using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class semsxMCoWgefAkNrSJJwPcOjkQI : IDisposable, IUnifiedKeyboardSource
{
	private class ffNnMWOtPLnWPKEflPALoTBunKw
	{
		private enum WDdXahLwTgAnTDJxbbjgfBmcZOZ
		{
			CEUjyvGIbsPgNjwVqrjvtItjjrS = 0,
			KyvYcVuHgpltaoATHEroKeMagqTG = 1,
			pihzgzYIlFnQqTeCpFwuFSxYPMk = 2
		}

		private const int QQBHfCBGIzyxYmQRwugkesCtkdu = 2;

		private static readonly KeyCode[] xlSKNkFwNXaMOMYnFQPbXfRBKiX = new KeyCode[2];

		private readonly UpdateLoopType xlaANeYPvyhpTiakMhbNPdKQFqJ;

		private bool[] mTiETACZqghJRNgcmnKTRhSKcJUu;

		private bool[] DSwWqcUpyPOgHlwQYJNiEGALYCi;

		private uint gNMmuYrggEkuYrNpLGhJfxgnJdW;

		public ffNnMWOtPLnWPKEflPALoTBunKw(UpdateLoopType updateLoop)
		{
			xlaANeYPvyhpTiakMhbNPdKQFqJ = updateLoop;
			mTiETACZqghJRNgcmnKTRhSKcJUu = new bool[132];
			DSwWqcUpyPOgHlwQYJNiEGALYCi = new bool[132];
		}

		public void YHswTwWqwjgaHZFKRxdOplcOvyY(ipwruYYKPldFWmYuJnDLBmTbJhD P_0)
		{
			int num = ZblPGcnFMjTOGlATMwYOmEJuSjI(P_0, xlSKNkFwNXaMOMYnFQPbXfRBKiX);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)xlSKNkFwNXaMOMYnFQPbXfRBKiX[i];
				if (num2 >= 0 && num2 < CxMzNuEfcomPzYfsuCDLcyXESQln.Length)
				{
					uvxRgDFmdliTSgWsBezRbUrebGkw oayUDEPfbhMWaUwggSuoNsdfvjR = P_0.oayUDEPfbhMWaUwggSuoNsdfvjR;
					uvxRgDFmdliTSgWsBezRbUrebGkw uvxRgDFmdliTSgWsBezRbUrebGkw2 = oayUDEPfbhMWaUwggSuoNsdfvjR;
					bool flag = ((uvxRgDFmdliTSgWsBezRbUrebGkw2 == uvxRgDFmdliTSgWsBezRbUrebGkw.QyiooDoiIgxAvwFgZFdWndOeVvT || uvxRgDFmdliTSgWsBezRbUrebGkw2 == uvxRgDFmdliTSgWsBezRbUrebGkw.OLBkFZukxrzCzZarUeHNdZMBwtt) ? true : false);
					int num3 = CxMzNuEfcomPzYfsuCDLcyXESQln[num2];
					bool flag2 = mTiETACZqghJRNgcmnKTRhSKcJUu[num3];
					mTiETACZqghJRNgcmnKTRhSKcJUu[num3] = flag;
					if (!flag2 && flag)
					{
						DSwWqcUpyPOgHlwQYJNiEGALYCi[num3] = true;
					}
				}
			}
		}

		public void NbRHSKRDySxUtOnCxXuGoqccJvd(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = mTiETACZqghJRNgcmnKTRhSKcJUu[i] || DSwWqcUpyPOgHlwQYJNiEGALYCi[i];
			}
			gPKYWvCNQJcdTVhdYLqWRhFPsbB();
		}

		public void xbrgbsymhweSXlyAZAqkvRqFNEB()
		{
			gPKYWvCNQJcdTVhdYLqWRhFPsbB();
		}

		private void gPKYWvCNQJcdTVhdYLqWRhFPsbB()
		{
			if (gNMmuYrggEkuYrNpLGhJfxgnJdW != ReInput.absFrame)
			{
				OxgfQwEYzNOiyLKHqRcAOsnIbYjl();
				gNMmuYrggEkuYrNpLGhJfxgnJdW = ReInput.absFrame;
			}
		}

		public void OxgfQwEYzNOiyLKHqRcAOsnIbYjl()
		{
			Array.Clear(DSwWqcUpyPOgHlwQYJNiEGALYCi, 0, 132);
		}

		public void TzBPrZngbKbHBhJPAmtHpHNMMTtf()
		{
			Array.Clear(mTiETACZqghJRNgcmnKTRhSKcJUu, 0, 132);
			Array.Clear(DSwWqcUpyPOgHlwQYJNiEGALYCi, 0, 132);
		}
	}

	private const int oAgEcboMdlEaIEGOCLobkVJhZnTW = 132;

	private const int oGLLsEhvqwEdtgzpyjOfsMqvkpf = 256;

	private readonly object DYqmLYQWtnCkUZCOjwXSRkHXDqs = new object();

	private UpdateLoopDataSet<ffNnMWOtPLnWPKEflPALoTBunKw> rBSQPHpAEpZjiGRosdEilOsbJXt;

	private HardwareControllerMap_Game xEHeCYbzZHcwCqXyRzEObXqDbVi;

	private bool WJeRKxtTKsphDaGMsYlUloenxBg;

	private int ynDBJaibcklQXxhGcyRNAQKqhIv;

	private bool[] THcQoxsTqqpFqlarkSMnJLioSxO = new bool[256];

	private readonly ipwruYYKPldFWmYuJnDLBmTbJhD FaRKbIidlYCEhfLslYqPyUPHHFq = new ipwruYYKPldFWmYuJnDLBmTbJhD();

	private static readonly int[] CxMzNuEfcomPzYfsuCDLcyXESQln;

	private static readonly int IjbwdhvMntfTRTdlLfDjFbZJCbFg;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	private static IntPtr IzAGxDDzWaMNyBdMVcWELkrOMQx;

	private static YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD QNRjewXOOeQpCDGqnVjOnSCVFVk;

	private static readonly int[] ZdpQlwbvFlOgWaYDMlNEZywhPLE;

	private static Dictionary<int, Dictionary<int, KeyCode>> llxXyJgcIYzfwnKmRVFxYgneCXA;

	private static readonly int[] VnzFwduqbPhbJXyAzOGdwHUmEAaJ;

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (xEHeCYbzZHcwCqXyRzEObXqDbVi == null)
			{
				xEHeCYbzZHcwCqXyRzEObXqDbVi = xymhxCjcTszQcNdaCAHXJrBYQlG();
			}
			return xEHeCYbzZHcwCqXyRzEObXqDbVi;
		}
	}

	public int buttonCount => 132;

	public Controller.Extension controllerExtension => null;

	static semsxMCoWgefAkNrSJJwPcOjkQI()
	{
		QNRjewXOOeQpCDGqnVjOnSCVFVk = YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD.mwnNCUqkkmpNkLjfFYluwUYSXes;
		ZdpQlwbvFlOgWaYDMlNEZywhPLE = (int[])Enum.GetValues(typeof(YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD));
		llxXyJgcIYzfwnKmRVFxYgneCXA = new Dictionary<int, Dictionary<int, KeyCode>>
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
		VnzFwduqbPhbJXyAzOGdwHUmEAaJ = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > IjbwdhvMntfTRTdlLfDjFbZJCbFg)
			{
				IjbwdhvMntfTRTdlLfDjFbZJCbFg = keyboardKeyValues[i];
			}
		}
		CxMzNuEfcomPzYfsuCDLcyXESQln = new int[IjbwdhvMntfTRTdlLfDjFbZJCbFg + 1];
		ArrayTools.Fill(CxMzNuEfcomPzYfsuCDLcyXESQln, -1);
		for (int j = 0; j < num; j++)
		{
			CxMzNuEfcomPzYfsuCDLcyXESQln[keyboardKeyValues[j]] = j;
		}
	}

	public semsxMCoWgefAkNrSJJwPcOjkQI(UpdateLoopSetting updateLoopSetting)
	{
		XizBWdVKeSmspQLrhznlgNFWzLm();
		rBSQPHpAEpZjiGRosdEilOsbJXt = new UpdateLoopDataSet<ffNnMWOtPLnWPKEflPALoTBunKw>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i] = new ffNnMWOtPLnWPKEflPALoTBunKw(list[i]);
			}
		}
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Keyboard);
		ReInput.ApplicationFocusChangedEvent += RbzPnjPKwnvkSOVQeEdrtPoybHi;
		ReInput.EditorPauseChangedEvent += QzTNlFpirLGoLVsrgGykIfjxeAh;
		ReInput.UpdateEndedEvent += lrvLKEbMyRgDDiIWnAynFDrmFkWw;
		ReInput.TimeScalePauseChangedEvent += cSDTWLpxUFauyuZmKkZyaygMBht;
	}

	public unsafe void RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		rBSQPHpAEpZjiGRosdEilOsbJXt.SetUpdateLoop(P_0);
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!AewjMoBLyBolnnNMhBXWHRooNZC.lGEIMckzpEMogUqZFYitDPUHCzk((IntPtr)ptr))
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
						if (THcQoxsTqqpFqlarkSMnJLioSxO[i])
						{
							FaRKbIidlYCEhfLslYqPyUPHHFq.dtacWSwUXqejVvKTIPvzDNvgneL();
							FaRKbIidlYCEhfLslYqPyUPHHFq.lwetWUmJoDgKnNxGfQksKVlucJD = ReInput.realTime;
							FaRKbIidlYCEhfLslYqPyUPHHFq.TtxGEzbPGmfFtctndOWwSOdhrvR = IntPtr.Zero;
							FaRKbIidlYCEhfLslYqPyUPHHFq.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = (kGzKERAiEUkXQAhDKgJaitseOtM)i;
							FaRKbIidlYCEhfLslYqPyUPHHFq.uVjyxYHGYMEbOEbToWajWAjwpzU = 0;
							FaRKbIidlYCEhfLslYqPyUPHHFq.bTmDziHDFXIUOXMzQKaELCXbDvIe = keYfQZftRQMIGBjcEezmFOHqjHQy.FwmSUurEGCrfMxlxmebPPFcnMaK;
							FaRKbIidlYCEhfLslYqPyUPHHFq.oayUDEPfbhMWaUwggSuoNsdfvjR = uvxRgDFmdliTSgWsBezRbUrebGkw.kurTkOtzmGiionJWdgzuPoCUVMK;
							FaRKbIidlYCEhfLslYqPyUPHHFq.ywgIJFxxTHiiMBKAFmOWIrjqpDL = 0;
							pxuGNwZmtUejHeAPFpfZJLcwCmlw(FaRKbIidlYCEhfLslYqPyUPHHFq);
						}
					}
					else if (!THcQoxsTqqpFqlarkSMnJLioSxO[i])
					{
						FaRKbIidlYCEhfLslYqPyUPHHFq.dtacWSwUXqejVvKTIPvzDNvgneL();
						FaRKbIidlYCEhfLslYqPyUPHHFq.lwetWUmJoDgKnNxGfQksKVlucJD = ReInput.realTime;
						FaRKbIidlYCEhfLslYqPyUPHHFq.TtxGEzbPGmfFtctndOWwSOdhrvR = IntPtr.Zero;
						FaRKbIidlYCEhfLslYqPyUPHHFq.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = (kGzKERAiEUkXQAhDKgJaitseOtM)i;
						FaRKbIidlYCEhfLslYqPyUPHHFq.uVjyxYHGYMEbOEbToWajWAjwpzU = 0;
						FaRKbIidlYCEhfLslYqPyUPHHFq.bTmDziHDFXIUOXMzQKaELCXbDvIe = keYfQZftRQMIGBjcEezmFOHqjHQy.dHxVmdOfSlppnvgBjZEZMESiQKP;
						FaRKbIidlYCEhfLslYqPyUPHHFq.oayUDEPfbhMWaUwggSuoNsdfvjR = uvxRgDFmdliTSgWsBezRbUrebGkw.QyiooDoiIgxAvwFgZFdWndOeVvT;
						FaRKbIidlYCEhfLslYqPyUPHHFq.ywgIJFxxTHiiMBKAFmOWIrjqpDL = 0;
						pxuGNwZmtUejHeAPFpfZJLcwCmlw(FaRKbIidlYCEhfLslYqPyUPHHFq);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void pxuGNwZmtUejHeAPFpfZJLcwCmlw(ipwruYYKPldFWmYuJnDLBmTbJhD P_0)
	{
		if (!WJeRKxtTKsphDaGMsYlUloenxBg)
		{
			return;
		}
		switch (P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe)
		{
		case kGzKERAiEUkXQAhDKgJaitseOtM.qGXabHyZhwlEXmzPBRAnxMpsyPd:
		{
			kGzKERAiEUkXQAhDKgJaitseOtM kGzKERAiEUkXQAhDKgJaitseOtM2 = (kGzKERAiEUkXQAhDKgJaitseOtM)AewjMoBLyBolnnNMhBXWHRooNZC.KLWgfiEsFzvHvrDcXCeDKhPTarCD((uint)P_0.uVjyxYHGYMEbOEbToWajWAjwpzU, YZuduhHYdujZNQijkwygrqXwCpon.rupHblOxfHIHwbZEfDYdGCDWIUY);
			if (kGzKERAiEUkXQAhDKgJaitseOtM2 != kGzKERAiEUkXQAhDKgJaitseOtM.PzwSmUGAlVdnIpuEqGbVDffZyCd && kGzKERAiEUkXQAhDKgJaitseOtM2 != kGzKERAiEUkXQAhDKgJaitseOtM.nJpaxkfDNtmCkPHaPGloUELplsMs)
			{
				return;
			}
			P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = (((P_0.bTmDziHDFXIUOXMzQKaELCXbDvIe & keYfQZftRQMIGBjcEezmFOHqjHQy.jCHUAtxmgWbUNMQXAamirZuSUfd) != keYfQZftRQMIGBjcEezmFOHqjHQy.dHxVmdOfSlppnvgBjZEZMESiQKP) ? kGzKERAiEUkXQAhDKgJaitseOtM.nJpaxkfDNtmCkPHaPGloUELplsMs : kGzKERAiEUkXQAhDKgJaitseOtM.PzwSmUGAlVdnIpuEqGbVDffZyCd);
			break;
		}
		case kGzKERAiEUkXQAhDKgJaitseOtM.DBhKRoqjxNcBZzSkMbIzeivxuir:
			P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = (((P_0.bTmDziHDFXIUOXMzQKaELCXbDvIe & keYfQZftRQMIGBjcEezmFOHqjHQy.jCHUAtxmgWbUNMQXAamirZuSUfd) != keYfQZftRQMIGBjcEezmFOHqjHQy.dHxVmdOfSlppnvgBjZEZMESiQKP) ? kGzKERAiEUkXQAhDKgJaitseOtM.SrqCOnEqgVkkgIbzEZotNZDAEISM : kGzKERAiEUkXQAhDKgJaitseOtM.hHqGnearMZbgYucUOiVlynauVkbA);
			break;
		case kGzKERAiEUkXQAhDKgJaitseOtM.SCaYbPtzxDooaLeNQDSIlhbrbuR:
		{
			P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = (kGzKERAiEUkXQAhDKgJaitseOtM)AewjMoBLyBolnnNMhBXWHRooNZC.KLWgfiEsFzvHvrDcXCeDKhPTarCD((uint)P_0.uVjyxYHGYMEbOEbToWajWAjwpzU, YZuduhHYdujZNQijkwygrqXwCpon.rupHblOxfHIHwbZEfDYdGCDWIUY);
			if (P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe == kGzKERAiEUkXQAhDKgJaitseOtM.lmCauqOpOYCiuxHhreCvQAbJSDu || P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe == kGzKERAiEUkXQAhDKgJaitseOtM.phZdgBquAsbAIZgYAWxYnOudcqI)
			{
				break;
			}
			uvxRgDFmdliTSgWsBezRbUrebGkw oayUDEPfbhMWaUwggSuoNsdfvjR = P_0.oayUDEPfbhMWaUwggSuoNsdfvjR;
			bool flag = ((oayUDEPfbhMWaUwggSuoNsdfvjR == uvxRgDFmdliTSgWsBezRbUrebGkw.QyiooDoiIgxAvwFgZFdWndOeVvT || oayUDEPfbhMWaUwggSuoNsdfvjR == uvxRgDFmdliTSgWsBezRbUrebGkw.OLBkFZukxrzCzZarUeHNdZMBwtt || oayUDEPfbhMWaUwggSuoNsdfvjR == uvxRgDFmdliTSgWsBezRbUrebGkw.ILVUuuCrnIHmEqktQflPJxaZfUoU) ? true : false);
			bool flag2 = (AewjMoBLyBolnnNMhBXWHRooNZC.flLvKQzCPnXcurXRbLwjkLKxQuU(160) & 0x8000) != 0;
			bool flag3 = (AewjMoBLyBolnnNMhBXWHRooNZC.flLvKQzCPnXcurXRbLwjkLKxQuU(161) & 0x8000) != 0;
			if (flag)
			{
				bool flag4 = (AewjMoBLyBolnnNMhBXWHRooNZC.EgrHVWeqxnqXldbAHRprvVxzdxDY(160) & 0x8000) != 0;
				bool flag5 = (AewjMoBLyBolnnNMhBXWHRooNZC.EgrHVWeqxnqXldbAHRprvVxzdxDY(161) & 0x8000) != 0;
				if (flag4)
				{
					P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.lmCauqOpOYCiuxHhreCvQAbJSDu;
					pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
				}
				if (flag5)
				{
					P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.phZdgBquAsbAIZgYAWxYnOudcqI;
					pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.lmCauqOpOYCiuxHhreCvQAbJSDu;
				break;
			}
			if (flag3)
			{
				P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.phZdgBquAsbAIZgYAWxYnOudcqI;
				break;
			}
			P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.lmCauqOpOYCiuxHhreCvQAbJSDu;
			pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
			P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe = kGzKERAiEUkXQAhDKgJaitseOtM.phZdgBquAsbAIZgYAWxYnOudcqI;
			pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
			return;
		}
		}
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			uvxRgDFmdliTSgWsBezRbUrebGkw oayUDEPfbhMWaUwggSuoNsdfvjR2 = P_0.oayUDEPfbhMWaUwggSuoNsdfvjR;
			if (oayUDEPfbhMWaUwggSuoNsdfvjR2 == uvxRgDFmdliTSgWsBezRbUrebGkw.QyiooDoiIgxAvwFgZFdWndOeVvT || oayUDEPfbhMWaUwggSuoNsdfvjR2 == uvxRgDFmdliTSgWsBezRbUrebGkw.OLBkFZukxrzCzZarUeHNdZMBwtt)
			{
				THcQoxsTqqpFqlarkSMnJLioSxO[(int)P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe] = true;
			}
			else
			{
				THcQoxsTqqpFqlarkSMnJLioSxO[(int)P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe] = false;
			}
			int count = rBSQPHpAEpZjiGRosdEilOsbJXt.Count;
			for (int i = 0; i < count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i].YHswTwWqwjgaHZFKRxdOplcOvyY(P_0);
			}
		}
	}

	public void wyrqFdOgaxQVgbBnFdlZHDmYRww(bool P_0)
	{
		QoHOmykwwMDrJvAIllxBJXXRJbt();
	}

	public void BaKUrWtSdbbeIHinStpYOpNkyeF(bool P_0)
	{
		int num = XizBWdVKeSmspQLrhznlgNFWzLm();
		if (num < 0)
		{
			QoHOmykwwMDrJvAIllxBJXXRJbt();
		}
	}

	private int XizBWdVKeSmspQLrhznlgNFWzLm()
	{
		int num = ynDBJaibcklQXxhGcyRNAQKqhIv;
		if (CDUDUtloSCOYNTanpthEeshuCdC.vTXbPWoRYRDlFArXUISNbPwbwMuJ(MAPTyOhgNVdBQSioUpquSdYiRkd.cXiIaGSjeBKnSzIJGvtEtwBDTsm, out var num2))
		{
			ynDBJaibcklQXxhGcyRNAQKqhIv = num2;
		}
		else
		{
			ynDBJaibcklQXxhGcyRNAQKqhIv = 1;
		}
		return ynDBJaibcklQXxhGcyRNAQKqhIv - num;
	}

	private void RbzPnjPKwnvkSOVQeEdrtPoybHi(bool P_0)
	{
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !WJeRKxtTKsphDaGMsYlUloenxBg)
		{
			QoHOmykwwMDrJvAIllxBJXXRJbt();
		}
	}

	private void QzTNlFpirLGoLVsrgGykIfjxeAh(bool P_0)
	{
	}

	private void cSDTWLpxUFauyuZmKkZyaygMBht(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			rBSQPHpAEpZjiGRosdEilOsbJXt[rBSQPHpAEpZjiGRosdEilOsbJXt.fixedUpdateSetIndex].OxgfQwEYzNOiyLKHqRcAOsnIbYjl();
		}
	}

	private void lrvLKEbMyRgDDiIWnAynFDrmFkWw(UpdateLoopType P_0)
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			rBSQPHpAEpZjiGRosdEilOsbJXt.Get(P_0).xbrgbsymhweSXlyAZAqkvRqFNEB();
		}
	}

	private void QoHOmykwwMDrJvAIllxBJXXRJbt()
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			int count = rBSQPHpAEpZjiGRosdEilOsbJXt.Count;
			for (int i = 0; i < count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i].TzBPrZngbKbHBhJPAmtHpHNMMTtf();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		rBSQPHpAEpZjiGRosdEilOsbJXt.Current.NbRHSKRDySxUtOnCxXuGoqccJvd(dataUpdater);
	}

	public void Clear()
	{
		QoHOmykwwMDrJvAIllxBJXXRJbt();
	}

	private static HardwareControllerMap_Game xymhxCjcTszQcNdaCAHXJrBYQlG()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, isMappableOnPlatform: true);
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
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~semsxMCoWgefAkNrSJJwPcOjkQI()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			ReInput.ApplicationFocusChangedEvent -= RbzPnjPKwnvkSOVQeEdrtPoybHi;
			ReInput.EditorPauseChangedEvent -= QzTNlFpirLGoLVsrgGykIfjxeAh;
			ReInput.UpdateEndedEvent -= lrvLKEbMyRgDDiIWnAynFDrmFkWw;
			ReInput.TimeScalePauseChangedEvent -= cSDTWLpxUFauyuZmKkZyaygMBht;
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	public static int ZblPGcnFMjTOGlATMwYOmEJuSjI(ipwruYYKPldFWmYuJnDLBmTbJhD P_0, KeyCode[] P_1)
	{
		kGzKERAiEUkXQAhDKgJaitseOtM eqQtXFYIIvPsnxSSrhFCxbDZhPXe = P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe;
		int result = 0;
		YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD nURGBCUamAWLTASRDDLecYPNAbD = JRMWoRCKevwGjthehCHbvcSogAG();
		_ = IzAGxDDzWaMNyBdMVcWELkrOMQx;
		AewjMoBLyBolnnNMhBXWHRooNZC.KLWgfiEsFzvHvrDcXCeDKhPTarCD((uint)P_0.EqQtXFYIIvPsnxSSrhFCxbDZhPXe, YZuduhHYdujZNQijkwygrqXwCpon.sjzoXyYNcjSaveLVtiSfFKBTWqW);
		if (ewcvHlOwkSUgfpOexgIYIAEEGncR(eqQtXFYIIvPsnxSSrhFCxbDZhPXe))
		{
			if (kaKbCQulvzFxHersEZstRdJjTKUV(eqQtXFYIIvPsnxSSrhFCxbDZhPXe, nURGBCUamAWLTASRDDLecYPNAbD, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (eqQtXFYIIvPsnxSSrhFCxbDZhPXe)
			{
			case kGzKERAiEUkXQAhDKgJaitseOtM.CEUjyvGIbsPgNjwVqrjvtItjjrS:
				P_1[result++] = KeyCode.None;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.HLBkENEeigvOzUhEwfKAFVCHodx:
				P_1[result++] = KeyCode.A;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.EkLVBMiyhEVFkqmJBATEkUaKVBSt:
				P_1[result++] = KeyCode.B;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.PqFcJrxRCvFNFljEgGhMUniQUSs:
				P_1[result++] = KeyCode.C;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.RTVJduUCiOsEEauKEzSHMAmVkQr:
				P_1[result++] = KeyCode.D;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.bJCDuXeXWQYMNVXJPgCvmLdMQMk:
				P_1[result++] = KeyCode.E;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.InDEPrvZcFHeWSLiUEZVHpGVXZF:
				P_1[result++] = KeyCode.F;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.sjmSdMsXjbmCyyXrFsUULYyDSnf:
				P_1[result++] = KeyCode.G;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ZWVlGtJFAosLGdWnEmjtmKaKmxc:
				P_1[result++] = KeyCode.H;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.UZenDhOPFXiMNAQqHTHSbLDVlVyR:
				P_1[result++] = KeyCode.I;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.wOKsSMcKaXlQxbTjDXqBCoRowPs:
				P_1[result++] = KeyCode.J;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.wRVtAZOSrpitUGKfGcyakrqSBCsA:
				P_1[result++] = KeyCode.K;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.rAZrrhJVGtftVIIwvSoeXgxjKok:
				P_1[result++] = KeyCode.L;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.aPEMVRaFNXtGmFzvPhFlmEEtwiM:
				P_1[result++] = KeyCode.M;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.mKHXWMFdWvaYSOFGpHluhiMgxtsA:
				P_1[result++] = KeyCode.N;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.TbBHWaOdXBQPOhHXjBEnSKSQMrb:
				P_1[result++] = KeyCode.O;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.DxwIFKpCPAAnxxBOkPPTCPviEXa:
				P_1[result++] = KeyCode.P;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.LHOlpVJWrnNkHbNhnLgBivpNEsb:
				P_1[result++] = KeyCode.Q;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.IofajCablOhTOpyVdljtojGyhWU:
				P_1[result++] = KeyCode.R;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.mCCfhBLXRYTmzYxsloMBMISPzFP:
				P_1[result++] = KeyCode.S;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ZedmcoVFpFYYJEylegBzcfrVCwh:
				P_1[result++] = KeyCode.T;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.GSFweOFIvsLOrMBgyGRNEyjgAUVB:
				P_1[result++] = KeyCode.U;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.wFINDZayAHibJKChxxmdtiDbGetK:
				P_1[result++] = KeyCode.V;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ZENDCtmmtXGClCwYxRJOJGBWdaB:
				P_1[result++] = KeyCode.W;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.aKhnJLPlzQqMJcsXANqZDKcXdkvk:
				P_1[result++] = KeyCode.X;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.CfrGUAcJZiBIgrKhIOoWYteVjgS:
				P_1[result++] = KeyCode.Y;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.WXjeIOAoewOQIscExpKoNuKQHmwy:
				P_1[result++] = KeyCode.Z;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.nxusVIEfxxOaTsUBLfSdzEgeITQ:
				P_1[result++] = KeyCode.Alpha0;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.eMdobAoWZYDtrCRkHkbrfEJfEnaH:
				P_1[result++] = KeyCode.Alpha1;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.bUKXUcjljXnZkIVxhwIvpRRZJac:
				P_1[result++] = KeyCode.Alpha2;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.VhyQbolHiqBQeEIVYHkgGsKGZbX:
				P_1[result++] = KeyCode.Alpha3;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.VyuNhVcvzIdFCUTquehAeeAqYch:
				P_1[result++] = KeyCode.Alpha4;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.zJwQHVuAdSMAgdLxEvaIfqEGWTk:
				P_1[result++] = KeyCode.Alpha5;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.AGbbStGsHRHZWZEUAOjjeLfGaKCb:
				P_1[result++] = KeyCode.Alpha6;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.dTuCrIgWOrZDMhdMTpRoWWRweFq:
				P_1[result++] = KeyCode.Alpha7;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.QkkUQOmZljwPoEutMeaxLUJpxsj:
				P_1[result++] = KeyCode.Alpha8;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.mipSlDewRUFSrbJkDaKvWJNIrym:
				P_1[result++] = KeyCode.Alpha9;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ThlxOrVyzgdyniIzImzXDwlLuZr:
				P_1[result++] = KeyCode.Keypad0;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.LmLIqSBXTCCLCFbyMdJGypmCgYjD:
				P_1[result++] = KeyCode.Keypad1;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.GfGcLQNXCWIkBkFOwRzjhubHxLxt:
				P_1[result++] = KeyCode.Keypad2;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.sIAEBdkKIZvqGRPOACtDzwMkQrc:
				P_1[result++] = KeyCode.Keypad3;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.LiJbBRRTQdGVEeeYUnfRpvPqhjqz:
				P_1[result++] = KeyCode.Keypad4;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.DEAGnGKJFgPZKEnEBumirGclaVhz:
				P_1[result++] = KeyCode.Keypad5;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.GBKeSWebVgtPabtbqHAhdqYaHCyo:
				P_1[result++] = KeyCode.Keypad6;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.LBfPrmwOnPSdxIqStEwpfxKEHzpC:
				P_1[result++] = KeyCode.Keypad7;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.XNRpsfhLtjaQFwbtAyCCbmnLuhM:
				P_1[result++] = KeyCode.Keypad8;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.hHKuNKvvczdlgQUnyEmHJXSGNrt:
				P_1[result++] = KeyCode.Keypad9;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ASOFbcGKvMsOcqEFlgCDIgrUHmXT:
				P_1[result++] = KeyCode.KeypadPeriod;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.cWgaiaIpWIqfYXtPbifdYktMcKH:
				P_1[result++] = KeyCode.KeypadDivide;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.stXVGjMNgwdddKSrtUAwEAKhmTqz:
				P_1[result++] = KeyCode.KeypadMultiply;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.MkjvRDjfLknCKKrknrWHhRQurFb:
				P_1[result++] = KeyCode.KeypadMinus;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.fjNiqfPnUABhMqOfzqJBJzslGp:
				P_1[result++] = KeyCode.KeypadPlus;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.xrUsdIwuYWGDAgvaSOEzMgXgDKo:
				if ((P_0.bTmDziHDFXIUOXMzQKaELCXbDvIe & keYfQZftRQMIGBjcEezmFOHqjHQy.jCHUAtxmgWbUNMQXAamirZuSUfd) != keYfQZftRQMIGBjcEezmFOHqjHQy.dHxVmdOfSlppnvgBjZEZMESiQKP)
				{
					P_1[result++] = KeyCode.KeypadEnter;
				}
				else
				{
					P_1[result++] = KeyCode.Return;
				}
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.UKWyChlSKFEALcQOgrTwSPSbYXQ:
				P_1[result++] = KeyCode.Backspace;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.mvakdAWqAobdEhrpRBOhDmEKdLSW:
				P_1[result++] = KeyCode.Tab;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.avkcOhFlGGeHrNSdTQlLZUnJDbw:
				P_1[result++] = KeyCode.Clear;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.BNrhSQDgiADcHFNvcNeVSykjWJH:
				P_1[result++] = KeyCode.Pause;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.YhtYjWQCIaoKBjBnSpYsESGlpmn:
				P_1[result++] = KeyCode.Escape;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.blysWbZfaOREfoGKcgSdHjPWzRX:
				P_1[result++] = KeyCode.Space;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ZbQKrqSHDaHGKqUhHDcQCewWjKHR:
				P_1[result++] = KeyCode.Delete;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.pihzgzYIlFnQqTeCpFwuFSxYPMk:
				P_1[result++] = KeyCode.UpArrow;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.KyvYcVuHgpltaoATHEroKeMagqTG:
				P_1[result++] = KeyCode.DownArrow;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.XLOGWeajpyNWLLJcMbUYbrDrwJHU:
				P_1[result++] = KeyCode.RightArrow;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.DaydOJjrLXCRlLGchVnZVwxaMpIt:
				P_1[result++] = KeyCode.LeftArrow;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.dkfFgBTuTrvycnaStFbqkmvokTaz:
				P_1[result++] = KeyCode.Insert;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.bToaxGzQbERdcivKbIdAKRJmMPi:
				P_1[result++] = KeyCode.Home;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.KftupcwjUwqncnODGnJtuLiOjjP:
				P_1[result++] = KeyCode.End;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.zpudSPBqfqOeJiZABCbmILKbEMaC:
				P_1[result++] = KeyCode.PageUp;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.nAzaAPcyUdyGgsMmwVatSyMneruB:
				P_1[result++] = KeyCode.PageDown;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.CEtenFHXOqdfIfbNNKWyjLNlDzig:
				P_1[result++] = KeyCode.F1;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.FuPfwPCFlraPSxsaWcCXnbVBuBmu:
				P_1[result++] = KeyCode.F2;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.RxIzISEavlYjrQijkgPbVjaHwsw:
				P_1[result++] = KeyCode.F3;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.wWENFcVkMIFEUQuXEWMEwLcWDqj:
				P_1[result++] = KeyCode.F4;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.YJkYUJyqavgEtEbFAbFPiKqBmxRO:
				P_1[result++] = KeyCode.F5;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.KReOEgmhpsXcAYobhBrSRGDNGXRH:
				P_1[result++] = KeyCode.F6;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.benrdUdrJLeBmnKcNInabcIGAInZ:
				P_1[result++] = KeyCode.F7;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.fEiZAmeHAAlGHiiigFrYdNMnTHZ:
				P_1[result++] = KeyCode.F8;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.JKBpxuyDzsIYIgVcapXWdlkNjMZ:
				P_1[result++] = KeyCode.F9;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.FQnZSavyZIHwvVwVrmwBkxCDDvq:
				P_1[result++] = KeyCode.F10;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.KThXuAsNGEDOOivxyfLaADtDLwat:
				P_1[result++] = KeyCode.F11;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ofKFphdOiWXoPnDEzjnGClwvKeGL:
				P_1[result++] = KeyCode.F12;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.IbZPJSVMaZdNAaLBiaVFfIlCSwEg:
				P_1[result++] = KeyCode.F13;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.lYaACmgAueURuAxgeNnLOzLDdvqO:
				P_1[result++] = KeyCode.F14;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.WuGbjhKTwCvQSdVPfHiEUvHjlHc:
				P_1[result++] = KeyCode.F15;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.KLgZDqLbHKmJXEUHEOVoIXmUWCG:
				P_1[result++] = KeyCode.Numlock;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.fYMTCeQmkluCYKXxfGRggftQTgU:
				P_1[result++] = KeyCode.CapsLock;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.mENhwaDHkWeOtjlJPUnyQjIxflLd:
				P_1[result++] = KeyCode.ScrollLock;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.phZdgBquAsbAIZgYAWxYnOudcqI:
				P_1[result++] = KeyCode.RightShift;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.lmCauqOpOYCiuxHhreCvQAbJSDu:
				P_1[result++] = KeyCode.LeftShift;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.nJpaxkfDNtmCkPHaPGloUELplsMs:
				P_1[result++] = KeyCode.RightControl;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.PzwSmUGAlVdnIpuEqGbVDffZyCd:
				P_1[result++] = KeyCode.LeftControl;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.SrqCOnEqgVkkgIbzEZotNZDAEISM:
				P_1[result++] = KeyCode.AltGr;
				P_1[result++] = KeyCode.RightAlt;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.hHqGnearMZbgYucUOiVlynauVkbA:
				P_1[result++] = KeyCode.LeftAlt;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.OeLCcjKyYjTykZTBbEphwaJXcBl:
				P_1[result++] = KeyCode.RightCommand;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.gMMetakXjwuiOVKMQDxNmfPebsx:
				P_1[result++] = KeyCode.LeftCommand;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.cvdMMuvqXPfqshWfGggMbWqEKUBi:
				P_1[result++] = KeyCode.Help;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.uLGrmhwGUPFktSjEsnLIKhuDLXi:
				P_1[result++] = KeyCode.Print;
				break;
			case kGzKERAiEUkXQAhDKgJaitseOtM.ISJqnFrIQAflgfNYfDKKbnFcOeos:
				P_1[result++] = KeyCode.Menu;
				break;
			}
		}
		return result;
	}

	private unsafe static YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD JRMWoRCKevwGjthehCHbvcSogAG()
	{
		IntPtr intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.UixsgzhgsjPRAyUunbkEXLVdwvG(0);
		if (intPtr == IzAGxDDzWaMNyBdMVcWELkrOMQx)
		{
			return QNRjewXOOeQpCDGqnVjOnSCVFVk;
		}
		YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD nURGBCUamAWLTASRDDLecYPNAbD = YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD.mwnNCUqkkmpNkLjfFYluwUYSXes;
		byte* ptr = stackalloc byte[128];
		AewjMoBLyBolnnNMhBXWHRooNZC.bJZuPkeKQPqpMlOaCqAZokjbIlj((IntPtr)ptr);
		string s = Marshal.PtrToStringUni((IntPtr)ptr);
		if (int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			int num = ArrayTools.IndexOf(ZdpQlwbvFlOgWaYDMlNEZywhPLE, result);
			if (num >= 0)
			{
				nURGBCUamAWLTASRDDLecYPNAbD = (YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD)ZdpQlwbvFlOgWaYDMlNEZywhPLE[num];
			}
		}
		IzAGxDDzWaMNyBdMVcWELkrOMQx = intPtr;
		QNRjewXOOeQpCDGqnVjOnSCVFVk = nURGBCUamAWLTASRDDLecYPNAbD;
		return nURGBCUamAWLTASRDDLecYPNAbD;
	}

	private static bool kaKbCQulvzFxHersEZstRdJjTKUV(kGzKERAiEUkXQAhDKgJaitseOtM P_0, YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!llxXyJgcIYzfwnKmRVFxYgneCXA.TryGetValue((int)P_1, out var value))
		{
			value = llxXyJgcIYzfwnKmRVFxYgneCXA[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != YZuduhHYdujZNQijkwygrqXwCpon.nURGBCUamAWLTASRDDLecYPNAbD.mwnNCUqkkmpNkLjfFYluwUYSXes)
		{
			value = llxXyJgcIYzfwnKmRVFxYgneCXA[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool ewcvHlOwkSUgfpOexgIYIAEEGncR(kGzKERAiEUkXQAhDKgJaitseOtM P_0)
	{
		return ArrayTools.Contains(VnzFwduqbPhbJXyAzOGdwHUmEAaJ, (int)P_0);
	}
}
