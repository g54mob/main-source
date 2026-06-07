using System;
using UnityEngine;

public class LevelModel : BaseModel, ICollectionItem
{
	public enum LevelPlace
	{
		Campaign = 0,
		Sandbox = 1,
		Tutorial = 2,
		Template = 3,
		Defender = 4,
		New = 5,
		User = 6,
		Workshop = 7,
		Test = 8
	}

	public enum LevelOverStatus
	{
		NotOver = 0,
		Successful = 1,
		SuccessfulWithCheat = 2,
		SuccessfulWithMod = 3,
		Failed = 4,
		BrainBlockDestroyed = 5
	}

	public enum RestrictedBlocks
	{
		None = 0,
		Flyers = 1
	}

	public const string NameChangedEvent = "LevelModel.NameChangedEvent";

	public const string BestTimeChangedEvent = "LevelModel.BestTimeChangedEvent";

	public const string NewLevelRecordsEvent = "LevelModel.NewLevelRecordsEvent";

	public const string CollectablesCountChangedEvent = "LevelModel.CollectablesCountChangedEvent";

	private string name;

	private float bestTime;

	private int goldCollectableCounter;

	private int silverCollectableCounter;

	public string Id { get; set; }

	public string SceneName { get; set; }

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			NotifyChange("LevelModel.NameChangedEvent");
		}
	}

	public string Description { get; set; }

	public bool IsBrainDestroyedGoal { get; set; }

	public bool HasDefenderZone { get; set; }

	public bool IsHidden { get; set; }

	public LevelPlace Place { get; set; }

	public bool IsSandboxWithGoal { get; set; }

	public bool IsThereCollectables { get; set; }

	public Vector3 Gravity { get; set; }

	public CreationModel DefenderCreationModel { get; set; }

	public string FilePath { get; set; }

	public DateTime FileLastModifiedDate { get; set; }

	public string HashSHA256 { get; set; }

	public LevelOverStatus LevelOverStatusEnum { get; set; }

	public RestrictedBlocks RestrictedBlocksEnum { get; set; }

	public float CurrentTime { get; set; }

	public LevelStatus LevelStatus { get; set; }

	public CustomLevelObjectsModel CustomLevelObjectsModel { get; private set; }

	public float BestTime
	{
		get
		{
			return bestTime;
		}
		set
		{
			bestTime = value;
			NotifyChange("LevelModel.BestTimeChangedEvent", this);
		}
	}

	public bool IsLevelCompleted
	{
		get
		{
			if (!(bestTime < float.PositiveInfinity))
			{
				if (LevelStatus != null)
				{
					return LevelStatus.LowestTimeRecords.NoneStarValue < float.PositiveInfinity;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsFirstTimeCompleted { get; set; }

	public bool IsLevelCheatable
	{
		get
		{
			if (Place == LevelPlace.Sandbox)
			{
				return !IsSandboxWithGoal;
			}
			return false;
		}
	}

	public int GoldCollectableTotal { get; set; }

	public int GoldCollectableCounter
	{
		get
		{
			return goldCollectableCounter;
		}
		set
		{
			goldCollectableCounter = value;
			NotifyChange("LevelModel.CollectablesCountChangedEvent");
		}
	}

	public int SilverCollectableTotal { get; set; }

	public int SilverCollectableCounter
	{
		get
		{
			return silverCollectableCounter;
		}
		set
		{
			silverCollectableCounter = value;
			NotifyChange("LevelModel.CollectablesCountChangedEvent");
		}
	}

	public bool IsPickedUpAllGoldCollectables
	{
		get
		{
			if (IsThereCollectables)
			{
				return GoldCollectableCounter == GoldCollectableTotal;
			}
			return false;
		}
	}

	public bool IsPickedUpAllSilverCollectables
	{
		get
		{
			if (IsThereCollectables)
			{
				return SilverCollectableCounter == SilverCollectableTotal;
			}
			return false;
		}
	}

	public LevelModel()
	{
		Id = Util.RandomString(4);
		IsBrainDestroyedGoal = false;
		HasDefenderZone = false;
		IsHidden = false;
		Place = LevelPlace.Campaign;
		IsSandboxWithGoal = false;
		IsThereCollectables = false;
		Gravity = Util.DefaultGravity;
		DefenderCreationModel = new CreationModel("", "", "");
		LevelOverStatusEnum = LevelOverStatus.NotOver;
		RestrictedBlocksEnum = RestrictedBlocks.None;
		CustomLevelObjectsModel = new CustomLevelObjectsModel();
		CurrentTime = 0f;
		BestTime = float.PositiveInfinity;
		GoldCollectableTotal = int.MaxValue;
		GoldCollectableCounter = 0;
		SilverCollectableTotal = int.MaxValue;
		SilverCollectableCounter = 0;
		IsFirstTimeCompleted = false;
		FileLastModifiedDate = DateTime.Now;
	}

	public void NotifyNewLevelRecords()
	{
		NotifyChange("LevelModel.NewLevelRecordsEvent", this);
	}

	public string GetId()
	{
		return Id;
	}
}
