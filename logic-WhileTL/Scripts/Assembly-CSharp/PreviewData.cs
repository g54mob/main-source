using System.Collections.Generic;
using Aux;

public class PreviewData
{
	public class QuestInfo
	{
		public bool done;
	}

	public IntDate date;

	public int saveId;

	public string version = "";

	public string saveName = "";

	public string showName = "";

	public string info = "";

	public long money;

	public int buggleScore;

	public int isLastRun;

	public int startupsNumber;

	public string startCheckpointKeyName = "";

	public int autoSaved;

	public Dictionary<string, QuestInfo> qinfo = new Dictionary<string, QuestInfo>();

	public string GetID()
	{
		return showName + saveName;
	}

	public int GetHash()
	{
		return GetID().GetHashCode();
	}

	public int GetNumQuestInfo()
	{
		return qinfo.Count;
	}

	public bool GetQuestInfo(string key, out QuestInfo qi)
	{
		return qinfo.TryGetValue(key, out qi);
	}

	public bool IsQuestDone(string key)
	{
		if (!GetQuestInfo(key, out var qi))
		{
			return false;
		}
		return qi.done;
	}

	public bool IsQuestAvailable(string key)
	{
		QuestInfo qi;
		return GetQuestInfo(key, out qi);
	}

	public bool MakeQuestAvailable(string key, bool state = true)
	{
		if (state)
		{
			if (!qinfo.ContainsKey(key))
			{
				qinfo.Add(key, new QuestInfo());
				return true;
			}
			return false;
		}
		return qinfo.Remove(key);
	}

	public void MakeQuestDone(string key, bool state = true)
	{
		Logic.GetModel().globalSaves.passedTasks[key] = 1;
		if (GetQuestInfo(key, out var qi))
		{
			qi.done = state;
		}
	}
}
