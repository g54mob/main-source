using System;

namespace Mirror.SimpleWeb
{
	internal static class SimpleWebJSLib
	{
		internal static bool IsConnected(int index)
		{
			return false;
		}

		internal static int Connect(string address, Action<int> openCallback, Action<int> closeCallBack, Action<int, IntPtr, int> messageCallback, Action<int> errorCallback)
		{
			return 0;
		}

		internal static void Disconnect(int index)
		{
		}

		internal static bool Send(int index, byte[] array, int offset, int length)
		{
			return false;
		}
	}
}
