using System;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class DHyomQWjauMcPIkowDdfDsBSAhHg : ngzGskRWZJYrKPHiTCFoPljOBNT
{
	internal class PjuRtVIxBeXsRSfIDUxILVkYObB : YcEAYcheCtPpqqoDLFNjlanIafmR
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int QVRFAGodoMcFPbMVcUEDaROfmbog(IntPtr thisObject, IntPtr guid, out IntPtr output);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int EodrisxmQanPrDJrCoruGnsdngx(IntPtr thisObject);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int jnlxKKruzEXdhbfuOvBdWxotKle(IntPtr thisObject);

		public PjuRtVIxBeXsRSfIDUxILVkYObB(int numberOfCallbackMethods)
			: base(numberOfCallbackMethods + 3)
		{
			aDcfFchGbJbrAnnMPQrMeekPAxdF(new QVRFAGodoMcFPbMVcUEDaROfmbog(vJhVfdNESfmoQcokhPzKKdEumuB));
			aDcfFchGbJbrAnnMPQrMeekPAxdF(new EodrisxmQanPrDJrCoruGnsdngx(UctucjArxGXXHPwPxBVtMMMYlUv));
			aDcfFchGbJbrAnnMPQrMeekPAxdF(new jnlxKKruzEXdhbfuOvBdWxotKle(NTigRLefPkhNVQMAzOvcjTBmjmRo));
		}

		protected unsafe static int vJhVfdNESfmoQcokhPzKKdEumuB(IntPtr P_0, IntPtr P_1, out IntPtr P_2)
		{
			DHyomQWjauMcPIkowDdfDsBSAhHg dHyomQWjauMcPIkowDdfDsBSAhHg = ngzGskRWZJYrKPHiTCFoPljOBNT.yahYmCoQMMfVRooGdVFikKwxYmd<DHyomQWjauMcPIkowDdfDsBSAhHg>(P_0);
			if (dHyomQWjauMcPIkowDdfDsBSAhHg == null)
			{
				P_2 = IntPtr.Zero;
				return llpFqWliQEfHkPmCCWtyJDAPdFG.eukeFKsUhVcorQiYRqHNssAkuYX.Code;
			}
			return dHyomQWjauMcPIkowDdfDsBSAhHg.vJhVfdNESfmoQcokhPzKKdEumuB(P_0, ref *(Guid*)(void*)P_1, out P_2);
		}

		protected static int UctucjArxGXXHPwPxBVtMMMYlUv(IntPtr P_0)
		{
			return ngzGskRWZJYrKPHiTCFoPljOBNT.yahYmCoQMMfVRooGdVFikKwxYmd<DHyomQWjauMcPIkowDdfDsBSAhHg>(P_0)?.UctucjArxGXXHPwPxBVtMMMYlUv(P_0) ?? 0;
		}

		protected static int NTigRLefPkhNVQMAzOvcjTBmjmRo(IntPtr P_0)
		{
			return ngzGskRWZJYrKPHiTCFoPljOBNT.yahYmCoQMMfVRooGdVFikKwxYmd<DHyomQWjauMcPIkowDdfDsBSAhHg>(P_0)?.NTigRLefPkhNVQMAzOvcjTBmjmRo(P_0) ?? 0;
		}
	}

	private int RWklmqWZUQouKnFAWGkBSxdcOkZ = 1;

	public static Guid UgtIyyVpSqKTXudfFJnYkHnhzJE = new Guid("00000000-0000-0000-C000-000000000046");

	protected int vJhVfdNESfmoQcokhPzKKdEumuB(IntPtr P_0, ref Guid P_1, out IntPtr P_2)
	{
		DHyomQWjauMcPIkowDdfDsBSAhHg dHyomQWjauMcPIkowDdfDsBSAhHg = (DHyomQWjauMcPIkowDdfDsBSAhHg)((uVOhyXJEBHNMmLikRbBJPYIweyE)base.Callback.Shadow).NtGjyQqnNakEjDefwGjxitGKgsA(P_1);
		if (dHyomQWjauMcPIkowDdfDsBSAhHg != null)
		{
			dHyomQWjauMcPIkowDdfDsBSAhHg.UctucjArxGXXHPwPxBVtMMMYlUv(P_0);
			P_2 = dHyomQWjauMcPIkowDdfDsBSAhHg.NativePointer;
			return llpFqWliQEfHkPmCCWtyJDAPdFG.SDdUlCTcEYKXsgFRafZmbpFIEvW.Code;
		}
		P_2 = IntPtr.Zero;
		return llpFqWliQEfHkPmCCWtyJDAPdFG.eukeFKsUhVcorQiYRqHNssAkuYX.Code;
	}

	protected virtual int UctucjArxGXXHPwPxBVtMMMYlUv(IntPtr P_0)
	{
		return Interlocked.Increment(ref RWklmqWZUQouKnFAWGkBSxdcOkZ);
	}

	protected virtual int NTigRLefPkhNVQMAzOvcjTBmjmRo(IntPtr P_0)
	{
		return Interlocked.Decrement(ref RWklmqWZUQouKnFAWGkBSxdcOkZ);
	}
}
