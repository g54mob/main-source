using System;
using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitSurtitle("Object")]
	public sealed class SetObjectVariable : SetVariableUnit, IObjectVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput source { get; private set; }

		FlowGraph IUnit.graph => base.graph;

		public SetObjectVariable()
		{
		}

		public SetObjectVariable(string name)
			: base(name)
		{
		}

		protected override void Definition()
		{
			source = ValueInput<GameObject>("source", null).NullMeansSelf();
			base.Definition();
			Requirement(source, base.assign);
		}

		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Object(flow.GetValue<GameObject>(source));
		}
	}
}
