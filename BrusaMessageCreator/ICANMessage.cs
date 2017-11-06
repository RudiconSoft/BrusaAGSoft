using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusaMessageCreator
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

    public interface ICANMessage
    {
        string MessageName { get; } // NLG_DEM_LIM etc.
        uint Size { get; }

        bool Parse(string message);// parse message from string  ex. (0F A0 26 6C 25 40 00 00)
        byte[] Create(string[] param); //
    }
}
