using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyInertiaSettings", menuName = "ScriptableObjects/Enemy Inertia Settings")]
public class EnemyInertiaSettings : ScriptableObject
{
	[SerializeField]
	[Tooltip("How long will an enemy wait before turning on the engine from a dead stop (min value)")]
	public float minStartReactionTime;

	[SerializeField]
	[Tooltip("How long will an enemy wait before turning on the engine from a dead stop (max value)")]
	public float maxStartReactionTime;

	[SerializeField]
	[Tooltip("How long does it take for an enemy to catch up with the train (min value)")]
	public float minSpeedUpTime;

	[SerializeField]
	[Tooltip("How long does it take for an enemy to catch up with the train (max value)")]
	public float maxSpeedUptime;

	[SerializeField]
	[Tooltip("How long will does it take for an enemy to come to a full stop (min value)")]
	public float minStopReactionTime;

	[SerializeField]
	[Tooltip("How long will does it take for an enemy to come to a full stop (max value)")]
	public float maxStopReactionTime;

	[SerializeField]
	[Range(0f, 10f)]
	[Tooltip("How hard will the enemy break (min value)")]
	public float minBreakingStrength;

	[SerializeField]
	[Range(0f, 10f)]
	[Tooltip("How hard will the enemy break (max value)")]
	public float maxBreakingStrength;
}
