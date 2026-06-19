using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class rweKSFuPTfgxliyJDpBvxBqSeDe
{
	public unsafe static int GJFxJKoLPoFjhxsAzHFlOcZQrtn(int P_0, int P_1, out iJOidXVPckAQlCWqKYNBmzZljcN P_2)
	{
		if (ROXKDWXUKcvkJkBQYHFAjebHFlk.version >= RLPLEmaTbAdCzEBENlKjSljwIxd.FyIWvzDdxecpozmsDSlrLnqhsxU)
		{
			P_2 = default(iJOidXVPckAQlCWqKYNBmzZljcN);
			return 0;
		}
		P_2 = default(iJOidXVPckAQlCWqKYNBmzZljcN);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<iJOidXVPckAQlCWqKYNBmzZljcN, IntPtr>(ref P_2))
		{
			result = FwFTuYkkIVIIvKALvCOOxOlFdHJs(P_0, P_1, ptr);
		}
		return result;
	}

	private unsafe static int FwFTuYkkIVIIvKALvCOOxOlFdHJs(int P_0, int P_1, void* P_2)
	{
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => ceaJBOVOUBdrIudIwdQAJbFNltUT(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => MKfyNuJpRZNoTPVYIErwgWExdDo(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => pxgGnHXTZmbEbDssGHbDEFTpfgZi(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => QwbfknHsdDDuBEizCemarpkBBDWc(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QwbfknHsdDDuBEizCemarpkBBDWc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pxgGnHXTZmbEbDssGHbDEFTpfgZi(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MKfyNuJpRZNoTPVYIErwgWExdDo(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ceaJBOVOUBdrIudIwdQAJbFNltUT(int P_0, int P_1, void* P_2);

	public unsafe static int jtWzeBdEhktIDKwiJZEyUEtKMjq(int P_0, DFsJAhmwnmSRJJkYRXwEfgOEkaa P_1)
	{
		return plmUsXJcwzyieljWJHXqlErqPrJ(P_0, &P_1);
	}

	private unsafe static int plmUsXJcwzyieljWJHXqlErqPrJ(int P_0, void* P_1)
	{
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.FyIWvzDdxecpozmsDSlrLnqhsxU => RBEBoJNmFIjslHcGBcjnvQAXbftV(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => yASLPvBpNiCdJKqYqggLjMOEdkPz(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => fVAZpYTxAAdTdqJgZjPRZqoMQkh(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => hzvoLRlPMpmHtlyERXEVvtUEYKT(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => aAuWKqjVtaYNpxFhMNmkDCfaZZE(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aAuWKqjVtaYNpxFhMNmkDCfaZZE(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hzvoLRlPMpmHtlyERXEVvtUEYKT(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int fVAZpYTxAAdTdqJgZjPRZqoMQkh(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yASLPvBpNiCdJKqYqggLjMOEdkPz(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RBEBoJNmFIjslHcGBcjnvQAXbftV(int P_0, void* P_1);

	public unsafe static int TaBfHLgmTAPpFqyOKLaXiRlDZkR(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_1))
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_2))
			{
				result = OKPzWeXVwPRmCqmfxrsPTEflxUF(P_0, ptr, ptr2);
			}
		}
		return result;
	}

	private unsafe static int OKPzWeXVwPRmCqmfxrsPTEflxUF(int P_0, void* P_1, void* P_2)
	{
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => vlFKlAUTdqpoMDQvmnRDCaZuzVh(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => InrKYrxWbtzWdWcUYeMFOdenQlU(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => DbJaYfXokmIDuhOBnYMFnJmZuMCQ(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => mBILBNwGnLALdgLLHcaGdUfEDub(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mBILBNwGnLALdgLLHcaGdUfEDub(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DbJaYfXokmIDuhOBnYMFnJmZuMCQ(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int InrKYrxWbtzWdWcUYeMFOdenQlU(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vlFKlAUTdqpoMDQvmnRDCaZuzVh(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int eduaqTIzybVxyojFtoyOdMDilUcW(int P_0, out ANInovfBkTqpKTBiXBwqFKXAGniM P_1)
	{
		P_1 = default(ANInovfBkTqpKTBiXBwqFKXAGniM);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref P_1))
		{
			result = bplVqQnVegywKfaccKQcpRDueLHb(P_0, ptr);
		}
		return result;
	}

	private unsafe static int bplVqQnVegywKfaccKQcpRDueLHb(int P_0, void* P_1)
	{
		if (ROXKDWXUKcvkJkBQYHFAjebHFlk.supportsGetStateEx && ROXKDWXUKcvkJkBQYHFAjebHFlk.getStateExDelegate != null)
		{
			return ROXKDWXUKcvkJkBQYHFAjebHFlk.getStateExDelegate(P_0, P_1);
		}
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.FyIWvzDdxecpozmsDSlrLnqhsxU => YjChoAgGmTwXbGyCixSwcAmpWTG(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => bybXhxutDINvUarwzCBFSbnseDA(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => mIRgPaMIjNhqQCMEJTghyiqucyMF(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => tHlGtpfvUibAwhFqVMCuWuNhJPf(P_0, P_1), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => hiJVVoHEupVIhOYAJdatYCKKkTY(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hiJVVoHEupVIhOYAJdatYCKKkTY(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tHlGtpfvUibAwhFqVMCuWuNhJPf(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mIRgPaMIjNhqQCMEJTghyiqucyMF(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bybXhxutDINvUarwzCBFSbnseDA(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YjChoAgGmTwXbGyCixSwcAmpWTG(int P_0, void* P_1);

	public unsafe static int ceVDAxsMKwXYXQRwChyddiJlHcZ(int P_0, gwSgCcGfNQxKhKgnLQsxicMPPRg P_1, out PrxqYxfCfoaUOqjCnEgiyLSbAjag P_2)
	{
		P_2 = default(PrxqYxfCfoaUOqjCnEgiyLSbAjag);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<PrxqYxfCfoaUOqjCnEgiyLSbAjag, IntPtr>(ref P_2))
		{
			result = tAAGBThhvALhSAVqKzksRKnuBrSQ(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int tAAGBThhvALhSAVqKzksRKnuBrSQ(int P_0, int P_1, void* P_2)
	{
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.FyIWvzDdxecpozmsDSlrLnqhsxU => gHLfEgHFDCNTfjXMWOdWnZKqEHq(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => RfEDPKfMsZYOzGQsqMbWpbirzZM(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => ljuewsujZXDQUgItTpdisZJiFnBs(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => VZcOsTeNUVBpLDUGqPorbjzEcZHy(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => tiBgMnhQXPOkEZYPiGNuthybNJAG(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tiBgMnhQXPOkEZYPiGNuthybNJAG(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VZcOsTeNUVBpLDUGqPorbjzEcZHy(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ljuewsujZXDQUgItTpdisZJiFnBs(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RfEDPKfMsZYOzGQsqMbWpbirzZM(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gHLfEgHFDCNTfjXMWOdWnZKqEHq(int P_0, int P_1, void* P_2);

	public unsafe static int mEJoPUxVAXZTorvynFAwYzTONIn(int P_0, VigeDkGSeGroZembgDwkuxbnNzPJ P_1, out OLyApKmKAGBtAjjMvWMTlHMLFpZ P_2)
	{
		P_2 = default(OLyApKmKAGBtAjjMvWMTlHMLFpZ);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<OLyApKmKAGBtAjjMvWMTlHMLFpZ, IntPtr>(ref P_2))
		{
			result = kTYcuiSgCWzuNvHeYdkOdsqXoNzF(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int kTYcuiSgCWzuNvHeYdkOdsqXoNzF(int P_0, int P_1, void* P_2)
	{
		return ROXKDWXUKcvkJkBQYHFAjebHFlk.version switch
		{
			RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH => JRpxswfJdQBbGnkMRVbuVOepKkt(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX => LOZoKlWKlBIojCbhbJwAYVgGKXuK(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN => obVLSgnhBnORPKGDvSnGtREpnMN(P_0, P_1, P_2), 
			RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP => dwymhTyZPuEWPubCwDnyACUGswbu(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dwymhTyZPuEWPubCwDnyACUGswbu(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int obVLSgnhBnORPKGDvSnGtREpnMN(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LOZoKlWKlBIojCbhbJwAYVgGKXuK(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JRpxswfJdQBbGnkMRVbuVOepKkt(int P_0, int P_1, void* P_2);

	public static void ldoCYvwPuVrXuQdlSWVmPzjQEKp(rlZVbCdeVmsWkNfGXJCirTzWorR P_0)
	{
		PnZjABPCetkRClhGOJMVXpxNzEJ(P_0);
	}

	private static void PnZjABPCetkRClhGOJMVXpxNzEJ(rlZVbCdeVmsWkNfGXJCirTzWorR P_0)
	{
		switch (ROXKDWXUKcvkJkBQYHFAjebHFlk.version)
		{
		case RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH:
			ZZaYgPdzhPTsFOJBvSUZFHNfhCc(P_0);
			break;
		case RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX:
			kXpdfLbVNRsFPOtQRhTajjglgDyG(P_0);
			break;
		case RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN:
			LuAKWWQqsgkuOpDDpqPgOlzKVCH(P_0);
			break;
		case RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP:
			XLucVkyJJeCnDQDNyUDYDsOmJWl(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void XLucVkyJJeCnDQDNyUDYDsOmJWl(rlZVbCdeVmsWkNfGXJCirTzWorR P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void LuAKWWQqsgkuOpDDpqPgOlzKVCH(rlZVbCdeVmsWkNfGXJCirTzWorR P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void kXpdfLbVNRsFPOtQRhTajjglgDyG(rlZVbCdeVmsWkNfGXJCirTzWorR P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ZZaYgPdzhPTsFOJBvSUZFHNfhCc(rlZVbCdeVmsWkNfGXJCirTzWorR P_0);
}
