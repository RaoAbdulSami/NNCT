using System;
using System.Collections.Generic;
using System.Text;

namespace NNCT
{
    interface ICommBase
    {
        bool sendMessage(byte[] buffer, int count, int offset);

    }
    abstract class CommBaseClass : ICommBase
    {
        public abstract bool sendMessage(byte[] buffer, int count, int offset);
    }
}
