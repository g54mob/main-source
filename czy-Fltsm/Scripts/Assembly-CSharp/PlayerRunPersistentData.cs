using System;
using System.Collections.Generic;

[Serializable]
public class PlayerRunPersistentData
{
	private Guid _id;

	private string _communityName;

	private List<SaveInfo> _saves;

	private bool _tutorial;

	public Guid Id => _id;

	public string CommunityName => _communityName;

	public List<SaveInfo> Saves => _saves;

	public bool Tutorial => _tutorial;

	public PlayerRunPersistentData(string communityName, bool tutorial = false)
	{
		_communityName = communityName;
		_saves = new List<SaveInfo>();
		_tutorial = tutorial;
		Sorting.SlowSort(_saves);
	}

	public bool SetCommunityName(string name)
	{
		if (Saves.IsNullOrEmpty())
		{
			_communityName = name;
			return true;
		}
		return false;
	}

	public bool TryGetSave(out SaveInfo save, string name, SaveType type = SaveType.Manual)
	{
		for (int i = 0; i < _saves.Count; i++)
		{
			save = _saves[i];
			if (save != null && save.Type == type && save.Name.Equals(name))
			{
				return true;
			}
		}
		save = null;
		return false;
	}
}
