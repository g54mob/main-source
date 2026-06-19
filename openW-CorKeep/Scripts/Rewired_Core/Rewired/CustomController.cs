using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int ppNyKnuFrMQKfeUrzVUUTJOfAzwn;

		private Func<int, float> otdkkREHNtLNKzAltAYDWVoYwuHI;

		private Func<int, bool> vVmVHVzWPVhKRoKNpGKZHkYnRZKsA;

		private bool kZAWDwuEeKDuHbjevgnYezWGnspyA;

		private Guid zockXiWnlvUKyrndcYdAABgBODvK;

		public int sourceControllerId => ppNyKnuFrMQKfeUrzVUUTJOfAzwn;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Guid.Empty;
				}
				return zockXiWnlvUKyrndcYdAABgBODvK;
			}
		}

		internal CustomController(mMNvwuYacSiZPCcCtPVisdtjTKJD P_0)
			: this(P_0.mqiYkAYAhyJmNmgmakdIgXfgwjpf, P_0.mVbaHtfyiAKBowTOjHxkzdqUxUW, P_0.BErYfWBtnmsJfuVSYhosBZHxsmVV, P_0.rLkPryMvIVTnTIjtvBUqOyjQQrXM, P_0.ITxWwbyjVtkYJUqTGJBJcNFokEXq, P_0.oGmrUpIPjfrADOhUgrfqxNessFtK, P_0.uXtaZeecSWilMSjaDflFzhHfdxkR, P_0.uwptlhSDRbsEdFMQmYlSbnmtCfwz, P_0.JjgiitdApkRoLilwSQpJtyIguXGL, P_0.XiVTfDNqcUekfBDcZZogRVEHcefC, null, new ControllerDataUpdater(P_0.rLkPryMvIVTnTIjtvBUqOyjQQrXM, P_0.uwptlhSDRbsEdFMQmYlSbnmtCfwz, P_0.JjgiitdApkRoLilwSQpJtyIguXGL, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			ppNyKnuFrMQKfeUrzVUUTJOfAzwn = P_1;
			zockXiWnlvUKyrndcYdAABgBODvK = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + ppNyKnuFrMQKfeUrzVUUTJOfAzwn + ", controllerId = " + P_0);
			vXguOrVHQgZdRgenIvihyjDDIBEO();
		}

		internal void flDnNlkPWbTQkpbmTXPywdioEIOaA()
		{
			if (!kZAWDwuEeKDuHbjevgnYezWGnspyA)
			{
				return;
			}
			if (otdkkREHNtLNKzAltAYDWVoYwuHI != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[i] = otdkkREHNtLNKzAltAYDWVoYwuHI(i);
				}
			}
			if (vVmVHVzWPVhKRoKNpGKZHkYnRZKsA != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonValues[j] = vVmVHVzWPVhKRoKNpGKZHkYnRZKsA(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return;
			}
			otdkkREHNtLNKzAltAYDWVoYwuHI = callback;
			if (!kZAWDwuEeKDuHbjevgnYezWGnspyA)
			{
				kZAWDwuEeKDuHbjevgnYezWGnspyA = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return;
			}
			vVmVHVzWPVhKRoKNpGKZHkYnRZKsA = callback;
			if (!kZAWDwuEeKDuHbjevgnYezWGnspyA)
			{
				kZAWDwuEeKDuHbjevgnYezWGnspyA = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementName);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementId);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonValues[index] = false;
				zfVdfqKDuqZKjafBdqgdinjRQNeGb.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementName);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (base.enabled)
			{
				int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementId);
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
