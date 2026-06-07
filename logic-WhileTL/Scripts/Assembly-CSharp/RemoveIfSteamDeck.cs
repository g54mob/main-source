using UnityEngine;

public class RemoveIfSteamDeck : ActiveComponent
{
	private void Awake()
	{
	}

	private void Check()
	{
		if (ActiveComponent.Model != null && ActiveComponent.Model.ReadyToPlay && Logic.IsSteamDeckRunning())
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (ActiveComponent._staticData != null)
		{
			Check();
		}
	}

	private void LateUpdate()
	{
		if (ActiveComponent._staticData != null)
		{
			Check();
		}
	}
}
