using System;
using System.Collections.Generic;
using System.Text;

namespace NNCT
{
    interface ICommBase
    {
        bool sendMessage(byte[] buffer);

    }
    abstract class CommBaseClass
    {
        public abstract bool sendMessage(byte[] buffer);
    }
}
