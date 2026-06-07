using System.Diagnostics;
using Assets.Scripts.Flight;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class InputBasedActivatorScript : PartModifierScript<InputBasedActivatorData>, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		private delegate void UpdateStateDelegate(bool state);

		private IInputController _input;

		private UpdateStateDelegate _updateState;

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_input = GetInputController();
			int activationTarget = base.Data.ActivationTarget;
			if (activationTarget == -1)
			{
				_updateState = ActivateStage;
			}
			else if (activationTarget == 0)
			{
				_updateState = UpdatePartActivationState;
			}
			else if (activationTarget == -7)
			{
				_updateState = ExplodePart;
			}
			else if (activationTarget < -1)
			{
				_updateState = UpdateHeadingLockState;
			}
			else
			{
				_updateState = UpdateActivationGroupState;
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			IInputController input = _input;
			if (input == null || !input.Active)
			{
				return;
			}
			float num = base.Data.RangeStart;
			float num2 = base.Data.RangeEnd;
			if (num > num2)
			{
				float num3 = num;
				num = num2;
				num2 = num3;
			}
			float value = _input.Value;
			bool flag = num <= value && value <= num2;
			bool currentState = base.Data.CurrentState;
			switch (base.Data.UpdateMethod)
			{
			case InputBasedActivatorData.ActivatorUpdateMethod.OneTime:
				if (flag != currentState)
				{
					_updateState(flag);
					RemoveModifier();
				}
				break;
			case InputBasedActivatorData.ActivatorUpdateMethod.OnChange:
				if (flag != currentState)
				{
					_updateState(flag);
				}
				break;
			case InputBasedActivatorData.ActivatorUpdateMethod.Continuous:
				_updateState(flag);
				break;
			default:
				UnityEngine.Debug.LogError($"ActivatorUpdateMethod '{base.Data.UpdateMethod}' is not currently supported.");
				RemoveModifier();
				break;
			}
			base.Data.CurrentState = flag;
		}

		private void ActivateStage(bool state)
		{
			base.PartScript.CommandPod?.ActivateStage();
		}

		private void ExplodePart(bool state)
		{
			base.PartScript.BodyScript.ExplodePart(base.PartScript, 1f);
		}

		[Conditional("DEBUG")]
		private void Log(string message)
		{
		}

		private void RemoveModifier()
		{
			base.Data.RemoveModifier();
		}

		private void UpdateActivationGroupState(bool state)
		{
			CraftControls craftControls = base.PartScript.CommandPod?.Controls;
			if (craftControls == null)
			{
				return;
			}
			int activationTarget = base.Data.ActivationTarget;
			bool activationGroup = craftControls.GetActivationGroup(activationTarget);
			switch (base.Data.ActivationType)
			{
			case InputBasedActivatorData.ActivatorType.Activate:
				if (state && !activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: true);
				}
				else if (!state && activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: false);
				}
				break;
			case InputBasedActivatorData.ActivatorType.ActivateOnly:
				if (state && !activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: true);
				}
				break;
			case InputBasedActivatorData.ActivatorType.Deactivate:
				if (state && activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: false);
				}
				else if (!state && !activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: true);
				}
				break;
			case InputBasedActivatorData.ActivatorType.DeactivateOnly:
				if (state && activationGroup)
				{
					craftControls.SetActivationGroup(activationTarget, state: false);
				}
				break;
			case InputBasedActivatorData.ActivatorType.Toggle:
				craftControls.SetActivationGroup(activationTarget, !activationGroup);
				break;
			default:
				UnityEngine.Debug.LogError($"ActivationType '{base.Data.ActivationType}' is not currently supported.");
				RemoveModifier();
				break;
			}
		}

		private void UpdateHeadingLockState(bool state)
		{
			if (!base.PartScript.CraftScript.CraftNode.IsPlayer)
			{
				return;
			}
			NavSphereIndicatorType? navSphereIndicatorType = null;
			navSphereIndicatorType = base.Data.ActivationTarget switch
			{
				-3 => NavSphereIndicatorType.VelocityPrograde, 
				-4 => NavSphereIndicatorType.VelocityRetrograde, 
				-5 => NavSphereIndicatorType.Target, 
				-6 => NavSphereIndicatorType.ManeuverNode, 
				_ => null, 
			};
			InputBasedActivatorData.ActivatorType activationType = base.Data.ActivationType;
			INavSphere navSphere = FlightSceneScript.Instance.FlightControls.NavSphere;
			if ((state && activationType == InputBasedActivatorData.ActivatorType.Activate) || (state && activationType == InputBasedActivatorData.ActivatorType.ActivateOnly) || (!state && activationType == InputBasedActivatorData.ActivatorType.Deactivate))
			{
				if (!navSphereIndicatorType.HasValue)
				{
					navSphere.LockCurrentHeading();
				}
				else
				{
					navSphere.LockedIndicator = navSphereIndicatorType.Value;
				}
			}
			else if ((!state && activationType == InputBasedActivatorData.ActivatorType.Activate) || (state && activationType == InputBasedActivatorData.ActivatorType.DeactivateOnly) || (state && activationType == InputBasedActivatorData.ActivatorType.Deactivate))
			{
				navSphere.UnlockHeading();
			}
			else
			{
				if (activationType != InputBasedActivatorData.ActivatorType.Toggle)
				{
					return;
				}
				if (!navSphereIndicatorType.HasValue)
				{
					if (navSphere.HeadingLocked)
					{
						navSphere.UnlockHeading();
					}
					else
					{
						navSphere.LockCurrentHeading();
					}
				}
				else if (navSphere.LockedIndicator == navSphereIndicatorType)
				{
					navSphere.UnlockHeading();
				}
				else
				{
					navSphere.LockedIndicator = navSphereIndicatorType;
				}
			}
		}

		private void UpdatePartActivationState(bool state)
		{
			bool activated = base.PartScript.Data.Activated;
			switch (base.Data.ActivationType)
			{
			case InputBasedActivatorData.ActivatorType.Activate:
				if (state && !activated)
				{
					base.PartScript.Activate();
				}
				else if (!state && activated)
				{
					base.PartScript.Deactivate();
				}
				break;
			case InputBasedActivatorData.ActivatorType.ActivateOnly:
				if (state && !activated)
				{
					base.PartScript.Activate();
				}
				break;
			case InputBasedActivatorData.ActivatorType.Deactivate:
				if (state && activated)
				{
					base.PartScript.Deactivate();
				}
				else if (!state && !activated)
				{
					base.PartScript.Activate();
				}
				break;
			case InputBasedActivatorData.ActivatorType.DeactivateOnly:
				if (state && activated)
				{
					base.PartScript.Deactivate();
				}
				break;
			case InputBasedActivatorData.ActivatorType.Toggle:
				if (activated)
				{
					base.PartScript.Deactivate();
				}
				else
				{
					base.PartScript.Activate();
				}
				break;
			default:
				UnityEngine.Debug.LogError($"ActivationType '{base.Data.ActivationType}' is not currently supported.");
				RemoveModifier();
				break;
			}
		}
	}
}
