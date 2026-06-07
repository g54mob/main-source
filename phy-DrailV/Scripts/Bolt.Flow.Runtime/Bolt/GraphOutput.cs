using System;
using System.Linq;

namespace Bolt
{
	[UnitCategory("Nesting")]
	[UnitOrder(2)]
	[UnitTitle("Output")]
	public sealed class GraphOutput : Unit
	{
		public override bool canDefine => base.graph != null;

		protected override void Definition()
		{
			isControlRoot = true;
			foreach (ControlOutputDefinition item in base.graph.validPortDefinitions.OfType<ControlOutputDefinition>())
			{
				string key = item.key;
				ControlInput(key, delegate(Flow flow)
				{
					SuperUnit parent = flow.stack.GetParent<SuperUnit>();
					flow.stack.ExitParentElement();
					parent.EnsureDefined();
					return parent.controlOutputs[key];
				});
			}
			foreach (ValueOutputDefinition item2 in base.graph.validPortDefinitions.OfType<ValueOutputDefinition>())
			{
				string key2 = item2.key;
				Type type = item2.type;
				ValueInput(type, key2);
			}
		}

		protected override void AfterDefine()
		{
			base.graph.onPortDefinitionsChanged += Define;
		}

		protected override void BeforeUndefine()
		{
			base.graph.onPortDefinitionsChanged -= Define;
		}
	}
}
