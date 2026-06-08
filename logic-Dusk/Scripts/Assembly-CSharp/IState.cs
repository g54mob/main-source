public interface IState
{
	string StateId { get; }

	event ChangeStateDelegate ChangeState;

	void Update();

	void EnterState();

	void ExitState();
}
