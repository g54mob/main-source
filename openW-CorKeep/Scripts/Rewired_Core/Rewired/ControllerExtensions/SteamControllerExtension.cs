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
		private class WJLNTdZoENPyNBSfQdmjslOOjFRt : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal QMJrqnnvHBLtxoojHbulnlgWcGyT;

			public WJLNTdZoENPyNBSfQdmjslOOjFRt(ISteamControllerInternal P_0)
			{
				QMJrqnnvHBLtxoojHbulnlgWcGyT = P_0;
			}
		}

		private WJLNTdZoENPyNBSfQdmjslOOjFRt gBuDjHgIOvSXIhqkVZtGogFbDFkab;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new WJLNTdZoENPyNBSfQdmjslOOjFRt(P_0))
		{
			FKKIuOBigKsZYCFPcralzazCLoQR();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			FKKIuOBigKsZYCFPcralzazCLoQR();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.ShowBindingPanel();
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
				gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.SetHapticPulse(targePad, durationSeconds);
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
				gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return gBuDjHgIOvSXIhqkVZtGogFbDFkab.QMJrqnnvHBLtxoojHbulnlgWcGyT.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			gBuDjHgIOvSXIhqkVZtGogFbDFkab = source as WJLNTdZoENPyNBSfQdmjslOOjFRt;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void FKKIuOBigKsZYCFPcralzazCLoQR()
		{
		}
	}
}
