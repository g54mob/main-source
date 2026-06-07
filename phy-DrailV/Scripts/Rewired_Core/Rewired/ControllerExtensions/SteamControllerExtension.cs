using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class LhvoWFSmzzRrZtaAlJXNwIAXAJUM : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal OycxZVARbirRVuKUjhEkElHaJFqA;

			public LhvoWFSmzzRrZtaAlJXNwIAXAJUM(ISteamControllerInternal P_0)
			{
				OycxZVARbirRVuKUjhEkElHaJFqA = P_0;
			}
		}

		private LhvoWFSmzzRrZtaAlJXNwIAXAJUM HXvQzPApsqliDaJnhjuqaWlQGmel;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new LhvoWFSmzzRrZtaAlJXNwIAXAJUM(P_0))
		{
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.ShowBindingPanel();
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
				HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.SetHapticPulse(targePad, durationSeconds);
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
				HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return HXvQzPApsqliDaJnhjuqaWlQGmel.OycxZVARbirRVuKUjhEkElHaJFqA.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			HXvQzPApsqliDaJnhjuqaWlQGmel = source as LhvoWFSmzzRrZtaAlJXNwIAXAJUM;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void TlzckGoQDITHcUYaslQXPQBOhTwq()
		{
		}
	}
}
