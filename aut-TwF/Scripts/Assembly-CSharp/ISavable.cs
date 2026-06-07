using System.Collections.Generic;

public interface ISavable
{
	void OnSave();

	void OnPreLoad();

	void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething);

	bool IgnoreSave()
	{
		return false;
	}
}
