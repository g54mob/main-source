using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class fjEmcRZhornhXQIvPjJCiBgYhDod : IEqualityComparer, IEqualityComparer<int>
		{
			private static fjEmcRZhornhXQIvPjJCiBgYhDod pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static fjEmcRZhornhXQIvPjJCiBgYhDod ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new fjEmcRZhornhXQIvPjJCiBgYhDod());

			public bool Equals(int x, int y)
			{
				return x == y;
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is int) || !(y is int))
				{
					return false;
				}
				return Equals((int)x, (int)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is int))
				{
					return 0;
				}
				return GetHashCode((int)obj);
			}
		}

		private class QLqdQiaHVhtuigfUpynPzVsoFeQx : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static QLqdQiaHVhtuigfUpynPzVsoFeQx pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static QLqdQiaHVhtuigfUpynPzVsoFeQx ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new QLqdQiaHVhtuigfUpynPzVsoFeQx());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is ulong) || !(y is ulong))
				{
					return false;
				}
				return Equals((ulong)x, (ulong)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return GetHashCode((ulong)obj);
			}
		}

		private class UKaplYgIBGCXQKwvsuDpEMnWAcVr : IEqualityComparer, IEqualityComparer<uint>
		{
			private static UKaplYgIBGCXQKwvsuDpEMnWAcVr pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static UKaplYgIBGCXQKwvsuDpEMnWAcVr ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new UKaplYgIBGCXQKwvsuDpEMnWAcVr());

			public bool Equals(uint x, uint y)
			{
				return x == y;
			}

			public int GetHashCode(uint obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is uint) || !(y is uint))
				{
					return false;
				}
				return Equals((uint)x, (uint)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is uint))
				{
					return 0;
				}
				return GetHashCode((uint)obj);
			}
		}

		private class xvyvfBSSwDbKZMmnUaxcoeHENchB : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static xvyvfBSSwDbKZMmnUaxcoeHENchB pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static xvyvfBSSwDbKZMmnUaxcoeHENchB ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new xvyvfBSSwDbKZMmnUaxcoeHENchB());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is ulong) || !(y is ulong))
				{
					return false;
				}
				return Equals((ulong)x, (ulong)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return GetHashCode((ulong)obj);
			}
		}

		private class qaQMRRewZPKRfRqkzGRoAgvAqAaq : IEqualityComparer, IEqualityComparer<float>
		{
			private static qaQMRRewZPKRfRqkzGRoAgvAqAaq pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static qaQMRRewZPKRfRqkzGRoAgvAqAaq ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new qaQMRRewZPKRfRqkzGRoAgvAqAaq());

			public bool Equals(float x, float y)
			{
				return x == y;
			}

			public int GetHashCode(float obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is float) || !(y is float))
				{
					return false;
				}
				return Equals((float)x, (float)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is float))
				{
					return 0;
				}
				return GetHashCode((float)obj);
			}
		}

		private class jandWDQQWFzEwWjKAztrjovzAkqBA : IEqualityComparer, IEqualityComparer<double>
		{
			private static jandWDQQWFzEwWjKAztrjovzAkqBA pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static jandWDQQWFzEwWjKAztrjovzAkqBA ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new jandWDQQWFzEwWjKAztrjovzAkqBA());

			public bool Equals(double x, double y)
			{
				return x == y;
			}

			public int GetHashCode(double obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is double) || !(y is double))
				{
					return false;
				}
				return Equals((double)x, (double)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is double))
				{
					return 0;
				}
				return GetHashCode((double)obj);
			}
		}

		private class nFANaqIpHrYGorlUeZXrPGMEdEpw : IEqualityComparer, IEqualityComparer<byte>
		{
			private static nFANaqIpHrYGorlUeZXrPGMEdEpw pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static nFANaqIpHrYGorlUeZXrPGMEdEpw ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new nFANaqIpHrYGorlUeZXrPGMEdEpw());

			public bool Equals(byte x, byte y)
			{
				return x == y;
			}

			public int GetHashCode(byte obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is byte) || !(y is byte))
				{
					return false;
				}
				return Equals((byte)x, (byte)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is byte))
				{
					return 0;
				}
				return GetHashCode((byte)obj);
			}
		}

		private class cAouJvQNKrgzygCvxbXbfDOccEtsb : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static cAouJvQNKrgzygCvxbXbfDOccEtsb pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static cAouJvQNKrgzygCvxbXbfDOccEtsb ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new cAouJvQNKrgzygCvxbXbfDOccEtsb());

			public bool Equals(sbyte x, sbyte y)
			{
				return x == y;
			}

			public int GetHashCode(sbyte obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is sbyte) || !(y is sbyte))
				{
					return false;
				}
				return Equals((sbyte)x, (sbyte)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is sbyte))
				{
					return 0;
				}
				return GetHashCode((sbyte)obj);
			}
		}

		private class RAznVCzdCytsuGkrxvwfXsahTDIf : IEqualityComparer, IEqualityComparer<bool>
		{
			private static RAznVCzdCytsuGkrxvwfXsahTDIf pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static RAznVCzdCytsuGkrxvwfXsahTDIf ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new RAznVCzdCytsuGkrxvwfXsahTDIf());

			public bool Equals(bool x, bool y)
			{
				return x == y;
			}

			public int GetHashCode(bool obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is bool) || !(y is bool))
				{
					return false;
				}
				return Equals((bool)x, (bool)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is bool))
				{
					return 0;
				}
				return GetHashCode((bool)obj);
			}
		}

		private class VZoZDbDnccoOgsZLzkKjvuNIHczQ : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static VZoZDbDnccoOgsZLzkKjvuNIHczQ pMPfMxiMGqmaqpkaIxsUKKMNLzbab;

			public static VZoZDbDnccoOgsZLzkKjvuNIHczQ ccczNqsNLdBVbHnxRjOzBZTknCGZ => pMPfMxiMGqmaqpkaIxsUKKMNLzbab ?? (pMPfMxiMGqmaqpkaIxsUKKMNLzbab = new VZoZDbDnccoOgsZLzkKjvuNIHczQ());

			public bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			public int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is IntPtr) || !(y is IntPtr))
				{
					return false;
				}
				return Equals((IntPtr)x, (IntPtr)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is IntPtr))
				{
					return 0;
				}
				return GetHashCode((IntPtr)obj);
			}
		}

		public static IEqualityComparer<T> Default
		{
			get
			{
				Type typeFromHandle = typeof(T);
				if ((object)typeFromHandle == typeof(int))
				{
					return (IEqualityComparer<T>)fjEmcRZhornhXQIvPjJCiBgYhDod.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(long))
				{
					return (IEqualityComparer<T>)QLqdQiaHVhtuigfUpynPzVsoFeQx.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(uint))
				{
					return (IEqualityComparer<T>)UKaplYgIBGCXQKwvsuDpEMnWAcVr.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(ulong))
				{
					return (IEqualityComparer<T>)xvyvfBSSwDbKZMmnUaxcoeHENchB.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(float))
				{
					return (IEqualityComparer<T>)qaQMRRewZPKRfRqkzGRoAgvAqAaq.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(double))
				{
					return (IEqualityComparer<T>)jandWDQQWFzEwWjKAztrjovzAkqBA.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(byte))
				{
					return (IEqualityComparer<T>)nFANaqIpHrYGorlUeZXrPGMEdEpw.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(sbyte))
				{
					return (IEqualityComparer<T>)cAouJvQNKrgzygCvxbXbfDOccEtsb.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(bool))
				{
					return (IEqualityComparer<T>)RAznVCzdCytsuGkrxvwfXsahTDIf.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				if ((object)typeFromHandle == typeof(IntPtr))
				{
					return (IEqualityComparer<T>)VZoZDbDnccoOgsZLzkKjvuNIHczQ.ccczNqsNLdBVbHnxRjOzBZTknCGZ;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
