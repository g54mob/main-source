using System;
using Ludiq;

namespace Bolt
{
	public interface ISceneVariableUnit : IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
	}
}
