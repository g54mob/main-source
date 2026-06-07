using UnityEngine;

[CreateAssetMenu(fileName = "GameplayObjectDataGroup_default", menuName = "Tower Factory/GameplayObjectData Group")]
public class GameplayObjectDataGroup : ScriptableObject
{
	[SerializeField]
	private GameplayObjectData[] group;

	public GameplayObjectData[] Group => group;
}
