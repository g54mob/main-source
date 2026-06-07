public interface IIncrementalSimulation
{
	void Registered(UIRegistry? registry);

	void Unregistered();

	void OnUpdateSimulation(float deltaTime);
}
