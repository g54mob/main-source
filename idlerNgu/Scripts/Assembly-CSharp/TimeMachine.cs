using System;
using UnityEngine;

[Serializable]
public class TimeMachine
{
	public float baseGold;

	public float machineProgress;

	public long machineEnergy;

	public double realBaseGold;

	public float speedLevel;

	public long levelSpeed;

	public float speedBuildTime;

	public float speedProgress;

	public long speedEnergy;

	public float speedGoldCost;

	public float goldMultiLevel;

	public long levelGoldMulti;

	public float goldMultiBuildTime;

	public float goldMultiProgress;

	public long goldMultiMagic;

	public float goldMultiGoldCost;

	public long speedTarget;

	public long multiTarget;

	public long speedBankLevels;

	public long goldMultiBankLevels;

	public bool transferredBankLevels = true;

	public TimeMachine()
	{
		baseGold = 0f;
		machineProgress = 0f;
		machineEnergy = 0L;
		speedLevel = 0f;
		levelSpeed = 0L;
		speedBuildTime = 100000f;
		speedProgress = 0f;
		speedEnergy = 0L;
		speedGoldCost = 1E+09f;
		goldMultiLevel = 0f;
		levelGoldMulti = 0L;
		goldMultiProgress = 0f;
		goldMultiBuildTime = 1000000f;
		goldMultiMagic = 0L;
		goldMultiGoldCost = 1E+09f;
		speedTarget = 0L;
		multiTarget = 0L;
		speedBankLevels = 0L;
		goldMultiBankLevels = 0L;
		transferredBankLevels = true;
	}

	public void reset()
	{
		machineEnergy = 0L;
		machineProgress = 0f;
		speedLevel = 0f;
		levelSpeed = 0L;
		speedProgress = 0f;
		goldMultiLevel = 0f;
		levelGoldMulti = 0L;
		machineProgress = 0f;
	}

	public void advanceMachineProgress()
	{
	}

	public string timeLeftSpeed(float speed)
	{
		if (speed == 0f)
		{
			return "N/A";
		}
		if (speedEnergy == 0L)
		{
			float num = (1f - speedProgress) * (speedBuildTime * (float)(levelSpeed + 1)) / (1000f * speed / 1000f);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			num4 = Mathf.Floor(num / 86400f);
			num %= 86400f;
			num3 = Mathf.Floor(num / 3600f);
			num %= 3600f;
			num2 = Mathf.Floor(num / 60f);
			num %= 60f;
			return num4 + " days " + num3 + " hours " + num2 + " minutes " + num.ToString("#0.0") + " seconds (with 1000 Energy)";
		}
		float num5 = (1f - speedProgress) * (speedBuildTime * (float)(levelSpeed + 1)) / ((float)speedEnergy * speed / 1000f);
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		num8 = Mathf.Floor(num5 / 86400f);
		num5 %= 86400f;
		num7 = Mathf.Floor(num5 / 3600f);
		num5 %= 3600f;
		num6 = Mathf.Floor(num5 / 60f);
		num5 %= 60f;
		return num8 + " days " + num7 + " hours " + num6 + " minutes " + num5.ToString("#0.0") + " seconds (with " + speedEnergy + " Energy)";
	}

	public string goldMultiTimeLeft(float magicSpeed)
	{
		if (magicSpeed == 0f)
		{
			return "N/A";
		}
		if (goldMultiMagic == 0L)
		{
			float num = (1f - goldMultiProgress) * (goldMultiBuildTime * (float)(levelGoldMulti + 1)) / (1000f * magicSpeed / 1000f);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			num4 = Mathf.Floor(num / 86400f);
			num %= 86400f;
			num3 = Mathf.Floor(num / 3600f);
			num %= 3600f;
			num2 = Mathf.Floor(num / 60f);
			num %= 60f;
			return num4 + " days " + num3 + " hours " + num2 + " minutes " + num.ToString("#0.0") + " seconds (with 1000 Magic)";
		}
		float num5 = (1f - goldMultiProgress) * (goldMultiBuildTime * (float)(levelGoldMulti + 1)) / ((float)goldMultiMagic * magicSpeed / 1000f);
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		num8 = Mathf.Floor(num5 / 86400f);
		num5 %= 86400f;
		num7 = Mathf.Floor(num5 / 3600f);
		num5 %= 3600f;
		num6 = Mathf.Floor(num5 / 60f);
		num5 %= 60f;
		return num8 + " days " + num7 + " hours " + num6 + " minutes " + num5.ToString("#0.0") + " seconds (with " + goldMultiMagic + "Magic)";
	}

	public float getSpeedCost()
	{
		return (float)(1 + levelSpeed) * speedGoldCost;
	}

	public float getGoldMultiCost()
	{
		return (float)(1 + levelGoldMulti) * goldMultiGoldCost;
	}

	public void updateBaseStats(float stime, float sgold, float gmtime, float gmgold)
	{
		speedBuildTime = stime;
		speedGoldCost = sgold;
		goldMultiBuildTime = gmtime;
		goldMultiGoldCost = gmgold;
	}
}
