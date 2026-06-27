using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class JiQDdSwbTlYIbMHszYOCgJQHwkGA : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal TseensImHDHEkxPShSqYHtfShDRD;

			public JiQDdSwbTlYIbMHszYOCgJQHwkGA(ISteamControllerInternal P_0)
			{
				TseensImHDHEkxPShSqYHtfShDRD = P_0;
			}
		}

		private JiQDdSwbTlYIbMHszYOCgJQHwkGA tKXdEVfRtbvoJrSKxPotYOQxgBXl;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new JiQDdSwbTlYIbMHszYOCgJQHwkGA(P_0))
		{
			SvfqbSqeFYjmLPxrGQsEHPaGNYfG();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			SvfqbSqeFYjmLPxrGQsEHPaGNYfG();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.ShowBindingPanel();
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
				tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.SetHapticPulse(targePad, durationSeconds);
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
				tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return tKXdEVfRtbvoJrSKxPotYOQxgBXl.TseensImHDHEkxPShSqYHtfShDRD.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			tKXdEVfRtbvoJrSKxPotYOQxgBXl = source as JiQDdSwbTlYIbMHszYOCgJQHwkGA;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void SvfqbSqeFYjmLPxrGQsEHPaGNYfG()
		{
		}
	}
}
