using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int UKfRtSYKCUfHCcwYOFbYSDtsQypr;

		private Func<int, float> PuHRRqgvuzOOnbZKWtPVZxZHxfMh;

		private Func<int, bool> WcEumqFLiTxLcoNuIEhVjulaoEFN;

		private bool TYsQcFYJRYNvkpJZEQMGgjxXIzaR;

		private Guid AzGRdBgcYdfFBpvUNizWPqDIlVcp;

		public int sourceControllerId => UKfRtSYKCUfHCcwYOFbYSDtsQypr;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Guid.Empty;
				}
				return AzGRdBgcYdfFBpvUNizWPqDIlVcp;
			}
		}

		internal CustomController(ZAhIiLqVPOrLiMeHCaikprQgoMUO P_0)
			: this(P_0.ZcEBhdemvwOCgqjJBpVKxyqbtteP, P_0.JwjLLuDBXcEDqqxmzootgfIjacFGA, P_0.qTBrYjzzAkUmEklvtRhaUQcwhOSg, P_0.IMMSYPqanXNmgGIWEzfqZNUFzqKR, P_0.daVSXIGJerjTyUbuxeeTvxmxZLOy, P_0.ZhGQJQcUijwpsIDbVBWymaPvbbsY, P_0.BTDTuJYzrAhVtSPVqSuXasocaefd, P_0.LBJpICysyvATKaHrVySYjkFcjgzEb, P_0.aoKZHSPHWeAfqeoNrVCTcwtnCpRpA, P_0.imIiOAjGTUBdRVMcuhyaKlyGFzws, null, new ControllerDataUpdater(P_0.IMMSYPqanXNmgGIWEzfqZNUFzqKR, P_0.LBJpICysyvATKaHrVySYjkFcjgzEb, P_0.aoKZHSPHWeAfqeoNrVCTcwtnCpRpA, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			UKfRtSYKCUfHCcwYOFbYSDtsQypr = P_1;
			AzGRdBgcYdfFBpvUNizWPqDIlVcp = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + UKfRtSYKCUfHCcwYOFbYSDtsQypr + ", controllerId = " + P_0);
			CpCVLCxmguYfwaCGdHOlxVqCpGLv();
		}

		internal void QjpUuIOUxpAXXfQDeFektwVlkJRV()
		{
			if (!TYsQcFYJRYNvkpJZEQMGgjxXIzaR)
			{
				return;
			}
			if (PuHRRqgvuzOOnbZKWtPVZxZHxfMh != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[i] = PuHRRqgvuzOOnbZKWtPVZxZHxfMh(i);
				}
			}
			if (WcEumqFLiTxLcoNuIEhVjulaoEFN != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonValues[j] = WcEumqFLiTxLcoNuIEhVjulaoEFN(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return;
			}
			PuHRRqgvuzOOnbZKWtPVZxZHxfMh = callback;
			if (!TYsQcFYJRYNvkpJZEQMGgjxXIzaR)
			{
				TYsQcFYJRYNvkpJZEQMGgjxXIzaR = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return;
			}
			WcEumqFLiTxLcoNuIEhVjulaoEFN = callback;
			if (!TYsQcFYJRYNvkpJZEQMGgjxXIzaR)
			{
				TYsQcFYJRYNvkpJZEQMGgjxXIzaR = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementName);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementId);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonValues[index] = false;
				EnxeINdfRsPNEfNsWCRpkeCWEWlpA.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementName);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (base.enabled)
			{
				int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementId);
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
