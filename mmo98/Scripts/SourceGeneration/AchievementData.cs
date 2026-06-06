using UnityEngine;

[CreateAssetMenu(menuName = "Data/Achievement", fileName = "Achievement")]
public class AchievementData : ScriptableData<Achievement>
{
	public enum Scope
	{
		Studio = 0,
		Global = 1
	}

	public enum ValueType
	{
		Int = 0,
		Float = 1
	}

	public Sprite sprite;

	public double target = 1.0;

	public Scope scope;

	public bool hidden;

	public bool steam;

	public string steamKey;

	public string steamStatKey;

	public ValueType steamStatType;

	protected override string LocalizationPrefix => "milestone";

	protected override LocTable LocalizationTable => LocTable.Milestones;

	public static implicit operator Achievement(AchievementData data)
	{
		return data.ID;
	}

	public static implicit operator AchievementData(Achievement node)
	{
		return node.Data();
	}
}
