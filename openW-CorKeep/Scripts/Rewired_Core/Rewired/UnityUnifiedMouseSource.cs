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
		private class MvobXFGMEIFVQNGvzmfnepSWbMIj
		{
			private float[] bvWmNNuhxiWjGNCSexuxGXNAUUZ;

			private bool[] NAinekULsoKbJnFppqZtFAAuOJN;

			public MvobXFGMEIFVQNGvzmfnepSWbMIj(int P_0, int P_1)
			{
				NAinekULsoKbJnFppqZtFAAuOJN = new bool[P_0];
				bvWmNNuhxiWjGNCSexuxGXNAUUZ = new float[P_1];
			}

			public void cvpAVmdQhadYjvNyOqobxwBmJVRb(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, NAinekULsoKbJnFppqZtFAAuOJN, P_0.Length);
				for (int i = 0; i < bvWmNNuhxiWjGNCSexuxGXNAUUZ.Length; i++)
				{
					bvWmNNuhxiWjGNCSexuxGXNAUUZ[i] += P_1[i];
				}
			}

			public void ToeASnfqSaKZIxbQdikfrpwEoekB(ControllerDataUpdater P_0)
			{
				Array.Copy(bvWmNNuhxiWjGNCSexuxGXNAUUZ, P_0.axisValues, bvWmNNuhxiWjGNCSexuxGXNAUUZ.Length);
				Array.Copy(NAinekULsoKbJnFppqZtFAAuOJN, P_0.buttonValues, NAinekULsoKbJnFppqZtFAAuOJN.Length);
			}

			public void tnPMvOhBpjvxYNUlgoWzWsITeuGP()
			{
				Array.Clear(bvWmNNuhxiWjGNCSexuxGXNAUUZ, 0, bvWmNNuhxiWjGNCSexuxGXNAUUZ.Length);
				Array.Clear(NAinekULsoKbJnFppqZtFAAuOJN, 0, NAinekULsoKbJnFppqZtFAAuOJN.Length);
			}

			public void IDrywvorrgxouKEvbvkUhijwgJcE()
			{
				Array.Clear(bvWmNNuhxiWjGNCSexuxGXNAUUZ, 0, bvWmNNuhxiWjGNCSexuxGXNAUUZ.Length);
			}
		}

		[Serializable]
		private sealed class WNPIJXFEanedPkvBcNAfLGmugoFI
		{
			public static readonly WNPIJXFEanedPkvBcNAfLGmugoFI _003C_003E9 = new WNPIJXFEanedPkvBcNAfLGmugoFI();

			public static Func<MvobXFGMEIFVQNGvzmfnepSWbMIj> _003C_003E9__20_0;

			internal MvobXFGMEIFVQNGvzmfnepSWbMIj EgofZKmGzYougWiQAWPFxAHuGKLs()
			{
				return new MvobXFGMEIFVQNGvzmfnepSWbMIj(7, 4);
			}
		}

		private static HardwareControllerMap_Game nXheGgTNHblnFEyABIbFGBWnzZn;

		private UpdateLoopDataSet<MvobXFGMEIFVQNGvzmfnepSWbMIj> RCTKNOorxaKSdafAFCNhqeplgjXj;

		private float[] FmszaTTFbKeSlgKImBbUeNnVzBQN;

		private bool[] AGdZXtHRInntjbHiSTnaWMtGluiv;

		private bool YFIOVhZbwMunhsxFaSxeHPQzgnBe;

		private bool LXWdiRhhonXzBMVOZSZAIieyBmrx;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return YFIOVhZbwMunhsxFaSxeHPQzgnBe;
			}
			set
			{
				if (YFIOVhZbwMunhsxFaSxeHPQzgnBe != value)
				{
					YFIOVhZbwMunhsxFaSxeHPQzgnBe = value;
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
				if (nXheGgTNHblnFEyABIbFGBWnzZn == null)
				{
					nXheGgTNHblnFEyABIbFGBWnzZn = CreateHardwareMap();
				}
				return nXheGgTNHblnFEyABIbFGBWnzZn;
			}
		}

		int IUnifiedMouseSource.buttonCount => 7;

		int IUnifiedMouseSource.axisCount => 4;

		Vector2 IUnifiedMouseSource.mousePosition
		{
			get
			{
				if (!YFIOVhZbwMunhsxFaSxeHPQzgnBe)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		Controller.Extension IUnifiedMouseSource.controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			RCTKNOorxaKSdafAFCNhqeplgjXj = new UpdateLoopDataSet<MvobXFGMEIFVQNGvzmfnepSWbMIj>(ReInput.configVars.updateLoop, WNPIJXFEanedPkvBcNAfLGmugoFI._003C_003E9.EgofZKmGzYougWiQAWPFxAHuGKLs);
			FmszaTTFbKeSlgKImBbUeNnVzBQN = new float[4];
			AGdZXtHRInntjbHiSTnaWMtGluiv = new bool[7];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ReInput.UpdateEndedEvent += JPRoVzBgaKIAwHfuZdmyPCjRAVbMA;
			ReInput.EarlyUpdateEvent += aPLFUgctBpOtJQATFBjMZNbscGqEb;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			RCTKNOorxaKSdafAFCNhqeplgjXj.Get(ReInput.currentUpdateLoop).ToeASnfqSaKZIxbQdikfrpwEoekB(dataUpdater);
		}

		void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
			int count = RCTKNOorxaKSdafAFCNhqeplgjXj.Count;
			for (int i = 0; i < count; i++)
			{
				RCTKNOorxaKSdafAFCNhqeplgjXj.Get(i).tnPMvOhBpjvxYNUlgoWzWsITeuGP();
			}
		}

		void IUnifiedMouseSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private void aPLFUgctBpOtJQATFBjMZNbscGqEb()
		{
			if (YFIOVhZbwMunhsxFaSxeHPQzgnBe)
			{
				ThreadSafeUnityInput.mouse.GetAxisRawValues(FmszaTTFbKeSlgKImBbUeNnVzBQN);
				ThreadSafeUnityInput.mouse.GetButtonValues(AGdZXtHRInntjbHiSTnaWMtGluiv);
				int count = RCTKNOorxaKSdafAFCNhqeplgjXj.Count;
				for (int i = 0; i < count; i++)
				{
					RCTKNOorxaKSdafAFCNhqeplgjXj.Get(i).cvpAVmdQhadYjvNyOqobxwBmJVRb(AGdZXtHRInntjbHiSTnaWMtGluiv, FmszaTTFbKeSlgKImBbUeNnVzBQN);
				}
			}
		}

		private void JPRoVzBgaKIAwHfuZdmyPCjRAVbMA(UpdateLoopType P_0)
		{
			RCTKNOorxaKSdafAFCNhqeplgjXj.Get(P_0).IDrywvorrgxouKEvbvkUhijwgJcE();
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
			if (LXWdiRhhonXzBMVOZSZAIieyBmrx)
			{
				return;
			}
			if (disposing)
			{
				if (YFIOVhZbwMunhsxFaSxeHPQzgnBe)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= JPRoVzBgaKIAwHfuZdmyPCjRAVbMA;
				ReInput.EarlyUpdateEvent -= aPLFUgctBpOtJQATFBjMZNbscGqEb;
			}
			LXWdiRhhonXzBMVOZSZAIieyBmrx = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (nXheGgTNHblnFEyABIbFGBWnzZn == null)
			{
				nXheGgTNHblnFEyABIbFGBWnzZn = CreateHardwareMap();
			}
			return nXheGgTNHblnFEyABIbFGBWnzZn.GetElementType(elementIdentifierId);
		}
	}
}
