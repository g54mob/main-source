using System;
using Ludiq;

namespace Bolt
{
	public interface INesterStateTransition : IStateTransition, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IConnection<IState, IState>, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester
	{
	}
}
