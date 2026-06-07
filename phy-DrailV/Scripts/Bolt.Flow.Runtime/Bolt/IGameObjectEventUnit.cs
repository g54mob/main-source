using System;
using Ludiq;

namespace Bolt
{
	public interface IGameObjectEventUnit : IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphEventListener
	{
		Type MessageListenerType { get; }
	}
}
