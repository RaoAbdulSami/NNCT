using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
namespace NNCT
{
    class SerialComm : CommBaseClass
    {
        ///////////////////////////////////////////// variables ///////////////////////////////////
        private SerialPort serialPort;
        private string _portName;
        private int _baudRate;
        
        /////////////////////////////////////////////  Properties /////////////////////////////////

        public string PortName
        {
            get { return _portName; }
            set
            {

                if (string.IsNullOrEmpty(value) == false)
                {
                    _portName = value;

                }
                else
                {
                    throw new Exception("Empty Port Name");
                }
            }
        }


        public int BaudRate
        {
            get { return _baudRate; }
            set
            {
                Type t = value.GetType();
                if (t.Equals(typeof(string)))
                {
                    try
                    {
                        _baudRate = (int)value;

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        _baudRate = value;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
        }

        //////////////////////////////////////////// Constructors ///////////////////////////////

        public SerialComm()
        {
            serialPort = new SerialPort();
        }
        //////////////////////////////////////////// Methods /////////////////////////////////////
        
        public string[] getSerialPortNames ()
        {
            return SerialPort.GetPortNames();
        }



        public override bool sendMessage(byte[] buffer , int count , int offset = 0)
        {
            if(serialPort.IsOpen == false)
            {
                openPort();
            }

            try
            {
                serialPort.Write(buffer, offset, count);
                if (serialPort.WriteBufferSize == count)
                {
                    return true;
                }

                else
                {
                  throw new Exception("Some data maynot be writter");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }


        }

        public override byte[] readMessage()
        {

        }



        private void openPort()
        {
            try
            {

            serialPort.PortName = PortName;
            serialPort.BaudRate = BaudRate;
            serialPort.Open();
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        public void closePort()
        {
            if (serialPort.IsOpen == true)
            {
                try
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
