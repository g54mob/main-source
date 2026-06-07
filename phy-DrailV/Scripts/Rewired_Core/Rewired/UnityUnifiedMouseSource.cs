using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedMouseSource : IDisposable, IGetSetEnabled, IUnifiedMouseSource
	{
		private class VRMyVtTsjegJCbRUAHOLaFARhrPi
		{
			private float[] iyvePiDsBkaQEukPGjVOgSrcFsyCB;

			private bool[] KPyRASCadfDvEEQtaqmfYfKlhabJ;

			public VRMyVtTsjegJCbRUAHOLaFARhrPi(int P_0, int P_1)
			{
				KPyRASCadfDvEEQtaqmfYfKlhabJ = new bool[P_0];
				iyvePiDsBkaQEukPGjVOgSrcFsyCB = new float[P_1];
			}

			public void OAwgFIAsoRFxpGYMneIGEGffpGbEA(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, KPyRASCadfDvEEQtaqmfYfKlhabJ, P_0.Length);
				for (int i = 0; i < iyvePiDsBkaQEukPGjVOgSrcFsyCB.Length; i++)
				{
					iyvePiDsBkaQEukPGjVOgSrcFsyCB[i] += P_1[i];
				}
			}

			public void StrlGTGUqyFUikpaIXJTWKtbCIvw(ControllerDataUpdater P_0)
			{
				Array.Copy(iyvePiDsBkaQEukPGjVOgSrcFsyCB, P_0.axisValues, iyvePiDsBkaQEukPGjVOgSrcFsyCB.Length);
				Array.Copy(KPyRASCadfDvEEQtaqmfYfKlhabJ, P_0.buttonValues, KPyRASCadfDvEEQtaqmfYfKlhabJ.Length);
			}

			public void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				Array.Clear(iyvePiDsBkaQEukPGjVOgSrcFsyCB, 0, iyvePiDsBkaQEukPGjVOgSrcFsyCB.Length);
				Array.Clear(KPyRASCadfDvEEQtaqmfYfKlhabJ, 0, KPyRASCadfDvEEQtaqmfYfKlhabJ.Length);
			}

			public void lKOMSsnXRzsvwAjmFFrvxczZMcgK()
			{
				Array.Clear(iyvePiDsBkaQEukPGjVOgSrcFsyCB, 0, iyvePiDsBkaQEukPGjVOgSrcFsyCB.Length);
			}
		}

		[Serializable]
		private sealed class TrzDdbKnuLLfZQWXZsZaTuydwCIb
		{
			public static readonly TrzDdbKnuLLfZQWXZsZaTuydwCIb _003C_003E9 = new TrzDdbKnuLLfZQWXZsZaTuydwCIb();

			public static Func<VRMyVtTsjegJCbRUAHOLaFARhrPi> _003C_003E9__20_0;

			internal VRMyVtTsjegJCbRUAHOLaFARhrPi yCjVfoxUGFmRTKsRLwfmVHWpHFNb()
			{
				return new VRMyVtTsjegJCbRUAHOLaFARhrPi(7, 4);
			}
		}

		private static HardwareControllerMap_Game tZIuQAjrHYWwCXVWSchyGqJusgzf;

		private UpdateLoopDataSet<VRMyVtTsjegJCbRUAHOLaFARhrPi> pAccjjftkSoAMvoMwnZTEXrzHEChb;

		private float[] iyvePiDsBkaQEukPGjVOgSrcFsyCB;

		private bool[] KPyRASCadfDvEEQtaqmfYfKlhabJ;

		private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public bool enabled
		{
			get
			{
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				if (KByWFLCBjjvqwXYVZFDfzPdklyjf != value)
				{
					KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
					Clear();
					ThreadSafeUnityInput.mouse.Monitor(value);
				}
			}
		}

		public InputSource inputSource => InputSource.UnityKeyboardAndMouse;

		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (tZIuQAjrHYWwCXVWSchyGqJusgzf == null)
				{
					tZIuQAjrHYWwCXVWSchyGqJusgzf = CreateHardwareMap();
				}
				return tZIuQAjrHYWwCXVWSchyGqJusgzf;
			}
		}

		public int buttonCount => 7;

		public int axisCount => 4;

		public Vector2 mousePosition
		{
			get
			{
				if (!KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			pAccjjftkSoAMvoMwnZTEXrzHEChb = new UpdateLoopDataSet<VRMyVtTsjegJCbRUAHOLaFARhrPi>(ReInput.configVars.updateLoop, TrzDdbKnuLLfZQWXZsZaTuydwCIb._003C_003E9.yCjVfoxUGFmRTKsRLwfmVHWpHFNb);
			iyvePiDsBkaQEukPGjVOgSrcFsyCB = new float[4];
			KPyRASCadfDvEEQtaqmfYfKlhabJ = new bool[7];
			enabled = true;
			ReInput.UpdateEndedEvent += jkOkPoftrVhToppXfgJzhqWpCtFab;
			ReInput.EarlyUpdateEvent += hEoCjMnrFDCFtdEgRFQxrekiAovV;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			pAccjjftkSoAMvoMwnZTEXrzHEChb.Get(ReInput.currentUpdateLoop).StrlGTGUqyFUikpaIXJTWKtbCIvw(dataUpdater);
		}

		public void Clear()
		{
			int count = pAccjjftkSoAMvoMwnZTEXrzHEChb.Count;
			for (int i = 0; i < count; i++)
			{
				pAccjjftkSoAMvoMwnZTEXrzHEChb.Get(i).wJjPIIRJfHhEbGedUconecGfiwzgB();
			}
		}

		private void hEoCjMnrFDCFtdEgRFQxrekiAovV()
		{
			if (KByWFLCBjjvqwXYVZFDfzPdklyjf)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(iyvePiDsBkaQEukPGjVOgSrcFsyCB);
				ThreadSafeUnityInput.mouse.GetButtonValues(KPyRASCadfDvEEQtaqmfYfKlhabJ);
				int count = pAccjjftkSoAMvoMwnZTEXrzHEChb.Count;
				for (int i = 0; i < count; i++)
				{
					pAccjjftkSoAMvoMwnZTEXrzHEChb.Get(i).OAwgFIAsoRFxpGYMneIGEGffpGbEA(KPyRASCadfDvEEQtaqmfYfKlhabJ, iyvePiDsBkaQEukPGjVOgSrcFsyCB);
				}
			}
		}

		private void jkOkPoftrVhToppXfgJzhqWpCtFab(UpdateLoopType P_0)
		{
			pAccjjftkSoAMvoMwnZTEXrzHEChb.Get(P_0).lKOMSsnXRzsvwAjmFFrvxczZMcgK();
		}

		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[i]);
			}
			int[] array2 = new int[7];
			int[] array3 = new int[4];
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].elementType == ControllerElementType.Axis)
				{
					array3[num2++] = array[j].id;
				}
				else if (array[j].elementType == ControllerElementType.Button)
				{
					array2[num++] = array[j].id;
				}
			}
			AxisCalibrationData[] array4 = new AxisCalibrationData[4];
			AxisRange[] array5 = new AxisRange[4];
			HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
			HardwareButtonInfo[] array7 = new HardwareButtonInfo[7];
			for (int k = 0; k < 4; k++)
			{
				array4[k] = AxisCalibrationData.Raw;
				array5[k] = AxisRange.Full;
				float num3 = (((uint)k > 1u) ? 2f : 100f);
				array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
			}
			for (int l = 0; l < 7; l++)
			{
				array7[l] = new HardwareButtonInfo();
			}
			return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~UnityUnifiedMouseSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				return;
			}
			if (disposing)
			{
				if (KByWFLCBjjvqwXYVZFDfzPdklyjf)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= jkOkPoftrVhToppXfgJzhqWpCtFab;
				ReInput.EarlyUpdateEvent -= hEoCjMnrFDCFtdEgRFQxrekiAovV;
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (tZIuQAjrHYWwCXVWSchyGqJusgzf == null)
			{
				tZIuQAjrHYWwCXVWSchyGqJusgzf = CreateHardwareMap();
			}
			return tZIuQAjrHYWwCXVWSchyGqJusgzf.GetElementType(elementIdentifierId);
		}
	}
}
