using System;
using Ludiq;

namespace Bolt
{
	public interface IStateTransition : IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IConnection<IState, IState>
	{
		void Branch(Flow flow);

		void OnEnter(Flow flow);

		void OnExit(Flow flow);
	}
}
