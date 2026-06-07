using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class ERHLaYdduuhIRIeLUEzbsxDqgoWq : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal MmPmVEPzFgoepfaRJzlfrmjknUxF;

			public ERHLaYdduuhIRIeLUEzbsxDqgoWq(ISteamControllerInternal P_0)
			{
				MmPmVEPzFgoepfaRJzlfrmjknUxF = P_0;
			}
		}

		private ERHLaYdduuhIRIeLUEzbsxDqgoWq yCyChceueIEQKplQTBgUsnUHFatR;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new ERHLaYdduuhIRIeLUEzbsxDqgoWq(P_0))
		{
			ZMywzfSWtEUEVFlqbljjaquNFVu();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			ZMywzfSWtEUEVFlqbljjaquNFVu();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.ShowBindingPanel();
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.SetHapticPulse(targePad, durationSeconds);
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yCyChceueIEQKplQTBgUsnUHFatR.MmPmVEPzFgoepfaRJzlfrmjknUxF.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			yCyChceueIEQKplQTBgUsnUHFatR = source as ERHLaYdduuhIRIeLUEzbsxDqgoWq;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void ZMywzfSWtEUEVFlqbljjaquNFVu()
		{
		}
	}
}
