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
		private class AVahEfWdHeWeIEjMoariYcuzBgD : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal TUphApSariRaKqPAJwGvysDpiSY;

			public AVahEfWdHeWeIEjMoariYcuzBgD(ISteamControllerInternal internalController)
			{
				TUphApSariRaKqPAJwGvysDpiSY = internalController;
			}
		}

		private AVahEfWdHeWeIEjMoariYcuzBgD WVeuvvGVKxuwIVofyhIJOpLcDjb;

		private Joystick joystick
		{
			get
			{
				return GetController<Joystick>();
			}
		}

		internal ISteamControllerInternal internalController
		{
			get
			{
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY;
			}
		}

		internal SteamControllerExtension(ISteamControllerInternal internalController)
			: base(new AVahEfWdHeWeIEjMoariYcuzBgD(internalController))
		{
			YJaAHaimrHWIfKrgfWxeihnqrcza();
		}

		private SteamControllerExtension(SteamControllerExtension source)
			: base(source)
		{
			YJaAHaimrHWIfKrgfWxeihnqrcza();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = 579331227;
					while (true)
					{
						switch (num ^ 0x2287E49A)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return string.Empty;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = 579331224;
					}
				}
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = -998048813;
					while (true)
					{
						switch (num ^ -998048815)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return Vector2.zero;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = -998048816;
					}
				}
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = -182875896;
					while (true)
					{
						switch (num ^ -182875894)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return Vector2.zero;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = -182875893;
					}
				}
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.ShowBindingPanel();
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x21F2C4FA ^ 0x21F2C4F8)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.SetHapticPulse(targePad, durationSeconds);
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = -1249492905;
					while (true)
					{
						switch (num ^ -1249492906)
						{
						case 3:
							break;
						case 1:
							ReInput.CheckInitialized(_reInputId);
							num = -1249492908;
							continue;
						case 2:
							return;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.SetHapticPulse(targePad, durationMicroSeconds);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = -849076621;
					while (true)
					{
						switch (num ^ -849076622)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = -849076622;
					}
				}
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return WVeuvvGVKxuwIVofyhIJOpLcDjb.TUphApSariRaKqPAJwGvysDpiSY.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			WVeuvvGVKxuwIVofyhIJOpLcDjb = source as AVahEfWdHeWeIEjMoariYcuzBgD;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void YJaAHaimrHWIfKrgfWxeihnqrcza()
		{
		}
	}
}
