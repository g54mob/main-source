using System;
using Ludiq;

namespace Bolt
{
	[UnitSurtitle("Application")]
	public sealed class IsApplicationVariableDefined : IsVariableDefinedUnit, IApplicationVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		FlowGraph IUnit.graph => base.graph;

		public IsApplicationVariableDefined()
		{
		}

		public IsApplicationVariableDefined(string defaultName)
			: base(defaultName)
		{
		}

		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Application;
		}
	}
}
