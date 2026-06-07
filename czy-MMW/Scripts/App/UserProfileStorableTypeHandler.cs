using Factory;

public class UserProfileStorableTypeHandler : IStorableTypeHandler
{
	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private IScope _scope;

	private const string FilenamePrefix = "userProfile_";

	private const string FilenameExtension = ".json";

	public string GetFilename(IStorable storable)
	{
		if (storable is ILegacyUserProfile legacyUserProfile && Diagnostics.Verify(legacyUserProfile.Player != null, "You can't save a LegacyUserProfile that hasn't been assigned to a Player."))
		{
			return GetFilename(legacyUserProfile.Player.Id, null);
		}
		return null;
	}

	public string GetFilename(string playerId, string deviceId)
	{
		return StorableUtilities.GenerateFilename("userProfile_", ".json", playerId);
	}

	public bool IsFilenameRecognized(string filename, out string playerId, out string deviceId)
	{
		deviceId = null;
		return StorableUtilities.TryParseFilename(filename, "userProfile_", ".json", out playerId);
	}

	public IStorable Load(byte[] data)
	{
		ILegacyUserProfile legacyUserProfile = _scope.Get<ILegacyUserProfile>();
		if (!StorableUtilities.LoadJsonStorable(legacyUserProfile, data))
		{
			_scope.Release(legacyUserProfile);
			return null;
		}
		return legacyUserProfile;
	}

	public byte[] Store(IStorable storable)
	{
		if (storable is ILegacyUserProfile jsonStorable)
		{
			return StorableUtilities.StoreJsonStorable(jsonStorable);
		}
		return null;
	}

	public bool ProcessLoadedStorable(IStorable storable, string playerId, string deviceId)
	{
		if (storable is ILegacyUserProfile newUserProfile)
		{
			_playerDatabase.AddUserProfile(newUserProfile, playerId);
			return true;
		}
		return false;
	}

	public void ProcessDeletedStorable(string playerId, string deviceId)
	{
		_playerDatabase.RemovePlayer(playerId);
	}
}
