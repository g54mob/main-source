using System;
using Ludiq;

namespace Bolt
{
	public interface INesterUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester
	{
	}
}
