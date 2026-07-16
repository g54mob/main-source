using UnityEngine;

[CreateAssetMenu(fileName = "NewDifficultySetting", menuName = "ScriptableObjects/Difficulty Setting")]
public class DifficultySetting : ScriptableObject
{
	[Header("Basic Info")]
	public string difficultyName;

	[Header("Gameplay Modifiers")]
	public float healthMultiplier = 1f;

	public float damageMultiplier = 1f;

	public float graceDamageMultiplier = 1f;

	public float additionalBossCores;

	public bool isUnlocked;
}
