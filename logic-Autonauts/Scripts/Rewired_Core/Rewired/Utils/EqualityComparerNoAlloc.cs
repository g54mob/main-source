using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class ezJBzORbxawfdkxvJuGxsIZfRky : IEqualityComparer, IEqualityComparer<int>
		{
			private static ezJBzORbxawfdkxvJuGxsIZfRky kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static ezJBzORbxawfdkxvJuGxsIZfRky Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new ezJBzORbxawfdkxvJuGxsIZfRky());
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
						int num = -1182757992;
						while (true)
						{
							switch (num ^ -1182757990)
							{
							case 0:
								break;
							case 2:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is int))
							{
								num = -1182757989;
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

		private class XiflDEksJszOyAythecMvFrDIMM : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static XiflDEksJszOyAythecMvFrDIMM kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static XiflDEksJszOyAythecMvFrDIMM Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new XiflDEksJszOyAythecMvFrDIMM());
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
				if (!(x is ulong) || !(y is ulong))
				{
					return false;
				}
				return Equals((ulong)x, (ulong)y);
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

		private class FIvKCiqpZHIWOevSkIwoUDinbEZ : IEqualityComparer, IEqualityComparer<uint>
		{
			private static FIvKCiqpZHIWOevSkIwoUDinbEZ kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static FIvKCiqpZHIWOevSkIwoUDinbEZ Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new FIvKCiqpZHIWOevSkIwoUDinbEZ());
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
					goto IL_0009;
				}
				int num;
				int num2;
				if (!(x is uint))
				{
					num = 439336470;
					num2 = num;
				}
				else
				{
					num = 439336471;
					num2 = num;
				}
				goto IL_000e;
				IL_0009:
				num = 439336468;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x1A2FBE17)
					{
					case 2:
						break;
					case 3:
						if (object.ReferenceEquals(y, null))
						{
							return true;
						}
						return false;
					case 0:
						if (!(y is uint))
						{
							goto IL_0059;
						}
						return Equals((uint)x, (uint)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = 439336470;
				}
				goto IL_0009;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 30092132;
						while (true)
						{
							switch (num ^ 0x1CB2B65)
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
							if (!(obj is uint))
							{
								num = 30092133;
								continue;
							}
							return GetHashCode((uint)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class cyjWRVYMxOmFYcPwzxImslIphCs : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static cyjWRVYMxOmFYcPwzxImslIphCs kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static cyjWRVYMxOmFYcPwzxImslIphCs Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new cyjWRVYMxOmFYcPwzxImslIphCs());
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
					goto IL_0009;
				}
				int num;
				int num2;
				if (x is ulong)
				{
					num = -1634355685;
					num2 = num;
				}
				else
				{
					num = -1634355687;
					num2 = num;
				}
				goto IL_000e;
				IL_0009:
				num = -1634355686;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1634355688)
					{
					case 0:
						break;
					case 2:
						if (object.ReferenceEquals(y, null))
						{
							return true;
						}
						return false;
					case 3:
						if (!(y is ulong))
						{
							goto IL_0059;
						}
						return Equals((ulong)x, (ulong)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = -1634355687;
				}
				goto IL_0009;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = -878757893;
						while (true)
						{
							switch (num ^ -878757894)
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
							if (!(obj is ulong))
							{
								num = -878757894;
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

		private class npRmefaeXSXQhxrDnpSdWFivjaw : IEqualityComparer, IEqualityComparer<float>
		{
			private static npRmefaeXSXQhxrDnpSdWFivjaw kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static npRmefaeXSXQhxrDnpSdWFivjaw Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new npRmefaeXSXQhxrDnpSdWFivjaw());
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

		private class cXgvzzKzAKJWmoEbMIisrtuWjUc : IEqualityComparer, IEqualityComparer<double>
		{
			private static cXgvzzKzAKJWmoEbMIisrtuWjUc kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static cXgvzzKzAKJWmoEbMIisrtuWjUc Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new cXgvzzKzAKJWmoEbMIisrtuWjUc());
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
				if (x is double)
				{
					while (true)
					{
						int num = 522047312;
						while (true)
						{
							switch (num ^ 0x1F1DCF52)
							{
							case 0:
								break;
							case 2:
								goto IL_003c;
							default:
								goto end_IL_001e;
							}
							break;
							IL_003c:
							if (!(y is double))
							{
								num = 522047315;
								continue;
							}
							return Equals((double)x, (double)y);
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
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = -1903924697;
						while (true)
						{
							switch (num ^ -1903924698)
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
							if (!(obj is double))
							{
								num = -1903924698;
								continue;
							}
							return GetHashCode((double)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class uTTGPIMxPglNoNYtiuKoZvXvlmr : IEqualityComparer, IEqualityComparer<byte>
		{
			private static uTTGPIMxPglNoNYtiuKoZvXvlmr kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static uTTGPIMxPglNoNYtiuKoZvXvlmr Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new uTTGPIMxPglNoNYtiuKoZvXvlmr());
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
					goto IL_0009;
				}
				int num;
				if (x is byte)
				{
					if (!(y is byte))
					{
						num = -1037546285;
						goto IL_000e;
					}
					return Equals((byte)x, (byte)y);
				}
				goto IL_004b;
				IL_0009:
				num = -1037546288;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1037546287)
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
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 411871827;
						while (true)
						{
							switch (num ^ 0x188CAA51)
							{
							case 0:
								break;
							case 2:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is byte))
							{
								num = 411871824;
								continue;
							}
							return GetHashCode((byte)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class xNbfqLEJMoUiqimGzoSqZrDJnon : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static xNbfqLEJMoUiqimGzoSqZrDJnon kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static xNbfqLEJMoUiqimGzoSqZrDJnon Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new xNbfqLEJMoUiqimGzoSqZrDJnon());
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
					if (object.ReferenceEquals(y, null))
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
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = -1701066729;
						while (true)
						{
							switch (num ^ -1701066731)
							{
							case 0:
								break;
							case 2:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (!(obj is sbyte))
							{
								num = -1701066732;
								continue;
							}
							return GetHashCode((sbyte)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class EepWwfjOnvyamaJfSeqjDtSujQf : IEqualityComparer, IEqualityComparer<bool>
		{
			private static EepWwfjOnvyamaJfSeqjDtSujQf kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static EepWwfjOnvyamaJfSeqjDtSujQf Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new EepWwfjOnvyamaJfSeqjDtSujQf());
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
					if (!object.ReferenceEquals(y, null))
					{
						return false;
					}
					goto IL_0012;
				}
				int num;
				int num2;
				if (!(x is bool))
				{
					num = -260295884;
					num2 = num;
				}
				else
				{
					num = -260295883;
					num2 = num;
				}
				goto IL_0017;
				IL_0012:
				num = -260295881;
				goto IL_0017;
				IL_0017:
				while (true)
				{
					switch (num ^ -260295882)
					{
					case 0:
						break;
					case 1:
						return true;
					case 3:
						if (!(y is bool))
						{
							goto IL_0059;
						}
						return Equals((bool)x, (bool)y);
					default:
						return false;
					}
					break;
					IL_0059:
					num = -260295884;
				}
				goto IL_0012;
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (!object.ReferenceEquals(obj, null))
				{
					while (true)
					{
						int num = 181170893;
						while (true)
						{
							switch (num ^ 0xACC72CC)
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
							if (!(obj is bool))
							{
								num = 181170892;
								continue;
							}
							return GetHashCode((bool)obj);
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return 0;
			}
		}

		private class UXjVkTJSavFVuUFatyNqdVWnGEz : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static UXjVkTJSavFVuUFatyNqdVWnGEz kJYsbRKlSlZlyWJDAHjHgULwfDhO;

			public static UXjVkTJSavFVuUFatyNqdVWnGEz Default
			{
				get
				{
					return kJYsbRKlSlZlyWJDAHjHgULwfDhO ?? (kJYsbRKlSlZlyWJDAHjHgULwfDhO = new UXjVkTJSavFVuUFatyNqdVWnGEz());
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
					if (object.ReferenceEquals(y, null))
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
					int num = -1486666900;
					while (true)
					{
						switch (num ^ -1486666899)
						{
						case 2:
							break;
						case 4:
							return (IEqualityComparer<T>)npRmefaeXSXQhxrDnpSdWFivjaw.Default;
						case 5:
							return (IEqualityComparer<T>)FIvKCiqpZHIWOevSkIwoUDinbEZ.Default;
						case 3:
							return (IEqualityComparer<T>)uTTGPIMxPglNoNYtiuKoZvXvlmr.Default;
						case 1:
							if (object.ReferenceEquals(typeFromHandle, typeof(int)))
							{
								return (IEqualityComparer<T>)ezJBzORbxawfdkxvJuGxsIZfRky.Default;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(long)))
							{
								return (IEqualityComparer<T>)XiflDEksJszOyAythecMvFrDIMM.Default;
							}
							if (!object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
								{
									return (IEqualityComparer<T>)cyjWRVYMxOmFYcPwzxImslIphCs.Default;
								}
								if (!object.ReferenceEquals(typeFromHandle, typeof(float)))
								{
									if (object.ReferenceEquals(typeFromHandle, typeof(double)))
									{
										return (IEqualityComparer<T>)cXgvzzKzAKJWmoEbMIisrtuWjUc.Default;
									}
									if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
									{
										num = -1486666898;
										continue;
									}
									if (!object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
									{
										if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
										{
											return (IEqualityComparer<T>)EepWwfjOnvyamaJfSeqjDtSujQf.Default;
										}
										if (object.ReferenceEquals(typeFromHandle, typeof(IntPtr)))
										{
											return (IEqualityComparer<T>)UXjVkTJSavFVuUFatyNqdVWnGEz.Default;
										}
										return EqualityComparer<T>.Default;
									}
									num = -1486666899;
								}
								else
								{
									num = -1486666903;
								}
							}
							else
							{
								num = -1486666904;
							}
							continue;
						default:
							return (IEqualityComparer<T>)xNbfqLEJMoUiqimGzoSqZrDJnon.Default;
						}
						break;
					}
				}
			}
		}
	}
}
