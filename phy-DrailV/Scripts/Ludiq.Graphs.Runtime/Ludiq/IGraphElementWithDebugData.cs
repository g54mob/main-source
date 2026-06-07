using System;

namespace Ludiq
{
	public interface IGraphElementWithDebugData : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		IGraphElementDebugData CreateDebugData();
	}
}
