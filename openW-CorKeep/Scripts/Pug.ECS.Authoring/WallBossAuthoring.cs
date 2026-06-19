using System.Collections.Generic;
using UnityEngine;

public class WallBossAuthoring : MonoBehaviour
{
	public float distanceFromCore = 875f;

	public float segmentRadius = 2.5f;

	public int totalSegments = 16;

	public float totalWidth = 50f;

	public float attackDuration = 1f;

	public float attackCooldown = 1f;

	public float slitheringFrequencyMultiplier = 1f;

	public float slitheringWavelengthMultiplier = 1f;

	public float slitheringWaveHeightMultiplier = 1f;

	public float pauseBeforeBulbsEmergeDuration;

	public float pauseBeforeHeadEmergesDuration;

	public float vulnerableDuration = 15f;

	public float vulnerableOnDamageMaxDuration = 5f;

	public float headOffset = -1f;

	public float bulbOffset = -1f;

	public List<MovementParameters> movement = new List<MovementParameters>();
}
