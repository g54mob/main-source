using System;
using Ludiq;

namespace Bolt
{
	[TypeIconPriority]
	public interface ISelectUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		ValueOutput selection { get; }
	}
}
