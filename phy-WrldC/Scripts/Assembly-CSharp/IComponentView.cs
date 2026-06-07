public interface IComponentView
{
	void Initialize(Properties properties);

	void SetUpToAction();

	void SetComponentActive(bool isActive);

	void SetBlockDestroyed();

	void InitializeGizmos<T>(T componentModel) where T : ComponentModel;

	void SetGizmosVisibility(bool isVisible);

	void SetGizmosLayer(int layer);

	string GetComponentName();

	ComponentType GetComponentType();
}
