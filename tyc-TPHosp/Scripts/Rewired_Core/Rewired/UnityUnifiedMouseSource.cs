using System;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedMouseSource : IDisposable, IUnifiedMouseSource
	{
		private class SlAwqyHtNHjLNuiARwnqRcOozwl
		{
			private float[] pXlAJrbenVlPNEpLFzibOvfeNwKG;

			private bool[] RpmBWBIHfQEmNXbspZOAzWyIpRD;

			public SlAwqyHtNHjLNuiARwnqRcOozwl(int buttonCount, int axisCount)
			{
				RpmBWBIHfQEmNXbspZOAzWyIpRD = new bool[buttonCount];
				pXlAJrbenVlPNEpLFzibOvfeNwKG = new float[axisCount];
			}

			public void NuoaXJgQQcAoeDNSCwnhTploCOXT(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, RpmBWBIHfQEmNXbspZOAzWyIpRD, P_0.Length);
				for (int i = 0; i < pXlAJrbenVlPNEpLFzibOvfeNwKG.Length; i++)
				{
					pXlAJrbenVlPNEpLFzibOvfeNwKG[i] += P_1[i];
				}
			}

			public void JYbpMAIkKJxNvdSwZlsujRfUtSZ(ControllerDataUpdater P_0)
			{
				Array.Copy(pXlAJrbenVlPNEpLFzibOvfeNwKG, P_0.axisValues, pXlAJrbenVlPNEpLFzibOvfeNwKG.Length);
				Array.Copy(RpmBWBIHfQEmNXbspZOAzWyIpRD, P_0.buttonValues, RpmBWBIHfQEmNXbspZOAzWyIpRD.Length);
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				Array.Clear(pXlAJrbenVlPNEpLFzibOvfeNwKG, 0, pXlAJrbenVlPNEpLFzibOvfeNwKG.Length);
				Array.Clear(RpmBWBIHfQEmNXbspZOAzWyIpRD, 0, RpmBWBIHfQEmNXbspZOAzWyIpRD.Length);
			}

			public void elYcMhbKzSeljZRwOauCUrvcISK()
			{
				Array.Clear(pXlAJrbenVlPNEpLFzibOvfeNwKG, 0, pXlAJrbenVlPNEpLFzibOvfeNwKG.Length);
			}
		}

		private static HardwareControllerMap_Game cEYeWTjdrdJnTGiDFBdZbfkXIqH;

		private UpdateLoopDataSet<SlAwqyHtNHjLNuiARwnqRcOozwl> kGuVfeffObwXFfTMvrqgyDrQrQy;

		private float[] pXlAJrbenVlPNEpLFzibOvfeNwKG;

		private bool[] RpmBWBIHfQEmNXbspZOAzWyIpRD;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		[CompilerGenerated]
		private static Func<SlAwqyHtNHjLNuiARwnqRcOozwl> ZCwIsrHovbcKJeKasXtvDGSZlUI;

		public InputSource inputSource => InputSource.UnityKeyboardAndMouse;

		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (cEYeWTjdrdJnTGiDFBdZbfkXIqH == null)
				{
					cEYeWTjdrdJnTGiDFBdZbfkXIqH = aKxbNHDftUXEhPzRIeHSCDPOrtfY();
				}
				return cEYeWTjdrdJnTGiDFBdZbfkXIqH;
			}
		}

		public int buttonCount => 7;

		public int axisCount => 4;

		public Vector2 mousePosition => ThreadSafeUnityInput.mouse.mousePosition;

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			ThreadSafeUnityInput.mouse.Monitor(state: true);
			kGuVfeffObwXFfTMvrqgyDrQrQy = new UpdateLoopDataSet<SlAwqyHtNHjLNuiARwnqRcOozwl>(ReInput.configVars.updateLoop, () => new SlAwqyHtNHjLNuiARwnqRcOozwl(7, 4));
			pXlAJrbenVlPNEpLFzibOvfeNwKG = new float[4];
			RpmBWBIHfQEmNXbspZOAzWyIpRD = new bool[7];
			ReInput.UpdateEndedEvent += oJEGHntPXeDMngoHmUuMXuUAYnf;
			ReInput.EarlyUpdateEvent += gkcUDzrPqIPuiToYGeMEGiRcoRf;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			kGuVfeffObwXFfTMvrqgyDrQrQy.Get(ReInput.currentUpdateLoop).JYbpMAIkKJxNvdSwZlsujRfUtSZ(dataUpdater);
		}

		public void Clear()
		{
			int count = kGuVfeffObwXFfTMvrqgyDrQrQy.Count;
			for (int i = 0; i < count; i++)
			{
				kGuVfeffObwXFfTMvrqgyDrQrQy.Get(i).dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
		}

		private void gkcUDzrPqIPuiToYGeMEGiRcoRf()
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(pXlAJrbenVlPNEpLFzibOvfeNwKG);
			ThreadSafeUnityInput.mouse.GetButtonValues(RpmBWBIHfQEmNXbspZOAzWyIpRD);
			int count = kGuVfeffObwXFfTMvrqgyDrQrQy.Count;
			for (int i = 0; i < count; i++)
			{
				kGuVfeffObwXFfTMvrqgyDrQrQy.Get(i).NuoaXJgQQcAoeDNSCwnhTploCOXT(RpmBWBIHfQEmNXbspZOAzWyIpRD, pXlAJrbenVlPNEpLFzibOvfeNwKG);
			}
		}

		private void oJEGHntPXeDMngoHmUuMXuUAYnf(UpdateLoopType P_0)
		{
			kGuVfeffObwXFfTMvrqgyDrQrQy.Get(P_0).elYcMhbKzSeljZRwOauCUrvcISK();
		}

		private static HardwareControllerMap_Game aKxbNHDftUXEhPzRIeHSCDPOrtfY()
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
				ref AxisCalibrationData reference = ref array4[k];
				reference = AxisCalibrationData.Raw;
				array5[k] = AxisRange.Full;
				float pollingDeadZone;
				switch (k)
				{
				case 0:
				case 1:
					pollingDeadZone = 100f;
					break;
				default:
					pollingDeadZone = 2f;
					break;
				}
				array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, excludeFromPolling: false, pollingDeadZone, SpecialAxisType.None);
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
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
					ReInput.UpdateEndedEvent -= oJEGHntPXeDMngoHmUuMXuUAYnf;
					ReInput.EarlyUpdateEvent -= gkcUDzrPqIPuiToYGeMEGiRcoRf;
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (cEYeWTjdrdJnTGiDFBdZbfkXIqH == null)
			{
				cEYeWTjdrdJnTGiDFBdZbfkXIqH = aKxbNHDftUXEhPzRIeHSCDPOrtfY();
			}
			return cEYeWTjdrdJnTGiDFBdZbfkXIqH.GetElementType(elementIdentifierId);
		}

		[CompilerGenerated]
		private static SlAwqyHtNHjLNuiARwnqRcOozwl bLodcsddrHTEuWTjOteQwJmDvMug()
		{
			return new SlAwqyHtNHjLNuiARwnqRcOozwl(7, 4);
		}
	}
}
