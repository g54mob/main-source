using System;
using Ludiq;

namespace Bolt
{
	[UnitSurtitle("Graph")]
	public sealed class IsGraphVariableDefined : IsVariableDefinedUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		FlowGraph IUnit.graph => base.graph;

		public IsGraphVariableDefined()
		{
		}

		public IsGraphVariableDefined(string defaultName)
			: base(defaultName)
		{
		}

		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Graph(flow.stack);
		}
	}
}
