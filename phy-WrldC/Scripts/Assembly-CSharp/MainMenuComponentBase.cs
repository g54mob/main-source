using UnityEngine;

public abstract class MainMenuComponentBase : MonoBehaviour
{
	protected abstract void InternalOnSpawnCreationStartingHandler();

	protected abstract void InternalOnSpawnCreationEndingHandler();

	public void OnSpawnCreationStartingHandler()
	{
		if (base.gameObject.activeInHierarchy)
		{
			InternalOnSpawnCreationStartingHandler();
		}
	}

	public void OnSpawnCreationEndingHandler()
	{
		if (base.gameObject.activeInHierarchy)
		{
			InternalOnSpawnCreationEndingHandler();
		}
	}
}
