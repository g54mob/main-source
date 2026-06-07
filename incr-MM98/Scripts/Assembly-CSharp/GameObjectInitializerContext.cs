using UnityEngine;

public class GameObjectInitializerContext : InitializerContext<GameObject>
{
	public GameObjectInitializerContext SetActive()
	{
		return SetActive(active: true);
	}

	public GameObjectInitializerContext SetInactive()
	{
		return SetActive(active: false);
	}

	public GameObjectInitializerContext SetActive(bool active)
	{
		Target.SetActive(active);
		return this;
	}
}
