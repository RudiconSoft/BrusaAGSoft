using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BrusaMessageCreator
{
    //[Flags]
    //public enum Msg711_3
    //{
    //    None = 0,
    //    NLG_C_ClrError = 1,
    //    NLG_C_UnlockConRq = 2,
    //    NLG_C_VentiRq = 4,
    //}


    //struct CANMessage_NLG_DEM_LIM
    //{
    //    byte NLG_C_ClrError;        //NLG_C_ClrError 0	1
    //    byte NLG_C_UnlockConRq;     //NLG_C_UnlockConRq 1	1
    //    byte NLG_C_VentiRq;         //NLG_C_VentiRq 2	1
    //    UInt16 NLG_DcHvVoltLimMax;  //NLG_DcHvVoltLimMax 3	13
    //                                //byte                       //NLG_StateDem 16	3
    //                                //NLG_DcHvCurrLimMax 21	11
    //                                //NLG_LedDem 32	4
    //                                //NLG_AcCurrLimMax 37	11
    //                                //NLG_C_EnPhaseShift 51	1
    //                                //NLG_AcPhaseShift 52	12
    //}

    internal class CANMessage711:ICANMessage
    {
        private const string name = "NLG_DEM_LIM";
        private const uint size = 8;
        private const uint paramCnt = 13;
        private byte[] messageBuff = new byte[size];

        MessageValue[] msgs = new MessageValue[paramCnt];

        string ICANMessage.MessageName { get => name; }

        uint ICANMessage.Size { get => size; }
        public byte[] MessageBuff { get => messageBuff; set => messageBuff = value; }

        public CANMessage711()
        {
            msgs[0] = new MessageValue("NLG_C_ClrError", 0, 0, 1);
            msgs[1] = new MessageValue("NLG_C_UnlockConRq", 0, 1, 1);
            msgs[2] = new MessageValue("NLG_C_VentiRq", 0, 2, 1);
            msgs[3] = new MessageValue("NLG_DcHvVoltLimMax", 0, 3, 13);
            msgs[4] = new MessageValue("NLG_StateDem", 0, 16, 3);
            msgs[5] = new MessageValue("NOT_USED", 0, 19, 2); // NOT USED
            msgs[6] = new MessageValue("NLG_DcHvCurrLimMax", 0, 21, 11);
            msgs[7] = new MessageValue("NLG_LedDem", 0, 32, 4);
            msgs[8] = new MessageValue("NOT_USED", 0, 36, 1); // NOT USED
            msgs[9] = new MessageValue("NLG_AcCurrLimMax", 0, 37, 11);
            msgs[10] = new MessageValue("NOT_USED", 0, 48, 3); // NOT USED
            msgs[11] = new MessageValue("NLG_C_EnPhaseShift", 0, 51, 1);
            msgs[12] = new MessageValue("NLG_AcPhaseShift", 0, 52, 12);
        }

        public byte[] Create(string[] param)
        {
            if (param.Length != paramCnt) throw new ArgumentException(string.Format("CAN Message {0,20} must have {1,4} params", name , msgs.Length));
            //MessageValue[] msgs = new MessageValue[13];

            // Initialize Message values for example
            //ushort[] vals =
            //{
            //    0,
            //    0,
            //    0,
            //    400, // NLG_DcHvVoltLimMax = 400 V  
            //    1,
            //    0, // for round
            //    60, // NLG_DcHvCurrLimMax = 60 A
            //    2,
            //    0, // for round
            //    60,// NLG_AcCurrLimMax = 60 A
            //    0, // for round
            //    0,
            //    0
            //}; // 13 fields = 10 real + 3 unused

            //ushort[] vals = new ushort[13];


            for (int i = 0; i < param.Length; i++)
            {
                msgs[i].Value = Convert.ToUInt16(param[i]);
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
                            p |= (ushort)(temp & 0x00FF);

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

            //byte[] buff = BitConverter.GetBytes(p);
            //Array.Reverse(buff);

            ////Console.WriteLine(BitConverter.ToString(buff));
            ////Console.ReadLine();

            //return buff;
            messageBuff = BitConverter.GetBytes(p);
            Array.Reverse(messageBuff);
            return messageBuff;
        }

        public bool Parse(string message)
        {
            bool res = false;

            return res;
        }

        public override string ToString()
        {
            return BitConverter.ToString(messageBuff);
        }

        //byte[] ICANMessage.Create(string[] param)
        //{
        //    throw new NotImplementedException();
        //}

        //bool ICANMessage.Parse(string message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}


