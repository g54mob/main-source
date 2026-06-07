using System;
using Ludiq;

namespace Bolt
{
	public interface IObjectVariableUnit : IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
	}
}
