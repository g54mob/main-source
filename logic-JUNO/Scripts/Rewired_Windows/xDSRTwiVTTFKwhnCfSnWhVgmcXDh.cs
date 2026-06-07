using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class xDSRTwiVTTFKwhnCfSnWhVgmcXDh
{
	public unsafe static int hLMxzXJOhtjIgyyCsDjwTmRHtAMm(int P_0, int P_1, out yOwUowVWqSppeHNQmGssqykLKaoS P_2)
	{
		if (NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR >= PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_4)
		{
			P_2 = default(yOwUowVWqSppeHNQmGssqykLKaoS);
			return 0;
		}
		P_2 = default(yOwUowVWqSppeHNQmGssqykLKaoS);
		int result;
		fixed (yOwUowVWqSppeHNQmGssqykLKaoS* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = MiZMAxwcVqLPnzJomzFZdtEInllK(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int MiZMAxwcVqLPnzJomzFZdtEInllK(int P_0, int P_1, void* P_2)
	{
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => nrWFkAuIoXPfUYdfMWMKDHSyWRyD(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => VnOeCCRQZlstveHEiYcgIKqCwOYr(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => cweEGbtYmYXedJfDQwBVBNNSJaiD(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => ZCUQwNUDFbsRzulvFXGHjDrhWtjX(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZCUQwNUDFbsRzulvFXGHjDrhWtjX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cweEGbtYmYXedJfDQwBVBNNSJaiD(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VnOeCCRQZlstveHEiYcgIKqCwOYr(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nrWFkAuIoXPfUYdfMWMKDHSyWRyD(int P_0, int P_1, void* P_2);

	public unsafe static int tUxZTxyQrAbIPqSUppsJjwARkDUc(int P_0, VgOyTCkBfUisISRqngkvhzxaTaRIA P_1)
	{
		return GXBpglgObafeYgwzVzvFCLSJISFp(P_0, &P_1);
	}

	private unsafe static int GXBpglgObafeYgwzVzvFCLSJISFp(int P_0, void* P_1)
	{
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_4 => VQaekgZOcRliAPlxVxYPGebYDgNj(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => pEzEWdhxnSAmOnpjyIcSfccGjhkgA(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => yoyhlAmfhaOGyxKWTWyckDRtRpHS(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => NsVhtItCHbwWabAqoJUYsoKCLDKw(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => DOqmHbjskPqAeFEfqHgCjduzkeQA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DOqmHbjskPqAeFEfqHgCjduzkeQA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NsVhtItCHbwWabAqoJUYsoKCLDKw(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yoyhlAmfhaOGyxKWTWyckDRtRpHS(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pEzEWdhxnSAmOnpjyIcSfccGjhkgA(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VQaekgZOcRliAPlxVxYPGebYDgNj(int P_0, void* P_1);

	public unsafe static int RvcPWSQJCeiCvpFrnFooyRhsjNOeA(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (Guid* ptr = &P_1)
		{
			void* ptr2 = ptr;
			fixed (Guid* ptr3 = &P_2)
			{
				void* ptr4 = ptr3;
				result = hNtXxlGZatimNFdijUyGumeZJSBw(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int hNtXxlGZatimNFdijUyGumeZJSBw(int P_0, void* P_1, void* P_2)
	{
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => EeUnmaAzLBZFPrqxXOIvXDbyKmsF(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => mUwBVEITkbRiDGmXNdZXCyhIqqnkA(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => YHnHRXdojRPIJMywhVEdEnQwhtgg(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => RtFFVjotTrGzlUZJtJNaMpLPueE(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RtFFVjotTrGzlUZJtJNaMpLPueE(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YHnHRXdojRPIJMywhVEdEnQwhtgg(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mUwBVEITkbRiDGmXNdZXCyhIqqnkA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EeUnmaAzLBZFPrqxXOIvXDbyKmsF(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int VzqONQQLYRBmbZiEAOzBfrNgcmRO(int P_0, out EFuZxUthyxEKBIgUnCFZfCcqupNqA P_1)
	{
		P_1 = default(EFuZxUthyxEKBIgUnCFZfCcqupNqA);
		int result;
		fixed (EFuZxUthyxEKBIgUnCFZfCcqupNqA* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = kKNfAiWhquyvCotRiJECZBmpXVvd(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int kKNfAiWhquyvCotRiJECZBmpXVvd(int P_0, void* P_1)
	{
		if (NKhLafDUxKEtAzgKmqVtfOxhlfXd.HYgfAbclpSaOuNhIVDlNTffIYSkc && NKhLafDUxKEtAzgKmqVtfOxhlfXd.FEgobmKvJFCzXUzRJpTjFYBsjcjB != null)
		{
			return NKhLafDUxKEtAzgKmqVtfOxhlfXd.FEgobmKvJFCzXUzRJpTjFYBsjcjB(P_0, P_1);
		}
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_4 => MlvxqatiiGpaKlOzsBscicYaRDwAA(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => cTfKQFstHsXMleGDHcBqAEWusTZe(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => IrdvNPXxPhDkgrNvZSGSOPMtOPwb(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => YthKqdLCbJDasFMPIPKuSSAGExfr(P_0, P_1), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => eAzFRUKdbDdNUsPCfLYycGSgWCXkb(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int eAzFRUKdbDdNUsPCfLYycGSgWCXkb(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YthKqdLCbJDasFMPIPKuSSAGExfr(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IrdvNPXxPhDkgrNvZSGSOPMtOPwb(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cTfKQFstHsXMleGDHcBqAEWusTZe(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MlvxqatiiGpaKlOzsBscicYaRDwAA(int P_0, void* P_1);

	public unsafe static int ZevvdVBgupmLCPnpUymAMOeniWK(int P_0, kwsWRBKxVgkhqFFDlrNAqajbFDTBA P_1, out ZPZgVGbxrAyXJFtcFqZXyNlZexJX P_2)
	{
		P_2 = default(ZPZgVGbxrAyXJFtcFqZXyNlZexJX);
		int result;
		fixed (ZPZgVGbxrAyXJFtcFqZXyNlZexJX* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = pTaEgGTmbqPzZpDOEWbleIcbgAsEA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int pTaEgGTmbqPzZpDOEWbleIcbgAsEA(int P_0, int P_1, void* P_2)
	{
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_4 => YtJluRTXhKLRkYSjTSnzWQZUFqjR(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => gMLzdbnlZBppxIMmfvGtDpwyDNJU(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => jjXhTJcXiQgAyOXVNePzJwZueJNI(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => xNGkCBOiBYkXXntsWtPQixvudzGf(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => MHvXvdkjScLVEnpXcPSsLkYYIOYR(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MHvXvdkjScLVEnpXcPSsLkYYIOYR(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xNGkCBOiBYkXXntsWtPQixvudzGf(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jjXhTJcXiQgAyOXVNePzJwZueJNI(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gMLzdbnlZBppxIMmfvGtDpwyDNJU(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YtJluRTXhKLRkYSjTSnzWQZUFqjR(int P_0, int P_1, void* P_2);

	public unsafe static int MLgptDGxZqUSNpSaZHetWExcCLvU(int P_0, ByUlWXCDuagXCFjFftRHWvOjvzaMA P_1, out IiWwvpmSiuQrDuoAZtKobzRfjBye P_2)
	{
		P_2 = default(IiWwvpmSiuQrDuoAZtKobzRfjBye);
		int result;
		fixed (IiWwvpmSiuQrDuoAZtKobzRfjBye* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = ARJLHKHGftFhSABRTRmmVQiPeveWA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int ARJLHKHGftFhSABRTRmmVQiPeveWA(int P_0, int P_1, void* P_2)
	{
		return NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR switch
		{
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3 => RbmCuWHKsulkvZjAdIAEwoOMhgwR(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2 => xxJeJoUfNPJbhzdBYmRFyMYzUboc(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1 => aVKNAqWgUIEatFiIccGWGZFAjVccB(P_0, P_1, P_2), 
			PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0 => THVrFDrJkMxpQdiCNQsvJIwCZxnN(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int THVrFDrJkMxpQdiCNQsvJIwCZxnN(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aVKNAqWgUIEatFiIccGWGZFAjVccB(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xxJeJoUfNPJbhzdBYmRFyMYzUboc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RbmCuWHKsulkvZjAdIAEwoOMhgwR(int P_0, int P_1, void* P_2);

	public static void VWEEmlFZPpPVWNgpIFhtcwSufltI(ppRQyWnmulBELSJBkakjdHwFfqEn P_0)
	{
		mhobyxSfDSIQmBlxmzfnKmuCOCvc(P_0);
	}

	private static void mhobyxSfDSIQmBlxmzfnKmuCOCvc(ppRQyWnmulBELSJBkakjdHwFfqEn P_0)
	{
		switch (NKhLafDUxKEtAzgKmqVtfOxhlfXd.xGOoWPTzsTiXMEaphleLvDzNwRaR)
		{
		case PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3:
			HrSVgRAJNxdzFwlMycKZDIHZcDCjA(P_0);
			break;
		case PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_2:
			VjqqvGdgKXHdQuqyqTfGzBOsizmn(P_0);
			break;
		case PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_1:
			WHTTMeiyMJkKswATMtSaJEddtAhT(P_0);
			break;
		case PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_9_1_0:
			KQZfcyYSFqCWhBbyhnDmNURgoBZcA(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void KQZfcyYSFqCWhBbyhnDmNURgoBZcA(ppRQyWnmulBELSJBkakjdHwFfqEn P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void WHTTMeiyMJkKswATMtSaJEddtAhT(ppRQyWnmulBELSJBkakjdHwFfqEn P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void VjqqvGdgKXHdQuqyqTfGzBOsizmn(ppRQyWnmulBELSJBkakjdHwFfqEn P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void HrSVgRAJNxdzFwlMycKZDIHZcDCjA(ppRQyWnmulBELSJBkakjdHwFfqEn P_0);
}
