using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class VzllWcTNDMJNQAhalGOEBBThJgCt : IEqualityComparer, IEqualityComparer<int>
		{
			private static VzllWcTNDMJNQAhalGOEBBThJgCt OUefHtesMXNZmerVNDLXyJrQXaSVA;

			public static VzllWcTNDMJNQAhalGOEBBThJgCt xeidzXfsEjdTuLEByZOPhhLmrODdA => OUefHtesMXNZmerVNDLXyJrQXaSVA ?? (OUefHtesMXNZmerVNDLXyJrQXaSVA = new VzllWcTNDMJNQAhalGOEBBThJgCt());

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

		private class aVBNtaixtMSvRewrXGkUWyjVpasD : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static aVBNtaixtMSvRewrXGkUWyjVpasD yajzJpQifBDMMfgeYqDPOpppWHom;

			public static aVBNtaixtMSvRewrXGkUWyjVpasD WxPTyOytUpcSIPQjdUSYdkngOOnU => yajzJpQifBDMMfgeYqDPOpppWHom ?? (yajzJpQifBDMMfgeYqDPOpppWHom = new aVBNtaixtMSvRewrXGkUWyjVpasD());

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

		private class kbRjmUkXbjcdfAONSloiJdblYxdY : IEqualityComparer, IEqualityComparer<uint>
		{
			private static kbRjmUkXbjcdfAONSloiJdblYxdY ujTVgdVTgQAEnbzfEpLWbOBLhMbn;

			public static kbRjmUkXbjcdfAONSloiJdblYxdY qIdrYZorfgtBYaRgCaqmCaySLVXm => ujTVgdVTgQAEnbzfEpLWbOBLhMbn ?? (ujTVgdVTgQAEnbzfEpLWbOBLhMbn = new kbRjmUkXbjcdfAONSloiJdblYxdY());

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

		private class ZKJeczAogiDnhYYOFHduHWutYaQK : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static ZKJeczAogiDnhYYOFHduHWutYaQK zVggjOkhfxLrBdRKcmMLMjIgkrzS;

			public static ZKJeczAogiDnhYYOFHduHWutYaQK PlIqjOcrUVUNFfxFMNgCYKvSkZkA => zVggjOkhfxLrBdRKcmMLMjIgkrzS ?? (zVggjOkhfxLrBdRKcmMLMjIgkrzS = new ZKJeczAogiDnhYYOFHduHWutYaQK());

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

		private class EndwSLuqfyahCIPWZVarDphrvHEcA : IEqualityComparer, IEqualityComparer<float>
		{
			private static EndwSLuqfyahCIPWZVarDphrvHEcA smaEzlPplvcaeWhQrVLsrNcuwOvy;

			public static EndwSLuqfyahCIPWZVarDphrvHEcA arkFnlUJpneAHEMVwTWzkICHZlAO => smaEzlPplvcaeWhQrVLsrNcuwOvy ?? (smaEzlPplvcaeWhQrVLsrNcuwOvy = new EndwSLuqfyahCIPWZVarDphrvHEcA());

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

		private class FnQqBRGzeyemVQiaykAkUtxCdJWl : IEqualityComparer, IEqualityComparer<double>
		{
			private static FnQqBRGzeyemVQiaykAkUtxCdJWl MwcENEKXwjdetigrIwmJZPCIWygaA;

			public static FnQqBRGzeyemVQiaykAkUtxCdJWl FlcaWyOWhDzqstGStiybANrQkNhI => MwcENEKXwjdetigrIwmJZPCIWygaA ?? (MwcENEKXwjdetigrIwmJZPCIWygaA = new FnQqBRGzeyemVQiaykAkUtxCdJWl());

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

		private class NVtfleJSjCmwRHvoCrwkqqUrxHVV : IEqualityComparer, IEqualityComparer<byte>
		{
			private static NVtfleJSjCmwRHvoCrwkqqUrxHVV cIALuyDgDdakWfrWCobBkSRDpaMR;

			public static NVtfleJSjCmwRHvoCrwkqqUrxHVV DWGkMEODcfsvxZzPQXxDfHZBOeoE => cIALuyDgDdakWfrWCobBkSRDpaMR ?? (cIALuyDgDdakWfrWCobBkSRDpaMR = new NVtfleJSjCmwRHvoCrwkqqUrxHVV());

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

		private class OPBDCpIYaMnFNMWDRNoekTANzVVU : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static OPBDCpIYaMnFNMWDRNoekTANzVVU wvnUZhhAdyijebNdsiZEaBoHjAMj;

			public static OPBDCpIYaMnFNMWDRNoekTANzVVU inYOTfRorXdKhHYwrJzvvmXIhHiE => wvnUZhhAdyijebNdsiZEaBoHjAMj ?? (wvnUZhhAdyijebNdsiZEaBoHjAMj = new OPBDCpIYaMnFNMWDRNoekTANzVVU());

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

		private class fNWcvUvgiLBPFIEMNtOyaCySjQaw : IEqualityComparer, IEqualityComparer<bool>
		{
			private static fNWcvUvgiLBPFIEMNtOyaCySjQaw wtuLZeynCajxvNKBIhykaraSGTrh;

			public static fNWcvUvgiLBPFIEMNtOyaCySjQaw RQGooDFPeiKMQdCIQyAhgONUyQJb => wtuLZeynCajxvNKBIhykaraSGTrh ?? (wtuLZeynCajxvNKBIhykaraSGTrh = new fNWcvUvgiLBPFIEMNtOyaCySjQaw());

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

		private class rMDQIjDfUJKuPcqdLMjwIpTnFjLbA : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static rMDQIjDfUJKuPcqdLMjwIpTnFjLbA hieLNRKgoZDrqSNUFaCLXXgaEVFf;

			public static rMDQIjDfUJKuPcqdLMjwIpTnFjLbA HCaEFAliOWBAAwKKSMqJYmwVxrMi => hieLNRKgoZDrqSNUFaCLXXgaEVFf ?? (hieLNRKgoZDrqSNUFaCLXXgaEVFf = new rMDQIjDfUJKuPcqdLMjwIpTnFjLbA());

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
					return (IEqualityComparer<T>)VzllWcTNDMJNQAhalGOEBBThJgCt.xeidzXfsEjdTuLEByZOPhhLmrODdA;
				}
				if ((object)typeFromHandle == typeof(long))
				{
					return (IEqualityComparer<T>)aVBNtaixtMSvRewrXGkUWyjVpasD.WxPTyOytUpcSIPQjdUSYdkngOOnU;
				}
				if ((object)typeFromHandle == typeof(uint))
				{
					return (IEqualityComparer<T>)kbRjmUkXbjcdfAONSloiJdblYxdY.qIdrYZorfgtBYaRgCaqmCaySLVXm;
				}
				if ((object)typeFromHandle == typeof(ulong))
				{
					return (IEqualityComparer<T>)ZKJeczAogiDnhYYOFHduHWutYaQK.PlIqjOcrUVUNFfxFMNgCYKvSkZkA;
				}
				if ((object)typeFromHandle == typeof(float))
				{
					return (IEqualityComparer<T>)EndwSLuqfyahCIPWZVarDphrvHEcA.arkFnlUJpneAHEMVwTWzkICHZlAO;
				}
				if ((object)typeFromHandle == typeof(double))
				{
					return (IEqualityComparer<T>)FnQqBRGzeyemVQiaykAkUtxCdJWl.FlcaWyOWhDzqstGStiybANrQkNhI;
				}
				if ((object)typeFromHandle == typeof(byte))
				{
					return (IEqualityComparer<T>)NVtfleJSjCmwRHvoCrwkqqUrxHVV.DWGkMEODcfsvxZzPQXxDfHZBOeoE;
				}
				if ((object)typeFromHandle == typeof(sbyte))
				{
					return (IEqualityComparer<T>)OPBDCpIYaMnFNMWDRNoekTANzVVU.inYOTfRorXdKhHYwrJzvvmXIhHiE;
				}
				if ((object)typeFromHandle == typeof(bool))
				{
					return (IEqualityComparer<T>)fNWcvUvgiLBPFIEMNtOyaCySjQaw.RQGooDFPeiKMQdCIQyAhgONUyQJb;
				}
				if ((object)typeFromHandle == typeof(IntPtr))
				{
					return (IEqualityComparer<T>)rMDQIjDfUJKuPcqdLMjwIpTnFjLbA.HCaEFAliOWBAAwKKSMqJYmwVxrMi;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
