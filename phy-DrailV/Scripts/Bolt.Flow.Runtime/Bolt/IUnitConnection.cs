using System;
using Ludiq;

namespace Bolt
{
	public interface IUnitConnection : IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		new FlowGraph graph { get; }
	}
}
