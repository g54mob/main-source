using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[Serializable]
public class QuestCategory : IPage, IComparable<IPage>, ICategoryPage
{
	[SerializeField]
	private QuestType[] _questTypes;

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private Sprite _icon;

	public string ID => null;

	public string Name => _name;

	public Sprite Icon => _icon;

	public string CompareString => null;

	public List<IPage> SubPages { get; private set; } = new List<IPage>();

	public void Populate(List<Quest> quests)
	{
		SubPages.Clear();
		foreach (Quest quest in quests)
		{
			if (_questTypes.Contains(quest.Properties.QuestType))
			{
				SubPages.Add(quest);
			}
		}
	}

	public void PopulateQuestType(List<QuestType> questTypes)
	{
		questTypes.AddRange(_questTypes);
	}

	public int CompareTo(IPage other)
	{
		throw new NotImplementedException();
	}
}
