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

internal class VOCficZbdByaYiCNWhvhQDfbGNWGA
{
	private static readonly VfaMsJiZMcMbNLWnTUGGuqjsnLg eYzfzYzbtuyBAUpePHLkjvJhJhdUA;

	private const uint bTncwAhPIZAYxzxngtFimeuWOQWTA = 8192u;

	private const uint WqhLXhidsQbPEuRIAuFruKKCQByh = 100u;

	private const uint nFfZrTiNBqbhsENubmvquFXzmwtPA = 8192u;

	private static IntPtr aEfGFOBAnpdUtejhIeYaOMaCgvUSc;

	private static bool UmKnMgYeoBdsTKztoDbstQxPkfkDA;

	private static IntPtr ICzKkDFXhNxvEFnZiavuMOzzoYuF;

	private static bool jJUbDplWhiafeEKcnhOaQpDtlaodb;

	private static readonly int YhtBoufCwAMPHkHlesxyWFVnZEne;

	private static readonly int xcoyejodbIwqcQMJarzmmaLAKtfO;

	private static readonly NativeBuffer sqhcJJCMHkRZnAnSSHEGriZRQWtD;

	private static readonly bool WALfACbTRVmctEQjYnlqbbLRCERG;

	private static readonly byte[] ZuLeIUkDlThGsJgGRUbMfhIAWhaR;

	private static readonly uint[] bPpzMaCiJFcAlBGlzLhTNmQqnnKaA;

	private static readonly uint[] ZECzGBDqWSNjDabKSXCLUvBZUbZ;

	private static readonly bool BVKHNIOHwKMRtidKowZQHMSHtjOo;

	private static ForwardRawInputEventsToUnityDelegate jcbcbOjQnOxFOPZsZZNYWZEEqGbSA;

	[CompilerGenerated]
	private static Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> m_pmRcDEJBJxZTNZuphiARdfjKGWHoA;

	[CompilerGenerated]
	private static Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> m_hMHeCVBHWCqUkOdIPSvnBfAsnaBX;

	[CompilerGenerated]
	private static Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> m_dHuNmDnkOMCHvtIZhCWlEpwntfcv;

	[CompilerGenerated]
	private static Action<IntPtr> m_rcYTXFBziePJgIYgWdBpYLQpVTjN;

	[CompilerGenerated]
	private static Action m_aFashijUwhhcypZFBFDbxdIjjEIKA;

	public static ForwardRawInputEventsToUnityDelegate NHRzxvdcnVnMxvqEwCHPbFwRhCuHb
	{
		get
		{
			return jcbcbOjQnOxFOPZsZZNYWZEEqGbSA;
		}
		set
		{
			jcbcbOjQnOxFOPZsZZNYWZEEqGbSA = forwardRawInputEventsToUnityDelegate;
		}
	}

