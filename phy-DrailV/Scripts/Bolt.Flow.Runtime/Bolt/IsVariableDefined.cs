using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitTitle("Has Variable")]
	public sealed class IsVariableDefined : UnifiedVariableUnit
	{
		[DoNotSerialize]
		[PortLabel("Defined")]
		[PortLabelHidden]
		[PortKey("isDefined")]
		public ValueOutput isVariableDefined { get; private set; }

		protected override void Definition()
		{
			base.Definition();
			isVariableDefined = ValueOutput("isDefined", IsDefined);
			Requirement(base.name, isVariableDefined);
			if (base.kind == VariableKind.Object)
			{
				Requirement(base.@object, isVariableDefined);
			}
		}

		private bool IsDefined(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			switch (base.kind)
			{
			case VariableKind.Flow:
				return flow.variables.IsDefined(value);
			case VariableKind.Graph:
				return Variables.Graph(flow.stack).IsDefined(value);
			case VariableKind.Object:
				return Variables.Object(flow.GetValue<GameObject>(base.@object)).IsDefined(value);
			case VariableKind.Scene:
				return Variables.Scene(flow.stack.scene).IsDefined(value);
			case VariableKind.Application:
				return Variables.Application.IsDefined(value);
			case VariableKind.Saved:
				return Variables.Saved.IsDefined(value);
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
		}
	}
}
