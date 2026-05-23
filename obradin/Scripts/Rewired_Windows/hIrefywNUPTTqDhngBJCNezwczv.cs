using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class hIrefywNUPTTqDhngBJCNezwczv : IDisposable, IUnifiedKeyboardSource
{
	private class ZTkEuytvnXROtSaoufRZJVFMtAf
	{
		private enum MRihWXWdHdfgHJhYaInrQYmlCfKh
		{
			FIZxYpycmNmDbQxAMdnkneLgidG = 0,
			VzwisEYZAMtAnBAbjgzfGqDzwteg = 1,
			gDcvidgLIoQhnuybTXdlFaqRQMN = 2
		}

		private const int TBAHUNrPcOVGJTloSgqreDtitCP = 2;

		private static readonly KeyCode[] JdMtVnjmATZKhHfoGoQZYKcfkZ = new KeyCode[2];

		private readonly UpdateLoopType rCSpsaJXNIOxHKmdtMQPDZLncf;

		private bool[] lBjQBTzEGHGwIHsKOIAOgrVTaIjf;

		private bool[] GulOadoGDwkvxOeAymFUGnNKFLr;

		private uint nEDuMTPGzlJjNGHahpVIlhGyqBd;

		public ZTkEuytvnXROtSaoufRZJVFMtAf(UpdateLoopType updateLoop)
		{
			while (true)
			{
				int num = -1591981369;
				while (true)
				{
					switch (num ^ -1591981372)
					{
					case 2:
						break;
					case 3:
						rCSpsaJXNIOxHKmdtMQPDZLncf = updateLoop;
						num = -1591981372;
						continue;
					case 0:
						lBjQBTzEGHGwIHsKOIAOgrVTaIjf = new bool[132];
						num = -1591981371;
						continue;
					default:
						GulOadoGDwkvxOeAymFUGnNKFLr = new bool[132];
						return;
					}
					break;
				}
			}
		}

		public void XFvaXWquGWZitqFbzlyoxuuByzX(znchxtogvsCwUJelEblQFvJYOmG P_0)
		{
			int num = CxmbMbJFmIlxXgYpcaWHwiOaxwrZ(P_0, JdMtVnjmATZKhHfoGoQZYKcfkZ);
			int num2 = 0;
			bool flag2 = default(bool);
			dawFmMbpZMhaNErGafhOzKosTNDy dawFmMbpZMhaNErGafhOzKosTNDy2 = default(dawFmMbpZMhaNErGafhOzKosTNDy);
			while (num2 < num)
			{
				while (true)
				{
					IL_0071:
					int num3 = (int)JdMtVnjmATZKhHfoGoQZYKcfkZ[num2];
					int num4;
					if (num3 >= 0)
					{
						int num5;
						if (num3 < PVNhJdyjUFesgDzUQRXIpoUTvRM.Length)
						{
							num4 = 791650909;
							num5 = num4;
						}
						else
						{
							num4 = 791650904;
							num5 = num4;
						}
						goto IL_0018;
					}
					goto IL_0066;
					IL_0018:
					while (true)
					{
						switch (num4 ^ 0x2F2FA258)
						{
						case 4:
							num4 = 791650906;
							continue;
						case 6:
							break;
						case 0:
							goto end_IL_0018;
						case 2:
							goto IL_0071;
						case 5:
							goto IL_0098;
						case 7:
							flag2 = true;
							num4 = 791650905;
							continue;
						case 8:
							flag2 = false;
							num4 = 791650905;
							continue;
						case 1:
						{
							int num6 = PVNhJdyjUFesgDzUQRXIpoUTvRM[num3];
							bool flag = lBjQBTzEGHGwIHsKOIAOgrVTaIjf[num6];
							lBjQBTzEGHGwIHsKOIAOgrVTaIjf[num6] = flag2;
							if (!flag && flag2)
							{
								GulOadoGDwkvxOeAymFUGnNKFLr[num6] = true;
								num4 = 791650904;
								continue;
							}
							goto end_IL_0018;
						}
						default:
							goto end_IL_0071;
						}
						int num7;
						if (dawFmMbpZMhaNErGafhOzKosTNDy2 == dawFmMbpZMhaNErGafhOzKosTNDy.HaMwKAAXyWUeGgFUsVOkpReAueG)
						{
							num4 = 791650911;
							num7 = num4;
						}
						else
						{
							num4 = 791650896;
							num7 = num4;
						}
						continue;
						IL_0098:
						dawFmMbpZMhaNErGafhOzKosTNDy btlePRpiLIUfpxsQCTidJPkejeiF = P_0.btlePRpiLIUfpxsQCTidJPkejeiF;
						dawFmMbpZMhaNErGafhOzKosTNDy2 = btlePRpiLIUfpxsQCTidJPkejeiF;
						int num8;
						if (dawFmMbpZMhaNErGafhOzKosTNDy2 == dawFmMbpZMhaNErGafhOzKosTNDy.VTjcGKIbCNDIsZLStfFBhrHhIKgj)
						{
							num4 = 791650911;
							num8 = num4;
						}
						else
						{
							num4 = 791650910;
							num8 = num4;
						}
						continue;
						end_IL_0018:
						break;
					}
					goto IL_0066;
					IL_0066:
					num2++;
					num4 = 791650907;
					goto IL_0018;
					continue;
					end_IL_0071:
					break;
				}
			}
		}

		public void QWEUCBrKKzvxklNuHPyBmatnhsG(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < 132)
				{
					num2 = -327026030;
					num3 = num2;
				}
				else
				{
					num2 = -327026025;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -327026025)
					{
					case 4:
						num2 = -327026030;
						continue;
					default:
						return;
					case 5:
						buttonValues[num] = lBjQBTzEGHGwIHsKOIAOgrVTaIjf[num] || GulOadoGDwkvxOeAymFUGnNKFLr[num];
						num2 = -327026026;
						continue;
					case 2:
						break;
					case 0:
						rXLYmcycnyHBWseByPXLZQuMrfe();
						num2 = -327026028;
						continue;
					case 1:
						num++;
						num2 = -327026027;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void aqqkTdOMGLHPIIcYrYTpjUXAOZk()
		{
			rXLYmcycnyHBWseByPXLZQuMrfe();
		}

		private void rXLYmcycnyHBWseByPXLZQuMrfe()
		{
			if (nEDuMTPGzlJjNGHahpVIlhGyqBd == ReInput.absFrame)
			{
				return;
			}
			while (true)
			{
				JytoQzmHZuRpbjAlMGyDqfmXRBI();
				int num = 2143311164;
				while (true)
				{
					switch (num ^ 0x7FC0553D)
					{
					case 0:
						num = 2143311166;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
						nEDuMTPGzlJjNGHahpVIlhGyqBd = ReInput.absFrame;
						num = 2143311167;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public void JytoQzmHZuRpbjAlMGyDqfmXRBI()
		{
			Array.Clear(GulOadoGDwkvxOeAymFUGnNKFLr, 0, 132);
		}

		public void IbWidGCHJzvyGGwvigfCOXYPcWYT()
		{
			Array.Clear(lBjQBTzEGHGwIHsKOIAOgrVTaIjf, 0, 132);
			Array.Clear(GulOadoGDwkvxOeAymFUGnNKFLr, 0, 132);
		}
	}

	private const int lsjoyeWZoIPbThwgyypaZAJgexa = 132;

	private const uint ZOIbKfQrQnwYKCanWiEogvuTDOj = 59u;

	private const uint TYuDmowCLPWlIagziRfBHeKppdw = 47u;

	private const uint CvasYzQvPRBWbNUaEIwCdfvpmIY = 96u;

	private const uint DRuencvXqpfhxCEFLIgLhCxfiLzE = 91u;

	private const uint VMihcDUDeNJizYSPwsMkobSCPeS = 92u;

	private const uint UlZrgnDQChvEFKrCchliqrNoQv = 93u;

	private const uint vOdfKalYTKCmiYvKiRcALfgiJHJ = 39u;

	private readonly object OwdBRVkoLEeNZyygHCLZABIQljTX = new object();

	private UpdateLoopDataSet<ZTkEuytvnXROtSaoufRZJVFMtAf> oTJfBQRroQHApFhCKvKdLzzcrUOr;

	private HardwareControllerMap_Game mPWmQPPNnugLPBDUlKYZdtvIJQR;

	private bool JHvBacPGzZKXIVYcGUBsznvooaR;

	private static readonly int[] PVNhJdyjUFesgDzUQRXIpoUTvRM;

	private static readonly int HkcFpmHdNMcKOCwHhsLiQZGQSyoF;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	private static Dictionary<uint, KeyCode> PSoFyYIKARkbGERxgPTVxFncTPp;

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
			if (mPWmQPPNnugLPBDUlKYZdtvIJQR == null)
			{
				while (true)
				{
					int num = 1919177273;
					while (true)
					{
						switch (num ^ 0x72645238)
						{
						case 2:
							break;
						case 1:
							mPWmQPPNnugLPBDUlKYZdtvIJQR = gxStPMFjPAOlAyQaHMKdDYaHTjP();
							num = 1919177272;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return mPWmQPPNnugLPBDUlKYZdtvIJQR;
		}
	}

	public int buttonCount
	{
		get
		{
			return 132;
		}
	}

	static hIrefywNUPTTqDhngBJCNezwczv()
	{
		PSoFyYIKARkbGERxgPTVxFncTPp = new Dictionary<uint, KeyCode>
		{
			{
				59u,
				KeyCode.Semicolon
			},
			{
				47u,
				KeyCode.Slash
			},
			{
				96u,
				KeyCode.BackQuote
			},
			{
				91u,
				KeyCode.LeftBracket
			},
			{
				92u,
				KeyCode.Backslash
			},
			{
				93u,
				KeyCode.RightBracket
			},
			{
				39u,
				KeyCode.Quote
			}
		};
		int[] keyboardKeyValues = default(int[]);
		int num4 = default(int);
		int num2 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num = -284583282;
			while (true)
			{
				switch (num ^ -284583283)
				{
				case 0:
					break;
				case 1:
					HkcFpmHdNMcKOCwHhsLiQZGQSyoF = keyboardKeyValues[num4];
					num = -284583286;
					continue;
				case 4:
					PVNhJdyjUFesgDzUQRXIpoUTvRM = new int[HkcFpmHdNMcKOCwHhsLiQZGQSyoF + 1];
					ArrayTools.Fill(PVNhJdyjUFesgDzUQRXIpoUTvRM, -1);
					num2 = 0;
					num = -284583285;
					continue;
				case 3:
					keyboardKeyValues = Consts._keyboardKeyValues;
					num3 = keyboardKeyValues.Length;
					num4 = 0;
					num = -284583291;
					continue;
				case 8:
				{
					int num6;
					if (num4 < num3)
					{
						num = -284583288;
						num6 = num;
					}
					else
					{
						num = -284583287;
						num6 = num;
					}
					continue;
				}
				case 2:
					PVNhJdyjUFesgDzUQRXIpoUTvRM[keyboardKeyValues[num2]] = num2;
					num2++;
					num = -284583285;
					continue;
				case 7:
					num4++;
					num = -284583291;
					continue;
				case 5:
				{
					int num5;
					if (keyboardKeyValues[num4] <= HkcFpmHdNMcKOCwHhsLiQZGQSyoF)
					{
						num = -284583286;
						num5 = num;
					}
					else
					{
						num = -284583284;
						num5 = num;
					}
					continue;
				}
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public hIrefywNUPTTqDhngBJCNezwczv(UpdateLoopSetting updateLoopSetting)
	{
		while (true)
		{
			int num = 126300611;
			while (true)
			{
				switch (num ^ 0x78731C2)
				{
				case 2:
					break;
				case 1:
					goto IL_002f;
				default:
				{
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							oTJfBQRroQHApFhCKvKdLzzcrUOr[i] = new ZTkEuytvnXROtSaoufRZJVFMtAf(list[i]);
						}
					}
					JHvBacPGzZKXIVYcGUBsznvooaR = ReInput.IsInputAllowed(ControllerType.Keyboard);
					ReInput.ApplicationFocusChangedEvent += CtaFdeHrYObIRlreCIAgVnnrkoBl;
					ReInput.EditorPauseChangedEvent += PuQVLYTVBaFLMsBlAaHdWauuFpQ;
					ReInput.UpdateEndedEvent += cIiCEBiNGkkiGENmFSkcCPmIrbtr;
					ReInput.TimeScalePauseChangedEvent += xeAiYSHaeoeZzVhKscFtcwjDaaWN;
					return;
				}
				}
				break;
				IL_002f:
				oTJfBQRroQHApFhCKvKdLzzcrUOr = new UpdateLoopDataSet<ZTkEuytvnXROtSaoufRZJVFMtAf>(updateLoopSetting);
				num = 126300610;
			}
		}
	}

	public void OKHZGFMfxtklwLbZuCziRQFTDNac(UpdateLoopType P_0)
	{
		oTJfBQRroQHApFhCKvKdLzzcrUOr.SetUpdateLoop(P_0);
		JHvBacPGzZKXIVYcGUBsznvooaR = ReInput.IsInputAllowed(ControllerType.Keyboard);
	}

	public void gWtxRrjxTpaISzgdnjvOGVfdZlUV(znchxtogvsCwUJelEblQFvJYOmG P_0)
	{
		if (!JHvBacPGzZKXIVYcGUBsznvooaR)
		{
			while (true)
			{
				switch (0x1E793F4C ^ 0x1E793F4D)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int count = oTJfBQRroQHApFhCKvKdLzzcrUOr.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 511262542;
				while (true)
				{
					switch (num ^ 0x1E793F4D)
					{
					case 0:
						break;
					case 1:
						num2++;
						num = 511262537;
						continue;
					case 2:
						oTJfBQRroQHApFhCKvKdLzzcrUOr[num2].XFvaXWquGWZitqFbzlyoxuuByzX(P_0);
						num = 511262540;
						continue;
					case 3:
					{
						int fixedUpdateSetIndex = oTJfBQRroQHApFhCKvKdLzzcrUOr.fixedUpdateSetIndex;
						num2 = 0;
						num = 511262537;
						continue;
					}
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}

	public void nqaoNwwONUjhhEBlzroSZxPTdDV(bool P_0)
	{
		TgKBgvkUWxJcUAUaEZxCzBUtMKSX();
	}

	private void CtaFdeHrYObIRlreCIAgVnnrkoBl(bool P_0)
	{
		JHvBacPGzZKXIVYcGUBsznvooaR = ReInput.IsInputAllowed(ControllerType.Keyboard);
		while (true)
		{
			int num = 2079617424;
			while (true)
			{
				switch (num ^ 0x7BF47192)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (P_0)
					{
						return;
					}
					goto case 3;
				case 3:
					if (!JHvBacPGzZKXIVYcGUBsznvooaR)
					{
						goto IL_0041;
					}
					return;
				case 1:
					return;
				}
				break;
				IL_0041:
				TgKBgvkUWxJcUAUaEZxCzBUtMKSX();
				num = 2079617427;
			}
		}
	}

	private void PuQVLYTVBaFLMsBlAaHdWauuFpQ(bool P_0)
	{
		JHvBacPGzZKXIVYcGUBsznvooaR = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!ReInput.isRunningInEditMode && P_0)
		{
			TgKBgvkUWxJcUAUaEZxCzBUtMKSX();
		}
	}

	private void xeAiYSHaeoeZzVhKscFtcwjDaaWN(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		while (true)
		{
			JHvBacPGzZKXIVYcGUBsznvooaR = ReInput.IsInputAllowed(ControllerType.Keyboard);
			int num = 47561642;
			while (true)
			{
				switch (num ^ 0x2D5BBAA)
				{
				case 2:
					goto IL_000f;
				case 1:
					break;
				default:
					lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
					{
						oTJfBQRroQHApFhCKvKdLzzcrUOr[oTJfBQRroQHApFhCKvKdLzzcrUOr.fixedUpdateSetIndex].JytoQzmHZuRpbjAlMGyDqfmXRBI();
						return;
					}
				}
				break;
				IL_000f:
				num = 47561643;
			}
		}
	}

	private void cIiCEBiNGkkiGENmFSkcCPmIrbtr(UpdateLoopType P_0)
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			oTJfBQRroQHApFhCKvKdLzzcrUOr.Get(P_0).aqqkTdOMGLHPIIcYrYTpjUXAOZk();
		}
	}

	private void TgKBgvkUWxJcUAUaEZxCzBUtMKSX()
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int count = oTJfBQRroQHApFhCKvKdLzzcrUOr.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					oTJfBQRroQHApFhCKvKdLzzcrUOr[num].IbWidGCHJzvyGGwvigfCOXYPcWYT();
					num++;
					int num2 = -231738453;
					while (true)
					{
						switch (num2 ^ -231738453)
						{
						case 2:
							num2 = -231738454;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003b;
						}
						break;
					}
					continue;
					end_IL_003b:
					break;
				}
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		oTJfBQRroQHApFhCKvKdLzzcrUOr.Current.QWEUCBrKKzvxklNuHPyBmatnhsG(dataUpdater);
	}

	public void Clear()
	{
		TgKBgvkUWxJcUAUaEZxCzBUtMKSX();
	}

	private static HardwareControllerMap_Game gxStPMFjPAOlAyQaHMKdDYaHTjP()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		int num = 0;
		int[] array2 = default(int[]);
		int num2 = default(int);
		HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
		int num4 = default(int);
		while (true)
		{
			IL_00ec:
			int num3;
			if (num >= array.Length)
			{
				array2 = new int[132];
				num2 = 0;
				num3 = 2113784907;
				goto IL_0017;
			}
			goto IL_008b;
			IL_0017:
			while (true)
			{
				switch (num3 ^ 0x7DFDCC4D)
				{
				case 5:
					num3 = 2113784908;
					continue;
				case 6:
					num3 = 2113784910;
					continue;
				case 3:
					if (num2 >= 132)
					{
						array3 = new HardwareButtonInfo[132];
						num4 = 0;
						num3 = 2113784911;
						continue;
					}
					goto case 8;
				case 0:
					array3[num4] = new HardwareButtonInfo();
					num4++;
					num3 = 2113784911;
					continue;
				case 1:
					break;
				case 8:
					array2[num2] = array[num2].id;
					num3 = 2113784905;
					continue;
				case 4:
					num2++;
					num3 = 2113784910;
					continue;
				case 7:
					num++;
					num3 = 2113784900;
					continue;
				case 9:
					goto IL_00ec;
				default:
					if (num4 >= 132)
					{
						return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
					}
					goto case 0;
				}
				break;
			}
			goto IL_008b;
			IL_008b:
			array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, true);
			num3 = 2113784906;
			goto IL_0017;
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~hIrefywNUPTTqDhngBJCNezwczv()
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
			ReInput.ApplicationFocusChangedEvent -= CtaFdeHrYObIRlreCIAgVnnrkoBl;
			int num = 2076669802;
			while (true)
			{
				switch (num ^ 0x7BC77768)
				{
				case 0:
					num = 2076669803;
					continue;
				default:
					return;
				case 3:
					break;
				case 2:
					ReInput.EditorPauseChangedEvent -= PuQVLYTVBaFLMsBlAaHdWauuFpQ;
					ReInput.UpdateEndedEvent -= cIiCEBiNGkkiGENmFSkcCPmIrbtr;
					ReInput.TimeScalePauseChangedEvent -= xeAiYSHaeoeZzVhKscFtcwjDaaWN;
					nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
					num = 2076669801;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}

	public static int CxmbMbJFmIlxXgYpcaWHwiOaxwrZ(znchxtogvsCwUJelEblQFvJYOmG P_0, KeyCode[] P_1)
	{
		rRyCKMhmmnbHTeljAkZpUqtVrehM rRyCKMhmmnbHTeljAkZpUqtVrehM2 = P_0.ZBDGVUqPwMRTaEHiVgNTxIKSWOc;
		int num;
		int result;
		rRyCKMhmmnbHTeljAkZpUqtVrehM rRyCKMhmmnbHTeljAkZpUqtVrehM3 = default(rRyCKMhmmnbHTeljAkZpUqtVrehM);
		switch (rRyCKMhmmnbHTeljAkZpUqtVrehM2)
		{
		case rRyCKMhmmnbHTeljAkZpUqtVrehM.lHIzUIABvBbFEVpubQnyrwTlUEQ:
			rRyCKMhmmnbHTeljAkZpUqtVrehM2 = (((P_0.cYzSlphSjaOpRyGZaAoHDFSuMslD & bqXPQARmlfdTBCiGIAznGrAmCux.ywKDGoiRCdRdABbryVynwptBlFSw) != bqXPQARmlfdTBCiGIAznGrAmCux.aQwDikuGuAhSsDCrLzYYbKJdqHcG) ? rRyCKMhmmnbHTeljAkZpUqtVrehM.sPwotnjlbOKpvysSdFfhYqWwbxpD : rRyCKMhmmnbHTeljAkZpUqtVrehM.STlDePukByCGXSUsIGtAfHaCPDO);
			num = 1690019977;
			goto IL_0028;
		case rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
			goto IL_0bc0;
		case rRyCKMhmmnbHTeljAkZpUqtVrehM.ISsdInOnFyxDGAVyqjnwuSwsnrY:
			goto IL_0cfc;
		default:
			goto IL_0f61;
			IL_0cfc:
			rRyCKMhmmnbHTeljAkZpUqtVrehM2 = (((P_0.cYzSlphSjaOpRyGZaAoHDFSuMslD & bqXPQARmlfdTBCiGIAznGrAmCux.ywKDGoiRCdRdABbryVynwptBlFSw) != bqXPQARmlfdTBCiGIAznGrAmCux.aQwDikuGuAhSsDCrLzYYbKJdqHcG) ? rRyCKMhmmnbHTeljAkZpUqtVrehM.VihlAkGgWuSTdAOHlwiuLvCVIXl : rRyCKMhmmnbHTeljAkZpUqtVrehM.mMfRvzXGoclZHXcqqXJwbQdzAlI);
			num = 1690019977;
			goto IL_0028;
			IL_0bc0:
			rRyCKMhmmnbHTeljAkZpUqtVrehM2 = ((P_0.jsumKRjbgtWlPtejQqKoQOghuVh == 54) ? rRyCKMhmmnbHTeljAkZpUqtVrehM.kLWcqUSCqFrmPyKcwzFRtOdivpx : rRyCKMhmmnbHTeljAkZpUqtVrehM.ebDbavepRxEjnEDlNaweCRoMXHN);
			num = 1690019977;
			goto IL_0028;
			IL_0f61:
			result = 0;
			num = 1690019969;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ 0x64BBA8F0)
				{
				case 34:
					num = 1690019972;
					continue;
				case 129:
					P_1[result++] = KeyCode.K;
					num = 1690020035;
					continue;
				case 58:
					goto IL_02a3;
				case 144:
					goto IL_02b9;
				case 53:
					goto IL_02cf;
				case 1:
					goto IL_02e2;
				case 110:
					num = 1690020035;
					continue;
				case 123:
					goto IL_0302;
				case 9:
					goto IL_0315;
				case 12:
					goto IL_0328;
				case 136:
					num = 1690020035;
					continue;
				case 111:
					goto IL_0348;
				case 130:
					goto IL_035b;
				case 37:
					goto IL_0371;
				case 91:
					goto IL_0384;
				case 147:
					goto IL_0397;
				case 36:
					goto IL_03aa;
				case 117:
					goto IL_03c0;
				case 15:
					num = 1690020035;
					continue;
				case 28:
					goto IL_03e0;
				case 149:
					goto IL_03f6;
				case 73:
					goto IL_0409;
				case 119:
					goto IL_041c;
				case 97:
					goto IL_0432;
				case 27:
					goto IL_0448;
				case 85:
					goto IL_045e;
				case 135:
					num = 1690020035;
					continue;
				case 125:
					goto IL_047b;
				case 122:
					break;
				case 134:
					goto IL_04ad;
				case 120:
					num = 1690020035;
					continue;
				case 124:
					goto IL_04ca;
				case 67:
					goto IL_04dd;
				case 54:
					goto IL_04f0;
				case 114:
					goto IL_0503;
				case 72:
					goto IL_0519;
				case 25:
					goto IL_052b;
				case 8:
					goto IL_0541;
				case 10:
					num = 1690020035;
					continue;
				case 20:
					num = 1690020035;
					continue;
				case 87:
					goto IL_0568;
				case 77:
					goto IL_057e;
				case 86:
					goto IL_0591;
				case 127:
					goto IL_05a4;
				case 24:
					num = 1690020035;
					continue;
				case 17:
					num = 1690020035;
					continue;
				case 90:
					goto IL_05cb;
				case 108:
					goto IL_05ed;
				case 148:
					num = 1690020035;
					continue;
				case 94:
					rRyCKMhmmnbHTeljAkZpUqtVrehM3 = rRyCKMhmmnbHTeljAkZpUqtVrehM2;
					num = 1690020091;
					continue;
				case 139:
					goto IL_0617;
				case 89:
					goto IL_062a;
				case 30:
					goto IL_0640;
				case 4:
					goto IL_0653;
				case 61:
					goto IL_0669;
				case 109:
					goto IL_067c;
				case 2:
					goto IL_068f;
				case 116:
					goto end_IL_0028;
				case 70:
					goto IL_06c4;
				case 41:
					goto IL_06d7;
				case 74:
					goto IL_06ea;
				case 98:
					num = 1690020035;
					continue;
				case 35:
					num = 1690020035;
					continue;
				case 45:
					goto IL_0714;
				case 64:
					goto IL_0727;
				case 88:
					num = 1690020035;
					continue;
				case 31:
					goto IL_0747;
				case 16:
					goto IL_075a;
				case 55:
					goto IL_0770;
				case 56:
					goto IL_0783;
				case 99:
					goto IL_0795;
				case 11:
					switch (rRyCKMhmmnbHTeljAkZpUqtVrehM3)
					{
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pgQgIGixBYrYTloTqLstqlbLDDV:
						break;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xlBvdpSQZXJLHqliuUvKgtCzetI:
						goto IL_02a3;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.BCbHWpCKJNLVBAhFjXrRQHWrUSqR:
						goto IL_02b9;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pJyBWfwbwlnlXnUBqUSTXafPPaV:
						goto IL_02cf;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.EODRKzJHXHTxWuXWgQrDnHUeUUa:
						goto IL_02e2;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ESRYfjsElVodXZgPrvaVwMpBORe:
						goto IL_0302;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.EwvcCJJpnpcdmUUmIaBIiEArgJRz:
						goto IL_0315;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IWwbzvSQXqAMuHzyNqisarZRSwSB:
						goto IL_0328;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VEQvHwTpEuzNFnBKwgRYPSXAWAu:
						goto IL_0348;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xkPvDkIqmqZFRoBmwllUzORpDqPH:
						goto IL_035b;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.eZveBRahZQGRUbJtnmdyVbbnGOdD:
						goto IL_0371;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.OAvgxPPIuCcgTCRiYDLEiMiiKYLi:
						goto IL_0384;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.kfQseUWDsKgfKJlhDqfXaGOiqlRz:
						goto IL_0397;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.CrPrhLvYfJFmBIweUNuhMKfbyGO:
						goto IL_03aa;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sPwotnjlbOKpvysSdFfhYqWwbxpD:
						goto IL_03c0;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.chJsRRLFJOCWhraqECOUVDOBUGI:
						goto IL_03e0;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.QMzEtxCNURdlnHnfJugnIELXDqoM:
						goto IL_03f6;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.bhuZrLSOdxLKiphOzPtohPSockLh:
						goto IL_0409;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.yJykJjFMTtoOetvmLsZEDIsxDRE:
						goto IL_041c;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.fhHbvkWJuyQsqbfySOvTQzbUwON:
						goto IL_0432;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.GUbnEKZenaMiwbzOJddSyLslaopH:
						goto IL_0448;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.bnGJGDzlmWsvTdxqPFvheMNdmsV:
						goto IL_045e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.taBCiRGKAqwMmSUXxVfKAeEvIpN:
						goto IL_047b;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cLdgJfYmnPfDcPGHkYisQMmtTRI:
						goto end_IL_002e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.vsfqJzuLOFAzwCXOFRGitJJbhPhn:
						goto IL_04ad;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IzutmTxqErmjUqxpMRCAUIdoDZq:
						goto IL_04ca;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.UCUZfebWTIqQOrJvNVtMzPGLDhR:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VVGEOaJYhpsgZIzYCClqhEYyAZD:
						goto IL_04dd;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.UwCuDiRsIWyaUQyZKIpVAfnLTMN:
						goto IL_04f0;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LgzXbCrNZtNpGfNwuQIzIlQDHzz:
						goto IL_0503;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
						goto IL_0519;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.zzSIOcyVWZaMafgBLCQzBMBsfSZl:
						goto IL_052b;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IoWvOyKDBaCpgbpqFJBPxNIVVxa:
						goto IL_0541;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LtAFLDBdGqDaZbkxdODCtSwcZnAh:
						goto IL_0568;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LnAxVeXjsjWdAwkNWDTdnYFpYeY:
						goto IL_057e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.uBfSzBGTuAtqZWAmzLFhSuIbRCT:
						goto IL_0591;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cIDVaCKpctGfYialdviixyyVtJBN:
						goto IL_05a4;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VihlAkGgWuSTdAOHlwiuLvCVIXl:
						goto IL_05cb;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cZAhrgEzoQtOAJzQVAanCTigijVO:
						goto IL_05ed;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.GVUdFtgpMbIVZhPkiBzQTKjCjzKv:
						goto IL_0617;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.DjkENKXGnPDhRAjGJgGUstBdBCOP:
						goto IL_062a;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TaccdTOGDjysPEcjXlCecTTnHOp:
						goto IL_0640;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.gDcvidgLIoQhnuybTXdlFaqRQMN:
						goto IL_0653;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.PUvbZqBcfcMdMPpSlYTVpBWElUHe:
						goto IL_0669;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.zPwGtICNjxYliEwSfBGaYZSBrxP:
						goto IL_067c;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.FMsKvFuGaHhrMaMDaVQvWMDiXlUu:
						goto IL_068f;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.qlOekHIyWxmhKlNAGQJNYQgwfHu:
						goto IL_06c4;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.rTXaNYfAysUQKipHJYmaUpUyOhKI:
						goto IL_06d7;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LTJHFHvEizANSEksGNnqIikBIWGn:
						goto IL_06ea;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.WgEcANcmYPCTJpcFSrNFHbQCvfC:
						goto IL_0714;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.WOEcxvGUBFQhDSZOMiJPmllWUJyj:
						goto IL_0727;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.feFEZQGYvymntqUDzEZgbkHkufnE:
						goto IL_0747;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.kLWcqUSCqFrmPyKcwzFRtOdivpx:
						goto IL_075a;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.lKBfDQpFhjagurPOLuGOGTRMoVk:
						goto IL_0770;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.FIZxYpycmNmDbQxAMdnkneLgidG:
						goto IL_0783;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.lgjkhUGlWHQrOuFVdOWgcCyVCXn:
						goto IL_0795;
					default:
						goto IL_0ad4;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VzwisEYZAMtAnBAbjgzfGqDzwteg:
						goto IL_0ade;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.EbGGdJvHjbpxTkcGwZlXorgRPbK:
						goto IL_0af4;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.MYSvkcPRrUVWaLXEmcAFborYbWj:
						goto IL_0b0a;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.BpvkICKYKCbnsGplcITUWblzBeuH:
						goto IL_0b20;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.PbAnqZnBHBCbkJhKMRNKHmsdJRgp:
						goto IL_0b40;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.mMfRvzXGoclZHXcqqXJwbQdzAlI:
						goto IL_0b67;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
						goto IL_0b7d;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IQPdbCAdPIeFCWUJPzyQlcmOyXGf:
						goto IL_0b90;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.BnoOLWClHLapgAPysAHqWqcOkax:
						goto IL_0ba3;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.OQMbPadwtRTyTGhuuwwswLvXtsH:
						goto IL_0be1;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.XwerGHKXYLmpNFPiVHEnFgJJJrXm:
						goto IL_0bf4;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.DpiMvWdPmBLMDOPhpaSvXOOygcP:
						goto IL_0c07;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.esagOIEssOSjddpAMakuFmBynmHp:
						goto IL_0c1d;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.gexMAEEQTJyVGsckrGvxGBVJfTLg:
						goto IL_0c33;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.AdkoKhJqrxBDwGubZmgGdcNQoqLj:
						goto IL_0c49;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.KfCqeGtHPEXiHHXSeIYKfDUOIGF:
						goto IL_0c5f;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.STlDePukByCGXSUsIGtAfHaCPDO:
						goto IL_0c95;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.hQMPueFAIcWTbSlbIWZNYIOvyoG:
						goto IL_0cc9;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.tNZwhaHAOzPDYYooBdfFEbroofna:
						goto IL_0cdc;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VWLmOXDtxHCepADNSpOuwcXYsRD:
						goto IL_0d1e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.dAdnVufqeSaMPCRYDnoTKKmZLLPB:
						goto IL_0d3e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.uunoAmRDihyRjFzPJCoVUDKhHPL:
						goto IL_0d51;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IqQpPGpdcADsHITioQtWnhCdMmZl:
						goto IL_0d67;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.epsqaQpadQFJfHOsLZnvUykpcSPL:
						goto IL_0d7d;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HjnApHOHOKVCltjPkssiRCVwkYU:
						goto IL_0d93;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.fWzuAFjFXxdRoqxypOAIFkBEHOX:
						goto IL_0da6;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.hNMnmvbKghlnsUhExlRhGVcyiQc:
						goto IL_0db9;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ViIEfaaoCIcZvwrjBQVckIHMbAQ:
						goto IL_0dcf;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.JzRMhwsAGzfbVbAhZQwNFIOcGYZc:
						goto IL_0df8;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.qpxENSIALdndtfGNoWyPxpBPEORd:
						goto IL_0e0e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.EmARMtqvngfeZGijRQpaAHRRsJK:
						goto IL_0e21;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.oSLPnlZBJeBUnpabXvmyhRGAdCR:
						goto IL_0e34;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pZecOfcXramZhftFmOgFEKlDPHo:
						goto IL_0e47;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ebDbavepRxEjnEDlNaweCRoMXHN:
						goto IL_0e5d;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TMohdrIBqFmGlUmvsaZyAcjFTcsl:
						goto IL_0e73;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.GPkfGwjqZBgRmIZRoUrAwPwYOUKe:
						goto IL_0e93;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sIlPExWygdWsQXhUQpKBvDZyGEi:
						goto IL_0ea9;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.bYPfXldbqrxbBrxveYUHAijLMlWW:
						goto IL_0ebf;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.KqaCyxcjNapbWKfLCSRmKucKbvCw:
						goto IL_0ed5;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ZgKFpMCFabPErJsiZAAHQzUXYlTt:
						goto IL_0ee8;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.yZrXrOiQQUBHfXFXZWzebiNsEx:
						goto IL_0efe;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.BiaQTospAouUVyiUwnucooXBBvn:
						goto IL_0f28;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.tOlhhFIvFAGrtLAFpHGJkDnYfgOL:
						goto IL_0f3b;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.AuoeHLJuFMMoucoivFmLiZVphpj:
						goto IL_0f4e;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HADWdlmqPdzdpJqpJEMSkuwBEnqf:
						goto IL_0f77;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LjAeJFMuPnbmbZAnfZZJIXvBmGd:
						goto IL_0f8d;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cbxnMpgQMDGkjWeIKwfUxkGGqaT:
						goto IL_0fa0;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xxfxbTiImXWWDOxZltMacyRgtWd:
						goto IL_0fca;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xIuDTKizXrGdQWHryFwOfDhIWfYh:
						goto IL_0fdd;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HfgJiVWTwhAdFEcPOBDbfPiAjxJf:
						goto IL_0ff0;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.gvygnTGBhoGczfEAffxfHmZHWHUB:
						goto IL_1006;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.AVZhANwKNIFCghjRCuDkVBpQFtVA:
						goto IL_1063;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.vSpsSziyerCaBmdpPnxwAUeDTnc:
						goto IL_1079;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.OqjLmMGHRhOrNtAjAmSPaFDpVXI:
						goto IL_108f;
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cKfgbICWGKrtGtPJOqaNZQavsgK:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.vIzZOYAQpTMASclKChSYBujOPlZV:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.PsHEcAUbaBdeEKzeojyGHYegeTm:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.aiGFALbdVEJjBXeWmqOgLPEyhTo:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pFBIZgreGKHXhrrrgyPjEfDpNUC:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pVZFLDmipAxIKzYQTprRAAPuojx:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.PsHEcAUbaBdeEKzeojyGHYegeTm | rRyCKMhmmnbHTeljAkZpUqtVrehM.aiGFALbdVEJjBXeWmqOgLPEyhTo:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jTKVbLfcbhAbLNZVdmdCHTNQpud:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.PsHEcAUbaBdeEKzeojyGHYegeTm | rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pVZFLDmipAxIKzYQTprRAAPuojx | rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cLdgJfYmnPfDcPGHkYisQMmtTRI | rRyCKMhmmnbHTeljAkZpUqtVrehM.vIzZOYAQpTMASclKChSYBujOPlZV:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.lHIzUIABvBbFEVpubQnyrwTlUEQ:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ISsdInOnFyxDGAVyqjnwuSwsnrY:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xhfCvmZxMPBTbipfsBSwsalcoegh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pVZFLDmipAxIKzYQTprRAAPuojx | rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.QrSQIkvNbfgOTtpzJmBrnujynJh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.nOKzEezQIAdlEGebFZawyBYstXD:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HEOuWmHlmekVATyThxtThDIlepC:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jTKVbLfcbhAbLNZVdmdCHTNQpud | rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sEWDyTGNotAkRajxkuzcUUdLXGfK:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LlXHuAgxEltuZZjfjIdDubbZhqh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sDUwTzbmDrJqZMJKcAQMsVvhfAy:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.XsliqkLlcbcLDdBlwpEXLuQNHoQ:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.gBXNPrBHIibVCsuXvMLMZqSRCowF:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.THUzatqtryEQIyPCoSaIsGoQbth:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.pVtKejIRUyjaMXKHSAmZQPhQFQlG:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.fhHbvkWJuyQsqbfySOvTQzbUwON | rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.FMsKvFuGaHhrMaMDaVQvWMDiXlUu | rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sEWDyTGNotAkRajxkuzcUUdLXGfK | rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LlXHuAgxEltuZZjfjIdDubbZhqh | rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sDUwTzbmDrJqZMJKcAQMsVvhfAy | rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.XsliqkLlcbcLDdBlwpEXLuQNHoQ | rRyCKMhmmnbHTeljAkZpUqtVrehM.qFbabLdpXjkRoLOiSqFkXSkFeos:
					case (rRyCKMhmmnbHTeljAkZpUqtVrehM)64:
					case (rRyCKMhmmnbHTeljAkZpUqtVrehM)94:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.uOUexulVHtvZBwPcusgjaAmnwGz:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.vlsJGSRAPNBPtCuynngTZIZPMAoO:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jWXKrMmYpkGRnUKREwuctvLoGtD:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.iTHCzkGtrxFkwFgUHndYlAYBxrqx:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.QbkUkbSldtblbhHrnMtJeCihHxl:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.OTgLnJhiXcGWNCRGqUvQJDxdWrku:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.iOgPfEBGxunQIaboepdOgJpEBEK:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.yydBpCimOCihSDUfcmLoibKofAo:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ItZmgbWqVigmsynXeKBaLfsDajI:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TllGDamwnHzLmIxlnbFJvKEgfov:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xxfxbTiImXWWDOxZltMacyRgtWd | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jTKVbLfcbhAbLNZVdmdCHTNQpud | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.OTgLnJhiXcGWNCRGqUvQJDxdWrku | rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.fWzuAFjFXxdRoqxypOAIFkBEHOX | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.cLdgJfYmnPfDcPGHkYisQMmtTRI | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ItZmgbWqVigmsynXeKBaLfsDajI | rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TllGDamwnHzLmIxlnbFJvKEgfov | rRyCKMhmmnbHTeljAkZpUqtVrehM.TMVIOoVvuqldANUkQIBzQEJsyYh:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ISsdInOnFyxDGAVyqjnwuSwsnrY | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.IzutmTxqErmjUqxpMRCAUIdoDZq | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.yZrXrOiQQUBHfXFXZWzebiNsEx | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.xhfCvmZxMPBTbipfsBSwsalcoegh | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.ItZmgbWqVigmsynXeKBaLfsDajI | rRyCKMhmmnbHTeljAkZpUqtVrehM.NObAJGNNtyPJrqlByJOHhmTqqWs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.QrSQIkvNbfgOTtpzJmBrnujynJh | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.nOKzEezQIAdlEGebFZawyBYstXD | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HEOuWmHlmekVATyThxtThDIlepC | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jTKVbLfcbhAbLNZVdmdCHTNQpud | rRyCKMhmmnbHTeljAkZpUqtVrehM.LgzXbCrNZtNpGfNwuQIzIlQDHzz:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.FMsKvFuGaHhrMaMDaVQvWMDiXlUu | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sEWDyTGNotAkRajxkuzcUUdLXGfK | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.LlXHuAgxEltuZZjfjIdDubbZhqh | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sDUwTzbmDrJqZMJKcAQMsVvhfAy | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.XsliqkLlcbcLDdBlwpEXLuQNHoQ | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.uENjuMJJflArEKoVzDTUfcjKulzs:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.qyzqhDMSeybIsPTXEJwsXTrkqJt:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.avyafrhUHRApTelTEqckngqnRFT:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.bYMizjnhaXyPAJPSiftPjNzSrcm:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.KrwxWtLTccJXMCSzFiDmJrTNqZH:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.VyfMEHCfwGdauAMPBymkUtuHFnw:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.deOyiJoqQybCRgPYRXgMEGrZxIA:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.kjOMoTpBsVuMQidxjFvtLkEJBcY:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.MkCMbFZqCTfElkAnWywZRfEepxu:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.fYjrdtngVCZYuOEGROoWSRpCgxv:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.zSmlitWaUhIHgOWyKkIyShlKkIQ:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.XntkMNdHuLXVLUuPOSdurOkFEBD:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.CDDhrIHjMbxGviVUsZExDfuoBSj:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.sCatOhZtJrtsraShdqjjjFyDoBp:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.jsSYjgEfRpGiuZgOViGUgGEqQGev:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.dhEKkrTGlbrdpxnQCZOzZzVBJoV:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.TXjAtWlVpViJJBcQDzXXiwlSJqYK:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.gOUwhAYrFNvgRtCWIauCsvxWGbeJ:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.HjnApHOHOKVCltjPkssiRCVwkYU | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
					case rRyCKMhmmnbHTeljAkZpUqtVrehM.zPwGtICNjxYliEwSfBGaYZSBrxP | rRyCKMhmmnbHTeljAkZpUqtVrehM.SNPtiQpfzRmqqPqSWfdRbZmVWWP:
						goto IL_10a2;
					}
					goto case 129;
				case 95:
					goto IL_0ade;
				case 14:
					goto IL_0af4;
				case 137:
					goto IL_0b0a;
				case 112:
					goto IL_0b20;
				case 50:
					num = 1690020035;
					continue;
				case 38:
					goto IL_0b40;
				case 29:
					num = 1690020035;
					continue;
				case 105:
					num = 1690020035;
					continue;
				case 100:
					goto IL_0b67;
				case 75:
					goto IL_0b7d;
				case 22:
					goto IL_0b90;
				case 18:
					goto IL_0ba3;
				case 42:
					num = 1690020035;
					continue;
				case 7:
					goto IL_0bc0;
				case 39:
					goto IL_0be1;
				case 92:
					goto IL_0bf4;
				case 128:
					goto IL_0c07;
				case 81:
					goto IL_0c1d;
				case 126:
					goto IL_0c33;
				case 142:
					goto IL_0c49;
				case 143:
					goto IL_0c5f;
				case 78:
					num = 1690020035;
					continue;
				case 107:
					P_1[result++] = KeyCode.KeypadEnter;
					num = 1690020035;
					continue;
				case 26:
					goto IL_0c95;
				case 62:
					num = 1690020035;
					continue;
				case 102:
					num = 1690020035;
					continue;
				case 82:
					num = 1690020035;
					continue;
				case 101:
					goto IL_0cc9;
				case 68:
					goto IL_0cdc;
				case 96:
					num = 1690020035;
					continue;
				case 79:
					goto IL_0cfc;
				case 60:
					goto IL_0d1e;
				case 19:
					num = 1690020035;
					continue;
				case 46:
					goto IL_0d3e;
				case 84:
					goto IL_0d51;
				case 69:
					goto IL_0d67;
				case 93:
					goto IL_0d7d;
				case 133:
					goto IL_0d93;
				case 63:
					goto IL_0da6;
				case 103:
					goto IL_0db9;
				case 131:
					goto IL_0dcf;
				case 104:
					P_1[result++] = KeyCode.Return;
					num = 1690020035;
					continue;
				case 33:
					goto IL_0df8;
				case 21:
					goto IL_0e0e;
				case 6:
					goto IL_0e21;
				case 13:
					goto IL_0e34;
				case 65:
					goto IL_0e47;
				case 115:
					goto IL_0e5d;
				case 71:
					goto IL_0e73;
				case 44:
					num = 1690020035;
					continue;
				case 0:
					goto IL_0e93;
				case 132:
					goto IL_0ea9;
				case 23:
					goto IL_0ebf;
				case 138:
					goto IL_0ed5;
				case 40:
					goto IL_0ee8;
				case 3:
					goto IL_0efe;
				case 83:
					num = 1690020035;
					continue;
				case 140:
					num = 1690020035;
					continue;
				case 141:
					goto IL_0f28;
				case 5:
					goto IL_0f3b;
				case 57:
					goto IL_0f4e;
				case 121:
					goto IL_0f61;
				case 76:
					num = 1690020035;
					continue;
				case 32:
					goto IL_0f77;
				case 118:
					goto IL_0f8d;
				case 49:
					goto IL_0fa0;
				case 80:
					num = 1690020035;
					continue;
				case 106:
					num = 1690020035;
					continue;
				case 146:
					goto IL_0fca;
				case 47:
					goto IL_0fdd;
				case 52:
					goto IL_0ff0;
				case 48:
					goto IL_1006;
				case 59:
					num = 1690020035;
					continue;
				case 113:
				{
					uint key = FTnXWfjUOcgIwWIoVmLFTvfzpAl.LgBTrvwYlANuiMcSfxwUvsEMTyr((uint)P_0.ZBDGVUqPwMRTaEHiVgNTxIKSWOc, HVtRggqIPNRqQNXHENoxokIzsuB.dEyoipsAPExYmTnpDafuJSNGTAh);
					if (PSoFyYIKARkbGERxgPTVxFncTPp.ContainsKey(key))
					{
						P_1[result++] = PSoFyYIKARkbGERxgPTVxFncTPp[key];
						num = 1690020035;
						continue;
					}
					goto case 94;
				}
				case 66:
					goto IL_1063;
				case 145:
					goto IL_1079;
				case 43:
					goto IL_108f;
				default:
					goto IL_10a2;
					IL_10a2:
					return result;
					IL_108f:
					P_1[result++] = KeyCode.Alpha4;
					num = 1690020035;
					continue;
					IL_1079:
					P_1[result++] = KeyCode.KeypadDivide;
					num = 1690019960;
					continue;
					IL_1063:
					P_1[result++] = KeyCode.F3;
					num = 1690019994;
					continue;
					IL_1006:
					P_1[result++] = KeyCode.F7;
					num = 1690019959;
					continue;
					IL_0ff0:
					P_1[result++] = KeyCode.F11;
					num = 1690020035;
					continue;
					IL_0fdd:
					P_1[result++] = KeyCode.X;
					num = 1690020090;
					continue;
					IL_0fca:
					P_1[result++] = KeyCode.Tab;
					num = 1690020035;
					continue;
					IL_0fa0:
					P_1[result++] = KeyCode.F14;
					num = 1690020035;
					continue;
					IL_0f8d:
					P_1[result++] = KeyCode.B;
					num = 1690020035;
					continue;
					IL_0f77:
					P_1[result++] = KeyCode.KeypadPeriod;
					num = 1690020035;
					continue;
					IL_0f4e:
					P_1[result++] = KeyCode.Comma;
					num = 1690020035;
					continue;
					IL_0f3b:
					P_1[result++] = KeyCode.G;
					num = 1690020030;
					continue;
					IL_0f28:
					P_1[result++] = KeyCode.Alpha6;
					num = 1690020035;
					continue;
					IL_0efe:
					P_1[result++] = KeyCode.CapsLock;
					num = 1690020043;
					continue;
					IL_0ee8:
					P_1[result++] = KeyCode.Menu;
					num = 1690020035;
					continue;
					IL_0ed5:
					P_1[result++] = KeyCode.T;
					num = 1690020035;
					continue;
					IL_0ebf:
					P_1[result++] = KeyCode.F4;
					num = 1690020035;
					continue;
					IL_0ea9:
					P_1[result++] = KeyCode.F8;
					num = 1690020035;
					continue;
					IL_0e93:
					P_1[result++] = KeyCode.Keypad0;
					num = 1690020035;
					continue;
					IL_0e73:
					P_1[result++] = KeyCode.End;
					num = 1690020035;
					continue;
					IL_0e5d:
					P_1[result++] = KeyCode.LeftShift;
					num = 1690020035;
					continue;
					IL_0e47:
					P_1[result++] = KeyCode.Help;
					num = 1690020035;
					continue;
					IL_0e34:
					P_1[result++] = KeyCode.Alpha2;
					num = 1690020035;
					continue;
					IL_0e21:
					P_1[result++] = KeyCode.O;
					num = 1690020060;
					continue;
					IL_0e0e:
					P_1[result++] = KeyCode.Alpha5;
					num = 1690020035;
					continue;
					IL_0df8:
					P_1[result++] = KeyCode.F15;
					num = 1690020067;
					continue;
					IL_0dcf:
					P_1[result++] = KeyCode.RightCommand;
					num = 1690020003;
					continue;
					IL_0db9:
					P_1[result++] = KeyCode.ScrollLock;
					num = 1690020035;
					continue;
					IL_0da6:
					P_1[result++] = KeyCode.Clear;
					num = 1690020035;
					continue;
					IL_0d93:
					P_1[result++] = KeyCode.Alpha8;
					num = 1690020035;
					continue;
					IL_0d7d:
					P_1[result++] = KeyCode.Insert;
					num = 1690020035;
					continue;
					IL_0d67:
					P_1[result++] = KeyCode.Keypad4;
					num = 1690020077;
					continue;
					IL_0d51:
					P_1[result++] = KeyCode.Home;
					num = 1690020035;
					continue;
					IL_0d3e:
					P_1[result++] = KeyCode.Equals;
					num = 1690019984;
					continue;
					IL_0d1e:
					P_1[result++] = KeyCode.Keypad6;
					num = 1690020035;
					continue;
					IL_0cdc:
					P_1[result++] = KeyCode.F12;
					num = 1690020035;
					continue;
					IL_0cc9:
					P_1[result++] = KeyCode.Backslash;
					num = 1690020035;
					continue;
					IL_0c95:
					P_1[result++] = KeyCode.LeftControl;
					num = 1690020035;
					continue;
					IL_0c5f:
					P_1[result++] = KeyCode.F2;
					num = 1690020035;
					continue;
					IL_0c49:
					P_1[result++] = KeyCode.F10;
					num = 1690020035;
					continue;
					IL_0c33:
					P_1[result++] = KeyCode.PageUp;
					num = 1690020035;
					continue;
					IL_0c1d:
					P_1[result++] = KeyCode.PageDown;
					num = 1690020035;
					continue;
					IL_0c07:
					P_1[result++] = KeyCode.F1;
					num = 1690020035;
					continue;
					IL_0bf4:
					P_1[result++] = KeyCode.Z;
					num = 1690020000;
					continue;
					IL_0be1:
					P_1[result++] = KeyCode.H;
					num = 1690020008;
					continue;
					IL_0ba3:
					P_1[result++] = KeyCode.Y;
					num = 1690020035;
					continue;
					IL_0b90:
					P_1[result++] = KeyCode.Q;
					num = 1690020035;
					continue;
					IL_0b7d:
					P_1[result++] = KeyCode.Space;
					num = 1690019976;
					continue;
					IL_0b67:
					P_1[result++] = KeyCode.LeftAlt;
					num = 1690020035;
					continue;
					IL_0b40:
					P_1[result++] = KeyCode.U;
					num = 1690020035;
					continue;
					IL_0b20:
					P_1[result++] = KeyCode.F5;
					num = 1690020002;
					continue;
					IL_0b0a:
					P_1[result++] = KeyCode.Keypad8;
					num = 1690020035;
					continue;
					IL_0af4:
					P_1[result++] = KeyCode.Keypad1;
					num = 1690020035;
					continue;
					IL_0ade:
					P_1[result++] = KeyCode.DownArrow;
					num = 1690020035;
					continue;
					IL_0ad4:
					num = 1690019964;
					continue;
					IL_0795:
					P_1[result++] = KeyCode.Period;
					num = 1690019993;
					continue;
					IL_0783:
					P_1[result++] = KeyCode.None;
					num = 1690020035;
					continue;
					IL_0770:
					P_1[result++] = KeyCode.S;
					num = 1690020035;
					continue;
					IL_075a:
					P_1[result++] = KeyCode.RightShift;
					num = 1690020035;
					continue;
					IL_0747:
					P_1[result++] = KeyCode.M;
					num = 1690020035;
					continue;
					IL_0727:
					P_1[result++] = KeyCode.F9;
					num = 1690020035;
					continue;
					IL_0714:
					P_1[result++] = KeyCode.A;
					num = 1690020035;
					continue;
					IL_06ea:
					P_1[result++] = KeyCode.Keypad2;
					num = 1690020035;
					continue;
					IL_06d7:
					P_1[result++] = KeyCode.V;
					num = 1690020035;
					continue;
					IL_06c4:
					P_1[result++] = KeyCode.RightBracket;
					num = 1690020035;
					continue;
					IL_068f:
					P_1[result++] = KeyCode.Escape;
					num = 1690020095;
					continue;
					IL_067c:
					P_1[result++] = KeyCode.Alpha9;
					num = 1690019998;
					continue;
					IL_0669:
					P_1[result++] = KeyCode.I;
					num = 1690020035;
					continue;
					IL_0653:
					P_1[result++] = KeyCode.UpArrow;
					num = 1690020034;
					continue;
					IL_0640:
					P_1[result++] = KeyCode.R;
					num = 1690020035;
					continue;
					IL_062a:
					P_1[result++] = KeyCode.KeypadMinus;
					num = 1690020046;
					continue;
					IL_0617:
					P_1[result++] = KeyCode.D;
					num = 1690020035;
					continue;
					IL_05ed:
					P_1[result++] = KeyCode.L;
					num = 1690020035;
					continue;
					IL_05cb:
					P_1[result++] = KeyCode.AltGr;
					P_1[result++] = KeyCode.RightAlt;
					num = 1690020035;
					continue;
					IL_05a4:
					P_1[result++] = KeyCode.E;
					num = 1690020035;
					continue;
					IL_0591:
					P_1[result++] = KeyCode.Alpha7;
					num = 1690020035;
					continue;
					IL_057e:
					P_1[result++] = KeyCode.LeftBracket;
					num = 1690020035;
					continue;
					IL_0568:
					P_1[result++] = KeyCode.F13;
					num = 1690020035;
					continue;
					IL_0541:
					P_1[result++] = KeyCode.W;
					num = 1690020035;
					continue;
					IL_052b:
					P_1[result++] = KeyCode.KeypadMultiply;
					num = 1690020035;
					continue;
					IL_0519:
					P_1[result++] = KeyCode.Backspace;
					num = 1690020028;
					continue;
					IL_0503:
					P_1[result++] = KeyCode.Numlock;
					num = 1690020035;
					continue;
					IL_04f0:
					P_1[result++] = KeyCode.C;
					num = 1690020035;
					continue;
					IL_04dd:
					P_1[result++] = KeyCode.BackQuote;
					num = 1690020035;
					continue;
					IL_04ca:
					P_1[result++] = KeyCode.Pause;
					num = 1690020035;
					continue;
					IL_04ad:
					P_1[result++] = KeyCode.Semicolon;
					num = 1690020068;
					continue;
					IL_047b:
					P_1[result++] = KeyCode.J;
					num = 1690020035;
					continue;
					IL_045e:
					P_1[result++] = KeyCode.N;
					num = 1690020035;
					continue;
					IL_0448:
					P_1[result++] = KeyCode.LeftArrow;
					num = 1690019940;
					continue;
					IL_0432:
					P_1[result++] = KeyCode.Print;
					num = 1690020035;
					continue;
					IL_041c:
					P_1[result++] = KeyCode.KeypadPlus;
					num = 1690020035;
					continue;
					IL_0409:
					P_1[result++] = KeyCode.Alpha1;
					num = 1690020072;
					continue;
					IL_03f6:
					P_1[result++] = KeyCode.Alpha3;
					num = 1690019990;
					continue;
					IL_03e0:
					P_1[result++] = KeyCode.Keypad9;
					num = 1690020065;
					continue;
					IL_03c0:
					P_1[result++] = KeyCode.RightControl;
					num = 1690020058;
					continue;
					IL_03aa:
					P_1[result++] = KeyCode.Keypad5;
					num = 1690020035;
					continue;
					IL_0397:
					P_1[result++] = KeyCode.Slash;
					num = 1690020035;
					continue;
					IL_0384:
					P_1[result++] = KeyCode.Minus;
					num = 1690020035;
					continue;
					IL_0371:
					P_1[result++] = KeyCode.Alpha0;
					num = 1690020035;
					continue;
					IL_035b:
					P_1[result++] = KeyCode.Keypad3;
					num = 1690020035;
					continue;
					IL_0348:
					P_1[result++] = KeyCode.F;
					num = 1690020035;
					continue;
					IL_0328:
					P_1[result++] = KeyCode.Keypad7;
					num = 1690019986;
					continue;
					IL_0315:
					P_1[result++] = KeyCode.P;
					num = 1690020035;
					continue;
					IL_0302:
					P_1[result++] = KeyCode.Delete;
					num = 1690020035;
					continue;
					IL_02e2:
					P_1[result++] = KeyCode.RightArrow;
					num = 1690020035;
					continue;
					IL_02cf:
					P_1[result++] = KeyCode.Quote;
					num = 1690020035;
					continue;
					IL_02b9:
					P_1[result++] = KeyCode.F6;
					num = 1690020051;
					continue;
					IL_02a3:
					P_1[result++] = KeyCode.LeftCommand;
					num = 1690020035;
					continue;
					end_IL_002e:
					break;
				}
				int num2;
				if ((P_0.cYzSlphSjaOpRyGZaAoHDFSuMslD & bqXPQARmlfdTBCiGIAznGrAmCux.ywKDGoiRCdRdABbryVynwptBlFSw) == 0)
				{
					num = 1690019992;
					num2 = num;
				}
				else
				{
					num = 1690019995;
					num2 = num;
				}
				continue;
				end_IL_0028:
				break;
			}
			goto case rRyCKMhmmnbHTeljAkZpUqtVrehM.lHIzUIABvBbFEVpubQnyrwTlUEQ;
		}
	}
}
