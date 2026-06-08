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

internal class uXmfJyNysxkJVMfVjUMqRSBUjHs : IDisposable, IUnifiedKeyboardSource
{
	private class ysPwUxOupCdMgAxtLKPxikNUSai
	{
		private enum OjmbeXVxnaQLWhiilvWPIKLSIer
		{
			UyGwCSXAdlJCSRSfHscRvehUkwi = 0,
			YQlTrllayyTdWOufwMahgukPLzU = 1,
			lphadBTcbEIrMfgqIPCtBDFrtUr = 2
		}

		private const int EBVQsGnUukgqQOsTRjhmnSUchd = 2;

		private static readonly KeyCode[] zEGVaEODTEeTioGRsJrwZCxeGnS = new KeyCode[2];

		private readonly UpdateLoopType zEyXzATlnbhhjMGAhEoOFPedgfE;

		private bool[] aMmaGodOghcRdzACTNLKAhgzBANr;

		private bool[] LwSLMfJpaYQCAPKkzIAyCqnyRDf;

		private uint yhOcnwicmNlkaDHXwJyAlVSStiV;

		public ysPwUxOupCdMgAxtLKPxikNUSai(UpdateLoopType updateLoop)
		{
			while (true)
			{
				int num = -1678960082;
				while (true)
				{
					switch (num ^ -1678960081)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						zEyXzATlnbhhjMGAhEoOFPedgfE = updateLoop;
						num = -1678960083;
						continue;
					case 2:
						aMmaGodOghcRdzACTNLKAhgzBANr = new bool[132];
						LwSLMfJpaYQCAPKkzIAyCqnyRDf = new bool[132];
						num = -1678960081;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public void MgtrORcuxoECdpDqmoGlFAnoCz(aTdyQHLUTWxtxOewXyYbXIrqYcL P_0)
		{
			int num = BvtpBMwnUaIEkJGnrfTDKyhHpeHr(P_0, zEGVaEODTEeTioGRsJrwZCxeGnS);
			KeyState guivIoOtvcGGUgbWBcrfbLNSSgGh = default(KeyState);
			bool flag2 = default(bool);
			int num3 = default(int);
			int num4 = default(int);
			bool flag = default(bool);
			int num5 = default(int);
			while (true)
			{
				int num2 = 1237388188;
				while (true)
				{
					switch (num2 ^ 0x49C10B95)
					{
					case 6:
						break;
					case 11:
					{
						int num6;
						switch (guivIoOtvcGGUgbWBcrfbLNSSgGh)
						{
						case KeyState.SystemKeyDown:
							num2 = 1237388181;
							num6 = num2;
							continue;
						default:
							num2 = 1237388176;
							num6 = num2;
							continue;
						case KeyState.KeyFirst:
							break;
						}
						goto case 0;
					}
					case 5:
						flag2 = false;
						num2 = 1237388178;
						continue;
					case 8:
						num3++;
						num2 = 1237388182;
						continue;
					case 10:
						num2 = 1237388182;
						continue;
					case 0:
						flag2 = true;
						num2 = 1237388178;
						continue;
					case 1:
						aMmaGodOghcRdzACTNLKAhgzBANr[num4] = flag2;
						if (!flag && flag2)
						{
							LwSLMfJpaYQCAPKkzIAyCqnyRDf[num4] = true;
							num2 = 1237388189;
							continue;
						}
						goto case 8;
					case 4:
						if (num5 >= 0 && num5 < QPEUGUNputsTXgnMVOASmlrpzHm.Length)
						{
							guivIoOtvcGGUgbWBcrfbLNSSgGh = P_0.guivIoOtvcGGUgbWBcrfbLNSSgGh;
							num2 = 1237388190;
							continue;
						}
						goto case 8;
					case 2:
						num5 = (int)zEGVaEODTEeTioGRsJrwZCxeGnS[num3];
						num2 = 1237388177;
						continue;
					case 9:
						num3 = 0;
						num2 = 1237388191;
						continue;
					case 7:
						num4 = QPEUGUNputsTXgnMVOASmlrpzHm[num5];
						flag = aMmaGodOghcRdzACTNLKAhgzBANr[num4];
						num2 = 1237388180;
						continue;
					default:
						if (num3 >= num)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public void PUNhNkYNeXdWTDciGPhTFmSiXuyR(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			int num2 = default(int);
			while (true)
			{
				int num = -1852740596;
				while (true)
				{
					switch (num ^ -1852740594)
					{
					case 3:
						break;
					case 2:
						num2 = 0;
						num = -1852740598;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= 132)
						{
							num = -1852740594;
							num3 = num;
						}
						else
						{
							num = -1852740593;
							num3 = num;
						}
						continue;
					}
					case 1:
						buttonValues[num2] = aMmaGodOghcRdzACTNLKAhgzBANr[num2] || LwSLMfJpaYQCAPKkzIAyCqnyRDf[num2];
						num2++;
						num = -1852740598;
						continue;
					default:
						sWOVSPHFXKeSnjPXvMxZHIBaraU();
						return;
					}
					break;
				}
			}
		}

		public void fHvlAyzcxwcbEJYkeBnphlWsGSD()
		{
			sWOVSPHFXKeSnjPXvMxZHIBaraU();
		}

		private void sWOVSPHFXKeSnjPXvMxZHIBaraU()
		{
			if (yhOcnwicmNlkaDHXwJyAlVSStiV != ReInput.absFrame)
			{
				SqoZNSJDzCagYFujVEtRFqPCrBef();
				yhOcnwicmNlkaDHXwJyAlVSStiV = ReInput.absFrame;
			}
		}

		public void SqoZNSJDzCagYFujVEtRFqPCrBef()
		{
			Array.Clear(LwSLMfJpaYQCAPKkzIAyCqnyRDf, 0, 132);
		}

		public void RFDPexajhTcXvizzpCmOkHbzMGox()
		{
			Array.Clear(aMmaGodOghcRdzACTNLKAhgzBANr, 0, 132);
			while (true)
			{
				int num = -746788439;
				while (true)
				{
					switch (num ^ -746788437)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002f;
					case 1:
						return;
					}
					break;
					IL_002f:
					Array.Clear(LwSLMfJpaYQCAPKkzIAyCqnyRDf, 0, 132);
					num = -746788438;
				}
			}
		}
	}

	private const int cTufjPtHboEgawuozivuLCfGUaI = 132;

	private const int kNVQzseDkrbtXGDTLMLcoXUGSmg = 256;

	private readonly object VscpWqBWzuDusblaKBCJNvlmplv = new object();

	private UpdateLoopDataSet<ysPwUxOupCdMgAxtLKPxikNUSai> piKoUxmrMerfAglUXqXbrnWETOs;

	private HardwareControllerMap_Game pYZeXwBoDCsmudSAinXVShKksCfW;

	private bool AuSfBgNJvdyvCemJZTwlrQYgnr;

	private int mLFGYdXdfbbtVuBHHjYETeJgec;

	private bool[] XAyZpDhVPdhNMPDCFRFsTAuZVfF = new bool[256];

	private readonly aTdyQHLUTWxtxOewXyYbXIrqYcL DGJBOozvtZYJNFwOSnIWswloGit = new aTdyQHLUTWxtxOewXyYbXIrqYcL();

	private static readonly int[] QPEUGUNputsTXgnMVOASmlrpzHm;

	private static readonly int AddzoJmKfskptvtDocWkJqjiFyU;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	private static IntPtr GFEgkfUWOdgKMrUokQFNFLZdVGo;

	private static WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier EGBEtGUfIppzarOYSakHtroiNQp;

	private static readonly int[] VkpBPQoJHeYGsOBhtygXHUICAQP;

	private static Dictionary<int, Dictionary<int, KeyCode>> dfrUHtlDgDjlOXRowYewEfFZfJT;

	private static readonly int[] RurklHhVvKbrdzggOdDsDgiLuFpl;

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (pYZeXwBoDCsmudSAinXVShKksCfW == null)
			{
				pYZeXwBoDCsmudSAinXVShKksCfW = pssshskLLdlkShgSdjTWPPtvjJV();
			}
			return pYZeXwBoDCsmudSAinXVShKksCfW;
		}
	}

	public int buttonCount => 132;

	public Controller.Extension controllerExtension => null;

	static uXmfJyNysxkJVMfVjUMqRSBUjHs()
	{
		EGBEtGUfIppzarOYSakHtroiNQp = WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier.United_States_English;
		VkpBPQoJHeYGsOBhtygXHUICAQP = (int[])Enum.GetValues(typeof(WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier));
		Dictionary<int, Dictionary<int, KeyCode>> dictionary = new Dictionary<int, Dictionary<int, KeyCode>> { 
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
		} };
		int num3 = default(int);
		int num5 = default(int);
		int[] keyboardKeyValues = default(int[]);
		int num2 = default(int);
		while (true)
		{
			int num = -1119943183;
			while (true)
			{
				switch (num ^ -1119943173)
				{
				case 11:
					break;
				default:
					return;
				case 8:
					ArrayTools.Fill(QPEUGUNputsTXgnMVOASmlrpzHm, -1);
					num3 = 0;
					num = -1119943169;
					continue;
				case 3:
					num5 = 0;
					num = -1119943175;
					continue;
				case 12:
					if (keyboardKeyValues[num5] > AddzoJmKfskptvtDocWkJqjiFyU)
					{
						AddzoJmKfskptvtDocWkJqjiFyU = keyboardKeyValues[num5];
						num = -1119943171;
						continue;
					}
					goto case 6;
				case 6:
					num5++;
					num = -1119943175;
					continue;
				case 2:
					if (num5 >= num2)
					{
						QPEUGUNputsTXgnMVOASmlrpzHm = new int[AddzoJmKfskptvtDocWkJqjiFyU + 1];
						num = -1119943181;
						continue;
					}
					goto case 12;
				case 0:
					dictionary.Add(1106, new Dictionary<int, KeyCode>
					{
						{
							223,
							KeyCode.BackQuote
						},
						{
							192,
							KeyCode.Quote
						}
					});
					dictionary.Add(1031, new Dictionary<int, KeyCode>
					{
						{
							219,
							KeyCode.Backslash
						},
						{
							221,
							KeyCode.BackQuote
						}
					});
					dfrUHtlDgDjlOXRowYewEfFZfJT = dictionary;
					RurklHhVvKbrdzggOdDsDgiLuFpl = new int[22]
					{
						186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
						254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
						186, 192
					};
					num = -1119943172;
					continue;
				case 5:
					num3++;
					num = -1119943169;
					continue;
				case 1:
					QPEUGUNputsTXgnMVOASmlrpzHm[keyboardKeyValues[num3]] = num3;
					num = -1119943170;
					continue;
				case 4:
				{
					int num4;
					if (num3 < num2)
					{
						num = -1119943174;
						num4 = num;
					}
					else
					{
						num = -1119943182;
						num4 = num;
					}
					continue;
				}
				case 7:
					keyboardKeyValues = Consts._keyboardKeyValues;
					num2 = keyboardKeyValues.Length;
					num = -1119943176;
					continue;
				case 10:
					dictionary.Add(2057, new Dictionary<int, KeyCode>
					{
						{
							223,
							KeyCode.BackQuote
						},
						{
							192,
							KeyCode.Quote
						}
					});
					num = -1119943173;
					continue;
				case 9:
					return;
				}
				break;
			}
		}
	}

