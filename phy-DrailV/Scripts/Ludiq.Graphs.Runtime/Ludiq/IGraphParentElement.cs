using System;

namespace Ludiq
{
	public interface IGraphParentElement : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphParent
	{
	}
}
