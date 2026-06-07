using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnButtonInput : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "Update";

		[DoNotSerialize]
		[PortLabel("Name")]
		public ValueInput buttonName { get; private set; }

		[DoNotSerialize]
		public ValueInput action { get; private set; }

		protected override void Definition()
		{
			base.Definition();
			buttonName = ValueInput("buttonName", string.Empty);
			action = ValueInput("action", PressState.Down);
		}

		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			string value = flow.GetValue<string>(buttonName);
			PressState value2 = flow.GetValue<PressState>(action);
			switch (value2)
			{
			case PressState.Down:
				return Input.GetButtonDown(value);
			case PressState.Up:
				return Input.GetButtonUp(value);
			case PressState.Hold:
				return Input.GetButton(value);
			default:
				throw new UnexpectedEnumValueException<PressState>(value2);
			}
		}
	}
}
