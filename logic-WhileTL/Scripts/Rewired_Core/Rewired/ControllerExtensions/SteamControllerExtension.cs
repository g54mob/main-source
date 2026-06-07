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
		private class qkfNVIyLTfqTpGeiQnyldzxIFTAC : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal hfaFsOsbllsUheQyvbLodDWGjDDXA;

			public qkfNVIyLTfqTpGeiQnyldzxIFTAC(ISteamControllerInternal P_0)
			{
				hfaFsOsbllsUheQyvbLodDWGjDDXA = P_0;
			}
		}

		private qkfNVIyLTfqTpGeiQnyldzxIFTAC yGdZHAmdUeDYveLTSINOCvUHtMoHA;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new qkfNVIyLTfqTpGeiQnyldzxIFTAC(P_0))
		{
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.ShowBindingPanel();
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
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.SetHapticPulse(targePad, durationSeconds);
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
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return yGdZHAmdUeDYveLTSINOCvUHtMoHA.hfaFsOsbllsUheQyvbLodDWGjDDXA.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			yGdZHAmdUeDYveLTSINOCvUHtMoHA = source as qkfNVIyLTfqTpGeiQnyldzxIFTAC;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void gUxczTgMdKUcYRnCXamteWaCXJodc()
		{
		}
	}
}
