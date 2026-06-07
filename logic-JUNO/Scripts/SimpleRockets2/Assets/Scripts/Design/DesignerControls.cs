using Assets.Scripts.DevConsole;
using Assets.Scripts.Input;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Input;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerControls
	{
		private ICraftScript _craftScript;

		private CraftControls _nullControls;

		private float _throttleIncrement;

		public CraftControls Controls
		{
			get
			{
				if (CommandPod != null && CommandPod.Controls != null)
				{
					return CommandPod.Controls;
				}
				return _nullControls;
			}
		}

		private ICommandPod CommandPod => _craftScript.PrimaryCommandPod;

		public DesignerControls()
		{
			_nullControls = new CraftControls(null, null);
		}

		public void ActivateStage()
		{
			if (CommandPod != null)
			{
				CommandPod.ActivateStage();
			}
		}

		public bool GetActivationGroupStatus(int activationGroup)
		{
			if (Controls != null)
			{
				return Controls.GetActivationGroup(activationGroup);
			}
			return false;
		}

		public void SetCraft(ICraftScript craftScript)
		{
			_craftScript = craftScript;
		}

		public void ToggleActivationGroup(int activationGroup)
		{
			if (Controls != null)
			{
				Controls.ToggleActivationGroup(activationGroup);
			}
		}

		public void Update(float timeStep)
		{
			if (_craftScript == null || Game.Instance.UserInterface.AnyDialogsOpen || DevConsoleManagerScript.IsConsoleOpen)
			{
				return;
			}
			IGameInputs inputs = Game.Instance.Inputs;
			InputWrapper.UpdateLastInput(inputs.Throttle);
			bool flag = InputWrapper.LastInputWasNormalAxis(inputs.Throttle);
			if (inputs.Throttle.Enabled && !flag)
			{
				_throttleIncrement = Mathf.Clamp(inputs.Throttle.GetAxis(), -1f, 1f);
			}
			float? controlInput = GetControlInput(inputs.Roll);
			if (controlInput.HasValue)
			{
				Controls.Roll = controlInput.Value;
			}
			float? controlInput2 = GetControlInput(inputs.Pitch);
			if (controlInput2.HasValue)
			{
				Controls.Pitch = controlInput2.Value;
			}
			float? controlInput3 = GetControlInput(inputs.Yaw);
			if (controlInput3.HasValue)
			{
				Controls.Yaw = controlInput3.Value;
			}
			if (inputs.Throttle.Enabled)
			{
				if (flag)
				{
					Controls.Throttle = inputs.Throttle.GetAxis();
				}
				else
				{
					Controls.Throttle += timeStep * _throttleIncrement;
				}
				Controls.Throttle = Mathf.Clamp01(Controls.Throttle);
			}
			if (inputs.ActivateStage.GetButtonDownIfEnabled())
			{
				ActivateStage();
			}
		}

		private float? GetControlInput(IGameInput input)
		{
			float? result = null;
			if (input.Enabled)
			{
				result = Mathf.Clamp(input.GetAxis(), -1f, 1f);
			}
			return result;
		}
	}
}
