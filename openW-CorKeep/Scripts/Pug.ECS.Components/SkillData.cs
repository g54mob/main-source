using System;

[Serializable]
public struct SkillData
{
	public SkillID skillID;

	public int value;

	public SkillData(SkillID skillID, int value)
	{
		this.skillID = skillID;
		this.value = value;
	}
}
