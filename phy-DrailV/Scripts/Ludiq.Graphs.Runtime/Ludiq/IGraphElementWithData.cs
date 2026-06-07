using System;

namespace Ludiq
{
	public interface IGraphElementWithData : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		IGraphElementData CreateData();
	}
}
