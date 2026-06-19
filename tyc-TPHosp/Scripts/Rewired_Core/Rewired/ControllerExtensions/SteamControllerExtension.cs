using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class ObdUOQUHLAaCQagGaKoubRQmPRoO : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal PUoxHYEnzUgcQSIRFKVdtvhmLPl;

			public ObdUOQUHLAaCQagGaKoubRQmPRoO(ISteamControllerInternal internalController)
			{
				PUoxHYEnzUgcQSIRFKVdtvhmLPl = internalController;
			}
		}

		private ObdUOQUHLAaCQagGaKoubRQmPRoO UdjCSEOPIRsTIjnUgCiPBbbzKWS;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl;

		internal SteamControllerExtension(ISteamControllerInternal internalController)
			: base(new ObdUOQUHLAaCQagGaKoubRQmPRoO(internalController))
		{
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}

		private SteamControllerExtension(SteamControllerExtension source)
			: base(source)
		{
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.ShowBindingPanel();
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
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.SetHapticPulse(targePad, durationSeconds);
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
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return UdjCSEOPIRsTIjnUgCiPBbbzKWS.PUoxHYEnzUgcQSIRFKVdtvhmLPl.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			UdjCSEOPIRsTIjnUgCiPBbbzKWS = source as ObdUOQUHLAaCQagGaKoubRQmPRoO;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
		{
		}
	}
}
