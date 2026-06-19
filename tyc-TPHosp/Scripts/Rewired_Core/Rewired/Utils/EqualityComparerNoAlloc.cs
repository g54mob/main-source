using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class VXIhhgfwbOGVMwgevesQkYswylQk : IEqualityComparer, IEqualityComparer<int>
		{
			private static VXIhhgfwbOGVMwgevesQkYswylQk FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static VXIhhgfwbOGVMwgevesQkYswylQk Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new VXIhhgfwbOGVMwgevesQkYswylQk());

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

		private class ytuBVggALIIURaCwEBkSZBFJGqgy : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static ytuBVggALIIURaCwEBkSZBFJGqgy FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static ytuBVggALIIURaCwEBkSZBFJGqgy Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new ytuBVggALIIURaCwEBkSZBFJGqgy());

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

		private class cOwaDGUkBhjHtkwHYIlkaxQesyj : IEqualityComparer, IEqualityComparer<uint>
		{
			private static cOwaDGUkBhjHtkwHYIlkaxQesyj FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static cOwaDGUkBhjHtkwHYIlkaxQesyj Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new cOwaDGUkBhjHtkwHYIlkaxQesyj());

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

		private class DLgiqzeiImCFjioEZjhucIZgLHKI : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static DLgiqzeiImCFjioEZjhucIZgLHKI FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static DLgiqzeiImCFjioEZjhucIZgLHKI Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new DLgiqzeiImCFjioEZjhucIZgLHKI());

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

		private class WMuOBEfDkVlEbeALXOfmBCyDCII : IEqualityComparer, IEqualityComparer<float>
		{
			private static WMuOBEfDkVlEbeALXOfmBCyDCII FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static WMuOBEfDkVlEbeALXOfmBCyDCII Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new WMuOBEfDkVlEbeALXOfmBCyDCII());

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

		private class BCpcVTuGWetkJmDmgsuqZYMNqkO : IEqualityComparer, IEqualityComparer<double>
		{
			private static BCpcVTuGWetkJmDmgsuqZYMNqkO FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static BCpcVTuGWetkJmDmgsuqZYMNqkO Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new BCpcVTuGWetkJmDmgsuqZYMNqkO());

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

		private class FdQlHggZSSyyDLcOSUMqpfXgEeX : IEqualityComparer, IEqualityComparer<byte>
		{
			private static FdQlHggZSSyyDLcOSUMqpfXgEeX FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static FdQlHggZSSyyDLcOSUMqpfXgEeX Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new FdQlHggZSSyyDLcOSUMqpfXgEeX());

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

		private class WimUtfaGDKFLDaRnHEsohvAWCdX : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static WimUtfaGDKFLDaRnHEsohvAWCdX FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static WimUtfaGDKFLDaRnHEsohvAWCdX Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new WimUtfaGDKFLDaRnHEsohvAWCdX());

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

		private class fljluAHECTVBVqmSXewqfjJNqPg : IEqualityComparer, IEqualityComparer<bool>
		{
			private static fljluAHECTVBVqmSXewqfjJNqPg FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static fljluAHECTVBVqmSXewqfjJNqPg Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new fljluAHECTVBVqmSXewqfjJNqPg());

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

		private class jcgbInhnaJGqNgKvXjPsLPewWyVt : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static jcgbInhnaJGqNgKvXjPsLPewWyVt FPTJhxcxKBYwLUQIqrDToaflCtZ;

			public static jcgbInhnaJGqNgKvXjPsLPewWyVt Default => FPTJhxcxKBYwLUQIqrDToaflCtZ ?? (FPTJhxcxKBYwLUQIqrDToaflCtZ = new jcgbInhnaJGqNgKvXjPsLPewWyVt());

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
					return (IEqualityComparer<T>)VXIhhgfwbOGVMwgevesQkYswylQk.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(long)))
				{
					return (IEqualityComparer<T>)ytuBVggALIIURaCwEBkSZBFJGqgy.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
				{
					return (IEqualityComparer<T>)cOwaDGUkBhjHtkwHYIlkaxQesyj.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
				{
					return (IEqualityComparer<T>)DLgiqzeiImCFjioEZjhucIZgLHKI.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(float)))
				{
					return (IEqualityComparer<T>)WMuOBEfDkVlEbeALXOfmBCyDCII.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(double)))
				{
					return (IEqualityComparer<T>)BCpcVTuGWetkJmDmgsuqZYMNqkO.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
				{
					return (IEqualityComparer<T>)FdQlHggZSSyyDLcOSUMqpfXgEeX.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
				{
					return (IEqualityComparer<T>)WimUtfaGDKFLDaRnHEsohvAWCdX.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
				{
					return (IEqualityComparer<T>)fljluAHECTVBVqmSXewqfjJNqPg.Default;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(IntPtr)))
				{
					return (IEqualityComparer<T>)jcgbInhnaJGqNgKvXjPsLPewWyVt.Default;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
