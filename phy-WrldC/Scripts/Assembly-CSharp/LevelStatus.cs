public class LevelStatus : ICollectionItem
{
	public enum StarType
	{
		Both = 0,
		Gold = 1,
		Silver = 2,
		None = 3
	}

	public class RecordsValues
	{
		public float NoneStarValue { get; set; }

		public float SilverStarValue { get; set; }

		public float GoldStarValue { get; set; }

		public float BothStarValue { get; set; }

		public string NoneCreationId { get; set; }

		public string SilverCreationId { get; set; }

		public string GoldCreationId { get; set; }

		public string BothCreationId { get; set; }

		public bool IsNoneStarValueNewRecord { get; set; }

		public bool IsSilverStarValueNewRecord { get; set; }

		public bool IsGoldStarValueNewRecord { get; set; }

		public bool IsBothStarValueNewRecord { get; set; }

		public RecordsValues()
		{
			NoneStarValue = float.PositiveInfinity;
			SilverStarValue = float.PositiveInfinity;
			GoldStarValue = float.PositiveInfinity;
			BothStarValue = float.PositiveInfinity;
			NoneCreationId = null;
			SilverCreationId = null;
			GoldCreationId = null;
			BothCreationId = null;
			IsNoneStarValueNewRecord = false;
			IsSilverStarValueNewRecord = false;
			IsGoldStarValueNewRecord = false;
			IsBothStarValueNewRecord = false;
		}
	}

	public float BestTime
	{
		get
		{
			return LevelMode.BestTime;
		}
		set
		{
			LevelMode.BestTime = value;
		}
	}

	public RecordsValues LowestTimeRecords { get; private set; }

	public RecordsValues LowestBlocksRecords { get; private set; }

	public RecordsValues LowestCostRecords { get; private set; }

	public RecordsValues LowestWeightRecords { get; private set; }

	public bool AllBothCollectables { get; set; }

	public bool AllGoldCollectables { get; set; }

	public bool AllSilverCollectables { get; set; }

	public LevelModel LevelMode { get; private set; }

	public LevelStatus(LevelModel levelModel)
	{
		LevelMode = levelModel;
		levelModel.LevelStatus = this;
		LowestTimeRecords = new RecordsValues();
		LowestBlocksRecords = new RecordsValues();
		LowestCostRecords = new RecordsValues();
		LowestWeightRecords = new RecordsValues();
		AllBothCollectables = false;
		AllGoldCollectables = false;
		AllSilverCollectables = false;
	}

	public string GetId()
	{
		return LevelMode.Id;
	}

	public (float time, StarType starType) BestTimeEver()
	{
		float num = LowestTimeRecords.BothStarValue;
		StarType item = StarType.Both;
		if (LowestTimeRecords.GoldStarValue < num)
		{
			num = LowestTimeRecords.GoldStarValue;
			item = StarType.Gold;
		}
		if (LowestTimeRecords.SilverStarValue < num)
		{
			num = LowestTimeRecords.SilverStarValue;
			item = StarType.Silver;
		}
		if (LowestTimeRecords.NoneStarValue < num)
		{
			num = LowestTimeRecords.NoneStarValue;
			item = StarType.None;
		}
		return (time: num, starType: item);
	}

	public bool IsCreationIdBeingUsed(string creationId)
	{
		if (!IsCreationIdInRecordsValues(LowestTimeRecords, creationId) && !IsCreationIdInRecordsValues(LowestBlocksRecords, creationId) && !IsCreationIdInRecordsValues(LowestCostRecords, creationId))
		{
			return IsCreationIdInRecordsValues(LowestWeightRecords, creationId);
		}
		return true;
		bool IsCreationIdInRecordsValues(RecordsValues recordsValues, string id)
		{
			if (recordsValues.NoneCreationId == id)
			{
				return true;
			}
			if (recordsValues.SilverCreationId == id)
			{
				return true;
			}
			if (recordsValues.GoldCreationId == id)
			{
				return true;
			}
			if (recordsValues.BothCreationId == id)
			{
				return true;
			}
			return false;
		}
	}
}
