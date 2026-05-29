using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.Windows.Forms;
using Rewired.Utils;
using UnityEngine;

internal class hKTkpUPnMJRQrUCFJINGfAbSxtx : IDisposable, IUnifiedKeyboardSource
{
	private class DWjSpWjVNiSrRNtTaRFPWOxpFWG
	{
		private enum PVSuEfWFoCdRpWfiEXsloJSAjJJ
		{
			PkbJcFPqmFczuJhwlfomqbZGagG = 0,
			PYCdhgdNGUBeiWtFGdXfdWZDram = 1,
			sIYYgAPYDeOHopOAiVHlEsqvjUR = 2
		}

		private const int VpygQdOCuGRQOGgMtLazdyrSvxB = 2;

		private static readonly KeyCode[] wSzzPTEAdmfOOggjKOEkMWOyOnsc = new KeyCode[2];

		private readonly UpdateLoopType wSHzZBTWZLoZZISsJufEGOHfIfo;

		private bool[] jmPEUpGFMHctZATktVWKmrRhhCb;

		private bool[] CtVEJTZNVkwWmHiaDNwURAHwGBl;

		private uint fUhElpEgCbeIAtRdGDrSvixKkmxF;

		public DWjSpWjVNiSrRNtTaRFPWOxpFWG(UpdateLoopType updateLoop)
		{
			wSHzZBTWZLoZZISsJufEGOHfIfo = updateLoop;
			jmPEUpGFMHctZATktVWKmrRhhCb = new bool[132];
			CtVEJTZNVkwWmHiaDNwURAHwGBl = new bool[132];
		}

		public void JhDhfqHiQYwUgddZAQhegkgbywD(bzEIwBRfuczFFAoUzMzCAMnmSUI P_0)
		{
			int num = EWALSHqiySalYVQHHAuPlUCPqPz(P_0, wSzzPTEAdmfOOggjKOEkMWOyOnsc);
			int num2 = 0;
			rUShqwQHDKddGacUEheMXiwWBkX rUShqwQHDKddGacUEheMXiwWBkX2 = default(rUShqwQHDKddGacUEheMXiwWBkX);
			int num6 = default(int);
			bool flag = default(bool);
			while (num2 < num)
			{
				while (true)
				{
					IL_00af:
					int num3 = (int)wSzzPTEAdmfOOggjKOEkMWOyOnsc[num2];
					int num4;
					if (num3 >= 0)
					{
						int num5;
						if (num3 >= HXjWcHTqKVpzfgaifJjOxbEjFXG.Length)
						{
							num4 = -298490290;
							num5 = num4;
						}
						else
						{
							num4 = -298490304;
							num5 = num4;
						}
						goto IL_0018;
					}
					goto IL_0094;
					IL_0018:
					while (true)
					{
						switch (num4 ^ -298490299)
						{
						case 2:
							num4 = -298490298;
							continue;
						case 8:
							break;
						case 5:
						{
							rUShqwQHDKddGacUEheMXiwWBkX fuBOYdEvNYkWeccvzqynAkPOwGq = P_0.fuBOYdEvNYkWeccvzqynAkPOwGq;
							rUShqwQHDKddGacUEheMXiwWBkX2 = fuBOYdEvNYkWeccvzqynAkPOwGq;
							num4 = -298490300;
							continue;
						}
						case 9:
							CtVEJTZNVkwWmHiaDNwURAHwGBl[num6] = true;
							num4 = -298490290;
							continue;
						case 11:
							goto end_IL_0018;
						case 0:
							flag = false;
							num4 = -298490301;
							continue;
						case 3:
							goto IL_00af;
						case 1:
							goto IL_00d9;
						case 4:
							goto IL_00f6;
						case 6:
							num6 = HXjWcHTqKVpzfgaifJjOxbEjFXG[num3];
							num4 = -298490303;
							continue;
						case 7:
							flag = true;
							num4 = -298490301;
							continue;
						default:
							goto end_IL_00af;
						}
						int num7;
						if (rUShqwQHDKddGacUEheMXiwWBkX2 == rUShqwQHDKddGacUEheMXiwWBkX.NSuwvythNACFhjlxVcDYYeJaoaMp)
						{
							num4 = -298490302;
							num7 = num4;
						}
						else
						{
							num4 = -298490299;
							num7 = num4;
						}
						continue;
						IL_00f6:
						bool flag2 = jmPEUpGFMHctZATktVWKmrRhhCb[num6];
						jmPEUpGFMHctZATktVWKmrRhhCb[num6] = flag;
						if (flag2)
						{
							break;
						}
						int num8;
						if (flag)
						{
							num4 = -298490292;
							num8 = num4;
						}
						else
						{
							num4 = -298490290;
							num8 = num4;
						}
						continue;
						IL_00d9:
						int num9;
						if (rUShqwQHDKddGacUEheMXiwWBkX2 != rUShqwQHDKddGacUEheMXiwWBkX.FZBqbyjYSZrJxMOyShBZyADVpMw)
						{
							num4 = -298490291;
							num9 = num4;
						}
						else
						{
							num4 = -298490302;
							num9 = num4;
						}
						continue;
						end_IL_0018:
						break;
					}
					goto IL_0094;
					IL_0094:
					num2++;
					num4 = -298490289;
					goto IL_0018;
					continue;
					end_IL_00af:
					break;
				}
			}
		}

