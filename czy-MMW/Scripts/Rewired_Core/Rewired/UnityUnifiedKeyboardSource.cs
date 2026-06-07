using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedKeyboardSource : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
	{
		private const int VXHbPNmLqaEbhziLbaxHVgipbeKD = 132;

		private static HardwareControllerMap_Game KwdewMDOTtdRFfrZPyQKbrQmnnonA;

		private bool jILcsVHzEhajlDFJSbjUgNcrXWkP;

		private bool bPllnoOvwfporNiFJXVbROdlzVOf;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return jILcsVHzEhajlDFJSbjUgNcrXWkP;
			}
			set
			{
				if (jILcsVHzEhajlDFJSbjUgNcrXWkP != value)
				{
					jILcsVHzEhajlDFJSbjUgNcrXWkP = value;
					Clear();
					ThreadSafeUnityInput.keyboard.Monitor(value);
				}
			}
		}

		InputSource IUnifiedKeyboardSource.inputSource => InputSource.UnityKeyboardAndMouse;

		HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap
		{
			get
			{
				if (KwdewMDOTtdRFfrZPyQKbrQmnnonA == null)
				{
					KwdewMDOTtdRFfrZPyQKbrQmnnonA = oPRLavxANrHukxYTHjjUoJyZDhldA();
				}
				return KwdewMDOTtdRFfrZPyQKbrQmnnonA;
			}
		}

		int IUnifiedKeyboardSource.buttonCount => 132;

		Controller.Extension IUnifiedKeyboardSource.controllerExtension => null;

		public UnityUnifiedKeyboardSource()
		{
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			if (jILcsVHzEhajlDFJSbjUgNcrXWkP)
			{
				ThreadSafeUnityInput.keyboard.GetKeyValues(dataUpdater.buttonValues);
			}
		}

		void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
		}

		void IUnifiedKeyboardSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private static HardwareControllerMap_Game oPRLavxANrHukxYTHjjUoJyZDhldA()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
			}
			int[] array2 = new int[132];
			for (int j = 0; j < 132; j++)
			{
				array2[j] = array[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
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
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~UnityUnifiedKeyboardSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!bPllnoOvwfporNiFJXVbROdlzVOf)
			{
				if (disposing && jILcsVHzEhajlDFJSbjUgNcrXWkP)
				{
					ThreadSafeUnityInput.keyboard.Monitor(state: false);
				}
				bPllnoOvwfporNiFJXVbROdlzVOf = true;
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (KwdewMDOTtdRFfrZPyQKbrQmnnonA == null)
			{
				KwdewMDOTtdRFfrZPyQKbrQmnnonA = oPRLavxANrHukxYTHjjUoJyZDhldA();
			}
			return KwdewMDOTtdRFfrZPyQKbrQmnnonA.GetElementType(elementIdentifierId);
		}
	}
}
