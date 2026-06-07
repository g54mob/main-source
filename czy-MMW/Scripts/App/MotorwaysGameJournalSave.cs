using System;
using System.IO;
using Factory;
using FixMath;
using Motorways;
using Server;

public class MotorwaysGameJournalSave : BaseGameJournalSave, IMotorwaysGameJournalHeader, IReleasedFromScopeHandler
{
	[Dependency]
	private IScope _scope;

	private MotorwaysGameJournalHeader _header;

	private byte[] _simulationData;

	public IScope Scope => _scope;

	public GameJournalMotive Motive
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.Motive;
			}
			return GameJournalMotive.Autosave;
		}
	}

	public string DeviceModel
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.DeviceModel;
			}
			return "";
		}
	}

	public string DeviceName
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.DeviceName;
			}
			return "";
		}
	}

	public int GameAssemblerSerializerHashCode
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.GameAssemblerSerializerHashCode;
			}
			return -1;
		}
	}

	public string CityId
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.CityId;
			}
			return "";
		}
	}

	public GameMode Mode
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.Mode;
			}
			return GameMode.Normal;
		}
	}

	public int TripCount
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.TripCount;
			}
			return 0;
		}
	}

	public Fix64 TimeElapsed
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.TimeElapsed;
			}
			return Fix64.Zero;
		}
	}

	public MapChallenge.ChallengeType ChallengeType
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.ChallengeType;
			}
			return MapChallenge.ChallengeType.None;
		}
	}

	public int ChallengeEndTime
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.ChallengeEndTime;
			}
			return 0;
		}
	}

	public int ChallengeIndex
	{
		get
		{
			if (Diagnostics.Verify(_header != null))
			{
				return _header.ChallengeIndex;
			}
			return -1;
		}
	}

	public bool InitializeFromSimulation(ISimulation simulation, GameJournalMotive motive)
	{
		_header = _scope.Get<MotorwaysGameJournalHeader>();
		if (!_header.Initialize(simulation, motive))
		{
			BaseGameJournalSave.Log.Warn("Unable to create header from simulation.");
			return false;
		}
		MemoryStream memoryStream = new MemoryStream();
		using (BinaryWriter writer = new BinaryWriter(memoryStream))
		{
			if (!simulation.Scope.Export(simulation, writer))
			{
				BaseGameJournalSave.Log.Warn("Failed to export simulation.");
				return false;
			}
		}
		_simulationData = memoryStream.ToArray();
		base.UtcTimestamp = DateTime.UtcNow;
		return true;
	}

	public override void InitializeWithBytes(byte[] saveDataAsBytes)
	{
		base.InitializeWithBytes(saveDataAsBytes);
		_simulationData = saveDataAsBytes;
	}

	public override byte[] GetBytesForSerializing()
	{
		return _simulationData;
	}

	public override void OnSerializeBeforeData(BinaryWriter binaryWriter)
	{
		base.OnSerializeBeforeData(binaryWriter);
		_scope.Export(_header, binaryWriter);
	}

	public override IBinarySerializableSaveData.HeaderValidationResult ValidateHeader(BinaryReader binaryReader)
	{
		if (base.ValidateHeader(binaryReader) == IBinarySerializableSaveData.HeaderValidationResult.Success)
		{
			_header = _scope.Import<MotorwaysGameJournalHeader>(binaryReader);
			if (_header == null)
			{
				return IBinarySerializableSaveData.HeaderValidationResult.InvalidHeader;
			}
			base.UtcTimestamp = _header.UtcTimestamp;
			Assembler assemblerForType = _scope.Assembler.GetAssemblerForType(typeof(Game));
			if (_header.GameAssemblerSerializerHashCode != assemblerForType.GlobalTypeSerializerHashCode)
			{
				BaseGameJournalSave.Log.Info("Rejecting save due to mismatched serializer hash codes. Theirs is {0}, ours is {1}.", _header.GameAssemblerSerializerHashCode, assemblerForType.GlobalTypeSerializerHashCode);
				return IBinarySerializableSaveData.HeaderValidationResult.HashCodesMismatched;
			}
			if (_header == null)
			{
				return IBinarySerializableSaveData.HeaderValidationResult.InvalidHeader;
			}
			return IBinarySerializableSaveData.HeaderValidationResult.Success;
		}
		return IBinarySerializableSaveData.HeaderValidationResult.InvalidHeader;
	}

	public Game DeserializeGame(CityDefinition cityDefinition)
	{
		if (_simulationData != null)
		{
			Game game = _scope.Get<Game>();
			game.Scope.Get<City>().Definition = cityDefinition;
			MotorwaysGame motorwaysGame = game as MotorwaysGame;
			motorwaysGame?.PausePathfinder();
			using (BinaryReader reader = new BinaryReader(new MemoryStream(_simulationData)))
			{
				if (game.Scope.Import<ISimulation>(reader) == null)
				{
					_scope.Release(game);
					return null;
				}
			}
			motorwaysGame?.ResumePathfinder();
			return game;
		}
		return null;
	}

	public void OnReleasedFromScope(IScope scope)
	{
		if (_header != null)
		{
			scope.Release(_header);
		}
	}
}
