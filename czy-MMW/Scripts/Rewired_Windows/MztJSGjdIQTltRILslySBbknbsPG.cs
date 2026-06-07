using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Platforms;

internal class MztJSGjdIQTltRILslySBbknbsPG : SpuHlNFbzIcPcRFJZVLvmcbZoCjW, IDisposable
{
	private static class pUdCTMcnskiFTnpRcdmKJuirZMpV
	{
		private struct jMLkHsUIAHJodmhKQAXiGtsXhRMaA
		{
			internal int IeCqdqVkDEvyhExqGPjRjbtoVgBe;

			internal int SSmXiGxoeZDLgRhypFstSkhBiOk;

			internal int UNXdQdQaNaYCynKCnEQHPFKsOPqb;

			internal Guid QTpjAalZjdiLbhVuFiDEdjyABcvbA;

			internal short xHfsYVgZWyMHciyUWkFjhHvAqUyE;
		}

		private static readonly Guid CfkBcLitEoMSXvSWYpDwariaFUkXB = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");

		private static IntPtr erXJPoPIXvsCloYahMbvUzOHTbdC;

		private static bool nnDdbXTWJqLJOTDiQPkODUqiMSUP;

		public static void rxwPzdOTVMLesOmznFcwShTzGqGhA(IntPtr P_0)
		{
			jMLkHsUIAHJodmhKQAXiGtsXhRMaA structure = new jMLkHsUIAHJodmhKQAXiGtsXhRMaA
			{
				SSmXiGxoeZDLgRhypFstSkhBiOk = 5,
				UNXdQdQaNaYCynKCnEQHPFKsOPqb = 0,
				QTpjAalZjdiLbhVuFiDEdjyABcvbA = CfkBcLitEoMSXvSWYpDwariaFUkXB,
				xHfsYVgZWyMHciyUWkFjhHvAqUyE = 0
			};
			structure.IeCqdqVkDEvyhExqGPjRjbtoVgBe = Marshal.SizeOf(structure);
			IntPtr intPtr = Marshal.AllocHGlobal(structure.IeCqdqVkDEvyhExqGPjRjbtoVgBe);
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			erXJPoPIXvsCloYahMbvUzOHTbdC = jUFDRChlCvyssntkoAsFpNGjFqMIA(P_0, intPtr, 0);
			nnDdbXTWJqLJOTDiQPkODUqiMSUP = true;
		}

