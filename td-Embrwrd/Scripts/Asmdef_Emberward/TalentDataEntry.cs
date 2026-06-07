using System;
using UnityEngine;

[Serializable]
public class TalentDataEntry
{
	[SerializeField]
	private eTalentType type;

	[SerializeField]
	private int level;

	public eTalentType Type => default(eTalentType);

	public int Level => 0;

	public TalentDataEntry(eTalentType type, int level)
	{
	}

	public void SetLevel(int level)
	{
	}
}
