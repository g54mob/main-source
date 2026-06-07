using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int tYHHCpDCDIyggdEAXoHbnvFQkkFd;

		private Func<int, float> wmkbncEzqeczXTqWJloMyyBdIfeRA;

		private Func<int, bool> lnhYaLGqFCoEWnmBHiaECcjOEDnj;

		private bool sGXANlNDjHUEvgXHZBBxFlIbxMac;

		private Guid lOdDtZkjGaGohdcAkWkNTqXsoXAjB;

		public int sourceControllerId => tYHHCpDCDIyggdEAXoHbnvFQkkFd;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Guid.Empty;
				}
				return lOdDtZkjGaGohdcAkWkNTqXsoXAjB;
			}
		}

		internal CustomController(ySKFuDcpZZqSGDRTHYdpwWAEQEmeA P_0)
			: this(P_0.oSttNjzSxlAlOhMXEYOREwyFifUr, P_0.sNGzxiChNzscGjgumLbuJkEXOkvs, P_0.HcoonNaYgnhyKzdarSfXlsSEvmzA, P_0.rYniVPfIzOVHCLGKPdelkGMlLcqU, P_0.AKwfAaDkpokCMTyHudUbAqaNVfwD, P_0.uwlFsUGdyabHAXNbKLJhPFTDJjGyA, P_0.mIqKjXXdpNDOJGTZbFFQoXwCeePxA, P_0.ikekJAfynwkkqKbmSDFwVJaGwEVd, P_0.VxfvLAGvUjKLWdGTqJRWZunFdynI, P_0.JedYMQqxBBBSzKqodufttUkatlMu, null, new ControllerDataUpdater(P_0.rYniVPfIzOVHCLGKPdelkGMlLcqU, P_0.ikekJAfynwkkqKbmSDFwVJaGwEVd, P_0.VxfvLAGvUjKLWdGTqJRWZunFdynI, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			tYHHCpDCDIyggdEAXoHbnvFQkkFd = P_1;
			lOdDtZkjGaGohdcAkWkNTqXsoXAjB = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + tYHHCpDCDIyggdEAXoHbnvFQkkFd + ", controllerId = " + P_0);
			rHrZhWmlidFfQIdUaELuLMacpKhFA();
		}

		internal void dUWBIKXavsOefswHnnzpGMLZFsrl()
		{
			if (!sGXANlNDjHUEvgXHZBBxFlIbxMac)
			{
				return;
			}
			if (wmkbncEzqeczXTqWJloMyyBdIfeRA != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[i] = wmkbncEzqeczXTqWJloMyyBdIfeRA(i);
				}
			}
			if (lnhYaLGqFCoEWnmBHiaECcjOEDnj != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonValues[j] = lnhYaLGqFCoEWnmBHiaECcjOEDnj(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return;
			}
			wmkbncEzqeczXTqWJloMyyBdIfeRA = callback;
			if (!sGXANlNDjHUEvgXHZBBxFlIbxMac)
			{
				sGXANlNDjHUEvgXHZBBxFlIbxMac = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return;
			}
			lnhYaLGqFCoEWnmBHiaECcjOEDnj = callback;
			if (!sGXANlNDjHUEvgXHZBBxFlIbxMac)
			{
				sGXANlNDjHUEvgXHZBBxFlIbxMac = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementName);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementId);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonValues[index] = false;
				jaSaHPudVtcyecnoPKkgZIAqgGJr.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementName);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (base.enabled)
			{
				int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementId);
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
