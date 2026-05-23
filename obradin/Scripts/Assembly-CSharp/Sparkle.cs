using System.Collections.Generic;
using UnityEngine;

public class Sparkle : MonoBehaviour
{
	[Readonly]
	public OneBit oneBit;

	public float radius = 1f;

	public float speed = 0.1f;

	public int beams = 6;

	public int holes = 4;

	public bool testDepth;

	[Readonly]
	public List<Sparkle> sparkles;

	private void OnDisable()
	{
		oneBit.linedSettings.sparkle = false;
	}

	private void LateUpdate()
	{
		if (Player.instance != null && this == sparkles[0])
		{
			ShowBestSparkle(oneBit, sparkles);
		}
	}

	private static void ShowBestSparkle(OneBit oneBit, List<Sparkle> sparkles)
	{
		Camera mainCamera = Player.instance.mainCamera;
		float num = 0.25f;
		Vector2 vector = 0.5f * Vector2.one;
		Sparkle sparkle = null;
		float num2 = 10000f;
		Vector3 vector2 = Vector3.zero;
		foreach (Sparkle sparkle2 in sparkles)
		{
			Vector3 vector3 = mainCamera.WorldToViewportPoint(sparkle2.transform.position);
			if (vector3.z > 0f && vector3.x >= 0f - num && vector3.y >= 0f - num && vector3.x <= 1f + num && vector3.y < 1f + num)
			{
				float magnitude = (vector3.ToVector2XY() - vector).magnitude;
				if (sparkle == null || magnitude < num2)
				{
					sparkle = sparkle2;
					num2 = magnitude;
					vector2 = vector3;
				}
			}
		}
		if (sparkle != null)
		{
			float num3 = sparkle.radius;
			if (sparkles.Count > 1)
			{
				num3 = Util.LerpScale(num2, 0f, 0.3f, sparkle.radius, 0f);
			}
			if (num3 > 0.001f)
			{
				oneBit.linedSettings.sparkleScreenPos = vector2;
				oneBit.linedSettings.sparkleScreenRadius = Mathf.Lerp(1.5f * num3, num3, Player.cameraFovT) / Mathf.Max(1f, vector2.z);
				oneBit.linedSettings.sparkleScreenRadius *= Util.LerpScale(Mathf.Cos(Clock.play.time), -1f, 1f, 0.8f, 1f);
				oneBit.linedSettings.sparkleSpinTime = 20f + Clock.play.time * sparkle.speed;
				oneBit.linedSettings.sparkleBeamCount = sparkle.beams;
				oneBit.linedSettings.sparkleHoleCount = sparkle.holes;
				oneBit.linedSettings.sparkleDepth01 = Util.LerpScale(vector2.z, mainCamera.nearClipPlane, 50f, 0f, 1f);
				oneBit.linedSettings.sparkleTestDepth = sparkle.testDepth;
				oneBit.linedSettings.sparkle = true;
			}
			else
			{
				oneBit.linedSettings.sparkle = false;
			}
		}
		else
		{
			oneBit.linedSettings.sparkle = false;
		}
	}
}
