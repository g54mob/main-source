using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class TrickShotHelper : MonoBehaviour
{
	public static TrickShotHelper Singleton;

	[Header("Trick Shot Compliments")]
	public List<string> trickShotCompliments;

	public List<float> trickShotDistanceThresholds;

	[Header("Celebration Visuals")]
	[SerializeField]
	private GameObject celebrationParent;

	[SerializeField]
	private TMP_Text celebrationText_Header;

	[SerializeField]
	private TMP_Text celebrationText_Distance;

	[SerializeField]
	private ParticleSystem celebrationParticles;

	[SerializeField]
	private float celebrationPopUp_Duration;

	private float celebrationPopUp_Duration_Curr;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_Celebration;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		HideTrickShotCelebration();
	}

	private void Update()
	{
		HandleCelebrationPopUpLifeTime();
	}

	private void HandleCelebrationPopUpLifeTime()
	{
		if (celebrationPopUp_Duration_Curr > 0f)
		{
			celebrationPopUp_Duration_Curr -= Time.deltaTime;
		}
		else
		{
			HideTrickShotCelebration();
		}
	}

	public void ShowNewTrickShotCelebration(float _distance, float _bonusPercentage)
	{
		celebrationParent.SetActive(value: true);
		celebrationPopUp_Duration_Curr = celebrationPopUp_Duration;
		celebrationText_Header.text = GetTrickShotComplimentByDistance(_distance) + " Trick Shot!";
		celebrationText_Distance.text = _distance.ToString("F2") + "m!\n+ " + (_bonusPercentage * 100f).ToString("F0") + "%";
		celebrationParticles.Stop();
		celebrationParticles.Play();
		feedback_Celebration?.StopFeedbacks();
		feedback_Celebration?.RestoreInitialValues();
		feedback_Celebration?.PlayFeedbacks();
	}

	private string GetTrickShotComplimentByDistance(float _distance)
	{
		if (_distance < trickShotDistanceThresholds[0])
		{
			return null;
		}
		if (IsBetween(_distance, trickShotDistanceThresholds[0], trickShotDistanceThresholds[1]))
		{
			return trickShotCompliments[0];
		}
		if (IsBetween(_distance, trickShotDistanceThresholds[1], trickShotDistanceThresholds[2]))
		{
			return trickShotCompliments[1];
		}
		if (IsBetween(_distance, trickShotDistanceThresholds[2], trickShotDistanceThresholds[3]))
		{
			return trickShotCompliments[2];
		}
		if (_distance >= trickShotDistanceThresholds[3])
		{
			return trickShotCompliments[3];
		}
		return null;
	}

	public static bool IsBetween(float value, float min, float max)
	{
		if (value >= min)
		{
			return value <= max;
		}
		return false;
	}

	public void HideTrickShotCelebration()
	{
		celebrationParent.SetActive(value: false);
	}
}
