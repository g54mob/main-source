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
		private class CygxvMycpAXJskVRuvEOzGrpmpMC
		{
			private float[] tvzAqYrWDbkIRnlcRrsPybDgoZGM;

			private bool[] LGOBrbAUteoUJykfybxwHiOjcNRlA;

			public CygxvMycpAXJskVRuvEOzGrpmpMC(int P_0, int P_1)
			{
				LGOBrbAUteoUJykfybxwHiOjcNRlA = new bool[P_0];
				tvzAqYrWDbkIRnlcRrsPybDgoZGM = new float[P_1];
			}

			public void ehpBCWAPilZbyCybjvbVoYyJBSDV(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, LGOBrbAUteoUJykfybxwHiOjcNRlA, P_0.Length);
				for (int i = 0; i < tvzAqYrWDbkIRnlcRrsPybDgoZGM.Length; i++)
				{
					tvzAqYrWDbkIRnlcRrsPybDgoZGM[i] += P_1[i];
				}
			}

			public void HMwEQDVYAwOklUgFurxLkafbbXwi(ControllerDataUpdater P_0)
			{
				Array.Copy(tvzAqYrWDbkIRnlcRrsPybDgoZGM, P_0.axisValues, tvzAqYrWDbkIRnlcRrsPybDgoZGM.Length);
				Array.Copy(LGOBrbAUteoUJykfybxwHiOjcNRlA, P_0.buttonValues, LGOBrbAUteoUJykfybxwHiOjcNRlA.Length);
			}

			public void dKFylNHpTdgjaodHjaZCBTWaArGcb()
			{
				Array.Clear(tvzAqYrWDbkIRnlcRrsPybDgoZGM, 0, tvzAqYrWDbkIRnlcRrsPybDgoZGM.Length);
				Array.Clear(LGOBrbAUteoUJykfybxwHiOjcNRlA, 0, LGOBrbAUteoUJykfybxwHiOjcNRlA.Length);
			}

			public void UcjsYuORPipKMvtkoqAboAqXbjws()
			{
				Array.Clear(tvzAqYrWDbkIRnlcRrsPybDgoZGM, 0, tvzAqYrWDbkIRnlcRrsPybDgoZGM.Length);
			}
		}

		[Serializable]
		private sealed class OmXaISlRipkxhDAXjMhCQcgThzTQ
		{
			public static readonly OmXaISlRipkxhDAXjMhCQcgThzTQ _003C_003E9 = new OmXaISlRipkxhDAXjMhCQcgThzTQ();

			public static Func<CygxvMycpAXJskVRuvEOzGrpmpMC> _003C_003E9__20_0;

			internal CygxvMycpAXJskVRuvEOzGrpmpMC QBgrVHOGRQiwQlcoZVNsmeLNENFt()
			{
				return new CygxvMycpAXJskVRuvEOzGrpmpMC(7, 4);
			}
		}

		private static HardwareControllerMap_Game dcNcrHSsdJjtVcyUJoJSEJDvDwXo;

		private UpdateLoopDataSet<CygxvMycpAXJskVRuvEOzGrpmpMC> LZPEkVSEZsCeVLDyOJZGprTCtLDD;

		private float[] ThsrxCjRmSAARViirixvfCniWQYf;

		private bool[] AixLHkdqotzpBCkMHicVTKvpvxou;

		private bool UeQExyfQTSqLBXmHnLXZSrLYjuXh;

		private bool XOksUCZUtQbfGdyaAIpYRkNWfljb;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return UeQExyfQTSqLBXmHnLXZSrLYjuXh;
			}
			set
			{
				if (UeQExyfQTSqLBXmHnLXZSrLYjuXh != value)
				{
					UeQExyfQTSqLBXmHnLXZSrLYjuXh = value;
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
				if (dcNcrHSsdJjtVcyUJoJSEJDvDwXo == null)
				{
					dcNcrHSsdJjtVcyUJoJSEJDvDwXo = CreateHardwareMap();
				}
				return dcNcrHSsdJjtVcyUJoJSEJDvDwXo;
			}
		}

		int IUnifiedMouseSource.buttonCount => 7;

		int IUnifiedMouseSource.axisCount => 4;

		Vector2 IUnifiedMouseSource.mousePosition
		{
			get
			{
				if (!UeQExyfQTSqLBXmHnLXZSrLYjuXh)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		Controller.Extension IUnifiedMouseSource.controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			LZPEkVSEZsCeVLDyOJZGprTCtLDD = new UpdateLoopDataSet<CygxvMycpAXJskVRuvEOzGrpmpMC>(ReInput.configVars.updateLoop, OmXaISlRipkxhDAXjMhCQcgThzTQ._003C_003E9.QBgrVHOGRQiwQlcoZVNsmeLNENFt);
			ThsrxCjRmSAARViirixvfCniWQYf = new float[4];
			AixLHkdqotzpBCkMHicVTKvpvxou = new bool[7];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ReInput.UpdateEndedEvent += JtHZNgrJUETCAKIWEFxHiXtgbSxKA;
			ReInput.EarlyUpdateEvent += ekNiMpTnjbHjxfmzGDajAGzXjJqgb;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			LZPEkVSEZsCeVLDyOJZGprTCtLDD.Get(ReInput.currentUpdateLoop).HMwEQDVYAwOklUgFurxLkafbbXwi(dataUpdater);
		}

		void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
			int count = LZPEkVSEZsCeVLDyOJZGprTCtLDD.Count;
			for (int i = 0; i < count; i++)
			{
				LZPEkVSEZsCeVLDyOJZGprTCtLDD.Get(i).dKFylNHpTdgjaodHjaZCBTWaArGcb();
			}
		}

		void IUnifiedMouseSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private void ekNiMpTnjbHjxfmzGDajAGzXjJqgb()
		{
			if (UeQExyfQTSqLBXmHnLXZSrLYjuXh)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(ThsrxCjRmSAARViirixvfCniWQYf);
				ThreadSafeUnityInput.mouse.GetButtonValues(AixLHkdqotzpBCkMHicVTKvpvxou);
				int count = LZPEkVSEZsCeVLDyOJZGprTCtLDD.Count;
				for (int i = 0; i < count; i++)
				{
					LZPEkVSEZsCeVLDyOJZGprTCtLDD.Get(i).ehpBCWAPilZbyCybjvbVoYyJBSDV(AixLHkdqotzpBCkMHicVTKvpvxou, ThsrxCjRmSAARViirixvfCniWQYf);
				}
			}
		}

		private void JtHZNgrJUETCAKIWEFxHiXtgbSxKA(UpdateLoopType P_0)
		{
			LZPEkVSEZsCeVLDyOJZGprTCtLDD.Get(P_0).UcjsYuORPipKMvtkoqAboAqXbjws();
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
			HardwareJoystickMap.CompoundElement[] array8 = new HardwareJoystickMap.CompoundElement[Consts.unifiedMouseCompoundElements_readOnly.Count];
			for (int m = 0; m < Consts.unifiedMouseCompoundElements_readOnly.Count; m++)
			{
				array8[m] = new HardwareJoystickMap.CompoundElement(Consts.unifiedMouseCompoundElements_readOnly[m]);
			}
			return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, array8);
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
			if (XOksUCZUtQbfGdyaAIpYRkNWfljb)
			{
				return;
			}
			if (disposing)
			{
				if (UeQExyfQTSqLBXmHnLXZSrLYjuXh)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= JtHZNgrJUETCAKIWEFxHiXtgbSxKA;
				ReInput.EarlyUpdateEvent -= ekNiMpTnjbHjxfmzGDajAGzXjJqgb;
			}
			XOksUCZUtQbfGdyaAIpYRkNWfljb = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (dcNcrHSsdJjtVcyUJoJSEJDvDwXo == null)
			{
				dcNcrHSsdJjtVcyUJoJSEJDvDwXo = CreateHardwareMap();
			}
			return dcNcrHSsdJjtVcyUJoJSEJDvDwXo.GetElementType(elementIdentifierId);
		}
	}
}
