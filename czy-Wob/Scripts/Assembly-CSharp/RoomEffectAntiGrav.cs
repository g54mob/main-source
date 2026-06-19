using System.Collections.Generic;
using UnityEngine;

public class RoomEffectAntiGrav : RoomEffectBase
{
	public enum GravSetting
	{
		Earth = 0,
		Mars = 1,
		Moon = 2,
		None = 3,
		Saturn = 4,
		Jupiter = 5,
		Flipped = 6,
		Random = 7
	}

	public static Dictionary<GravSetting, float> gravityValues = new Dictionary<GravSetting, float>
	{
		{
			GravSetting.Mars,
			-1.8f
		},
		{
			GravSetting.Moon,
			-2.5f
		},
		{
			GravSetting.None,
			-1f
		},
		{
			GravSetting.Earth,
			0f
		},
		{
			GravSetting.Saturn,
			0.42f
		},
		{
			GravSetting.Jupiter,
			4.58f
		},
		{
			GravSetting.Flipped,
			-6f
		}
	};

	private float randomCycleFlip = 1f;

	private float currentRandomCycleTimer = 3f;

	private GravSetting currentRandomSetting;

	private GravSetting currentGravSetting = GravSetting.None;

	protected override void UpdateBehavior()
	{
		base.UpdateBehavior();
		if (currentGravSetting == GravSetting.Random)
		{
			currentRandomCycleTimer += Time.deltaTime;
		}
	}

	public void CycleGravity()
	{
		currentGravSetting++;
		if ((int)currentGravSetting >= EnumUtils.GetNumValues<GravSetting>())
		{
			currentGravSetting = GravSetting.Earth;
		}
	}

	public float GetGravMod()
	{
		if (currentGravSetting == GravSetting.Random)
		{
			if (currentRandomCycleTimer >= randomCycleFlip)
			{
				currentRandomCycleTimer = 0f;
				currentRandomSetting = EnumUtils.GetRandomElement<GravSetting>();
				if (currentRandomSetting == GravSetting.Random)
				{
					currentRandomSetting = GravSetting.None;
				}
			}
			return gravityValues[currentRandomSetting];
		}
		return gravityValues[currentGravSetting];
	}

	public string GetGravModName()
	{
		return currentGravSetting.ToString();
	}
}
