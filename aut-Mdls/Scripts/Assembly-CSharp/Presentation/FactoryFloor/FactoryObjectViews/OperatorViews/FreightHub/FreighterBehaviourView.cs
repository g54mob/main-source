using Data.FactoryFloor.Freighter;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public abstract class FreighterBehaviourView<T> : IFreighterBehaviourView where T : IFreighterObjectStateBehaviour
	{
		protected T _behaviour;

		protected FreighterObject _freighter;

		protected FreighterView _view;

		public virtual void Enter(IFreighterObjectStateBehaviour freighterObjectStateBehaviour, FreighterObject freighterObject, FreighterView freighterView)
		{
			_behaviour = (T)freighterObjectStateBehaviour;
			_freighter = freighterObject;
			_view = freighterView;
		}

		public abstract void Exit();

		public abstract void Update();
	}
}
