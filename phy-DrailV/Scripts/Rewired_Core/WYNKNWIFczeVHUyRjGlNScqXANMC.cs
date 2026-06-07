using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class WYNKNWIFczeVHUyRjGlNScqXANMC
{
	private class AFOuqHHBYRFCPMZFVTQeccBeGtYm
	{
		private ButtonStateFlags JyHADxoRKQNjGdZfIGvCYpCGctyE;

		private ButtonStateFlags HhbvxxGDSqxTZJNbKdXJufAxlCIA;

		private ButtonStateFlags UufTCbRKqdyjEVqJybvjBooPmklK;

		private ButtonStateFlags YfOtrjSaCVMDIodrKBUsqlxgeCxt;

		private uint yuOOyUhNObzXYIGgywCdCuLneokl;

		private bool tgvVmwfSudDgQeGCTgJwqomTwepU;

		private bool YytJDrRLPPFkGHBRHWbRuCAFsYRxA;

		private bool zqKmqYyIzGMnDwuVjaxnewQMiojF;

		private KtsEclDDNAMtzXpypcdeiyHyEFolA BTRQpUgGaOmyqnYvHEXtYXvdezIe;

		public bool ZxzEvLaKwNhveXxXvUHUuKyEDzKz => tgvVmwfSudDgQeGCTgJwqomTwepU;

		public bool OeQLYUPDDBkdHhbaaYeQwJgkelpZ
		{
			get
			{
				return YytJDrRLPPFkGHBRHWbRuCAFsYRxA;
			}
			set
			{
				YytJDrRLPPFkGHBRHWbRuCAFsYRxA = yytJDrRLPPFkGHBRHWbRuCAFsYRxA;
			}
		}

		public ButtonStateFlags xlyWqlnToOPAbVjNGAzzNUGWChIEA(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (JyHADxoRKQNjGdZfIGvCYpCGctyE & ButtonStateFlags.On) != 0;
				flag2 = (HhbvxxGDSqxTZJNbKdXJufAxlCIA & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!YytJDrRLPPFkGHBRHWbRuCAFsYRxA) ? JyHADxoRKQNjGdZfIGvCYpCGctyE : ButtonStateFlags.Off);
			}
			else
			{
				flag = (UufTCbRKqdyjEVqJybvjBooPmklK & ButtonStateFlags.On) != 0;
				flag2 = (YfOtrjSaCVMDIodrKBUsqlxgeCxt & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!YytJDrRLPPFkGHBRHWbRuCAFsYRxA) ? UufTCbRKqdyjEVqJybvjBooPmklK : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (YytJDrRLPPFkGHBRHWbRuCAFsYRxA)
				{
					if (flag2 && !zqKmqYyIzGMnDwuVjaxnewQMiojF && BTRQpUgGaOmyqnYvHEXtYXvdezIe.GXybZxkxlIHHsGOkUaQgyHDMDCGc)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (zqKmqYyIzGMnDwuVjaxnewQMiojF && BTRQpUgGaOmyqnYvHEXtYXvdezIe.GXybZxkxlIHHsGOkUaQgyHDMDCGc)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !YytJDrRLPPFkGHBRHWbRuCAFsYRxA && !zqKmqYyIzGMnDwuVjaxnewQMiojF)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
		{
			HhbvxxGDSqxTZJNbKdXJufAxlCIA = JyHADxoRKQNjGdZfIGvCYpCGctyE;
			YfOtrjSaCVMDIodrKBUsqlxgeCxt = UufTCbRKqdyjEVqJybvjBooPmklK;
			zqKmqYyIzGMnDwuVjaxnewQMiojF = YytJDrRLPPFkGHBRHWbRuCAFsYRxA;
			JyHADxoRKQNjGdZfIGvCYpCGctyE = ButtonStateFlags.Off;
			UufTCbRKqdyjEVqJybvjBooPmklK = ButtonStateFlags.Off;
		}

		public void bGmoUimdmfdGLWSXOgeEiOJuUsWfA(uint P_0)
		{
			if (yuOOyUhNObzXYIGgywCdCuLneokl < P_0 - 1)
			{
				tgvVmwfSudDgQeGCTgJwqomTwepU = false;
			}
		}

		public void pPkAjWcjXawKVDbcOlwBbFlvXJDA(bool P_0)
		{
			fytesVmSgMdEYCdUSfupqQQYLxEPA((P_0 ? JyHADxoRKQNjGdZfIGvCYpCGctyE : UufTCbRKqdyjEVqJybvjBooPmklK) | ButtonStateFlags.On, P_0);
		}

		public void fytesVmSgMdEYCdUSfupqQQYLxEPA(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				JyHADxoRKQNjGdZfIGvCYpCGctyE = P_0;
			}
			else
			{
				UufTCbRKqdyjEVqJybvjBooPmklK = P_0;
			}
			yuOOyUhNObzXYIGgywCdCuLneokl = ReInput.currentFrame;
			if (!tgvVmwfSudDgQeGCTgJwqomTwepU)
			{
				tgvVmwfSudDgQeGCTgJwqomTwepU = true;
			}
		}

		public void oCYktUpYSAqYazDNkURaYKHUyQLe(ref KtsEclDDNAMtzXpypcdeiyHyEFolA P_0)
		{
			BTRQpUgGaOmyqnYvHEXtYXvdezIe = P_0;
			YytJDrRLPPFkGHBRHWbRuCAFsYRxA = P_0.JeAenAwJIaCwIKhPcmfPuNhocdJM;
			zqKmqYyIzGMnDwuVjaxnewQMiojF = P_0.JeAenAwJIaCwIKhPcmfPuNhocdJM;
		}

		public void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			JyHADxoRKQNjGdZfIGvCYpCGctyE = ButtonStateFlags.Off;
			HhbvxxGDSqxTZJNbKdXJufAxlCIA = ButtonStateFlags.Off;
			UufTCbRKqdyjEVqJybvjBooPmklK = ButtonStateFlags.Off;
			YfOtrjSaCVMDIodrKBUsqlxgeCxt = ButtonStateFlags.Off;
			yuOOyUhNObzXYIGgywCdCuLneokl = 0u;
			tgvVmwfSudDgQeGCTgJwqomTwepU = false;
			YytJDrRLPPFkGHBRHWbRuCAFsYRxA = false;
			zqKmqYyIzGMnDwuVjaxnewQMiojF = false;
		}
	}

	public struct KtsEclDDNAMtzXpypcdeiyHyEFolA
	{
		public bool GXybZxkxlIHHsGOkUaQgyHDMDCGc;

		public bool JeAenAwJIaCwIKhPcmfPuNhocdJM;

		public static KtsEclDDNAMtzXpypcdeiyHyEFolA TnTDUNAZHaIKIVXoBnkbIGJLDAwVA => default(KtsEclDDNAMtzXpypcdeiyHyEFolA);
	}

	[Serializable]
	private sealed class QgUtMReIFNRJdKrxcVhJSJnyqNG
	{
		public static readonly QgUtMReIFNRJdKrxcVhJSJnyqNG _003C_003E9 = new QgUtMReIFNRJdKrxcVhJSJnyqNG();

		public static Func<AFOuqHHBYRFCPMZFVTQeccBeGtYm> _003C_003E9__22_0;

		internal WYNKNWIFczeVHUyRjGlNScqXANMC yTiwccvKYndwyEbjSIlNrIPQKfAoA()
		{
			return new WYNKNWIFczeVHUyRjGlNScqXANMC();
		}

		internal void VidwbiQheMAscdxapVTkRMTTAjaOA(WYNKNWIFczeVHUyRjGlNScqXANMC P_0)
		{
			P_0.wJjPIIRJfHhEbGedUconecGfiwzgB();
		}

		internal AFOuqHHBYRFCPMZFVTQeccBeGtYm pdXHCrJUTndRsfAkyuMTKmWIlNol()
		{
			return new AFOuqHHBYRFCPMZFVTQeccBeGtYm();
		}
	}

	private const int XUGbNSxsWVGEjPfVQlaSbFVwkPcO = 20;

	private const int SMZZcNRjaWpaiGaHRbgqloCFmccN = 10;

	private static ObjectPool<WYNKNWIFczeVHUyRjGlNScqXANMC> rbhcKUclQkUwmrYEMpjLImUBFhbc;

	private static WYNKNWIFczeVHUyRjGlNScqXANMC[] dYkoKUlGdrlOFWGHqCIyvCPfIUlM;

	private static int yRGqFQobqGcJzicFjfcRzWrKIMlH;

	public int unVfCqoeDCEJeDyociDfoLlVwjIRA;

	private UpdateLoopDataSet<AFOuqHHBYRFCPMZFVTQeccBeGtYm> bFWxHBjQsxHuYvNjQgQHYwACscWA;

	public bool ZxzEvLaKwNhveXxXvUHUuKyEDzKz
	{
		get
		{
			int count = bFWxHBjQsxHuYvNjQgQHYwACscWA.Count;
			for (int i = 0; i < count; i++)
			{
				if (bFWxHBjQsxHuYvNjQgQHYwACscWA[i].ZxzEvLaKwNhveXxXvUHUuKyEDzKz)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool OeQLYUPDDBkdHhbaaYeQwJgkelpZ
	{
		get
		{
			return bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.OeQLYUPDDBkdHhbaaYeQwJgkelpZ;
		}
		set
		{
			bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.OeQLYUPDDBkdHhbaaYeQwJgkelpZ = flag;
		}
	}

	static WYNKNWIFczeVHUyRjGlNScqXANMC()
	{
		rbhcKUclQkUwmrYEMpjLImUBFhbc = new ObjectPool<WYNKNWIFczeVHUyRjGlNScqXANMC>(20, QgUtMReIFNRJdKrxcVhJSJnyqNG._003C_003E9.yTiwccvKYndwyEbjSIlNrIPQKfAoA, QgUtMReIFNRJdKrxcVhJSJnyqNG._003C_003E9.VidwbiQheMAscdxapVTkRMTTAjaOA);
		dYkoKUlGdrlOFWGHqCIyvCPfIUlM = new WYNKNWIFczeVHUyRjGlNScqXANMC[20];
	}

	public static void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
	{
		yRGqFQobqGcJzicFjfcRzWrKIMlH = 0;
		Array.Clear(dYkoKUlGdrlOFWGHqCIyvCPfIUlM, 0, dYkoKUlGdrlOFWGHqCIyvCPfIUlM.Length);
		rbhcKUclQkUwmrYEMpjLImUBFhbc.Clear();
	}

	public static WYNKNWIFczeVHUyRjGlNScqXANMC VjGNvPXHUExSrGcFIxHRneMhGBUk(int P_0)
	{
		for (int i = 0; i < yRGqFQobqGcJzicFjfcRzWrKIMlH; i++)
		{
			if (dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i] != null && dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i].unVfCqoeDCEJeDyociDfoLlVwjIRA == P_0)
			{
				return dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i];
			}
		}
		return null;
	}

	public static WYNKNWIFczeVHUyRjGlNScqXANMC ARtThZfcYFFcPpcOdDABFOcvJqddb(int P_0, KtsEclDDNAMtzXpypcdeiyHyEFolA P_1)
	{
		WYNKNWIFczeVHUyRjGlNScqXANMC wYNKNWIFczeVHUyRjGlNScqXANMC = VjGNvPXHUExSrGcFIxHRneMhGBUk(P_0);
		if (wYNKNWIFczeVHUyRjGlNScqXANMC != null)
		{
			return wYNKNWIFczeVHUyRjGlNScqXANMC;
		}
		wYNKNWIFczeVHUyRjGlNScqXANMC = rbhcKUclQkUwmrYEMpjLImUBFhbc.Get();
		wYNKNWIFczeVHUyRjGlNScqXANMC.akFcZMRBxxMvoxUzyuXkRTwgFiAL(P_0);
		wYNKNWIFczeVHUyRjGlNScqXANMC.oCYktUpYSAqYazDNkURaYKHUyQLe(ref P_1);
		wYNKNWIFczeVHUyRjGlNScqXANMC.bFWxHBjQsxHuYvNjQgQHYwACscWA.SetUpdateLoop(ReInput.currentUpdateLoop);
		kLUccTxFNGtAdVZIzfhQztvGanwO(wYNKNWIFczeVHUyRjGlNScqXANMC);
		return wYNKNWIFczeVHUyRjGlNScqXANMC;
	}

	public static void JWFebvhzvQAAorlOmNEaEKvHKbdFA(UpdateLoopType P_0)
	{
		for (int i = 0; i < yRGqFQobqGcJzicFjfcRzWrKIMlH; i++)
		{
			if (dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i] != null)
			{
				dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i].DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0);
			}
		}
	}

	public static void bGmoUimdmfdGLWSXOgeEiOJuUsWfA(UpdateLoopType P_0, uint P_1)
	{
		for (int num = yRGqFQobqGcJzicFjfcRzWrKIMlH - 1; num >= 0; num--)
		{
			if (dYkoKUlGdrlOFWGHqCIyvCPfIUlM[num] == null)
			{
				if (num == yRGqFQobqGcJzicFjfcRzWrKIMlH - 1)
				{
					yRGqFQobqGcJzicFjfcRzWrKIMlH--;
				}
			}
			else
			{
				dYkoKUlGdrlOFWGHqCIyvCPfIUlM[num].bGmoUimdmfdGLWSXOgeEiOJuUsWfA(P_1);
				if (!dYkoKUlGdrlOFWGHqCIyvCPfIUlM[num].ZxzEvLaKwNhveXxXvUHUuKyEDzKz)
				{
					ejspFHxkGGGpqToNLvcEsujiiuyl(num);
				}
			}
		}
	}

	private static void kLUccTxFNGtAdVZIzfhQztvGanwO(WYNKNWIFczeVHUyRjGlNScqXANMC P_0)
	{
		int num = cQqxaEmpqhBglQRSlIJedYsYYvPm();
		if (num < 0)
		{
			if (yRGqFQobqGcJzicFjfcRzWrKIMlH == dYkoKUlGdrlOFWGHqCIyvCPfIUlM.Length)
			{
				WYNKNWIFczeVHUyRjGlNScqXANMC[] array = dYkoKUlGdrlOFWGHqCIyvCPfIUlM;
				dYkoKUlGdrlOFWGHqCIyvCPfIUlM = new WYNKNWIFczeVHUyRjGlNScqXANMC[dYkoKUlGdrlOFWGHqCIyvCPfIUlM.Length + 10];
				Array.Copy(array, dYkoKUlGdrlOFWGHqCIyvCPfIUlM, array.Length);
			}
			num = yRGqFQobqGcJzicFjfcRzWrKIMlH;
			yRGqFQobqGcJzicFjfcRzWrKIMlH++;
		}
		dYkoKUlGdrlOFWGHqCIyvCPfIUlM[num] = P_0;
	}

	private static void ejspFHxkGGGpqToNLvcEsujiiuyl(int P_0)
	{
		if (P_0 >= 0 && P_0 < yRGqFQobqGcJzicFjfcRzWrKIMlH)
		{
			WYNKNWIFczeVHUyRjGlNScqXANMC wYNKNWIFczeVHUyRjGlNScqXANMC = dYkoKUlGdrlOFWGHqCIyvCPfIUlM[P_0];
			if (wYNKNWIFczeVHUyRjGlNScqXANMC != null)
			{
				rbhcKUclQkUwmrYEMpjLImUBFhbc.Return(wYNKNWIFczeVHUyRjGlNScqXANMC);
				dYkoKUlGdrlOFWGHqCIyvCPfIUlM[P_0] = null;
			}
			if (P_0 == yRGqFQobqGcJzicFjfcRzWrKIMlH - 1)
			{
				yRGqFQobqGcJzicFjfcRzWrKIMlH--;
			}
		}
	}

	private static int cQqxaEmpqhBglQRSlIJedYsYYvPm()
	{
		for (int i = 0; i < yRGqFQobqGcJzicFjfcRzWrKIMlH; i++)
		{
			if (dYkoKUlGdrlOFWGHqCIyvCPfIUlM[i] == null)
			{
				return i;
			}
		}
		if (yRGqFQobqGcJzicFjfcRzWrKIMlH >= dYkoKUlGdrlOFWGHqCIyvCPfIUlM.Length)
		{
			return -1;
		}
		int result = yRGqFQobqGcJzicFjfcRzWrKIMlH;
		yRGqFQobqGcJzicFjfcRzWrKIMlH++;
		return result;
	}

	public ButtonStateFlags xlyWqlnToOPAbVjNGAzzNUGWChIEA(bool P_0)
	{
		return bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.xlyWqlnToOPAbVjNGAzzNUGWChIEA(P_0);
	}

	public WYNKNWIFczeVHUyRjGlNScqXANMC()
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA = new UpdateLoopDataSet<AFOuqHHBYRFCPMZFVTQeccBeGtYm>(ReInput.UserData.ConfigVars.updateLoop, QgUtMReIFNRJdKrxcVhJSJnyqNG._003C_003E9.pdXHCrJUTndRsfAkyuMTKmWIlNol);
		wJjPIIRJfHhEbGedUconecGfiwzgB();
	}

	public void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA.SetUpdateLoop(P_0);
		bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.DsDuSUaDcVanpNAhDLIRqjKndMGi();
	}

	public void bGmoUimdmfdGLWSXOgeEiOJuUsWfA(uint P_0)
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.bGmoUimdmfdGLWSXOgeEiOJuUsWfA(P_0);
	}

	public void pPkAjWcjXawKVDbcOlwBbFlvXJDA(UpdateLoopType P_0, bool P_1)
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.pPkAjWcjXawKVDbcOlwBbFlvXJDA(P_1);
	}

	public void fytesVmSgMdEYCdUSfupqQQYLxEPA(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA.Current.fytesVmSgMdEYCdUSfupqQQYLxEPA(P_1, P_2);
	}

	private void oCYktUpYSAqYazDNkURaYKHUyQLe(ref KtsEclDDNAMtzXpypcdeiyHyEFolA P_0)
	{
		int count = bFWxHBjQsxHuYvNjQgQHYwACscWA.Count;
		for (int i = 0; i < count; i++)
		{
			bFWxHBjQsxHuYvNjQgQHYwACscWA[i].oCYktUpYSAqYazDNkURaYKHUyQLe(ref P_0);
		}
	}

	private void akFcZMRBxxMvoxUzyuXkRTwgFiAL(int P_0)
	{
		unVfCqoeDCEJeDyociDfoLlVwjIRA = P_0;
	}

	private void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		unVfCqoeDCEJeDyociDfoLlVwjIRA = -1;
		int count = bFWxHBjQsxHuYvNjQgQHYwACscWA.Count;
		for (int i = 0; i < count; i++)
		{
			bFWxHBjQsxHuYvNjQgQHYwACscWA[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
		}
	}
}
