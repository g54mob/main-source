namespace Restory.Infrastructure.StateMachine.States.Interfaces
{
	public interface IUpdatableState
	{
		void OnUpdate(float deltaTime);
	}
}
