using UnityEngine;

[CreateAssetMenu(fileName = "New AutoDelay Data", menuName = "Super Text Mesh/AutoDelay Data", order = 0)]
public class STMAutoDelayData : STMDelayData
{
	public enum Ruleset
	{
		Always = 0,
		FollowedBySpace = 1,
		FollowedBySameCharacterOrSpace = 2,
		FollowedByDifferentCharacter = 3
	}

	public enum Type
	{
		Character = 0,
		Quad = 1
	}

	public Type type;

	public char character;

	public string quadName;

	public Ruleset ruleset;
}
