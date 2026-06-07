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

internal class gnWOnWzmgxFJvyBjJGkrgQPpkQDO : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	private class RbVsSIcgMaruhvcRksIfintWWdyG
	{
		private enum sjtCBBwjFJCrbHXUaIvnCIYycJplA
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int HcLULLGkLpaHpeOwlMjDbOdHGBCoB = 2;

		private static readonly KeyCode[] tyQnVeVqdtwwHztHOnOQHAekTQgs = new KeyCode[2];

		private readonly UpdateLoopType dTjaNMSXgPckJezZfeFDHZGRiMMeA;

		private bool[] pcXGhjHrGNvqFnFkaJerPXzKdlPw;

		private bool[] mGmyWegYeGnTHHEpuLTWLTZZFirt;

		private uint stHApxDzPspOUIMRolYaxfFvpFhcA;

		public RbVsSIcgMaruhvcRksIfintWWdyG(UpdateLoopType P_0)
		{
			dTjaNMSXgPckJezZfeFDHZGRiMMeA = P_0;
			pcXGhjHrGNvqFnFkaJerPXzKdlPw = new bool[132];
			mGmyWegYeGnTHHEpuLTWLTZZFirt = new bool[132];
		}

		public void QIJBiQIfVQEuFKhmashaSdgGyNaD(lXqhyLmCiKlksFNuxjbZrETGdxhz P_0)
		{
			int num = DMDMGNudKigUZCiWLEqOmRRRRoyuA(P_0, tyQnVeVqdtwwHztHOnOQHAekTQgs);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)tyQnVeVqdtwwHztHOnOQHAekTQgs[i];
				if (num2 >= 0 && num2 < NnAdgOHuFlMVNxBBBDfZuPfaYyYM.Length)
				{
					KeyState eEivaPrcBzzOQOOrGlfPCizKfmlgA = P_0.EEivaPrcBzzOQOOrGlfPCizKfmlgA;
					bool flag = ((eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.KeyFirst || eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.SystemKeyDown) ? true : false);
					int num3 = NnAdgOHuFlMVNxBBBDfZuPfaYyYM[num2];
					bool num4 = pcXGhjHrGNvqFnFkaJerPXzKdlPw[num3];
					pcXGhjHrGNvqFnFkaJerPXzKdlPw[num3] = flag;
					if (!num4 && flag)
					{
						mGmyWegYeGnTHHEpuLTWLTZZFirt[num3] = true;
					}
				}
			}
		}

		public void DbSuuwWOOsFkLOKmDHbBDgSipxNAb(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = pcXGhjHrGNvqFnFkaJerPXzKdlPw[i] || mGmyWegYeGnTHHEpuLTWLTZZFirt[i];
			}
			BRheMHCeqDCCMDgCHoEhoXXfGpps();
		}

		public void IvWrivXGNuPbeqjmZgoeBTezyARCA()
		{
			BRheMHCeqDCCMDgCHoEhoXXfGpps();
		}

		private void BRheMHCeqDCCMDgCHoEhoXXfGpps()
		{
			if (stHApxDzPspOUIMRolYaxfFvpFhcA != ReInput.absFrame)
			{
				tHzKaDFKXVcXWErNEsyXrvLTVNQG();
				stHApxDzPspOUIMRolYaxfFvpFhcA = ReInput.absFrame;
			}
		}

		public void tHzKaDFKXVcXWErNEsyXrvLTVNQG()
		{
			Array.Clear(mGmyWegYeGnTHHEpuLTWLTZZFirt, 0, 132);
		}

		public void mbZhqNniBgSmhwCjKMlBGUukOYQI()
		{
			Array.Clear(pcXGhjHrGNvqFnFkaJerPXzKdlPw, 0, 132);
			Array.Clear(mGmyWegYeGnTHHEpuLTWLTZZFirt, 0, 132);
		}
	}

	private const int KDRytbjXsKJqFEEQPmXzdLHIqrgW = 132;

	private const int FvEcPdNmLxCXgaCQemACxYyckoTeA = 256;

	private readonly object iBaDCYADSxhNlhNNglDYmpIvjKFeB = new object();

	private UpdateLoopDataSet<RbVsSIcgMaruhvcRksIfintWWdyG> MvsXnpfixmGHFdkGJnGkFOZuUmBe;

	private HardwareControllerMap_Game xRNNlbvLbaiGlfAiioQvdbqcwwMCA;

	private bool uqMuNyvpsVoSTEYbMbEbHIojkMPl;

	private int VFDLOcgHTrKLufsgWigausszoNeN;

	private bool[] HtNllDKJHIThEFHZqCpjiDgTXRot = new bool[256];

	private readonly lXqhyLmCiKlksFNuxjbZrETGdxhz gUaOZSLrSHQwzXcdMHRJXcXEwltn = new lXqhyLmCiKlksFNuxjbZrETGdxhz();

	private bool iFZfHlFzIZrokVUisryBGixAlesP;

	private static readonly int[] NnAdgOHuFlMVNxBBBDfZuPfaYyYM;

	private static readonly int gnLbUXDNzjVDOJuBdNEJlVClcySSA;

	private bool merfQobNpdQHSqgWWlOKXDEOHrRu;

	private static IntPtr LTGWKGsjQiAzRCcTQRWoxzmNAvbW;

	private static tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ QkaqpoxpguRSosrkfwApKKRHpHVu;

	private static readonly int[] TfCjFrGsPbEdmmGXCbNPOshriQSs;

	private static Dictionary<int, Dictionary<int, KeyCode>> rNzAnuublqvbCMUlnbpDJqeWFeul;

	private static readonly int[] HdkCLScstxMJLRlvGnEmffjZKwzmA;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return iFZfHlFzIZrokVUisryBGixAlesP;
		}
		set
		{
			if (iFZfHlFzIZrokVUisryBGixAlesP != value)
			{
				iFZfHlFzIZrokVUisryBGixAlesP = value;
			}
		}
	}

	InputSource IUnifiedKeyboardSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap
	{
		get
		{
			if (xRNNlbvLbaiGlfAiioQvdbqcwwMCA == null)
			{
				xRNNlbvLbaiGlfAiioQvdbqcwwMCA = mZkbGaeobTXbqkxKgwfCWwncTasEA();
			}
			return xRNNlbvLbaiGlfAiioQvdbqcwwMCA;
		}
	}

	int IUnifiedKeyboardSource.buttonCount => 132;

	Controller.Extension IUnifiedKeyboardSource.controllerExtension => null;

	static gnWOnWzmgxFJvyBjJGkrgQPpkQDO()
	{
		QkaqpoxpguRSosrkfwApKKRHpHVu = tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ.United_States_English;
		TfCjFrGsPbEdmmGXCbNPOshriQSs = (int[])Enum.GetValues(typeof(tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ));
		rNzAnuublqvbCMUlnbpDJqeWFeul = new Dictionary<int, Dictionary<int, KeyCode>>
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
		HdkCLScstxMJLRlvGnEmffjZKwzmA = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > gnLbUXDNzjVDOJuBdNEJlVClcySSA)
			{
				gnLbUXDNzjVDOJuBdNEJlVClcySSA = keyboardKeyValues[i];
			}
		}
		NnAdgOHuFlMVNxBBBDfZuPfaYyYM = new int[gnLbUXDNzjVDOJuBdNEJlVClcySSA + 1];
		ArrayTools.Fill(NnAdgOHuFlMVNxBBBDfZuPfaYyYM, -1);
		for (int j = 0; j < num; j++)
		{
			NnAdgOHuFlMVNxBBBDfZuPfaYyYM[keyboardKeyValues[j]] = j;
		}
	}

	public gnWOnWzmgxFJvyBjJGkrgQPpkQDO(UpdateLoopSetting P_0)
	{
		odwrTpgQGMWwAewEaDvWaPodHhrk();
		MvsXnpfixmGHFdkGJnGkFOZuUmBe = new UpdateLoopDataSet<RbVsSIcgMaruhvcRksIfintWWdyG>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				MvsXnpfixmGHFdkGJnGkFOZuUmBe[i] = new RbVsSIcgMaruhvcRksIfintWWdyG(list[i]);
			}
		}
		uqMuNyvpsVoSTEYbMbEbHIojkMPl = ReInput.IsInputAllowed(ControllerType.Keyboard);
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.ApplicationFocusChangedEvent += jLMXOYbcOUBtaNfOOtTwMvtaYYjc;
		ReInput.ApplicationPauseChangedEvent += XOlczPdbFEbvhwenxkIWlcDKOKPC;
		ReInput.EditorPauseChangedEvent += eOrKXbuayYfxJbfjScxZxpqMxzhw;
		ReInput.UpdateEndedEvent += PBgHsdZDiuAKvfOTEkrXhsKMyIGQA;
		ReInput.TimeScalePauseChangedEvent += EwczrKyNUKkGkJLtbBQHgzyqMaKs;
	}

	public unsafe void QFolINQnnncNzFWuYVgnuUAazhxv(UpdateLoopType P_0)
	{
		MvsXnpfixmGHFdkGJnGkFOZuUmBe.SetUpdateLoop(P_0);
		uqMuNyvpsVoSTEYbMbEbHIojkMPl = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (iBaDCYADSxhNlhNNglDYmpIvjKFeB)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!JUcffnbUUIpygcbMFvGmfZKcYwgXc.WfGDrWjxsmvamlkmOXePrLjYHhnN((IntPtr)ptr))
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
						if (HtNllDKJHIThEFHZqCpjiDgTXRot[i])
						{
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.LQXqvALMIteRdezexTEZsaYoxbKn();
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.mOrLyzOlkOAtaLSNFVOhcmMgbdOcA = ReInput.realTime;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.PmpqFWyBkdUXMlcJRmJQVVGNNAno = IntPtr.Zero;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.HTaVUnXVaEgTDWJTzZyTOAxztorg = (Keys)i;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.tfwYhTxyLvFZTZRdEkgUdzrvqepd = 0;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.uUcsSThpHkDbXiFZpqvqnVJOApBCA = ScanCodeFlags.Break;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.EEivaPrcBzzOQOOrGlfPCizKfmlgA = KeyState.KeyUp;
							gUaOZSLrSHQwzXcdMHRJXcXEwltn.gBlfJycXDugtHavHLYpWWWzzYgPGA = 0;
							odjaTyGVTdnXEuZFJhKkLZZbTtYD(gUaOZSLrSHQwzXcdMHRJXcXEwltn);
						}
					}
					else if (!HtNllDKJHIThEFHZqCpjiDgTXRot[i])
					{
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.LQXqvALMIteRdezexTEZsaYoxbKn();
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.mOrLyzOlkOAtaLSNFVOhcmMgbdOcA = ReInput.realTime;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.PmpqFWyBkdUXMlcJRmJQVVGNNAno = IntPtr.Zero;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.HTaVUnXVaEgTDWJTzZyTOAxztorg = (Keys)i;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.tfwYhTxyLvFZTZRdEkgUdzrvqepd = 0;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.uUcsSThpHkDbXiFZpqvqnVJOApBCA = ScanCodeFlags.Make;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.EEivaPrcBzzOQOOrGlfPCizKfmlgA = KeyState.KeyFirst;
						gUaOZSLrSHQwzXcdMHRJXcXEwltn.gBlfJycXDugtHavHLYpWWWzzYgPGA = 0;
						odjaTyGVTdnXEuZFJhKkLZZbTtYD(gUaOZSLrSHQwzXcdMHRJXcXEwltn);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void odjaTyGVTdnXEuZFJhKkLZZbTtYD(lXqhyLmCiKlksFNuxjbZrETGdxhz P_0)
	{
		if (!uqMuNyvpsVoSTEYbMbEbHIojkMPl)
		{
			return;
		}
		switch (P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg)
		{
		case Keys.ControlKey:
		{
			Keys keys = (Keys)JUcffnbUUIpygcbMFvGmfZKcYwgXc.BRAzViRHHVFTaSaLVTZGjXDliZpT((uint)P_0.tfwYhTxyLvFZTZRdEkgUdzrvqepd, tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.CMcAcnzEVLGAvEXqxPqTUfuzOzwD);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = (((P_0.uUcsSThpHkDbXiFZpqvqnVJOApBCA & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = (((P_0.uUcsSThpHkDbXiFZpqvqnVJOApBCA & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		case Keys.ShiftKey:
		{
			P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = (Keys)JUcffnbUUIpygcbMFvGmfZKcYwgXc.BRAzViRHHVFTaSaLVTZGjXDliZpT((uint)P_0.tfwYhTxyLvFZTZRdEkgUdzrvqepd, tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.CMcAcnzEVLGAvEXqxPqTUfuzOzwD);
			if (P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg == Keys.LShiftKey || P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg == Keys.RShiftKey)
			{
				break;
			}
			KeyState eEivaPrcBzzOQOOrGlfPCizKfmlgA = P_0.EEivaPrcBzzOQOOrGlfPCizKfmlgA;
			bool flag = ((eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.KeyFirst || eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.SystemKeyDown || eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.KeyLast) ? true : false);
			bool flag2 = (JUcffnbUUIpygcbMFvGmfZKcYwgXc.pLNUwfNDUIBQfDPJkFEPEwlIgeMOA(160) & 0x8000) != 0;
			bool flag3 = (JUcffnbUUIpygcbMFvGmfZKcYwgXc.pLNUwfNDUIBQfDPJkFEPEwlIgeMOA(161) & 0x8000) != 0;
			if (flag)
			{
				bool num = (JUcffnbUUIpygcbMFvGmfZKcYwgXc.mwTfkuCyCmiKMWDdfxhNwxHBxdDg(160) & 0x8000) != 0;
				bool flag4 = (JUcffnbUUIpygcbMFvGmfZKcYwgXc.mwTfkuCyCmiKMWDdfxhNwxHBxdDg(161) & 0x8000) != 0;
				if (num)
				{
					P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.LShiftKey;
					odjaTyGVTdnXEuZFJhKkLZZbTtYD(P_0);
				}
				if (flag4)
				{
					P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.RShiftKey;
					odjaTyGVTdnXEuZFJhKkLZZbTtYD(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.LShiftKey;
				break;
			}
			if (flag3)
			{
				P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.RShiftKey;
				break;
			}
			P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.LShiftKey;
			odjaTyGVTdnXEuZFJhKkLZZbTtYD(P_0);
			P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg = Keys.RShiftKey;
			odjaTyGVTdnXEuZFJhKkLZZbTtYD(P_0);
			return;
		}
		}
		lock (iBaDCYADSxhNlhNNglDYmpIvjKFeB)
		{
			KeyState eEivaPrcBzzOQOOrGlfPCizKfmlgA = P_0.EEivaPrcBzzOQOOrGlfPCizKfmlgA;
			if (eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.KeyFirst || eEivaPrcBzzOQOOrGlfPCizKfmlgA == KeyState.SystemKeyDown)
			{
				HtNllDKJHIThEFHZqCpjiDgTXRot[(int)P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg] = true;
			}
			else
			{
				HtNllDKJHIThEFHZqCpjiDgTXRot[(int)P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg] = false;
			}
			int count = MvsXnpfixmGHFdkGJnGkFOZuUmBe.Count;
			for (int i = 0; i < count; i++)
			{
				MvsXnpfixmGHFdkGJnGkFOZuUmBe[i].QIJBiQIfVQEuFKhmashaSdgGyNaD(P_0);
			}
		}
	}

	public void jyqAbTUCPQyOzDZSsiVVhpsLDbs(bool P_0)
	{
		bgVMEnbMVWaYgOwUJdMpISsyCOhb();
	}

	public void dpcLiTAkZVaACZQgQMXnzDcIJEXG(bool P_0)
	{
		if (odwrTpgQGMWwAewEaDvWaPodHhrk() < 0)
		{
			bgVMEnbMVWaYgOwUJdMpISsyCOhb();
		}
	}

	private int odwrTpgQGMWwAewEaDvWaPodHhrk()
	{
		int vFDLOcgHTrKLufsgWigausszoNeN = VFDLOcgHTrKLufsgWigausszoNeN;
		if (BqakktYRwNvnDKTTjDQXbTstkBmA.aFsxvkDaLokAiLPHthmvqQwtFeRFA(hEwPeXHtAVoNjNQkbBuyQaRHvVmt.Keyboard, out var vFDLOcgHTrKLufsgWigausszoNeN2))
		{
			VFDLOcgHTrKLufsgWigausszoNeN = vFDLOcgHTrKLufsgWigausszoNeN2;
		}
		else
		{
			VFDLOcgHTrKLufsgWigausszoNeN = 1;
		}
		return VFDLOcgHTrKLufsgWigausszoNeN - vFDLOcgHTrKLufsgWigausszoNeN;
	}

	private void jLMXOYbcOUBtaNfOOtTwMvtaYYjc(bool P_0)
	{
		uqMuNyvpsVoSTEYbMbEbHIojkMPl = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !uqMuNyvpsVoSTEYbMbEbHIojkMPl)
		{
			bgVMEnbMVWaYgOwUJdMpISsyCOhb();
		}
	}

	private void XOlczPdbFEbvhwenxkIWlcDKOKPC(bool P_0)
	{
		uqMuNyvpsVoSTEYbMbEbHIojkMPl = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!uqMuNyvpsVoSTEYbMbEbHIojkMPl)
		{
			bgVMEnbMVWaYgOwUJdMpISsyCOhb();
		}
	}

	private void eOrKXbuayYfxJbfjScxZxpqMxzhw(bool P_0)
	{
	}

	private void EwczrKyNUKkGkJLtbBQHgzyqMaKs(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		uqMuNyvpsVoSTEYbMbEbHIojkMPl = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (iBaDCYADSxhNlhNNglDYmpIvjKFeB)
		{
			MvsXnpfixmGHFdkGJnGkFOZuUmBe[MvsXnpfixmGHFdkGJnGkFOZuUmBe.fixedUpdateSetIndex].tHzKaDFKXVcXWErNEsyXrvLTVNQG();
		}
	}

	private void PBgHsdZDiuAKvfOTEkrXhsKMyIGQA(UpdateLoopType P_0)
	{
		lock (iBaDCYADSxhNlhNNglDYmpIvjKFeB)
		{
			MvsXnpfixmGHFdkGJnGkFOZuUmBe.Get(P_0).IvWrivXGNuPbeqjmZgoeBTezyARCA();
		}
	}

	private void bgVMEnbMVWaYgOwUJdMpISsyCOhb()
	{
		lock (iBaDCYADSxhNlhNNglDYmpIvjKFeB)
		{
			int count = MvsXnpfixmGHFdkGJnGkFOZuUmBe.Count;
			for (int i = 0; i < count; i++)
			{
				MvsXnpfixmGHFdkGJnGkFOZuUmBe[i].mbZhqNniBgSmhwCjKMlBGUukOYQI();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		MvsXnpfixmGHFdkGJnGkFOZuUmBe.Current.DbSuuwWOOsFkLOKmDHbBDgSipxNAb(dataUpdater);
	}

	void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		bgVMEnbMVWaYgOwUJdMpISsyCOhb();
	}

	void IUnifiedKeyboardSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private static HardwareControllerMap_Game mZkbGaeobTXbqkxKgwfCWwncTasEA()
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
		xQnnbcdqdaDiadMvFFzHAXAqfGKjA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void GqyEWHfSRAstnhcfGLXpUyrjrRs()
	{
		try
		{
			xQnnbcdqdaDiadMvFFzHAXAqfGKjA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void xQnnbcdqdaDiadMvFFzHAXAqfGKjA(bool P_0)
	{
		if (!merfQobNpdQHSqgWWlOKXDEOHrRu)
		{
			ReInput.ApplicationFocusChangedEvent -= jLMXOYbcOUBtaNfOOtTwMvtaYYjc;
			ReInput.ApplicationPauseChangedEvent -= XOlczPdbFEbvhwenxkIWlcDKOKPC;
			ReInput.EditorPauseChangedEvent -= eOrKXbuayYfxJbfjScxZxpqMxzhw;
			ReInput.UpdateEndedEvent -= PBgHsdZDiuAKvfOTEkrXhsKMyIGQA;
			ReInput.TimeScalePauseChangedEvent -= EwczrKyNUKkGkJLtbBQHgzyqMaKs;
			merfQobNpdQHSqgWWlOKXDEOHrRu = true;
		}
	}

	public static int DMDMGNudKigUZCiWLEqOmRRRRoyuA(lXqhyLmCiKlksFNuxjbZrETGdxhz P_0, KeyCode[] P_1)
	{
		Keys hTaVUnXVaEgTDWJTzZyTOAxztorg = P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg;
		int result = 0;
		tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ xBFdpRuvKwjOprnLxyqHXMXmlHNQ = HatefsdYYsCexwsGwUiPhtnxNJQmA();
		_ = LTGWKGsjQiAzRCcTQRWoxzmNAvbW;
		JUcffnbUUIpygcbMFvGmfZKcYwgXc.BRAzViRHHVFTaSaLVTZGjXDliZpT((uint)P_0.HTaVUnXVaEgTDWJTzZyTOAxztorg, tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.tHSOdcvybNWYnspgtVCZvonwNsjU);
		if (CFIDEKcTHdoClZVsNyudokxRexcPA(hTaVUnXVaEgTDWJTzZyTOAxztorg))
		{
			if (TEzpLKQgMHhWPrBUoFMJDAgjUAlfA(hTaVUnXVaEgTDWJTzZyTOAxztorg, xBFdpRuvKwjOprnLxyqHXMXmlHNQ, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (hTaVUnXVaEgTDWJTzZyTOAxztorg)
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
				if ((P_0.uUcsSThpHkDbXiFZpqvqnVJOApBCA & ScanCodeFlags.E0) != ScanCodeFlags.Make)
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

	private unsafe static tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ HatefsdYYsCexwsGwUiPhtnxNJQmA()
	{
		IntPtr intPtr = JUcffnbUUIpygcbMFvGmfZKcYwgXc.ulwdvaGBxLxGIvqkCPIOvhcqVYtA(0);
		if (intPtr == LTGWKGsjQiAzRCcTQRWoxzmNAvbW)
		{
			return QkaqpoxpguRSosrkfwApKKRHpHVu;
		}
		tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ xBFdpRuvKwjOprnLxyqHXMXmlHNQ = tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ.United_States_English;
		byte* intPtr2 = stackalloc byte[128];
		JUcffnbUUIpygcbMFvGmfZKcYwgXc.qydOpipkYqulWJohFUBbeWhuzaIk((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			int num = ArrayTools.IndexOf(TfCjFrGsPbEdmmGXCbNPOshriQSs, result);
			if (num >= 0)
			{
				xBFdpRuvKwjOprnLxyqHXMXmlHNQ = (tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ)TfCjFrGsPbEdmmGXCbNPOshriQSs[num];
			}
		}
		LTGWKGsjQiAzRCcTQRWoxzmNAvbW = intPtr;
		QkaqpoxpguRSosrkfwApKKRHpHVu = xBFdpRuvKwjOprnLxyqHXMXmlHNQ;
		return xBFdpRuvKwjOprnLxyqHXMXmlHNQ;
	}

	private static bool TEzpLKQgMHhWPrBUoFMJDAgjUAlfA(Keys P_0, tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!rNzAnuublqvbCMUlnbpDJqeWFeul.TryGetValue((int)P_1, out var value))
		{
			value = rNzAnuublqvbCMUlnbpDJqeWFeul[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xBFdpRuvKwjOprnLxyqHXMXmlHNQ.United_States_English)
		{
			value = rNzAnuublqvbCMUlnbpDJqeWFeul[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool CFIDEKcTHdoClZVsNyudokxRexcPA(Keys P_0)
	{
		return ArrayTools.Contains(HdkCLScstxMJLRlvGnEmffjZKwzmA, (int)P_0);
	}
}
