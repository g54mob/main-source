using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Rewired;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

internal class pBAEQqdrZrLYcuIUaQPJZJmsVktE
{
	private static readonly lSlbXeplzgAPRZhVTdmqFmIyesww wxNIMVPiXOmMREIUyCOtunGaDjZJ;

	private const uint LEGNWhbAtYXrEjwyQaPtCactBNcG = 8192u;

	private const uint nFLfIUuhJOajCrjVtSXRlQLdTOLq = 100u;

	private const uint sGqcAMGzCJOzFazPmgRDrvagCiIz = 8192u;

	private static IntPtr LwChEasbkznzHPlKEwUKLeYgJkcq;

	private static bool mbVSmkUoeuMGzdliPUvucYTcuSKe;

	private static IntPtr TOfSReuDOrdbpIDMicyIVzqppBsOA;

	private static bool hcJllQndGRvYDXlHdJYmbruUIPgy;

	private static readonly int RUsIgBGTdThVJMyqVsOXlnkSAiqiA;

	private static readonly int sFmDHdbrvwttmyDZBhveSoFQRaOO;

	private static readonly NativeBuffer uzveKGjDoWOOLEGohOgQXlMwocBXB;

	private static readonly bool YxcRqwOVshKVjcdaCaJUgZykGdQNA;

	private static readonly byte[] MibgvWehwKzIIOapvdhUSpGaAiqy;

	private static readonly uint[] VoAKyaSlxIFGcoNpGDvhkPJPBrjk;

	private static readonly uint[] eTTzzSCDvnGsYEnxEDrIftfbENtkb;

	private static readonly bool crEYwpaZJAdfPnOFQhfJCgvztKOsA;

	private static ForwardRawInputEventsToUnityDelegate yYGgtfAIkMvfcjSUUjwXEkyfFlgo;

	[CompilerGenerated]
	private static Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> m_pZeDMFIjdfjPRfdFAgCdKuhlPRrQ;

	[CompilerGenerated]
	private static Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> m_cmIjOmSnKieZjkypgoNXQNRJzQJq;

	[CompilerGenerated]
	private static Action<GDoemERPManoIlVObhuwkOFTJris, double> m_SkqInFsfXfSuloqmOgRBjRmNeDKi;

	[CompilerGenerated]
	private static Action<IntPtr> m_AJNExKnaBXFBOkZoIWhmrelMMjJTA;

	[CompilerGenerated]
	private static Action m_FiLZHDTlGVoWKYTAhoSQlRSTyUsL;

	public static ForwardRawInputEventsToUnityDelegate NqmleOYWMFZKCNCbmiBFWuomLpUA
	{
		get
		{
			return yYGgtfAIkMvfcjSUUjwXEkyfFlgo;
		}
		set
		{
			yYGgtfAIkMvfcjSUUjwXEkyfFlgo = forwardRawInputEventsToUnityDelegate;
		}
	}

