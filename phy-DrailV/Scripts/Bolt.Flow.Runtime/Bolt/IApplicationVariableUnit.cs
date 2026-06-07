using System;
using Ludiq;

namespace Bolt
{
	[TypeIconPriority]
	public interface IApplicationVariableUnit : IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
	}
}
