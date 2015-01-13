using System;
using System.Collections.Generic;
using System.Text;

using SagaLib;
using SagaWorld;
using SagaWorld.Network.Client;

using SagaDB.Actor;

namespace SagaWorld.Packets.Client
{
    public class CSMG_CHAR_DELETE : Packet
    {
        public CSMG_CHAR_DELETE()
        {
            this.offset = 2;
        }

        public byte Slot
        {
            get
            {
                return this.GetByte(2);
            }
        }

        public string DeletePassword
        {
            get
            {
                byte size = this.GetByte(3);
                size--;
                return System.Text.Encoding.ASCII.GetString(this.GetBytes(size, 4));
            }
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaWorld.Packets.Client.CSMG_CHAR_DELETE();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((WorldClient)(client)).OnCharDelete(this);
        }

    }
}