using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class RSomheSYoacBPEvJXhDQbjcyKAuE : IEqualityComparer, IEqualityComparer<int>
		{
			private static RSomheSYoacBPEvJXhDQbjcyKAuE AOnRIfrlXbCcxbCEflcEppJXcGaeA;

			public static RSomheSYoacBPEvJXhDQbjcyKAuE fyxmuDtbFNDenhYGEsbCBBllHmxib => AOnRIfrlXbCcxbCEflcEppJXcGaeA ?? (AOnRIfrlXbCcxbCEflcEppJXcGaeA = new RSomheSYoacBPEvJXhDQbjcyKAuE());

			public bool Equals(int x, int y)
			{
				return x == y;
			}

			bool IEqualityComparer<int>.Equals(int x, int y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<int>.GetHashCode(int obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class ecAGVkpyyshOUgpzrlRVyfAUHmWG : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static ecAGVkpyyshOUgpzrlRVyfAUHmWG ghedgfLBwjIcDhyfoSRWsBZoUcYX;

			public static ecAGVkpyyshOUgpzrlRVyfAUHmWG ErEEzCjbZVbfNVLgJBbHBsZlRmNM => ghedgfLBwjIcDhyfoSRWsBZoUcYX ?? (ghedgfLBwjIcDhyfoSRWsBZoUcYX = new ecAGVkpyyshOUgpzrlRVyfAUHmWG());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			bool IEqualityComparer<ulong>.Equals(ulong x, ulong y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<ulong>.GetHashCode(ulong obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class ueESjMreyPoSgYIAoVDnRtHahBZv : IEqualityComparer, IEqualityComparer<uint>
		{
			private static ueESjMreyPoSgYIAoVDnRtHahBZv yMOhhpIOjkMzghqkyGiXJglOamFgA;

			public static ueESjMreyPoSgYIAoVDnRtHahBZv cFwFPBkreAruFDizsDZtRcETPnfQA => yMOhhpIOjkMzghqkyGiXJglOamFgA ?? (yMOhhpIOjkMzghqkyGiXJglOamFgA = new ueESjMreyPoSgYIAoVDnRtHahBZv());

			public bool Equals(uint x, uint y)
			{
				return x == y;
			}

			bool IEqualityComparer<uint>.Equals(uint x, uint y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(uint obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<uint>.GetHashCode(uint obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class RIfzxXMlAqomWIJnbgxhnUknycu : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static RIfzxXMlAqomWIJnbgxhnUknycu lStxsIxegRfwKtqJOZuYeXifRTPh;

			public static RIfzxXMlAqomWIJnbgxhnUknycu PomrdtzTwidmWraKfkIhwAagABpI => lStxsIxegRfwKtqJOZuYeXifRTPh ?? (lStxsIxegRfwKtqJOZuYeXifRTPh = new RIfzxXMlAqomWIJnbgxhnUknycu());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			bool IEqualityComparer<ulong>.Equals(ulong x, ulong y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<ulong>.GetHashCode(ulong obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class QGehTNnocANGBRsHvuRsPpBmmlcW : IEqualityComparer, IEqualityComparer<float>
		{
			private static QGehTNnocANGBRsHvuRsPpBmmlcW ejlTstGfmXpDvSTBLMibZjIjnmVq;

			public static QGehTNnocANGBRsHvuRsPpBmmlcW iXbSmfLkuHrnECmOSjtgKEcIvLeHA => ejlTstGfmXpDvSTBLMibZjIjnmVq ?? (ejlTstGfmXpDvSTBLMibZjIjnmVq = new QGehTNnocANGBRsHvuRsPpBmmlcW());

			public bool Equals(float x, float y)
			{
				return x == y;
			}

			bool IEqualityComparer<float>.Equals(float x, float y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(float obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<float>.GetHashCode(float obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class NTBGKXbTpAXHGsQdQGnrHqXiNDiQb : IEqualityComparer, IEqualityComparer<double>
		{
			private static NTBGKXbTpAXHGsQdQGnrHqXiNDiQb QZbNWIYNdRWFicLmorBSjiaPhUIFA;

			public static NTBGKXbTpAXHGsQdQGnrHqXiNDiQb REppceLBkxIRtdFTBRFoukDXKRNj => QZbNWIYNdRWFicLmorBSjiaPhUIFA ?? (QZbNWIYNdRWFicLmorBSjiaPhUIFA = new NTBGKXbTpAXHGsQdQGnrHqXiNDiQb());

			public bool Equals(double x, double y)
			{
				return x == y;
			}

			bool IEqualityComparer<double>.Equals(double x, double y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(double obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<double>.GetHashCode(double obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class VpgRmqXJimoLGjzbidVfEJmqfdlaA : IEqualityComparer, IEqualityComparer<byte>
		{
			private static VpgRmqXJimoLGjzbidVfEJmqfdlaA qLZUEsEDANLrXlJPmCDOWczAYTaI;

			public static VpgRmqXJimoLGjzbidVfEJmqfdlaA VCFfpOTKxTZmcTiiodkYHKzIakIkA => qLZUEsEDANLrXlJPmCDOWczAYTaI ?? (qLZUEsEDANLrXlJPmCDOWczAYTaI = new VpgRmqXJimoLGjzbidVfEJmqfdlaA());

			public bool Equals(byte x, byte y)
			{
				return x == y;
			}

			bool IEqualityComparer<byte>.Equals(byte x, byte y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(byte obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<byte>.GetHashCode(byte obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class AJCOLlDxneQoEOlKrtDxAKgYixjBA : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static AJCOLlDxneQoEOlKrtDxAKgYixjBA gasRbFcmcGJdvfaFCPNzGUwKHmnb;

			public static AJCOLlDxneQoEOlKrtDxAKgYixjBA wqJZkzIaHlYAoXLFDeHyPhAHPFYI => gasRbFcmcGJdvfaFCPNzGUwKHmnb ?? (gasRbFcmcGJdvfaFCPNzGUwKHmnb = new AJCOLlDxneQoEOlKrtDxAKgYixjBA());

			public bool Equals(sbyte x, sbyte y)
			{
				return x == y;
			}

			bool IEqualityComparer<sbyte>.Equals(sbyte x, sbyte y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(sbyte obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<sbyte>.GetHashCode(sbyte obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class nhVnDWwDhdoXOMdXddSzMELHiyIe : IEqualityComparer, IEqualityComparer<bool>
		{
			private static nhVnDWwDhdoXOMdXddSzMELHiyIe wWfOByrRDAUmXRWCgMhdEGfFipNe;

			public static nhVnDWwDhdoXOMdXddSzMELHiyIe VdDxucAxGYzVBnaTaXlXCYaLWlmK => wWfOByrRDAUmXRWCgMhdEGfFipNe ?? (wWfOByrRDAUmXRWCgMhdEGfFipNe = new nhVnDWwDhdoXOMdXddSzMELHiyIe());

			public bool Equals(bool x, bool y)
			{
				return x == y;
			}

			bool IEqualityComparer<bool>.Equals(bool x, bool y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(bool obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<bool>.GetHashCode(bool obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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

		private class vtWgNzYVXdWDOikebJKjiNtgTvfK : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static vtWgNzYVXdWDOikebJKjiNtgTvfK vojCCBZMfvDwxUJVvxNEnAGjIetBA;

			public static vtWgNzYVXdWDOikebJKjiNtgTvfK HzbTjGkiRwbgZiQZynlQsaQMbVqbA => vojCCBZMfvDwxUJVvxNEnAGjIetBA ?? (vojCCBZMfvDwxUJVvxNEnAGjIetBA = new vtWgNzYVXdWDOikebJKjiNtgTvfK());

			public bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			bool IEqualityComparer<IntPtr>.Equals(IntPtr x, IntPtr y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(x, y);
			}

			public int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}

			int IEqualityComparer<IntPtr>.GetHashCode(IntPtr obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetHashCode
				return this.GetHashCode(obj);
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
					return (IEqualityComparer<T>)RSomheSYoacBPEvJXhDQbjcyKAuE.fyxmuDtbFNDenhYGEsbCBBllHmxib;
				}
				if ((object)typeFromHandle == typeof(long))
				{
					return (IEqualityComparer<T>)ecAGVkpyyshOUgpzrlRVyfAUHmWG.ErEEzCjbZVbfNVLgJBbHBsZlRmNM;
				}
				if ((object)typeFromHandle == typeof(uint))
				{
					return (IEqualityComparer<T>)ueESjMreyPoSgYIAoVDnRtHahBZv.cFwFPBkreAruFDizsDZtRcETPnfQA;
				}
				if ((object)typeFromHandle == typeof(ulong))
				{
					return (IEqualityComparer<T>)RIfzxXMlAqomWIJnbgxhnUknycu.PomrdtzTwidmWraKfkIhwAagABpI;
				}
				if ((object)typeFromHandle == typeof(float))
				{
					return (IEqualityComparer<T>)QGehTNnocANGBRsHvuRsPpBmmlcW.iXbSmfLkuHrnECmOSjtgKEcIvLeHA;
				}
				if ((object)typeFromHandle == typeof(double))
				{
					return (IEqualityComparer<T>)NTBGKXbTpAXHGsQdQGnrHqXiNDiQb.REppceLBkxIRtdFTBRFoukDXKRNj;
				}
				if ((object)typeFromHandle == typeof(byte))
				{
					return (IEqualityComparer<T>)VpgRmqXJimoLGjzbidVfEJmqfdlaA.VCFfpOTKxTZmcTiiodkYHKzIakIkA;
				}
				if ((object)typeFromHandle == typeof(sbyte))
				{
					return (IEqualityComparer<T>)AJCOLlDxneQoEOlKrtDxAKgYixjBA.wqJZkzIaHlYAoXLFDeHyPhAHPFYI;
				}
				if ((object)typeFromHandle == typeof(bool))
				{
					return (IEqualityComparer<T>)nhVnDWwDhdoXOMdXddSzMELHiyIe.VdDxucAxGYzVBnaTaXlXCYaLWlmK;
				}
				if ((object)typeFromHandle == typeof(IntPtr))
				{
					return (IEqualityComparer<T>)vtWgNzYVXdWDOikebJKjiNtgTvfK.HzbTjGkiRwbgZiQZynlQsaQMbVqbA;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
