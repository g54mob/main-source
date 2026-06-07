using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Libraries.SharpDX.Windows.Forms;
using Rewired.Utils;
using UnityEngine;

internal class fhbpHHFIYHRXRDKbVpCLsduWompt : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	private class znNHfSBEHgotVICPWZhTLjDJmpAD
	{
		private enum cunezeEyiozzseOUHucinwMILaDMA
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int dhpVUCdUJDQwALNQmYDbEClwdzSO = 2;

		private static readonly KeyCode[] XVNRTcWfjLEmdNtpsFkbEGJJNgOU = new KeyCode[2];

		private readonly UpdateLoopType nNJCdMHiMApJQbsjjCqsdxbZfOZpb;

		private bool[] rylvWOFcUqSrVidcifoxejyvdnXm;

		private bool[] FlVNGUDCCQiLKAQNJaAHpzphMzTb;

		private uint NwicalvHGCysWYYPzCxgmrFwJKpT;

		public znNHfSBEHgotVICPWZhTLjDJmpAD(UpdateLoopType P_0)
		{
			nNJCdMHiMApJQbsjjCqsdxbZfOZpb = P_0;
			rylvWOFcUqSrVidcifoxejyvdnXm = new bool[132];
			FlVNGUDCCQiLKAQNJaAHpzphMzTb = new bool[132];
		}

		public void xbhDuqUZjucbfuYYNuFAHkqKGnoDA(xLqoCUFzeuaUtTowffsTsLggiDSO P_0)
		{
			int num = YoxtDILjZIBFGUYVSTclqRsaEeUU(P_0, XVNRTcWfjLEmdNtpsFkbEGJJNgOU);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)XVNRTcWfjLEmdNtpsFkbEGJJNgOU[i];
				if (num2 >= 0 && num2 < tEahzvQHhYWqMiLRBDMmWglFtlOj.Length)
				{
					KeyState jbMsKIwUEuIcJmgRcuQrKBrJfLPJ = P_0.jbMsKIwUEuIcJmgRcuQrKBrJfLPJ;
					bool flag = ((jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.KeyFirst || jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.SystemKeyDown) ? true : false);
					int num3 = tEahzvQHhYWqMiLRBDMmWglFtlOj[num2];
					bool num4 = rylvWOFcUqSrVidcifoxejyvdnXm[num3];
					rylvWOFcUqSrVidcifoxejyvdnXm[num3] = flag;
					if (!num4 && flag)
					{
						FlVNGUDCCQiLKAQNJaAHpzphMzTb[num3] = true;
					}
				}
			}
		}

		public void RbipbJZdrLEeNlicewsGWIGRRyIQ(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = rylvWOFcUqSrVidcifoxejyvdnXm[i] || FlVNGUDCCQiLKAQNJaAHpzphMzTb[i];
			}
			lROqffArJVZbGMoJDFwNneYSOZkm();
		}

		public void XQZqEkbqPKyheYtDzEKFkDWlqlhJ()
		{
			lROqffArJVZbGMoJDFwNneYSOZkm();
		}

		private void lROqffArJVZbGMoJDFwNneYSOZkm()
		{
			if (NwicalvHGCysWYYPzCxgmrFwJKpT != ReInput.absFrame)
			{
				tIdrlzeVVKtJtTJdeCALHrqylIscb();
				NwicalvHGCysWYYPzCxgmrFwJKpT = ReInput.absFrame;
			}
		}

		public void tIdrlzeVVKtJtTJdeCALHrqylIscb()
		{
			Array.Clear(FlVNGUDCCQiLKAQNJaAHpzphMzTb, 0, 132);
		}

		public void ombhfJDJGrkHJioHJxTIDEkhLzESD()
		{
			Array.Clear(rylvWOFcUqSrVidcifoxejyvdnXm, 0, 132);
			Array.Clear(FlVNGUDCCQiLKAQNJaAHpzphMzTb, 0, 132);
		}
	}

	private const int YNUFmSOQcXzeVGQolxYhaIHvhxNR = 132;

	private const int eiVCjfBoPinhpytxmictxdMhTBuN = 256;

	private readonly object fKSsTaPTjegZnYBQZBxvfslPyBlnA = new object();

	private UpdateLoopDataSet<znNHfSBEHgotVICPWZhTLjDJmpAD> kOqKTtvgmXEdjLTiCUSxztMmFVjq;

	private HardwareControllerMap_Game qHocMPoxlriEonrsOVWTLrWTRqpJ;

	private bool jHkttkANmEkFMCTZgerIAXvEUSPr;

	private int zSEGIWkRGskNoDXPYOFMPQCxAKOo;

	private bool[] EnbTscRRZeRTdngjrodMJQhenmoh = new bool[256];

	private readonly xLqoCUFzeuaUtTowffsTsLggiDSO vKtCdNCVAUbDWIEAYaNkMQisfypOA = new xLqoCUFzeuaUtTowffsTsLggiDSO();

	private bool uHyAGhgEVFycqNnKycTuoUJLOZEQ;

	private static readonly int[] tEahzvQHhYWqMiLRBDMmWglFtlOj;

	private static readonly int VyWCgqieJBmwLxgdqztsyRQhczox;

	private bool yxlSuTobwJGVBBpzrraQocussrpnA;

	private static IntPtr tNlGMLlDGWoDyAPTGZliKECbENpE;

	private static FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb JCjcqjsUwNtZRhFExIwogYNkrlDy;

	private static readonly int[] TXBckzEXMbxCrMZRFkJCoHrCzqEkA;

	private static Dictionary<int, Dictionary<int, KeyCode>> qIrMcyiznqDVEHGnZARlvaXitAib;

	private static readonly int[] TknTmgHDzLYLmggvosbcDDhRtGkv;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return uHyAGhgEVFycqNnKycTuoUJLOZEQ;
		}
		set
		{
			if (uHyAGhgEVFycqNnKycTuoUJLOZEQ != value)
			{
				uHyAGhgEVFycqNnKycTuoUJLOZEQ = value;
			}
		}
	}

	InputSource IUnifiedKeyboardSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap
	{
		get
		{
			if (qHocMPoxlriEonrsOVWTLrWTRqpJ == null)
			{
				qHocMPoxlriEonrsOVWTLrWTRqpJ = fOfDThHJPbCVFryiMTpsoGhCymmsA();
			}
			return qHocMPoxlriEonrsOVWTLrWTRqpJ;
		}
	}

	int IUnifiedKeyboardSource.buttonCount => 132;

	Controller.Extension IUnifiedKeyboardSource.controllerExtension => null;

	static fhbpHHFIYHRXRDKbVpCLsduWompt()
	{
		JCjcqjsUwNtZRhFExIwogYNkrlDy = FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb.United_States_English;
		TXBckzEXMbxCrMZRFkJCoHrCzqEkA = (int[])Enum.GetValues(typeof(FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb));
		qIrMcyiznqDVEHGnZARlvaXitAib = new Dictionary<int, Dictionary<int, KeyCode>>
		{
			{
				1033,
				new Dictionary<int, KeyCode>
				{
					{
						222,
						KeyCode.Quote
					},
					{
						188,
						KeyCode.Comma
					},
					{
						189,
						KeyCode.Minus
					},
					{
						190,
						KeyCode.Period
					},
					{
						191,
						KeyCode.Slash
					},
					{
						186,
						KeyCode.Semicolon
					},
					{
						187,
						KeyCode.Equals
					},
					{
						219,
						KeyCode.LeftBracket
					},
					{
						220,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.RightBracket
					},
					{
						192,
						KeyCode.BackQuote
					},
					{
						223,
						KeyCode.BackQuote
					}
				}
			},
			{
				2057,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1106,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1031,
				new Dictionary<int, KeyCode>
				{
					{
						219,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.BackQuote
					}
				}
			}
		};
		TknTmgHDzLYLmggvosbcDDhRtGkv = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > VyWCgqieJBmwLxgdqztsyRQhczox)
			{
				VyWCgqieJBmwLxgdqztsyRQhczox = keyboardKeyValues[i];
			}
		}
		tEahzvQHhYWqMiLRBDMmWglFtlOj = new int[VyWCgqieJBmwLxgdqztsyRQhczox + 1];
		ArrayTools.Fill(tEahzvQHhYWqMiLRBDMmWglFtlOj, -1);
		for (int j = 0; j < num; j++)
		{
			tEahzvQHhYWqMiLRBDMmWglFtlOj[keyboardKeyValues[j]] = j;
		}
	}

	public fhbpHHFIYHRXRDKbVpCLsduWompt(UpdateLoopSetting P_0)
	{
		nApjEVHpTYhZFadlEkWVlLwIJQyx();
		kOqKTtvgmXEdjLTiCUSxztMmFVjq = new UpdateLoopDataSet<znNHfSBEHgotVICPWZhTLjDJmpAD>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				kOqKTtvgmXEdjLTiCUSxztMmFVjq[i] = new znNHfSBEHgotVICPWZhTLjDJmpAD(list[i]);
			}
		}
		jHkttkANmEkFMCTZgerIAXvEUSPr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.ApplicationFocusChangedEvent += MzXAVSeQyStDRiarGjDPCgrODYvAA;
		ReInput.EditorPauseChangedEvent += qwVoLDvRVPCSgudldpSCcPUVOnwc;
		ReInput.UpdateEndedEvent += ZLjLLBgSocAWWjojrtUFrbinCJgKA;
		ReInput.TimeScalePauseChangedEvent += LRBErTwrjoVjXABbhsBVpSuQyIV;
	}

	public unsafe void vYxJSkWXrdRMYRXzLSvOumiQkpdr(UpdateLoopType P_0)
	{
		kOqKTtvgmXEdjLTiCUSxztMmFVjq.SetUpdateLoop(P_0);
		jHkttkANmEkFMCTZgerIAXvEUSPr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (fKSsTaPTjegZnYBQZBxvfslPyBlnA)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!FTdbbIUhAgYSHUHmiEJUirkRZXhf.BOkQoSxVneNJqEahjdOPfVxqsYALA((IntPtr)ptr))
				{
					return;
				}
				for (int i = 0; i < 256; i++)
				{
					switch (i)
					{
					case 1:
					case 2:
					case 4:
					case 5:
					case 6:
					case 16:
					case 17:
					case 18:
					case 65536:
					case 131072:
						continue;
					}
					if ((ptr[i] & 0x80) == 0)
					{
						if (EnbTscRRZeRTdngjrodMJQhenmoh[i])
						{
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.pYyznFfnigkzNNWEikhsAoGrtSsk();
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.NPloAlyQKWGZhIkxiLZcawQAaCBi = ReInput.realTime;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.fvNmfcOcheJbzRbNDsRmcyRyCrVn = IntPtr.Zero;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.RejlMfvnwTgZMrBzZwgikPwJNUsu = (Keys)i;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.aMVYeZZxlMDWHpdtMUyRGkeeHoKy = 0;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.PyyGuDDTHmDOOQnbtpFrzOLSWfDn = ScanCodeFlags.Break;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.jbMsKIwUEuIcJmgRcuQrKBrJfLPJ = KeyState.KeyUp;
							vKtCdNCVAUbDWIEAYaNkMQisfypOA.qPIBsykiiwtvBCjfvqqtXuvOoBALA = 0;
							ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(vKtCdNCVAUbDWIEAYaNkMQisfypOA);
						}
					}
					else if (!EnbTscRRZeRTdngjrodMJQhenmoh[i])
					{
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.pYyznFfnigkzNNWEikhsAoGrtSsk();
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.NPloAlyQKWGZhIkxiLZcawQAaCBi = ReInput.realTime;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.fvNmfcOcheJbzRbNDsRmcyRyCrVn = IntPtr.Zero;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.RejlMfvnwTgZMrBzZwgikPwJNUsu = (Keys)i;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.aMVYeZZxlMDWHpdtMUyRGkeeHoKy = 0;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.PyyGuDDTHmDOOQnbtpFrzOLSWfDn = ScanCodeFlags.Make;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.jbMsKIwUEuIcJmgRcuQrKBrJfLPJ = KeyState.KeyFirst;
						vKtCdNCVAUbDWIEAYaNkMQisfypOA.qPIBsykiiwtvBCjfvqqtXuvOoBALA = 0;
						ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(vKtCdNCVAUbDWIEAYaNkMQisfypOA);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(xLqoCUFzeuaUtTowffsTsLggiDSO P_0)
	{
		if (!jHkttkANmEkFMCTZgerIAXvEUSPr)
		{
			return;
		}
		switch (P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu)
		{
		case Keys.ControlKey:
		{
			Keys keys = (Keys)FTdbbIUhAgYSHUHmiEJUirkRZXhf.dDebsAIlMEPVChQfqALazNYNcBqbb((uint)P_0.aMVYeZZxlMDWHpdtMUyRGkeeHoKy, FctNbXZaNPcyhHCDrwfgVeJXGxBEA.lslRnnklhDyMXjRALTcomEDoICcKA);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = (((P_0.PyyGuDDTHmDOOQnbtpFrzOLSWfDn & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = (((P_0.PyyGuDDTHmDOOQnbtpFrzOLSWfDn & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		case Keys.ShiftKey:
		{
			P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = (Keys)FTdbbIUhAgYSHUHmiEJUirkRZXhf.dDebsAIlMEPVChQfqALazNYNcBqbb((uint)P_0.aMVYeZZxlMDWHpdtMUyRGkeeHoKy, FctNbXZaNPcyhHCDrwfgVeJXGxBEA.lslRnnklhDyMXjRALTcomEDoICcKA);
			if (P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu == Keys.LShiftKey || P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu == Keys.RShiftKey)
			{
				break;
			}
			KeyState jbMsKIwUEuIcJmgRcuQrKBrJfLPJ = P_0.jbMsKIwUEuIcJmgRcuQrKBrJfLPJ;
			bool flag = ((jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.KeyFirst || jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.SystemKeyDown || jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.KeyLast) ? true : false);
			bool flag2 = (FTdbbIUhAgYSHUHmiEJUirkRZXhf.IatHGQiOBEaetDmWFLthvQVmgcKg(160) & 0x8000) != 0;
			bool flag3 = (FTdbbIUhAgYSHUHmiEJUirkRZXhf.IatHGQiOBEaetDmWFLthvQVmgcKg(161) & 0x8000) != 0;
			if (flag)
			{
				bool num = (FTdbbIUhAgYSHUHmiEJUirkRZXhf.WKRCGfzHIhGpixXCgXSQEDqBtKfx(160) & 0x8000) != 0;
				bool flag4 = (FTdbbIUhAgYSHUHmiEJUirkRZXhf.WKRCGfzHIhGpixXCgXSQEDqBtKfx(161) & 0x8000) != 0;
				if (num)
				{
					P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.LShiftKey;
					ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(P_0);
				}
				if (flag4)
				{
					P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.RShiftKey;
					ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.LShiftKey;
				break;
			}
			if (flag3)
			{
				P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.RShiftKey;
				break;
			}
			P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.LShiftKey;
			ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(P_0);
			P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu = Keys.RShiftKey;
			ZYEipFgAcGsCtoPhRFrYHMZZeNwQ(P_0);
			return;
		}
		}
		lock (fKSsTaPTjegZnYBQZBxvfslPyBlnA)
		{
			KeyState jbMsKIwUEuIcJmgRcuQrKBrJfLPJ = P_0.jbMsKIwUEuIcJmgRcuQrKBrJfLPJ;
			if (jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.KeyFirst || jbMsKIwUEuIcJmgRcuQrKBrJfLPJ == KeyState.SystemKeyDown)
			{
				EnbTscRRZeRTdngjrodMJQhenmoh[(int)P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu] = true;
			}
			else
			{
				EnbTscRRZeRTdngjrodMJQhenmoh[(int)P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu] = false;
			}
			int count = kOqKTtvgmXEdjLTiCUSxztMmFVjq.Count;
			for (int i = 0; i < count; i++)
			{
				kOqKTtvgmXEdjLTiCUSxztMmFVjq[i].xbhDuqUZjucbfuYYNuFAHkqKGnoDA(P_0);
			}
		}
	}

	public void JUGfktbHGnxcVtCBJDrjPzmjReTE(bool P_0)
	{
		XdwzyjXwUrOBbDImmHKeCzMsZVR();
	}

	public void yLPqUbyFIGaSxRCoGStzapsAcPJf(bool P_0)
	{
		if (nApjEVHpTYhZFadlEkWVlLwIJQyx() < 0)
		{
			XdwzyjXwUrOBbDImmHKeCzMsZVR();
		}
	}

	private int nApjEVHpTYhZFadlEkWVlLwIJQyx()
	{
		int num = zSEGIWkRGskNoDXPYOFMPQCxAKOo;
		if (PtZxJDakPjxrloDZyiNQFrvDzsve.vROsnIXqeeoCUOomBOuBQWADDgAT(HLIHggermciamhEKNxfavGKToBMk.Keyboard, out var num2))
		{
			zSEGIWkRGskNoDXPYOFMPQCxAKOo = num2;
		}
		else
		{
			zSEGIWkRGskNoDXPYOFMPQCxAKOo = 1;
		}
		return zSEGIWkRGskNoDXPYOFMPQCxAKOo - num;
	}

	private void MzXAVSeQyStDRiarGjDPCgrODYvAA(bool P_0)
	{
		jHkttkANmEkFMCTZgerIAXvEUSPr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !jHkttkANmEkFMCTZgerIAXvEUSPr)
		{
			XdwzyjXwUrOBbDImmHKeCzMsZVR();
		}
	}

	private void qwVoLDvRVPCSgudldpSCcPUVOnwc(bool P_0)
	{
	}

	private void LRBErTwrjoVjXABbhsBVpSuQyIV(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		jHkttkANmEkFMCTZgerIAXvEUSPr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (fKSsTaPTjegZnYBQZBxvfslPyBlnA)
		{
			kOqKTtvgmXEdjLTiCUSxztMmFVjq[kOqKTtvgmXEdjLTiCUSxztMmFVjq.fixedUpdateSetIndex].tIdrlzeVVKtJtTJdeCALHrqylIscb();
		}
	}

	private void ZLjLLBgSocAWWjojrtUFrbinCJgKA(UpdateLoopType P_0)
	{
		lock (fKSsTaPTjegZnYBQZBxvfslPyBlnA)
		{
			kOqKTtvgmXEdjLTiCUSxztMmFVjq.Get(P_0).XQZqEkbqPKyheYtDzEKFkDWlqlhJ();
		}
	}

	private void XdwzyjXwUrOBbDImmHKeCzMsZVR()
	{
		lock (fKSsTaPTjegZnYBQZBxvfslPyBlnA)
		{
			int count = kOqKTtvgmXEdjLTiCUSxztMmFVjq.Count;
			for (int i = 0; i < count; i++)
			{
				kOqKTtvgmXEdjLTiCUSxztMmFVjq[i].ombhfJDJGrkHJioHJxTIDEkhLzESD();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		kOqKTtvgmXEdjLTiCUSxztMmFVjq.Current.RbipbJZdrLEeNlicewsGWIGRRyIQ(dataUpdater);
	}

	void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		XdwzyjXwUrOBbDImmHKeCzMsZVR();
	}

	void IUnifiedKeyboardSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private static HardwareControllerMap_Game fOfDThHJPbCVFryiMTpsoGhCymmsA()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].id;
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	public void Dispose()
	{
		SqfifslZAmfVfqJWPHoCFtTShrZo(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void RtlCLzZszqqBeNzCyYjIbvIFMXsG()
	{
		try
		{
			SqfifslZAmfVfqJWPHoCFtTShrZo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void SqfifslZAmfVfqJWPHoCFtTShrZo(bool P_0)
	{
		if (!yxlSuTobwJGVBBpzrraQocussrpnA)
		{
			ReInput.ApplicationFocusChangedEvent -= MzXAVSeQyStDRiarGjDPCgrODYvAA;
			ReInput.EditorPauseChangedEvent -= qwVoLDvRVPCSgudldpSCcPUVOnwc;
			ReInput.UpdateEndedEvent -= ZLjLLBgSocAWWjojrtUFrbinCJgKA;
			ReInput.TimeScalePauseChangedEvent -= LRBErTwrjoVjXABbhsBVpSuQyIV;
			yxlSuTobwJGVBBpzrraQocussrpnA = true;
		}
	}

	public static int YoxtDILjZIBFGUYVSTclqRsaEeUU(xLqoCUFzeuaUtTowffsTsLggiDSO P_0, KeyCode[] P_1)
	{
		Keys rejlMfvnwTgZMrBzZwgikPwJNUsu = P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu;
		int result = 0;
		FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb bjTYAoNegaIUjBxZcIveLcunaAJcb = PUiMgHvEenBsMZVMvPpjGSYNslEv();
		_ = tNlGMLlDGWoDyAPTGZliKECbENpE;
		FTdbbIUhAgYSHUHmiEJUirkRZXhf.dDebsAIlMEPVChQfqALazNYNcBqbb((uint)P_0.RejlMfvnwTgZMrBzZwgikPwJNUsu, FctNbXZaNPcyhHCDrwfgVeJXGxBEA.zMeZWHMaCcNFRCLvPVWLKYVANvfv);
		if (ujRoJmkfdrZipNZJTLJeuVWBSGXQ(rejlMfvnwTgZMrBzZwgikPwJNUsu))
		{
			if (fRxeRHejdAVDsFYeOJnFQWnLflwg(rejlMfvnwTgZMrBzZwgikPwJNUsu, bjTYAoNegaIUjBxZcIveLcunaAJcb, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (rejlMfvnwTgZMrBzZwgikPwJNUsu)
			{
			case Keys.None:
				P_1[result++] = KeyCode.None;
				break;
			case Keys.A:
				P_1[result++] = KeyCode.A;
				break;
			case Keys.B:
				P_1[result++] = KeyCode.B;
				break;
			case Keys.C:
				P_1[result++] = KeyCode.C;
				break;
			case Keys.D:
				P_1[result++] = KeyCode.D;
				break;
			case Keys.E:
				P_1[result++] = KeyCode.E;
				break;
			case Keys.F:
				P_1[result++] = KeyCode.F;
				break;
			case Keys.G:
				P_1[result++] = KeyCode.G;
				break;
			case Keys.H:
				P_1[result++] = KeyCode.H;
				break;
			case Keys.I:
				P_1[result++] = KeyCode.I;
				break;
			case Keys.J:
				P_1[result++] = KeyCode.J;
				break;
			case Keys.K:
				P_1[result++] = KeyCode.K;
				break;
			case Keys.L:
				P_1[result++] = KeyCode.L;
				break;
			case Keys.M:
				P_1[result++] = KeyCode.M;
				break;
			case Keys.N:
				P_1[result++] = KeyCode.N;
				break;
			case Keys.O:
				P_1[result++] = KeyCode.O;
				break;
			case Keys.P:
				P_1[result++] = KeyCode.P;
				break;
			case Keys.Q:
				P_1[result++] = KeyCode.Q;
				break;
			case Keys.R:
				P_1[result++] = KeyCode.R;
				break;
			case Keys.S:
				P_1[result++] = KeyCode.S;
				break;
			case Keys.T:
				P_1[result++] = KeyCode.T;
				break;
			case Keys.U:
				P_1[result++] = KeyCode.U;
				break;
			case Keys.V:
				P_1[result++] = KeyCode.V;
				break;
			case Keys.W:
				P_1[result++] = KeyCode.W;
				break;
			case Keys.X:
				P_1[result++] = KeyCode.X;
				break;
			case Keys.Y:
				P_1[result++] = KeyCode.Y;
				break;
			case Keys.Z:
				P_1[result++] = KeyCode.Z;
				break;
			case Keys.D0:
				P_1[result++] = KeyCode.Alpha0;
				break;
			case Keys.D1:
				P_1[result++] = KeyCode.Alpha1;
				break;
			case Keys.D2:
				P_1[result++] = KeyCode.Alpha2;
				break;
			case Keys.D3:
				P_1[result++] = KeyCode.Alpha3;
				break;
			case Keys.D4:
				P_1[result++] = KeyCode.Alpha4;
				break;
			case Keys.D5:
				P_1[result++] = KeyCode.Alpha5;
				break;
			case Keys.D6:
				P_1[result++] = KeyCode.Alpha6;
				break;
			case Keys.D7:
				P_1[result++] = KeyCode.Alpha7;
				break;
			case Keys.D8:
				P_1[result++] = KeyCode.Alpha8;
				break;
			case Keys.D9:
				P_1[result++] = KeyCode.Alpha9;
				break;
			case Keys.NumPad0:
				P_1[result++] = KeyCode.Keypad0;
				break;
			case Keys.NumPad1:
				P_1[result++] = KeyCode.Keypad1;
				break;
			case Keys.NumPad2:
				P_1[result++] = KeyCode.Keypad2;
				break;
			case Keys.NumPad3:
				P_1[result++] = KeyCode.Keypad3;
				break;
			case Keys.NumPad4:
				P_1[result++] = KeyCode.Keypad4;
				break;
			case Keys.NumPad5:
				P_1[result++] = KeyCode.Keypad5;
				break;
			case Keys.NumPad6:
				P_1[result++] = KeyCode.Keypad6;
				break;
			case Keys.NumPad7:
				P_1[result++] = KeyCode.Keypad7;
				break;
			case Keys.NumPad8:
				P_1[result++] = KeyCode.Keypad8;
				break;
			case Keys.NumPad9:
				P_1[result++] = KeyCode.Keypad9;
				break;
			case Keys.Decimal:
				P_1[result++] = KeyCode.KeypadPeriod;
				break;
			case Keys.Divide:
				P_1[result++] = KeyCode.KeypadDivide;
				break;
			case Keys.Multiply:
				P_1[result++] = KeyCode.KeypadMultiply;
				break;
			case Keys.Subtract:
				P_1[result++] = KeyCode.KeypadMinus;
				break;
			case Keys.Add:
				P_1[result++] = KeyCode.KeypadPlus;
				break;
			case Keys.Return:
				if ((P_0.PyyGuDDTHmDOOQnbtpFrzOLSWfDn & ScanCodeFlags.E0) != ScanCodeFlags.Make)
				{
					P_1[result++] = KeyCode.KeypadEnter;
				}
				else
				{
					P_1[result++] = KeyCode.Return;
				}
				break;
			case Keys.Back:
				P_1[result++] = KeyCode.Backspace;
				break;
			case Keys.Tab:
				P_1[result++] = KeyCode.Tab;
				break;
			case Keys.Clear:
				P_1[result++] = KeyCode.Clear;
				break;
			case Keys.Pause:
				P_1[result++] = KeyCode.Pause;
				break;
			case Keys.Escape:
				P_1[result++] = KeyCode.Escape;
				break;
			case Keys.Space:
				P_1[result++] = KeyCode.Space;
				break;
			case Keys.Delete:
				P_1[result++] = KeyCode.Delete;
				break;
			case Keys.Up:
				P_1[result++] = KeyCode.UpArrow;
				break;
			case Keys.Down:
				P_1[result++] = KeyCode.DownArrow;
				break;
			case Keys.Right:
				P_1[result++] = KeyCode.RightArrow;
				break;
			case Keys.Left:
				P_1[result++] = KeyCode.LeftArrow;
				break;
			case Keys.Insert:
				P_1[result++] = KeyCode.Insert;
				break;
			case Keys.Home:
				P_1[result++] = KeyCode.Home;
				break;
			case Keys.End:
				P_1[result++] = KeyCode.End;
				break;
			case Keys.Prior:
				P_1[result++] = KeyCode.PageUp;
				break;
			case Keys.Next:
				P_1[result++] = KeyCode.PageDown;
				break;
			case Keys.F1:
				P_1[result++] = KeyCode.F1;
				break;
			case Keys.F2:
				P_1[result++] = KeyCode.F2;
				break;
			case Keys.F3:
				P_1[result++] = KeyCode.F3;
				break;
			case Keys.F4:
				P_1[result++] = KeyCode.F4;
				break;
			case Keys.F5:
				P_1[result++] = KeyCode.F5;
				break;
			case Keys.F6:
				P_1[result++] = KeyCode.F6;
				break;
			case Keys.F7:
				P_1[result++] = KeyCode.F7;
				break;
			case Keys.F8:
				P_1[result++] = KeyCode.F8;
				break;
			case Keys.F9:
				P_1[result++] = KeyCode.F9;
				break;
			case Keys.F10:
				P_1[result++] = KeyCode.F10;
				break;
			case Keys.F11:
				P_1[result++] = KeyCode.F11;
				break;
			case Keys.F12:
				P_1[result++] = KeyCode.F12;
				break;
			case Keys.F13:
				P_1[result++] = KeyCode.F13;
				break;
			case Keys.F14:
				P_1[result++] = KeyCode.F14;
				break;
			case Keys.F15:
				P_1[result++] = KeyCode.F15;
				break;
			case Keys.NumLock:
				P_1[result++] = KeyCode.Numlock;
				break;
			case Keys.Capital:
				P_1[result++] = KeyCode.CapsLock;
				break;
			case Keys.Scroll:
				P_1[result++] = KeyCode.ScrollLock;
				break;
			case Keys.RShiftKey:
				P_1[result++] = KeyCode.RightShift;
				break;
			case Keys.LShiftKey:
				P_1[result++] = KeyCode.LeftShift;
				break;
			case Keys.RControlKey:
				P_1[result++] = KeyCode.RightControl;
				break;
			case Keys.LControlKey:
				P_1[result++] = KeyCode.LeftControl;
				break;
			case Keys.RMenu:
				P_1[result++] = KeyCode.AltGr;
				P_1[result++] = KeyCode.RightAlt;
				break;
			case Keys.LMenu:
				P_1[result++] = KeyCode.LeftAlt;
				break;
			case Keys.RWin:
				P_1[result++] = KeyCode.RightMeta;
				break;
			case Keys.LWin:
				P_1[result++] = KeyCode.LeftMeta;
				break;
			case Keys.Help:
				P_1[result++] = KeyCode.Help;
				break;
			case Keys.Print:
				P_1[result++] = KeyCode.Print;
				break;
			case Keys.Apps:
				P_1[result++] = KeyCode.Menu;
				break;
			}
		}
		return result;
	}

	private unsafe static FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb PUiMgHvEenBsMZVMvPpjGSYNslEv()
	{
		IntPtr intPtr = FTdbbIUhAgYSHUHmiEJUirkRZXhf.BzrofXeFSfuNqrPJjrlvLOftusep(0);
		if (intPtr == tNlGMLlDGWoDyAPTGZliKECbENpE)
		{
			return JCjcqjsUwNtZRhFExIwogYNkrlDy;
		}
		FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb bjTYAoNegaIUjBxZcIveLcunaAJcb = FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb.United_States_English;
		byte* intPtr2 = stackalloc byte[128];
		FTdbbIUhAgYSHUHmiEJUirkRZXhf.bTgflcCSpupkYeBSSCMPUqapVYBE((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			int num = ArrayTools.IndexOf(TXBckzEXMbxCrMZRFkJCoHrCzqEkA, result);
			if (num >= 0)
			{
				bjTYAoNegaIUjBxZcIveLcunaAJcb = (FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb)TXBckzEXMbxCrMZRFkJCoHrCzqEkA[num];
			}
		}
		tNlGMLlDGWoDyAPTGZliKECbENpE = intPtr;
		JCjcqjsUwNtZRhFExIwogYNkrlDy = bjTYAoNegaIUjBxZcIveLcunaAJcb;
		return bjTYAoNegaIUjBxZcIveLcunaAJcb;
	}

	private static bool fRxeRHejdAVDsFYeOJnFQWnLflwg(Keys P_0, FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!qIrMcyiznqDVEHGnZARlvaXitAib.TryGetValue((int)P_1, out var value))
		{
			value = qIrMcyiznqDVEHGnZARlvaXitAib[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != FctNbXZaNPcyhHCDrwfgVeJXGxBEA.BjTYAoNegaIUjBxZcIveLcunaAJcb.United_States_English)
		{
			value = qIrMcyiznqDVEHGnZARlvaXitAib[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool ujRoJmkfdrZipNZJTLJeuVWBSGXQ(Keys P_0)
	{
		return ArrayTools.Contains(TknTmgHDzLYLmggvosbcDDhRtGkv, (int)P_0);
	}
}
