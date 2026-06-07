using System;
using System.Collections.Generic;

public interface IDeviceSettings : IJsonSerializableSaveData, IStorable
{
	Player Player { get; set; }

	DateTime LastPlayedUtcTime { get; set; }

	LocaleDatabase.LocaleId LastLocaleId { get; set; }

	bool SyncToCloud { get; set; }

	Dictionary<string, string> GetDeviceControlMapping(string deviceName);

	void SetDeviceControlMappings(string deviceName, Dictionary<string, string> deviceControlMappings);
}
