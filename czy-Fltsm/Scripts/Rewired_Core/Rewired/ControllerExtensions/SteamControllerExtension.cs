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
		private class CpBzLufKaNegxbuXZKdWdjAppWVAb : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal CJXUmiLvpFlpNNBFCOdGmuebRFyv;

			public CpBzLufKaNegxbuXZKdWdjAppWVAb(ISteamControllerInternal P_0)
			{
				CJXUmiLvpFlpNNBFCOdGmuebRFyv = P_0;
			}
		}

		private CpBzLufKaNegxbuXZKdWdjAppWVAb sxuIxMesqxWHgFaQSCyharZAPCebb;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new CpBzLufKaNegxbuXZKdWdjAppWVAb(P_0))
		{
			FkUdkFInSONDqxhjfntEpmpxSnQrA();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			FkUdkFInSONDqxhjfntEpmpxSnQrA();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.ShowBindingPanel();
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
				sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.SetHapticPulse(targePad, durationSeconds);
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
				sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return sxuIxMesqxWHgFaQSCyharZAPCebb.CJXUmiLvpFlpNNBFCOdGmuebRFyv.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			sxuIxMesqxWHgFaQSCyharZAPCebb = source as CpBzLufKaNegxbuXZKdWdjAppWVAb;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void FkUdkFInSONDqxhjfntEpmpxSnQrA()
		{
		}
	}
}
