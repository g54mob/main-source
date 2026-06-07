using System;

namespace Ludiq
{
	public interface IGraphNesterElement : IGraphParentElement, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphParent, IGraphNester
	{
	}
}
