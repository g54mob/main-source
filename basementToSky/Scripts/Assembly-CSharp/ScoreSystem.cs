using System;
using UnityEngine;
using UnityEngine.Localization;

public class ScoreSystem : MonoBehaviour
{
	private LocalizedString steadyFilghtString = new LocalizedString("MyTable", "score_steadyFlight");

	private LocalizedString perfectLandingString = new LocalizedString("MyTable", "score_perfectLanding");

	private LocalizedString parachuteString = new LocalizedString("MyTable", "score_parachute");

	private LocalizedString barrelRollString = new LocalizedString("MyTable", "score_barrelroll");

	private LocalizedString rocketFlipString = new LocalizedString("MyTable", "score_rocketflip");

	private LocalizedString rocketCrashedString = new LocalizedString("MyTable", "score_rocketcrashed");

	[Header("Settings")]
	public float timeLimit = 3f;

	public float trickThreshold = 300f;

	[Header("Stability Settings")]
	public float stabilityAngleThreshold = 15f;

	public float stabilityRequiredTime = 2f;

	public int stabilityScoreBonus = 50;

	private float rollAccumulator;

	private float stabilityTimer;

	private float flipAccumulator;

	private Quaternion lastRotation;

	private bool isTrickStarted;

	private float currentTimer;

	public int score;

	public static event Action<string, int> OnScored;

	public void StartScore()
	{
		score = 0;
		stabilityTimer = 0f;
		ResetTrickContext();
	}

	public void GetScore()
	{
		Quaternion quaternion = Quaternion.Inverse(lastRotation) * base.transform.rotation;
		lastRotation = base.transform.rotation;
		Vector3 eulerAngles = quaternion.eulerAngles;
		float num = Mathf.DeltaAngle(0f, eulerAngles.x);
		float num2 = Mathf.DeltaAngle(0f, eulerAngles.y);
		float num3 = Mathf.DeltaAngle(0f, eulerAngles.z);
		float num4 = Vector3.Angle(base.transform.forward, Vector3.up);
		if (!isTrickStarted && num4 <= stabilityAngleThreshold)
		{
			stabilityTimer += Time.deltaTime;
			if (stabilityTimer >= stabilityRequiredTime)
			{
				AddScore(stabilityScoreBonus, steadyFilghtString.GetLocalizedString());
				stabilityTimer = 0f;
			}
		}
		else
		{
			stabilityTimer = 0f;
		}
		if (!isTrickStarted && (Mathf.Abs(num) > 0.2f || Mathf.Abs(num2) > 0.2f || Mathf.Abs(num3) > 0.2f))
		{
			isTrickStarted = true;
			currentTimer = 0f;
		}
		if (!isTrickStarted)
		{
			return;
		}
		currentTimer += Time.deltaTime;
		if (currentTimer > timeLimit)
		{
			ResetTrickContext();
			return;
		}
		float num5 = Mathf.Sqrt(num * num + num2 * num2);
		flipAccumulator += num5;
		rollAccumulator += num3;
		if (flipAccumulator >= trickThreshold)
		{
			AddScore(100, rocketFlipString.GetLocalizedString());
			ResetTrickContext();
		}
		else if (Mathf.Abs(rollAccumulator) >= trickThreshold)
		{
			AddScore(50, barrelRollString.GetLocalizedString());
			ResetTrickContext();
		}
	}

	private void ResetTrickContext()
	{
		flipAccumulator = 0f;
		lastRotation = base.transform.rotation;
		rollAccumulator = 0f;
		isTrickStarted = false;
		currentTimer = 0f;
	}

	private void AddScore(int amount, string trickName)
	{
		if (GameManager.S.isDicaInstalled)
		{
			score += amount;
			ScoreSystem.OnScored?.Invoke(trickName, amount);
			Debug.Log($"<b>{trickName}</b> 성공! (+{amount}점)");
		}
	}

	public void CrashedScore()
	{
		AddScore(150, rocketCrashedString.GetLocalizedString());
	}

	public void ParachuteScore()
	{
		AddScore(200, parachuteString.GetLocalizedString());
	}

	public void PerfectLandingScore()
	{
		AddScore(500, perfectLandingString.GetLocalizedString());
	}
}
