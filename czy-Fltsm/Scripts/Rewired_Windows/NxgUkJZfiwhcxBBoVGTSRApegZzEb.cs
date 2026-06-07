using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class NxgUkJZfiwhcxBBoVGTSRApegZzEb
{
	public unsafe static int ZguEYaEaWSxCdrCyEqWmdkGNOOyiA(int P_0, int P_1, out OiQXLBoBXpKnrdXkUzpcThdHXWMi P_2)
	{
		if (fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA >= hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_4)
		{
			P_2 = default(OiQXLBoBXpKnrdXkUzpcThdHXWMi);
			return 0;
		}
		P_2 = default(OiQXLBoBXpKnrdXkUzpcThdHXWMi);
		int result;
		fixed (OiQXLBoBXpKnrdXkUzpcThdHXWMi* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = agzfvGDYgPPciZAKGPsRWITKFONv(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int agzfvGDYgPPciZAKGPsRWITKFONv(int P_0, int P_1, void* P_2)
	{
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => XBoHexVHjwFcRgiTcdJAwkWkvlIU(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => xVkrWlmobMQCsMAsUfXijrlQlucJ(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => ECMUvnMJpnHoxndFgpbFuTQSwwYU(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => hiwTHshkxIcQkIXlrLFJIakvUVTi(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hiwTHshkxIcQkIXlrLFJIakvUVTi(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ECMUvnMJpnHoxndFgpbFuTQSwwYU(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xVkrWlmobMQCsMAsUfXijrlQlucJ(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XBoHexVHjwFcRgiTcdJAwkWkvlIU(int P_0, int P_1, void* P_2);

	public unsafe static int LDVtoiPKrdIATGnyNgemSCrTTNlP(int P_0, xMedudRCKhsTLkKCDLrxSkmiOLrV P_1)
	{
		return qwhPKvDKzLXDdGRTdcXlrRCZlnkB(P_0, &P_1);
	}

	private unsafe static int qwhPKvDKzLXDdGRTdcXlrRCZlnkB(int P_0, void* P_1)
	{
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_4 => pxIgZNBkVcGITthZvAyBAhsgSwlIB(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => DENfzISEppFfTNJOYbgYCahECzIJ(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => GJMInpDMEBhylLqIrhyuFSfnEPzd(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => dZbZAxYXaUqVjJLOCFxUPZZKyEqJ(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => vaunPoOELRGTVtukRaGkECicEFAWA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vaunPoOELRGTVtukRaGkECicEFAWA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dZbZAxYXaUqVjJLOCFxUPZZKyEqJ(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int GJMInpDMEBhylLqIrhyuFSfnEPzd(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DENfzISEppFfTNJOYbgYCahECzIJ(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pxIgZNBkVcGITthZvAyBAhsgSwlIB(int P_0, void* P_1);

	public unsafe static int vtQbCxtzlNzGgVTFVbquLeTsePke(int P_0, out Guid P_1, out Guid P_2)
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
				result = ZaBDQKfYPKTNCpRQZZzKNDdLgfpT(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int ZaBDQKfYPKTNCpRQZZzKNDdLgfpT(int P_0, void* P_1, void* P_2)
	{
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => qisUYZlhqomaAFgHpjLjecwoWdQrA(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => ASYWwnlUJUkREohdrrQBHXoCGVTR(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => gjNAgaEUCebwAogWFmQfezHcoECcB(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => lHPNceSkRaRKmDGajcaVGDXZOyUDA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lHPNceSkRaRKmDGajcaVGDXZOyUDA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gjNAgaEUCebwAogWFmQfezHcoECcB(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ASYWwnlUJUkREohdrrQBHXoCGVTR(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qisUYZlhqomaAFgHpjLjecwoWdQrA(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int lAOkMdltdoZlitaOusPZOCbeTvvE(int P_0, out uGSAOvAjRCveMsCgFFKXrVlihUjy P_1)
	{
		P_1 = default(uGSAOvAjRCveMsCgFFKXrVlihUjy);
		int result;
		fixed (uGSAOvAjRCveMsCgFFKXrVlihUjy* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = CFtrYDhHCNtRJUJJGFCKCeUbsgFaA(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int CFtrYDhHCNtRJUJJGFCKCeUbsgFaA(int P_0, void* P_1)
	{
		if (fFZryUsdljdnPVeYUEptcGRleKhgb.zlMsUzBiCljRTbxVvHGnsKgQVjaX && fFZryUsdljdnPVeYUEptcGRleKhgb.rdqORUfMCesfgeVLxpuLuwFilESq != null)
		{
			return fFZryUsdljdnPVeYUEptcGRleKhgb.rdqORUfMCesfgeVLxpuLuwFilESq(P_0, P_1);
		}
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_4 => wRNCTBAkVhAZBXEBUsvoFFZuDsIbA(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => EOxMxvFAWTraZSAcxObcllTueXfu(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => cXRRGcgxWUbmfXzlbjROdqMfFrrQ(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => aeTVdSuKCwLZvjShuPVqnHZAbCVm(P_0, P_1), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => GbHiHlQhEoJiNpLgHqZgfSXIpfrS(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int GbHiHlQhEoJiNpLgHqZgfSXIpfrS(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aeTVdSuKCwLZvjShuPVqnHZAbCVm(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cXRRGcgxWUbmfXzlbjROdqMfFrrQ(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EOxMxvFAWTraZSAcxObcllTueXfu(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wRNCTBAkVhAZBXEBUsvoFFZuDsIbA(int P_0, void* P_1);

	public unsafe static int tlIoEWmjHLlGQcKVDCHglEHkgOoJA(int P_0, YVCcwitYsBdSvvMxHdOQeNajSotYA P_1, out hdvoYbCLQdebKTTSvQwTBcsTYXti P_2)
	{
		P_2 = default(hdvoYbCLQdebKTTSvQwTBcsTYXti);
		int result;
		fixed (hdvoYbCLQdebKTTSvQwTBcsTYXti* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = RaWNGnycOPAQKNfqgiofXItvfEWK(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int RaWNGnycOPAQKNfqgiofXItvfEWK(int P_0, int P_1, void* P_2)
	{
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_4 => wAdNgycCOzavpkXjzebvnEsIVFRB(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => YbjcAAKkakzYewkQDARzkNzeHajX(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => VjdUYgLiVpuDfcXnfhUvuEYyHTpx(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => FleeZubpmzuNUXNEqZiIJKqcbOeO(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => oqZdWKNklXbsFVuhEgDimaZCzjuX(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oqZdWKNklXbsFVuhEgDimaZCzjuX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FleeZubpmzuNUXNEqZiIJKqcbOeO(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VjdUYgLiVpuDfcXnfhUvuEYyHTpx(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YbjcAAKkakzYewkQDARzkNzeHajX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wAdNgycCOzavpkXjzebvnEsIVFRB(int P_0, int P_1, void* P_2);

	public unsafe static int eKSaMsAzuVabGILKhbUbrfqgguLsb(int P_0, raDxmdvZXpkHMRdNiOTEELcrYSvB P_1, out egofHUVjzFcpASVYpGuuiCgrXKYbA P_2)
	{
		P_2 = default(egofHUVjzFcpASVYpGuuiCgrXKYbA);
		int result;
		fixed (egofHUVjzFcpASVYpGuuiCgrXKYbA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = afjarZaKSqYZdhbIljmSjtcFMOlB(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int afjarZaKSqYZdhbIljmSjtcFMOlB(int P_0, int P_1, void* P_2)
	{
		return fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA switch
		{
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3 => tLUxXxsmLVBDkbywHKXGDPNGDJAo(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2 => PwloZFpvOuSkcBvNeQpHBoRdbbDIA(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1 => ETwhELlhvtDdsOqiQHwScKspuHID(P_0, P_1, P_2), 
			hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0 => bnloswEVXxOTWHgfljpdcrAEWeBD(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bnloswEVXxOTWHgfljpdcrAEWeBD(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ETwhELlhvtDdsOqiQHwScKspuHID(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int PwloZFpvOuSkcBvNeQpHBoRdbbDIA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tLUxXxsmLVBDkbywHKXGDPNGDJAo(int P_0, int P_1, void* P_2);

	public static void rQkSrIikuULgZjcRcnIvBrBoKSLP(HcjebfGWBEygWckvSivzbOnNcDqbb P_0)
	{
		AhWEQKjLAhcjxItBCLqjWfvYGpwlA(P_0);
	}

	private static void AhWEQKjLAhcjxItBCLqjWfvYGpwlA(HcjebfGWBEygWckvSivzbOnNcDqbb P_0)
	{
		switch (fFZryUsdljdnPVeYUEptcGRleKhgb.VoMnmtiVicyTswJRVxHDQwBweIKA)
		{
		case hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3:
			rJgVPwtWyKOPGOeoUNMNsqWRebmL(P_0);
			break;
		case hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_2:
			jjIULzYczyTKHWEWAhOUcUFyBMSOA(P_0);
			break;
		case hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_1:
			gKvzSNPztotRpOThgZpyqbidjoTJ(P_0);
			break;
		case hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_9_1_0:
			ubvZdPnzgZtgkVBWTdCidTKmLmpP(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ubvZdPnzgZtgkVBWTdCidTKmLmpP(HcjebfGWBEygWckvSivzbOnNcDqbb P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void gKvzSNPztotRpOThgZpyqbidjoTJ(HcjebfGWBEygWckvSivzbOnNcDqbb P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void jjIULzYczyTKHWEWAhOUcUFyBMSOA(HcjebfGWBEygWckvSivzbOnNcDqbb P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void rJgVPwtWyKOPGOeoUNMNsqWRebmL(HcjebfGWBEygWckvSivzbOnNcDqbb P_0);
}
