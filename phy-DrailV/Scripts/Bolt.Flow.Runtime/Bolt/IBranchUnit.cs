using System;
using Ludiq;

namespace Bolt
{
	[TypeIconPriority]
	public interface IBranchUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		ControlInput enter { get; }
	}
}
