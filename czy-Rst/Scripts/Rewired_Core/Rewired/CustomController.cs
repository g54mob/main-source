using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int qYkUUnVDSKgmudQBZjwrbrJpzSXt;

		private Func<int, float> lgKjgDjKanNlPioZFEmwHcbEPNcNA;

		private Func<int, bool> eRDBHNERuXRiYlaxFFymFOBxuuxjA;

		private bool bondJaLnZSGAYCgYHeLxRFHOsRYFA;

		private Guid mrFjeebVKriUbgXRGutfolfPxaOm;

		public int sourceControllerId => qYkUUnVDSKgmudQBZjwrbrJpzSXt;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Guid.Empty;
				}
				return mrFjeebVKriUbgXRGutfolfPxaOm;
			}
		}

		internal CustomController(rLcHvetlHEOCUXxKJOdROkyhUscr P_0)
			: this(P_0.tULpMEvsvmFbEKvUYhOpTQMeLHWbb, P_0.nieNuHKRLmMeCtqjczXCJHkqJCrV, P_0.ICSFvCapUauhyntyogCZzWEbSNwn, P_0.sPhrgWptXqBEBTRDXsBFkoEIYgMB, P_0.TpQCcdPZonOaYNIdkxnuGNGckjmW, P_0.zyFfblnamxnVQFngKeRVXUzwsBKO, P_0.rOCacgdVrAxKNvFGxDXygNSbvWPYA, P_0.lKEjuhtBshHmaMmqIlPhXMpxCIVHA, P_0.WTLyQhSMIiIeAzHOyFCyRZNuPMrf, P_0.CEPLBnsuBAwAlEbfrizRAtWZSPSrA, null, new ControllerDataUpdater(P_0.sPhrgWptXqBEBTRDXsBFkoEIYgMB, P_0.lKEjuhtBshHmaMmqIlPhXMpxCIVHA, P_0.WTLyQhSMIiIeAzHOyFCyRZNuPMrf, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			qYkUUnVDSKgmudQBZjwrbrJpzSXt = P_1;
			mrFjeebVKriUbgXRGutfolfPxaOm = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + qYkUUnVDSKgmudQBZjwrbrJpzSXt + ", controllerId = " + P_0);
			yAFKgfmSqcdzYvwLywJEIeWPEynEA();
		}

		internal void ioVJltJbvZsnQwQxlbVHGzyzlvSA()
		{
			if (!bondJaLnZSGAYCgYHeLxRFHOsRYFA)
			{
				return;
			}
			if (lgKjgDjKanNlPioZFEmwHcbEPNcNA != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[i] = lgKjgDjKanNlPioZFEmwHcbEPNcNA(i);
				}
			}
			if (eRDBHNERuXRiYlaxFFymFOBxuuxjA != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.buttonValues[j] = eRDBHNERuXRiYlaxFFymFOBxuuxjA(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					ucqtfsuOTseRsybfPGjEFawPmfNK.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return;
			}
			lgKjgDjKanNlPioZFEmwHcbEPNcNA = callback;
			if (!bondJaLnZSGAYCgYHeLxRFHOsRYFA)
			{
				bondJaLnZSGAYCgYHeLxRFHOsRYFA = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return;
			}
			eRDBHNERuXRiYlaxFFymFOBxuuxjA = callback;
			if (!bondJaLnZSGAYCgYHeLxRFHOsRYFA)
			{
				bondJaLnZSGAYCgYHeLxRFHOsRYFA = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementName);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementId);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				ucqtfsuOTseRsybfPGjEFawPmfNK.buttonValues[index] = false;
				ucqtfsuOTseRsybfPGjEFawPmfNK.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementName);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (base.enabled)
			{
				int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementId);
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
