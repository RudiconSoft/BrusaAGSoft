using System;
using System.Collections.Specialized;

namespace Message711Test
{
    [Serializable]
    public class MessageValue
    {
        private string name;
        private UInt16 value;
        private byte offset;
        private byte size;

        public string Name { get => name; set => this.name = value; }
        public byte Size { get => size; set => this.size = value; }
        public byte Offset { get => offset; set => this.offset = value; }
        public UInt16 Value { get => value; set => this.value = value; }

        public MessageValue()
        {

        }
        public MessageValue(string name, UInt16 value, byte offset, byte size)
        {
            this.name = name;
            this.value = value;
            this.offset = offset;
            this.size = size;
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {
            //NLG_C_ClrError NLG_DEM_LIM 0   1
            //NLG_C_UnlockConRq NLG_DEM_LIM 1   1
            //NLG_C_VentiRq NLG_DEM_LIM 2   1
            //NLG_DcHvVoltLimMax NLG_DEM_LIM 3   13
            //NLG_StateDem NLG_DEM_LIM 16  3
            // 19 2
            //NLG_DcHvCurrLimMax NLG_DEM_LIM 21  11
            //NLG_LedDem NLG_DEM_LIM 32  4
            // 36 1
            //NLG_AcCurrLimMax NLG_DEM_LIM 37  11
            // 48 3
            //NLG_C_EnPhaseShift NLG_DEM_LIM 51  1
            //NLG_AcPhaseShift NLG_DEM_LIM 52  12
            MessageValue[] msgs = new MessageValue[13];
            //BitVector32.Section[] sec_v1 = new BitVector32.Section[7];
            //BitVector32.Section[] sec_v2 = new BitVector32.Section[7];

            // Initialize Message values for example
            ushort[] vals = 
            {
                0, 
                0,
                0,
                400, // NLG_DcHvVoltLimMax = 400 V  
                1,
                0, // for round
                60, // NLG_DcHvCurrLimMax = 60 A
                2,
                0, // for round
                60,// NLG_AcCurrLimMax = 60 A
                0, // for round
                0,
                0
            }; // 13 fields = 10 real + 3 unused

            msgs[0] = new MessageValue("NLG_C_ClrError"     , 0, 0, 1);
            msgs[1] = new MessageValue("NLG_C_UnlockConRq"  , 0, 1, 1);
            msgs[2] = new MessageValue("NLG_C_VentiRq"      , 0, 2, 1);
            msgs[3] = new MessageValue("NLG_DcHvVoltLimMax" , 0, 3, 13);
            msgs[4] = new MessageValue("NLG_StateDem"       , 0, 16, 3);
            msgs[5] = new MessageValue("NOT_USED"           , 0, 19, 2); // NOT USED
            msgs[6] = new MessageValue("NLG_DcHvCurrLimMax" , 0, 21, 11);
            msgs[7] = new MessageValue("NLG_LedDem"         , 0, 32, 4);
            msgs[8] = new MessageValue("NOT_USED"           , 0, 36, 1); // NOT USED
            msgs[9] = new MessageValue("NLG_AcCurrLimMax"   , 0, 37, 11);
            msgs[10] = new MessageValue("NOT_USED"          , 0, 48, 3); // NOT USED
            msgs[11] = new MessageValue("NLG_C_EnPhaseShift", 0, 51, 1);
            msgs[12] = new MessageValue("NLG_AcPhaseShift"  , 0, 52, 12);

            for (int i = 0; i < vals.Length; i++)
            {
                msgs[i].Value = vals[i];
            }

            // Create message bytes
            UInt64 p = 0;

            for (int i = 0; i < msgs.Length; i++)
            {
                switch (msgs[i].Name)
                {
                    case "NLG_DcHvVoltLimMax":
                        {
                            ushort temp = msgs[i].Value;
                            temp *= 10;

                            p <<= msgs[i].Size;
                            p |= temp;

                            break;
                        }
                    case "NLG_DcHvCurrLimMax":
                        {
                            ushort temp = msgs[i].Value;
                            temp *= 10;
                            temp += 1024;

                            p <<= 3;
                            p |= (ushort)(temp >> 8);
                            p <<= 8;
                            p |= (ushort) (temp & 0x00FF);

                            //
                            //byte[] bytes = BitConverter.GetBytes(temp);

                            //p <<= 3;
                            //p |= bytes[1];
                            //p <<= 8;
                            //p |= bytes[0];

                            break;
                        }
                    case "NLG_AcCurrLimMax":
                        {
                            ushort temp = msgs[i].Value;
                            temp *= 10;
                            temp += 1024;

                            p <<= 3;
                            p |= (ushort)(temp >> 8);
                            p <<= 8;
                            p |= (ushort)(temp & 0x00FF);

                            //byte[] bytes = BitConverter.GetBytes(temp);

                            //p <<= 3;
                            //p |= bytes[1];
                            //p <<= 8;
                            //p |= bytes[0];

                            break;
                        }
                    default:
                        {
                            p <<= msgs[i].Size;
                            p |= msgs[i].Value;
                        }
                        break;
                }
            }

            byte[] buff = BitConverter.GetBytes(p);
            Array.Reverse(buff);

            Console.WriteLine(BitConverter.ToString(buff));
            Console.ReadLine();
        }
    }
}


#region MyRegion

//using System;
//using System.Collections.Specialized;

//namespace Message711Test
//{
//    public class MessageValue
//    {
//        private string name;
//        private UInt16 value;
//        private byte offset;
//        private byte size;

//        public string Name { get => name; set => this.name = value; }
//        public byte Size { get => size; set => this.size = value; }
//        public byte Offset { get => offset; set => this.offset = value; }
//        public UInt16 Value { get => value; set => this.value = value; }

//        public MessageValue()
//        {

//        }
//        public MessageValue(string name, UInt16 value, byte offset, byte size)
//        {
//            this.name = name;
//            this.value = value;
//            this.offset = offset;
//            this.size = size;
//        }
//    }

//    class Class1
//    {
//        static void Main(string[] args)
//        {
//            //BitVector32 vector1 = new BitVector32(0);

//            ///* Маски для первых пяти битов */
//            //int bit1 = BitVector32.CreateMask();
//            //int bit2 = BitVector32.CreateMask(bit1);
//            //int bit3 = BitVector32.CreateMask(bit2);
//            //int bit4 = BitVector32.CreateMask(bit3);
//            //int bit5 = BitVector32.CreateMask(bit4);

//            //Console.WriteLine(vector1.ToString()); /* Получаем BitVector32{00000000000000000000000000000000} */
//            //vector1[bit1] = true; /* установить 1 бит */

//            //Console.WriteLine(vector1.ToString()); /* Получаем BitVector32{00000000000000000000000000000001} */

//            //vector1[bit3] = true; /* установить 3 бит */

//            //Console.WriteLine(vector1.ToString()); /* Получаем BitVector32{00000000000000000000000000000101} */

//            //vector1[bit5] = true; /* установить 5 бит */

//            //Console.WriteLine(vector1.ToString()); /* Получаем BitVector32{00000000000000000000000000010101} */

//            //BitVector32 vector2 = new BitVector32(0);

//            ///* Создаем 4 секции (окна). Первая имеет максимум значений 6, т.е занимает 4 бита. */
//            ///* Вторая - максимум 3 (т.е. два бита), затем 1 бит, затем 4 бита. */
//            //BitVector32.Section sect1 = BitVector32.CreateSection(6);
//            //BitVector32.Section sect2 = BitVector32.CreateSection(3, sect1);
//            //BitVector32.Section sect3 = BitVector32.CreateSection(1, sect2);
//            //BitVector32.Section sect4 = BitVector32.CreateSection(15, sect3);

//            //vector2[sect2] = 3;

//            //Console.WriteLine(vector2.ToString()); /* Получим BitVector32{00000000000000000000000000011000} */

//            //vector2[sect4] = 1;

//            //Console.WriteLine(vector2.ToString()); /* Получим BitVector32{00000000000000000000000001011000} */

//            ///
//            //NLG_C_ClrError NLG_DEM_LIM 0   1
//            //NLG_C_UnlockConRq NLG_DEM_LIM 1   1
//            //NLG_C_VentiRq NLG_DEM_LIM 2   1
//            //NLG_DcHvVoltLimMax NLG_DEM_LIM 3   13
//            //NLG_StateDem NLG_DEM_LIM 16  3
//            //NLG_DcHvCurrLimMax NLG_DEM_LIM 21  11
//            //NLG_LedDem NLG_DEM_LIM 32  4
//            //NLG_AcCurrLimMax NLG_DEM_LIM 37  11
//            //NLG_C_EnPhaseShift NLG_DEM_LIM 51  1
//            //NLG_AcPhaseShift NLG_DEM_LIM 52  12

//            BitVector32 vect0_31 = new BitVector32(0);
//            BitVector32 vect32_63 = new BitVector32(0);

//            // first 4 bytes
//            BitVector32.Section NLG_C_ClrError = BitVector32.CreateSection(1); // 1 bit
//            BitVector32.Section NLG_C_UnlockConRq = BitVector32.CreateSection(1, NLG_C_ClrError); // 1 bit
//            BitVector32.Section NLG_C_VentiRq = BitVector32.CreateSection(1, NLG_C_UnlockConRq); // 1 bit

//            BitVector32.Section NLG_DcHvVoltLimMax = BitVector32.CreateSection(8191, NLG_C_VentiRq); // 13 bits
//            BitVector32.Section NLG_StateDem = BitVector32.CreateSection(3, NLG_DcHvVoltLimMax); // 2 bits
//            BitVector32.Section NLG_StateDemXX = BitVector32.CreateSection(3, NLG_StateDem); // NOT USED 3 bits
//            BitVector32.Section NLG_DcHvCurrLimMax = BitVector32.CreateSection(2047, NLG_StateDemXX); // 11 bit

//            // next 4 bytes
//            BitVector32.Section NLG_LedDem = BitVector32.CreateSection(15);
//            BitVector32.Section NLG_AcCurrLimMax = BitVector32.CreateSection(2047, NLG_LedDem);
//            BitVector32.Section NLG_LedDemXX = BitVector32.CreateSection(3, NLG_AcCurrLimMax);
//            BitVector32.Section NLG_C_EnPhaseShift = BitVector32.CreateSection(1, NLG_AcCurrLimMax);
//            BitVector32.Section NLG_AcPhaseShift = BitVector32.CreateSection(4095, NLG_C_EnPhaseShift);

//            //NLG_C_ClrError NLG_DEM_LIM 0   1
//            //NLG_C_UnlockConRq NLG_DEM_LIM 1   1
//            //NLG_C_VentiRq NLG_DEM_LIM 2   1
//            //NLG_DcHvVoltLimMax NLG_DEM_LIM 3   13
//            //NLG_StateDem NLG_DEM_LIM 16  3
//            // 19 2
//            //NLG_DcHvCurrLimMax NLG_DEM_LIM 21  11
//            //NLG_LedDem NLG_DEM_LIM 32  4
//            // 36 1
//            //NLG_AcCurrLimMax NLG_DEM_LIM 37  11
//            // 48 3
//            //NLG_C_EnPhaseShift NLG_DEM_LIM 51  1
//            //NLG_AcPhaseShift NLG_DEM_LIM 52  12
//            MessageValue[] msgs = new MessageValue[13];
//            BitVector32.Section[] sec_v1 = new BitVector32.Section[7];
//            BitVector32.Section[] sec_v2 = new BitVector32.Section[7];

//            // Initialize Message values for example
//            ushort[] vals = { 0, 0, 0, 400, 1, 0, 60, 2, 0, 60, 0, 0, 0 };

//            msgs[0] = new MessageValue("NLG_C_ClrError", 0, 0, 1);
//            msgs[1] = new MessageValue("NLG_C_UnlockConRq", 0, 1, 1);
//            msgs[2] = new MessageValue("NLG_C_VentiRq", 0, 2, 1);
//            msgs[3] = new MessageValue("NLG_DcHvVoltLimMax", 0, 3, 13);
//            msgs[4] = new MessageValue("NLG_StateDem", 0, 16, 3);
//            msgs[5] = new MessageValue("NOT_USED", 0, 19, 2); // NOT USED
//            msgs[6] = new MessageValue("NLG_DcHvCurrLimMax", 0, 21, 11);
//            msgs[7] = new MessageValue("NLG_LedDem", 0, 32, 4);
//            msgs[8] = new MessageValue("NOT_USED", 0, 36, 1); // NOT USED
//            msgs[9] = new MessageValue("NLG_AcCurrLimMax", 0, 37, 11);
//            msgs[10] = new MessageValue("NOT_USED", 0, 48, 3); // NOT USED
//            msgs[11] = new MessageValue("NLG_C_EnPhaseShift", 0, 51, 1);
//            msgs[12] = new MessageValue("NLG_AcPhaseShift", 0, 52, 12);

//            for (int i = 0; i < vals.Length; i++)
//            {
//                msgs[i].Value = vals[i];
//            }

//            // Create message bytes
//            UInt64 p = 0;

//            for (int i = 0; i < msgs.Length; i++)
//            {
//                switch (msgs[i].Name)
//                {
//                    case "NLG_DcHvVoltLimMax":
//                        {
//                            UInt16 temp = msgs[i].Value;
//                            temp *= 10;

//                            //byte[] bytes = BitConverter.GetBytes(temp);

//                            //Console.WriteLine(BitConverter.ToString(bytes));
//                            //Console.WriteLine(Convert.ToString(temp, 2));

//                            //if (BitConverter.IsLittleEndian)
//                            //    Array.Reverse(bytes);
//                            //Console.WriteLine(BitConverter.ToString(bytes));

//                            //ushort volts = BitConverter.ToUInt16(bytes, 0);
//                            //Console.WriteLine(Convert.ToString(volts, 2));

//                            //byte[] bytesv = BitConverter.GetBytes(volts);
//                            //Console.WriteLine(BitConverter.ToString(bytesv));

//                            //// Call method to send byte stream across machine boundaries.

//                            //// Receive byte stream from beyond machine boundaries.
//                            //Console.WriteLine(BitConverter.ToString(bytes));
//                            //if (BitConverter.IsLittleEndian)
//                            //    Array.Reverse(bytes);

//                            //Console.WriteLine(BitConverter.ToString(bytes));

//                            //if (BitConverter.IsLittleEndian) Array.Reverse(buff);

//                            //string ts = Convert.ToString(temp, 2);
//                            //s += ts.Substring(msgs[i].Size, ts.Length - msgs[i].Size);

//                            p <<= msgs[i].Size;
//                            p |= temp;

//                            break;
//                        }
//                    case "NLG_DcHvCurrLimMax":
//                        {
//                            UInt16 temp = msgs[i].Value;
//                            temp *= 10;
//                            temp += 1024;

//                            byte[] bytes = BitConverter.GetBytes(temp);

//                            p <<= 8;
//                            p |= bytes[0];
//                            p <<= 8;
//                            p |= bytes[1];
//                            p >>= 5;

//                            //if (BitConverter.IsLittleEndian)
//                            //    Array.Reverse(bytes);

//                            //ushort ampers = BitConverter.ToUInt16(bytes, 0);
//                            //ampers >>= 5;
//                            //byte[] bytes1 = BitConverter.GetBytes(ampers);

//                            //if (BitConverter.IsLittleEndian)
//                            //    Array.Reverse(bytes1);
//                            //temp = BitConverter.ToUInt16(bytes, 0);
//                            //Console.WriteLine(Convert.ToString(ampers, 2));

//                            //byte[] bytesv = BitConverter.GetBytes(ampers);
//                            //Console.WriteLine(BitConverter.ToString(bytesv));
//                            //p <<= msgs[i].Size;
//                            //p |= temp;
//                            //string ts = Convert.ToString(temp, 2);
//                            //s += ts.Substring(msgs[i].Size, ts.Length - msgs[i].Size);

//                            break;
//                        }
//                    case "NLG_AcCurrLimMax":
//                        {
//                            UInt16 temp = msgs[i].Value;
//                            temp *= 10;
//                            temp += 1024;

//                            byte[] bytes = BitConverter.GetBytes(temp);

//                            p <<= 8;
//                            p |= bytes[0];
//                            p <<= 8;
//                            p |= bytes[1];
//                            p >>= 5;


//                            //byte[] bytes = BitConverter.GetBytes(temp);

//                            //if (BitConverter.IsLittleEndian)
//                            //    Array.Reverse(bytes);

//                            //ushort ampers = BitConverter.ToUInt16(bytes, 0);
//                            //Console.WriteLine(Convert.ToString(ampers, 2));

//                            //byte[] bytesv = BitConverter.GetBytes(ampers);
//                            //Console.WriteLine(BitConverter.ToString(bytesv));

//                            //p <<= msgs[i].Size;
//                            //p |= temp;

//                            //string ts = Convert.ToString(temp, 2);
//                            //s += ts.Substring(msgs[i].Size, ts.Length - msgs[i].Size);

//                            break;
//                        }
//                    default:
//                        {
//                            UInt16 temp = msgs[i].Value;
//                            p = p << msgs[i].Size;
//                            p |= temp;

//                            //string ts = Convert.ToString(temp, 2);
//                            //s += ts.Substring(msgs[i].Size, ts.Length - msgs[i].Size);
//                        }
//                        break;
//                }
//            }

//            byte[] buff = BitConverter.GetBytes(p);

//            Console.WriteLine(BitConverter.ToString(buff));

//            //Console.WriteLine(Convert.ToUInt64(s, 2));


//            Console.ReadLine();
//        }

//        //        private string GetBits(UInt64 )
//        //{

//        //}
//    }
//}
#endregion
