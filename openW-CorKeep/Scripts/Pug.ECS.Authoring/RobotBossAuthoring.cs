using UnityEngine;

[DisallowMultipleComponent]
public class RobotBossAuthoring : MonoBehaviour
{
	public int legBrokenTime = 20;

	public float legXOffset = 4f;

	public float legZOffset = 4f;

	public float stepHeightProgressMultiplier = 1f;

	public float distanceToTriggerLegMovement = 1.5f;

	public float legMovementSpeed = 1f;

	public float maxStepHeight = 0.5f;

	public float startDistance = 0.5f;

	public float stepForwardDistance = 0.8f;

	public float legStepCooldownDuration = 0.5f;

	public float chainedDelayBetweenAttacks = 1f;

	public int numberOfAttacksInChain = 6;
}
