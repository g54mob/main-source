using Factory;

public interface IApp
{
	IScope Scope { get; }

	Game Game { get; }

	IInputState InputState { get; }

	PlayerActionController PlayerActionController { get; }

	void Start();

	void Tick(float absoluteTime, float deltaTime);

	void GameOpenedNotificationSetup();
}
