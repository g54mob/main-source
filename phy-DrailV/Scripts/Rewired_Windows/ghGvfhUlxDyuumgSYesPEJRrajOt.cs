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

internal class ghGvfhUlxDyuumgSYesPEJRrajOt : IDisposable, IUnifiedKeyboardSource, IGetSetEnabled
{
	private class BvHoZtTaPSfYiHrVtXmTfEhOPztGb
	{
		private enum axygyLDncTQYhPHnYCMqZMGxkfwZ
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int tAeJiyMIWNTlwtydQsQIIpxCkfsl = 2;

		private static readonly KeyCode[] WHzTpKOGPdYTeZiMzsCNxaCoCsNHA = new KeyCode[2];

		private readonly UpdateLoopType WHDTzYTojOwKfxiTarplhaTxVeNq;

		private bool[] DCFbyeGxqUTufdkZORKtNQLxKBGq;

		private bool[] aYVkrIVhdfurCscNoBRfJsHkmUEfA;

		private uint FHtaTkgagqxJcJyGzijxbNhExnIpA;

		public BvHoZtTaPSfYiHrVtXmTfEhOPztGb(UpdateLoopType P_0)
		{
			WHDTzYTojOwKfxiTarplhaTxVeNq = P_0;
			DCFbyeGxqUTufdkZORKtNQLxKBGq = new bool[132];
			aYVkrIVhdfurCscNoBRfJsHkmUEfA = new bool[132];
		}

