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
		private class dLgggygPnwjzisTyUcqIvgtrbQE : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal csrrZciKniGPhIdLdqKbRkBpbrD;

			public dLgggygPnwjzisTyUcqIvgtrbQE(ISteamControllerInternal internalController)
			{
				csrrZciKniGPhIdLdqKbRkBpbrD = internalController;
			}
		}

		private dLgggygPnwjzisTyUcqIvgtrbQE pjmDqcGcEdmXbvnkITKNjUFiEooD;

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
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD;
			}
		}

		internal SteamControllerExtension(ISteamControllerInternal internalController)
			: base(new dLgggygPnwjzisTyUcqIvgtrbQE(internalController))
		{
			dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
		}

		private SteamControllerExtension(SteamControllerExtension source)
			: base(source)
		{
			dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = 451689413;
					while (true)
					{
						switch (num ^ 0x1AEC3BC4)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return Vector2.zero;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = 451689414;
					}
				}
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = 2086796659;
					while (true)
					{
						switch (num ^ 0x7C61FD72)
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
						num = 2086796656;
					}
				}
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.ShowBindingPanel();
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x4B4B18A1 ^ 0x4B4B18A0)
					{
					case 2:
						continue;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.SetHapticPulse(targePad, durationSeconds);
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = 785253706;
					while (true)
					{
						switch (num ^ 0x2ECE054B)
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
						num = 785253707;
					}
				}
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return pjmDqcGcEdmXbvnkITKNjUFiEooD.csrrZciKniGPhIdLdqKbRkBpbrD.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			pjmDqcGcEdmXbvnkITKNjUFiEooD = source as dLgggygPnwjzisTyUcqIvgtrbQE;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void dFyvOnKBbTYzKLbxHBbiIGdcrpeH()
		{
		}
	}
}
