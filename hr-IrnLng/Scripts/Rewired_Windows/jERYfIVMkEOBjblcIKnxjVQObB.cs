using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class jERYfIVMkEOBjblcIKnxjVQObB : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr QcngvNNbiGQnDVFawSYPMCjuHxk(int nCode, IntPtr wParam, IntPtr lParam);

	private struct AlSVuCgCLoydRaoOMbirKLyicpRi
	{
		public IntPtr NgVUMEIsJwFySgtmRFSEOUjrvWy;

		public IntPtr KlSEmHyoGhtCdUdNNLejGRcTfRr;

		public uint OgYWOvFEpokXqlkKDAosEyKjzgi;

		public IntPtr abaiDnqfJRAdBsCNACizfiXnYBtb;
	}

	private const int NLJRNgAvTrrorOixyalDgRJgMPg = 4;

	private static jERYfIVMkEOBjblcIKnxjVQObB vcPdtGGvPwkmRWvcNuQMsgPoctMc;

	private IntPtr BngitMecwaCrsFQiwZJlfiUxHEr = IntPtr.Zero;

	private QcngvNNbiGQnDVFawSYPMCjuHxk SxciOqFFWxPqxoKaniMiiWqNQLb;

	private Action<cMSvoEKriZNtMdzXJTSCtfipYFh, TSrfFdAmQuDNBoHUlddNXTpuyKU, uint, IntPtr> yzgFjAAwsThDqPRedJjBqTBgVaQ;

	private byte[] hWqEtHVvnCwvJmvTDepQAOtIpdO;

	private readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	private AlSVuCgCLoydRaoOMbirKLyicpRi lGqPXiMKiHlpaVdovIVrBQAZMNy;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public jERYfIVMkEOBjblcIKnxjVQObB()
	{
		if (vcPdtGGvPwkmRWvcNuQMsgPoctMc != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		vcPdtGGvPwkmRWvcNuQMsgPoctMc = this;
		GupIFSTVSLnhDwDGCsKLmLgUDLU = IntPtr.Size == 8;
		hWqEtHVvnCwvJmvTDepQAOtIpdO = new byte[IntPtr.Size * 3 + 4];
	}

	public void xvbxOrqVqOrazQGxyaxNVVjBbvnD(Action<cMSvoEKriZNtMdzXJTSCtfipYFh, TSrfFdAmQuDNBoHUlddNXTpuyKU, uint, IntPtr> P_0, bool P_1)
	{
		yzgFjAAwsThDqPRedJjBqTBgVaQ = P_0;
		SxciOqFFWxPqxoKaniMiiWqNQLb = ssFcfVqirtAJodeRKXfbAFMclMJ;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		BngitMecwaCrsFQiwZJlfiUxHEr = CRufyamCQuxfTZFAKxIvfOWlVUv(4, SxciOqFFWxPqxoKaniMiiWqNQLb, IntPtr.Zero, num);
		if (BngitMecwaCrsFQiwZJlfiUxHEr == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void geoIFBiFlApdDXXfKBCJdCpXhlk()
	{
		if (!(BngitMecwaCrsFQiwZJlfiUxHEr == IntPtr.Zero))
		{
			if (!HsLdGZfQdZtPOlWcLmwTQtHCyCVf(BngitMecwaCrsFQiwZJlfiUxHEr))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				BngitMecwaCrsFQiwZJlfiUxHEr = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(QcngvNNbiGQnDVFawSYPMCjuHxk))]
	private static IntPtr ssFcfVqirtAJodeRKXfbAFMclMJ(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, 0, vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO.Length);
		int num = 0;
		vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.NgVUMEIsJwFySgtmRFSEOUjrvWy = cMSvoEKriZNtMdzXJTSCtfipYFh.IFUvyfjjlmiTRXvpbkTSGARqaVO(vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, num);
		num += cMSvoEKriZNtMdzXJTSCtfipYFh.iiCeZsFqsCMgMBWpCvqNRTNxrPf;
		vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.KlSEmHyoGhtCdUdNNLejGRcTfRr = TSrfFdAmQuDNBoHUlddNXTpuyKU.IFUvyfjjlmiTRXvpbkTSGARqaVO(vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, num);
		num += TSrfFdAmQuDNBoHUlddNXTpuyKU.iiCeZsFqsCMgMBWpCvqNRTNxrPf;
		vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.OgYWOvFEpokXqlkKDAosEyKjzgi = BitConverter.ToUInt32(vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, num);
		num += 4;
		if (vcPdtGGvPwkmRWvcNuQMsgPoctMc.GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.abaiDnqfJRAdBsCNACizfiXnYBtb = new IntPtr(BitConverter.ToInt32(vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, num + 4));
		}
		else
		{
			vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.abaiDnqfJRAdBsCNACizfiXnYBtb = new IntPtr(BitConverter.ToInt32(vcPdtGGvPwkmRWvcNuQMsgPoctMc.hWqEtHVvnCwvJmvTDepQAOtIpdO, num));
		}
		if (P_0 >= 0)
		{
			vcPdtGGvPwkmRWvcNuQMsgPoctMc.yzgFjAAwsThDqPRedJjBqTBgVaQ(vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.NgVUMEIsJwFySgtmRFSEOUjrvWy, vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.KlSEmHyoGhtCdUdNNLejGRcTfRr, vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.OgYWOvFEpokXqlkKDAosEyKjzgi, vcPdtGGvPwkmRWvcNuQMsgPoctMc.lGqPXiMKiHlpaVdovIVrBQAZMNy.abaiDnqfJRAdBsCNACizfiXnYBtb);
		}
		return qPiuAbAaNEfkuHVmCJWtwXbdMIoW(vcPdtGGvPwkmRWvcNuQMsgPoctMc.BngitMecwaCrsFQiwZJlfiUxHEr, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~jERYfIVMkEOBjblcIKnxjVQObB()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			geoIFBiFlApdDXXfKBCJdCpXhlk();
			if (vcPdtGGvPwkmRWvcNuQMsgPoctMc == this)
			{
				vcPdtGGvPwkmRWvcNuQMsgPoctMc = null;
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr CRufyamCQuxfTZFAKxIvfOWlVUv(int P_0, QcngvNNbiGQnDVFawSYPMCjuHxk P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool HsLdGZfQdZtPOlWcLmwTQtHCyCVf(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr qPiuAbAaNEfkuHVmCJWtwXbdMIoW(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
