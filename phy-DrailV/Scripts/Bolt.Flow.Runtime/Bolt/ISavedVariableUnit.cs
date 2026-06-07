using System;
using Ludiq;

namespace Bolt
{
	public interface ISavedVariableUnit : IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
	}
}
