using Factory;

public class DeviceSettingsStorableTypeHandler : IStorableTypeHandler
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private IScope _scope;

	private const string FilenamePrefix = "deviceSettings_";

	private const string FilenameExtension = ".json";

	public string GetFilename(IStorable storable)
	{
		if (storable is IDeviceSettings deviceSettings && Diagnostics.Verify(deviceSettings.Player != null, "You can't save a DeviceSettings that hasn't been assigned to a Player."))
		{
			return GetFilename(deviceSettings.Player.Id, _hardwareCapabilities.UniqueDeviceId);
		}
		return null;
	}

	public string GetFilename(string playerId, string deviceId)
	{
		return StorableUtilities.GenerateFilename("deviceSettings_", ".json", playerId, deviceId);
	}

	public bool IsFilenameRecognized(string filename, out string playerId, out string deviceId)
	{
		return StorableUtilities.TryParseFilename(filename, "deviceSettings_", ".json", out playerId, out deviceId);
	}

	public IStorable Load(byte[] data)
	{
		IDeviceSettings deviceSettings = _scope.Get<IDeviceSettings>();
		if (!StorableUtilities.LoadJsonStorable(deviceSettings, data))
		{
			_scope.Release(deviceSettings);
			return null;
		}
		return deviceSettings;
	}

	public byte[] Store(IStorable storable)
	{
		if (storable is IDeviceSettings jsonStorable)
		{
			return StorableUtilities.StoreJsonStorable(jsonStorable);
		}
		return null;
	}

	public bool ProcessLoadedStorable(IStorable storable, string playerId, string deviceId)
	{
		if (storable is IDeviceSettings newDeviceSettings)
		{
			_playerDatabase.AddDeviceSettings(newDeviceSettings, playerId, deviceId);
			return true;
		}
		return false;
	}

	public void ProcessDeletedStorable(string playerId, string deviceId)
	{
	}
}
