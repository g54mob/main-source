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
		private class IyKaSGmWpGISYUZCueUuWNlroQwy : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal USOxeOIDaEiFgbFEfRCmLaFtITBz;

			public IyKaSGmWpGISYUZCueUuWNlroQwy(ISteamControllerInternal P_0)
			{
				USOxeOIDaEiFgbFEfRCmLaFtITBz = P_0;
			}
		}

		private IyKaSGmWpGISYUZCueUuWNlroQwy ygpkKyhFdgxJTjuHzLzPAtwMMCVh;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new IyKaSGmWpGISYUZCueUuWNlroQwy(P_0))
		{
			HrPhBbuSDXvtLVdaICDeHhWjEdvm();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			HrPhBbuSDXvtLVdaICDeHhWjEdvm();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.ShowBindingPanel();
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
				ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.SetHapticPulse(targePad, durationSeconds);
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
				ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ygpkKyhFdgxJTjuHzLzPAtwMMCVh.USOxeOIDaEiFgbFEfRCmLaFtITBz.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			ygpkKyhFdgxJTjuHzLzPAtwMMCVh = source as IyKaSGmWpGISYUZCueUuWNlroQwy;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void HrPhBbuSDXvtLVdaICDeHhWjEdvm()
		{
		}
	}
}
