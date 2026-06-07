using System.Collections.Generic;
using NBT.Tags;

public class GameRecorder
{
	public class UnitLifeDeathRecord
	{
		public int UID;

		public string unitName;

		public string unitType;

		public bool enemy;

		public int loc;

		public int gameFrameCreated;

		public int gameFrameDestroyed;

		public bool showDeath;

		public UnitLifeDeathRecord()
		{
		}

		public UnitLifeDeathRecord(int UID, string unitName, string unitType, bool enemy, int loc, int gameFrameCreated, bool showDeath)
		{
		}

		public void UnitDestroyed(int gameFrameDestroyed)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public struct CellRecord
	{
		public int loc;

		public byte cellData;

		public CellRecord(int loc, byte cellData)
		{
			this.loc = 0;
			this.cellData = 0;
		}
	}

	public enum UnitRecordType
	{
		MOVE = 0,
		CREATE = 1,
		DESTROY = 2,
		ROTATE = 3,
		SIZEX = 4,
		SIZEY = 5,
		ENABLE = 6,
		UNITCOLORSTATE = 7,
		UNITSETIMAGE = 8
	}

	public struct UnitRecord
	{
		public int UID;

		public int data;

		private byte _recordType;

		public UnitRecordType recordType
		{
			get
			{
				return default(UnitRecordType);
			}
			set
			{
			}
		}

		public UnitRecord(UnitRecordType unitRecordType, int UID, int data)
		{
			this.UID = 0;
			this.data = 0;
			_recordType = 0;
		}
	}

	public class GameRecord
	{
		public int gameFrame;

		public int rawGameFrame;

		public float energyProduction;

		public float energyStore;

		public float ultracStore;

		public float anticreeperStore;

		public float argStore;

		public float lifticStore;

		public float energyDeficit;

		public List<CellRecord> cellRecords;

		public List<UnitRecord> unitRecords;

		public void AddCellRecord(int loc, byte cellData)
		{
		}

		public void AddUnitRecord(UnitRecordType recordType, int UID, int data)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public enum GAME_COMPLETION_STATE
	{
		PENDING = 0,
		SUCCESS = 1,
		FAILUTE = 2
	}

	private Dictionary<int, UnitLifeDeathRecord> unitLifeDeathRecords;

	private List<GameRecord> records;

	private GameRecord currentGameRecord;

	private int lastGameFrame;

	private Dictionary<int, int> unitMovement;

	private Dictionary<string, byte[]> customUnitImages;

	private int completionFrame;

	private float completionScore;

	private GAME_COMPLETION_STATE completionState;

	public int recordInterval;

	public string lastGameRecorderGUID;

	public string missionTitle;

	public bool updateOnInit;

	private int _gameWidth;

	private int _gameHeight;

	public bool customImagesDirty;

	public int gameWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int gameHeight
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Init()
	{
	}

	public void UpdateCustomUnitImages()
	{
	}

	public void CloseCurrentGameRecord()
	{
	}

	public List<GameRecord> GetRecords()
	{
		return null;
	}

	private void CreateNewGameRecord()
	{
	}

	public void CreateNewGameRecordIfNeeded()
	{
	}

	public void AddGameRecordForCell(int loc, byte cellData)
	{
	}

	public void AddUnitCreation(int UID, string unitName, string unitType, bool enemy, int loc, int rotation, int sizeX, int sizeY, bool showDeath)
	{
	}

	public void AddUnitDestroyed(int UID, int loc)
	{
	}

	public UnitLifeDeathRecord GetUnitLifeDeathRecord(int UID)
	{
		return null;
	}

	public void AddUnitRotation(int UID, int rotation)
	{
	}

	public void AddUnitEnabled(int UID, bool enabled)
	{
	}

	public void AddUnitColorState(int UID, int state)
	{
	}

	public void AddUnitSetImage(int UID, int image)
	{
	}

	public void AddUnitMoved(int UID, int loc)
	{
	}

	public void SetGameCompletion(GAME_COMPLETION_STATE state)
	{
	}

	public Dictionary<string, byte[]> GetCustomUnitImages()
	{
		return null;
	}

	public void AddCustomUnitImage(string unitType, byte[] data)
	{
	}

	public byte[] GetCustomUnitImage(string unitType)
	{
		return null;
	}

	public bool ContainsCustomUnitImage(string unitType)
	{
		return false;
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