	public static event Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> pZeDMFIjdfjPRfdFAgCdKuhlPRrQ
	{
		[CompilerGenerated]
		add
		{
			Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_pZeDMFIjdfjPRfdFAgCdKuhlPRrQ;
			Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> action2;
			do
			{
				action2 = action;
				Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> value2 = (Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_pZeDMFIjdfjPRfdFAgCdKuhlPRrQ, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_pZeDMFIjdfjPRfdFAgCdKuhlPRrQ;
			Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> action2;
			do
			{
				action2 = action;
				Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double> value2 = (Action<PYiFzEFMJxXAESEyjKCbCeULHHPzA, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_pZeDMFIjdfjPRfdFAgCdKuhlPRrQ, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> cmIjOmSnKieZjkypgoNXQNRJzQJq
	{
		[CompilerGenerated]
		add
		{
			Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_cmIjOmSnKieZjkypgoNXQNRJzQJq;
			Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> action2;
			do
			{
				action2 = action;
				Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> value2 = (Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_cmIjOmSnKieZjkypgoNXQNRJzQJq, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_cmIjOmSnKieZjkypgoNXQNRJzQJq;
			Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> action2;
			do
			{
				action2 = action;
				Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double> value2 = (Action<iqODoWfaaoUhjOzxtmuPOwzFSbyvA, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_cmIjOmSnKieZjkypgoNXQNRJzQJq, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<GDoemERPManoIlVObhuwkOFTJris, double> SkqInFsfXfSuloqmOgRBjRmNeDKi
	{
		[CompilerGenerated]
		add
		{
			Action<GDoemERPManoIlVObhuwkOFTJris, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_SkqInFsfXfSuloqmOgRBjRmNeDKi;
			Action<GDoemERPManoIlVObhuwkOFTJris, double> action2;
			do
			{
				action2 = action;
				Action<GDoemERPManoIlVObhuwkOFTJris, double> value2 = (Action<GDoemERPManoIlVObhuwkOFTJris, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_SkqInFsfXfSuloqmOgRBjRmNeDKi, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<GDoemERPManoIlVObhuwkOFTJris, double> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_SkqInFsfXfSuloqmOgRBjRmNeDKi;
			Action<GDoemERPManoIlVObhuwkOFTJris, double> action2;
			do
			{
				action2 = action;
				Action<GDoemERPManoIlVObhuwkOFTJris, double> value2 = (Action<GDoemERPManoIlVObhuwkOFTJris, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_SkqInFsfXfSuloqmOgRBjRmNeDKi, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<IntPtr> AJNExKnaBXFBOkZoIWhmrelMMjJTA
	{
		[CompilerGenerated]
		add
		{
			Action<IntPtr> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_AJNExKnaBXFBOkZoIWhmrelMMjJTA;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_AJNExKnaBXFBOkZoIWhmrelMMjJTA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<IntPtr> action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_AJNExKnaBXFBOkZoIWhmrelMMjJTA;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_AJNExKnaBXFBOkZoIWhmrelMMjJTA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action FiLZHDTlGVoWKYTAhoSQlRSTyUsL
	{
		[CompilerGenerated]
		add
		{
			Action action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_FiLZHDTlGVoWKYTAhoSQlRSTyUsL;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_FiLZHDTlGVoWKYTAhoSQlRSTyUsL, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_FiLZHDTlGVoWKYTAhoSQlRSTyUsL;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref pBAEQqdrZrLYcuIUaQPJZJmsVktE.m_FiLZHDTlGVoWKYTAhoSQlRSTyUsL, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	static pBAEQqdrZrLYcuIUaQPJZJmsVktE()
	{
		wxNIMVPiXOmMREIUyCOtunGaDjZJ = bbCyzPpSBHxELLJhfHqIKWHublayA;
		RUsIgBGTdThVJMyqVsOXlnkSAiqiA = qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<HDnhBREyWmXPeHmoTZzebZvcPyvf>();
		sFmDHdbrvwttmyDZBhveSoFQRaOO = qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<DuFTUcMolCBEEpnwVtOJkBhYtKpq>();
		YxcRqwOVshKVjcdaCaJUgZykGdQNA = UnityTools.windowsStandalone_supportsRawInputForwarding;
		if (YxcRqwOVshKVjcdaCaJUgZykGdQNA)
		{
			try
			{
				uzveKGjDoWOOLEGohOgQXlMwocBXB = new NativeBuffer(8192);
				MibgvWehwKzIIOapvdhUSpGaAiqy = new byte[8192];
				VoAKyaSlxIFGcoNpGDvhkPJPBrjk = new uint[100];
				eTTzzSCDvnGsYEnxEDrIftfbENtkb = new uint[100];
			}
			catch
			{
				YxcRqwOVshKVjcdaCaJUgZykGdQNA = false;
				Logger.LogError("Could not allocate memory for Raw Input buffer.", requiredThreadSafety: true);
			}
		}
		crEYwpaZJAdfPnOFQhfJCgvztKOsA = !SystemInfo.is64Bit && nxzMUSyCaMfSlEuvKxUcjBKIXFKl.UACaiNdWAAcBVoOSWHwhWdBXCKxg();
	}

	public static void gUVvTAnBsRwTMepvvQVVxjBZXfQc(IntPtr P_0, bool P_1)
	{
		mbVSmkUoeuMGzdliPUvucYTcuSKe = P_1;
		if (!(P_0 == IntPtr.Zero) && !(P_0 == LwChEasbkznzHPlKEwUKLeYgJkcq))
		{
			LwChEasbkznzHPlKEwUKLeYgJkcq = P_0;
			hcJllQndGRvYDXlHdJYmbruUIPgy = true;
		}
	}

	public static void QXAygGNJfUysOdMpMGUSvjTPwjRx(bool P_0)
	{
		mbVSmkUoeuMGzdliPUvucYTcuSKe = P_0;
	}

	public static lSlbXeplzgAPRZhVTdmqFmIyesww ZDMlrAKmVANqhMJwGOrYekqDcquk()
	{
		return wxNIMVPiXOmMREIUyCOtunGaDjZJ;
	}

	public unsafe static List<XMHZJfePGESHkVIigmcLsKHsgaRe> XglCxuhEeHOHNPhBEpaixSIvFGFH(bool P_0)
	{
		int num = 0;
		YqWtGThGEbqWgpbNLISqdhKKOeWtA.hNvdifvMuydvvzHlJFkaHRZkfOLib(null, ref num, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<vKvFfEaUEqcCLatCfsioGxOBRYwwB>());
		if (num == 0)
		{
			return null;
		}
		vKvFfEaUEqcCLatCfsioGxOBRYwwB[] array = new vKvFfEaUEqcCLatCfsioGxOBRYwwB[num];
		YqWtGThGEbqWgpbNLISqdhKKOeWtA.hNvdifvMuydvvzHlJFkaHRZkfOLib(array, ref num, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<vKvFfEaUEqcCLatCfsioGxOBRYwwB>());
		string[] array2 = new string[num];
		int num2 = 0;
		int num3 = 0;
		List<XMHZJfePGESHkVIigmcLsKHsgaRe> list = new List<XMHZJfePGESHkVIigmcLsKHsgaRe>();
		for (int i = 0; i < num; i++)
		{
			bool flag = false;
			IntPtr fnBHFWknxmPBXjxewaTbzVUbhOzC = array[i].fnBHFWknxmPBXjxewaTbzVUbhOzC;
			int num4 = 0;
			YqWtGThGEbqWgpbNLISqdhKKOeWtA.XlwDOxckXwHphGgfgIzKrHoBHnNgA(fnBHFWknxmPBXjxewaTbzVUbhOzC, ZHyvCoWKvlnvwNTkgaBjzQzrHSLu.DeviceName, IntPtr.Zero, ref num4);
			if (num4 == 0)
			{
				flag = true;
			}
			char* ptr = stackalloc char[num4];
			YqWtGThGEbqWgpbNLISqdhKKOeWtA.XlwDOxckXwHphGgfgIzKrHoBHnNgA(fnBHFWknxmPBXjxewaTbzVUbhOzC, ZHyvCoWKvlnvwNTkgaBjzQzrHSLu.DeviceName, (IntPtr)ptr, ref num4);
			int length = ((num4 > 0) ? (num4 - 1) : 0);
			string text = new string(ptr, 0, length);
			if (text.Length == 0)
			{
				text = string.Empty;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			int num5 = 0;
			for (int j = 0; j < bytes.Length; j++)
			{
				if (bytes[j] != 0)
				{
					num5++;
				}
			}
			if (num5 != bytes.Length)
			{
				if (num5 == 0)
				{
					text = string.Empty;
				}
				else
				{
					byte[] array3 = new byte[num5];
					int num6 = 0;
					for (int k = 0; k < bytes.Length; k++)
					{
						if (bytes[k] != 0)
						{
							array3[num6] = bytes[k];
							num6++;
						}
					}
					text = Encoding.UTF8.GetString(array3);
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (!string.IsNullOrEmpty(array2[l]) && string.Equals(array2[l], text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
			}
			array2[i] = text;
			int num7 = 0;
			YqWtGThGEbqWgpbNLISqdhKKOeWtA.XlwDOxckXwHphGgfgIzKrHoBHnNgA(fnBHFWknxmPBXjxewaTbzVUbhOzC, ZHyvCoWKvlnvwNTkgaBjzQzrHSLu.DeviceInfo, IntPtr.Zero, ref num7);
			if (num7 == 0)
			{
				if (flag)
				{
					num3++;
				}
				continue;
			}
			byte* ptr2 = stackalloc byte[(int)(uint)num7];
			*(int*)ptr2 = num7;
			if (YqWtGThGEbqWgpbNLISqdhKKOeWtA.XlwDOxckXwHphGgfgIzKrHoBHnNgA(fnBHFWknxmPBXjxewaTbzVUbhOzC, ZHyvCoWKvlnvwNTkgaBjzQzrHSLu.DeviceInfo, (IntPtr)ptr2, ref num7) >= 0)
			{
				try
				{
					TwUrBBvkazgsxFTKseLkWVvBAHgNA twUrBBvkazgsxFTKseLkWVvBAHgNA = *(TwUrBBvkazgsxFTKseLkWVvBAHgNA*)ptr2;
					XMHZJfePGESHkVIigmcLsKHsgaRe item = XMHZJfePGESHkVIigmcLsKHsgaRe.wEVFXfNdmgdjqHLPoNmGxOYZNaGHA(ref twUrBBvkazgsxFTKseLkWVvBAHgNA, text, fnBHFWknxmPBXjxewaTbzVUbhOzC);
					list.Add(item);
				}
				catch (Exception)
				{
					throw;
				}
				num2++;
			}
		}
		if (P_0 && num2 == 0 && num3 > 0)
		{
			throw new Exception("Possible sandbox detected.")
			{
				Data = { 
				{
					(object)1,
					(object)"sandbox"
				} }
			};
		}
		return list;
	}

	public static void yFmRDoKwQpkVavXMSGGrHVBdcwal(LuuEPDthPoAwtruQqBgyXrwLSnkx P_0, wdFALZBHCrblwHdVeElJaeWFWlOhc P_1, BwpHbKZhLWDXpAyxEIPcZcLvvUZL P_2, IntPtr P_3)
	{
		rTYrKTomZpsJmTDLUtskruaoaALV[] array = new rTYrKTomZpsJmTDLUtskruaoaALV[1];
		array[0].cWHHTJlxwbBqFnpPZJxJBVsoCWYF = (short)P_0;
		array[0].ccJRqzCgYjAPXCgrDoojypVxFhkTA = (short)P_1;
		array[0].VLbBlajDRCKlfsUoYsvoOwmKeETSA = (int)P_2;
		array[0].gBKALcjUzHaaCAqTIVxPfUqWjKTUA = P_3;
		YqWtGThGEbqWgpbNLISqdhKKOeWtA.EyoywHPTfXloHpSANWMmGoJLRBcu(array, 1, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<rTYrKTomZpsJmTDLUtskruaoaALV>());
	}

	public static void XoAGGufefJeAdXGpueVmlQwUHohib(LuuEPDthPoAwtruQqBgyXrwLSnkx P_0, wdFALZBHCrblwHdVeElJaeWFWlOhc P_1)
	{
		rTYrKTomZpsJmTDLUtskruaoaALV[] array = new rTYrKTomZpsJmTDLUtskruaoaALV[1];
		array[0].cWHHTJlxwbBqFnpPZJxJBVsoCWYF = (short)P_0;
		array[0].ccJRqzCgYjAPXCgrDoojypVxFhkTA = (short)P_1;
		array[0].VLbBlajDRCKlfsUoYsvoOwmKeETSA = 1;
		array[0].gBKALcjUzHaaCAqTIVxPfUqWjKTUA = IntPtr.Zero;
		YqWtGThGEbqWgpbNLISqdhKKOeWtA.EyoywHPTfXloHpSANWMmGoJLRBcu(array, 1, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<rTYrKTomZpsJmTDLUtskruaoaALV>());
	}

	internal static void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		pBAEQqdrZrLYcuIUaQPJZJmsVktE.pZeDMFIjdfjPRfdFAgCdKuhlPRrQ = null;
		pBAEQqdrZrLYcuIUaQPJZJmsVktE.cmIjOmSnKieZjkypgoNXQNRJzQJq = null;
		pBAEQqdrZrLYcuIUaQPJZJmsVktE.SkqInFsfXfSuloqmOgRBjRmNeDKi = null;
		LwChEasbkznzHPlKEwUKLeYgJkcq = IntPtr.Zero;
		mbVSmkUoeuMGzdliPUvucYTcuSKe = false;
		TOfSReuDOrdbpIDMicyIVzqppBsOA = IntPtr.Zero;
		hcJllQndGRvYDXlHdJYmbruUIPgy = false;
	}

	public unsafe static void SmbAPUldizYkTmIOPrAQOgZjkQnp(IntPtr P_0, double P_1)
	{
		if (YxcRqwOVshKVjcdaCaJUgZykGdQNA)
		{
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 8192u;
			int num4 = 0;
			if (YqWtGThGEbqWgpbNLISqdhKKOeWtA.UmrFWFnlgceBCrWCcQpHqpiJMEIF(P_0, WdZrzicdiXusiaqGKRYGVgaNZeWE.Input, IntPtr.Zero, ref num4, sFmDHdbrvwttmyDZBhveSoFQRaOO) < 0 || num4 == 0)
			{
				return;
			}
			num4 = (int)num3;
			if (YqWtGThGEbqWgpbNLISqdhKKOeWtA.UmrFWFnlgceBCrWCcQpHqpiJMEIF(P_0, WdZrzicdiXusiaqGKRYGVgaNZeWE.Input, uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer, ref num4, sFmDHdbrvwttmyDZBhveSoFQRaOO) < 0)
			{
				return;
			}
			HDnhBREyWmXPeHmoTZzebZvcPyvf* ptr = (HDnhBREyWmXPeHmoTZzebZvcPyvf*)(void*)uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer;
			yykbSnRLhflADGKHSxjDBcYsoNdT(ptr, P_1);
			BEhckYlmFaGrnShdHbXrVwGNTZUB(ptr, MibgvWehwKzIIOapvdhUSpGaAiqy, VoAKyaSlxIFGcoNpGDvhkPJPBrjk, eTTzzSCDvnGsYEnxEDrIftfbENtkb, ref num2, ref num);
			if (crEYwpaZJAdfPnOFQhfJCgvztKOsA)
			{
				int num5;
				while ((num5 = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.dvAhNcDpZGovnYKSchKXtNiNzIOV(uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer, ref num3, (uint)sFmDHdbrvwttmyDZBhveSoFQRaOO)) > 0)
				{
					byte* ptr2 = (byte*)(void*)uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer;
					for (int i = 0; i < num5; i++)
					{
						int cfckFHAeKtxOuKnldkennpJlaHxB = ((DuFTUcMolCBEEpnwVtOJkBhYtKpq*)ptr2)->cfckFHAeKtxOuKnldkennpJlaHxB;
						byte* ptr3 = stackalloc byte[(int)(uint)(sFmDHdbrvwttmyDZBhveSoFQRaOO + cfckFHAeKtxOuKnldkennpJlaHxB)];
						OLserehNWHIbghIOsZgXEwMqColl.xnsRGPggmOBQaJicgDFeOmzTqZEeb(ptr2, ptr3, 0, 0, sFmDHdbrvwttmyDZBhveSoFQRaOO);
						OLserehNWHIbghIOsZgXEwMqColl.xnsRGPggmOBQaJicgDFeOmzTqZEeb(ptr2, ptr3, sFmDHdbrvwttmyDZBhveSoFQRaOO + 8, sFmDHdbrvwttmyDZBhveSoFQRaOO, cfckFHAeKtxOuKnldkennpJlaHxB);
						ptr = (HDnhBREyWmXPeHmoTZzebZvcPyvf*)ptr3;
						yykbSnRLhflADGKHSxjDBcYsoNdT(ptr, P_1);
						BEhckYlmFaGrnShdHbXrVwGNTZUB(ptr, MibgvWehwKzIIOapvdhUSpGaAiqy, VoAKyaSlxIFGcoNpGDvhkPJPBrjk, eTTzzSCDvnGsYEnxEDrIftfbENtkb, ref num2, ref num);
						ptr2 = (byte*)aIQdnxAhUPQMBCULpqcncvrMjCpR.GNbrqHkoklUrBAMmqgkACSLTKEyx((HDnhBREyWmXPeHmoTZzebZvcPyvf*)ptr2);
					}
				}
			}
			else
			{
				int num5;
				while ((num5 = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.dvAhNcDpZGovnYKSchKXtNiNzIOV(uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer, ref num3, (uint)sFmDHdbrvwttmyDZBhveSoFQRaOO)) > 0)
				{
					ptr = (HDnhBREyWmXPeHmoTZzebZvcPyvf*)(void*)uzveKGjDoWOOLEGohOgQXlMwocBXB.Pointer;
					for (int j = 0; j < num5; j++)
					{
						yykbSnRLhflADGKHSxjDBcYsoNdT(ptr, P_1);
						BEhckYlmFaGrnShdHbXrVwGNTZUB(ptr, MibgvWehwKzIIOapvdhUSpGaAiqy, VoAKyaSlxIFGcoNpGDvhkPJPBrjk, eTTzzSCDvnGsYEnxEDrIftfbENtkb, ref num2, ref num);
						ptr = aIQdnxAhUPQMBCULpqcncvrMjCpR.JdGQUJsazPUyfKCaQUICMuNwxGHC(ptr);
					}
				}
			}
			QCYwkrKFbBGiIgEcwZfcsBmIxcHA(MibgvWehwKzIIOapvdhUSpGaAiqy, VoAKyaSlxIFGcoNpGDvhkPJPBrjk, eTTzzSCDvnGsYEnxEDrIftfbENtkb, ref num2, ref num);
		}
		else
		{
			int num6 = 0;
			YqWtGThGEbqWgpbNLISqdhKKOeWtA.UmrFWFnlgceBCrWCcQpHqpiJMEIF(P_0, WdZrzicdiXusiaqGKRYGVgaNZeWE.Input, IntPtr.Zero, ref num6, sFmDHdbrvwttmyDZBhveSoFQRaOO);
			if (num6 != 0)
			{
				byte* ptr4 = stackalloc byte[(int)(uint)num6];
				YqWtGThGEbqWgpbNLISqdhKKOeWtA.UmrFWFnlgceBCrWCcQpHqpiJMEIF(P_0, WdZrzicdiXusiaqGKRYGVgaNZeWE.Input, (IntPtr)ptr4, ref num6, sFmDHdbrvwttmyDZBhveSoFQRaOO);
				yykbSnRLhflADGKHSxjDBcYsoNdT((HDnhBREyWmXPeHmoTZzebZvcPyvf*)ptr4, P_1);
			}
		}
	}

	private unsafe static void BEhckYlmFaGrnShdHbXrVwGNTZUB(HDnhBREyWmXPeHmoTZzebZvcPyvf* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		if (!ljdyhHMHzShRKRhcEeJMibvGlmdmA(P_0, P_1, P_2, P_3, ref P_4, ref P_5))
		{
			QCYwkrKFbBGiIgEcwZfcsBmIxcHA(P_1, P_2, P_3, ref P_4, ref P_5);
			ljdyhHMHzShRKRhcEeJMibvGlmdmA(P_0, P_1, P_2, P_3, ref P_4, ref P_5);
		}
	}

	private unsafe static bool ljdyhHMHzShRKRhcEeJMibvGlmdmA(HDnhBREyWmXPeHmoTZzebZvcPyvf* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		DuFTUcMolCBEEpnwVtOJkBhYtKpq* ptr = &P_0->KNSgCGeNgLYaOtaGxRPmUMNlQQbp;
		uint num = (uint)(sFmDHdbrvwttmyDZBhveSoFQRaOO + ptr->cfckFHAeKtxOuKnldkennpJlaHxB);
		if (P_4 + num > P_1.Length)
		{
			return false;
		}
		if (P_5 == P_2.Length)
		{
			return false;
		}
		Marshal.Copy((IntPtr)P_0, P_1, (int)P_4, sFmDHdbrvwttmyDZBhveSoFQRaOO + ptr->cfckFHAeKtxOuKnldkennpJlaHxB);
		P_2[P_5] = P_4;
		P_3[P_5] = (uint)(P_4 + sFmDHdbrvwttmyDZBhveSoFQRaOO);
		P_5++;
		P_4 += num;
		return true;
	}

	private unsafe static void QCYwkrKFbBGiIgEcwZfcsBmIxcHA(byte[] P_0, uint[] P_1, uint[] P_2, ref uint P_3, ref uint P_4)
	{
		if (yYGgtfAIkMvfcjSUUjwXEkyfFlgo == null || P_4 == 0 || P_3 == 0)
		{
			P_3 = 0u;
			P_4 = 0u;
			return;
		}
		try
		{
			fixed (byte* ptr = P_0)
			{
				fixed (uint* ptr2 = P_1)
				{
					fixed (uint* ptr3 = P_2)
					{
						yYGgtfAIkMvfcjSUUjwXEkyfFlgo((IntPtr)ptr2, (IntPtr)ptr3, P_4, (IntPtr)ptr, P_3);
					}
				}
			}
		}
		catch (Exception msg)
		{
			Logger.LogError(msg, requiredThreadSafety: true);
		}
		P_3 = 0u;
		P_4 = 0u;
	}

	private unsafe static void yykbSnRLhflADGKHSxjDBcYsoNdT(HDnhBREyWmXPeHmoTZzebZvcPyvf* P_0, double P_1)
	{
		switch (P_0->KNSgCGeNgLYaOtaGxRPmUMNlQQbp.fIOegccOCicVLevenXOIwaeUcNZY)
		{
		case pkUmomIELOfJWzdNflUWcAcSmqxS.HumanInputDevice:
			if (pBAEQqdrZrLYcuIUaQPJZJmsVktE.SkqInFsfXfSuloqmOgRBjRmNeDKi != null)
			{
				GDoemERPManoIlVObhuwkOFTJris arg = new GDoemERPManoIlVObhuwkOFTJris(ref *P_0, mNTkiJMXCVttYyemNAsvcCIEgrzOA.IGGbkEtwElfyTqEOCASSdVSAMLKVA);
				if (arg.RWcjmtEWOihCnICrbgbyOHewqpcW)
				{
					pBAEQqdrZrLYcuIUaQPJZJmsVktE.SkqInFsfXfSuloqmOgRBjRmNeDKi(arg, P_1);
				}
			}
			break;
		case pkUmomIELOfJWzdNflUWcAcSmqxS.Keyboard:
			if (pBAEQqdrZrLYcuIUaQPJZJmsVktE.pZeDMFIjdfjPRfdFAgCdKuhlPRrQ != null)
			{
				pBAEQqdrZrLYcuIUaQPJZJmsVktE.pZeDMFIjdfjPRfdFAgCdKuhlPRrQ(new PYiFzEFMJxXAESEyjKCbCeULHHPzA(ref *P_0), P_1);
			}
			break;
		case pkUmomIELOfJWzdNflUWcAcSmqxS.Mouse:
			if (pBAEQqdrZrLYcuIUaQPJZJmsVktE.cmIjOmSnKieZjkypgoNXQNRJzQJq != null)
			{
				pBAEQqdrZrLYcuIUaQPJZJmsVktE.cmIjOmSnKieZjkypgoNXQNRJzQJq(new iqODoWfaaoUhjOzxtmuPOwzFSbyvA(ref *P_0), P_1);
			}
			break;
		}
	}

	private static void OXeFtkeiiCccBzlqegPKfaJbGVVUA(IntPtr P_0, IntPtr P_1)
	{
		switch (P_0.ToInt32())
		{
		case 1:
			if (pBAEQqdrZrLYcuIUaQPJZJmsVktE.AJNExKnaBXFBOkZoIWhmrelMMjJTA != null)
			{
				pBAEQqdrZrLYcuIUaQPJZJmsVktE.AJNExKnaBXFBOkZoIWhmrelMMjJTA(P_1);
			}
			break;
		case 2:
			if (pBAEQqdrZrLYcuIUaQPJZJmsVktE.FiLZHDTlGVoWKYTAhoSQlRSTyUsL != null)
			{
				pBAEQqdrZrLYcuIUaQPJZJmsVktE.FiLZHDTlGVoWKYTAhoSQlRSTyUsL();
			}
			break;
		}
	}

	[MonoPInvokeCallback(typeof(lSlbXeplzgAPRZhVTdmqFmIyesww))]
	private static IntPtr bbCyzPpSBHxELLJhfHqIKWHublayA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		switch (P_1)
		{
		case 255u:
			SmbAPUldizYkTmIOPrAQOgZjkQnp(P_3, ReInput.realTime);
			if (mbVSmkUoeuMGzdliPUvucYTcuSKe && !YxcRqwOVshKVjcdaCaJUgZykGdQNA)
			{
				ntBTCKNpWbGcfvsaroYgIIHAcwSp(P_0, P_1, P_2, P_3);
			}
			break;
		case 254u:
			OXeFtkeiiCccBzlqegPKfaJbGVVUA(P_2, P_3);
			break;
		}
		return IntPtr.Zero;
	}

	private static void ntBTCKNpWbGcfvsaroYgIIHAcwSp(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (DKtuRFGcKtBXAKmiDMkHoofaImWI.KncfVZCHlnVGaGAWkdKMOFojVdkmA(LwChEasbkznzHPlKEwUKLeYgJkcq))
		{
			if (hcJllQndGRvYDXlHdJYmbruUIPgy)
			{
				TOfSReuDOrdbpIDMicyIVzqppBsOA = DKtuRFGcKtBXAKmiDMkHoofaImWI.RRpaxjhmOuyozjnUYCvOBsgPZsHm(LwChEasbkznzHPlKEwUKLeYgJkcq, DKtuRFGcKtBXAKmiDMkHoofaImWI.iULbZudjvvimtxzAlbKaQpKNQueLA.WndProc);
				hcJllQndGRvYDXlHdJYmbruUIPgy = false;
			}
			if (TOfSReuDOrdbpIDMicyIVzqppBsOA != IntPtr.Zero)
			{
				DKtuRFGcKtBXAKmiDMkHoofaImWI.EZTqBnkzbQyCIRRRBSABASmBtlVj(TOfSReuDOrdbpIDMicyIVzqppBsOA, LwChEasbkznzHPlKEwUKLeYgJkcq, (int)P_1, P_2, P_3);
			}
		}
	}
}
