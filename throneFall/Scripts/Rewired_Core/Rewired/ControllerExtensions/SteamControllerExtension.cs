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
		private class nnnUaYxAbRttgHgExyDnbVhVdEOX : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal bHdyZOVvqBkcOgjAgYBfkHNJvBtn;

			public nnnUaYxAbRttgHgExyDnbVhVdEOX(ISteamControllerInternal P_0)
			{
				bHdyZOVvqBkcOgjAgYBfkHNJvBtn = P_0;
			}
		}

		private nnnUaYxAbRttgHgExyDnbVhVdEOX DVCEMqyKtvUtfoBPcHCIdpcwPIrW;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new nnnUaYxAbRttgHgExyDnbVhVdEOX(P_0))
		{
			gjaGBjBdJGLStRKgVqPbzkYRMlJLA();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			gjaGBjBdJGLStRKgVqPbzkYRMlJLA();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.ShowBindingPanel();
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
				DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.SetHapticPulse(targePad, durationSeconds);
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
				DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return DVCEMqyKtvUtfoBPcHCIdpcwPIrW.bHdyZOVvqBkcOgjAgYBfkHNJvBtn.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			DVCEMqyKtvUtfoBPcHCIdpcwPIrW = source as nnnUaYxAbRttgHgExyDnbVhVdEOX;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void gjaGBjBdJGLStRKgVqPbzkYRMlJLA()
		{
		}
	}
}
