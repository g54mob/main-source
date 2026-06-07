using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int jkLPSmUeXMdSVHNHasZjPGUYHswMA;

		private Func<int, float> cXbsbSeuvxBLmIJJmVusNlordKNH;

		private Func<int, bool> bssnDYTWnPkUjZnnqTJwvgYAGYQeA;

		private bool kwSlBvQsEITkdWTSckwbsvMfRxno;

		private Guid bMgybboQDjUjYMLVnNHjVVwmDprj;

		public int sourceControllerId => jkLPSmUeXMdSVHNHasZjPGUYHswMA;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Guid.Empty;
				}
				return bMgybboQDjUjYMLVnNHjVVwmDprj;
			}
		}

		internal CustomController(mqPhMngUOCoKlpBKyQYRthlEEQXL P_0)
			: this(P_0.aPkIxRmZmsXulBxCxpKtjCFNdFhI, P_0.eWLAyERXGypSzNqxHYnGoyfVmLEm, P_0.XGbLzThtLsuZPPsuLihTCkFECnHGA, P_0.hPmyndiXkJrvbzgToNVRHpfzSoBO, P_0.EqfmgsMFrzzIlxYrBIQejdXRTHTO, P_0.cemhyouVznfmflbwfaEFmtkJtirL, P_0.oUdwtjKckScokjAYAyVwamJCaTqI, P_0.iZrPzmqRbzHAVyYufnkhwYySQigO, P_0.RPofuoVXVweopJJOFZyqJsKDWnMIA, P_0.PayEJivmCQGkMfwbYfCXcSXDsnzxb, null, new ControllerDataUpdater(P_0.hPmyndiXkJrvbzgToNVRHpfzSoBO, P_0.iZrPzmqRbzHAVyYufnkhwYySQigO, P_0.RPofuoVXVweopJJOFZyqJsKDWnMIA, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			jkLPSmUeXMdSVHNHasZjPGUYHswMA = P_1;
			bMgybboQDjUjYMLVnNHjVVwmDprj = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + jkLPSmUeXMdSVHNHasZjPGUYHswMA + ", controllerId = " + P_0);
			jcuaGkxKxwRQhPfLTgjWpYLcOGCK();
		}

		internal void tiVXVcOoctHMEhKKWwEDjvyLJHQxA()
		{
			if (!kwSlBvQsEITkdWTSckwbsvMfRxno)
			{
				return;
			}
			if (cXbsbSeuvxBLmIJJmVusNlordKNH != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[i] = cXbsbSeuvxBLmIJJmVusNlordKNH(i);
				}
			}
			if (bssnDYTWnPkUjZnnqTJwvgYAGYQeA != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.buttonValues[j] = bssnDYTWnPkUjZnnqTJwvgYAGYQeA(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					vAJlxjrsCepUBGzroHjWcArmXQkU.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return;
			}
			cXbsbSeuvxBLmIJJmVusNlordKNH = callback;
			if (!kwSlBvQsEITkdWTSckwbsvMfRxno)
			{
				kwSlBvQsEITkdWTSckwbsvMfRxno = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return;
			}
			bssnDYTWnPkUjZnnqTJwvgYAGYQeA = callback;
			if (!kwSlBvQsEITkdWTSckwbsvMfRxno)
			{
				kwSlBvQsEITkdWTSckwbsvMfRxno = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementName);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementId);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				vAJlxjrsCepUBGzroHjWcArmXQkU.buttonValues[index] = false;
				vAJlxjrsCepUBGzroHjWcArmXQkU.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementName);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (base.enabled)
			{
				int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementId);
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
