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
		private class INwzDnGosgeguFZqJJwtvxOqkHn : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal JtddwdWoEihQalMyoihkBmtwPoq;

			public INwzDnGosgeguFZqJJwtvxOqkHn(ISteamControllerInternal internalController)
			{
				JtddwdWoEihQalMyoihkBmtwPoq = internalController;
			}
		}

		private INwzDnGosgeguFZqJJwtvxOqkHn QhiXIzSBnzSGaWwDVddQlyhdvkF;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq;

		internal SteamControllerExtension(ISteamControllerInternal internalController)
			: base(new INwzDnGosgeguFZqJJwtvxOqkHn(internalController))
		{
			SdmfoteCDVoXNaSlWEvRMBbwmDy();
		}

		private SteamControllerExtension(SteamControllerExtension source)
			: base(source)
		{
			SdmfoteCDVoXNaSlWEvRMBbwmDy();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = 2145684952;
					while (true)
					{
						switch (num ^ 0x7FE48DD9)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = 2145684955;
					}
				}
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.ShowBindingPanel();
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
				QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.SetHapticPulse(targePad, durationSeconds);
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
				QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.JtddwdWoEihQalMyoihkBmtwPoq.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			QhiXIzSBnzSGaWwDVddQlyhdvkF = source as INwzDnGosgeguFZqJJwtvxOqkHn;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void SdmfoteCDVoXNaSlWEvRMBbwmDy()
		{
		}
	}
}
