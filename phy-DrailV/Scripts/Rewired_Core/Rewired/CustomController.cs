using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int YjGLwFPmrwSzCJzUxSuMEdnMATfaA;

		private Func<int, float> fkEgWpTxCagAChYiCHEOzomihOShA;

		private Func<int, bool> PYmAzigojvALtdrxBHXoxUlblpVab;

		private bool YkZtOIraPzcvDSIGKHddzGugKUcn;

		private Guid AIzKFppczrKwcfHsGKZydmrnUHsF;

		public int sourceControllerId => YjGLwFPmrwSzCJzUxSuMEdnMATfaA;

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return AIzKFppczrKwcfHsGKZydmrnUHsF;
			}
		}

		internal CustomController(nglusGJXMgLJZiPxWsApahSkNMcB P_0)
			: this(P_0.PoDKkXNZKOoZdyxGaKFAmJnBpZjC, P_0.wBSTLjhpdiHRmEEkZOkkaQsqkqoP, P_0.oIiVjZhLzkOGISxkurAyuQUtJZSA, P_0.HXvQzPApsqliDaJnhjuqaWlQGmel, P_0.LhuRrfwUPjAvVlMldFuefsAzsjXEb, P_0.nboorIDxkYmnlTDtCiHMGRkezuKF, P_0.mYDXvdZiNyDHBPtnhOwhGhxHttvt, P_0.MXkNViMtSkCXhVAqsNOXkqgyAXmH, P_0.JUTanEOVBHbwVHQHKsAHkvZOyxmj, P_0.OzUAkEAoBUdTsTYzBynAISLBcyKN, null, new ControllerDataUpdater(P_0.HXvQzPApsqliDaJnhjuqaWlQGmel, P_0.MXkNViMtSkCXhVAqsNOXkqgyAXmH, P_0.JUTanEOVBHbwVHQHKsAHkvZOyxmj, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			YjGLwFPmrwSzCJzUxSuMEdnMATfaA = P_1;
			AIzKFppczrKwcfHsGKZydmrnUHsF = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + YjGLwFPmrwSzCJzUxSuMEdnMATfaA + ", controllerId = " + P_0);
			pggOEkcvhxxBuBDIbrJuSafugeIK();
		}

		internal void TTmlLbNbxWaHEgWSRqkIYAtJGFFkA()
		{
			if (!YkZtOIraPzcvDSIGKHddzGugKUcn)
			{
				return;
			}
			if (fkEgWpTxCagAChYiCHEOzomihOShA != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[i] = fkEgWpTxCagAChYiCHEOzomihOShA(i);
				}
			}
			if (PYmAzigojvALtdrxBHXoxUlblpVab != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonValues[j] = PYmAzigojvALtdrxBHXoxUlblpVab(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			fkEgWpTxCagAChYiCHEOzomihOShA = callback;
			if (!YkZtOIraPzcvDSIGKHddzGugKUcn)
			{
				YkZtOIraPzcvDSIGKHddzGugKUcn = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			PYmAzigojvALtdrxBHXoxUlblpVab = callback;
			if (!YkZtOIraPzcvDSIGKHddzGugKUcn)
			{
				YkZtOIraPzcvDSIGKHddzGugKUcn = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementName);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementId);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonValues[index] = false;
				fcpRkkeLOqieJylVwWSUEEJhOXpJ.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementName);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (base.enabled)
			{
				int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementId);
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
