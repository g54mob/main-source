using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	internal class SteamControllerInternal : ISteamControllerInternal
	{
		private static Dictionary<string, ulong> actionSetHandles;

		private static Dictionary<string, ulong> analogActionHandles;

		private static Dictionary<string, ulong> digitalActionHandles;

		private static Dictionary<ulong, string> actionSetHandles_reverse;

		private static Dictionary<ulong, string> analogActionHandles_reverse;

		private static Dictionary<ulong, string> digitalActionHandles_reverse;

		public readonly ulong handle;

		private qnWQnCnVygzqNYsMYlQfTwIvNew[] dqmrJRMDHrgVRCWhxLmISAqgTmqJ;

		private List<SteamControllerActionOrigin> originsList;

		private ReadOnlyCollection<SteamControllerActionOrigin> originsList_readOnly;

		public int MaxActionSourceCount
		{
			get
			{
				return 8;
			}
		}

		public bool IsConnected
		{
			get
			{
				return dkQevYhLCTSvcEXLRGhdxOJRjkCt.vCKeEMAiJdnzxbQcHJralfKexaeQ(handle);
			}
		}

		public static void SetActionSetHandles(Dictionary<string, ulong> handles)
		{
			if (handles != null && handles.Count != 0)
			{
				actionSetHandles = handles;
				actionSetHandles_reverse = CollectionTools.CreateInverseDictionary(handles);
			}
		}

		public static void SetAnalogActionHandles(Dictionary<string, ulong> handles)
		{
			if (handles != null && handles.Count != 0)
			{
				analogActionHandles = handles;
				analogActionHandles_reverse = CollectionTools.CreateInverseDictionary(handles);
			}
		}

		public static void SetDigitalActionHandles(Dictionary<string, ulong> handles)
		{
			if (handles != null && handles.Count != 0)
			{
				digitalActionHandles = handles;
				digitalActionHandles_reverse = CollectionTools.CreateInverseDictionary(handles);
			}
		}

		public SteamControllerInternal(ulong handle)
		{
			this.handle = handle;
			dqmrJRMDHrgVRCWhxLmISAqgTmqJ = new qnWQnCnVygzqNYsMYlQfTwIvNew[8];
			originsList = new List<SteamControllerActionOrigin>(8);
			originsList_readOnly = new ReadOnlyCollection<SteamControllerActionOrigin>(originsList);
		}

		public string GetActionSetName(ulong handle)
		{
			return GetNameForHandle(actionSetHandles_reverse, handle);
		}

		public string GetDigitalActionName(ulong handle)
		{
			return GetNameForHandle(digitalActionHandles_reverse, handle);
		}

		public string GetAnalogActionName(ulong handle)
		{
			return GetNameForHandle(analogActionHandles_reverse, handle);
		}

		public ulong GetActionSetHandle(ref string actionSetName)
		{
			return GetHandleForName(actionSetHandles, ref actionSetName);
		}

		public ulong GetDigitalActionHandle(ref string actionName)
		{
			return GetHandleForName(digitalActionHandles, ref actionName);
		}

		public ulong GetAnalogActionHandle(ref string actionName)
		{
			return GetHandleForName(analogActionHandles, ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (actionHandle == 0)
			{
				return default(Vector2);
			}
			try
			{
				rcKBMqpHhHnQuCIOFQemglsFLir analogActionData = dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetAnalogActionData(handle, actionHandle);
				if (!analogActionData.mylVxQwGzyDnJRwPXDacpEXVLyQ)
				{
					return default(Vector2);
				}
				return new Vector2(analogActionData.dwcksDbKbKTxMUqRtRLrDcsbnSa, analogActionData.PPbqRHFiecbEhHnZAAzNKBrPASea);
			}
			catch
			{
				return default(Vector2);
			}
		}

		public Vector2 GetAnalogActionValue(ref string actionName)
		{
			ulong analogActionHandle = GetAnalogActionHandle(ref actionName);
			return GetAnalogActionValue(analogActionHandle);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (actionHandle == 0)
			{
				return false;
			}
			try
			{
				OBfMVxddjuYzEvCThHAmoKGjAhu digitalActionData = dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetDigitalActionData(handle, actionHandle);
				Debug.Log(actionHandle + " state = " + digitalActionData.OHKaNQazTUbEGxiZwVLMFnKgAJLa + " active = " + digitalActionData.mylVxQwGzyDnJRwPXDacpEXVLyQ);
				return digitalActionData.mylVxQwGzyDnJRwPXDacpEXVLyQ && digitalActionData.OHKaNQazTUbEGxiZwVLMFnKgAJLa;
			}
			catch
			{
				return false;
			}
		}

		public bool GetDigitalActionValue(ref string actionName)
		{
			ulong digitalActionHandle = GetDigitalActionHandle(ref actionName);
			return GetDigitalActionValue(digitalActionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (actionSetHandle == 0)
			{
				return false;
			}
			try
			{
				dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.ActivateActionSet(handle, actionSetHandle);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SetActiveActionSet(ref string actionSetName)
		{
			ulong actionSetHandle = GetActionSetHandle(ref actionSetName);
			return SetActiveActionSet(actionSetHandle);
		}

		public ulong GetActiveActionSetHandle()
		{
			return dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetCurrentActionSet(handle);
		}

		public string GetActiveActionSetName()
		{
			return GetNameForHandle(actionSetHandles_reverse, dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetCurrentActionSet(handle));
		}

		public void ShowBindingPanel()
		{
			dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.ShowBindingPanel(handle);
		}

		public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
		{
			if (durationSeconds < 0f)
			{
				durationSeconds = 0f;
			}
			dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.TriggerHapticPulse(handle, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
		}

		public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
		{
			dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.TriggerHapticPulse(handle, (uint)triggerPad, durationMicroSeconds);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
		{
			return GetDigitalActionOrigins(GetHandleForName(actionSetHandles, ref actionSetName), GetHandleForName(digitalActionHandles, ref actionName));
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			originsList.Clear();
			if (actionSetHandle == 0 || actionHandle == 0)
			{
				return originsList_readOnly;
			}
			int digitalActionOrigins = dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetDigitalActionOrigins(handle, actionSetHandle, actionHandle, dqmrJRMDHrgVRCWhxLmISAqgTmqJ);
			for (int i = 0; i < digitalActionOrigins; i++)
			{
				originsList.Add((SteamControllerActionOrigin)dqmrJRMDHrgVRCWhxLmISAqgTmqJ[i]);
			}
			return originsList_readOnly;
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
		{
			return GetAnalogActionOrigins(GetHandleForName(actionSetHandles, ref actionSetName), GetHandleForName(analogActionHandles, ref actionName));
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			originsList.Clear();
			if (actionSetHandle == 0 || actionHandle == 0)
			{
				return originsList_readOnly;
			}
			int analogActionOrigins = dkQevYhLCTSvcEXLRGhdxOJRjkCt.ControllerManager.GetAnalogActionOrigins(handle, actionSetHandle, actionHandle, dqmrJRMDHrgVRCWhxLmISAqgTmqJ);
			for (int i = 0; i < analogActionOrigins; i++)
			{
				originsList.Add((SteamControllerActionOrigin)dqmrJRMDHrgVRCWhxLmISAqgTmqJ[i]);
			}
			return originsList_readOnly;
		}

		private ulong GetHandleForName(Dictionary<string, ulong> dict, ref string name)
		{
			if (dict == null || string.IsNullOrEmpty(name))
			{
				return 0uL;
			}
			ulong value;
			if (!dict.TryGetValue(name, out value))
			{
				return 0uL;
			}
			return value;
		}

		private string GetNameForHandle(Dictionary<ulong, string> dict, ulong handle)
		{
			if (dict == null || handle == 0)
			{
				return string.Empty;
			}
			string value;
			if (!dict.TryGetValue(handle, out value))
			{
				return string.Empty;
			}
			return value;
		}
	}
}
