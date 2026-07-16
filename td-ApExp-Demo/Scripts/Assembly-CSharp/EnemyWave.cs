using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
	private static float spriteOffset = 0.25f;

	[field: SerializeField]
	public int Id { get; private set; }

	[field: SerializeField]
	[field: Tooltip("The minimum difficulty at which this wave appears (inclusive).")]
	public float MinDifficulty { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Time in seconds between each enemy spawning. Specific enemy spawn times override this. Set this to -1 if you want to ignore it.")]
	public float TimeBetweenSpawns { get; private set; } = -1f;

	[field: SerializeField]
	[field: Tooltip("Time in seconds added to the time until the next wave, as compensation for an incredibly difficult wave.")]
	public float ExtraTime { get; private set; }

	[field: SerializeField]
	[field: Tooltip("If true, waves can and will spawn flipped vertically half the time for added variance.")]
	public bool VerticalSymmetry { get; private set; }

	[field: SerializeField]
	[field: Tooltip("If true, ignore the angle and variance of the spawn itself and spawn enemies in this wave at the top and bottom of the screen randomly.")]
	public bool RandomAnglesOverride { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	public List<EnemySpawn> Spawns { get; private set; }

	public static Vector3 SpawnPosFromAngle(float spawnAngle)
	{
		Camera main = Camera.main;
		float f = (90f - spawnAngle) * (MathF.PI / 180f);
		Vector3 vector = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f);
		float num = main.orthographicSize * 2f;
		float num2 = num * main.aspect;
		float num3 = num * 0.7f;
		float num4 = num2 * 0.7f;
		Vector3 vector2 = vector;
		if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
		{
			vector2 *= num4 / Mathf.Abs(vector.x);
		}
		else
		{
			vector2 *= num3 / Mathf.Abs(vector.y) + spriteOffset;
		}
		return vector2 + new Vector3(main.transform.position.x, main.transform.position.y, 0f);
	}
}
