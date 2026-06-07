using System;
using System.Linq;
using Ludiq;

namespace Bolt
{
	[UnitCategory("Nesting")]
	[UnitOrder(1)]
	[UnitTitle("Input")]
	public sealed class GraphInput : Unit
	{
		public override bool canDefine => base.graph != null;

		protected override void Definition()
		{
			isControlRoot = true;
			foreach (ControlInputDefinition item in base.graph.validPortDefinitions.OfType<ControlInputDefinition>())
			{
				ControlOutput(item.key);
			}
			foreach (ValueInputDefinition item2 in base.graph.validPortDefinitions.OfType<ValueInputDefinition>())
			{
				string key = item2.key;
				Type type = item2.type;
				ValueOutput(type, key, delegate(Flow flow)
				{
					SuperUnit parent = flow.stack.GetParent<SuperUnit>();
					if (flow.enableDebug)
					{
						IUnitDebugData elementDebugData = flow.stack.GetElementDebugData<IUnitDebugData>(parent);
						elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
						elementDebugData.lastInvokeTime = EditorTimeBinding.time;
					}
					flow.stack.ExitParentElement();
					parent.EnsureDefined();
					object value = flow.GetValue(parent.valueInputs[key], type);
					flow.stack.EnterParentElement(parent);
					return value;
				});
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
