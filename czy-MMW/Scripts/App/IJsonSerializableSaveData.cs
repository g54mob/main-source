using System;
using System.Collections.Generic;

public interface IJsonSerializableSaveData : IStorable
{
	event Action DataChanged;

	void InitializeWithJson(JSON.Dictionary jsonSaveData);

	Dictionary<string, object> SerializeToJson();

	void Merge(IJsonSerializableSaveData otherData, bool autosave = true);
}
