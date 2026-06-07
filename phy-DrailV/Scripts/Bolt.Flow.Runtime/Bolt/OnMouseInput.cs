using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseInput : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "Update";

		[DoNotSerialize]
		public ValueInput button { get; private set; }

		[DoNotSerialize]
		public ValueInput action { get; private set; }

		protected override void Definition()
		{
			base.Definition();
			button = ValueInput("button", MouseButton.Left);
			action = ValueInput("action", PressState.Down);
		}

		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			int value = (int)flow.GetValue<MouseButton>(button);
			PressState value2 = flow.GetValue<PressState>(action);
			switch (value2)
			{
			case PressState.Down:
				return Input.GetMouseButtonDown(value);
			case PressState.Up:
				return Input.GetMouseButtonUp(value);
			case PressState.Hold:
				return Input.GetMouseButton(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
