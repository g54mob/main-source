using System.Net;
using System.Net.Sockets;

public class LocalIPHelper
{
	public static string GetLocalIP()
	{
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return iPAddress.ToString();
			}
		}
		return "";
	}
}
