using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Persistence;
using UnityEngine;

[Serializable]
public class WorldPersistentData
{
	public PersistentPropertiesData PersistentProperties;

	private readonly float DistanceTravelled;

	private readonly CommunityPersistentData[] Communities;

	private readonly UIPersistentData UI;

	private readonly GameWorldPersistentData GameWorld;

	private readonly LimitPersistentData ResourceLimits = new LimitPersistentData();

	private readonly CameraPersistentData Camera;

	private readonly GameTimePersistentData GameTime = new GameTimePersistentData();

	private readonly UnlockableManager.PersistentData Unlockables;

	[OptionalField(VersionAdded = 3)]
	private readonly ActorDescriptorPersistentData ActorDescriptorPersistentData = ActorDescriptor.ToPersistentData();

	private readonly StoryManager.PersistentData Story = new StoryManager.PersistentData();

	[OptionalField(VersionAdded = 3)]
	private readonly RadioMessagesManager.PersistentData RadioMessages = new RadioMessagesManager.PersistentData();

	private GameStatsManager.PersistentData GameStats = new GameStatsManager.PersistentData();

	[OptionalField(VersionAdded = 3)]
	private readonly NotificationHandler.PersistentData NotificationsHandler = new NotificationHandler.PersistentData();

	private readonly EnergyGridPersistentData[] EnergyGrids;

	private WorldPersistentData()
	{
		DistanceTravelled = GameManager.GameStatsManager.GameData.DistanceTravelled;
		GameWorld = new GameWorldPersistentData(GameManager.WorldManager.World);
		Communities = ReturnCommunityPersistentData();
		GameWorld.PopulateReferences();
		UI = new UIPersistentData(GameManager.UIManager);
		Unlockables = UnlockableManager.GetPersistentData();
		Camera = new CameraPersistentData(CameraController.Instance);
		InventoryPersistentData.PopulateAllReferences();
	}

	public static bool TryCreateInstance(out WorldPersistentData instance, PersistentPropertiesData persistentPropertiesData)
	{
		try
		{
			PersistenceLifeCycle.OnPrePersistenceAction(PersistenceState.Saving);
			instance = new WorldPersistentData();
			instance.SetPersistentProperties(persistentPropertiesData);
			return true;
		}
		catch (Exception innerException)
		{
			Debug.LogException(new PersistenceException("Failed to create WorldPersistentData instance!", innerException));
			PersistenceLifeCycle.OnPostPersistenceAction();
			instance = null;
			return false;
		}
	}

	public bool TrySerialize(out byte[] data)
	{
		try
		{
			data = Serialize();
			return true;
		}
		catch (Exception innerException)
		{
			Debug.LogException(new PersistenceException("Failed to serialize WorldPersistentData!", innerException));
			data = null;
			return false;
		}
	}

	public byte[] Serialize()
	{
		if (PersistenceLifeCycle.State == PersistenceState.Saving)
		{
			try
			{
				return PersistenceLifeCycle.Serialize(this);
			}
			finally
			{
				PersistenceLifeCycle.OnPostPersistenceAction();
			}
		}
		Debug.LogException(new PersistenceException($"Trying to serialize WorldPersistentData instance, but PersistenceLifeCycle.State is '{PersistenceLifeCycle.State}' and not 'Saving'"));
		return null;
	}

	public void Restore()
	{
		GameManager.WorldManager.SetWorldDistanceTravelled(DistanceTravelled);
		if (NotificationsHandler != null)
		{
			NotificationsHandler.Restore();
		}
		GameTime?.Restore();
		Unlockables?.Restore();
		Story?.Restore();
		ActorDescriptorPersistentData?.Restore();
		GameWorld.Restore();
		RestoreCommunities();
		GameWorld.RepositionLandmarks();
		LoadingScreen.AddTask(delegate
		{
			InventoryPersistentData.RestoreAllReferences();
			LandmarkMooringPointPersistentData.RestoreMooredBoats();
			RestoreCommunityReferences();
			GameWorld.RestoreReferences();
			EnergyGridManager.RestoreReferences();
			Story?.RestoreReferences();
			RadioMessages?.RestoreReferences();
			UI.Restore(GameManager.UIManager);
			ResourceLimits.Restore();
			if (Camera != null)
			{
				Camera.Restore(CameraController.Instance);
			}
			if (GameStats == null)
			{
				GameStats = new GameStatsManager.PersistentData();
			}
			GameStats.Restore();
			PersistenceLifeCycle.OnPostPersistenceAction();
		});
	}

	public void SetPersistentProperties(PersistentPropertiesData persistentProperties)
	{
		PersistentProperties = persistentProperties;
	}

	private CommunityPersistentData[] ReturnCommunityPersistentData()
	{
		IReadOnlyList<Community> communities = Community.Communities;
		int count = communities.Count;
		CommunityPersistentData[] array = new CommunityPersistentData[communities.Count];
		for (int i = 0; i < count; i++)
		{
			array[i] = new CommunityPersistentData(communities[i]);
		}
		for (int j = 0; j < count; j++)
		{
			array[j].PopulateReferences();
		}
		return array;
	}

	private void RestoreCommunities()
	{
		int num = Communities.Length;
		for (int i = 0; i < num; i++)
		{
			Communities[i].Restore();
		}
	}

	private void RestoreCommunityReferences()
	{
		int num = Communities.Length;
		for (int i = 0; i < num; i++)
		{
			Communities[i].RestoreReferences();
		}
	}
}
