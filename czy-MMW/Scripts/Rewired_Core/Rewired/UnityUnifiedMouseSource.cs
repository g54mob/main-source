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
		private class QlvFowvMdPEpHEKCHzOedOndWexcA
		{
			private float[] hMyznwuPGkAwybVxovLnRRiapDrgb;

			private bool[] XxDyeBHpgbwkgSGaPdYCDoxdwByv;

			public QlvFowvMdPEpHEKCHzOedOndWexcA(int P_0, int P_1)
			{
				XxDyeBHpgbwkgSGaPdYCDoxdwByv = new bool[P_0];
				hMyznwuPGkAwybVxovLnRRiapDrgb = new float[P_1];
			}

			public void eYcyBwDjzmuLRoeeOjKvIRHVsAioA(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, XxDyeBHpgbwkgSGaPdYCDoxdwByv, P_0.Length);
				for (int i = 0; i < hMyznwuPGkAwybVxovLnRRiapDrgb.Length; i++)
				{
					hMyznwuPGkAwybVxovLnRRiapDrgb[i] += P_1[i];
				}
			}

			public void TnfxJzYBLjrqWoEALrKxFwAlBnHw(ControllerDataUpdater P_0)
			{
				Array.Copy(hMyznwuPGkAwybVxovLnRRiapDrgb, P_0.axisValues, hMyznwuPGkAwybVxovLnRRiapDrgb.Length);
				Array.Copy(XxDyeBHpgbwkgSGaPdYCDoxdwByv, P_0.buttonValues, XxDyeBHpgbwkgSGaPdYCDoxdwByv.Length);
			}

			public void pxMBgjUVCspDVGcQGckahgdejdrVA()
			{
				Array.Clear(hMyznwuPGkAwybVxovLnRRiapDrgb, 0, hMyznwuPGkAwybVxovLnRRiapDrgb.Length);
				Array.Clear(XxDyeBHpgbwkgSGaPdYCDoxdwByv, 0, XxDyeBHpgbwkgSGaPdYCDoxdwByv.Length);
			}

			public void AEmihEeLSlIZhFofJdDTbXHRcnTjb()
			{
				Array.Clear(hMyznwuPGkAwybVxovLnRRiapDrgb, 0, hMyznwuPGkAwybVxovLnRRiapDrgb.Length);
			}
		}

		[Serializable]
		private sealed class IqSTBoiyrcRMObuUQnjaxiLLYnsW
		{
			public static readonly IqSTBoiyrcRMObuUQnjaxiLLYnsW _003C_003E9 = new IqSTBoiyrcRMObuUQnjaxiLLYnsW();

			public static Func<QlvFowvMdPEpHEKCHzOedOndWexcA> _003C_003E9__20_0;

			internal QlvFowvMdPEpHEKCHzOedOndWexcA WClnizHUYRiYtBJrehwKVReHDVgK()
			{
				return new QlvFowvMdPEpHEKCHzOedOndWexcA(7, 4);
			}
		}

		private static HardwareControllerMap_Game rdIAqpDHcCZXsgUDmKkcFliixciRb;

		private UpdateLoopDataSet<QlvFowvMdPEpHEKCHzOedOndWexcA> RDUIRrBjMjQycrdtvzsiGvQIrSam;

		private float[] ZuxDouiXSTTeotBfKsTTIwMeFMtS;

		private bool[] ECeCKLezmiRokmRhgXjjgAapbJNb;

		private bool OxHFBAgyAZJUkojOAqkzFpgGJvaCA;

		private bool TMBmtcGVRcFNGJAlxjnDEuXDQxGoA;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return OxHFBAgyAZJUkojOAqkzFpgGJvaCA;
			}
			set
			{
				if (OxHFBAgyAZJUkojOAqkzFpgGJvaCA != value)
				{
					OxHFBAgyAZJUkojOAqkzFpgGJvaCA = value;
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
				if (rdIAqpDHcCZXsgUDmKkcFliixciRb == null)
				{
					rdIAqpDHcCZXsgUDmKkcFliixciRb = AyODANdQgzDsscINKWklbEICkweLD();
				}
				return rdIAqpDHcCZXsgUDmKkcFliixciRb;
			}
		}

		int IUnifiedMouseSource.buttonCount => 7;

		int IUnifiedMouseSource.axisCount => 4;

		Vector2 IUnifiedMouseSource.mousePosition
		{
			get
			{
				if (!OxHFBAgyAZJUkojOAqkzFpgGJvaCA)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		Controller.Extension IUnifiedMouseSource.controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			RDUIRrBjMjQycrdtvzsiGvQIrSam = new UpdateLoopDataSet<QlvFowvMdPEpHEKCHzOedOndWexcA>(ReInput.configVars.updateLoop, IqSTBoiyrcRMObuUQnjaxiLLYnsW._003C_003E9.WClnizHUYRiYtBJrehwKVReHDVgK);
			ZuxDouiXSTTeotBfKsTTIwMeFMtS = new float[4];
			ECeCKLezmiRokmRhgXjjgAapbJNb = new bool[7];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ReInput.UpdateEndedEvent += BSQAWIiPRRBwvcXJvwAfcQUeQUMl;
			ReInput.EarlyUpdateEvent += iSMVwREyxkLPGLknjRBPxeMRHHNf;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			RDUIRrBjMjQycrdtvzsiGvQIrSam.Get(ReInput.currentUpdateLoop).TnfxJzYBLjrqWoEALrKxFwAlBnHw(dataUpdater);
		}

		void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
			int count = RDUIRrBjMjQycrdtvzsiGvQIrSam.Count;
			for (int i = 0; i < count; i++)
			{
				RDUIRrBjMjQycrdtvzsiGvQIrSam.Get(i).pxMBgjUVCspDVGcQGckahgdejdrVA();
			}
		}

		void IUnifiedMouseSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private void iSMVwREyxkLPGLknjRBPxeMRHHNf()
		{
			if (OxHFBAgyAZJUkojOAqkzFpgGJvaCA)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(ZuxDouiXSTTeotBfKsTTIwMeFMtS);
				ThreadSafeUnityInput.mouse.GetButtonValues(ECeCKLezmiRokmRhgXjjgAapbJNb);
				int count = RDUIRrBjMjQycrdtvzsiGvQIrSam.Count;
				for (int i = 0; i < count; i++)
				{
					RDUIRrBjMjQycrdtvzsiGvQIrSam.Get(i).eYcyBwDjzmuLRoeeOjKvIRHVsAioA(ECeCKLezmiRokmRhgXjjgAapbJNb, ZuxDouiXSTTeotBfKsTTIwMeFMtS);
				}
			}
		}

		private void BSQAWIiPRRBwvcXJvwAfcQUeQUMl(UpdateLoopType P_0)
		{
			RDUIRrBjMjQycrdtvzsiGvQIrSam.Get(P_0).AEmihEeLSlIZhFofJdDTbXHRcnTjb();
		}

		private static HardwareControllerMap_Game AyODANdQgzDsscINKWklbEICkweLD()
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
			if (TMBmtcGVRcFNGJAlxjnDEuXDQxGoA)
			{
				return;
			}
			if (disposing)
			{
				if (OxHFBAgyAZJUkojOAqkzFpgGJvaCA)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= BSQAWIiPRRBwvcXJvwAfcQUeQUMl;
				ReInput.EarlyUpdateEvent -= iSMVwREyxkLPGLknjRBPxeMRHHNf;
			}
			TMBmtcGVRcFNGJAlxjnDEuXDQxGoA = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (rdIAqpDHcCZXsgUDmKkcFliixciRb == null)
			{
				rdIAqpDHcCZXsgUDmKkcFliixciRb = AyODANdQgzDsscINKWklbEICkweLD();
			}
			return rdIAqpDHcCZXsgUDmKkcFliixciRb.GetElementType(elementIdentifierId);
		}
	}
}
