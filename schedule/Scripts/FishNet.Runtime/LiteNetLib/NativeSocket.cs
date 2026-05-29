using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LiteNetLib
{
	internal static class NativeSocket
	{
		private static class WinSock
		{
			private const string LibName = "ws2_32.dll";

			[PreserveSig]
			public static extern int recvfrom(IntPtr socketHandle, [In][Out] byte[] pinnedBuffer, [In] int len, [In] SocketFlags socketFlags, [Out] byte[] socketAddress, [In][Out] ref int socketAddressSize);

			[PreserveSig]
			internal static extern int sendto(IntPtr socketHandle, [In] byte[] pinnedBuffer, [In] int len, [In] SocketFlags socketFlags, [In] byte[] socketAddress, [In] int socketAddressSize);
		}

		private static class UnixSock
		{
			private const string LibName = "libc";

			[PreserveSig]
			public static extern int recvfrom(IntPtr socketHandle, [In][Out] byte[] pinnedBuffer, [In] int len, [In] SocketFlags socketFlags, [Out] byte[] socketAddress, [In][Out] ref int socketAddressSize);

			[PreserveSig]
			internal static extern int sendto(IntPtr socketHandle, [In] byte[] pinnedBuffer, [In] int len, [In] SocketFlags socketFlags, [In] byte[] socketAddress, [In] int socketAddressSize);
		}

		public static readonly bool IsSupported;

		public static readonly bool UnixMode;

		public const int IPv4AddrSize = 16;

		public const int IPv6AddrSize = 28;

		public const int AF_INET = 2;

		public const int AF_INET6 = 10;

		private static readonly Dictionary<int, SocketError> NativeErrorToSocketError;

		static NativeSocket()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int RecvFrom(IntPtr socketHandle, byte[] pinnedBuffer, int len, byte[] socketAddress, ref int socketAddressSize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int SendTo(IntPtr socketHandle, byte[] pinnedBuffer, int len, byte[] socketAddress, int socketAddressSize)
		{
			return 0;
		}

		public static SocketError GetSocketError()
		{
			return default(SocketError);
		}

		public static SocketException GetSocketException()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short GetNativeAddressFamily(IPEndPoint remoteEndPoint)
		{
			return 0;
		}
	}
}
