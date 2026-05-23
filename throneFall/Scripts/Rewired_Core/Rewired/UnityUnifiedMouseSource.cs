using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class jxACgsetvSUZpZShWFBjdFvVyRTG
		{
			private float[] UxTBnadECpXSYIenlMVomduWHXFT;

			private bool[] sgmOQBKYkeVfCPEgUDULkFhRXROm;

			public jxACgsetvSUZpZShWFBjdFvVyRTG(int P_0, int P_1)
			{
				sgmOQBKYkeVfCPEgUDULkFhRXROm = new bool[P_0];
				UxTBnadECpXSYIenlMVomduWHXFT = new float[P_1];
			}

			public void PkNlQyOElnfullokVfDwkKFdWYYO(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, sgmOQBKYkeVfCPEgUDULkFhRXROm, P_0.Length);
				for (int i = 0; i < UxTBnadECpXSYIenlMVomduWHXFT.Length; i++)
				{
					UxTBnadECpXSYIenlMVomduWHXFT[i] += P_1[i];
				}
			}

			public void waIfvjBkZqiRglYGCMZuaTKXMtbt(ControllerDataUpdater P_0)
			{
				Array.Copy(UxTBnadECpXSYIenlMVomduWHXFT, P_0.axisValues, UxTBnadECpXSYIenlMVomduWHXFT.Length);
				Array.Copy(sgmOQBKYkeVfCPEgUDULkFhRXROm, P_0.buttonValues, sgmOQBKYkeVfCPEgUDULkFhRXROm.Length);
			}

			public void WldvUpZbEzYcnTyALArtZLbUdvFu()
			{
				Array.Clear(UxTBnadECpXSYIenlMVomduWHXFT, 0, UxTBnadECpXSYIenlMVomduWHXFT.Length);
				Array.Clear(sgmOQBKYkeVfCPEgUDULkFhRXROm, 0, sgmOQBKYkeVfCPEgUDULkFhRXROm.Length);
			}

			public void doDViCGtQomEHEnnUUIEuaZdHzrv()
			{
				Array.Clear(UxTBnadECpXSYIenlMVomduWHXFT, 0, UxTBnadECpXSYIenlMVomduWHXFT.Length);
			}
		}

		[Serializable]
		private sealed class jazdturDpdGnwyxKRBejESThJrGgA
		{
			public static readonly jazdturDpdGnwyxKRBejESThJrGgA _003C_003E9 = new jazdturDpdGnwyxKRBejESThJrGgA();

			public static Func<jxACgsetvSUZpZShWFBjdFvVyRTG> _003C_003E9__20_0;

			internal jxACgsetvSUZpZShWFBjdFvVyRTG zmECfjAFOCnOJCsfbfYRaselPTGf()
			{
				return new jxACgsetvSUZpZShWFBjdFvVyRTG(7, 4);
			}
		}

		private static HardwareControllerMap_Game QplWvlMccBbiSZCTlMtnWwsBkyQr;

		private UpdateLoopDataSet<jxACgsetvSUZpZShWFBjdFvVyRTG> eObfsfUAuqHLEahBodudjYUqrRCe;

		private float[] cHUEoiziSQHRIwLhROSYjCUUQJJJ;

		private bool[] ttPqwAnutbJgIxdDfHQsETEPOrhPA;

		private bool bGkbkQtREIdFWwsQXzjaKgacClOQ;

		private bool gVsDknBZHfaiUUrryuCSDRntrsGc;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return bGkbkQtREIdFWwsQXzjaKgacClOQ;
			}
			set
			{
				if (bGkbkQtREIdFWwsQXzjaKgacClOQ != value)
				{
					bGkbkQtREIdFWwsQXzjaKgacClOQ = value;
					Clear();
					ThreadSafeUnityInput.mouse.Monitor(value);
				}
			}
		}

		InputSource IUnifiedMouseSource.inputSource => InputSource.UnityKeyboardAndMouse;

		HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap
		{
			get
			{
				if (QplWvlMccBbiSZCTlMtnWwsBkyQr == null)
				{
					QplWvlMccBbiSZCTlMtnWwsBkyQr = CreateHardwareMap();
				}
				return QplWvlMccBbiSZCTlMtnWwsBkyQr;
			}
		}

		int IUnifiedMouseSource.buttonCount => 7;

		int IUnifiedMouseSource.axisCount => 4;

		Vector2 IUnifiedMouseSource.mousePosition
		{
			get
			{
				if (!bGkbkQtREIdFWwsQXzjaKgacClOQ)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		Controller.Extension IUnifiedMouseSource.controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			eObfsfUAuqHLEahBodudjYUqrRCe = new UpdateLoopDataSet<jxACgsetvSUZpZShWFBjdFvVyRTG>(ReInput.configVars.updateLoop, jazdturDpdGnwyxKRBejESThJrGgA._003C_003E9.zmECfjAFOCnOJCsfbfYRaselPTGf);
			cHUEoiziSQHRIwLhROSYjCUUQJJJ = new float[4];
			ttPqwAnutbJgIxdDfHQsETEPOrhPA = new bool[7];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ReInput.UpdateEndedEvent += gjhuoArwXIFHPxHJuEXoXqQYmYot;
			ReInput.EarlyUpdateEvent += XjhkxBFxsrNykEaksVEUQfUtJHpn;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			eObfsfUAuqHLEahBodudjYUqrRCe.Get(ReInput.currentUpdateLoop).waIfvjBkZqiRglYGCMZuaTKXMtbt(dataUpdater);
		}

		void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
			int count = eObfsfUAuqHLEahBodudjYUqrRCe.Count;
			for (int i = 0; i < count; i++)
			{
				eObfsfUAuqHLEahBodudjYUqrRCe.Get(i).WldvUpZbEzYcnTyALArtZLbUdvFu();
			}
		}

		void IUnifiedMouseSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private void XjhkxBFxsrNykEaksVEUQfUtJHpn()
		{
			if (bGkbkQtREIdFWwsQXzjaKgacClOQ)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(cHUEoiziSQHRIwLhROSYjCUUQJJJ);
				ThreadSafeUnityInput.mouse.GetButtonValues(ttPqwAnutbJgIxdDfHQsETEPOrhPA);
				int count = eObfsfUAuqHLEahBodudjYUqrRCe.Count;
				for (int i = 0; i < count; i++)
				{
					eObfsfUAuqHLEahBodudjYUqrRCe.Get(i).PkNlQyOElnfullokVfDwkKFdWYYO(ttPqwAnutbJgIxdDfHQsETEPOrhPA, cHUEoiziSQHRIwLhROSYjCUUQJJJ);
				}
			}
		}

		private void gjhuoArwXIFHPxHJuEXoXqQYmYot(UpdateLoopType P_0)
		{
			eObfsfUAuqHLEahBodudjYUqrRCe.Get(P_0).doDViCGtQomEHEnnUUIEuaZdHzrv();
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
					array3[num2++] = array[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
				}
				else if (array[j].elementType == ControllerElementType.Button)
				{
					array2[num++] = array[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
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

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~UnityUnifiedMouseSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (gVsDknBZHfaiUUrryuCSDRntrsGc)
			{
				return;
			}
			if (disposing)
			{
				if (bGkbkQtREIdFWwsQXzjaKgacClOQ)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= gjhuoArwXIFHPxHJuEXoXqQYmYot;
				ReInput.EarlyUpdateEvent -= XjhkxBFxsrNykEaksVEUQfUtJHpn;
			}
			gVsDknBZHfaiUUrryuCSDRntrsGc = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (QplWvlMccBbiSZCTlMtnWwsBkyQr == null)
			{
				QplWvlMccBbiSZCTlMtnWwsBkyQr = CreateHardwareMap();
			}
			return QplWvlMccBbiSZCTlMtnWwsBkyQr.GetElementType(elementIdentifierId);
		}
	}
}
