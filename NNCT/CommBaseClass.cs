using System;
using System.Collections.Generic;
using System.Text;

namespace NNCT
{
    interface ICommBase
    {
        bool sendMessage(byte[] buffer, int count, int offset);
        byte[] readMessage();

    }
    abstract class CommBaseClass : ICommBase
    {
        public abstract bool sendMessage(byte[] buffer, int count, int offset);
        public abstract byte[] readMessage();
    }
}
