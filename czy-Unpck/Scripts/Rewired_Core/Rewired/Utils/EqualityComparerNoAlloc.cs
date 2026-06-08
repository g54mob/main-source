using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class HgNFmBgjKiXhouJEWCFRWqagkGBI : IEqualityComparer, IEqualityComparer<int>
		{
			private static HgNFmBgjKiXhouJEWCFRWqagkGBI BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static HgNFmBgjKiXhouJEWCFRWqagkGBI Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new HgNFmBgjKiXhouJEWCFRWqagkGBI());

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
				if (object.ReferenceEquals(x, null))
				{
					if (object.ReferenceEquals(y, null))
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
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 1366084906;
						while (true)
						{
							switch (num ^ 0x516CCD2B)
							{
							case 0:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is int))
							{
								num = 1366084905;
								continue;
							}
							return GetHashCode((int)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class ympFYLMKocKqfhQUaeHZnNPENBd : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static ympFYLMKocKqfhQUaeHZnNPENBd BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static ympFYLMKocKqfhQUaeHZnNPENBd Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new ympFYLMKocKqfhQUaeHZnNPENBd());

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
				if (object.ReferenceEquals(x, null))
				{
					if (object.ReferenceEquals(y, null))
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
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 1197324443;
						while (true)
						{
							switch (num ^ 0x475DB89A)
							{
							case 0:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is ulong))
							{
								num = 1197324440;
								continue;
							}
							return GetHashCode((ulong)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class qerbAlCFiDPtNHEbtEpbAUIeIVm : IEqualityComparer, IEqualityComparer<uint>
		{
			private static qerbAlCFiDPtNHEbtEpbAUIeIVm BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static qerbAlCFiDPtNHEbtEpbAUIeIVm Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new qerbAlCFiDPtNHEbtEpbAUIeIVm());

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
				if (object.ReferenceEquals(x, null))
				{
					if (object.ReferenceEquals(y, null))
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
				if (object.ReferenceEquals(obj, null) || !(obj is uint))
				{
					return 0;
				}
				return GetHashCode((uint)obj);
			}
		}

		private class FajedYIqxGYrDqVusRIvOoPwLeBV : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static FajedYIqxGYrDqVusRIvOoPwLeBV BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static FajedYIqxGYrDqVusRIvOoPwLeBV Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new FajedYIqxGYrDqVusRIvOoPwLeBV());

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
				if (object.ReferenceEquals(x, null))
				{
					goto IL_0009;
				}
				int num;
				if (x is ulong)
				{
					if (!(y is ulong))
					{
						num = 799124355;
						goto IL_000e;
					}
					return Equals((ulong)x, (ulong)y);
				}
				goto IL_004b;
				IL_0009:
				num = 799124352;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x2FA1AB82)
				{
				case 0:
					break;
				case 2:
					goto IL_0027;
				default:
					goto IL_004b;
				}
				goto IL_0009;
				IL_004b:
				return false;
				IL_0027:
				if (object.ReferenceEquals(y, null))
				{
					return true;
				}
				return false;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (object.ReferenceEquals(obj, null) || !(obj is ulong))
				{
					return 0;
				}
				return GetHashCode((ulong)obj);
			}
		}

		private class WqDRPmIdsQZXsUVkshlkCEOcrHB : IEqualityComparer, IEqualityComparer<float>
		{
			private static WqDRPmIdsQZXsUVkshlkCEOcrHB BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static WqDRPmIdsQZXsUVkshlkCEOcrHB Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new WqDRPmIdsQZXsUVkshlkCEOcrHB());

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
				if (object.ReferenceEquals(x, null))
				{
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				int num2;
				if (!(x is float))
				{
					num = -1884763535;
					num2 = num;
				}
				else
				{
					num = -1884763534;
					num2 = num;
				}
				goto IL_0017;
				IL_0012:
				num = -1884763536;
				goto IL_0017;
				IL_0017:
				while (true)
				{
					switch (num ^ -1884763535)
					{
					case 2:
						break;
					case 1:
						return true;
					case 3:
						if (!(y is float))
						{
							goto IL_0059;
						}
						return Equals((float)x, (float)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = -1884763535;
				}
				goto IL_0012;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = -903104287;
						while (true)
						{
							switch (num ^ -903104288)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is float))
							{
								num = -903104288;
								continue;
							}
							return GetHashCode((float)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class JVcOalwdSKQvtZQEJJfpdObFPfR : IEqualityComparer, IEqualityComparer<double>
		{
			private static JVcOalwdSKQvtZQEJJfpdObFPfR BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static JVcOalwdSKQvtZQEJJfpdObFPfR Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new JVcOalwdSKQvtZQEJJfpdObFPfR());

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
				if (object.ReferenceEquals(x, null))
				{
					if (object.ReferenceEquals(y, null))
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
				if (object.ReferenceEquals(obj, null) || !(obj is double))
				{
					return 0;
				}
				return GetHashCode((double)obj);
			}
		}

		private class FqTyhTcMaiOXjggSplkhBpzilIS : IEqualityComparer, IEqualityComparer<byte>
		{
			private static FqTyhTcMaiOXjggSplkhBpzilIS BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static FqTyhTcMaiOXjggSplkhBpzilIS Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new FqTyhTcMaiOXjggSplkhBpzilIS());

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
				if (object.ReferenceEquals(x, null))
				{
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				if (x is byte)
				{
					if (!(y is byte))
					{
						num = 700134347;
						goto IL_0017;
					}
					return Equals((byte)x, (byte)y);
				}
				goto IL_004b;
				IL_0017:
				switch (num ^ 0x29BB33CB)
				{
				case 2:
					break;
				case 1:
					return true;
				default:
					goto IL_004b;
				}
				goto IL_0012;
				IL_0012:
				num = 700134346;
				goto IL_0017;
				IL_004b:
				return false;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (object.ReferenceEquals(obj, null) || !(obj is byte))
				{
					return 0;
				}
				return GetHashCode((byte)obj);
			}
		}

		private class YOnDESiNjmvGfPEfwtXzNcjSitE : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static YOnDESiNjmvGfPEfwtXzNcjSitE BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static YOnDESiNjmvGfPEfwtXzNcjSitE Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new YOnDESiNjmvGfPEfwtXzNcjSitE());

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
				if (object.ReferenceEquals(x, null))
				{
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				if (x is sbyte)
				{
					if (!(y is sbyte))
					{
						num = -800828895;
						goto IL_0017;
					}
					return Equals((sbyte)x, (sbyte)y);
				}
				goto IL_004b;
				IL_0017:
				switch (num ^ -800828893)
				{
				case 0:
					break;
				case 1:
					return true;
				default:
					goto IL_004b;
				}
				goto IL_0012;
				IL_0012:
				num = -800828894;
				goto IL_0017;
				IL_004b:
				return false;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (object.ReferenceEquals(obj, null) || !(obj is sbyte))
				{
					return 0;
				}
				return GetHashCode((sbyte)obj);
			}
		}

		private class xPaSxhHNrzLlbZEuiQLhFKDZtot : IEqualityComparer, IEqualityComparer<bool>
		{
			private static xPaSxhHNrzLlbZEuiQLhFKDZtot BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static xPaSxhHNrzLlbZEuiQLhFKDZtot Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new xPaSxhHNrzLlbZEuiQLhFKDZtot());

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
				if (object.ReferenceEquals(x, null))
				{
					goto IL_0009;
				}
				int num;
				if (x is bool)
				{
					if (!(y is bool))
					{
						num = -2121464498;
						goto IL_000e;
					}
					return Equals((bool)x, (bool)y);
				}
				goto IL_004b;
				IL_0009:
				num = -2121464499;
				goto IL_000e;
				IL_000e:
				switch (num ^ -2121464497)
				{
				case 0:
					break;
				case 2:
					goto IL_0027;
				default:
					goto IL_004b;
				}
				goto IL_0009;
				IL_004b:
				return false;
				IL_0027:
				if (object.ReferenceEquals(y, null))
				{
					return true;
				}
				return false;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (object.ReferenceEquals(obj, null) || !(obj is bool))
				{
					return 0;
				}
				return GetHashCode((bool)obj);
			}
		}

		private class xVdFOKbBcvCbBdZXqkpjlcmmTED : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static xVdFOKbBcvCbBdZXqkpjlcmmTED BELYGgvdxqwzdKiTuASOKvfcQKF;

			public static xVdFOKbBcvCbBdZXqkpjlcmmTED Default => BELYGgvdxqwzdKiTuASOKvfcQKF ?? (BELYGgvdxqwzdKiTuASOKvfcQKF = new xVdFOKbBcvCbBdZXqkpjlcmmTED());

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
				if (object.ReferenceEquals(x, null))
				{
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				int num2;
				if (x is IntPtr)
				{
					num = 1320502394;
					num2 = num;
				}
				else
				{
					num = 1320502395;
					num2 = num;
				}
				goto IL_0017;
				IL_0012:
				num = 1320502392;
				goto IL_0017;
				IL_0017:
				while (true)
				{
					switch (num ^ 0x4EB54479)
					{
					case 0:
						break;
					case 1:
						return true;
					case 3:
						if (!(y is IntPtr))
						{
							goto IL_0059;
						}
						return Equals((IntPtr)x, (IntPtr)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = 1320502395;
				}
				goto IL_0012;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 1295575991;
						while (true)
						{
							switch (num ^ 0x4D38EBB6)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is IntPtr))
							{
								num = 1295575990;
								continue;
							}
							return GetHashCode((IntPtr)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		public static IEqualityComparer<T> Default
		{
			get
			{
				Type typeFromHandle = typeof(T);
				while (true)
				{
					int num = 1303520353;
					while (true)
					{
						switch (num ^ 0x4DB22463)
						{
						case 0:
							break;
						case 2:
							if (object.ReferenceEquals(typeFromHandle, typeof(int)))
							{
								num = 1303520354;
								continue;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(long)))
							{
								return (IEqualityComparer<T>)ympFYLMKocKqfhQUaeHZnNPENBd.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								return (IEqualityComparer<T>)qerbAlCFiDPtNHEbtEpbAUIeIVm.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
							{
								return (IEqualityComparer<T>)FajedYIqxGYrDqVusRIvOoPwLeBV.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(float)))
							{
								num = 1303520352;
								continue;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(double)))
							{
								return (IEqualityComparer<T>)JVcOalwdSKQvtZQEJJfpdObFPfR.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
							{
								return (IEqualityComparer<T>)FqTyhTcMaiOXjggSplkhBpzilIS.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
							{
								return (IEqualityComparer<T>)YOnDESiNjmvGfPEfwtXzNcjSitE.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
							{
								return (IEqualityComparer<T>)xPaSxhHNrzLlbZEuiQLhFKDZtot.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(IntPtr)))
							{
								return (IEqualityComparer<T>)xVdFOKbBcvCbBdZXqkpjlcmmTED.Default;
							}
							return EqualityComparer<T>.Default;
						case 1:
							return (IEqualityComparer<T>)HgNFmBgjKiXhouJEWCFRWqagkGBI.Default;
						default:
							return (IEqualityComparer<T>)WqDRPmIdsQZXsUVkshlkCEOcrHB.Default;
						}
						break;
					}
				}
			}
		}
	}
}
