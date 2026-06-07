using Factory;

public class SavedGameStorableTypeHandler : IStorableTypeHandler
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private IScope _scope;

	private const string FilenamePrefix = "gameJournal_";

	private const string FilenameExtension = ".dat";

	public string GetFilename(IStorable storable)
	{
		if (storable is IGameJournalSave gameJournalSave)
		{
			return GetFilename(gameJournalSave.Player.Id, _hardwareCapabilities.UniqueDeviceId);
		}
		return null;
	}

	public string GetFilename(string playerId, string deviceId)
	{
		return StorableUtilities.GenerateFilename("gameJournal_", ".dat", playerId, deviceId);
	}

	public bool IsFilenameRecognized(string filename, out string playerId, out string deviceId)
	{
		return StorableUtilities.TryParseFilename(filename, "gameJournal_", ".dat", out playerId, out deviceId);
	}

	public IStorable Load(byte[] data)
	{
		IGameJournalSave gameJournalSave = _scope.Get<IGameJournalSave>();
		if (StorableUtilities.LoadBinaryStorable(gameJournalSave, data) != StorableUtilities.LoadResult.Success)
		{
			_scope.Release(gameJournalSave);
			return null;
		}
		return gameJournalSave;
	}

	public byte[] Store(IStorable storable)
	{
		if (storable is IGameJournalSave binaryStorable)
		{
			return StorableUtilities.StoreBinaryStorable(binaryStorable);
		}
		return null;
	}

	public bool ProcessLoadedStorable(IStorable storable, string playerId, string deviceId)
	{
		if (storable is IGameJournalSave newSavedGame)
		{
			_playerDatabase.AddSavedGame(playerId, deviceId, newSavedGame);
			return true;
		}
		return false;
	}

	public void ProcessDeletedStorable(string playerId, string deviceId)
	{
		_playerDatabase.GetPlayer(playerId)?.RemoveSavedGame(deviceId);
	}
}
