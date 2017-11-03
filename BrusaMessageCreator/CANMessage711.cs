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

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct CANMessage_NLG_DEM_LIM
    {
        byte NLG_C_ClrError;        //NLG_C_ClrError 0	1
        byte NLG_C_UnlockConRq;     //NLG_C_UnlockConRq 1	1
        byte NLG_C_VentiRq;         //NLG_C_VentiRq 2	1
        UInt16 NLG_DcHvVoltLimMax;  //NLG_DcHvVoltLimMax 3	13
                               //NLG_StateDem 16	3
                              //NLG_DcHvCurrLimMax 21	11
                              //NLG_LedDem 32	4
                              //NLG_AcCurrLimMax 37	11
                              //NLG_C_EnPhaseShift 51	1
                              //NLG_AcPhaseShift 52	12
    }

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
        //BitArray[] bits = new BitArray[size * 8];
        BitVector32 vect0_31 = new BitVector32(0);
        BitVector32 vect32_63 = new BitVector32(0);

        MessageValue[] msgs = new MessageValue[10];


        string ICANMessage.MessageName { get => name; }

        uint ICANMessage.Size { get => size; }

        public CANMessage711()
        {
            //MessageValue[] msgs = new MessageValue[10];
            msgs[0] = new MessageValue("NLG_C_ClrError", 0, 0, 1);
            msgs[1] = new MessageValue("NLG_C_UnlockConRq", 0, 1, 1);
            msgs[2] = new MessageValue("NLG_C_VentiRq", 0, 2, 1);
            msgs[3] = new MessageValue("NLG_DcHvVoltLimMax", 0, 3, 13);
            msgs[4] = new MessageValue("NLG_StateDem", 0, 16, 3);
            msgs[5] = new MessageValue("NLG_DcHvCurrLimMax", 0, 21, 11);

            BitVector32.CreateSection(1);

            msgs[6] = new MessageValue("NLG_LedDem", 0, 32, 4);
            msgs[7] = new MessageValue("NLG_AcCurrLimMax", 0, 37, 11);
            msgs[8] = new MessageValue("NLG_C_EnPhaseShift", 0, 51, 1);
            msgs[9] = new MessageValue("NLG_AcPhaseShift", 0, 52, 12);

        }

        public byte[] Create(string[] param)
        {
            if (param.Length != 10) throw new ArgumentException(string.Format("CAN Message {0,20} must have {1,4} params", name , 10));
            byte[] buffer = new byte[8];
            
            //BitVector32.CreateSection()

            return buffer;
        }

        public bool Parse(string message)
        {
            bool res = false;

            return res;
        }

        byte[] ICANMessage.Create(string[] param)
        {
            throw new NotImplementedException();
        }

        bool ICANMessage.Parse(string message)
        {
            throw new NotImplementedException();
        }
    }
}
