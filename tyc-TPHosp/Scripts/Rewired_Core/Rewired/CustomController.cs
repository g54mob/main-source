using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int ZiORqANABZSuNUOOeVLvtvptERP;

		private Func<int, float> ykOJCaXwqTsJJkouFRrrWuqVAKa;

		private Func<int, bool> QzwerrhgLGVEqlatOXiXujbMCdxz;

		private bool LEJcpTridOopCXkSXrMKUwuTsQW;

		private Guid PklKNibBDUZkzudeZtiBAWsAYiS;

		public int sourceControllerId => ZiORqANABZSuNUOOeVLvtvptERP;

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return PklKNibBDUZkzudeZtiBAWsAYiS;
			}
		}

		internal CustomController(ygvylZNreBYIQhhVJVOfRApPZNs data)
			: this(data.AVJCjGFlvmvUQprbQtbNLTqidXD, data.zgKNDgvLPNgKlLScSDXNeXiBIqQM, data.brEBbktrLGXDVNcjjSmlHrEpLlf, data.UdjCSEOPIRsTIjnUgCiPBbbzKWS, data.MLmLjcwSbKBkEhcbqGJFmLCQUrjT, data.uayuHNVIEnEtqEVbNsJfjAqVsbm, data.ptRLmiXIjTICISXbyEHEtIvywjV, data.JDyNNdOScJLywOHcbmcaJdgZeIE, data.CtHmgLQvreiWMWnBZZLsTLZpuCY, data.JZChcDKathrMbEPpYYUdEtVaKyqX, null, new ControllerDataUpdater(data.UdjCSEOPIRsTIjnUgCiPBbbzKWS, data.JDyNNdOScJLywOHcbmcaJdgZeIE, data.CtHmgLQvreiWMWnBZZLsTLZpuCY, null))
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Custom, hardwareTypeGuid, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			ZiORqANABZSuNUOOeVLvtvptERP = sourceControllerId;
			PklKNibBDUZkzudeZtiBAWsAYiS = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + ZiORqANABZSuNUOOeVLvtvptERP + ", controllerId = " + controllerId);
			guKElsGLCmgnAbWmxWZxRdTPwg();
		}

		internal void GVyzsgBcNtCKXvPCYEVnrvtmvVp()
		{
			if (!LEJcpTridOopCXkSXrMKUwuTsQW)
			{
				return;
			}
			if (ykOJCaXwqTsJJkouFRrrWuqVAKa != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[i] = ykOJCaXwqTsJJkouFRrrWuqVAKa(i);
				}
			}
			if (QzwerrhgLGVEqlatOXiXujbMCdxz != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonValues[j] = QzwerrhgLGVEqlatOXiXujbMCdxz(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			ykOJCaXwqTsJJkouFRrrWuqVAKa = callback;
			if (!LEJcpTridOopCXkSXrMKUwuTsQW)
			{
				LEJcpTridOopCXkSXrMKUwuTsQW = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			QzwerrhgLGVEqlatOXiXujbMCdxz = callback;
			if (!LEJcpTridOopCXkSXrMKUwuTsQW)
			{
				LEJcpTridOopCXkSXrMKUwuTsQW = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementName);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementId);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonValues[index] = false;
				ebxBmtwxyRprAbJBnnRdvbVCKbL.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementName);
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (base.enabled)
			{
				int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementId);
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
