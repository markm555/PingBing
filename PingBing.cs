/*
Author: Mark Moore
Created: 8/21/2017
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PingBing

{
    public class PingExample
    {
        // args[0] can be an IPaddress or host name.
        public static void Main(string[] args)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string host = "bing.com";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            int i = 1;
            
            while (i < 2)
                {
                PingReply reply = pingSender.Send(host, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                  Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                }
            }
        }
    }
}