		public void GvsBjrOWinoVlsKjosmZrtrPqqY(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < 132)
				{
					num2 = 217991924;
					num3 = num2;
				}
				else
				{
					num2 = 217991925;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0xCFE4AF6)
					{
					case 0:
						num2 = 217991924;
						continue;
					case 2:
						buttonValues[num] = jmPEUpGFMHctZATktVWKmrRhhCb[num] || CtVEJTZNVkwWmHiaDNwURAHwGBl[num];
						num++;
						num2 = 217991927;
						continue;
					case 1:
						break;
					default:
						lxfpLSFOlicUFxfxJBDRMReqihkg();
						return;
					}
					break;
				}
			}
		}

		public void cHQDtHxqOBHMTeDoAMAnUqYwlCyL()
		{
			lxfpLSFOlicUFxfxJBDRMReqihkg();
		}

		private void lxfpLSFOlicUFxfxJBDRMReqihkg()
		{
			if (fUhElpEgCbeIAtRdGDrSvixKkmxF == ReInput.absFrame)
			{
				return;
			}
			while (true)
			{
				BwPPkRHFJojOgeLLjTuFpJmbjNQ();
				fUhElpEgCbeIAtRdGDrSvixKkmxF = ReInput.absFrame;
				int num = 736266231;
				while (true)
				{
					switch (num ^ 0x2BE287F7)
					{
					case 2:
						goto IL_000e;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000e:
					num = 736266230;
				}
			}
		}

		public void BwPPkRHFJojOgeLLjTuFpJmbjNQ()
		{
			Array.Clear(CtVEJTZNVkwWmHiaDNwURAHwGBl, 0, 132);
		}

		public void UsuwPiqVitnNRnZALvWAYQYnQRS()
		{
			Array.Clear(jmPEUpGFMHctZATktVWKmrRhhCb, 0, 132);
			Array.Clear(CtVEJTZNVkwWmHiaDNwURAHwGBl, 0, 132);
		}
	}

	private const int fHHCpGAnBQuEWvqSZiewbEUiSuyP = 132;

	private readonly object QRRGShBaDEUaStPKcRtRWlMmzrR = new object();

	private UpdateLoopDataSet<DWjSpWjVNiSrRNtTaRFPWOxpFWG> ibpCLuiexKBwoqamlUDvmEzESoC;

	private HardwareControllerMap_Game kywcProzpyKAYCUwKMSZmgdyZWL;

	private bool RJDHCSyNzZgHTKlYtMvisGnMHgD;

	private static readonly int[] HXjWcHTqKVpzfgaifJjOxbEjFXG;

	private static readonly int NICkeWuwJYHOBpTvGXokKeScimm;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	private static IntPtr BhtsyPMeDyasOpGKWKVlIwpUBOW;

	private static VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier NgkhNQWeALDYDjuFyrPNwREgWZX;

	private static readonly int[] UCGfPXsvfEEoKbURJCvBNIxGIKth;

	private static Dictionary<int, Dictionary<int, KeyCode>> yrCrKaxrEhvXiFvGCpDiDesPMHd;

	private static readonly int[] KoOjYDxHZiNZIdUqsCaXjJMNDNo;

	public InputSource inputSource
	{
		get
		{
			return InputSource.RawInput;
		}
	}

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (kywcProzpyKAYCUwKMSZmgdyZWL == null)
			{
				kywcProzpyKAYCUwKMSZmgdyZWL = uyRygbwjbPqTqjKaNOACKtIbhTb();
			}
			return kywcProzpyKAYCUwKMSZmgdyZWL;
		}
	}

	public int buttonCount
	{
		get
		{
			return 132;
		}
	}

	static hKTkpUPnMJRQrUCFJINGfAbSxtx()
	{
		NgkhNQWeALDYDjuFyrPNwREgWZX = VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier.United_States_English;
		UCGfPXsvfEEoKbURJCvBNIxGIKth = (int[])Enum.GetValues(typeof(VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier));
		Dictionary<int, Dictionary<int, KeyCode>> dictionary = new Dictionary<int, Dictionary<int, KeyCode>>
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
			}
		};
		int[] keyboardKeyValues = default(int[]);
		int num4 = default(int);
		int num2 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num = 1193572889;
			while (true)
			{
				switch (num ^ 0x47247A1D)
				{
				case 8:
					break;
				case 0:
					if (keyboardKeyValues[num4] > NICkeWuwJYHOBpTvGXokKeScimm)
					{
						NICkeWuwJYHOBpTvGXokKeScimm = keyboardKeyValues[num4];
						num = 1193572884;
						continue;
					}
					goto case 9;
				case 10:
					HXjWcHTqKVpzfgaifJjOxbEjFXG[keyboardKeyValues[num2]] = num2;
					num = 1193572892;
					continue;
				case 4:
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
					yrCrKaxrEhvXiFvGCpDiDesPMHd = dictionary;
					KoOjYDxHZiNZIdUqsCaXjJMNDNo = new int[22]
					{
						186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
						254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
						186, 192
					};
					num = 1193572895;
					continue;
				case 9:
					num4++;
					num = 1193572894;
					continue;
				case 2:
					keyboardKeyValues = Consts._keyboardKeyValues;
					num3 = keyboardKeyValues.Length;
					num4 = 0;
					num = 1193572894;
					continue;
				case 7:
					num = 1193572891;
					continue;
				case 5:
					num2 = 0;
					num = 1193572890;
					continue;
				case 3:
					if (num4 >= num3)
					{
						HXjWcHTqKVpzfgaifJjOxbEjFXG = new int[NICkeWuwJYHOBpTvGXokKeScimm + 1];
						ArrayTools.Fill(HXjWcHTqKVpzfgaifJjOxbEjFXG, -1);
						num = 1193572888;
						continue;
					}
					goto case 0;
				case 1:
					num2++;
					num = 1193572891;
					continue;
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 10;
				}
				break;
			}
		}
	}

	public hKTkpUPnMJRQrUCFJINGfAbSxtx(UpdateLoopSetting updateLoopSetting)
	{
		ibpCLuiexKBwoqamlUDvmEzESoC = new UpdateLoopDataSet<DWjSpWjVNiSrRNtTaRFPWOxpFWG>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				ibpCLuiexKBwoqamlUDvmEzESoC[i] = new DWjSpWjVNiSrRNtTaRFPWOxpFWG(list[i]);
			}
		}
		RJDHCSyNzZgHTKlYtMvisGnMHgD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		ReInput.ApplicationFocusChangedEvent += YBGcPGSALKHsWiOOjIjkknlLmvR;
		ReInput.EditorPauseChangedEvent += TzkfSsaoLoOGJUjdtPituTwCfRWT;
		ReInput.UpdateEndedEvent += kQKXzfiMsaljLGGJcswSCmyJxfq;
		ReInput.TimeScalePauseChangedEvent += tteBryqoaiYMgAooPDRpjOtvqpM;
	}

	public void EhlPnfprjfkehAbDLrDcQKRlXmc(UpdateLoopType P_0)
	{
		ibpCLuiexKBwoqamlUDvmEzESoC.SetUpdateLoop(P_0);
		RJDHCSyNzZgHTKlYtMvisGnMHgD = ReInput.IsInputAllowed(ControllerType.Keyboard);
	}

	public void qDbCHnCDbcDTxgRYolAbQrAZfUj(bzEIwBRfuczFFAoUzMzCAMnmSUI P_0)
	{
		if (!RJDHCSyNzZgHTKlYtMvisGnMHgD)
		{
			return;
		}
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int count = ibpCLuiexKBwoqamlUDvmEzESoC.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -970149381;
				while (true)
				{
					switch (num ^ -970149382)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -970149382;
						continue;
					case 4:
						ibpCLuiexKBwoqamlUDvmEzESoC[num2].JhDhfqHiQYwUgddZAQhegkgbywD(P_0);
						num2++;
						num = -970149384;
						continue;
					case 0:
						num = -970149384;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}
	}

	public void pXUftSdREUzmyeRlCXpOKKdpgdHr(bool P_0)
	{
		BOifSHhAYhzhTTOUwfTYSQGyMXO();
	}

	private void YBGcPGSALKHsWiOOjIjkknlLmvR(bool P_0)
	{
		RJDHCSyNzZgHTKlYtMvisGnMHgD = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (P_0)
		{
			return;
		}
		while (!RJDHCSyNzZgHTKlYtMvisGnMHgD)
		{
			BOifSHhAYhzhTTOUwfTYSQGyMXO();
			int num = 902886276;
			while (true)
			{
				switch (num ^ 0x35D0F386)
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
				num = 902886279;
			}
		}
	}

	private void TzkfSsaoLoOGJUjdtPituTwCfRWT(bool P_0)
	{
	}

	private void tteBryqoaiYMgAooPDRpjOtvqpM(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		while (true)
		{
			RJDHCSyNzZgHTKlYtMvisGnMHgD = ReInput.IsInputAllowed(ControllerType.Keyboard);
			int num = 1682804967;
			while (true)
			{
				switch (num ^ 0x644D90E6)
				{
				case 0:
					goto IL_000f;
				case 2:
					break;
				default:
					lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
					{
						ibpCLuiexKBwoqamlUDvmEzESoC[ibpCLuiexKBwoqamlUDvmEzESoC.fixedUpdateSetIndex].BwPPkRHFJojOgeLLjTuFpJmbjNQ();
						return;
					}
				}
				break;
				IL_000f:
				num = 1682804964;
			}
		}
	}

	private void kQKXzfiMsaljLGGJcswSCmyJxfq(UpdateLoopType P_0)
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			ibpCLuiexKBwoqamlUDvmEzESoC.Get(P_0).cHQDtHxqOBHMTeDoAMAnUqYwlCyL();
		}
	}

	private void BOifSHhAYhzhTTOUwfTYSQGyMXO()
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int count = ibpCLuiexKBwoqamlUDvmEzESoC.Count;
			int num = 0;
			while (true)
			{
				int num2 = 2020028639;
				while (true)
				{
					switch (num2 ^ 0x786730DC)
					{
					case 2:
						break;
					case 3:
						num2 = 2020028637;
						continue;
					case 0:
						ibpCLuiexKBwoqamlUDvmEzESoC[num].UsuwPiqVitnNRnZALvWAYQYnQRS();
						num++;
						num2 = 2020028637;
						continue;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		ibpCLuiexKBwoqamlUDvmEzESoC.Current.GvsBjrOWinoVlsKjosmZrtrPqqY(dataUpdater);
	}

	public void Clear()
	{
		BOifSHhAYhzhTTOUwfTYSQGyMXO();
	}

	private static HardwareControllerMap_Game uyRygbwjbPqTqjKaNOACKtIbhTb()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		int num = 0;
		int num4 = default(int);
		HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
		int num3 = default(int);
		int[] array2 = default(int[]);
		while (true)
		{
			int num2 = -1180107475;
			while (true)
			{
				switch (num2 ^ -1180107480)
				{
				case 7:
					break;
				case 3:
					if (num4 >= 132)
					{
						array3 = new HardwareButtonInfo[132];
						num3 = 0;
						num2 = -1180107488;
						continue;
					}
					goto case 1;
				case 2:
					num3++;
					num2 = -1180107488;
					continue;
				case 6:
				{
					int num5;
					if (num < array.Length)
					{
						num2 = -1180107480;
						num5 = num2;
					}
					else
					{
						num2 = -1180107487;
						num5 = num2;
					}
					continue;
				}
				case 4:
					array3[num3] = new HardwareButtonInfo();
					num2 = -1180107478;
					continue;
				case 1:
					array2[num4] = array[num4].id;
					num4++;
					num2 = -1180107477;
					continue;
				case 9:
					array2 = new int[132];
					num4 = 0;
					num2 = -1180107477;
					continue;
				case 5:
					num2 = -1180107474;
					continue;
				case 0:
					array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, true);
					num++;
					num2 = -1180107474;
					continue;
				default:
					if (num3 >= 132)
					{
						return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~hKTkpUPnMJRQrUCFJINGfAbSxtx()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			goto IL_0008;
		}
		goto IL_0046;
		IL_0008:
		int num = 528080102;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x1F79DCE7)
			{
			case 2:
				break;
			case 4:
				ReInput.UpdateEndedEvent -= kQKXzfiMsaljLGGJcswSCmyJxfq;
				num = 528080100;
				continue;
			case 0:
				goto IL_0046;
			case 1:
				return;
			default:
				ReInput.TimeScalePauseChangedEvent -= tteBryqoaiYMgAooPDRpjOtvqpM;
				nNxUslIcGUpqKgpPZYhuimcvWyC = true;
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0046:
		ReInput.ApplicationFocusChangedEvent -= YBGcPGSALKHsWiOOjIjkknlLmvR;
		ReInput.EditorPauseChangedEvent -= TzkfSsaoLoOGJUjdtPituTwCfRWT;
		num = 528080099;
		goto IL_000d;
	}

	public static int EWALSHqiySalYVQHHAuPlUCPqPz(bzEIwBRfuczFFAoUzMzCAMnmSUI P_0, KeyCode[] P_1)
	{
		Keys keys = P_0.VQhGjcVrcEWsnFHGmiHPiqKyfSo;
		Keys keys2 = default(Keys);
		VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier keyboardIdentifier = default(VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier);
		while (true)
		{
			int num = -689600356;
			while (true)
			{
				int result;
				int num2;
				switch (num ^ -689600486)
				{
				case 29:
					break;
				case 132:
					P_1[result++] = KeyCode.Alpha0;
					num = -689600396;
					continue;
				case 127:
					goto IL_0267;
				case 77:
					goto IL_027a;
				case 6:
					goto IL_028c;
				case 33:
					goto IL_02a2;
				case 107:
					goto IL_02b8;
				case 90:
					num = -689600396;
					continue;
				case 81:
					num = -689600396;
					continue;
				case 140:
					goto IL_02df;
				case 32:
					num = -689600396;
					continue;
				case 87:
					goto IL_02fc;
				case 134:
					keys2 = keys;
					num = -689600422;
					continue;
				case 139:
					num = -689600396;
					continue;
				case 49:
					goto IL_0329;
				case 103:
					goto IL_033c;
				case 116:
					goto IL_0352;
				case 35:
					result = 0;
					num = -689600511;
					continue;
				case 1:
					goto IL_0371;
				case 57:
					goto IL_0387;
				case 8:
					num = -689600396;
					continue;
				case 64:
					switch (keys2)
					{
					case Keys.ShiftKey:
						goto IL_048a;
					case Keys.Menu:
						goto IL_0aad;
					case Keys.ControlKey:
						goto IL_0ca4;
					}
					num = -689600455;
					continue;
				case 17:
					goto IL_03c7;
				case 47:
				{
					if (!rPJEzWPBGbWfnJIugiMFNWRtfsP(keys))
					{
						goto case 0;
					}
					KeyCode keyCode;
					if (lFxaPzrQJOdBNZQuNFmaAiQKpLhI(keys, keyboardIdentifier, out keyCode))
					{
						P_1[result++] = keyCode;
						num = -689600456;
						continue;
					}
					goto IL_0f46;
				}
				case 76:
					goto IL_0405;
				case 59:
					num = -689600396;
					continue;
				case 69:
					goto IL_0422;
				case 7:
					goto IL_0438;
				case 96:
					goto IL_044e;
				case 28:
					goto IL_0461;
				case 75:
					goto IL_0477;
				case 40:
					goto IL_048a;
				case 68:
					goto IL_04ab;
				case 130:
					P_1[result++] = KeyCode.Return;
					num = -689600404;
					continue;
				case 55:
					goto IL_04d4;
				case 97:
					num = -689600396;
					continue;
				case 101:
					num = -689600396;
					continue;
				case 65:
					goto IL_04fb;
				case 10:
					goto IL_050e;
				case 9:
					num = -689600396;
					continue;
				case 42:
					goto IL_052b;
				case 37:
					goto IL_0541;
				case 83:
					goto IL_0554;
				case 123:
					goto IL_056a;
				case 111:
					goto IL_0580;
				case 61:
					goto IL_0593;
				case 89:
					goto IL_05a9;
				case 41:
					goto IL_05bf;
				case 80:
					goto IL_05d5;
				case 84:
					goto IL_05eb;
				case 38:
					goto IL_05fe;
				case 109:
					goto IL_0611;
				case 31:
					goto IL_0627;
				case 12:
					goto IL_063a;
				case 3:
					goto IL_064d;
				case 44:
					num = -689600455;
					continue;
				case 66:
					num = -689600396;
					continue;
				case 74:
					goto IL_0677;
				case 126:
					goto IL_0689;
				case 112:
					goto IL_069f;
				case 115:
					num = -689600396;
					continue;
				case 14:
					goto IL_06bf;
				case 118:
					num = -689600396;
					continue;
				case 0:
					switch (keys)
					{
					case Keys.D0:
						break;
					case Keys.Space:
						goto IL_0267;
					case Keys.None:
						goto IL_027a;
					case Keys.Subtract:
						goto IL_028c;
					case Keys.RShiftKey:
						goto IL_02a2;
					case Keys.V:
						goto IL_02b8;
					case Keys.D6:
						goto IL_02df;
					case Keys.F4:
						goto IL_02fc;
					case Keys.D2:
						goto IL_0329;
					case Keys.NumPad3:
						goto IL_033c;
					case Keys.Z:
						goto IL_0352;
					case Keys.F10:
						goto IL_0371;
					case Keys.Scroll:
						goto IL_0387;
					case Keys.Q:
						goto IL_03c7;
					case Keys.G:
						goto IL_0405;
					case Keys.F15:
						goto IL_0422;
					case Keys.F14:
						goto IL_0438;
					case Keys.Clear:
						goto IL_044e;
					case Keys.F3:
						goto IL_0461;
					case Keys.T:
						goto IL_0477;
					case Keys.LShiftKey:
						goto IL_04ab;
					case Keys.Y:
						goto IL_04d4;
					case Keys.D9:
						goto IL_04fb;
					case Keys.P:
						goto IL_050e;
					case Keys.NumPad5:
						goto IL_052b;
					case Keys.D1:
						goto IL_0541;
					case Keys.F2:
						goto IL_0554;
					case Keys.F13:
						goto IL_056a;
					case Keys.D:
						goto IL_0580;
					case Keys.NumPad4:
						goto IL_0593;
					case Keys.Apps:
						goto IL_05a9;
					case Keys.F11:
						goto IL_05bf;
					case Keys.Right:
						goto IL_05d5;
					case Keys.N:
						goto IL_05eb;
					case Keys.U:
						goto IL_05fe;
					case Keys.Decimal:
						goto IL_0611;
					case Keys.H:
						goto IL_0627;
					case Keys.D8:
						goto IL_063a;
					case Keys.F9:
						goto IL_064d;
					case Keys.Back:
						goto IL_0677;
					case Keys.F8:
						goto IL_0689;
					case Keys.End:
						goto IL_069f;
					case Keys.Left:
						goto IL_06bf;
					default:
						goto IL_0981;
					case Keys.NumPad8:
						goto IL_09c6;
					case Keys.Insert:
						goto IL_09dc;
					case Keys.W:
						goto IL_09f2;
					case Keys.NumPad7:
						goto IL_0a05;
					case Keys.Multiply:
						goto IL_0a1b;
					case Keys.Divide:
						goto IL_0a31;
					case Keys.K:
						goto IL_0a47;
					case Keys.F1:
						goto IL_0a5a;
					case Keys.NumLock:
						goto IL_0a84;
					case Keys.R:
						goto IL_0a9a;
					case Keys.Print:
						goto IL_0ac5;
					case Keys.LMenu:
						goto IL_0adb;
					case Keys.LControlKey:
						goto IL_0afb;
					case Keys.X:
						goto IL_0b11;
					case Keys.F5:
						goto IL_0b24;
					case Keys.F7:
						goto IL_0b3a;
					case Keys.Capital:
						goto IL_0b50;
					case Keys.Tab:
						goto IL_0b66;
					case Keys.Escape:
						goto IL_0b83;
					case Keys.Up:
						goto IL_0b96;
					case Keys.S:
						goto IL_0bac;
					case Keys.NumPad9:
						goto IL_0bc9;
					case Keys.NumPad0:
						goto IL_0bdf;
					case Keys.Down:
						goto IL_0bf5;
					case Keys.Pause:
						goto IL_0c0b;
					case Keys.LWin:
						goto IL_0c1e;
					case Keys.NumPad2:
						goto IL_0c48;
					case Keys.J:
						goto IL_0c5e;
					case Keys.Delete:
						goto IL_0c71;
					case Keys.Help:
						goto IL_0c84;
					case Keys.D7:
						goto IL_0cd0;
					case Keys.NumPad1:
						goto IL_0ce3;
					case Keys.C:
						goto IL_0d10;
					case Keys.RMenu:
						goto IL_0d2d;
					case Keys.A:
						goto IL_0d4f;
					case Keys.D3:
						goto IL_0d62;
					case Keys.Add:
						goto IL_0d75;
					case Keys.Prior:
						goto IL_0d8b;
					case Keys.Return:
						goto IL_0dab;
					case Keys.O:
						goto IL_0dcf;
					case Keys.RWin:
						goto IL_0de2;
					case Keys.RControlKey:
						goto IL_0df8;
					case Keys.E:
						goto IL_0e22;
					case Keys.D4:
						goto IL_0e35;
					case Keys.Next:
						goto IL_0e48;
					case Keys.F12:
						goto IL_0e5e;
					case Keys.NumPad6:
						goto IL_0e74;
					case Keys.Home:
						goto IL_0e8a;
					case Keys.B:
						goto IL_0ea0;
					case Keys.M:
						goto IL_0eb3;
					case Keys.F6:
						goto IL_0eda;
					case Keys.L:
						goto IL_0ef0;
					case Keys.D5:
						goto IL_0f03;
					case Keys.I:
						goto IL_0f20;
					case Keys.F:
						goto IL_0f33;
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
						goto IL_0f46;
					}
					goto case 132;
				case 78:
					num = -689600396;
					continue;
				case 105:
					num = -689600396;
					continue;
				case 27:
				{
					keyboardIdentifier = IxzeFBFiiICOlJBnqPMqDgtRofxQ();
					IntPtr bhtsyPMeDyasOpGKWKVlIwpUBOW = BhtsyPMeDyasOpGKWKVlIwpUBOW;
					JBXHRSYUePslTBUiRmNOkdLSed.HnzucBHfgCjfzVgaOukUwHSykyn((uint)P_0.VQhGjcVrcEWsnFHGmiHPiqKyfSo, VsBhOKFiHLExTQMhhdmldpUBgyL.dIIWdHVwQYOerWUNqCeiIvIcgPb);
					num = -689600459;
					continue;
				}
				case 45:
					goto IL_09c6;
				case 24:
					goto IL_09dc;
				case 125:
					goto IL_09f2;
				case 137:
					goto IL_0a05;
				case 129:
					goto IL_0a1b;
				case 94:
					goto IL_0a31;
				case 91:
					goto IL_0a47;
				case 21:
					goto IL_0a5a;
				case 131:
					num = -689600396;
					continue;
				case 19:
					num = -689600396;
					continue;
				case 18:
					goto IL_0a84;
				case 63:
					goto IL_0a9a;
				case 15:
					goto IL_0aad;
				case 72:
					goto IL_0ac5;
				case 13:
					goto IL_0adb;
				case 98:
					num = -689600396;
					continue;
				case 26:
					goto IL_0afb;
				case 133:
					goto IL_0b11;
				case 82:
					goto IL_0b24;
				case 79:
					goto IL_0b3a;
				case 113:
					goto IL_0b50;
				case 124:
					goto IL_0b66;
				case 36:
					num = -689600396;
					continue;
				case 22:
					goto IL_0b83;
				case 39:
					goto IL_0b96;
				case 100:
					goto IL_0bac;
				case 102:
					num = -689600396;
					continue;
				case 70:
					goto IL_0bc9;
				case 71:
					goto IL_0bdf;
				case 4:
					goto IL_0bf5;
				case 11:
					goto IL_0c0b;
				case 20:
					goto IL_0c1e;
				case 122:
					num = -689600396;
					continue;
				case 50:
					num = -689600396;
					continue;
				case 56:
					goto IL_0c48;
				case 128:
					goto IL_0c5e;
				case 43:
					goto IL_0c71;
				case 73:
					goto IL_0c84;
				case 120:
					num = -689600396;
					continue;
				case 117:
					goto IL_0ca4;
				case 51:
					num = -689600396;
					continue;
				case 121:
					goto IL_0cd0;
				case 108:
					goto IL_0ce3;
				case 54:
					num2 = 164;
					goto IL_0d05;
				case 30:
					goto IL_0d10;
				case 52:
					num = -689600396;
					continue;
				case 138:
					goto IL_0d2d;
				case 114:
					goto IL_0d4f;
				case 92:
					goto IL_0d62;
				case 136:
					goto IL_0d75;
				case 119:
					goto IL_0d8b;
				case 58:
					num = -689600396;
					continue;
				case 95:
					goto IL_0dab;
				case 106:
					goto IL_0dcf;
				case 2:
					goto IL_0de2;
				case 104:
					goto IL_0df8;
				case 48:
					num = -689600396;
					continue;
				case 53:
					num = -689600396;
					continue;
				case 86:
					goto IL_0e22;
				case 23:
					goto IL_0e35;
				case 60:
					goto IL_0e48;
				case 16:
					goto IL_0e5e;
				case 62:
					goto IL_0e74;
				case 93:
					goto IL_0e8a;
				case 25:
					goto IL_0ea0;
				case 88:
					goto IL_0eb3;
				case 67:
					num = -689600396;
					continue;
				case 34:
					num = -689600396;
					continue;
				case 141:
					goto IL_0eda;
				case 99:
					goto IL_0ef0;
				case 85:
					goto IL_0f03;
				case 5:
					num = -689600396;
					continue;
				case 135:
					goto IL_0f20;
				case 46:
					goto IL_0f33;
				default:
					goto IL_0f46;
					IL_02fc:
					P_1[result++] = KeyCode.F4;
					num = -689600396;
					continue;
					IL_0f46:
					return result;
					IL_0f33:
					P_1[result++] = KeyCode.F;
					num = -689600397;
					continue;
					IL_0f20:
					P_1[result++] = KeyCode.I;
					num = -689600481;
					continue;
					IL_0f03:
					P_1[result++] = KeyCode.Alpha5;
					num = -689600396;
					continue;
					IL_0ef0:
					P_1[result++] = KeyCode.L;
					num = -689600396;
					continue;
					IL_0eda:
					P_1[result++] = KeyCode.F6;
					num = -689600396;
					continue;
					IL_0eb3:
					P_1[result++] = KeyCode.M;
					num = -689600437;
					continue;
					IL_0ea0:
					P_1[result++] = KeyCode.B;
					num = -689600396;
					continue;
					IL_0e8a:
					P_1[result++] = KeyCode.Home;
					num = -689600454;
					continue;
					IL_0e74:
					P_1[result++] = KeyCode.Keypad6;
					num = -689600428;
					continue;
					IL_0e5e:
					P_1[result++] = KeyCode.F12;
					num = -689600389;
					continue;
					IL_0e48:
					P_1[result++] = KeyCode.PageDown;
					num = -689600472;
					continue;
					IL_0e35:
					P_1[result++] = KeyCode.Alpha4;
					num = -689600396;
					continue;
					IL_0e22:
					P_1[result++] = KeyCode.E;
					num = -689600396;
					continue;
					IL_0df8:
					P_1[result++] = KeyCode.RightControl;
					num = -689600396;
					continue;
					IL_0de2:
					P_1[result++] = KeyCode.RightCommand;
					num = -689600396;
					continue;
					IL_0dcf:
					P_1[result++] = KeyCode.O;
					num = -689600396;
					continue;
					IL_0dab:
					if ((P_0.muPkNHWlpukUSfbmVyLHYQMAaxn & jevTfoocnrJqEPfaxxbtTuEGQIf.gCcBhUkAIxkSBegHBytbuozvJZO) != jevTfoocnrJqEPfaxxbtTuEGQIf.wbKxiCVhyODuvRXZoIdKJxTVRni)
					{
						P_1[result++] = KeyCode.KeypadEnter;
						num = -689600396;
						continue;
					}
					goto case 130;
					IL_0d8b:
					P_1[result++] = KeyCode.PageUp;
					num = -689600396;
					continue;
					IL_0d75:
					P_1[result++] = KeyCode.KeypadPlus;
					num = -689600396;
					continue;
					IL_0d62:
					P_1[result++] = KeyCode.Alpha3;
					num = -689600396;
					continue;
					IL_0d4f:
					P_1[result++] = KeyCode.A;
					num = -689600396;
					continue;
					IL_0d2d:
					P_1[result++] = KeyCode.AltGr;
					P_1[result++] = KeyCode.RightAlt;
					num = -689600396;
					continue;
					IL_0d10:
					P_1[result++] = KeyCode.C;
					num = -689600470;
					continue;
					IL_0ce3:
					P_1[result++] = KeyCode.Keypad1;
					num = -689600359;
					continue;
					IL_0cd0:
					P_1[result++] = KeyCode.Alpha7;
					num = -689600465;
					continue;
					IL_0c84:
					P_1[result++] = KeyCode.Help;
					num = -689600396;
					continue;
					IL_0c71:
					P_1[result++] = KeyCode.Delete;
					num = -689600396;
					continue;
					IL_0c5e:
					P_1[result++] = KeyCode.J;
					num = -689600396;
					continue;
					IL_0c48:
					P_1[result++] = KeyCode.Keypad2;
					num = -689600396;
					continue;
					IL_0c1e:
					P_1[result++] = KeyCode.LeftCommand;
					num = -689600396;
					continue;
					IL_0c0b:
					P_1[result++] = KeyCode.Pause;
					num = -689600396;
					continue;
					IL_0bf5:
					P_1[result++] = KeyCode.DownArrow;
					num = -689600503;
					continue;
					IL_0bdf:
					P_1[result++] = KeyCode.Keypad0;
					num = -689600392;
					continue;
					IL_0bc9:
					P_1[result++] = KeyCode.Keypad9;
					num = -689600396;
					continue;
					IL_0bac:
					P_1[result++] = KeyCode.S;
					num = -689600480;
					continue;
					IL_0b96:
					P_1[result++] = KeyCode.UpArrow;
					num = -689600396;
					continue;
					IL_0b83:
					P_1[result++] = KeyCode.Escape;
					num = -689600396;
					continue;
					IL_0b66:
					P_1[result++] = KeyCode.Tab;
					num = -689600396;
					continue;
					IL_0b50:
					P_1[result++] = KeyCode.CapsLock;
					num = -689600396;
					continue;
					IL_0b3a:
					P_1[result++] = KeyCode.F7;
					num = -689600396;
					continue;
					IL_0b24:
					P_1[result++] = KeyCode.F5;
					num = -689600479;
					continue;
					IL_0b11:
					P_1[result++] = KeyCode.X;
					num = -689600396;
					continue;
					IL_0afb:
					P_1[result++] = KeyCode.LeftControl;
					num = -689600494;
					continue;
					IL_0adb:
					P_1[result++] = KeyCode.LeftAlt;
					num = -689600396;
					continue;
					IL_0ac5:
					P_1[result++] = KeyCode.Print;
					num = -689600448;
					continue;
					IL_0a9a:
					P_1[result++] = KeyCode.R;
					num = -689600396;
					continue;
					IL_0a84:
					P_1[result++] = KeyCode.Numlock;
					num = -689600396;
					continue;
					IL_0a5a:
					P_1[result++] = KeyCode.F1;
					num = -689600396;
					continue;
					IL_0a47:
					P_1[result++] = KeyCode.K;
					num = -689600396;
					continue;
					IL_0a31:
					P_1[result++] = KeyCode.KeypadDivide;
					num = -689600396;
					continue;
					IL_0a1b:
					P_1[result++] = KeyCode.KeypadMultiply;
					num = -689600396;
					continue;
					IL_0a05:
					P_1[result++] = KeyCode.Keypad7;
					num = -689600414;
					continue;
					IL_09f2:
					P_1[result++] = KeyCode.W;
					num = -689600396;
					continue;
					IL_09dc:
					P_1[result++] = KeyCode.Insert;
					num = -689600396;
					continue;
					IL_09c6:
					P_1[result++] = KeyCode.Keypad8;
					num = -689600396;
					continue;
					IL_0981:
					num = -689600416;
					continue;
					IL_06bf:
					P_1[result++] = KeyCode.LeftArrow;
					num = -689600396;
					continue;
					IL_069f:
					P_1[result++] = KeyCode.End;
					num = -689600396;
					continue;
					IL_0689:
					P_1[result++] = KeyCode.F8;
					num = -689600493;
					continue;
					IL_0677:
					P_1[result++] = KeyCode.Backspace;
					num = -689600396;
					continue;
					IL_064d:
					P_1[result++] = KeyCode.F9;
					num = -689600450;
					continue;
					IL_063a:
					P_1[result++] = KeyCode.Alpha8;
					num = -689600367;
					continue;
					IL_0627:
					P_1[result++] = KeyCode.H;
					num = -689600423;
					continue;
					IL_0611:
					P_1[result++] = KeyCode.KeypadPeriod;
					num = -689600396;
					continue;
					IL_05fe:
					P_1[result++] = KeyCode.U;
					num = -689600396;
					continue;
					IL_05eb:
					P_1[result++] = KeyCode.N;
					num = -689600396;
					continue;
					IL_05d5:
					P_1[result++] = KeyCode.RightArrow;
					num = -689600396;
					continue;
					IL_05bf:
					P_1[result++] = KeyCode.F11;
					num = -689600396;
					continue;
					IL_05a9:
					P_1[result++] = KeyCode.Menu;
					num = -689600396;
					continue;
					IL_0593:
					P_1[result++] = KeyCode.Keypad4;
					num = -689600396;
					continue;
					IL_0580:
					P_1[result++] = KeyCode.D;
					num = -689600396;
					continue;
					IL_056a:
					P_1[result++] = KeyCode.F13;
					num = -689600466;
					continue;
					IL_0554:
					P_1[result++] = KeyCode.F2;
					num = -689600396;
					continue;
					IL_0541:
					P_1[result++] = KeyCode.Alpha1;
					num = -689600396;
					continue;
					IL_052b:
					P_1[result++] = KeyCode.Keypad5;
					num = -689600471;
					continue;
					IL_050e:
					P_1[result++] = KeyCode.P;
					num = -689600396;
					continue;
					IL_04fb:
					P_1[result++] = KeyCode.Alpha9;
					num = -689600396;
					continue;
					IL_04d4:
					P_1[result++] = KeyCode.Y;
					num = -689600396;
					continue;
					IL_04ab:
					P_1[result++] = KeyCode.LeftShift;
					num = -689600385;
					continue;
					IL_0477:
					P_1[result++] = KeyCode.T;
					num = -689600396;
					continue;
					IL_0461:
					P_1[result++] = KeyCode.F3;
					num = -689600424;
					continue;
					IL_044e:
					P_1[result++] = KeyCode.Clear;
					num = -689600388;
					continue;
					IL_0438:
					P_1[result++] = KeyCode.F14;
					num = -689600396;
					continue;
					IL_0422:
					P_1[result++] = KeyCode.F15;
					num = -689600396;
					continue;
					IL_0405:
					P_1[result++] = KeyCode.G;
					num = -689600396;
					continue;
					IL_03c7:
					P_1[result++] = KeyCode.Q;
					num = -689600396;
					continue;
					IL_0ca4:
					keys = (((P_0.muPkNHWlpukUSfbmVyLHYQMAaxn & jevTfoocnrJqEPfaxxbtTuEGQIf.gCcBhUkAIxkSBegHBytbuozvJZO) != jevTfoocnrJqEPfaxxbtTuEGQIf.wbKxiCVhyODuvRXZoIdKJxTVRni) ? Keys.RControlKey : Keys.LControlKey);
					num = -689600455;
					continue;
					IL_02b8:
					P_1[result++] = KeyCode.V;
					num = -689600396;
					continue;
					IL_0aad:
					if ((P_0.muPkNHWlpukUSfbmVyLHYQMAaxn & jevTfoocnrJqEPfaxxbtTuEGQIf.gCcBhUkAIxkSBegHBytbuozvJZO) == 0)
					{
						num = -689600468;
						continue;
					}
					num2 = 165;
					goto IL_0d05;
					IL_02a2:
					P_1[result++] = KeyCode.RightShift;
					num = -689600396;
					continue;
					IL_028c:
					P_1[result++] = KeyCode.KeypadMinus;
					num = -689600396;
					continue;
					IL_0d05:
					keys = (Keys)num2;
					num = -689600458;
					continue;
					IL_048a:
					keys = ((P_0.rwGaxtUVotiXCaoXbaggrFkJIitL == 54) ? Keys.RShiftKey : Keys.LShiftKey);
					num = -689600455;
					continue;
					IL_0267:
					P_1[result++] = KeyCode.Space;
					num = -689600396;
					continue;
					IL_027a:
					P_1[result++] = KeyCode.None;
					num = -689600396;
					continue;
					IL_02df:
					P_1[result++] = KeyCode.Alpha6;
					num = -689600396;
					continue;
					IL_0387:
					P_1[result++] = KeyCode.ScrollLock;
					num = -689600407;
					continue;
					IL_0371:
					P_1[result++] = KeyCode.F10;
					num = -689600396;
					continue;
					IL_0352:
					P_1[result++] = KeyCode.Z;
					num = -689600396;
					continue;
					IL_033c:
					P_1[result++] = KeyCode.Keypad3;
					num = -689600396;
					continue;
					IL_0329:
					P_1[result++] = KeyCode.Alpha2;
					num = -689600396;
					continue;
				}
				break;
			}
		}
	}

	private unsafe static VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier IxzeFBFiiICOlJBnqPMqDgtRofxQ()
	{
		IntPtr intPtr = JBXHRSYUePslTBUiRmNOkdLSed.BDWnVCypAYfvYGGmuoMJMEWMyar(0);
		VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier keyboardIdentifier = default(VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier);
		string s = default(string);
		while (true)
		{
			int num = 301524421;
			while (true)
			{
				switch (num ^ 0x11F8E5C4)
				{
				case 2:
					break;
				case 1:
				{
					if (intPtr == BhtsyPMeDyasOpGKWKVlIwpUBOW)
					{
						num = 301524416;
						continue;
					}
					keyboardIdentifier = VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier.United_States_English;
					byte* ptr = stackalloc byte[128];
					JBXHRSYUePslTBUiRmNOkdLSed.kCmAAVpZumHcATfcNSxGfamMFmG((IntPtr)ptr);
					s = Marshal.PtrToStringUni((IntPtr)ptr);
					num = 301524420;
					continue;
				}
				case 4:
					return NgkhNQWeALDYDjuFyrPNwREgWZX;
				case 0:
				{
					int result;
					if (int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result))
					{
						int num2 = ArrayTools.IndexOf(UCGfPXsvfEEoKbURJCvBNIxGIKth, result);
						if (num2 >= 0)
						{
							keyboardIdentifier = (VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier)UCGfPXsvfEEoKbURJCvBNIxGIKth[num2];
							num = 301524423;
							continue;
						}
					}
					goto default;
				}
				default:
					BhtsyPMeDyasOpGKWKVlIwpUBOW = intPtr;
					NgkhNQWeALDYDjuFyrPNwREgWZX = keyboardIdentifier;
					return keyboardIdentifier;
				}
				break;
			}
		}
	}

	private static bool lFxaPzrQJOdBNZQuNFmaAiQKpLhI(Keys P_0, VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		Dictionary<int, KeyCode> value;
		if (!yrCrKaxrEhvXiFvGCpDiDesPMHd.TryGetValue((int)P_1, out value))
		{
			value = yrCrKaxrEhvXiFvGCpDiDesPMHd[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != VsBhOKFiHLExTQMhhdmldpUBgyL.KeyboardIdentifier.United_States_English)
		{
			value = yrCrKaxrEhvXiFvGCpDiDesPMHd[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool rPJEzWPBGbWfnJIugiMFNWRtfsP(Keys P_0)
	{
		return ArrayTools.Contains(KoOjYDxHZiNZIdUqsCaXjJMNDNo, (int)P_0);
	}
}
