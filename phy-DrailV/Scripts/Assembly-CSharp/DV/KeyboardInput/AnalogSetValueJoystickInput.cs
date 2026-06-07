using DV.CabControls;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class AnalogSetValueJoystickInput : AKeyboardInput
	{
		public ActionReference action;

		public bool compressZeroToOne;

		private ControlImplBase control;

		private float lastValue = -1f;

		private float lastValueForDisplay = -1f;

		public override bool FixedUpdateTick => false;

		private void Start()
		{
			control = GetComponent<ControlImplBase>();
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			action.Initialize(interiorControlsManager);
			lastValue = InputManager.NewPlayer.GetAxis(action.id);
			if (compressZeroToOne)
			{
				lastValue = lastValue * 0.5f + 0.5f;
			}
		}

		public override void Tick(float deltaTime)
		{
			if (!control || !PlayerCanReach())
			{
				return;
			}
			float num;
			if (InputManager.Actions.pausedInBackground)
			{
				num = lastValue;
			}
			else
			{
				num = InputManager.NewPlayer.GetAxis(action.id);
				if (compressZeroToOne)
				{
					num = num * 0.5f + 0.5f;
				}
			}
			bool flag = Mathf.Abs(num - lastValue) > 0.1f;
			if (action.CanMoveOverridableBaseControl && (flag || control.LastSetValueSource == ControlImplBase.SetValueSource.Analog))
			{
				control.SetValue(num, ControlImplBase.SetValueSource.Analog);
				if (Mathf.Abs(num - lastValueForDisplay) > 0.040000003f)
				{
					RailDriverDisplayDV.DisplayNotification(new DV.RailDriver.RailDriver.DisplayBuffer(Mathf.RoundToInt(control.Value * 100f)));
					lastValueForDisplay = num;
				}
				lastValue = num;
			}
		}
	}
}
