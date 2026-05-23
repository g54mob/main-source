using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Lidgren.Network
{
	public static class NetUtility
	{
		public delegate void ResolveEndPointCallback(IPEndPoint endPoint);

		public delegate void ResolveAddressCallback(IPAddress adr);

		private static readonly bool IsMono;

		private static IPAddress s_broadcastAddress;

		private static byte[] s_randomMacBytes;

		private static readonly SHA1 s_sha;

		public static void ResolveAsync(string ipOrHost, int port, ResolveEndPointCallback callback)
		{
			ResolveAsync(ipOrHost, delegate(IPAddress adr)
			{
				if (adr == null)
				{
					callback(null);
				}
				else
				{
					callback(new IPEndPoint(adr, port));
				}
			});
		}

		public static IPEndPoint Resolve(string ipOrHost, int port)
		{
			IPAddress iPAddress = Resolve(ipOrHost);
			if (iPAddress != null)
			{
				return new IPEndPoint(iPAddress, port);
			}
			return null;
		}

		public static IPAddress GetCachedBroadcastAddress()
		{
			if (s_broadcastAddress == null)
			{
				s_broadcastAddress = GetBroadcastAddress();
			}
			return s_broadcastAddress;
		}

		public static void ResolveAsync(string ipOrHost, ResolveAddressCallback callback)
		{
			if (string.IsNullOrEmpty(ipOrHost))
			{
				throw new ArgumentException("Supplied string must not be empty", "ipOrHost");
			}
			ipOrHost = ipOrHost.Trim();
			IPAddress address = null;
			if (IPAddress.TryParse(ipOrHost, out address))
			{
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					callback(address);
					return;
				}
				throw new ArgumentException("This method will not currently resolve other than ipv4 addresses");
			}
			try
			{
				IPHostEntry entry;
				Dns.BeginGetHostEntry(ipOrHost, delegate(IAsyncResult result)
				{
					try
					{
						entry = Dns.EndGetHostEntry(result);
					}
					catch (SocketException ex2)
					{
						if (ex2.SocketErrorCode == SocketError.HostNotFound)
						{
							callback(null);
							return;
						}
						throw;
					}
					if (entry == null)
					{
						callback(null);
					}
					else
					{
						IPAddress[] addressList = entry.AddressList;
						foreach (IPAddress iPAddress in addressList)
						{
							if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
							{
								callback(iPAddress);
								return;
							}
						}
						callback(null);
					}
				}, null);
			}
			catch (SocketException ex)
			{
				if (ex.SocketErrorCode == SocketError.HostNotFound)
				{
					callback(null);
					return;
				}
				throw;
			}
		}

		public static IPAddress Resolve(string ipOrHost)
		{
			if (string.IsNullOrEmpty(ipOrHost))
			{
				throw new ArgumentException("Supplied string must not be empty", "ipOrHost");
			}
			ipOrHost = ipOrHost.Trim();
			IPAddress address = null;
			if (IPAddress.TryParse(ipOrHost, out address))
			{
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					return address;
				}
				throw new ArgumentException("This method will not currently resolve other than ipv4 addresses");
			}
			try
			{
				IPAddress[] hostAddresses = Dns.GetHostAddresses(ipOrHost);
				if (hostAddresses == null)
				{
					return null;
				}
				IPAddress[] array = hostAddresses;
				foreach (IPAddress iPAddress in array)
				{
					if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
					{
						return iPAddress;
					}
				}
				return null;
			}
			catch (SocketException ex)
			{
				if (ex.SocketErrorCode == SocketError.HostNotFound)
				{
					return null;
				}
				throw;
			}
		}

		public static string ToHexString(long data)
		{
			return ToHexString(BitConverter.GetBytes(data));
		}

		public static string ToHexString(byte[] data)
		{
			return ToHexString(data, 0, data.Length);
		}

		public static string ToHexString(byte[] data, int offset, int length)
		{
			char[] array = new char[length * 2];
			for (int i = 0; i < length; i++)
			{
				byte b = (byte)(data[offset + i] >> 4);
				array[i * 2] = (char)((b > 9) ? (b + 55) : (b + 48));
				b = (byte)(data[offset + i] & 0xF);
				array[i * 2 + 1] = (char)((b > 9) ? (b + 55) : (b + 48));
			}
			return new string(array);
		}

		public static bool IsLocal(IPEndPoint endPoint)
		{
			if (endPoint == null)
			{
				return false;
			}
			return IsLocal(endPoint.Address);
		}

		public static bool IsLocal(IPAddress remote)
		{
			IPAddress mask;
			IPAddress myAddress = GetMyAddress(out mask);
			if (mask == null)
			{
				return false;
			}
			uint num = BitConverter.ToUInt32(mask.GetAddressBytes(), 0);
			uint num2 = BitConverter.ToUInt32(remote.GetAddressBytes(), 0);
			uint num3 = BitConverter.ToUInt32(myAddress.GetAddressBytes(), 0);
			return (num2 & num) == (num3 & num);
		}

		[CLSCompliant(false)]
		public static int BitsToHoldUInt(uint value)
		{
			int num = 1;
			while ((value >>= 1) != 0)
			{
				num++;
			}
			return num;
		}

		[CLSCompliant(false)]
		public static int BitsToHoldUInt64(ulong value)
		{
			int num = 1;
			while ((value >>= 1) != 0L)
			{
				num++;
			}
			return num;
		}

		public static int BytesToHoldBits(int numBits)
		{
			return (numBits + 7) / 8;
		}

		internal static uint SwapByteOrder(uint value)
		{
			return ((value & 0xFF000000u) >> 24) | ((value & 0xFF0000) >> 8) | ((value & 0xFF00) << 8) | ((value & 0xFF) << 24);
		}

		internal static ulong SwapByteOrder(ulong value)
		{
			return ((value & 0xFF00000000000000uL) >> 56) | ((value & 0xFF000000000000L) >> 40) | ((value & 0xFF0000000000L) >> 24) | ((value & 0xFF00000000L) >> 8) | ((value & 0xFF000000u) << 8) | ((value & 0xFF0000) << 24) | ((value & 0xFF00) << 40) | ((value & 0xFF) << 56);
		}

		internal static bool CompareElements(byte[] one, byte[] two)
		{
			if (one.Length != two.Length)
			{
				return false;
			}
			for (int i = 0; i < one.Length; i++)
			{
				if (one[i] != two[i])
				{
					return false;
				}
			}
			return true;
		}

		public static byte[] ToByteArray(string hexString)
		{
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < hexString.Length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
			}
			return array;
		}

		public static string ToHumanReadable(long bytes)
		{
			if (bytes < 4000)
			{
				return bytes + " bytes";
			}
			if (bytes < 1000000)
			{
				return Math.Round((double)bytes / 1000.0, 2) + " kilobytes";
			}
			return Math.Round((double)bytes / 1000000.0, 2) + " megabytes";
		}

		internal static int RelativeSequenceNumber(int nr, int expected)
		{
			return (nr - expected + 1024 + 512) % 1024 - 512;
		}

		public static int GetWindowSize(NetDeliveryMethod method)
		{
			switch (method)
			{
			case NetDeliveryMethod.Unreliable:
			case NetDeliveryMethod.UnreliableSequenced:
				if (method - 1 > NetDeliveryMethod.Unreliable)
				{
					break;
				}
				return 128;
			case NetDeliveryMethod.Unknown:
				return 0;
			case NetDeliveryMethod.ReliableOrdered:
				return 64;
			}
			return 64;
		}

		internal static void SortMembersList(MemberInfo[] list)
		{
			int num = 1;
			while (num * 3 + 1 <= list.Length)
			{
				num = 3 * num + 1;
			}
			while (num > 0)
			{
				for (int i = num - 1; i < list.Length; i++)
				{
					MemberInfo memberInfo = list[i];
					int num2 = i;
					while (num2 >= num && string.Compare(list[num2 - num].Name, memberInfo.Name, StringComparison.InvariantCulture) > 0)
					{
						list[num2] = list[num2 - num];
						num2 -= num;
					}
					list[num2] = memberInfo;
				}
				num /= 3;
			}
		}

		internal static NetDeliveryMethod GetDeliveryMethod(NetMessageType mtp)
		{
			if ((int)mtp >= 67)
			{
				return NetDeliveryMethod.ReliableOrdered;
			}
			if ((int)mtp >= 35)
			{
				return NetDeliveryMethod.ReliableSequenced;
			}
			if ((int)mtp >= 34)
			{
				return NetDeliveryMethod.ReliableUnordered;
			}
			if ((int)mtp >= 2)
			{
				return NetDeliveryMethod.UnreliableSequenced;
			}
			return NetDeliveryMethod.Unreliable;
		}

		public static string MakeCommaDelimitedList<T>(IList<T> list)
		{
			int count = list.Count;
			StringBuilder stringBuilder = new StringBuilder(count * 5);
			for (int i = 0; i < count; i++)
			{
				stringBuilder.Append(list[i].ToString());
				if (i != count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			return stringBuilder.ToString();
		}

		public static byte[] ComputeSHAHash(byte[] bytes)
		{
			return ComputeSHAHash(bytes, 0, bytes.Length);
		}

		static NetUtility()
		{
			IsMono = Type.GetType("Mono.Runtime") != null;
			s_sha = SHA1.Create();
		}

		[CLSCompliant(false)]
		public static ulong GetPlatformSeed(int seedInc)
		{
			return (ulong)(((long)Environment.TickCount + (long)seedInc) ^ ((long)new object().GetHashCode() << 32));
		}

		public static IPAddress GetMyAddress(out IPAddress mask)
		{
			mask = null;
			try
			{
				if (Application.internetReachability != NetworkReachability.NotReachable)
				{
					return null;
				}
				return IPAddress.Parse(UnityEngine.Network.player.externalIP);
			}
			catch
			{
				return null;
			}
		}

		public static byte[] GetMacAddressBytes()
		{
			if (s_randomMacBytes == null)
			{
				s_randomMacBytes = new byte[8];
				MWCRandom.Instance.NextBytes(s_randomMacBytes);
			}
			return s_randomMacBytes;
		}

		public static IPAddress GetBroadcastAddress()
		{
			return IPAddress.Broadcast;
		}

		public static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		public static IPAddress CreateAddressFromBytes(byte[] bytes)
		{
			return new IPAddress(bytes);
		}

		public static byte[] ComputeSHAHash(byte[] bytes, int offset, int count)
		{
			return s_sha.ComputeHash(bytes, offset, count);
		}
	}
}
