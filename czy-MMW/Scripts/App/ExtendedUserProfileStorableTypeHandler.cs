using Factory;

public class ExtendedUserProfileStorableTypeHandler : IStorableTypeHandler
{
	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private IScope _scope;

	private const string FilenamePrefix = "extendedUserProfile_";

	private const string FilenameExtension = ".json";

	public string GetFilename(IStorable storable)
	{
		if (storable is IExtendedUserProfile extendedUserProfile && Diagnostics.Verify(extendedUserProfile.Player != null, "You can't save an ExtendedUserProfile that hasn't been assigned to a Player."))
		{
			return GetFilename(extendedUserProfile.Player.Id, null);
		}
		return null;
	}

	public string GetFilename(string playerId, string deviceId)
	{
		return StorableUtilities.GenerateFilename("extendedUserProfile_", ".json", playerId);
	}

	public bool IsFilenameRecognized(string filename, out string playerId, out string deviceId)
	{
		deviceId = null;
		return StorableUtilities.TryParseFilename(filename, "extendedUserProfile_", ".json", out playerId);
	}

	public IStorable Load(byte[] data)
	{
		IExtendedUserProfile extendedUserProfile = _scope.Get<IExtendedUserProfile>();
		if (!StorableUtilities.LoadJsonStorable(extendedUserProfile, data))
		{
			_scope.Release(extendedUserProfile);
			return null;
		}
		return extendedUserProfile;
	}

	public byte[] Store(IStorable storable)
	{
		if (storable is IExtendedUserProfile jsonStorable)
		{
			return StorableUtilities.StoreJsonStorable(jsonStorable);
		}
		return null;
	}

	public bool ProcessLoadedStorable(IStorable storable, string playerId, string deviceId)
	{
		if (storable is IExtendedUserProfile newExtendedUserProfile)
		{
			_playerDatabase.AddExtendedUserProfile(newExtendedUserProfile, playerId);
			return true;
		}
		return false;
	}

	public void ProcessDeletedStorable(string playerId, string deviceId)
	{
		_playerDatabase.RemovePlayer(playerId);
	}
}
