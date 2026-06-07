using UnityEngine;

public class BadgeEvent
{
	public enum Type
	{
		Tutorial = 0,
		Berries = 1,
		Mushrooms = 2,
		Milk = 3,
		Wool = 4,
		Eggs = 5,
		Fish = 6,
		Tools = 7,
		Honey = 8,
		Colonists = 9,
		Mining = 10,
		Pottery = 11,
		Clothes = 12,
		PlotsUncovered = 13,
		TreesCut = 14,
		Food = 15,
		CropsCut = 16,
		MobileStorage = 17,
		AnythingStored = 18,
		BotsMade = 19,
		GameComplete = 20,
		Total = 21
	}

	public Type m_Type;

	public int m_Count;

	public static string GetNameFromType(Type NewType)
	{
		return "BadgeEvent" + NewType;
	}

	public BadgeEvent(Type NewType)
	{
		m_Type = NewType;
		m_Count = 0;
	}

	public void Save()
	{
		PlayerPrefs.SetInt(GetNameFromType(m_Type), m_Count);
	}

	public void Load()
	{
		string nameFromType = GetNameFromType(m_Type);
		if (PlayerPrefs.HasKey(nameFromType))
		{
			m_Count = PlayerPrefs.GetInt(nameFromType);
		}
	}

	public void Clear()
	{
		m_Count = 0;
		Save();
	}

	public void AddEvent(int Amount)
	{
		m_Count += Amount;
	}
}
