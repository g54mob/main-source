using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int foBKwGIjPbBuflEDbLWWJZfHQExE;

		private Func<int, float> oFxLgykGzKeEQBkTvKVXuQxmeBGxA;

		private Func<int, bool> xJwTHyNqfgXiPzMbfXqNakLFiAFl;

		private bool knGNQPKVYdxKNyCAfwfSjSJqToek;

		private Guid hisouLunNCWDceqLqbVIWejbjjkIA;

		public int sourceControllerId => foBKwGIjPbBuflEDbLWWJZfHQExE;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Guid.Empty;
				}
				return hisouLunNCWDceqLqbVIWejbjjkIA;
			}
		}

		internal CustomController(gMHrfNmlAthdFHvMbEMkuLiDfcMw P_0)
			: this(P_0.swafEdmNyLmEZtiSitfCaBMKYBwW, P_0.wrXIeaLrSNGBTjSpCTSdlsgYuOTM, P_0.TYrtdrpvBVIXbhEcMrvqZDKRLKMl, P_0.jsehdJggeeoLNNCBjPweCpcqSeSk, P_0.WGhiNOQWlUPYBFWdCWWVqcOGpCWL, P_0.yZgrbUaSfIUkHRuwwrgejxhOQLaR, P_0.yfnxcLKmsdErGCTAFkiDidAHlKjGA, P_0.qQvnuMklpIVmpUgocgsKpDvFGWhM, P_0.RQgyOdFZEFnEZdWMCwDRlVXMTVSb, P_0.XhiJBSvyWljVyMvzNQMmNKEtFTeg, null, new ControllerDataUpdater(P_0.jsehdJggeeoLNNCBjPweCpcqSeSk, P_0.qQvnuMklpIVmpUgocgsKpDvFGWhM, P_0.RQgyOdFZEFnEZdWMCwDRlVXMTVSb, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			foBKwGIjPbBuflEDbLWWJZfHQExE = P_1;
			hisouLunNCWDceqLqbVIWejbjjkIA = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + foBKwGIjPbBuflEDbLWWJZfHQExE + ", controllerId = " + P_0);
			blqnoKjqhVSIFnqRKLejmqEtdoFaA();
		}

		internal void hyZPOQSauMHfukHKBKIsuFfWjbTQ()
		{
			if (!knGNQPKVYdxKNyCAfwfSjSJqToek)
			{
				return;
			}
			if (oFxLgykGzKeEQBkTvKVXuQxmeBGxA != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[i] = oFxLgykGzKeEQBkTvKVXuQxmeBGxA(i);
				}
			}
			if (xJwTHyNqfgXiPzMbfXqNakLFiAFl != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.buttonValues[j] = xJwTHyNqfgXiPzMbfXqNakLFiAFl(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					rGVdhXruOTgLzoPtrwxfhKmroixX.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return;
			}
			oFxLgykGzKeEQBkTvKVXuQxmeBGxA = callback;
			if (!knGNQPKVYdxKNyCAfwfSjSJqToek)
			{
				knGNQPKVYdxKNyCAfwfSjSJqToek = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return;
			}
			xJwTHyNqfgXiPzMbfXqNakLFiAFl = callback;
			if (!knGNQPKVYdxKNyCAfwfSjSJqToek)
			{
				knGNQPKVYdxKNyCAfwfSjSJqToek = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementName);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementId);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				rGVdhXruOTgLzoPtrwxfhKmroixX.buttonValues[index] = false;
				rGVdhXruOTgLzoPtrwxfhKmroixX.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementName);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (base.enabled)
			{
				int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementId);
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
