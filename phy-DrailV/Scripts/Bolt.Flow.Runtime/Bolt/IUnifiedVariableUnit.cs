using System;
using Ludiq;

namespace Bolt
{
	public interface IUnifiedVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		VariableKind kind { get; }

		ValueInput name { get; }
	}
}
