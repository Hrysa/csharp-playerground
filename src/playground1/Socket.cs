using System.Net;
using System.Net.Sockets;
using NUnit.Framework;
using shared;

namespace playground1;

public class SocketTest
{
    EndPoint _endPoint = new IPEndPoint(IPAddress.Parse("172.22.1.59"), 8888);

    [Test]
    public void UdpSend()
    {
        Helper.MeasureTime(() =>
        {
            Helper.MeasureGC(() =>
            {
                SocketAddress sa = _endPoint.Serialize();
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte[] buff = new byte[80];
                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = (byte)'a';
                }

                for (int i = 0; i < 100000; i++)
                {
                    socket.SendTo(buff, SocketFlags.None, sa);
                }
            });
        });
    }

    [Test]
    public void TcpSend()
    {
        Helper.MeasureTime(() =>
        {
            Helper.MeasureGC(() =>
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(_endPoint);
                byte[] buff = new byte[80];
                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = (byte)'a';
                }

                for (int i = 0; i < 100000; i++)
                {
                    socket.Send(buff);
                }
            });
        });
    }
}