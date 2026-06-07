using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnKeyboardInput : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "Update";

		[DoNotSerialize]
		public ValueInput key { get; private set; }

		[DoNotSerialize]
		public ValueInput action { get; private set; }

		protected override void Definition()
		{
			base.Definition();
			key = ValueInput("key", KeyCode.Space);
			action = ValueInput("action", PressState.Down);
		}

		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			KeyCode value = flow.GetValue<KeyCode>(key);
			PressState value2 = flow.GetValue<PressState>(action);
			switch (value2)
			{
			case PressState.Down:
				return Input.GetKeyDown(value);
			case PressState.Up:
				return Input.GetKeyUp(value);
			case PressState.Hold:
				return Input.GetKey(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
