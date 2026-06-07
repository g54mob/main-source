using UnityEngine;

public class BuildingDevTools : MonoBehaviour
{
	public static bool AutoSpawnResources;

	public static bool InstantBuild;

	public static bool InstantUnlock;

	public void ToggleAutoSpawnResources(bool value)
	{
		AutoSpawnResources = value;
		Community.PlayerCommunity.UpdateBuildables();
	}

	public void ToggleInstantBuild(bool value)
	{
		InstantBuild = value;
		Community.PlayerCommunity.UpdateBuildables();
	}

	public void ToggleInstantUnlock(bool value)
	{
		InstantUnlock = value;
	}

	public void UnlockBuildables()
	{
		for (int i = 0; i < GameManager.Settings.BuildableSettings.Buildables.Length; i++)
		{
			Community.PlayerCommunity.Research.UnlockBuildable(GameManager.Settings.BuildableSettings.Buildables[i]);
		}
	}

	public void UnlockDecorations()
	{
		for (int i = 0; i < GameManager.Settings.BuildableSettings.Decorations.Length; i++)
		{
			GameManager.Settings.BuildableSettings.Decorations[i].Unlock();
		}
	}

	public void ToggleCursorProperties(CursorProperties cursorProperties)
	{
		if (GameManager.CursorManager.Properties == cursorProperties)
		{
			GameManager.CursorManager.Deactivate(cancelled: true);
		}
		else
		{
			GameManager.CursorManager.Activate(cursorProperties);
		}
	}

	public static bool TryAutoSpawnResources(CountedItemProperty[] resourcesToSpawn)
	{
		if (AutoSpawnResources)
		{
			Community playerCommunity = Community.PlayerCommunity;
			foreach (CountedItemProperty countedItemProperty in resourcesToSpawn)
			{
				for (int j = 0; j < countedItemProperty.Amount; j++)
				{
					if (!playerCommunity.SpawnItemToAvailableStorage(countedItemProperty.ItemProperties))
					{
						return false;
					}
				}
			}
			playerCommunity.ForceStorageLateUpdate();
		}
		return true;
	}
}
