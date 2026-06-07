using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int pVkDZeuroSeLJETezpLqWjQXPZxE;

		private Func<int, float> KAsBrSJuHOhwFOrAWFfuWGXzXUG;

		private Func<int, bool> ycGrWPJiyDKbipsDZAaSdIWchtD;

		private bool zofOzpYSMPCISSHmMSeHMjNbGEa;

		private Guid daDenESRsNYcblpUGKfMATRkvCo;

		public int sourceControllerId => pVkDZeuroSeLJETezpLqWjQXPZxE;

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return daDenESRsNYcblpUGKfMATRkvCo;
			}
		}

		internal CustomController(SSXBUfkgAKBbEgHlAaRyfXKtATAa data)
			: this(data.sjbjANsWQaKxKgfHgxDuZgoAatr, data.TMsCkWDMcUezxWQMFEJGYJRjUaqu, data.BosaYMINWJilPSeDoArkNCjTJvR, data.ahVlanlbOCBOWeBnfSIFVGtHSeq, data.qROaKKGTWVzDYhhRdQZEfZxsihTO, data.CJAZbjwducAKeDXWKNPqtHrxjmK, data.VCpqtEqSaKpqQHTevHyRzIpEfdp, data.rGEuFEtJcMmFaLOCcsmbRHUjSpy, data.qrXpdbCUzFLCBfjCDTfPHyJCus, data.ptorLnNmGaWxfMoJJnQaxSkKksE, null, new ControllerDataUpdater(data.ahVlanlbOCBOWeBnfSIFVGtHSeq, data.rGEuFEtJcMmFaLOCcsmbRHUjSpy, data.qrXpdbCUzFLCBfjCDTfPHyJCus, null))
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Custom, hardwareTypeGuid, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			pVkDZeuroSeLJETezpLqWjQXPZxE = sourceControllerId;
			daDenESRsNYcblpUGKfMATRkvCo = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + pVkDZeuroSeLJETezpLqWjQXPZxE + ", controllerId = " + controllerId);
			ANKdbHXpmTNShTcixGbSxMIpqJK();
		}

		internal void oYEKbEsjyanyZgeNJBDuvfAMTFD()
		{
			if (!zofOzpYSMPCISSHmMSeHMjNbGEa)
			{
				return;
			}
			if (KAsBrSJuHOhwFOrAWFfuWGXzXUG != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[i] = KAsBrSJuHOhwFOrAWFfuWGXzXUG(i);
				}
			}
			if (ycGrWPJiyDKbipsDZAaSdIWchtD != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonValues[j] = ycGrWPJiyDKbipsDZAaSdIWchtD(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			KAsBrSJuHOhwFOrAWFfuWGXzXUG = callback;
			if (!zofOzpYSMPCISSHmMSeHMjNbGEa)
			{
				zofOzpYSMPCISSHmMSeHMjNbGEa = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			ycGrWPJiyDKbipsDZAaSdIWchtD = callback;
			if (!zofOzpYSMPCISSHmMSeHMjNbGEa)
			{
				zofOzpYSMPCISSHmMSeHMjNbGEa = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					ClearAxisValue(axisIndex);
				}
			}
		}

		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					ClearAxisValue(axisIndex);
				}
			}
		}

		public void ClearButtonValue(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonValues[index] = false;
				QlXkhNBHPYUNWwhKurdwrqFgWTf.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					ClearButtonValue(buttonIndex);
				}
			}
		}

		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (base.enabled)
			{
				int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					ClearButtonValue(buttonIndex);
				}
			}
		}
	}
}
