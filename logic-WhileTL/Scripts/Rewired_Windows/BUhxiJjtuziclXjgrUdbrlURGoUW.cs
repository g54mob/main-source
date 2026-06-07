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

internal class BUhxiJjtuziclXjgrUdbrlURGoUW : IUnifiedKeyboardSource, IDisposable, IGetSetEnabled
{
	private class BDLkPIzDsKbRdYkZssgxGyLSQkdw
	{
		private enum GCphCyYZOUWIGIaLvsRQzJuRGgkR
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int zUQsHmiDAoxcAFHnPMMEOfOPHkyaA = 2;

		private static readonly KeyCode[] MZFiIKsFZSncCvtQwPuRvhhrPoZt = new KeyCode[2];

		private readonly UpdateLoopType MZtiQUxntlKvFThTntRndJsqMyNL;

		private bool[] FTbTQwooHvXtPPDLTqgdFfggFsWG;

		private bool[] mqfWGMrijEGMqURXhWvrkeqrbAUKA;

		private uint RxTNcmWPuLncUIqKqhJfDoIDplAO;

		public BDLkPIzDsKbRdYkZssgxGyLSQkdw(UpdateLoopType P_0)
		{
			MZtiQUxntlKvFThTntRndJsqMyNL = P_0;
			FTbTQwooHvXtPPDLTqgdFfggFsWG = new bool[132];
			mqfWGMrijEGMqURXhWvrkeqrbAUKA = new bool[132];
		}

