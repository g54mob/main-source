using System;
using Ludiq;

namespace Bolt
{
	[UnitSurtitle("Save")]
	public sealed class GetSavedVariable : GetVariableUnit, ISavedVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		FlowGraph IUnit.graph => base.graph;

		public GetSavedVariable()
		{
		}

		public GetSavedVariable(string defaultName)
			: base(defaultName)
		{
		}

		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Saved;
		}
	}
}
