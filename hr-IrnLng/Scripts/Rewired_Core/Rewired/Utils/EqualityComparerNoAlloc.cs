using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class vEuxKMKqUTFmQzqKmHcRbEDWwxgd : IEqualityComparer, IEqualityComparer<int>
		{
			private static vEuxKMKqUTFmQzqKmHcRbEDWwxgd djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static vEuxKMKqUTFmQzqKmHcRbEDWwxgd Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new vEuxKMKqUTFmQzqKmHcRbEDWwxgd());

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
				if (object.ReferenceEquals(obj, null) || !(obj is int))
				{
					return 0;
				}
				return GetHashCode((int)obj);
			}
		}

		private class YmOmsClQwXjjTXNEKweRDLesyoE : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static YmOmsClQwXjjTXNEKweRDLesyoE djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static YmOmsClQwXjjTXNEKweRDLesyoE Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new YmOmsClQwXjjTXNEKweRDLesyoE());

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

		private class GECdZavXgiwKbzhbTlMhakdStgL : IEqualityComparer, IEqualityComparer<uint>
		{
			private static GECdZavXgiwKbzhbTlMhakdStgL djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static GECdZavXgiwKbzhbTlMhakdStgL Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new GECdZavXgiwKbzhbTlMhakdStgL());

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

		private class tYCuHPZOzbNwnvUuIQrxShmYzVu : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static tYCuHPZOzbNwnvUuIQrxShmYzVu djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static tYCuHPZOzbNwnvUuIQrxShmYzVu Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new tYCuHPZOzbNwnvUuIQrxShmYzVu());

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

		private class gqqtAxbJebMPOkzwOOAeaPhIQpw : IEqualityComparer, IEqualityComparer<float>
		{
			private static gqqtAxbJebMPOkzwOOAeaPhIQpw djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static gqqtAxbJebMPOkzwOOAeaPhIQpw Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new gqqtAxbJebMPOkzwOOAeaPhIQpw());

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

		private class jVDizpLfejZHTtAtzsyhHzgfkXw : IEqualityComparer, IEqualityComparer<double>
		{
			private static jVDizpLfejZHTtAtzsyhHzgfkXw djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static jVDizpLfejZHTtAtzsyhHzgfkXw Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new jVDizpLfejZHTtAtzsyhHzgfkXw());

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

		private class fqgQVWRDsXhTLQOIPwCzvKYCtOd : IEqualityComparer, IEqualityComparer<byte>
		{
			private static fqgQVWRDsXhTLQOIPwCzvKYCtOd djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static fqgQVWRDsXhTLQOIPwCzvKYCtOd Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new fqgQVWRDsXhTLQOIPwCzvKYCtOd());

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

		private class yOOhmJRhhTswRpDzABOnhaKkwCt : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static yOOhmJRhhTswRpDzABOnhaKkwCt djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static yOOhmJRhhTswRpDzABOnhaKkwCt Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new yOOhmJRhhTswRpDzABOnhaKkwCt());

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
				if (object.ReferenceEquals(obj, null) || !(obj is sbyte))
				{
					return 0;
				}
				return GetHashCode((sbyte)obj);
			}
		}

		private class JrPABgbcvMfeVmfyMtorAjaxFVOT : IEqualityComparer, IEqualityComparer<bool>
		{
			private static JrPABgbcvMfeVmfyMtorAjaxFVOT djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static JrPABgbcvMfeVmfyMtorAjaxFVOT Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new JrPABgbcvMfeVmfyMtorAjaxFVOT());

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
				if (!(x is bool) || !(y is bool))
				{
					return false;
				}
				return Equals((bool)x, (bool)y);
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

		private class XVUzbHIZuYNBNHkXKZKlXhXOwkv : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static XVUzbHIZuYNBNHkXKZKlXhXOwkv djlcmNRpVGlRVVmXbhEIuUsTdqb;

			public static XVUzbHIZuYNBNHkXKZKlXhXOwkv Default => djlcmNRpVGlRVVmXbhEIuUsTdqb ?? (djlcmNRpVGlRVVmXbhEIuUsTdqb = new XVUzbHIZuYNBNHkXKZKlXhXOwkv());

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
				if (object.ReferenceEquals(typeFromHandle, typeof(int)))
				{
					return (IEqualityComparer<T>)vEuxKMKqUTFmQzqKmHcRbEDWwxgd.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(long)))
				{
					return (IEqualityComparer<T>)YmOmsClQwXjjTXNEKweRDLesyoE.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
				{
					return (IEqualityComparer<T>)GECdZavXgiwKbzhbTlMhakdStgL.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
				{
					return (IEqualityComparer<T>)tYCuHPZOzbNwnvUuIQrxShmYzVu.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(float)))
				{
					return (IEqualityComparer<T>)gqqtAxbJebMPOkzwOOAeaPhIQpw.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(double)))
				{
					return (IEqualityComparer<T>)jVDizpLfejZHTtAtzsyhHzgfkXw.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
				{
					return (IEqualityComparer<T>)fqgQVWRDsXhTLQOIPwCzvKYCtOd.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
				{
					return (IEqualityComparer<T>)yOOhmJRhhTswRpDzABOnhaKkwCt.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
				{
					return (IEqualityComparer<T>)JrPABgbcvMfeVmfyMtorAjaxFVOT.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(IntPtr)))
				{
					return (IEqualityComparer<T>)XVUzbHIZuYNBNHkXKZKlXhXOwkv.Default;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