		public void drltkfbmyaNygyWycsTVVONmTpqV(RJqXbQrAGQstHNyvDmNbduGrAJjq P_0)
		{
			int num = ybqcKWMECsMWWWjclQmuYzdQlRML(P_0, MZFiIKsFZSncCvtQwPuRvhhrPoZt);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)MZFiIKsFZSncCvtQwPuRvhhrPoZt[i];
				if (num2 >= 0 && num2 < xNNaSzfoxHBfnRDXifdFYziOKjKA.Length)
				{
					KeyState lbvFBiwfWmAxudHqBUjExiPTlvXf = P_0.LbvFBiwfWmAxudHqBUjExiPTlvXf;
					bool flag = ((lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.KeyFirst || lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.SystemKeyDown) ? true : false);
					int num3 = xNNaSzfoxHBfnRDXifdFYziOKjKA[num2];
					bool num4 = FTbTQwooHvXtPPDLTqgdFfggFsWG[num3];
					FTbTQwooHvXtPPDLTqgdFfggFsWG[num3] = flag;
					if (!num4 && flag)
					{
						mqfWGMrijEGMqURXhWvrkeqrbAUKA[num3] = true;
					}
				}
			}
		}

		public void aaIQDywfqNeCltKvAbGcWTSCAlpkA(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = FTbTQwooHvXtPPDLTqgdFfggFsWG[i] || mqfWGMrijEGMqURXhWvrkeqrbAUKA[i];
			}
			LUTFKPKvVKfcDqyQjLnwrrNzhuTAb();
		}

		public void AAkveQLPaxEaDKEXsosCHmnfCXLT()
		{
			LUTFKPKvVKfcDqyQjLnwrrNzhuTAb();
		}

		private void LUTFKPKvVKfcDqyQjLnwrrNzhuTAb()
		{
			if (RxTNcmWPuLncUIqKqhJfDoIDplAO != ReInput.absFrame)
			{
				nDdSOYpjGGqvidkbPWyyYRZuUKhC();
				RxTNcmWPuLncUIqKqhJfDoIDplAO = ReInput.absFrame;
			}
		}

		public void nDdSOYpjGGqvidkbPWyyYRZuUKhC()
		{
			Array.Clear(mqfWGMrijEGMqURXhWvrkeqrbAUKA, 0, 132);
		}

		public void clOavfCHpNeTPfcwzgPdNbzmHFpz()
		{
			Array.Clear(FTbTQwooHvXtPPDLTqgdFfggFsWG, 0, 132);
			Array.Clear(mqfWGMrijEGMqURXhWvrkeqrbAUKA, 0, 132);
		}
	}

	private const int VjxKyXJzrgooUdbfdNWNxsrVlzRo = 132;

	private const int JuUboySrchdlzRpOJfkJKvINdhbX = 256;

	private readonly object cCndHwpyhmiyUcAhGQdqlqtbgioX = new object();

	private UpdateLoopDataSet<BDLkPIzDsKbRdYkZssgxGyLSQkdw> MYVDgrMcWoexelkNDeTMJZIXLWhg;

	private HardwareControllerMap_Game SFGGRoEaDYcZKZuBaaxqNeYpRRqJ;

	private bool hPlTVNQiLdbzFFHrHysLbZOBZvgEA;

	private int PXYTXOXVlddjVUiGLMIxaoqMzzlU;

	private bool[] yspaQFIJNzjpmPECVFsTFdWiMKOMb = new bool[256];

	private readonly RJqXbQrAGQstHNyvDmNbduGrAJjq qbEiKyNzhFrSxEoFCASjCEvdZJiFA = new RJqXbQrAGQstHNyvDmNbduGrAJjq();

	private bool vzuaBvpIbhXloHFBfRifuhXzDGqV;

	private static readonly int[] xNNaSzfoxHBfnRDXifdFYziOKjKA;

	private static readonly int vqojJfMxGapPrwGcyfCDffYlfDVc;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	private static IntPtr fmVljpwpYhIeyaAtqgUehCVoFYjL;

	private static bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql rLIcxMsGEtzuUwTuWFCwXBqrJCml;

	private static readonly int[] gXuPYMMtBcLKQZpuhdJokxCTAPAmA;

	private static Dictionary<int, Dictionary<int, KeyCode>> IBsfDpFFkVyfyRExeUlXtaTMoWKab;

	private static readonly int[] amcwZNHQfErQJkTbMuaNSruGEwuF;

	public bool enabled
	{
		get
		{
			return vzuaBvpIbhXloHFBfRifuhXzDGqV;
		}
		set
		{
			if (vzuaBvpIbhXloHFBfRifuhXzDGqV != value)
			{
				vzuaBvpIbhXloHFBfRifuhXzDGqV = value;
			}
		}
	}

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (SFGGRoEaDYcZKZuBaaxqNeYpRRqJ == null)
			{
				SFGGRoEaDYcZKZuBaaxqNeYpRRqJ = EAfjryUkPjwpqmQDbBmpnGrwOKAO();
			}
			return SFGGRoEaDYcZKZuBaaxqNeYpRRqJ;
		}
	}

	public int buttonCount => 132;

	public Controller.Extension controllerExtension => null;

	static BUhxiJjtuziclXjgrUdbrlURGoUW()
	{
		rLIcxMsGEtzuUwTuWFCwXBqrJCml = bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql.United_States_English;
		gXuPYMMtBcLKQZpuhdJokxCTAPAmA = (int[])Enum.GetValues(typeof(bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql));
		IBsfDpFFkVyfyRExeUlXtaTMoWKab = new Dictionary<int, Dictionary<int, KeyCode>>
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
		amcwZNHQfErQJkTbMuaNSruGEwuF = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > vqojJfMxGapPrwGcyfCDffYlfDVc)
			{
				vqojJfMxGapPrwGcyfCDffYlfDVc = keyboardKeyValues[i];
			}
		}
		xNNaSzfoxHBfnRDXifdFYziOKjKA = new int[vqojJfMxGapPrwGcyfCDffYlfDVc + 1];
		ArrayTools.Fill(xNNaSzfoxHBfnRDXifdFYziOKjKA, -1);
		for (int j = 0; j < num; j++)
		{
			xNNaSzfoxHBfnRDXifdFYziOKjKA[keyboardKeyValues[j]] = j;
		}
	}

	public BUhxiJjtuziclXjgrUdbrlURGoUW(UpdateLoopSetting P_0)
	{
		weqNSFuLoRuepnjCMZBLMEbeGDiDA();
		MYVDgrMcWoexelkNDeTMJZIXLWhg = new UpdateLoopDataSet<BDLkPIzDsKbRdYkZssgxGyLSQkdw>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i] = new BDLkPIzDsKbRdYkZssgxGyLSQkdw(list[i]);
			}
		}
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		enabled = true;
		ReInput.ApplicationFocusChangedEvent += izsxjNyxyktvAnVpBwNVRAUOxkcJ;
		ReInput.EditorPauseChangedEvent += jbYPDtSqdSxaDyKMNhAMwaVDmIlo;
		ReInput.UpdateEndedEvent += YJobGkINyGJLLBjbOaWTfJLMSwUN;
		ReInput.TimeScalePauseChangedEvent += ZjMAJpWMjCgjaRLAzzaKAIUkbKtL;
	}

	public unsafe void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(UpdateLoopType P_0)
	{
		MYVDgrMcWoexelkNDeTMJZIXLWhg.SetUpdateLoop(P_0);
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!nxzMUSyCaMfSlEuvKxUcjBKIXFKl.CEXQmKBOtVkqaxzaaMYZfkNjbesG((IntPtr)ptr))
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
						if (yspaQFIJNzjpmPECVFsTFdWiMKOMb[i])
						{
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.WuflAoNgHfNrTWAitlHTduHQRmXo();
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.GnnIcTLqcCYcjgtWMYQGuLuWLqPd = ReInput.realTime;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.oguMFXKsGdJFrDFMUaaUuSTZTbJu = IntPtr.Zero;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.xLJBatpMRckbjWhSGzcsPrkxVFHc = (Keys)i;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.RQiNqkcCWNalKEpsFxUZIqTEQlMEb = 0;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.WsjbxIsPXWKNGwiCnGJqlphVrpGF = ScanCodeFlags.Break;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.LbvFBiwfWmAxudHqBUjExiPTlvXf = KeyState.KeyUp;
							qbEiKyNzhFrSxEoFCASjCEvdZJiFA.XGzaYxOgjODmABctcfOkcyHbQnNGc = 0;
							UNjTkGmulXtcDtUguRlvtYWMwrxg(qbEiKyNzhFrSxEoFCASjCEvdZJiFA);
						}
					}
					else if (!yspaQFIJNzjpmPECVFsTFdWiMKOMb[i])
					{
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.WuflAoNgHfNrTWAitlHTduHQRmXo();
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.GnnIcTLqcCYcjgtWMYQGuLuWLqPd = ReInput.realTime;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.oguMFXKsGdJFrDFMUaaUuSTZTbJu = IntPtr.Zero;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.xLJBatpMRckbjWhSGzcsPrkxVFHc = (Keys)i;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.RQiNqkcCWNalKEpsFxUZIqTEQlMEb = 0;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.WsjbxIsPXWKNGwiCnGJqlphVrpGF = ScanCodeFlags.Make;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.LbvFBiwfWmAxudHqBUjExiPTlvXf = KeyState.KeyFirst;
						qbEiKyNzhFrSxEoFCASjCEvdZJiFA.XGzaYxOgjODmABctcfOkcyHbQnNGc = 0;
						UNjTkGmulXtcDtUguRlvtYWMwrxg(qbEiKyNzhFrSxEoFCASjCEvdZJiFA);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void UNjTkGmulXtcDtUguRlvtYWMwrxg(RJqXbQrAGQstHNyvDmNbduGrAJjq P_0)
	{
		if (!hPlTVNQiLdbzFFHrHysLbZOBZvgEA)
		{
			return;
		}
		switch (P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc)
		{
		case Keys.ControlKey:
		{
			Keys keys = (Keys)nxzMUSyCaMfSlEuvKxUcjBKIXFKl.xWHrLKjwZwVizYaBkCQhNehdtMUg((uint)P_0.RQiNqkcCWNalKEpsFxUZIqTEQlMEb, bNjyIBdgpdVpFZDGLcYCYJhSMleY.WGibqLdlxGXMaEhzMifBaKnuUXWh);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = (((P_0.WsjbxIsPXWKNGwiCnGJqlphVrpGF & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = (((P_0.WsjbxIsPXWKNGwiCnGJqlphVrpGF & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		case Keys.ShiftKey:
		{
			P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = (Keys)nxzMUSyCaMfSlEuvKxUcjBKIXFKl.xWHrLKjwZwVizYaBkCQhNehdtMUg((uint)P_0.RQiNqkcCWNalKEpsFxUZIqTEQlMEb, bNjyIBdgpdVpFZDGLcYCYJhSMleY.WGibqLdlxGXMaEhzMifBaKnuUXWh);
			if (P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc == Keys.LShiftKey || P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc == Keys.RShiftKey)
			{
				break;
			}
			KeyState lbvFBiwfWmAxudHqBUjExiPTlvXf = P_0.LbvFBiwfWmAxudHqBUjExiPTlvXf;
			bool flag = ((lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.KeyFirst || lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.SystemKeyDown || lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.KeyLast) ? true : false);
			bool flag2 = (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.QoSEmfILxcyimIkoUKFNOmCPgCAE(160) & 0x8000) != 0;
			bool flag3 = (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.QoSEmfILxcyimIkoUKFNOmCPgCAE(161) & 0x8000) != 0;
			if (flag)
			{
				bool num = (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.rhyRmmFveqBVzOdBiZaZjDjHpsLD(160) & 0x8000) != 0;
				bool flag4 = (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.rhyRmmFveqBVzOdBiZaZjDjHpsLD(161) & 0x8000) != 0;
				if (num)
				{
					P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.LShiftKey;
					UNjTkGmulXtcDtUguRlvtYWMwrxg(P_0);
				}
				if (flag4)
				{
					P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.RShiftKey;
					UNjTkGmulXtcDtUguRlvtYWMwrxg(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.LShiftKey;
				break;
			}
			if (flag3)
			{
				P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.RShiftKey;
				break;
			}
			P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.LShiftKey;
			UNjTkGmulXtcDtUguRlvtYWMwrxg(P_0);
			P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc = Keys.RShiftKey;
			UNjTkGmulXtcDtUguRlvtYWMwrxg(P_0);
			return;
		}
		}
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			KeyState lbvFBiwfWmAxudHqBUjExiPTlvXf = P_0.LbvFBiwfWmAxudHqBUjExiPTlvXf;
			if (lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.KeyFirst || lbvFBiwfWmAxudHqBUjExiPTlvXf == KeyState.SystemKeyDown)
			{
				yspaQFIJNzjpmPECVFsTFdWiMKOMb[(int)P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc] = true;
			}
			else
			{
				yspaQFIJNzjpmPECVFsTFdWiMKOMb[(int)P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc] = false;
			}
			int count = MYVDgrMcWoexelkNDeTMJZIXLWhg.Count;
			for (int i = 0; i < count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i].drltkfbmyaNygyWycsTVVONmTpqV(P_0);
			}
		}
	}

	public void LfoQuDdqyouAgYcQelFthkWoncwV(bool P_0)
	{
		ryWAqWJXgJjDHCPtOCVzbpvhTLlW();
	}

	public void oKZjJsUfdokwGiyKjHVaqyvEQkZs(bool P_0)
	{
		if (weqNSFuLoRuepnjCMZBLMEbeGDiDA() < 0)
		{
			ryWAqWJXgJjDHCPtOCVzbpvhTLlW();
		}
	}

	private int weqNSFuLoRuepnjCMZBLMEbeGDiDA()
	{
		int pXYTXOXVlddjVUiGLMIxaoqMzzlU = PXYTXOXVlddjVUiGLMIxaoqMzzlU;
		if (tVBWyZGsKPKvJuuMOPZiWmVEjMGK.EJKTrsPAGYfqDQnsfqkzzEnCYGmG(pkUmomIELOfJWzdNflUWcAcSmqxS.Keyboard, out var pXYTXOXVlddjVUiGLMIxaoqMzzlU2))
		{
			PXYTXOXVlddjVUiGLMIxaoqMzzlU = pXYTXOXVlddjVUiGLMIxaoqMzzlU2;
		}
		else
		{
			PXYTXOXVlddjVUiGLMIxaoqMzzlU = 1;
		}
		return PXYTXOXVlddjVUiGLMIxaoqMzzlU - pXYTXOXVlddjVUiGLMIxaoqMzzlU;
	}

	private void izsxjNyxyktvAnVpBwNVRAUOxkcJ(bool P_0)
	{
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !hPlTVNQiLdbzFFHrHysLbZOBZvgEA)
		{
			ryWAqWJXgJjDHCPtOCVzbpvhTLlW();
		}
	}

	private void jbYPDtSqdSxaDyKMNhAMwaVDmIlo(bool P_0)
	{
	}

	private void ZjMAJpWMjCgjaRLAzzaKAIUkbKtL(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			MYVDgrMcWoexelkNDeTMJZIXLWhg[MYVDgrMcWoexelkNDeTMJZIXLWhg.fixedUpdateSetIndex].nDdSOYpjGGqvidkbPWyyYRZuUKhC();
		}
	}

	private void YJobGkINyGJLLBjbOaWTfJLMSwUN(UpdateLoopType P_0)
	{
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			MYVDgrMcWoexelkNDeTMJZIXLWhg.Get(P_0).AAkveQLPaxEaDKEXsosCHmnfCXLT();
		}
	}

	private void ryWAqWJXgJjDHCPtOCVzbpvhTLlW()
	{
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			int count = MYVDgrMcWoexelkNDeTMJZIXLWhg.Count;
			for (int i = 0; i < count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i].clOavfCHpNeTPfcwzgPdNbzmHFpz();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		MYVDgrMcWoexelkNDeTMJZIXLWhg.Current.aaIQDywfqNeCltKvAbGcWTSCAlpkA(dataUpdater);
	}

	public void Clear()
	{
		ryWAqWJXgJjDHCPtOCVzbpvhTLlW();
	}

	private static HardwareControllerMap_Game EAfjryUkPjwpqmQDbBmpnGrwOKAO()
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
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			ReInput.ApplicationFocusChangedEvent -= izsxjNyxyktvAnVpBwNVRAUOxkcJ;
			ReInput.EditorPauseChangedEvent -= jbYPDtSqdSxaDyKMNhAMwaVDmIlo;
			ReInput.UpdateEndedEvent -= YJobGkINyGJLLBjbOaWTfJLMSwUN;
			ReInput.TimeScalePauseChangedEvent -= ZjMAJpWMjCgjaRLAzzaKAIUkbKtL;
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	public static int ybqcKWMECsMWWWjclQmuYzdQlRML(RJqXbQrAGQstHNyvDmNbduGrAJjq P_0, KeyCode[] P_1)
	{
		Keys xLJBatpMRckbjWhSGzcsPrkxVFHc = P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc;
		int result = 0;
		bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql bHNPdqjTEQNrLtkEKxYQrcGcIVql = shFtSWloYyuJvYBSYDcZTQGMeaYT();
		_ = fmVljpwpYhIeyaAtqgUehCVoFYjL;
		nxzMUSyCaMfSlEuvKxUcjBKIXFKl.xWHrLKjwZwVizYaBkCQhNehdtMUg((uint)P_0.xLJBatpMRckbjWhSGzcsPrkxVFHc, bNjyIBdgpdVpFZDGLcYCYJhSMleY.JPuFmYvZkkIOvTOiUZQVlIrtpUYN);
		if (XFbRHNnmlLixdGTpImwQawvezwJB(xLJBatpMRckbjWhSGzcsPrkxVFHc))
		{
			if (LaFOYqFyxuknTQDVjGYJEVxXjSGmA(xLJBatpMRckbjWhSGzcsPrkxVFHc, bHNPdqjTEQNrLtkEKxYQrcGcIVql, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (xLJBatpMRckbjWhSGzcsPrkxVFHc)
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
				if ((P_0.WsjbxIsPXWKNGwiCnGJqlphVrpGF & ScanCodeFlags.E0) != ScanCodeFlags.Make)
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

	private unsafe static bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql shFtSWloYyuJvYBSYDcZTQGMeaYT()
	{
		IntPtr intPtr = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.btggEJCiScBgAVDbUQuwnfvFfGSD(0);
		if (intPtr == fmVljpwpYhIeyaAtqgUehCVoFYjL)
		{
			return rLIcxMsGEtzuUwTuWFCwXBqrJCml;
		}
		bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql result = bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql.United_States_English;
		byte* intPtr2 = stackalloc byte[128];
		nxzMUSyCaMfSlEuvKxUcjBKIXFKl.ESQPECNYYWnCESVAxuShOFMPfYxD((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
		{
			int num = ArrayTools.IndexOf(gXuPYMMtBcLKQZpuhdJokxCTAPAmA, result2);
			if (num >= 0)
			{
				result = (bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql)gXuPYMMtBcLKQZpuhdJokxCTAPAmA[num];
			}
		}
		fmVljpwpYhIeyaAtqgUehCVoFYjL = intPtr;
		rLIcxMsGEtzuUwTuWFCwXBqrJCml = result;
		return result;
	}

	private static bool LaFOYqFyxuknTQDVjGYJEVxXjSGmA(Keys P_0, bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!IBsfDpFFkVyfyRExeUlXtaTMoWKab.TryGetValue((int)P_1, out var value))
		{
			value = IBsfDpFFkVyfyRExeUlXtaTMoWKab[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != bNjyIBdgpdVpFZDGLcYCYJhSMleY.bHNPdqjTEQNrLtkEKxYQrcGcIVql.United_States_English)
		{
			value = IBsfDpFFkVyfyRExeUlXtaTMoWKab[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool XFbRHNnmlLixdGTpImwQawvezwJB(Keys P_0)
	{
		return ArrayTools.Contains(amcwZNHQfErQJkTbMuaNSruGEwuF, (int)P_0);
	}
}
