using System;
using Ludiq;

namespace Bolt
{
	public interface IEventUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphEventListener
	{
		bool coroutine { get; }
	}
}
