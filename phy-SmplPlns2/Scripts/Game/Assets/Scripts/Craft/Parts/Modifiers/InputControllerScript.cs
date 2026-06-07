using System;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class InputControllerScript : PartModifierScript, IInputController
	{
		private Func<bool> _activateInput;

		private Func<float> _inputAxis;

		public bool Active { get; private set; }

		public bool Disabled { get; set; }

		public InputControllerData InputController { get; set; }

		public string InputId => InputController.Name;

		public float Value { get; private set; }

		public bool Visible { get; set; } = true;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.Default, 502);
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			if (InputController.InvertOnMirror)
			{
				InputController.Invert = !InputController.Invert;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused, -100);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = _activateInput();
			if (flag && _inputAxis != null)
			{
				float num = _inputAxis();
				if (InputController.Invert && InputController.InvertType == InvertType.Axis)
				{
					num = 0f - num;
				}
				if (num < 0f)
				{
					Value = (0f - num) * InputController.MinValue;
				}
				else
				{
					Value = num * InputController.MaxValue;
				}
				if (InputController.Invert && InputController.InvertType == InvertType.Output)
				{
					Value = 0f - Value;
				}
			}
			else if (InputController.ZeroOnDeactivate)
			{
				Value = 0f;
			}
			Active = flag;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_activateInput = base.PartScript.Aircraft.Controls.GetActivatorGetter(InputController.ActivationGroup, base.PartScript, valueIfZero: true);
			_inputAxis = base.PartScript.Aircraft.Controls.GetAxisGetter(InputController.Input, -1f, base.PartScript);
			return UniTask.CompletedTask;
		}
	}
}
