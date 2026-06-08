using System.Collections.Generic;
using UnityEngine;

public class HUDOnlyCameraController : MonoBehaviour
{
	private class DroneProperties
	{
		public int DroneNumber = -1;

		public bool isStaticOnNoise;

		public bool isStaticOnNoiseIsClearing;

		public int currentStaticIdx = -1;

		public float staticNoiseStrengthFactor = 1f;

		public float timerUntilStartClear;

		public float timerUntilEndClear;
	}

	public static HUDOnlyCameraController Instance;

	public PostAnimator StaticAnimator;

	public Static StaticShader;

	public int StaticStartIdx = 1;

	public int StaticIdleFwdIdx = 2;

	public int StaticIdleHoldIdx = 5;

	public int StaticIdleBackIdx = 4;

	public int StaticPopIdx = 3;

	public int StaticPopChance = 20;

	public int StaticIdleHoldChance = 80;

	public int StaticIdleHoldContinueChance = 20;

	private List<DroneProperties> dronePropertyList;

	private bool atLeastOneStaticOnNoise;

	private AnimFloat currentStaticAnim;

	private int currentDroneNumber = -1;

	public void Awake()
	{
		Instance = this;
		StaticShader.enabled = false;
	}

	private void OnDestroy()
	{
		StaticAnimator = null;
		StaticShader = null;
	}

	public void SwitchToDrone(int droneNumber)
	{
		if (droneNumber == currentDroneNumber)
		{
			return;
		}
		DroneProperties droneProperties = null;
		if (dronePropertyList != null)
		{
			int count = dronePropertyList.Count;
			for (int i = 0; i < count; i++)
			{
				if (dronePropertyList[i].DroneNumber == droneNumber)
				{
					droneProperties = dronePropertyList[i];
					break;
				}
			}
		}
		if (droneProperties == null)
		{
			if (currentStaticAnim != null && currentStaticAnim.isPlaying)
			{
				currentStaticAnim.Stop();
			}
			StaticShader.strength = 0f;
			StaticShader.sample = 0f;
			StaticShader.enabled = false;
		}
		else if (!droneProperties.isStaticOnNoise)
		{
			if (currentStaticAnim != null && currentStaticAnim.isPlaying)
			{
				currentStaticAnim.Stop();
				droneProperties.staticNoiseStrengthFactor = 1f;
				droneProperties.timerUntilStartClear = 0f;
				droneProperties.isStaticOnNoiseIsClearing = false;
				StaticShader.strength = 0f;
				StaticShader.sample = 0f;
				StaticShader.enabled = false;
			}
		}
		else
		{
			currentStaticAnim = StaticAnimator.animations[droneProperties.currentStaticIdx];
			currentStaticAnim.obj = StaticShader;
			StaticShader.StrengthFactor = droneProperties.staticNoiseStrengthFactor;
			currentStaticAnim.Play();
			StaticShader.enabled = true;
		}
		currentDroneNumber = droneNumber;
	}

	public void FireStaticOnDisabled(int droneNumber)
	{
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (dronePropertyList[i].DroneNumber == droneNumber)
			{
				droneProperties = dronePropertyList[i];
				break;
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		droneProperties.currentStaticIdx = StaticStartIdx;
		droneProperties.staticNoiseStrengthFactor = (float)((Random.Range(0, 2) == 0) ? 1 : (-1)) * Random.Range(0.6f, 1f);
		droneProperties.isStaticOnNoise = true;
		droneProperties.isStaticOnNoiseIsClearing = false;
		droneProperties.timerUntilStartClear = Random.Range(1f, 3f);
		if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			StaticShader.StrengthFactor = droneProperties.staticNoiseStrengthFactor;
			currentStaticAnim = StaticAnimator.animations[droneProperties.currentStaticIdx];
			currentStaticAnim.obj = StaticShader;
			currentStaticAnim.Play();
			StaticShader.enabled = true;
			currentDroneNumber = droneNumber;
		}
		atLeastOneStaticOnNoise = true;
	}

	private void Update()
	{
		if (dronePropertyList == null || !atLeastOneStaticOnNoise)
		{
			return;
		}
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (!dronePropertyList[i].isStaticOnNoise)
			{
				continue;
			}
			if (!dronePropertyList[i].isStaticOnNoiseIsClearing)
			{
				dronePropertyList[i].timerUntilStartClear -= Time.deltaTime;
				if (dronePropertyList[i].timerUntilStartClear <= 0f)
				{
					dronePropertyList[i].timerUntilStartClear = 0f;
					dronePropertyList[i].isStaticOnNoiseIsClearing = true;
					dronePropertyList[i].timerUntilEndClear = 0.5f;
					if (currentStaticAnim != null && currentStaticAnim.isPlaying)
					{
						currentStaticAnim.Stop();
					}
				}
			}
			else
			{
				dronePropertyList[i].timerUntilEndClear -= Time.deltaTime;
				if (dronePropertyList[i].timerUntilEndClear <= 0f)
				{
					dronePropertyList[i].isStaticOnNoise = false;
					dronePropertyList[i].isStaticOnNoiseIsClearing = false;
					dronePropertyList[i].timerUntilStartClear = 0f;
					dronePropertyList[i].timerUntilEndClear = 0f;
					if (dronePropertyList[i].DroneNumber == currentDroneNumber)
					{
						StaticShader.strength = 0f;
						StaticShader.enabled = false;
					}
					continue;
				}
				if (dronePropertyList[i].DroneNumber == currentDroneNumber)
				{
					float t = 1f - dronePropertyList[i].timerUntilEndClear / 0.5f;
					StaticShader.strength = Mathf.Lerp(StaticShader.strength, 0f, t);
				}
			}
			if (dronePropertyList[i].DroneNumber != currentDroneNumber || dronePropertyList[i].isStaticOnNoiseIsClearing || currentStaticAnim.isPlaying)
			{
				continue;
			}
			if (dronePropertyList[i].currentStaticIdx == StaticStartIdx)
			{
				dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
			}
			else if (dronePropertyList[i].currentStaticIdx == StaticIdleFwdIdx)
			{
				if (Random.Range(0, 100) < StaticPopChance)
				{
					dronePropertyList[i].currentStaticIdx = StaticPopIdx;
				}
				else if (Random.Range(0, 100) < StaticIdleHoldChance)
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleHoldIdx;
				}
				else
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleBackIdx;
				}
			}
			else if (dronePropertyList[i].currentStaticIdx == StaticIdleBackIdx)
			{
				dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
			}
			else if (dronePropertyList[i].currentStaticIdx == StaticIdleHoldIdx)
			{
				if (Random.Range(0, 100) < StaticPopChance)
				{
					dronePropertyList[i].currentStaticIdx = StaticPopIdx;
				}
				else if (Random.Range(0, 100) < StaticIdleHoldContinueChance)
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleHoldIdx;
				}
				else
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleBackIdx;
				}
			}
			else if (dronePropertyList[i].currentStaticIdx == StaticPopIdx)
			{
				dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
			}
			currentStaticAnim = StaticAnimator.animations[dronePropertyList[i].currentStaticIdx];
			currentStaticAnim.obj = StaticShader;
			currentStaticAnim.Play();
		}
	}
}