	public uXmfJyNysxkJVMfVjUMqRSBUjHs(UpdateLoopSetting updateLoopSetting)
	{
		FOdNxLQXaXoFVqyRSyfyeevnORf();
		piKoUxmrMerfAglUXqXbrnWETOs = new UpdateLoopDataSet<ysPwUxOupCdMgAxtLKPxikNUSai>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				piKoUxmrMerfAglUXqXbrnWETOs[i] = new ysPwUxOupCdMgAxtLKPxikNUSai(list[i]);
			}
		}
		AuSfBgNJvdyvCemJZTwlrQYgnr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		ReInput.ApplicationFocusChangedEvent += ZhtNyHCNouilkiOwVeXopAYTKgl;
		ReInput.EditorPauseChangedEvent += SSNYvrcdzAoOjvBXDhnpIfDMHLe;
		ReInput.UpdateEndedEvent += xylQXgmJgMaNzIbeWgxuADDXkzHn;
		ReInput.TimeScalePauseChangedEvent += oZDzLjcaKWUyGIjWfYXzuzUxeco;
	}

	public unsafe void FFYEDujhZPZIRSsDbLkeXQkxTZI(UpdateLoopType P_0)
	{
		piKoUxmrMerfAglUXqXbrnWETOs.SetUpdateLoop(P_0);
		AuSfBgNJvdyvCemJZTwlrQYgnr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!YksGHYKteMuhDXToEsEFZvCVfCJ.tMYgTGhkhHvsGcmjmQlsJogeowb((IntPtr)ptr))
				{
					return;
				}
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -1927413755;
					while (true)
					{
						int num7;
						switch (num ^ -1927413754)
						{
						case 4:
							break;
						default:
							return;
						case 12:
						{
							int num5;
							if (XAyZpDhVPdhNMPDCFRFsTAuZVfF[num3])
							{
								num = -1927413754;
								num5 = num;
							}
							else
							{
								num = -1927413753;
								num5 = num;
							}
							continue;
						}
						case 0:
							DGJBOozvtZYJNFwOSnIWswloGit.hmcZJavdRjdndRuzheyiFfLNpQS();
							DGJBOozvtZYJNFwOSnIWswloGit.xdmAJsfTsGwAFbRaKbbziORJkMWx = ReInput.realTime;
							DGJBOozvtZYJNFwOSnIWswloGit.RZxeRXiRMdGVXExVYrFfKSLGcgO = IntPtr.Zero;
							DGJBOozvtZYJNFwOSnIWswloGit.QxCyIbDyCmOiHZZcYITHlevsHEY = (Keys)num3;
							DGJBOozvtZYJNFwOSnIWswloGit.scvnvaWGSXdrkwwpRshiCZDXqwX = 0;
							DGJBOozvtZYJNFwOSnIWswloGit.nAqlsKIvNUaQezRRzExFARhMBkZn = ScanCodeFlags.Break;
							num = -1927413748;
							continue;
						case 8:
							num = -1927413749;
							continue;
						case 16:
							num2 = num3;
							if (num2 <= 18)
							{
								switch (num2)
								{
								case 1:
								case 2:
								case 4:
								case 5:
								case 6:
									goto IL_01f5;
								case 3:
									goto IL_02a3;
								}
								num = -1927413757;
								continue;
							}
							goto case 9;
						case 7:
							DGJBOozvtZYJNFwOSnIWswloGit.scvnvaWGSXdrkwwpRshiCZDXqwX = 0;
							DGJBOozvtZYJNFwOSnIWswloGit.nAqlsKIvNUaQezRRzExFARhMBkZn = ScanCodeFlags.Make;
							num = -1927413760;
							continue;
						case 11:
							if (!XAyZpDhVPdhNMPDCFRFsTAuZVfF[num3])
							{
								DGJBOozvtZYJNFwOSnIWswloGit.hmcZJavdRjdndRuzheyiFfLNpQS();
								DGJBOozvtZYJNFwOSnIWswloGit.xdmAJsfTsGwAFbRaKbbziORJkMWx = ReInput.realTime;
								DGJBOozvtZYJNFwOSnIWswloGit.RZxeRXiRMdGVXExVYrFfKSLGcgO = IntPtr.Zero;
								DGJBOozvtZYJNFwOSnIWswloGit.QxCyIbDyCmOiHZZcYITHlevsHEY = (Keys)num3;
								num = -1927413759;
								continue;
							}
							goto IL_01f5;
						case 9:
						{
							int num6;
							switch (num2)
							{
							default:
								num = -1927413756;
								num6 = num;
								continue;
							case 131072:
								num = -1927413753;
								num6 = num;
								continue;
							case 65536:
								break;
							}
							goto IL_01f5;
						}
						case 15:
							num = -1927413753;
							continue;
						case 3:
							num3 = 0;
							num = -1927413746;
							continue;
						case 1:
							goto IL_01f5;
						case 13:
						{
							int num4;
							if (num3 >= 256)
							{
								num = -1927413752;
								num4 = num;
							}
							else
							{
								num = -1927413738;
								num4 = num;
							}
							continue;
						}
						case 10:
							DGJBOozvtZYJNFwOSnIWswloGit.guivIoOtvcGGUgbWBcrfbLNSSgGh = KeyState.KeyUp;
							DGJBOozvtZYJNFwOSnIWswloGit.mpiPlvupZUmbuvucoxNFATAToxO = 0;
							nDwGSGWCnHAfhkghamaOrLWTAxcn(DGJBOozvtZYJNFwOSnIWswloGit);
							num = -1927413751;
							continue;
						case 5:
							switch (num2)
							{
							case 16:
							case 17:
							case 18:
								break;
							default:
								num = -1927413756;
								continue;
							}
							goto IL_01f5;
						case 6:
							DGJBOozvtZYJNFwOSnIWswloGit.guivIoOtvcGGUgbWBcrfbLNSSgGh = KeyState.KeyFirst;
							DGJBOozvtZYJNFwOSnIWswloGit.mpiPlvupZUmbuvucoxNFATAToxO = 0;
							nDwGSGWCnHAfhkghamaOrLWTAxcn(DGJBOozvtZYJNFwOSnIWswloGit);
							num = -1927413753;
							continue;
						case 2:
							goto IL_02a3;
						case 14:
							return;
							IL_01f5:
							num3++;
							num = -1927413749;
							continue;
							IL_02a3:
							if ((ptr[num3] & 0x80) == 0)
							{
								num = -1927413750;
								num7 = num;
							}
							else
							{
								num = -1927413747;
								num7 = num;
							}
							continue;
						}
						break;
					}
				}
			}
			catch
			{
			}
		}
	}

	public void nDwGSGWCnHAfhkghamaOrLWTAxcn(aTdyQHLUTWxtxOewXyYbXIrqYcL P_0)
	{
		if (!AuSfBgNJvdyvCemJZTwlrQYgnr)
		{
			return;
		}
		KeyState guivIoOtvcGGUgbWBcrfbLNSSgGh = default(KeyState);
		bool flag = default(bool);
		bool flag5 = default(bool);
		bool flag3 = default(bool);
		bool flag4 = default(bool);
		bool flag2 = default(bool);
		while (true)
		{
			IL_00e8:
			int num;
			Keys keys;
			switch (P_0.QxCyIbDyCmOiHZZcYITHlevsHEY)
			{
			case Keys.Menu:
				P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = (((P_0.nAqlsKIvNUaQezRRzExFARhMBkZn & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
				num = 906829097;
				goto IL_0011;
			default:
				num = 906829097;
				goto IL_0011;
			case Keys.ShiftKey:
				goto IL_01c7;
			case Keys.ControlKey:
				goto IL_020f;
				IL_00a4:
				P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = (((P_0.nAqlsKIvNUaQezRRzExFARhMBkZn & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
				num = 906829113;
				goto IL_0011;
				IL_01c7:
				P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = (Keys)YksGHYKteMuhDXToEsEFZvCVfCJ.MfGIsGJbNoMXRHYIcTfMlrnkroT((uint)P_0.scvnvaWGSXdrkwwpRshiCZDXqwX, WgyDhDKPtxBNfGUTiXnlxotcDalv.zaphgLNNnEaRCVtmCiVsElnnMZX);
				if (P_0.QxCyIbDyCmOiHZZcYITHlevsHEY == Keys.LShiftKey || P_0.QxCyIbDyCmOiHZZcYITHlevsHEY == Keys.RShiftKey)
				{
					break;
				}
				guivIoOtvcGGUgbWBcrfbLNSSgGh = P_0.guivIoOtvcGGUgbWBcrfbLNSSgGh;
				num = 906829106;
				goto IL_0011;
				IL_020f:
				keys = (Keys)YksGHYKteMuhDXToEsEFZvCVfCJ.MfGIsGJbNoMXRHYIcTfMlrnkroT((uint)P_0.scvnvaWGSXdrkwwpRshiCZDXqwX, WgyDhDKPtxBNfGUTiXnlxotcDalv.zaphgLNNnEaRCVtmCiVsElnnMZX);
				if (keys != Keys.LControlKey && keys != Keys.RControlKey)
				{
					return;
				}
				goto IL_00a4;
				IL_0011:
				while (true)
				{
					switch (num ^ 0x360D1D3F)
					{
					case 18:
						num = 906829112;
						continue;
					case 14:
						break;
					case 12:
						goto IL_00a4;
					case 13:
						goto IL_00cb;
					case 7:
						goto IL_00e8;
					case 6:
						num = 906829097;
						continue;
					case 21:
						return;
					case 11:
						num = 906829097;
						continue;
					case 3:
						if (!flag)
						{
							return;
						}
						P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.RShiftKey;
						nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
						num = 906829098;
						continue;
					case 19:
						return;
					case 5:
						if (flag5)
						{
							P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.LShiftKey;
							nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
							num = 906829116;
							continue;
						}
						goto case 3;
					case 15:
						goto IL_017a;
					case 8:
						if (flag3)
						{
							P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.LShiftKey;
							num = 906829097;
							continue;
						}
						goto case 2;
					case 16:
						goto IL_01bb;
					case 4:
						goto IL_01c7;
					case 17:
						goto IL_020f;
					case 9:
						flag3 = (YksGHYKteMuhDXToEsEFZvCVfCJ.hEVxZuuNJeWsYJcfSjdggWuGDfXh(160) & 0x8000) != 0;
						flag4 = (YksGHYKteMuhDXToEsEFZvCVfCJ.hEVxZuuNJeWsYJcfSjdggWuGDfXh(161) & 0x8000) != 0;
						if (flag2)
						{
							flag5 = (YksGHYKteMuhDXToEsEFZvCVfCJ.SYpAGwgbrymBTNtcmcycBVDYciWI(160) & 0x8000) != 0;
							num = 906829118;
							continue;
						}
						goto case 0;
					case 2:
						if (flag4)
						{
							P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.RShiftKey;
							num = 906829108;
							continue;
						}
						goto case 10;
					case 10:
						P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.LShiftKey;
						nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
						P_0.QxCyIbDyCmOiHZZcYITHlevsHEY = Keys.RShiftKey;
						nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
						num = 906829100;
						continue;
					case 20:
						flag2 = false;
						num = 906829110;
						continue;
					case 0:
						if (flag3 && flag4)
						{
							return;
						}
						goto case 8;
					case 1:
						flag = (YksGHYKteMuhDXToEsEFZvCVfCJ.SYpAGwgbrymBTNtcmcycBVDYciWI(161) & 0x8000) != 0;
						num = 906829114;
						continue;
					default:
						goto end_IL_00f5;
					}
					break;
					IL_017a:
					int num2;
					switch (guivIoOtvcGGUgbWBcrfbLNSSgGh)
					{
					case KeyState.KeyLast:
						num = 906829103;
						num2 = num;
						continue;
					default:
						num = 906829099;
						num2 = num;
						continue;
					case KeyState.SystemKeyDown:
						break;
					}
					goto IL_01bb;
					IL_01bb:
					flag2 = true;
					num = 906829110;
					continue;
					IL_00cb:
					int num3;
					if (guivIoOtvcGGUgbWBcrfbLNSSgGh != KeyState.KeyFirst)
					{
						num = 906829104;
						num3 = num;
					}
					else
					{
						num = 906829103;
						num3 = num;
					}
				}
				goto case Keys.Menu;
				end_IL_00f5:
				break;
			}
			break;
		}
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			KeyState guivIoOtvcGGUgbWBcrfbLNSSgGh2 = P_0.guivIoOtvcGGUgbWBcrfbLNSSgGh;
			if (guivIoOtvcGGUgbWBcrfbLNSSgGh2 == KeyState.KeyFirst)
			{
				goto IL_0371;
			}
			if (guivIoOtvcGGUgbWBcrfbLNSSgGh2 == KeyState.SystemKeyDown)
			{
				goto IL_0347;
			}
			goto IL_0386;
			IL_0371:
			XAyZpDhVPdhNMPDCFRFsTAuZVfF[(int)P_0.QxCyIbDyCmOiHZZcYITHlevsHEY] = true;
			int num4 = 906829119;
			goto IL_034c;
			IL_0347:
			num4 = 906829118;
			goto IL_034c;
			IL_034c:
			int count = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num4 ^ 0x360D1D3F)
				{
				case 2:
					break;
				case 1:
					goto IL_0371;
				case 3:
					goto IL_0386;
				case 0:
					count = piKoUxmrMerfAglUXqXbrnWETOs.Count;
					num5 = 0;
					num4 = 906829114;
					continue;
				case 4:
					piKoUxmrMerfAglUXqXbrnWETOs[num5].MgtrORcuxoECdpDqmoGlFAnoCz(P_0);
					num5++;
					num4 = 906829114;
					continue;
				default:
					if (num5 >= count)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0347;
			IL_0386:
			XAyZpDhVPdhNMPDCFRFsTAuZVfF[(int)P_0.QxCyIbDyCmOiHZZcYITHlevsHEY] = false;
			num4 = 906829119;
			goto IL_034c;
		}
	}

	public void yRdrULZFsagIEVrPsPcWDOWjCdhH(bool P_0)
	{
		SHJRhOlimDwLjNdaQwaAPwjoBIq();
	}

	public void FtQMeykQvehoqnnZziMNKixBdnK(bool P_0)
	{
		int num = FOdNxLQXaXoFVqyRSyfyeevnORf();
		while (true)
		{
			int num2 = 766345138;
			while (true)
			{
				switch (num2 ^ 0x2DAD7FB3)
				{
				case 2:
					break;
				default:
					return;
				case 1:
				{
					int num3;
					if (num >= 0)
					{
						num2 = 766345136;
						num3 = num2;
					}
					else
					{
						num2 = 766345139;
						num3 = num2;
					}
					continue;
				}
				case 0:
					SHJRhOlimDwLjNdaQwaAPwjoBIq();
					num2 = 766345136;
					continue;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private int FOdNxLQXaXoFVqyRSyfyeevnORf()
	{
		int num = mLFGYdXdfbbtVuBHHjYETeJgec;
		if (YkKIPPiCWZeAzAfNMTiDRgJXluDN.hbViCuxTSCahxePjlnRUwRUZuRvK(QTBMtemSTKEFyypUdDxnYBkZCjsF.otHBHGZfzdEKPVeyweIkhCMmKxf, out var num2))
		{
			mLFGYdXdfbbtVuBHHjYETeJgec = num2;
			goto IL_0018;
		}
		goto IL_0041;
		IL_0041:
		mLFGYdXdfbbtVuBHHjYETeJgec = 1;
		int num3 = -69363451;
		goto IL_001d;
		IL_0018:
		num3 = -69363452;
		goto IL_001d;
		IL_001d:
		while (true)
		{
			switch (num3 ^ -69363451)
			{
			case 3:
				break;
			case 1:
				num3 = -69363451;
				continue;
			case 2:
				goto IL_0041;
			default:
				return mLFGYdXdfbbtVuBHHjYETeJgec - num;
			}
			break;
		}
		goto IL_0018;
	}

	private void ZhtNyHCNouilkiOwVeXopAYTKgl(bool P_0)
	{
		AuSfBgNJvdyvCemJZTwlrQYgnr = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (P_0)
		{
			return;
		}
		while (!AuSfBgNJvdyvCemJZTwlrQYgnr)
		{
			SHJRhOlimDwLjNdaQwaAPwjoBIq();
			int num = -1078855105;
			while (true)
			{
				switch (num ^ -1078855107)
				{
				case 0:
					goto IL_0010;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0010:
				num = -1078855108;
			}
		}
	}

	private void SSNYvrcdzAoOjvBXDhnpIfDMHLe(bool P_0)
	{
	}

	private void oZDzLjcaKWUyGIjWfYXzuzUxeco(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		while (true)
		{
			AuSfBgNJvdyvCemJZTwlrQYgnr = ReInput.IsInputAllowed(ControllerType.Keyboard);
			int num = -2083381374;
			while (true)
			{
				switch (num ^ -2083381376)
				{
				case 0:
					goto IL_000f;
				case 1:
					break;
				default:
					lock (VscpWqBWzuDusblaKBCJNvlmplv)
					{
						piKoUxmrMerfAglUXqXbrnWETOs[piKoUxmrMerfAglUXqXbrnWETOs.fixedUpdateSetIndex].SqoZNSJDzCagYFujVEtRFqPCrBef();
						return;
					}
				}
				break;
				IL_000f:
				num = -2083381375;
			}
		}
	}

	private void xylQXgmJgMaNzIbeWgxuADDXkzHn(UpdateLoopType P_0)
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			piKoUxmrMerfAglUXqXbrnWETOs.Get(P_0).fHvlAyzcxwcbEJYkeBnphlWsGSD();
		}
	}

	private void SHJRhOlimDwLjNdaQwaAPwjoBIq()
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			int count = piKoUxmrMerfAglUXqXbrnWETOs.Count;
			int num = 0;
			while (true)
			{
				int num2 = -450701590;
				while (true)
				{
					switch (num2 ^ -450701589)
					{
					case 2:
						break;
					case 1:
						num2 = -450701589;
						continue;
					case 3:
						piKoUxmrMerfAglUXqXbrnWETOs[num].RFDPexajhTcXvizzpCmOkHbzMGox();
						num++;
						num2 = -450701589;
						continue;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		piKoUxmrMerfAglUXqXbrnWETOs.Current.PUNhNkYNeXdWTDciGPhTFmSiXuyR(dataUpdater);
	}

	public void Clear()
	{
		SHJRhOlimDwLjNdaQwaAPwjoBIq();
	}

	private static HardwareControllerMap_Game pssshskLLdlkShgSdjTWPPtvjJV()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		int num = 0;
		int[] array2 = default(int[]);
		int num2 = default(int);
		HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
		int num4 = default(int);
		while (true)
		{
			int num3;
			if (num >= array.Length)
			{
				array2 = new int[132];
				num2 = 0;
				num3 = -1295498386;
				goto IL_0014;
			}
			goto IL_00ba;
			IL_0014:
			while (true)
			{
				switch (num3 ^ -1295498393)
				{
				case 0:
					num3 = -1295498395;
					continue;
				case 1:
					array2[num2] = array[num2].id;
					num2++;
					num3 = -1295498400;
					continue;
				case 3:
					num++;
					num3 = -1295498399;
					continue;
				case 6:
					break;
				case 5:
					array3[num4] = new HardwareButtonInfo();
					num4++;
					num3 = -1295498385;
					continue;
				case 4:
					array3 = new HardwareButtonInfo[132];
					num4 = 0;
					num3 = -1295498385;
					continue;
				case 2:
					goto IL_00ba;
				case 7:
					goto IL_00ea;
				case 9:
					num3 = -1295498400;
					continue;
				default:
					if (num4 >= 132)
					{
						return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
					}
					goto case 5;
				}
				break;
				IL_00ea:
				int num5;
				if (num2 < 132)
				{
					num3 = -1295498394;
					num5 = num3;
				}
				else
				{
					num3 = -1295498397;
					num5 = num3;
				}
			}
			continue;
			IL_00ba:
			array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, isMappableOnPlatform: true);
			num3 = -1295498396;
			goto IL_0014;
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~uXmfJyNysxkJVMfVjUMqRSBUjHs()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		while (true)
		{
			ReInput.ApplicationFocusChangedEvent -= ZhtNyHCNouilkiOwVeXopAYTKgl;
			ReInput.EditorPauseChangedEvent -= SSNYvrcdzAoOjvBXDhnpIfDMHLe;
			int num = 43560849;
			while (true)
			{
				switch (num ^ 0x298AF93)
				{
				case 0:
					num = 43560850;
					continue;
				case 1:
					break;
				case 2:
					ReInput.UpdateEndedEvent -= xylQXgmJgMaNzIbeWgxuADDXkzHn;
					ReInput.TimeScalePauseChangedEvent -= oZDzLjcaKWUyGIjWfYXzuzUxeco;
					num = 43560848;
					continue;
				default:
					inweGjIgYacXYohFlYRlpMFkgKMi = true;
					return;
				}
				break;
			}
		}
	}

	public static int BvtpBMwnUaIEkJGnrfTDKyhHpeHr(aTdyQHLUTWxtxOewXyYbXIrqYcL P_0, KeyCode[] P_1)
	{
		Keys qxCyIbDyCmOiHZZcYITHlevsHEY = P_0.QxCyIbDyCmOiHZZcYITHlevsHEY;
		int result = 0;
		WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier keyboardIdentifier = default(WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier);
		while (true)
		{
			int num = 377081206;
			while (true)
			{
				switch (num ^ 0x1679CD2C)
				{
				case 107:
					break;
				case 41:
					num = 377081149;
					continue;
				case 122:
					P_1[result++] = KeyCode.RightArrow;
					num = 377081190;
					continue;
				case 72:
					goto IL_023e;
				case 19:
					goto IL_0254;
				case 53:
					goto IL_0267;
				case 52:
				{
					if (!cCevMVJJsJmkFLlYWoJRKIyduej(qxCyIbDyCmOiHZZcYITHlevsHEY))
					{
						goto case 14;
					}
					if (iGEVvwhWjsbJfRHYjtdyvtbQThX(qxCyIbDyCmOiHZZcYITHlevsHEY, keyboardIdentifier, out var keyCode))
					{
						P_1[result++] = keyCode;
						num = 377081149;
						continue;
					}
					goto IL_0e1f;
				}
				case 89:
					num = 377081149;
					continue;
				case 10:
					goto IL_02af;
				case 7:
					num = 377081149;
					continue;
				case 66:
					goto IL_02cc;
				case 81:
					goto IL_02df;
				case 42:
					goto IL_02f2;
				case 102:
					goto IL_0308;
				case 40:
					goto IL_031e;
				case 33:
					num = 377081149;
					continue;
				case 69:
					goto IL_033b;
				case 12:
					num = 377081149;
					continue;
				case 8:
					num = 377081149;
					continue;
				case 117:
					num = 377081149;
					continue;
				case 54:
					goto IL_036f;
				case 59:
					num = 377081149;
					continue;
				case 110:
					goto IL_038f;
				case 87:
					goto IL_03a2;
				case 98:
					num = 377081149;
					continue;
				case 103:
					num = 377081149;
					continue;
				case 70:
					goto IL_03c9;
				case 47:
					goto IL_03dc;
				case 5:
					goto IL_03f2;
				case 11:
					goto IL_0408;
				case 20:
					num = 377081149;
					continue;
				case 50:
					goto IL_0436;
				case 44:
					goto IL_044c;
				case 39:
					goto IL_0462;
				case 51:
					goto IL_0478;
				case 64:
					goto IL_048e;
				case 63:
					goto IL_04a4;
				case 27:
					goto IL_04ba;
				case 82:
					goto IL_04d0;
				case 22:
					goto IL_04e3;
				case 92:
					goto IL_04f9;
				case 126:
					goto IL_050c;
				case 0:
					num = 377081149;
					continue;
				case 73:
					goto IL_0529;
				case 104:
					goto IL_053c;
				case 56:
					goto IL_054f;
				case 57:
					goto IL_0562;
				case 55:
					goto IL_0575;
				case 118:
					num = 377081149;
					continue;
				case 23:
					goto IL_0595;
				case 86:
					num = 377081149;
					continue;
				case 14:
					switch (qxCyIbDyCmOiHZZcYITHlevsHEY)
					{
					case Keys.Right:
						break;
					case Keys.NumPad4:
						goto IL_023e;
					case Keys.L:
						goto IL_0254;
					case Keys.D0:
						goto IL_0267;
					case Keys.Space:
						goto IL_02af;
					case Keys.O:
						goto IL_02cc;
					case Keys.Delete:
						goto IL_02df;
					case Keys.F3:
						goto IL_02f2;
					case Keys.Print:
						goto IL_0308;
					case Keys.Tab:
						goto IL_031e;
					case Keys.Decimal:
						goto IL_033b;
					case Keys.Next:
						goto IL_036f;
					case Keys.I:
						goto IL_038f;
					case Keys.Z:
						goto IL_03a2;
					case Keys.D2:
						goto IL_03c9;
					case Keys.F4:
						goto IL_03dc;
					case Keys.Up:
						goto IL_03f2;
					case Keys.Return:
						goto IL_0408;
					case Keys.F13:
						goto IL_0436;
					case Keys.F5:
						goto IL_044c;
					case Keys.F12:
						goto IL_0462;
					case Keys.RShiftKey:
						goto IL_0478;
					case Keys.F14:
						goto IL_048e;
					case Keys.F11:
						goto IL_04a4;
					case Keys.NumPad0:
						goto IL_04ba;
					case Keys.B:
						goto IL_04d0;
					case Keys.NumPad8:
						goto IL_04e3;
					case Keys.Escape:
						goto IL_04f9;
					case Keys.V:
						goto IL_050c;
					case Keys.D8:
						goto IL_0529;
					case Keys.Y:
						goto IL_053c;
					case Keys.D1:
						goto IL_054f;
					case Keys.D5:
						goto IL_0562;
					case Keys.Subtract:
						goto IL_0575;
					case Keys.RWin:
						goto IL_0595;
					default:
						goto IL_0857;
					case Keys.A:
						goto IL_0861;
					case Keys.H:
						goto IL_0874;
					case Keys.RControlKey:
						goto IL_0887;
					case Keys.Pause:
						goto IL_089d;
					case Keys.End:
						goto IL_08b0;
					case Keys.F:
						goto IL_08c6;
					case Keys.Apps:
						goto IL_08d9;
					case Keys.NumPad7:
						goto IL_08ef;
					case Keys.LControlKey:
						goto IL_0905;
					case Keys.LWin:
						goto IL_091b;
					case Keys.NumPad5:
						goto IL_093b;
					case Keys.D7:
						goto IL_0951;
					case Keys.Clear:
						goto IL_0964;
					case Keys.Divide:
						goto IL_0977;
					case Keys.RMenu:
						goto IL_098d;
					case Keys.Q:
						goto IL_09af;
					case Keys.F15:
						goto IL_09c2;
					case Keys.D6:
						goto IL_09d8;
					case Keys.X:
						goto IL_09f5;
					case Keys.F7:
						goto IL_0a08;
					case Keys.F2:
						goto IL_0a28;
					case Keys.Add:
						goto IL_0a3e;
					case Keys.Insert:
						goto IL_0a54;
					case Keys.Multiply:
						goto IL_0a74;
					case Keys.J:
						goto IL_0a94;
					case Keys.NumPad9:
						goto IL_0ab1;
					case Keys.D4:
						goto IL_0ac7;
					case Keys.E:
						goto IL_0ada;
					case Keys.Capital:
						goto IL_0aed;
					case Keys.D9:
						goto IL_0b21;
					case Keys.Down:
						goto IL_0b34;
					case Keys.F10:
						goto IL_0b4a;
					case Keys.LMenu:
						goto IL_0b60;
					case Keys.S:
						goto IL_0b76;
					case Keys.Prior:
						goto IL_0b89;
					case Keys.NumPad3:
						goto IL_0b9f;
					case Keys.Help:
						goto IL_0bbf;
					case Keys.N:
						goto IL_0bd5;
					case Keys.Scroll:
						goto IL_0be8;
					case Keys.P:
						goto IL_0bfe;
					case Keys.D:
						goto IL_0c11;
					case Keys.Back:
						goto IL_0c24;
					case Keys.C:
						goto IL_0c36;
					case Keys.LShiftKey:
						goto IL_0c49;
					case Keys.G:
						goto IL_0c5f;
					case Keys.F6:
						goto IL_0c72;
					case Keys.NumPad1:
						goto IL_0c9b;
					case Keys.None:
						goto IL_0cb1;
					case Keys.Home:
						goto IL_0cea;
					case Keys.Left:
						goto IL_0d00;
					case Keys.R:
						goto IL_0d16;
					case Keys.F9:
						goto IL_0d29;
					case Keys.NumLock:
						goto IL_0d3f;
					case Keys.W:
						goto IL_0d55;
					case Keys.D3:
						goto IL_0d68;
					case Keys.K:
						goto IL_0d7b;
					case Keys.F1:
						goto IL_0d8e;
					case Keys.T:
						goto IL_0da4;
					case Keys.NumPad6:
						goto IL_0db7;
					case Keys.NumPad2:
						goto IL_0dcd;
					case Keys.U:
						goto IL_0de3;
					case Keys.M:
						goto IL_0df6;
					case Keys.F8:
						goto IL_0e09;
					case Keys.LButton:
					case Keys.RButton:
					case Keys.Cancel:
					case Keys.MButton:
					case Keys.XButton1:
					case Keys.XButton2:
					case (Keys)7:
					case Keys.LineFeed:
					case (Keys)11:
					case (Keys)14:
					case (Keys)15:
					case Keys.ShiftKey:
					case Keys.ControlKey:
					case Keys.Menu:
					case Keys.KanaMode:
					case (Keys)22:
					case Keys.JunjaMode:
					case Keys.FinalMode:
					case Keys.HanjaMode:
					case (Keys)26:
					case Keys.IMEConvert:
					case Keys.IMENonconvert:
					case Keys.IMEAccept:
					case Keys.IMEModeChange:
					case Keys.Select:
					case Keys.Execute:
					case Keys.Snapshot:
					case (Keys)58:
					case (Keys)59:
					case (Keys)60:
					case (Keys)61:
					case (Keys)62:
					case (Keys)63:
					case (Keys)64:
					case (Keys)94:
					case Keys.Sleep:
					case Keys.Separator:
					case Keys.F16:
					case Keys.F17:
					case Keys.F18:
					case Keys.F19:
					case Keys.F20:
					case Keys.F21:
					case Keys.F22:
					case Keys.F23:
					case Keys.F24:
					case (Keys)136:
					case (Keys)137:
					case (Keys)138:
					case (Keys)139:
					case (Keys)140:
					case (Keys)141:
					case (Keys)142:
					case (Keys)143:
					case (Keys)146:
					case (Keys)147:
					case (Keys)148:
					case (Keys)149:
					case (Keys)150:
					case (Keys)151:
					case (Keys)152:
					case (Keys)153:
					case (Keys)154:
					case (Keys)155:
					case (Keys)156:
					case (Keys)157:
					case (Keys)158:
					case (Keys)159:
						goto IL_0e1f;
					}
					goto case 122;
				case 84:
					goto IL_0861;
				case 76:
					goto IL_0874;
				case 2:
					goto IL_0887;
				case 49:
					goto IL_089d;
				case 123:
					goto IL_08b0;
				case 67:
					goto IL_08c6;
				case 31:
					goto IL_08d9;
				case 21:
					goto IL_08ef;
				case 58:
					goto IL_0905;
				case 25:
					goto IL_091b;
				case 32:
					num = 377081149;
					continue;
				case 77:
					goto IL_093b;
				case 105:
					goto IL_0951;
				case 62:
					goto IL_0964;
				case 88:
					goto IL_0977;
				case 9:
					goto IL_098d;
				case 1:
					goto IL_09af;
				case 113:
					goto IL_09c2;
				case 43:
					goto IL_09d8;
				case 28:
					num = 377081149;
					continue;
				case 48:
					goto IL_09f5;
				case 61:
					goto IL_0a08;
				case 75:
					num = 377081149;
					continue;
				case 36:
					goto IL_0a28;
				case 83:
					goto IL_0a3e;
				case 29:
					goto IL_0a54;
				case 124:
					num = 377081149;
					continue;
				case 37:
					goto IL_0a74;
				case 95:
					num = 377081149;
					continue;
				case 96:
					goto IL_0a94;
				case 35:
					num = 377081149;
					continue;
				case 15:
					goto IL_0ab1;
				case 99:
					goto IL_0ac7;
				case 85:
					goto IL_0ada;
				case 71:
					goto IL_0aed;
				case 111:
					num = 377081149;
					continue;
				case 74:
					num = 377081149;
					continue;
				case 120:
					num = 377081149;
					continue;
				case 93:
					goto IL_0b21;
				case 79:
					goto IL_0b34;
				case 68:
					goto IL_0b4a;
				case 94:
					goto IL_0b60;
				case 108:
					goto IL_0b76;
				case 101:
					goto IL_0b89;
				case 106:
					goto IL_0b9f;
				case 6:
					num = 377081149;
					continue;
				case 18:
					goto IL_0bbf;
				case 60:
					goto IL_0bd5;
				case 4:
					goto IL_0be8;
				case 13:
					goto IL_0bfe;
				case 127:
					goto IL_0c11;
				case 26:
					goto IL_0c24;
				case 3:
					goto IL_0c36;
				case 119:
					goto IL_0c49;
				case 91:
					goto IL_0c5f;
				case 112:
					goto IL_0c72;
				case 116:
					P_1[result++] = KeyCode.Return;
					num = 377081149;
					continue;
				case 100:
					goto IL_0c9b;
				case 109:
					goto IL_0cb1;
				case 90:
					keyboardIdentifier = NYZDUZHGoetJNYTUHlwxYgJrDR();
					_ = GFEgkfUWOdgKMrUokQFNFLZdVGo;
					YksGHYKteMuhDXToEsEFZvCVfCJ.MfGIsGJbNoMXRHYIcTfMlrnkroT((uint)P_0.QxCyIbDyCmOiHZZcYITHlevsHEY, WgyDhDKPtxBNfGUTiXnlxotcDalv.wcdreUNIukUPXKCjAIpcBVteIPF);
					num = 377081112;
					continue;
				case 45:
					goto IL_0cea;
				case 65:
					goto IL_0d00;
				case 115:
					goto IL_0d16;
				case 46:
					goto IL_0d29;
				case 34:
					goto IL_0d3f;
				case 78:
					goto IL_0d55;
				case 16:
					goto IL_0d68;
				case 125:
					goto IL_0d7b;
				case 30:
					goto IL_0d8e;
				case 80:
					goto IL_0da4;
				case 24:
					goto IL_0db7;
				case 114:
					goto IL_0dcd;
				case 38:
					goto IL_0de3;
				case 121:
					goto IL_0df6;
				case 97:
					goto IL_0e09;
				default:
					goto IL_0e1f;
					IL_023e:
					P_1[result++] = KeyCode.Keypad4;
					num = 377081149;
					continue;
					IL_0e1f:
					return result;
					IL_0e09:
					P_1[result++] = KeyCode.F8;
					num = 377081149;
					continue;
					IL_0df6:
					P_1[result++] = KeyCode.M;
					num = 377081163;
					continue;
					IL_0de3:
					P_1[result++] = KeyCode.U;
					num = 377081149;
					continue;
					IL_0dcd:
					P_1[result++] = KeyCode.Keypad2;
					num = 377081132;
					continue;
					IL_0db7:
					P_1[result++] = KeyCode.Keypad6;
					num = 377081149;
					continue;
					IL_0da4:
					P_1[result++] = KeyCode.T;
					num = 377081149;
					continue;
					IL_0d8e:
					P_1[result++] = KeyCode.F1;
					num = 377081149;
					continue;
					IL_0d7b:
					P_1[result++] = KeyCode.K;
					num = 377081149;
					continue;
					IL_0d68:
					P_1[result++] = KeyCode.Alpha3;
					num = 377081149;
					continue;
					IL_0d55:
					P_1[result++] = KeyCode.W;
					num = 377081149;
					continue;
					IL_0d3f:
					P_1[result++] = KeyCode.Numlock;
					num = 377081149;
					continue;
					IL_0d29:
					P_1[result++] = KeyCode.F9;
					num = 377081149;
					continue;
					IL_0d16:
					P_1[result++] = KeyCode.R;
					num = 377081149;
					continue;
					IL_0d00:
					P_1[result++] = KeyCode.LeftArrow;
					num = 377081155;
					continue;
					IL_0cea:
					P_1[result++] = KeyCode.Home;
					num = 377081205;
					continue;
					IL_0cb1:
					P_1[result++] = KeyCode.None;
					num = 377081101;
					continue;
					IL_0c9b:
					P_1[result++] = KeyCode.Keypad1;
					num = 377081130;
					continue;
					IL_0c72:
					P_1[result++] = KeyCode.F6;
					num = 377081149;
					continue;
					IL_0c5f:
					P_1[result++] = KeyCode.G;
					num = 377081136;
					continue;
					IL_0c49:
					P_1[result++] = KeyCode.LeftShift;
					num = 377081149;
					continue;
					IL_0c36:
					P_1[result++] = KeyCode.C;
					num = 377081149;
					continue;
					IL_0c24:
					P_1[result++] = KeyCode.Backspace;
					num = 377081149;
					continue;
					IL_0c11:
					P_1[result++] = KeyCode.D;
					num = 377081149;
					continue;
					IL_0bfe:
					P_1[result++] = KeyCode.P;
					num = 377081149;
					continue;
					IL_0be8:
					P_1[result++] = KeyCode.ScrollLock;
					num = 377081149;
					continue;
					IL_0bd5:
					P_1[result++] = KeyCode.N;
					num = 377081149;
					continue;
					IL_0bbf:
					P_1[result++] = KeyCode.Help;
					num = 377081149;
					continue;
					IL_0b9f:
					P_1[result++] = KeyCode.Keypad3;
					num = 377081149;
					continue;
					IL_0b89:
					P_1[result++] = KeyCode.PageUp;
					num = 377081149;
					continue;
					IL_0b76:
					P_1[result++] = KeyCode.S;
					num = 377081149;
					continue;
					IL_0b60:
					P_1[result++] = KeyCode.LeftAlt;
					num = 377081149;
					continue;
					IL_0b4a:
					P_1[result++] = KeyCode.F10;
					num = 377081149;
					continue;
					IL_0b34:
					P_1[result++] = KeyCode.DownArrow;
					num = 377081149;
					continue;
					IL_0b21:
					P_1[result++] = KeyCode.Alpha9;
					num = 377081149;
					continue;
					IL_0aed:
					P_1[result++] = KeyCode.CapsLock;
					num = 377081149;
					continue;
					IL_0ada:
					P_1[result++] = KeyCode.E;
					num = 377081177;
					continue;
					IL_0ac7:
					P_1[result++] = KeyCode.Alpha4;
					num = 377081149;
					continue;
					IL_0ab1:
					P_1[result++] = KeyCode.Keypad9;
					num = 377081149;
					continue;
					IL_0a94:
					P_1[result++] = KeyCode.J;
					num = 377081149;
					continue;
					IL_0a74:
					P_1[result++] = KeyCode.KeypadMultiply;
					num = 377081149;
					continue;
					IL_0a54:
					P_1[result++] = KeyCode.Insert;
					num = 377081131;
					continue;
					IL_0a3e:
					P_1[result++] = KeyCode.KeypadPlus;
					num = 377081149;
					continue;
					IL_0a28:
					P_1[result++] = KeyCode.F2;
					num = 377081149;
					continue;
					IL_0a08:
					P_1[result++] = KeyCode.F7;
					num = 377081149;
					continue;
					IL_09f5:
					P_1[result++] = KeyCode.X;
					num = 377081111;
					continue;
					IL_09d8:
					P_1[result++] = KeyCode.Alpha6;
					num = 377081149;
					continue;
					IL_09c2:
					P_1[result++] = KeyCode.F15;
					num = 377081093;
					continue;
					IL_09af:
					P_1[result++] = KeyCode.Q;
					num = 377081149;
					continue;
					IL_098d:
					P_1[result++] = KeyCode.AltGr;
					P_1[result++] = KeyCode.RightAlt;
					num = 377081149;
					continue;
					IL_0977:
					P_1[result++] = KeyCode.KeypadDivide;
					num = 377081149;
					continue;
					IL_0964:
					P_1[result++] = KeyCode.Clear;
					num = 377081149;
					continue;
					IL_0951:
					P_1[result++] = KeyCode.Alpha7;
					num = 377081149;
					continue;
					IL_093b:
					P_1[result++] = KeyCode.Keypad5;
					num = 377081168;
					continue;
					IL_091b:
					P_1[result++] = KeyCode.LeftCommand;
					num = 377081149;
					continue;
					IL_0905:
					P_1[result++] = KeyCode.LeftControl;
					num = 377081149;
					continue;
					IL_08ef:
					P_1[result++] = KeyCode.Keypad7;
					num = 377081149;
					continue;
					IL_08d9:
					P_1[result++] = KeyCode.Menu;
					num = 377081149;
					continue;
					IL_08c6:
					P_1[result++] = KeyCode.F;
					num = 377081149;
					continue;
					IL_08b0:
					P_1[result++] = KeyCode.End;
					num = 377081149;
					continue;
					IL_089d:
					P_1[result++] = KeyCode.Pause;
					num = 377081149;
					continue;
					IL_0887:
					P_1[result++] = KeyCode.RightControl;
					num = 377081149;
					continue;
					IL_0874:
					P_1[result++] = KeyCode.H;
					num = 377081149;
					continue;
					IL_0861:
					P_1[result++] = KeyCode.A;
					num = 377081149;
					continue;
					IL_0857:
					num = 377081149;
					continue;
					IL_0595:
					P_1[result++] = KeyCode.RightCommand;
					num = 377081149;
					continue;
					IL_0575:
					P_1[result++] = KeyCode.KeypadMinus;
					num = 377081149;
					continue;
					IL_0562:
					P_1[result++] = KeyCode.Alpha5;
					num = 377081149;
					continue;
					IL_054f:
					P_1[result++] = KeyCode.Alpha1;
					num = 377081144;
					continue;
					IL_053c:
					P_1[result++] = KeyCode.Y;
					num = 377081103;
					continue;
					IL_0529:
					P_1[result++] = KeyCode.Alpha8;
					num = 377081191;
					continue;
					IL_050c:
					P_1[result++] = KeyCode.V;
					num = 377081149;
					continue;
					IL_04f9:
					P_1[result++] = KeyCode.Escape;
					num = 377081210;
					continue;
					IL_04e3:
					P_1[result++] = KeyCode.Keypad8;
					num = 377081149;
					continue;
					IL_04d0:
					P_1[result++] = KeyCode.B;
					num = 377081149;
					continue;
					IL_04ba:
					P_1[result++] = KeyCode.Keypad0;
					num = 377081166;
					continue;
					IL_04a4:
					P_1[result++] = KeyCode.F11;
					num = 377081149;
					continue;
					IL_048e:
					P_1[result++] = KeyCode.F14;
					num = 377081149;
					continue;
					IL_0478:
					P_1[result++] = KeyCode.RightShift;
					num = 377081149;
					continue;
					IL_0462:
					P_1[result++] = KeyCode.F12;
					num = 377081149;
					continue;
					IL_044c:
					P_1[result++] = KeyCode.F5;
					num = 377081149;
					continue;
					IL_0436:
					P_1[result++] = KeyCode.F13;
					num = 377081149;
					continue;
					IL_0408:
					if ((P_0.nAqlsKIvNUaQezRRzExFARhMBkZn & ScanCodeFlags.E0) != ScanCodeFlags.Make)
					{
						P_1[result++] = KeyCode.KeypadEnter;
						num = 377081124;
						continue;
					}
					goto case 116;
					IL_03f2:
					P_1[result++] = KeyCode.UpArrow;
					num = 377081203;
					continue;
					IL_03dc:
					P_1[result++] = KeyCode.F4;
					num = 377081149;
					continue;
					IL_03c9:
					P_1[result++] = KeyCode.Alpha2;
					num = 377081120;
					continue;
					IL_03a2:
					P_1[result++] = KeyCode.Z;
					num = 377081149;
					continue;
					IL_038f:
					P_1[result++] = KeyCode.I;
					num = 377081149;
					continue;
					IL_036f:
					P_1[result++] = KeyCode.PageDown;
					num = 377081149;
					continue;
					IL_033b:
					P_1[result++] = KeyCode.KeypadPeriod;
					num = 377081149;
					continue;
					IL_031e:
					P_1[result++] = KeyCode.Tab;
					num = 377081100;
					continue;
					IL_0308:
					P_1[result++] = KeyCode.Print;
					num = 377081172;
					continue;
					IL_02f2:
					P_1[result++] = KeyCode.F3;
					num = 377081149;
					continue;
					IL_02df:
					P_1[result++] = KeyCode.Delete;
					num = 377081149;
					continue;
					IL_02cc:
					P_1[result++] = KeyCode.O;
					num = 377081178;
					continue;
					IL_02af:
					P_1[result++] = KeyCode.Space;
					num = 377081149;
					continue;
					IL_0267:
					P_1[result++] = KeyCode.Alpha0;
					num = 377081149;
					continue;
					IL_0254:
					P_1[result++] = KeyCode.L;
					num = 377081149;
					continue;
				}
				break;
			}
		}
	}

	private unsafe static WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier NYZDUZHGoetJNYTUHlwxYgJrDR()
	{
		IntPtr intPtr = YksGHYKteMuhDXToEsEFZvCVfCJ.GPlXnPwyayGHuUaWKRjNRnrYLwR(0);
		WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier keyboardIdentifier = default(WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier);
		int result = default(int);
		while (true)
		{
			int num = -505947460;
			while (true)
			{
				switch (num ^ -505947458)
				{
				case 0:
					break;
				case 2:
				{
					if (intPtr == GFEgkfUWOdgKMrUokQFNFLZdVGo)
					{
						return EGBEtGUfIppzarOYSakHtroiNQp;
					}
					keyboardIdentifier = WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier.United_States_English;
					byte* ptr = stackalloc byte[128];
					YksGHYKteMuhDXToEsEFZvCVfCJ.xqTzAQfWKYOloTgCbGROekHAFgwR((IntPtr)ptr);
					string s = Marshal.PtrToStringUni((IntPtr)ptr);
					int num3;
					if (!int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result))
					{
						num = -505947459;
						num3 = num;
					}
					else
					{
						num = -505947457;
						num3 = num;
					}
					continue;
				}
				case 1:
				{
					int num2 = ArrayTools.IndexOf(VkpBPQoJHeYGsOBhtygXHUICAQP, result);
					if (num2 >= 0)
					{
						keyboardIdentifier = (WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier)VkpBPQoJHeYGsOBhtygXHUICAQP[num2];
						num = -505947459;
						continue;
					}
					goto default;
				}
				default:
					GFEgkfUWOdgKMrUokQFNFLZdVGo = intPtr;
					EGBEtGUfIppzarOYSakHtroiNQp = keyboardIdentifier;
					return keyboardIdentifier;
				}
				break;
			}
		}
	}

	private static bool iGEVvwhWjsbJfRHYjtdyvtbQThX(Keys P_0, WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!dfrUHtlDgDjlOXRowYewEfFZfJT.TryGetValue((int)P_1, out var value))
		{
			value = dfrUHtlDgDjlOXRowYewEfFZfJT[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != WgyDhDKPtxBNfGUTiXnlxotcDalv.KeyboardIdentifier.United_States_English)
		{
			value = dfrUHtlDgDjlOXRowYewEfFZfJT[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool cCevMVJJsJmkFLlYWoJRKIyduej(Keys P_0)
	{
		return ArrayTools.Contains(RurklHhVvKbrdzggOdDsDgiLuFpl, (int)P_0);
	}
}
