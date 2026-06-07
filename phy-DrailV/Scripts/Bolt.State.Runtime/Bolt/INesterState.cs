using System;
using Ludiq;

namespace Bolt
{
	public interface INesterState : IState, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphElementWithData, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester
	{
	}
}
