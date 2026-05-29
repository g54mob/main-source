using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace LiteNetLib
{
	public static class NetUtils
	{
		private static readonly List<string> IpList;

		public static IPEndPoint MakeEndPoint(string hostStr, int port)
		{
			return null;
		}

		public static IPAddress ResolveAddress(string hostStr)
		{
			return null;
		}

		public static IPAddress ResolveAddress(string hostStr, AddressFamily addressFamily)
		{
			return null;
		}

		public static List<string> GetLocalIpList(LocalAddrType addrType)
		{
			return null;
		}

		public static void GetLocalIpList(IList<string> targetList, LocalAddrType addrType)
		{
		}

		public static string GetLocalIp(LocalAddrType addrType)
		{
			return null;
		}

		internal static void PrintInterfaceInfos()
		{
		}

		internal static int RelativeSequenceNumber(int number, int expected)
		{
			return 0;
		}

		internal static T[] AllocatePinnedUninitializedArray<T>(int count) where T : struct
		{
			return null;
		}
	}
}