	public static event Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> pmRcDEJBJxZTNZuphiARdfjKGWHoA
	{
		[CompilerGenerated]
		add
		{
			Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_pmRcDEJBJxZTNZuphiARdfjKGWHoA;
			Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> action2;
			do
			{
				action2 = action;
				Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> value2 = (Action<bWaeCKounRufwYulBkfXjjgGVZaP, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_pmRcDEJBJxZTNZuphiARdfjKGWHoA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_pmRcDEJBJxZTNZuphiARdfjKGWHoA;
			Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> action2;
			do
			{
				action2 = action;
				Action<bWaeCKounRufwYulBkfXjjgGVZaP, double> value2 = (Action<bWaeCKounRufwYulBkfXjjgGVZaP, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_pmRcDEJBJxZTNZuphiARdfjKGWHoA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> hMHeCVBHWCqUkOdIPSvnBfAsnaBX
	{
		[CompilerGenerated]
		add
		{
			Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_hMHeCVBHWCqUkOdIPSvnBfAsnaBX;
			Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> action2;
			do
			{
				action2 = action;
				Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> value2 = (Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_hMHeCVBHWCqUkOdIPSvnBfAsnaBX, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_hMHeCVBHWCqUkOdIPSvnBfAsnaBX;
			Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> action2;
			do
			{
				action2 = action;
				Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double> value2 = (Action<AAQKPUCiIQrCBdBuDFRrBhBEPbRuA, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_hMHeCVBHWCqUkOdIPSvnBfAsnaBX, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> dHuNmDnkOMCHvtIZhCWlEpwntfcv
	{
		[CompilerGenerated]
		add
		{
			Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_dHuNmDnkOMCHvtIZhCWlEpwntfcv;
			Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> action2;
			do
			{
				action2 = action;
				Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> value2 = (Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_dHuNmDnkOMCHvtIZhCWlEpwntfcv, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_dHuNmDnkOMCHvtIZhCWlEpwntfcv;
			Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> action2;
			do
			{
				action2 = action;
				Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double> value2 = (Action<aToEJMDjaKBRkUrNXmHCmhtEwpJxA, double>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_dHuNmDnkOMCHvtIZhCWlEpwntfcv, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<IntPtr> rcYTXFBziePJgIYgWdBpYLQpVTjN
	{
		[CompilerGenerated]
		add
		{
			Action<IntPtr> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_rcYTXFBziePJgIYgWdBpYLQpVTjN;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_rcYTXFBziePJgIYgWdBpYLQpVTjN, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<IntPtr> action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_rcYTXFBziePJgIYgWdBpYLQpVTjN;
			Action<IntPtr> action2;
			do
			{
				action2 = action;
				Action<IntPtr> value2 = (Action<IntPtr>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_rcYTXFBziePJgIYgWdBpYLQpVTjN, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action aFashijUwhhcypZFBFDbxdIjjEIKA
	{
		[CompilerGenerated]
		add
		{
			Action action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_aFashijUwhhcypZFBFDbxdIjjEIKA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_aFashijUwhhcypZFBFDbxdIjjEIKA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = VOCficZbdByaYiCNWhvhQDfbGNWGA.m_aFashijUwhhcypZFBFDbxdIjjEIKA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VOCficZbdByaYiCNWhvhQDfbGNWGA.m_aFashijUwhhcypZFBFDbxdIjjEIKA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	static VOCficZbdByaYiCNWhvhQDfbGNWGA()
	{
		eYzfzYzbtuyBAUpePHLkjvJhJhdUA = CIvCSVUstBGerNTKLiUTpSjPGLaQ;
		YhtBoufCwAMPHkHlesxyWFVnZEne = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<lnpeeBWlsKrkONptvHYKoRRtgPSS>();
		xcoyejodbIwqcQMJarzmmaLAKtfO = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<rwXRtooqPoJzyhLfxrvbtaDDLAQO>();
		WALfACbTRVmctEQjYnlqbbLRCERG = UnityTools.windowsStandalone_supportsRawInputForwarding;
		if (WALfACbTRVmctEQjYnlqbbLRCERG)
		{
			try
			{
				sqhcJJCMHkRZnAnSSHEGriZRQWtD = new NativeBuffer(8192);
				ZuLeIUkDlThGsJgGRUbMfhIAWhaR = new byte[8192];
				bPpzMaCiJFcAlBGlzLhTNmQqnnKaA = new uint[100];
				ZECzGBDqWSNjDabKSXCLUvBZUbZ = new uint[100];
			}
			catch
			{
				WALfACbTRVmctEQjYnlqbbLRCERG = false;
				Logger.LogError("Could not allocate memory for Raw Input buffer.", requiredThreadSafety: true);
			}
		}
		BVKHNIOHwKMRtidKowZQHMSHtjOo = !SystemInfo.is64Bit && FTdbbIUhAgYSHUHmiEJUirkRZXhf.JlVnXHbxbrozGMzJjhOGmPjJDSGj();
	}

	public static void yWylBbJgIGlJAtirvWsIJlAeWlCc(IntPtr P_0, bool P_1)
	{
		UmKnMgYeoBdsTKztoDbstQxPkfkDA = P_1;
		if (!(P_0 == IntPtr.Zero) && !(P_0 == aEfGFOBAnpdUtejhIeYaOMaCgvUSc))
		{
			aEfGFOBAnpdUtejhIeYaOMaCgvUSc = P_0;
			jJUbDplWhiafeEKcnhOaQpDtlaodb = true;
		}
	}

	public static void fAbBNiRtBTPupRIeaDQygpzBqvJfA(bool P_0)
	{
		UmKnMgYeoBdsTKztoDbstQxPkfkDA = P_0;
	}

	public static VfaMsJiZMcMbNLWnTUGGuqjsnLg ETrgbYLHMlqYYFPTJOrXIOFzvSkl()
	{
		return eYzfzYzbtuyBAUpePHLkjvJhJhdUA;
	}

	public unsafe static List<bCVCqJGQfobtAJKBYJLjxEezUkax> rysdPuHtloHgbxskNapOExZYvBKBb(bool P_0)
	{
		int num = 0;
		kaKSjRDqyXTrOnqKpcpOqXaZcszV.mcHHOzHhEDgYWQdAPKbdaoKrcHQlA(null, ref num, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<TKfiIAMvoMajpzMHXaNGeewCQKDyA>());
		if (num == 0)
		{
			return null;
		}
		TKfiIAMvoMajpzMHXaNGeewCQKDyA[] array = new TKfiIAMvoMajpzMHXaNGeewCQKDyA[num];
		kaKSjRDqyXTrOnqKpcpOqXaZcszV.mcHHOzHhEDgYWQdAPKbdaoKrcHQlA(array, ref num, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<TKfiIAMvoMajpzMHXaNGeewCQKDyA>());
		string[] array2 = new string[num];
		int num2 = 0;
		int num3 = 0;
		List<bCVCqJGQfobtAJKBYJLjxEezUkax> list = new List<bCVCqJGQfobtAJKBYJLjxEezUkax>();
		for (int i = 0; i < num; i++)
		{
			bool flag = false;
			IntPtr dVGrzVrYFAdXogFEmpuwwUvWTxhG = array[i].DVGrzVrYFAdXogFEmpuwwUvWTxhG;
			int num4 = 0;
			kaKSjRDqyXTrOnqKpcpOqXaZcszV.gCaBVHcFDNAIRjsqxfsDKqoRoDOeA(dVGrzVrYFAdXogFEmpuwwUvWTxhG, pTeNfaiQPJQOABjhAtwFmlBqEIsv.DeviceName, IntPtr.Zero, ref num4);
			if (num4 == 0)
			{
				flag = true;
			}
			char* ptr = stackalloc char[num4];
			kaKSjRDqyXTrOnqKpcpOqXaZcszV.gCaBVHcFDNAIRjsqxfsDKqoRoDOeA(dVGrzVrYFAdXogFEmpuwwUvWTxhG, pTeNfaiQPJQOABjhAtwFmlBqEIsv.DeviceName, (IntPtr)ptr, ref num4);
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
			kaKSjRDqyXTrOnqKpcpOqXaZcszV.gCaBVHcFDNAIRjsqxfsDKqoRoDOeA(dVGrzVrYFAdXogFEmpuwwUvWTxhG, pTeNfaiQPJQOABjhAtwFmlBqEIsv.DeviceInfo, IntPtr.Zero, ref num7);
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
			if (kaKSjRDqyXTrOnqKpcpOqXaZcszV.gCaBVHcFDNAIRjsqxfsDKqoRoDOeA(dVGrzVrYFAdXogFEmpuwwUvWTxhG, pTeNfaiQPJQOABjhAtwFmlBqEIsv.DeviceInfo, (IntPtr)ptr2, ref num7) >= 0)
			{
				try
				{
					buMUyDRZYHJJFRsRWOsUCuVWuBBq buMUyDRZYHJJFRsRWOsUCuVWuBBq2 = *(buMUyDRZYHJJFRsRWOsUCuVWuBBq*)ptr2;
					bCVCqJGQfobtAJKBYJLjxEezUkax item = bCVCqJGQfobtAJKBYJLjxEezUkax.FZnMfANDWEApWgeljPRjthaMldXSA(ref buMUyDRZYHJJFRsRWOsUCuVWuBBq2, text, dVGrzVrYFAdXogFEmpuwwUvWTxhG);
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

	public static void NEhXUVyqKHzxzkuZjoOhqkRCzvyr(xUivhXBnnOXcBfVLUPeYUEnEfaRE P_0, IsXKoFjdoBmMGfmMiJEdvzqZllxq P_1, xtpywObpOquEBOucidMAGjbshBeF P_2, IntPtr P_3)
	{
		NiIUnPYpvHjaCXcCqYNIeLExhAsW[] array = new NiIUnPYpvHjaCXcCqYNIeLExhAsW[1];
		array[0].nmfraRTwPHWQYjnFFHRttrOwaDPZ = (short)P_0;
		array[0].PcCFgJmzSLXPnrERAEfJldaHlSFi = (short)P_1;
		array[0].ogMhRDeyGciLZpjllCIDbeHQmpvd = (int)P_2;
		array[0].XxQFzPfjQniOagXIiiADJTSpkXtAA = P_3;
		kaKSjRDqyXTrOnqKpcpOqXaZcszV.dXWHlIKCBGexMFVfyeVwnnjuZXxO(array, 1, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<NiIUnPYpvHjaCXcCqYNIeLExhAsW>());
	}

	public static void sBdNhEnAYPArLHHmkUBseOAefTgy(xUivhXBnnOXcBfVLUPeYUEnEfaRE P_0, IsXKoFjdoBmMGfmMiJEdvzqZllxq P_1)
	{
		NiIUnPYpvHjaCXcCqYNIeLExhAsW[] array = new NiIUnPYpvHjaCXcCqYNIeLExhAsW[1];
		array[0].nmfraRTwPHWQYjnFFHRttrOwaDPZ = (short)P_0;
		array[0].PcCFgJmzSLXPnrERAEfJldaHlSFi = (short)P_1;
		array[0].ogMhRDeyGciLZpjllCIDbeHQmpvd = 1;
		array[0].XxQFzPfjQniOagXIiiADJTSpkXtAA = IntPtr.Zero;
		kaKSjRDqyXTrOnqKpcpOqXaZcszV.dXWHlIKCBGexMFVfyeVwnnjuZXxO(array, 1, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<NiIUnPYpvHjaCXcCqYNIeLExhAsW>());
	}

	internal static void zXZILICovMOOtvYdGcYSjIvduLSS()
	{
		VOCficZbdByaYiCNWhvhQDfbGNWGA.pmRcDEJBJxZTNZuphiARdfjKGWHoA = null;
		VOCficZbdByaYiCNWhvhQDfbGNWGA.hMHeCVBHWCqUkOdIPSvnBfAsnaBX = null;
		VOCficZbdByaYiCNWhvhQDfbGNWGA.dHuNmDnkOMCHvtIZhCWlEpwntfcv = null;
		aEfGFOBAnpdUtejhIeYaOMaCgvUSc = IntPtr.Zero;
		UmKnMgYeoBdsTKztoDbstQxPkfkDA = false;
		ICzKkDFXhNxvEFnZiavuMOzzoYuF = IntPtr.Zero;
		jJUbDplWhiafeEKcnhOaQpDtlaodb = false;
	}

	public unsafe static void VltcBkLPxrbmBLugCDZsMFsnOdWT(IntPtr P_0, double P_1)
	{
		if (WALfACbTRVmctEQjYnlqbbLRCERG)
		{
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 8192u;
			int num4 = 0;
			if (kaKSjRDqyXTrOnqKpcpOqXaZcszV.fiWOtwJeuGtdHSTuqjbuFgffZayw(P_0, asBOkuGRNrZaGgVhakFwMZKOZMrl.Input, IntPtr.Zero, ref num4, xcoyejodbIwqcQMJarzmmaLAKtfO) < 0 || num4 == 0)
			{
				return;
			}
			num4 = (int)num3;
			if (kaKSjRDqyXTrOnqKpcpOqXaZcszV.fiWOtwJeuGtdHSTuqjbuFgffZayw(P_0, asBOkuGRNrZaGgVhakFwMZKOZMrl.Input, sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer, ref num4, xcoyejodbIwqcQMJarzmmaLAKtfO) < 0)
			{
				return;
			}
			lnpeeBWlsKrkONptvHYKoRRtgPSS* ptr = (lnpeeBWlsKrkONptvHYKoRRtgPSS*)(void*)sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer;
			tCmZMKWDgzGbmqrBItgKoRMlWjjJ(ptr, P_1);
			gGSazjEVqRuizcjQTmsGXkGvNGHT(ptr, ZuLeIUkDlThGsJgGRUbMfhIAWhaR, bPpzMaCiJFcAlBGlzLhTNmQqnnKaA, ZECzGBDqWSNjDabKSXCLUvBZUbZ, ref num2, ref num);
			if (BVKHNIOHwKMRtidKowZQHMSHtjOo)
			{
				int num5;
				while ((num5 = FTdbbIUhAgYSHUHmiEJUirkRZXhf.cYvnzvuKjGALxsGlWOFtcZnHzIHj(sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer, ref num3, (uint)xcoyejodbIwqcQMJarzmmaLAKtfO)) > 0)
				{
					byte* ptr2 = (byte*)(void*)sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer;
					for (int i = 0; i < num5; i++)
					{
						int mnbandJxkGmHgNVOViHVIAvEpfqJb = ((rwXRtooqPoJzyhLfxrvbtaDDLAQO*)ptr2)->mnbandJxkGmHgNVOViHVIAvEpfqJb;
						byte* ptr3 = stackalloc byte[(int)(uint)(xcoyejodbIwqcQMJarzmmaLAKtfO + mnbandJxkGmHgNVOViHVIAvEpfqJb)];
						gkeZAoVSdvnpEhiPWCalNOchbIMDA.YtXSMYgudjcubxCFGIPCpdeaocve(ptr2, ptr3, 0, 0, xcoyejodbIwqcQMJarzmmaLAKtfO);
						gkeZAoVSdvnpEhiPWCalNOchbIMDA.YtXSMYgudjcubxCFGIPCpdeaocve(ptr2, ptr3, xcoyejodbIwqcQMJarzmmaLAKtfO + 8, xcoyejodbIwqcQMJarzmmaLAKtfO, mnbandJxkGmHgNVOViHVIAvEpfqJb);
						ptr = (lnpeeBWlsKrkONptvHYKoRRtgPSS*)ptr3;
						tCmZMKWDgzGbmqrBItgKoRMlWjjJ(ptr, P_1);
						gGSazjEVqRuizcjQTmsGXkGvNGHT(ptr, ZuLeIUkDlThGsJgGRUbMfhIAWhaR, bPpzMaCiJFcAlBGlzLhTNmQqnnKaA, ZECzGBDqWSNjDabKSXCLUvBZUbZ, ref num2, ref num);
						ptr2 = (byte*)GGKWpYaqvdxlhYAaRDjPdXkXGbAe.nevALgIKTFFZxYfBznidwwBdzcQp((lnpeeBWlsKrkONptvHYKoRRtgPSS*)ptr2);
					}
				}
			}
			else
			{
				int num5;
				while ((num5 = FTdbbIUhAgYSHUHmiEJUirkRZXhf.cYvnzvuKjGALxsGlWOFtcZnHzIHj(sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer, ref num3, (uint)xcoyejodbIwqcQMJarzmmaLAKtfO)) > 0)
				{
					ptr = (lnpeeBWlsKrkONptvHYKoRRtgPSS*)(void*)sqhcJJCMHkRZnAnSSHEGriZRQWtD.Pointer;
					for (int j = 0; j < num5; j++)
					{
						tCmZMKWDgzGbmqrBItgKoRMlWjjJ(ptr, P_1);
						gGSazjEVqRuizcjQTmsGXkGvNGHT(ptr, ZuLeIUkDlThGsJgGRUbMfhIAWhaR, bPpzMaCiJFcAlBGlzLhTNmQqnnKaA, ZECzGBDqWSNjDabKSXCLUvBZUbZ, ref num2, ref num);
						ptr = GGKWpYaqvdxlhYAaRDjPdXkXGbAe.fXykSqqgaphbdEbFfjCgLphIkOteb(ptr);
					}
				}
			}
			ffbpnJpHhsUXwWOcoFxGrJuKGIZX(ZuLeIUkDlThGsJgGRUbMfhIAWhaR, bPpzMaCiJFcAlBGlzLhTNmQqnnKaA, ZECzGBDqWSNjDabKSXCLUvBZUbZ, ref num2, ref num);
		}
		else
		{
			int num6 = 0;
			kaKSjRDqyXTrOnqKpcpOqXaZcszV.fiWOtwJeuGtdHSTuqjbuFgffZayw(P_0, asBOkuGRNrZaGgVhakFwMZKOZMrl.Input, IntPtr.Zero, ref num6, xcoyejodbIwqcQMJarzmmaLAKtfO);
			if (num6 != 0)
			{
				byte* ptr4 = stackalloc byte[(int)(uint)num6];
				kaKSjRDqyXTrOnqKpcpOqXaZcszV.fiWOtwJeuGtdHSTuqjbuFgffZayw(P_0, asBOkuGRNrZaGgVhakFwMZKOZMrl.Input, (IntPtr)ptr4, ref num6, xcoyejodbIwqcQMJarzmmaLAKtfO);
				tCmZMKWDgzGbmqrBItgKoRMlWjjJ((lnpeeBWlsKrkONptvHYKoRRtgPSS*)ptr4, P_1);
			}
		}
	}

	private unsafe static void gGSazjEVqRuizcjQTmsGXkGvNGHT(lnpeeBWlsKrkONptvHYKoRRtgPSS* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		if (!AxjMsghhYublJbLqwQaCbMvMwhHuA(P_0, P_1, P_2, P_3, ref P_4, ref P_5))
		{
			ffbpnJpHhsUXwWOcoFxGrJuKGIZX(P_1, P_2, P_3, ref P_4, ref P_5);
			AxjMsghhYublJbLqwQaCbMvMwhHuA(P_0, P_1, P_2, P_3, ref P_4, ref P_5);
		}
	}

	private unsafe static bool AxjMsghhYublJbLqwQaCbMvMwhHuA(lnpeeBWlsKrkONptvHYKoRRtgPSS* P_0, byte[] P_1, uint[] P_2, uint[] P_3, ref uint P_4, ref uint P_5)
	{
		rwXRtooqPoJzyhLfxrvbtaDDLAQO* ptr = &P_0->UqDJoqlmyBXLoSmoegZwHgFGYpvt;
		uint num = (uint)(xcoyejodbIwqcQMJarzmmaLAKtfO + ptr->mnbandJxkGmHgNVOViHVIAvEpfqJb);
		if (P_4 + num > P_1.Length)
		{
			return false;
		}
		if (P_5 == P_2.Length)
		{
			return false;
		}
		Marshal.Copy((IntPtr)P_0, P_1, (int)P_4, xcoyejodbIwqcQMJarzmmaLAKtfO + ptr->mnbandJxkGmHgNVOViHVIAvEpfqJb);
		P_2[P_5] = P_4;
		P_3[P_5] = (uint)(P_4 + xcoyejodbIwqcQMJarzmmaLAKtfO);
		P_5++;
		P_4 += num;
		return true;
	}

	private unsafe static void ffbpnJpHhsUXwWOcoFxGrJuKGIZX(byte[] P_0, uint[] P_1, uint[] P_2, ref uint P_3, ref uint P_4)
	{
		if (jcbcbOjQnOxFOPZsZZNYWZEEqGbSA == null || P_4 == 0 || P_3 == 0)
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
						jcbcbOjQnOxFOPZsZZNYWZEEqGbSA((IntPtr)ptr2, (IntPtr)ptr3, P_4, (IntPtr)ptr, P_3);
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

	private unsafe static void tCmZMKWDgzGbmqrBItgKoRMlWjjJ(lnpeeBWlsKrkONptvHYKoRRtgPSS* P_0, double P_1)
	{
		switch (P_0->UqDJoqlmyBXLoSmoegZwHgFGYpvt.jcNyjzdnjCDdhQZxdhcipgBdkERq)
		{
		case HLIHggermciamhEKNxfavGKToBMk.HumanInputDevice:
			if (VOCficZbdByaYiCNWhvhQDfbGNWGA.dHuNmDnkOMCHvtIZhCWlEpwntfcv != null)
			{
				aToEJMDjaKBRkUrNXmHCmhtEwpJxA arg = new aToEJMDjaKBRkUrNXmHCmhtEwpJxA(ref *P_0, IoJbJLHywlWGmeKpnkPFHZqNbjUM.SeSOGJrxhRvYYdcKCEtJvgPlOWMQ);
				if (arg.EZdLdBDgHAJSnCFTnczORkkRilJr)
				{
					VOCficZbdByaYiCNWhvhQDfbGNWGA.dHuNmDnkOMCHvtIZhCWlEpwntfcv(arg, P_1);
				}
			}
			break;
		case HLIHggermciamhEKNxfavGKToBMk.Keyboard:
			if (VOCficZbdByaYiCNWhvhQDfbGNWGA.pmRcDEJBJxZTNZuphiARdfjKGWHoA != null)
			{
				VOCficZbdByaYiCNWhvhQDfbGNWGA.pmRcDEJBJxZTNZuphiARdfjKGWHoA(new bWaeCKounRufwYulBkfXjjgGVZaP(ref *P_0), P_1);
			}
			break;
		case HLIHggermciamhEKNxfavGKToBMk.Mouse:
			if (VOCficZbdByaYiCNWhvhQDfbGNWGA.hMHeCVBHWCqUkOdIPSvnBfAsnaBX != null)
			{
				VOCficZbdByaYiCNWhvhQDfbGNWGA.hMHeCVBHWCqUkOdIPSvnBfAsnaBX(new AAQKPUCiIQrCBdBuDFRrBhBEPbRuA(ref *P_0), P_1);
			}
			break;
		}
	}

	private static void GalXmpKmmNBbrezfcWNfEiuQejnlA(IntPtr P_0, IntPtr P_1)
	{
		switch (P_0.ToInt32())
		{
		case 1:
			if (VOCficZbdByaYiCNWhvhQDfbGNWGA.rcYTXFBziePJgIYgWdBpYLQpVTjN != null)
			{
				VOCficZbdByaYiCNWhvhQDfbGNWGA.rcYTXFBziePJgIYgWdBpYLQpVTjN(P_1);
			}
			break;
		case 2:
			if (VOCficZbdByaYiCNWhvhQDfbGNWGA.aFashijUwhhcypZFBFDbxdIjjEIKA != null)
			{
				VOCficZbdByaYiCNWhvhQDfbGNWGA.aFashijUwhhcypZFBFDbxdIjjEIKA();
			}
			break;
		}
	}

	[MonoPInvokeCallback(typeof(VfaMsJiZMcMbNLWnTUGGuqjsnLg))]
	private static IntPtr CIvCSVUstBGerNTKLiUTpSjPGLaQ(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		switch (P_1)
		{
		case 255u:
			VltcBkLPxrbmBLugCDZsMFsnOdWT(P_3, ReInput.realTime);
			if (UmKnMgYeoBdsTKztoDbstQxPkfkDA && !WALfACbTRVmctEQjYnlqbbLRCERG)
			{
				BHxhFrRZXckyALmZGVAaXdZxuKkK(P_0, P_1, P_2, P_3);
			}
			break;
		case 254u:
			GalXmpKmmNBbrezfcWNfEiuQejnlA(P_2, P_3);
			break;
		}
		return IntPtr.Zero;
	}

	private static void BHxhFrRZXckyALmZGVAaXdZxuKkK(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (tlfLBPuqgJySwCjSltjrpFZlYYxH.OLnHATFKWYsBKWEwQQzBebdSzimF(aEfGFOBAnpdUtejhIeYaOMaCgvUSc))
		{
			if (jJUbDplWhiafeEKcnhOaQpDtlaodb)
			{
				ICzKkDFXhNxvEFnZiavuMOzzoYuF = tlfLBPuqgJySwCjSltjrpFZlYYxH.IBFPYydUDlvPobPkZsnRBDBMFhd(aEfGFOBAnpdUtejhIeYaOMaCgvUSc, tlfLBPuqgJySwCjSltjrpFZlYYxH.AwRkygDXJHIRLlsPRnpIyZuCoeVQ.WndProc);
				jJUbDplWhiafeEKcnhOaQpDtlaodb = false;
			}
			if (ICzKkDFXhNxvEFnZiavuMOzzoYuF != IntPtr.Zero)
			{
				tlfLBPuqgJySwCjSltjrpFZlYYxH.JBAAIfBFFgIDWWMrLQxaBWdaNnWaA(ICzKkDFXhNxvEFnZiavuMOzzoYuF, aEfGFOBAnpdUtejhIeYaOMaCgvUSc, (int)P_1, P_2, P_3);
			}
		}
	}
}
