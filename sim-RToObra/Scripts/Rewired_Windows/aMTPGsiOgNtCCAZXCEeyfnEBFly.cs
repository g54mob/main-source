using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class aMTPGsiOgNtCCAZXCEeyfnEBFly : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr UeJcUrHaslBFNMPXXfJQGjDFhNCf(int nCode, IntPtr wParam, IntPtr lParam);

	private struct MuwAJxcvqsbDzJZGeKBydKhVXoCf
	{
		public IntPtr MQWeENqvtNMNLLFMbVKTMPmajTXd;

		public IntPtr NcDAXOCbGSHUqlmtjNwcOalYmrK;

		public uint DKBIdXlTyRDcGCIUnUrvKThimOL;

		public IntPtr vMlcIgIvcwKRUFtpiaRaoYRcAjU;
	}

	private const int EeSNjSeRNiAilbuOZspcwjAOVli = 4;

	private static aMTPGsiOgNtCCAZXCEeyfnEBFly mQCxsBeEhFVCUhOYlAzPetKjySt;

	private IntPtr KbtdsRWEOTnttqnQACTgBnNkOBUB = IntPtr.Zero;

	private UeJcUrHaslBFNMPXXfJQGjDFhNCf FshAathsoYmsmNJEDAszwEbUHBWA;

	private Action<jLFEcVyWEgJATAvbnSKLbjtayCE, WaaxNiwDiJyoSDhaNWpIFQyxNxt, uint, IntPtr> dbvqhTEvKcUotwRODBfQBDIrhdha;

	private byte[] wbrWdUtODnpIUFDhlwdLExyFoen;

	private readonly bool LYsVNLhRiifOKHqsgjYAquxHdMr;

	private MuwAJxcvqsbDzJZGeKBydKhVXoCf kfzZrzwKawEjUeOMLWgHLZgIFdB;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public aMTPGsiOgNtCCAZXCEeyfnEBFly()
	{
		if (mQCxsBeEhFVCUhOYlAzPetKjySt != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		mQCxsBeEhFVCUhOYlAzPetKjySt = this;
		LYsVNLhRiifOKHqsgjYAquxHdMr = IntPtr.Size == 8;
		wbrWdUtODnpIUFDhlwdLExyFoen = new byte[IntPtr.Size * 3 + 4];
	}

	public void udkMCiMROhAJufzBMnlEZscMcyE(Action<jLFEcVyWEgJATAvbnSKLbjtayCE, WaaxNiwDiJyoSDhaNWpIFQyxNxt, uint, IntPtr> P_0, bool P_1)
	{
		dbvqhTEvKcUotwRODBfQBDIrhdha = P_0;
		FshAathsoYmsmNJEDAszwEbUHBWA = juEkFkQHYIAhAMKOuGJqFOAxPuxp;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
			goto IL_0024;
		}
		goto IL_0046;
		IL_0046:
		KbtdsRWEOTnttqnQACTgBnNkOBUB = VZjhWrKosBUHwszjuxSJpQTsKvh(4, FshAathsoYmsmNJEDAszwEbUHBWA, IntPtr.Zero, num);
		int num2 = -779149206;
		goto IL_0029;
		IL_0024:
		num2 = -779149205;
		goto IL_0029;
		IL_0029:
		while (true)
		{
			switch (num2 ^ -779149206)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0046;
			case 0:
				if (KbtdsRWEOTnttqnQACTgBnNkOBUB == IntPtr.Zero)
				{
					Logger.LogError("SetWindowsHookEx Failed");
					num2 = -779149207;
					continue;
				}
				return;
			case 3:
				return;
			}
			break;
		}
		goto IL_0024;
	}

	public void zphONIGhZdWSWuYBmNkAtbyYGiB()
	{
		if (KbtdsRWEOTnttqnQACTgBnNkOBUB == IntPtr.Zero)
		{
			return;
		}
		while (true)
		{
			bool flag = UgALUUovBaPkVfUQjyRWneURLRi(KbtdsRWEOTnttqnQACTgBnNkOBUB);
			int num = 1450018090;
			while (true)
			{
				switch (num ^ 0x566D852B)
				{
				case 0:
					goto IL_0013;
				case 2:
					break;
				case 1:
					if (!flag)
					{
						Logger.LogError("UnhookWindowsHookEx Failed");
						return;
					}
					goto default;
				default:
					KbtdsRWEOTnttqnQACTgBnNkOBUB = IntPtr.Zero;
					return;
				}
				break;
				IL_0013:
				num = 1450018089;
			}
		}
	}

	[MonoPInvokeCallback(typeof(UeJcUrHaslBFNMPXXfJQGjDFhNCf))]
	private static IntPtr juEkFkQHYIAhAMKOuGJqFOAxPuxp(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, 0, mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen.Length);
		int num2 = default(int);
		while (true)
		{
			int num = 1684309448;
			while (true)
			{
				switch (num ^ 0x646485CB)
				{
				case 7:
					break;
				case 3:
					num2 = 0;
					num = 1684309451;
					continue;
				case 1:
					num2 += jLFEcVyWEgJATAvbnSKLbjtayCE.lqTmJvWoCjJVTvmDeCmOJTAiWOQ;
					mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.NcDAXOCbGSHUqlmtjNwcOalYmrK = WaaxNiwDiJyoSDhaNWpIFQyxNxt.HNLDkkXWZHkaKqwPVcaROpYlMtv(mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, num2);
					num2 += WaaxNiwDiJyoSDhaNWpIFQyxNxt.lqTmJvWoCjJVTvmDeCmOJTAiWOQ;
					mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.DKBIdXlTyRDcGCIUnUrvKThimOL = BitConverter.ToUInt32(mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, num2);
					num2 += 4;
					if (mQCxsBeEhFVCUhOYlAzPetKjySt.LYsVNLhRiifOKHqsgjYAquxHdMr)
					{
						mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.vMlcIgIvcwKRUFtpiaRaoYRcAjU = new IntPtr(BitConverter.ToInt32(mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, num2 + 4));
						num = 1684309455;
						continue;
					}
					goto case 6;
				case 4:
					num = 1684309454;
					continue;
				case 0:
					mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.MQWeENqvtNMNLLFMbVKTMPmajTXd = jLFEcVyWEgJATAvbnSKLbjtayCE.HNLDkkXWZHkaKqwPVcaROpYlMtv(mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, num2);
					num = 1684309450;
					continue;
				case 6:
					mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.vMlcIgIvcwKRUFtpiaRaoYRcAjU = new IntPtr(BitConverter.ToInt32(mQCxsBeEhFVCUhOYlAzPetKjySt.wbrWdUtODnpIUFDhlwdLExyFoen, num2));
					num = 1684309454;
					continue;
				case 5:
					if (P_0 >= 0)
					{
						mQCxsBeEhFVCUhOYlAzPetKjySt.dbvqhTEvKcUotwRODBfQBDIrhdha(mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.MQWeENqvtNMNLLFMbVKTMPmajTXd, mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.NcDAXOCbGSHUqlmtjNwcOalYmrK, mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.DKBIdXlTyRDcGCIUnUrvKThimOL, mQCxsBeEhFVCUhOYlAzPetKjySt.kfzZrzwKawEjUeOMLWgHLZgIFdB.vMlcIgIvcwKRUFtpiaRaoYRcAjU);
						num = 1684309449;
						continue;
					}
					goto default;
				default:
					return ncvhIucIdjEFxuoYawQqPmegBLH(mQCxsBeEhFVCUhOYlAzPetKjySt.KbtdsRWEOTnttqnQACTgBnNkOBUB, P_0, P_1, P_2);
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~aMTPGsiOgNtCCAZXCEeyfnEBFly()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		while (true)
		{
			zphONIGhZdWSWuYBmNkAtbyYGiB();
			if (mQCxsBeEhFVCUhOYlAzPetKjySt != this)
			{
				break;
			}
			mQCxsBeEhFVCUhOYlAzPetKjySt = null;
			int num = 340202970;
			while (true)
			{
				switch (num ^ 0x144715D8)
				{
				case 0:
					num = 340202969;
					continue;
				case 1:
					break;
				default:
					goto end_IL_0027;
				}
				break;
			}
			continue;
			end_IL_0027:
			break;
		}
		nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr VZjhWrKosBUHwszjuxSJpQTsKvh(int P_0, UeJcUrHaslBFNMPXXfJQGjDFhNCf P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool UgALUUovBaPkVfUQjyRWneURLRi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr ncvhIucIdjEFxuoYawQqPmegBLH(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
