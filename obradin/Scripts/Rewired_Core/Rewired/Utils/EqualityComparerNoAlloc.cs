using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class LzBQCRpnpmZFICexxuEYJKfdQpz : IEqualityComparer, IEqualityComparer<int>
		{
			private static LzBQCRpnpmZFICexxuEYJKfdQpz HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static LzBQCRpnpmZFICexxuEYJKfdQpz Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new LzBQCRpnpmZFICexxuEYJKfdQpz());
				}
			}

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
					goto IL_0009;
				}
				int num;
				int num2;
				if (x is int)
				{
					num = 1209610763;
					num2 = num;
				}
				else
				{
					num = 1209610761;
					num2 = num;
				}
				goto IL_000e;
				IL_0009:
				num = 1209610762;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x4819320B)
					{
					case 3:
						break;
					case 1:
						if (object.ReferenceEquals(y, null))
						{
							return true;
						}
						return false;
					case 0:
						if (!(y is int))
						{
							goto IL_0059;
						}
						return Equals((int)x, (int)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = 1209610761;
				}
				goto IL_0009;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 1860928798;
						while (true)
						{
							switch (num ^ 0x6EEB851F)
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
								num = 1860928797;
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

		private class gAjacVKuVogANwhoFQgUKitHgNN : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static gAjacVKuVogANwhoFQgUKitHgNN HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static gAjacVKuVogANwhoFQgUKitHgNN Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new gAjacVKuVogANwhoFQgUKitHgNN());
				}
			}

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
				if (x is ulong)
				{
					while (true)
					{
						int num = 1048119410;
						while (true)
						{
							switch (num ^ 0x3E790873)
							{
							case 2:
								break;
							case 1:
								goto IL_003c;
							default:
								goto end_IL_001e;
							}
							break;
							IL_003c:
							if (!(y is ulong))
							{
								num = 1048119411;
								continue;
							}
							return Equals((ulong)x, (ulong)y);
						}
						continue;
						end_IL_001e:
						break;
					}
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

		private class sVbsJxMqLJntvIWFUFIgzYgnDJS : IEqualityComparer, IEqualityComparer<uint>
		{
			private static sVbsJxMqLJntvIWFUFIgzYgnDJS HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static sVbsJxMqLJntvIWFUFIgzYgnDJS Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new sVbsJxMqLJntvIWFUFIgzYgnDJS());
				}
			}

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
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				if (x is uint)
				{
					if (!(y is uint))
					{
						num = -462319819;
						goto IL_0017;
					}
					return Equals((uint)x, (uint)y);
				}
				goto IL_004b;
				IL_0017:
				switch (num ^ -462319817)
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
				num = -462319818;
				goto IL_0017;
				IL_004b:
				return false;
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

		private class PdCBQcGGMFDtJQWLdvcXNflFklG : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static PdCBQcGGMFDtJQWLdvcXNflFklG HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static PdCBQcGGMFDtJQWLdvcXNflFklG Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new PdCBQcGGMFDtJQWLdvcXNflFklG());
				}
			}

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
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				if (x is ulong)
				{
					if (!(y is ulong))
					{
						num = -496800848;
						goto IL_0017;
					}
					return Equals((ulong)x, (ulong)y);
				}
				goto IL_004b;
				IL_0017:
				switch (num ^ -496800847)
				{
				case 0:
					break;
				case 2:
					return true;
				default:
					goto IL_004b;
				}
				goto IL_0012;
				IL_0012:
				num = -496800845;
				goto IL_0017;
				IL_004b:
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

		private class SpThdwAaDAzlYNxCFLWnrvmjUtl : IEqualityComparer, IEqualityComparer<float>
		{
			private static SpThdwAaDAzlYNxCFLWnrvmjUtl HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static SpThdwAaDAzlYNxCFLWnrvmjUtl Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new SpThdwAaDAzlYNxCFLWnrvmjUtl());
				}
			}

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
					if (object.ReferenceEquals(y, null))
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
				if (object.ReferenceEquals(obj, null) || !(obj is float))
				{
					return 0;
				}
				return GetHashCode((float)obj);
			}
		}

		private class ZPifukbuYGFeZAOqJwaiRCqqUJbb : IEqualityComparer, IEqualityComparer<double>
		{
			private static ZPifukbuYGFeZAOqJwaiRCqqUJbb HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static ZPifukbuYGFeZAOqJwaiRCqqUJbb Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new ZPifukbuYGFeZAOqJwaiRCqqUJbb());
				}
			}

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

		private class DQBQIVmtVmKkLbjsAQOaoFXpvni : IEqualityComparer, IEqualityComparer<byte>
		{
			private static DQBQIVmtVmKkLbjsAQOaoFXpvni HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static DQBQIVmtVmKkLbjsAQOaoFXpvni Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new DQBQIVmtVmKkLbjsAQOaoFXpvni());
				}
			}

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
					if (object.ReferenceEquals(y, null))
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
				if (object.ReferenceEquals(obj, null) || !(obj is byte))
				{
					return 0;
				}
				return GetHashCode((byte)obj);
			}
		}

		private class WpjOlSiIAixHNAWJZAWwmgLLnhe : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static WpjOlSiIAixHNAWJZAWwmgLLnhe HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static WpjOlSiIAixHNAWJZAWwmgLLnhe Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new WpjOlSiIAixHNAWJZAWwmgLLnhe());
				}
			}

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
						num = -589959784;
						goto IL_0017;
					}
					return Equals((sbyte)x, (sbyte)y);
				}
				goto IL_004b;
				IL_0017:
				switch (num ^ -589959784)
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
				num = -589959783;
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

		private class tKmFbjJgIxBOVOAUHukqqRbKuzJ : IEqualityComparer, IEqualityComparer<bool>
		{
			private static tKmFbjJgIxBOVOAUHukqqRbKuzJ HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static tKmFbjJgIxBOVOAUHukqqRbKuzJ Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new tKmFbjJgIxBOVOAUHukqqRbKuzJ());
				}
			}

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
					if (object.ReferenceEquals(y, null))
					{
						return true;
					}
					return false;
				}
				if (x is bool)
				{
					while (true)
					{
						int num = 1959487532;
						while (true)
						{
							switch (num ^ 0x74CB682D)
							{
							case 0:
								break;
							case 1:
								goto IL_003c;
							default:
								goto end_IL_001e;
							}
							break;
							IL_003c:
							if (!(y is bool))
							{
								num = 1959487535;
								continue;
							}
							return Equals((bool)x, (bool)y);
						}
						continue;
						end_IL_001e:
						break;
					}
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

		private class hPnfhKajihmqTGexJyPadGYhRTik : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static hPnfhKajihmqTGexJyPadGYhRTik HcOcaCIaSdKUNugUabjZgrXFgUqM;

			public static hPnfhKajihmqTGexJyPadGYhRTik Default
			{
				get
				{
					return HcOcaCIaSdKUNugUabjZgrXFgUqM ?? (HcOcaCIaSdKUNugUabjZgrXFgUqM = new hPnfhKajihmqTGexJyPadGYhRTik());
				}
			}

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
					goto IL_0009;
				}
				int num;
				if (x is IntPtr)
				{
					if (!(y is IntPtr))
					{
						num = -367659545;
						goto IL_000e;
					}
					return Equals((IntPtr)x, (IntPtr)y);
				}
				goto IL_004b;
				IL_0009:
				num = -367659548;
				goto IL_000e;
				IL_000e:
				switch (num ^ -367659547)
				{
				case 0:
					break;
				case 1:
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
				if (object.ReferenceEquals(obj, null) || !(obj is IntPtr))
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
				while (true)
				{
					int num = 764220689;
					while (true)
					{
						switch (num ^ 0x2D8D1515)
						{
						case 0:
							break;
						case 4:
							if (object.ReferenceEquals(typeFromHandle, typeof(int)))
							{
								return (IEqualityComparer<T>)LzBQCRpnpmZFICexxuEYJKfdQpz.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(long)))
							{
								num = 764220692;
								continue;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								return (IEqualityComparer<T>)sVbsJxMqLJntvIWFUFIgzYgnDJS.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
							{
								return (IEqualityComparer<T>)PdCBQcGGMFDtJQWLdvcXNflFklG.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(float)))
							{
								return (IEqualityComparer<T>)SpThdwAaDAzlYNxCFLWnrvmjUtl.Default;
							}
							if (!object.ReferenceEquals(typeFromHandle, typeof(double)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
								{
									return (IEqualityComparer<T>)DQBQIVmtVmKkLbjsAQOaoFXpvni.Default;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
								{
									return (IEqualityComparer<T>)WpjOlSiIAixHNAWJZAWwmgLLnhe.Default;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
								{
									return (IEqualityComparer<T>)tKmFbjJgIxBOVOAUHukqqRbKuzJ.Default;
								}
								if (!object.ReferenceEquals(typeFromHandle, typeof(IntPtr)))
								{
									return EqualityComparer<T>.Default;
								}
								num = 764220694;
							}
							else
							{
								num = 764220695;
							}
							continue;
						case 2:
							return (IEqualityComparer<T>)ZPifukbuYGFeZAOqJwaiRCqqUJbb.Default;
						case 1:
							return (IEqualityComparer<T>)gAjacVKuVogANwhoFQgUKitHgNN.Default;
						default:
							return (IEqualityComparer<T>)hPnfhKajihmqTGexJyPadGYhRTik.Default;
						}
						break;
					}
				}
			}
		}
	}
}
