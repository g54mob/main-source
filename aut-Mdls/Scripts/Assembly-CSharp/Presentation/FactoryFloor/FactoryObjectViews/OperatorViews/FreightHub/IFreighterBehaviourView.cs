using Data.FactoryFloor.Freighter;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public interface IFreighterBehaviourView
	{
		void Enter(IFreighterObjectStateBehaviour freighterObjectStateBehaviour, FreighterObject freighterObject, FreighterView freighterView);

		void Exit();

		void Update();
	}
}
