using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class wDxltwsOcAxtVrLvfbjqEldmjmFI : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct YQuggLHUluMYjcaPDyBVCQyucILYA : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private wDxltwsOcAxtVrLvfbjqEldmjmFI PSTFzqNUCvLCCWPHGQjhTVBHOysh;

		private int mvXdSFHldOQbmdmHgalevSWNWOldb;

		byte IEnumerator<byte>.Current => PSTFzqNUCvLCCWPHGQjhTVBHOysh.VkbxhOppzazqABXPhKgYniGmifIs(mvXdSFHldOQbmdmHgalevSWNWOldb);

		object IEnumerator.Current => PSTFzqNUCvLCCWPHGQjhTVBHOysh.VkbxhOppzazqABXPhKgYniGmifIs(mvXdSFHldOQbmdmHgalevSWNWOldb);

		public YQuggLHUluMYjcaPDyBVCQyucILYA(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0)
		{
			PSTFzqNUCvLCCWPHGQjhTVBHOysh = P_0;
			mvXdSFHldOQbmdmHgalevSWNWOldb = -1;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (mvXdSFHldOQbmdmHgalevSWNWOldb >= PSTFzqNUCvLCCWPHGQjhTVBHOysh.fAgdGKEsQkYQhUPYmpxnJexlAxhTA - 1)
			{
				return false;
			}
			mvXdSFHldOQbmdmHgalevSWNWOldb++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			mvXdSFHldOQbmdmHgalevSWNWOldb = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int fAgdGKEsQkYQhUPYmpxnJexlAxhTA;

	private unsafe byte* TyBsvsIPdVirUHLjKmBTwYMnBYozA;

	public int SLmbGyvIpieAQGuSQWFIlxpiboSJ => fAgdGKEsQkYQhUPYmpxnJexlAxhTA;

	public unsafe bool gzkXdPkykOHPPQztcYtoBUpfJtOJ
	{
		get
		{
			if (fAgdGKEsQkYQhUPYmpxnJexlAxhTA <= 0)
			{
				return true;
			}
			return TyBsvsIPdVirUHLjKmBTwYMnBYozA != null;
		}
	}

	public unsafe byte EamgoYNNurOqsIDnCBONFlhmFsjE
	{
		get
		{
			if (P_0 < 0 || P_0 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
			{
				throw new IndexOutOfRangeException();
			}
			return TyBsvsIPdVirUHLjKmBTwYMnBYozA[P_0];
		}
		set
		{
			if (num < 0 || num >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
			{
				throw new IndexOutOfRangeException();
			}
			TyBsvsIPdVirUHLjKmBTwYMnBYozA[num] = b;
		}
	}

	public wDxltwsOcAxtVrLvfbjqEldmjmFI(int P_0)
	{
		oKYtDHgXjnbIeEwoVwsDOzglpuPC(P_0);
	}

	public unsafe wDxltwsOcAxtVrLvfbjqEldmjmFI(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0.Length);
	}

	public wDxltwsOcAxtVrLvfbjqEldmjmFI(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0)
		: this(P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
	{
		P_0.FlvDPlAeGmCpXUXTtAPvEFpvaVQTA(this, 0, P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA);
	}

	public unsafe wDxltwsOcAxtVrLvfbjqEldmjmFI(byte* P_0, int P_1)
		: this(P_1)
	{
		byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(P_0, TyBsvsIPdVirUHLjKmBTwYMnBYozA, 0, 0, P_1);
	}

	public unsafe bool hryOpvdeBkoIUfAAzrCBEoWZDHLF(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool FlvDPlAeGmCpXUXTtAPvEFpvaVQTA(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return hryOpvdeBkoIUfAAzrCBEoWZDHLF(P_0.TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA, P_1, P_2, P_3);
	}

	public unsafe bool ExGhFDIQqnmLlZMcvMfKDGmAXRhO(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool lErsOOVQrmTHODQVoyeqROdBtNRx(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool RjeMUxVpsOACUhfitRqkfUVBmzddA(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return lErsOOVQrmTHODQVoyeqROdBtNRx(P_0.TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA, P_1, P_2, P_3, P_4);
	}

	public unsafe bool uSuqbeauoadETGiHvqZEJCIPTHDD(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool JyEgNkhdFkCWQAJpfxESHcswiKUPc(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			P_3 = fAgdGKEsQkYQhUPYmpxnJexlAxhTA - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool NJQZmTjorssNgVNnpXJzhemKDJjl(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return JyEgNkhdFkCWQAJpfxESHcswiKUPc(P_0.TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA, P_1, P_2);
	}

	public unsafe bool iuBEztvxWfjsKGIcoXOewMZhVUKr(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			P_2 = fAgdGKEsQkYQhUPYmpxnJexlAxhTA - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool rBXXKeVFyOcqbycbAsLlQArREZMCA(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			P_4 = fAgdGKEsQkYQhUPYmpxnJexlAxhTA - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return byZcZqIHxDbsMlffPcbwjwzKCDShb.dyoQAxMhxFETOZadtDYECzhvSTwKA(TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool KEyXPwEPRsRMGoWguljVZKYYOAcB(wDxltwsOcAxtVrLvfbjqEldmjmFI P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return rBXXKeVFyOcqbycbAsLlQArREZMCA(P_0.TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0.fAgdGKEsQkYQhUPYmpxnJexlAxhTA, P_1, P_2, P_3);
	}

	public unsafe bool JPbJBwaIYXLYAwKBMAiLRbGoOnzo(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			P_3 = fAgdGKEsQkYQhUPYmpxnJexlAxhTA - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void xanoOmJpkAIHSGeekjMuSpWEJbzoA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (fAgdGKEsQkYQhUPYmpxnJexlAxhTA != P_0)
		{
			oKYtDHgXjnbIeEwoVwsDOzglpuPC(P_0);
		}
	}

	public unsafe void jtsSYjHsSTqBPBIVDCTjDyiFipAW()
	{
		if (fAgdGKEsQkYQhUPYmpxnJexlAxhTA != 0 && TyBsvsIPdVirUHLjKmBTwYMnBYozA != null)
		{
			byZcZqIHxDbsMlffPcbwjwzKCDShb.QWzjHjKKFDaDLHcBJvSqVPOlqHWH(TyBsvsIPdVirUHLjKmBTwYMnBYozA, fAgdGKEsQkYQhUPYmpxnJexlAxhTA);
		}
	}

	private unsafe void oKYtDHgXjnbIeEwoVwsDOzglpuPC(int P_0)
	{
		if (P_0 == fAgdGKEsQkYQhUPYmpxnJexlAxhTA)
		{
			jtsSYjHsSTqBPBIVDCTjDyiFipAW();
			return;
		}
		if (fAgdGKEsQkYQhUPYmpxnJexlAxhTA > 0)
		{
			iAwtbyBprZabnsLNZTnoVugZpObT();
		}
		TyBsvsIPdVirUHLjKmBTwYMnBYozA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (TyBsvsIPdVirUHLjKmBTwYMnBYozA == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		fAgdGKEsQkYQhUPYmpxnJexlAxhTA = P_0;
		jtsSYjHsSTqBPBIVDCTjDyiFipAW();
	}

	private unsafe void iAwtbyBprZabnsLNZTnoVugZpObT()
	{
		if (TyBsvsIPdVirUHLjKmBTwYMnBYozA != null)
		{
			Marshal.FreeHGlobal((IntPtr)TyBsvsIPdVirUHLjKmBTwYMnBYozA);
		}
		TyBsvsIPdVirUHLjKmBTwYMnBYozA = null;
		fAgdGKEsQkYQhUPYmpxnJexlAxhTA = 0;
	}

	public void Dispose()
	{
		uYmfOQfTuANkRzSgsgCkGQTCJYKsB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void pRTkgKqcWeFcJKRELzANsyOdpatt()
	{
		try
		{
			uYmfOQfTuANkRzSgsgCkGQTCJYKsB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void uYmfOQfTuANkRzSgsgCkGQTCJYKsB(bool P_0)
	{
		iAwtbyBprZabnsLNZTnoVugZpObT();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new YQuggLHUluMYjcaPDyBVCQyucILYA(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new YQuggLHUluMYjcaPDyBVCQyucILYA(this);
	}
}
