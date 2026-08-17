using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Other;

public class RunConfig
{
	public MapData mapData;

	public StageData stageData;

	public int mapTierIndex;

	public ChallengeData challenge;

	public int musicTrackIndex;

	private Dictionary<int, float> tierSilverMultipliers;

	public float GetEnemyHp(float hp)
	{
		//IL_0060: Expected O, but got I4
		MapData mapData = this.mapData;
		if (mapData.eMap != EMap.Graveyard)
		{
			bool flag = mapTierIndex == 0;
			if (flag)
			{
				return hp * 0.8f;
			}
			object obj = mapTierIndex - 1;
			if (flag)
			{
				return hp * 0.95f;
			}
			if ((nint)obj != 1)
			{
				return hp;
			}
		}
		return hp * 1.05f;
	}

	public float GetEnemySpeed(float speed)
	{
		//IL_0060: Expected O, but got I4
		MapData mapData = this.mapData;
		if (mapData.eMap != EMap.Graveyard)
		{
			bool flag = mapTierIndex == 0;
			if (flag)
			{
				return speed * 0.85f;
			}
			object obj = mapTierIndex - 1;
			if (flag)
			{
				return speed * 0.98f;
			}
			if ((nint)obj != 1)
			{
				return speed;
			}
		}
		return speed * 1.065f;
	}

	public float GetEnemyDamage(float value)
	{
		//IL_0060: Expected O, but got I4
		MapData mapData = this.mapData;
		if (mapData.eMap != EMap.Graveyard)
		{
			bool flag = mapTierIndex == 0;
			if (flag)
			{
				return value * 0.75f;
			}
			object obj = mapTierIndex - 1;
			if (flag)
			{
				return value * 0.95f;
			}
			if ((nint)obj != 1)
			{
				return value;
			}
		}
		return value * 1.1f;
	}

	private int GetIndexToMultiplier()
	{
		//IL_0066: Expected I4, but got O
		MapData mapData = this.mapData;
		if ((object)this.mapData != null)
		{
			if (mapData.eMap != EMap.Graveyard)
			{
				return mapTierIndex;
			}
			return 2;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public float GetSilverMultiplier()
	{
		if (tierSilverMultipliers != null)
		{
			float num = tierSilverMultipliers.get_Item(mapTierIndex);
			bool flag = challenge != null;
			bool flag2 = !flag;
			float result = num;
			if (!flag2)
			{
				ChallengeData challengeData = challenge;
				if ((object)challenge == null)
				{
					goto IL_00a2;
				}
				float num2 = challengeData.silverMultiplier - 1f;
				result = num + num2;
			}
			return result;
		}
		goto IL_00a2;
		IL_00a2:
		throw new NullReferenceException();
	}

	public string GetFormattedSilverMultiplier()
	{
		if (tierSilverMultipliers != null)
		{
			float num = tierSilverMultipliers.get_Item(mapTierIndex);
			bool flag = challenge != null;
			bool flag2 = !flag;
			float number = num;
			if (!flag2)
			{
				ChallengeData challengeData = challenge;
				if ((object)challenge == null)
				{
					goto IL_00a2;
				}
				float num2 = challengeData.silverMultiplier - 1f;
				number = num + num2;
			}
			return MyStringUtil.ShowOnlyDecimals(number);
		}
		goto IL_00a2;
		IL_00a2:
		return (string)(object)new NullReferenceException();
	}

	public RunConfig()
	{
		//IL_006c: Expected I4, but got I8
		musicTrackIndex = -1;
		tierSilverMultipliers = new Dictionary<int, float>
		{
			{ 0, 1f },
			{ 1, 1.1f },
			{ 2, 1.2f }
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
