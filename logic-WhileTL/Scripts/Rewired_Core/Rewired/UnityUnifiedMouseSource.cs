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
		private class qbYYvgdvNywLkOHcvSdhjCnEbxFZ
		{
			private float[] VOdcCxGpnuflkFUltgtmdTSOLsszA;

			private bool[] fMmsOPeSTxakcjrZNcSDeNzkYtrAA;

			public qbYYvgdvNywLkOHcvSdhjCnEbxFZ(int P_0, int P_1)
			{
				fMmsOPeSTxakcjrZNcSDeNzkYtrAA = new bool[P_0];
				VOdcCxGpnuflkFUltgtmdTSOLsszA = new float[P_1];
			}

			public void bRcBGZsEAHPATdseEayuTKIegMdx(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, fMmsOPeSTxakcjrZNcSDeNzkYtrAA, P_0.Length);
				for (int i = 0; i < VOdcCxGpnuflkFUltgtmdTSOLsszA.Length; i++)
				{
					VOdcCxGpnuflkFUltgtmdTSOLsszA[i] += P_1[i];
				}
			}

			public void tJxRcImkKqvmMRbSpjmbXPMuSelH(ControllerDataUpdater P_0)
			{
				Array.Copy(VOdcCxGpnuflkFUltgtmdTSOLsszA, P_0.axisValues, VOdcCxGpnuflkFUltgtmdTSOLsszA.Length);
				Array.Copy(fMmsOPeSTxakcjrZNcSDeNzkYtrAA, P_0.buttonValues, fMmsOPeSTxakcjrZNcSDeNzkYtrAA.Length);
			}

			public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
				Array.Clear(VOdcCxGpnuflkFUltgtmdTSOLsszA, 0, VOdcCxGpnuflkFUltgtmdTSOLsszA.Length);
				Array.Clear(fMmsOPeSTxakcjrZNcSDeNzkYtrAA, 0, fMmsOPeSTxakcjrZNcSDeNzkYtrAA.Length);
			}

			public void CuKbNfFFbvNNOElOidzNqiYASKahA()
			{
				Array.Clear(VOdcCxGpnuflkFUltgtmdTSOLsszA, 0, VOdcCxGpnuflkFUltgtmdTSOLsszA.Length);
			}
		}

		[Serializable]
		private sealed class gAhKWwurVZsgbnNqkTKvKlHkByOS
		{
			public static readonly gAhKWwurVZsgbnNqkTKvKlHkByOS _003C_003E9 = new gAhKWwurVZsgbnNqkTKvKlHkByOS();

			public static Func<qbYYvgdvNywLkOHcvSdhjCnEbxFZ> _003C_003E9__20_0;

			internal qbYYvgdvNywLkOHcvSdhjCnEbxFZ VmbfQsPLyFGZnvWIapEPANmyjTLv()
			{
				return new qbYYvgdvNywLkOHcvSdhjCnEbxFZ(7, 4);
			}
		}

		private static HardwareControllerMap_Game MWUXdFVnrMGjoJuplFCUaTFIzejiB;

		private UpdateLoopDataSet<qbYYvgdvNywLkOHcvSdhjCnEbxFZ> GesyYeBpGYjhiPhqJvunCCEmAIOj;

		private float[] VOdcCxGpnuflkFUltgtmdTSOLsszA;

		private bool[] fMmsOPeSTxakcjrZNcSDeNzkYtrAA;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool enabled
		{
			get
			{
				return llkLFSoLVtaASCstwdnHCsIDxnhYb;
			}
			set
			{
				if (llkLFSoLVtaASCstwdnHCsIDxnhYb != value)
				{
					llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
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
				if (MWUXdFVnrMGjoJuplFCUaTFIzejiB == null)
				{
					MWUXdFVnrMGjoJuplFCUaTFIzejiB = UbrfMNNvrvFcOBozobIHidyuqtTEb();
				}
				return MWUXdFVnrMGjoJuplFCUaTFIzejiB;
			}
		}

		public int buttonCount => 7;

		public int axisCount => 4;

		public Vector2 mousePosition
		{
			get
			{
				if (!llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			GesyYeBpGYjhiPhqJvunCCEmAIOj = new UpdateLoopDataSet<qbYYvgdvNywLkOHcvSdhjCnEbxFZ>(ReInput.configVars.updateLoop, gAhKWwurVZsgbnNqkTKvKlHkByOS._003C_003E9.VmbfQsPLyFGZnvWIapEPANmyjTLv);
			VOdcCxGpnuflkFUltgtmdTSOLsszA = new float[4];
			fMmsOPeSTxakcjrZNcSDeNzkYtrAA = new bool[7];
			enabled = true;
			ReInput.UpdateEndedEvent += ANWWxmBLjBmUkWbQltRWrtgDpXUA;
			ReInput.EarlyUpdateEvent += ABemZVTTHZtsBAXUqzbHwVVruOdh;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			GesyYeBpGYjhiPhqJvunCCEmAIOj.Get(ReInput.currentUpdateLoop).tJxRcImkKqvmMRbSpjmbXPMuSelH(dataUpdater);
		}

		public void Clear()
		{
			int count = GesyYeBpGYjhiPhqJvunCCEmAIOj.Count;
			for (int i = 0; i < count; i++)
			{
				GesyYeBpGYjhiPhqJvunCCEmAIOj.Get(i).HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			}
		}

		private void ABemZVTTHZtsBAXUqzbHwVVruOdh()
		{
			if (llkLFSoLVtaASCstwdnHCsIDxnhYb)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(VOdcCxGpnuflkFUltgtmdTSOLsszA);
				ThreadSafeUnityInput.mouse.GetButtonValues(fMmsOPeSTxakcjrZNcSDeNzkYtrAA);
				int count = GesyYeBpGYjhiPhqJvunCCEmAIOj.Count;
				for (int i = 0; i < count; i++)
				{
					GesyYeBpGYjhiPhqJvunCCEmAIOj.Get(i).bRcBGZsEAHPATdseEayuTKIegMdx(fMmsOPeSTxakcjrZNcSDeNzkYtrAA, VOdcCxGpnuflkFUltgtmdTSOLsszA);
				}
			}
		}

		private void ANWWxmBLjBmUkWbQltRWrtgDpXUA(UpdateLoopType P_0)
		{
			GesyYeBpGYjhiPhqJvunCCEmAIOj.Get(P_0).CuKbNfFFbvNNOElOidzNqiYASKahA();
		}

		private static HardwareControllerMap_Game UbrfMNNvrvFcOBozobIHidyuqtTEb()
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
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return;
			}
			if (disposing)
			{
				if (llkLFSoLVtaASCstwdnHCsIDxnhYb)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= ANWWxmBLjBmUkWbQltRWrtgDpXUA;
				ReInput.EarlyUpdateEvent -= ABemZVTTHZtsBAXUqzbHwVVruOdh;
			}
			JChPmMbeaoLOGQvosPYqDDInSiCs = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (MWUXdFVnrMGjoJuplFCUaTFIzejiB == null)
			{
				MWUXdFVnrMGjoJuplFCUaTFIzejiB = UbrfMNNvrvFcOBozobIHidyuqtTEb();
			}
			return MWUXdFVnrMGjoJuplFCUaTFIzejiB.GetElementType(elementIdentifierId);
		}
	}
}
