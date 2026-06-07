using System.Collections.Generic;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class WJLNTdZoENPyNBSfQdmjslOOjFRt : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal QMJrqnnvHBLtxoojHbulnlgWcGyT;

			public WJLNTdZoENPyNBSfQdmjslOOjFRt(ISteamControllerInternal P_0)
			{
			}
		}

		private WJLNTdZoENPyNBSfQdmjslOOjFRt gBuDjHgIOvSXIhqkVZtGogFbDFkab;

		private Joystick joystick => null;

		internal ISteamControllerInternal internalController => null;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			return 0uL;
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			return 0uL;
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			return 0uL;
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			return null;
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			return null;
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			return null;
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			return default(Vector2);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			return default(Vector2);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			return false;
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			return false;
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			return false;
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			return false;
		}

		public ulong GetActiveActionSetHandle()
		{
			return 0uL;
		}

		public string GetActiveActionSetName()
		{
			return null;
		}

		public void ShowBindingPanel()
		{
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			return null;
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			return null;
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			return null;
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			return null;
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private void FKKIuOBigKsZYCFPcralzazCLoQR()
		{
		}
	}
}