		public void fjTIBpBcqDOXCISmvKbNXSkjvvux(zckLuWBdGiBGhVRmcpdrNJqUWocC P_0)
		{
			int num = sqMhxQiYoNjhymeIaQoeMOmZhCUg(P_0, WHzTpKOGPdYTeZiMzsCNxaCoCsNHA);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)WHzTpKOGPdYTeZiMzsCNxaCoCsNHA[i];
				if (num2 >= 0 && num2 < fxpkREHLyAscNHzJGFabUeWjfGzv.Length)
				{
					KeyState pSXmUcWexXbxODmXGsTWpIwAjFVi = P_0.PSXmUcWexXbxODmXGsTWpIwAjFVi;
					bool flag = ((pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.KeyFirst || pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.SystemKeyDown) ? true : false);
					int num3 = fxpkREHLyAscNHzJGFabUeWjfGzv[num2];
					bool num4 = DCFbyeGxqUTufdkZORKtNQLxKBGq[num3];
					DCFbyeGxqUTufdkZORKtNQLxKBGq[num3] = flag;
					if (!num4 && flag)
					{
						aYVkrIVhdfurCscNoBRfJsHkmUEfA[num3] = true;
					}
				}
			}
		}

		public void cgXdoDGasbxLMLtXKouQWlVBfjiA(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = DCFbyeGxqUTufdkZORKtNQLxKBGq[i] || aYVkrIVhdfurCscNoBRfJsHkmUEfA[i];
			}
			VBnPpPXWVpHXfYPMcmPqvsaonuJM();
		}

		public void MqQjLCryqEPDlgJVxyKAVvUubRHs()
		{
			VBnPpPXWVpHXfYPMcmPqvsaonuJM();
		}

		private void VBnPpPXWVpHXfYPMcmPqvsaonuJM()
		{
			if (FHtaTkgagqxJcJyGzijxbNhExnIpA != ReInput.absFrame)
			{
				lYFvtKVZfnJpSZNkIaHaGdkxaOxu();
				FHtaTkgagqxJcJyGzijxbNhExnIpA = ReInput.absFrame;
			}
		}

		public void lYFvtKVZfnJpSZNkIaHaGdkxaOxu()
		{
			Array.Clear(aYVkrIVhdfurCscNoBRfJsHkmUEfA, 0, 132);
		}

		public void wSuERjejnukorMpeyvWlfiOlJujf()
		{
			Array.Clear(DCFbyeGxqUTufdkZORKtNQLxKBGq, 0, 132);
			Array.Clear(aYVkrIVhdfurCscNoBRfJsHkmUEfA, 0, 132);
		}
	}

	private const int VUPdXNBtnPJFqFFpgcmDvnMIQtZLB = 132;

	private const int JLiJboksTUCEFpFCSEmNGAhWeblV = 256;

	private readonly object eTRoskBdTVJraCzYFXNyrUomeHqE = new object();

	private UpdateLoopDataSet<BvHoZtTaPSfYiHrVtXmTfEhOPztGb> YqtgmrqbQPIkQJUFMKiGJqhGNslH;

	private HardwareControllerMap_Game OqezqauiJzHPibkVlZIqPxfahHmv;

	private bool xhJKgJuhFOPEpnVzWdMTBCnMpdeW;

	private int FDcKeYvozAzYhkOGWOarmETRVtnR;

	private bool[] wkDQfLpeNSnOAkUWIRGDvHrJgKMY = new bool[256];

	private readonly zckLuWBdGiBGhVRmcpdrNJqUWocC mTuYfwlLruFlTkMJNsTzOwGsLXig = new zckLuWBdGiBGhVRmcpdrNJqUWocC();

	private bool vOCRKtJjUKmNQpDZwbafkshoGskD;

	private static readonly int[] fxpkREHLyAscNHzJGFabUeWjfGzv;

	private static readonly int bKCCCVuRhTCLnAeChhHHlAOoYrLn;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	private static IntPtr fRvIAxGUrKzsAUbdhEbqvAebCXdJ;

	private static xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG tDqZCGWWIEMriSJqJvEoPhPeXjqL;

	private static readonly int[] csMdxWCsBJIzyIbguGzaSnxGbTGab;

	private static Dictionary<int, Dictionary<int, KeyCode>> QgYlwhnwcgsYQwFhhlRTgPwDuWQn;

	private static readonly int[] aDSVXJzlylIzXKzLJYVPAJoXEilB;

	public bool enabled
	{
		get
		{
			return vOCRKtJjUKmNQpDZwbafkshoGskD;
		}
		set
		{
			if (vOCRKtJjUKmNQpDZwbafkshoGskD != value)
			{
				vOCRKtJjUKmNQpDZwbafkshoGskD = value;
			}
		}
	}

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (OqezqauiJzHPibkVlZIqPxfahHmv == null)
			{
				OqezqauiJzHPibkVlZIqPxfahHmv = GURSYgsQJIKQUSvFwlKtfbGzZQCQ();
			}
			return OqezqauiJzHPibkVlZIqPxfahHmv;
		}
	}

	public int buttonCount => 132;

	public Controller.Extension controllerExtension => null;

	static ghGvfhUlxDyuumgSYesPEJRrajOt()
	{
		tDqZCGWWIEMriSJqJvEoPhPeXjqL = xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG.United_States_English;
		csMdxWCsBJIzyIbguGzaSnxGbTGab = (int[])Enum.GetValues(typeof(xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG));
		QgYlwhnwcgsYQwFhhlRTgPwDuWQn = new Dictionary<int, Dictionary<int, KeyCode>>
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
		aDSVXJzlylIzXKzLJYVPAJoXEilB = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > bKCCCVuRhTCLnAeChhHHlAOoYrLn)
			{
				bKCCCVuRhTCLnAeChhHHlAOoYrLn = keyboardKeyValues[i];
			}
		}
		fxpkREHLyAscNHzJGFabUeWjfGzv = new int[bKCCCVuRhTCLnAeChhHHlAOoYrLn + 1];
		ArrayTools.Fill(fxpkREHLyAscNHzJGFabUeWjfGzv, -1);
		for (int j = 0; j < num; j++)
		{
			fxpkREHLyAscNHzJGFabUeWjfGzv[keyboardKeyValues[j]] = j;
		}
	}

	public ghGvfhUlxDyuumgSYesPEJRrajOt(UpdateLoopSetting P_0)
	{
		mnYfrHaUogrZZmJYPsfXwOIpMTayA();
		YqtgmrqbQPIkQJUFMKiGJqhGNslH = new UpdateLoopDataSet<BvHoZtTaPSfYiHrVtXmTfEhOPztGb>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i] = new BvHoZtTaPSfYiHrVtXmTfEhOPztGb(list[i]);
			}
		}
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Keyboard);
		enabled = true;
		ReInput.ApplicationFocusChangedEvent += orUMILCIqROwyBKfAAnTVqdZfYkj;
		ReInput.ApplicationPauseChangedEvent += TNcWPrbERDuIJOeRurmdoMrAbUeN;
		ReInput.EditorPauseChangedEvent += fVsAsvbqlzfDdjOSAWqIHuaIUAvyB;
		ReInput.UpdateEndedEvent += WAOrbusfizshnpxwFmgJjjqHioOJ;
		ReInput.TimeScalePauseChangedEvent += HbahpfcvOpPnYxZFkJkAOBvbitdv;
	}

	public unsafe void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		YqtgmrqbQPIkQJUFMKiGJqhGNslH.SetUpdateLoop(P_0);
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!VBqfSSvUBwCRtzUpeUWIfCWGfXliA.SkblAsrxBwDeSByXliNHvHWujmuD((IntPtr)ptr))
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
						if (wkDQfLpeNSnOAkUWIRGDvHrJgKMY[i])
						{
							mTuYfwlLruFlTkMJNsTzOwGsLXig.WCFFzsHtLWMKfhauyUvHRdaBsqRcA();
							mTuYfwlLruFlTkMJNsTzOwGsLXig.YxFdZozJytryXOxcRaQAmySLFHVc = ReInput.realTime;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.ayUvCXyCfGuQLrCsZWEOwszCfnBD = IntPtr.Zero;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.fDpaljVWGPHyPchjXRieXeSuCFVm = (Keys)i;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.ZzGFFmDQKczUmCFmGJuHassDRjQeA = 0;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.EVjCMfEXhQhiAIWbuwuqtUbKdMJb = ScanCodeFlags.Break;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.PSXmUcWexXbxODmXGsTWpIwAjFVi = KeyState.KeyUp;
							mTuYfwlLruFlTkMJNsTzOwGsLXig.NWNNppyDrpeJuiYvjWaiHikJvfXOA = 0;
							YtPyBCQxqyYSzFiSvpFtthKByQre(mTuYfwlLruFlTkMJNsTzOwGsLXig);
						}
					}
					else if (!wkDQfLpeNSnOAkUWIRGDvHrJgKMY[i])
					{
						mTuYfwlLruFlTkMJNsTzOwGsLXig.WCFFzsHtLWMKfhauyUvHRdaBsqRcA();
						mTuYfwlLruFlTkMJNsTzOwGsLXig.YxFdZozJytryXOxcRaQAmySLFHVc = ReInput.realTime;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.ayUvCXyCfGuQLrCsZWEOwszCfnBD = IntPtr.Zero;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.fDpaljVWGPHyPchjXRieXeSuCFVm = (Keys)i;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.ZzGFFmDQKczUmCFmGJuHassDRjQeA = 0;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.EVjCMfEXhQhiAIWbuwuqtUbKdMJb = ScanCodeFlags.Make;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.PSXmUcWexXbxODmXGsTWpIwAjFVi = KeyState.KeyFirst;
						mTuYfwlLruFlTkMJNsTzOwGsLXig.NWNNppyDrpeJuiYvjWaiHikJvfXOA = 0;
						YtPyBCQxqyYSzFiSvpFtthKByQre(mTuYfwlLruFlTkMJNsTzOwGsLXig);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void YtPyBCQxqyYSzFiSvpFtthKByQre(zckLuWBdGiBGhVRmcpdrNJqUWocC P_0)
	{
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			return;
		}
		switch (P_0.fDpaljVWGPHyPchjXRieXeSuCFVm)
		{
		case Keys.ControlKey:
		{
			Keys keys = (Keys)VBqfSSvUBwCRtzUpeUWIfCWGfXliA.fdIISZyRZanLcJNfadxNTOghTQG((uint)P_0.ZzGFFmDQKczUmCFmGJuHassDRjQeA, xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.MWMQhJXhEjyyCetqBSUDqAhnISQd);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = (((P_0.EVjCMfEXhQhiAIWbuwuqtUbKdMJb & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = (((P_0.EVjCMfEXhQhiAIWbuwuqtUbKdMJb & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		case Keys.ShiftKey:
		{
			P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = (Keys)VBqfSSvUBwCRtzUpeUWIfCWGfXliA.fdIISZyRZanLcJNfadxNTOghTQG((uint)P_0.ZzGFFmDQKczUmCFmGJuHassDRjQeA, xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.MWMQhJXhEjyyCetqBSUDqAhnISQd);
			if (P_0.fDpaljVWGPHyPchjXRieXeSuCFVm == Keys.LShiftKey || P_0.fDpaljVWGPHyPchjXRieXeSuCFVm == Keys.RShiftKey)
			{
				break;
			}
			KeyState pSXmUcWexXbxODmXGsTWpIwAjFVi = P_0.PSXmUcWexXbxODmXGsTWpIwAjFVi;
			bool flag = ((pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.KeyFirst || pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.SystemKeyDown || pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.KeyLast) ? true : false);
			bool flag2 = (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.UIivVgcbNLNfYsBwTcPVUaDQAgYx(160) & 0x8000) != 0;
			bool flag3 = (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.UIivVgcbNLNfYsBwTcPVUaDQAgYx(161) & 0x8000) != 0;
			if (flag)
			{
				bool num = (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.lqQytorDxVcgNsDpjcnZIpkQJjNGb(160) & 0x8000) != 0;
				bool flag4 = (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.lqQytorDxVcgNsDpjcnZIpkQJjNGb(161) & 0x8000) != 0;
				if (num)
				{
					P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.LShiftKey;
					YtPyBCQxqyYSzFiSvpFtthKByQre(P_0);
				}
				if (flag4)
				{
					P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.RShiftKey;
					YtPyBCQxqyYSzFiSvpFtthKByQre(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.LShiftKey;
				break;
			}
			if (flag3)
			{
				P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.RShiftKey;
				break;
			}
			P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.LShiftKey;
			YtPyBCQxqyYSzFiSvpFtthKByQre(P_0);
			P_0.fDpaljVWGPHyPchjXRieXeSuCFVm = Keys.RShiftKey;
			YtPyBCQxqyYSzFiSvpFtthKByQre(P_0);
			return;
		}
		}
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			KeyState pSXmUcWexXbxODmXGsTWpIwAjFVi = P_0.PSXmUcWexXbxODmXGsTWpIwAjFVi;
			if (pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.KeyFirst || pSXmUcWexXbxODmXGsTWpIwAjFVi == KeyState.SystemKeyDown)
			{
				wkDQfLpeNSnOAkUWIRGDvHrJgKMY[(int)P_0.fDpaljVWGPHyPchjXRieXeSuCFVm] = true;
			}
			else
			{
				wkDQfLpeNSnOAkUWIRGDvHrJgKMY[(int)P_0.fDpaljVWGPHyPchjXRieXeSuCFVm] = false;
			}
			int count = YqtgmrqbQPIkQJUFMKiGJqhGNslH.Count;
			for (int i = 0; i < count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i].fjTIBpBcqDOXCISmvKbNXSkjvvux(P_0);
			}
		}
	}

	public void FxUZVZTmsPHdAmjAncfrdhvpHgkkA(bool P_0)
	{
		bDiBsKvwpyintgnDBvTnbKLwNaxd();
	}

	public void uSpAIgmdvPVFmEjMufooqHERiqRV(bool P_0)
	{
		if (mnYfrHaUogrZZmJYPsfXwOIpMTayA() < 0)
		{
			bDiBsKvwpyintgnDBvTnbKLwNaxd();
		}
	}

	private int mnYfrHaUogrZZmJYPsfXwOIpMTayA()
	{
		int fDcKeYvozAzYhkOGWOarmETRVtnR = FDcKeYvozAzYhkOGWOarmETRVtnR;
		if (BJkeDTpvKMtUyGqqYbRkHpVmhHYR.QbqauytRUvOCdsOckcSnCvrVAGyuA(jssTDwsNFlmgwNaDqygUqSPLaLlh.Keyboard, out var fDcKeYvozAzYhkOGWOarmETRVtnR2))
		{
			FDcKeYvozAzYhkOGWOarmETRVtnR = fDcKeYvozAzYhkOGWOarmETRVtnR2;
		}
		else
		{
			FDcKeYvozAzYhkOGWOarmETRVtnR = 1;
		}
		return FDcKeYvozAzYhkOGWOarmETRVtnR - fDcKeYvozAzYhkOGWOarmETRVtnR;
	}

	private void orUMILCIqROwyBKfAAnTVqdZfYkj(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			bDiBsKvwpyintgnDBvTnbKLwNaxd();
		}
	}

	private void TNcWPrbERDuIJOeRurmdoMrAbUeN(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			bDiBsKvwpyintgnDBvTnbKLwNaxd();
		}
	}

	private void fVsAsvbqlzfDdjOSAWqIHuaIUAvyB(bool P_0)
	{
	}

	private void HbahpfcvOpPnYxZFkJkAOBvbitdv(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			YqtgmrqbQPIkQJUFMKiGJqhGNslH[YqtgmrqbQPIkQJUFMKiGJqhGNslH.fixedUpdateSetIndex].lYFvtKVZfnJpSZNkIaHaGdkxaOxu();
		}
	}

	private void WAOrbusfizshnpxwFmgJjjqHioOJ(UpdateLoopType P_0)
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			YqtgmrqbQPIkQJUFMKiGJqhGNslH.Get(P_0).MqQjLCryqEPDlgJVxyKAVvUubRHs();
		}
	}

	private void bDiBsKvwpyintgnDBvTnbKLwNaxd()
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			int count = YqtgmrqbQPIkQJUFMKiGJqhGNslH.Count;
			for (int i = 0; i < count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i].wSuERjejnukorMpeyvWlfiOlJujf();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		YqtgmrqbQPIkQJUFMKiGJqhGNslH.Current.cgXdoDGasbxLMLtXKouQWlVBfjiA(dataUpdater);
	}

	public void Clear()
	{
		bDiBsKvwpyintgnDBvTnbKLwNaxd();
	}

	private static HardwareControllerMap_Game GURSYgsQJIKQUSvFwlKtfbGzZQCQ()
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
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			ReInput.ApplicationFocusChangedEvent -= orUMILCIqROwyBKfAAnTVqdZfYkj;
			ReInput.ApplicationPauseChangedEvent -= TNcWPrbERDuIJOeRurmdoMrAbUeN;
			ReInput.EditorPauseChangedEvent -= fVsAsvbqlzfDdjOSAWqIHuaIUAvyB;
			ReInput.UpdateEndedEvent -= WAOrbusfizshnpxwFmgJjjqHioOJ;
			ReInput.TimeScalePauseChangedEvent -= HbahpfcvOpPnYxZFkJkAOBvbitdv;
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	public static int sqMhxQiYoNjhymeIaQoeMOmZhCUg(zckLuWBdGiBGhVRmcpdrNJqUWocC P_0, KeyCode[] P_1)
	{
		Keys fDpaljVWGPHyPchjXRieXeSuCFVm = P_0.fDpaljVWGPHyPchjXRieXeSuCFVm;
		int result = 0;
		xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG ipchvFcQcvArQQdbXZAgXeqbfjuG = eztgtWXpETnDZoaKHfYJZQfDceEjA();
		_ = fRvIAxGUrKzsAUbdhEbqvAebCXdJ;
		VBqfSSvUBwCRtzUpeUWIfCWGfXliA.fdIISZyRZanLcJNfadxNTOghTQG((uint)P_0.fDpaljVWGPHyPchjXRieXeSuCFVm, xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ZkYyLWXnoHifLzvsVUoZdeGoAYUdA);
		if (TyXosRPvwsVJPwiXLOMwwKFjjPeJ(fDpaljVWGPHyPchjXRieXeSuCFVm))
		{
			if (JvlExoCzzLvOfBiZeMoZRJWSYASDA(fDpaljVWGPHyPchjXRieXeSuCFVm, ipchvFcQcvArQQdbXZAgXeqbfjuG, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (fDpaljVWGPHyPchjXRieXeSuCFVm)
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
				if ((P_0.EVjCMfEXhQhiAIWbuwuqtUbKdMJb & ScanCodeFlags.E0) != ScanCodeFlags.Make)
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
				P_1[result++] = KeyCode.RightCommand;
				break;
			case Keys.LWin:
				P_1[result++] = KeyCode.LeftCommand;
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

	private unsafe static xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG eztgtWXpETnDZoaKHfYJZQfDceEjA()
	{
		IntPtr intPtr = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.jKQHHVuTcRaegrhHBdggbmEQchAFA(0);
		if (intPtr == fRvIAxGUrKzsAUbdhEbqvAebCXdJ)
		{
			return tDqZCGWWIEMriSJqJvEoPhPeXjqL;
		}
		xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG result = xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG.United_States_English;
		byte* intPtr2 = stackalloc byte[128];
		VBqfSSvUBwCRtzUpeUWIfCWGfXliA.YkweqOvVOdEWsmDRmSdfAOaGdppj((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
		{
			int num = ArrayTools.IndexOf(csMdxWCsBJIzyIbguGzaSnxGbTGab, result2);
			if (num >= 0)
			{
				result = (xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG)csMdxWCsBJIzyIbguGzaSnxGbTGab[num];
			}
		}
		fRvIAxGUrKzsAUbdhEbqvAebCXdJ = intPtr;
		tDqZCGWWIEMriSJqJvEoPhPeXjqL = result;
		return result;
	}

	private static bool JvlExoCzzLvOfBiZeMoZRJWSYASDA(Keys P_0, xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!QgYlwhnwcgsYQwFhhlRTgPwDuWQn.TryGetValue((int)P_1, out var value))
		{
			value = QgYlwhnwcgsYQwFhhlRTgPwDuWQn[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.ipchvFcQcvArQQdbXZAgXeqbfjuG.United_States_English)
		{
			value = QgYlwhnwcgsYQwFhhlRTgPwDuWQn[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool TyXosRPvwsVJPwiXLOMwwKFjjPeJ(Keys P_0)
	{
		return ArrayTools.Contains(aDSVXJzlylIzXKzLJYVPAJoXEilB, (int)P_0);
	}
}
