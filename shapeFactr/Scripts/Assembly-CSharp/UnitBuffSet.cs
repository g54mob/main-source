using System;
using Libs;
using UnityEngine;

[Serializable]
public class UnitBuffSet : ISerializationCallbackReceiver
{
	[SerializeField]
	private JDictionary<int, float> _baseBuffSet;

	[SerializeField]
	private JDictionary<int, float> _ratioBuffSet;

	[SerializeField]
	private JDictionary<int, float> _relicBaseBuff;

	[SerializeField]
	private JDictionary<int, float> _relicRatioBuff;

	public JDictionary<int, float> BaseBuffSet
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public JDictionary<int, float> RatioBuffSet
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public JDictionary<int, float> RelicBaseBuff
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public JDictionary<int, float> RelicRatioBuff
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float GetTotalBasePoint(eAbilityEffectId effectId)
	{
		return 0f;
	}

	public float GetBaseBuffPoint(eAbilityEffectId effectId)
	{
		return 0f;
	}

	public float GetRatioBuffPoint(eAbilityEffectId effectId)
	{
		return 0f;
	}

	public float GetRalicBaseBuff(eAbilityEffectId effectId)
	{
		return 0f;
	}

	public float GetRelicRatioBuff(eAbilityEffectId effectId)
	{
		return 0f;
	}

	public void AddBaseBuffPoint(eAbilityEffectId effectId, float value)
	{
	}

	public void AddRatioBuffPoint(eAbilityEffectId effectId, float value)
	{
	}

	public void AddRelicBaseBuff(eAbilityEffectId effectId, float value)
	{
	}

	public void AddRelicRatioBuff(eAbilityEffectId effectId, float value)
	{
	}

	public float CalcBuff(eAbilityEffectId effectId, float value)
	{
		return 0f;
	}

	public double CalcBuff(eAbilityEffectId effectId, double value)
	{
		return 0.0;
	}

	public void ResetSkillBuff()
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
	}
}