		public static void ofguEtdnQBJnNHMJuHEIGJVcRPctA()
		{
			if (!(erXJPoPIXvsCloYahMbvUzOHTbdC == IntPtr.Zero))
			{
				xUmCwLwZPeQdBIUEMnVCyimtCDxHA(erXJPoPIXvsCloYahMbvUzOHTbdC);
				nnDdbXTWJqLJOTDiQPkODUqiMSUP = false;
			}
		}

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "RegisterDeviceNotification", SetLastError = true)]
		private static extern IntPtr jUFDRChlCvyssntkoAsFpNGjFqMIA(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnregisterDeviceNotification")]
		private static extern bool xUmCwLwZPeQdBIUEMnVCyimtCDxHA(IntPtr P_0);
	}

	private Action<EventArgs> acpgLqEMHkpjjAbFbJactxofOjKTd;

	private Action<EventArgs> AdoTCpojYfBMVfdeXWBCmNkwksWiA;

	private Action<EventArgs> mCAhUTGshhMnWLRWLHmzjmantkgLA;

	private Action<oymhsAPIfMyZRMQaeDTCWtiWVvgh, vjLKSDOZfFImbYjjOVLVIVdqJbio> QxYKpCIaHIjvgPPyTJdodwPyCrdK;

	private IntPtr fBGClyhtgGggZqmytdNXoVDWzcgH;

	private AOPqlOHynGlfBPmVtFamIiQqvLnBA wqYTfrfFXBwOJIOgFfTWQrcxMNNV;

	private readonly bool JXxPFiojJKovIyoWUxrGGjzJhdNt;

	private static WDfkTImFSaQkAopFgARJAIdQhUmX LHxMLVBovshqugRIEIqgOtnnwmpf;

	private AOPqlOHynGlfBPmVtFamIiQqvLnBA whGPdejqNvLNlzGTGVxUsIDlvqKr;

	private bool IXqZjcdojOPQCwsfXhBKAzmWXUFeA;

	public IntPtr BDrdrECItDCRaacyCmvnpDrgxNUc => fBGClyhtgGggZqmytdNXoVDWzcgH;

	event Action<EventArgs> SpuHlNFbzIcPcRFJZVLvmcbZoCjW.EPWCkjITdpOLiwoYvGtvEddUkibzA
	{
		add
		{
			acpgLqEMHkpjjAbFbJactxofOjKTd = (Action<EventArgs>)Delegate.Combine(acpgLqEMHkpjjAbFbJactxofOjKTd, b);
		}
		remove
		{
			acpgLqEMHkpjjAbFbJactxofOjKTd = (Action<EventArgs>)Delegate.Remove(acpgLqEMHkpjjAbFbJactxofOjKTd, value2);
		}
	}

	event Action<EventArgs> SpuHlNFbzIcPcRFJZVLvmcbZoCjW.wvIxwNgQhJAEcdqQMBjQZWCKHBHfA
	{
		add
		{
			AdoTCpojYfBMVfdeXWBCmNkwksWiA = (Action<EventArgs>)Delegate.Combine(AdoTCpojYfBMVfdeXWBCmNkwksWiA, b);
		}
		remove
		{
			AdoTCpojYfBMVfdeXWBCmNkwksWiA = (Action<EventArgs>)Delegate.Remove(AdoTCpojYfBMVfdeXWBCmNkwksWiA, value2);
		}
	}

	public event Action<oymhsAPIfMyZRMQaeDTCWtiWVvgh, vjLKSDOZfFImbYjjOVLVIVdqJbio> NhwPXzilyijqWilRAJQRnLCwPpLl
	{
		add
		{
			QxYKpCIaHIjvgPPyTJdodwPyCrdK = (Action<oymhsAPIfMyZRMQaeDTCWtiWVvgh, vjLKSDOZfFImbYjjOVLVIVdqJbio>)Delegate.Combine(QxYKpCIaHIjvgPPyTJdodwPyCrdK, b);
		}
		remove
		{
			QxYKpCIaHIjvgPPyTJdodwPyCrdK = (Action<oymhsAPIfMyZRMQaeDTCWtiWVvgh, vjLKSDOZfFImbYjjOVLVIVdqJbio>)Delegate.Remove(QxYKpCIaHIjvgPPyTJdodwPyCrdK, value2);
		}
	}

	public MztJSGjdIQTltRILslySBbknbsPG()
	{
		JXxPFiojJKovIyoWUxrGGjzJhdNt = ReInput.editorPlatform != EditorPlatform.None;
		try
		{
			vujYNqFbIZAgZURCHjuWfhbZWDAqA();
		}
		catch
		{
			ipQoqpBcXzpJMitwmsKIFlOnGmAE();
			throw;
		}
	}

	public void ipQoqpBcXzpJMitwmsKIFlOnGmAE()
	{
		Dispose();
	}

	void SpuHlNFbzIcPcRFJZVLvmcbZoCjW.oSgWhZmWkKeaCFPNVEfTfknZNmVVA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ipQoqpBcXzpJMitwmsKIFlOnGmAE
		this.ipQoqpBcXzpJMitwmsKIFlOnGmAE();
	}

	private void vujYNqFbIZAgZURCHjuWfhbZWDAqA()
	{
		zqPSFUmIbbyiBEjeJGEVlbGGJEHC();
		FHzWjSBqlgxxdVkMTqKDAeqWDhqhA();
		if (JXxPFiojJKovIyoWUxrGGjzJhdNt)
		{
			whGPdejqNvLNlzGTGVxUsIDlvqKr = new AOPqlOHynGlfBPmVtFamIiQqvLnBA();
			whGPdejqNvLNlzGTGVxUsIDlvqKr.plUslHmSZsbRLrpVSVOAzQLjIDMb(CTezcPQlOoJOXqPDjcubfZIdjwlKA, true);
		}
	}

	public void Dispose()
	{
		HMOzAcYKoWXZZVICdEeTiByDujbP(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void arfqKMtpDlspntIdsIKHqgHTxIop()
	{
		try
		{
			HMOzAcYKoWXZZVICdEeTiByDujbP(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void HMOzAcYKoWXZZVICdEeTiByDujbP(bool P_0)
	{
		if (IXqZjcdojOPQCwsfXhBKAzmWXUFeA)
		{
			return;
		}
		if (JXxPFiojJKovIyoWUxrGGjzJhdNt)
		{
			sbWCIUjEmhnIYzznSzFMXsTQPDng();
			if (whGPdejqNvLNlzGTGVxUsIDlvqKr != null)
			{
				whGPdejqNvLNlzGTGVxUsIDlvqKr.Dispose();
			}
			if (LHxMLVBovshqugRIEIqgOtnnwmpf != null)
			{
				LHxMLVBovshqugRIEIqgOtnnwmpf.Dispose();
				LHxMLVBovshqugRIEIqgOtnnwmpf = null;
			}
		}
		else
		{
			sbWCIUjEmhnIYzznSzFMXsTQPDng();
			if (wqYTfrfFXBwOJIOgFfTWQrcxMNNV != null)
			{
				wqYTfrfFXBwOJIOgFfTWQrcxMNNV.Dispose();
			}
		}
		IXqZjcdojOPQCwsfXhBKAzmWXUFeA = true;
	}

	private void FHzWjSBqlgxxdVkMTqKDAeqWDhqhA()
	{
		pUdCTMcnskiFTnpRcdmKJuirZMpV.rxwPzdOTVMLesOmznFcwShTzGqGhA(fBGClyhtgGggZqmytdNXoVDWzcgH);
	}

	private void sbWCIUjEmhnIYzznSzFMXsTQPDng()
	{
		pUdCTMcnskiFTnpRcdmKJuirZMpV.ofguEtdnQBJnNHMJuHEIGJVcRPctA();
	}

	private void XEygvRMRqnJAgXTPgOIYYgshfKYU(HcRBSzHiTzbGMALvAEsXZexPXEBZ P_0, oymhsAPIfMyZRMQaeDTCWtiWVvgh P_1, uint P_2, IntPtr P_3)
	{
		switch (P_2)
		{
		case 537u:
		{
			int num = P_1.JvRDYSETmAOmGlhbESDLXnmVxbui();
			if (P_3 == fBGClyhtgGggZqmytdNXoVDWzcgH)
			{
				switch (num)
				{
				case 32768:
					acpgLqEMHkpjjAbFbJactxofOjKTd?.Invoke(null);
					break;
				case 32772:
					AdoTCpojYfBMVfdeXWBCmNkwksWiA?.Invoke(null);
					break;
				case 32771:
					mCAhUTGshhMnWLRWLHmzjmantkgLA?.Invoke(null);
					break;
				}
			}
			break;
		}
		case 7u:
		case 8u:
			if (QxYKpCIaHIjvgPPyTJdodwPyCrdK != null)
			{
				QxYKpCIaHIjvgPPyTJdodwPyCrdK(P_1, SXgteXWEPLyHbxmQNCQiBhYIujrBA.HEJruwmPUlmmoiNsPedjwZEKPPtP(P_2));
			}
			break;
		}
	}

	private void CTezcPQlOoJOXqPDjcubfZIdjwlKA(HcRBSzHiTzbGMALvAEsXZexPXEBZ P_0, oymhsAPIfMyZRMQaeDTCWtiWVvgh P_1, uint P_2, IntPtr P_3)
	{
		if (P_2 == 8 && QxYKpCIaHIjvgPPyTJdodwPyCrdK != null)
		{
			QxYKpCIaHIjvgPPyTJdodwPyCrdK(P_1, SXgteXWEPLyHbxmQNCQiBhYIujrBA.HEJruwmPUlmmoiNsPedjwZEKPPtP(P_2));
		}
	}

	private void zqPSFUmIbbyiBEjeJGEVlbGGJEHC()
	{
		if (LHxMLVBovshqugRIEIqgOtnnwmpf == null)
		{
			LHxMLVBovshqugRIEIqgOtnnwmpf = new WDfkTImFSaQkAopFgARJAIdQhUmX("RewiredWDMWindow", true, gqvgmbNczJmMhrOsfophRlLUjBFj);
			if (LHxMLVBovshqugRIEIqgOtnnwmpf.DQlnccYfKAebOztsUYLkEkvPUtWj == IntPtr.Zero)
			{
				throw new Exception("Error creating window.");
			}
		}
		else
		{
			if (LHxMLVBovshqugRIEIqgOtnnwmpf.DQlnccYfKAebOztsUYLkEkvPUtWj == IntPtr.Zero)
			{
				throw new Exception("Message window has invalid handle.");
			}
			LHxMLVBovshqugRIEIqgOtnnwmpf.TcqMxAUbmFShOljlGRKsuKytqAdr(gqvgmbNczJmMhrOsfophRlLUjBFj);
		}
		fBGClyhtgGggZqmytdNXoVDWzcgH = LHxMLVBovshqugRIEIqgOtnnwmpf.DQlnccYfKAebOztsUYLkEkvPUtWj;
	}

	private IntPtr gqvgmbNczJmMhrOsfophRlLUjBFj(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		XEygvRMRqnJAgXTPgOIYYgshfKYU(HcRBSzHiTzbGMALvAEsXZexPXEBZ.hWZgqaHVSypUmdJEsvIjORzlXnweA(P_3), oymhsAPIfMyZRMQaeDTCWtiWVvgh.ImXPaiHLtatbwmhHshHWSHnnThoF(P_2), P_1, P_0);
		return IntPtr.Zero;
	}
}
