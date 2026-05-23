using System;
using Libs;
using SaveData;
using UnityEngine;

[Serializable]
public class BuffSet<T> : ISerializationCallbackReceiver where T : struct, IConvertible
{
	[SerializeField]
	private JDictionary<int, BuffData> baseBuffDatas;

	[SerializeField]
	private JDictionary<int, BuffData> ratioBuffDatas;

	public JDictionary<int, BuffData> BaseBuffDatas => null;

	public JDictionary<int, BuffData> RatioBuffDatas => null;

	public void AddBuff(T id, float value, int isSum, eArchiveCategory sourceCategory = eArchiveCategory.None, string sourceId = "", bool persistence = true)
	{
	}

	public float GetBasePoint(T buffId)
	{
		return 0f;
	}

	public float GetBasePoint(int buffId)
	{
		return 0f;
	}

	public float GetRatioPoint(T buffId)
	{
		return 0f;
	}

	public float GetRatioPoint(int buffId)
	{
		return 0f;
	}

	public bool EnableBuff(T buffId)
	{
		return false;
	}

	public float CalcBuff(T buffId, float value)
	{
		return 0f;
	}

	public double CalcBuff(T buffId, double value)
	{
		return 0.0;
	}

	public void CheckAllPersistent(eArchiveCategory categoryFilter = eArchiveCategory.None)
	{
	}

	public void RemoveAllBySourceCategory(eArchiveCategory category)
	{
	}

	public void RemoveBuff(T buffId)
	{
	}

	public BuffData GetBaseBuffData(T buffId)
	{
		return null;
	}

	public override string ToString()
	{
		return null;
	}

	public void OnAfterDeserialize()
	{
	}

	public void OnBeforeSerialize()
	{
	}
}
