using System.Collections.Generic;
using UnityEngine;

public static class EarModInfo
{
	private static List<Transform> transformList = new List<Transform>();

	private static float AA_Min = 0.4f;

	private static float AA_Max = 0.3f;

	private static float BA_Min = 0.8f;

	private static float BA_Max = 0.5f;

	private static float bentMin = 0.2f;

	private static float bentMax = 0.2f;

	private static float crossMin = 0.15f;

	private static float crossMax = 0.225f;

	private static float twistMin = 0.15f;

	private static float twistMax = 0.225f;

	private static float wavyMin = 0.2f;

	private static float wavyMax = 0.225f;

	public static float GetModAMin(EarType type)
	{
		switch (type)
		{
		case EarType.TYPE_A:
			return AA_Min;
		case EarType.TYPE_B:
			return BA_Min;
		case EarType.BENT:
			return bentMin;
		case EarType.CROSS:
			return crossMin;
		case EarType.TWISTED:
			return twistMin;
		case EarType.WAVY:
			return wavyMin;
		default:
			return 0f;
		}
	}

	public static float GetModAMax(EarType type)
	{
		switch (type)
		{
		case EarType.TYPE_A:
			return AA_Max;
		case EarType.TYPE_B:
			return BA_Max;
		case EarType.BENT:
			return bentMax;
		case EarType.CROSS:
			return crossMax;
		case EarType.TWISTED:
			return twistMax;
		case EarType.WAVY:
			return wavyMax;
		default:
			return 0f;
		}
	}

	public static void ApplyModA(GameObject earsHolder, float modValue, EarType type)
	{
		switch (type)
		{
		case EarType.TYPE_A:
			ApplyModAA(earsHolder, modValue);
			break;
		case EarType.TYPE_B:
			ApplyModBA(earsHolder, modValue);
			break;
		case EarType.BENT:
			ApplyModAA(earsHolder, modValue);
			break;
		case EarType.CROSS:
			ApplyModAA(earsHolder, modValue);
			break;
		case EarType.TWISTED:
			ApplyModAA(earsHolder, modValue);
			break;
		case EarType.WAVY:
			ApplyModAA(earsHolder, modValue);
			break;
		case EarType.BLUNT:
		case EarType.BULBOUS:
		case EarType.HORN:
		case EarType.SHEPHERD:
			break;
		}
	}

	private static void ApplyModAA(GameObject earsHolder, float modValue)
	{
		earsHolder.transform.localPosition -= modValue * earsHolder.transform.right;
	}

	private static void ApplyModBA(GameObject earsHolder, float modValue)
	{
		for (int i = 0; i < earsHolder.transform.childCount; i++)
		{
			transformList.Add(earsHolder.transform.GetChild(i));
		}
		for (int j = 0; j < transformList.Count; j++)
		{
			transformList[j].SetParent(null);
			transformList[j].localPosition += transformList[j].up * modValue * transformList[j].localScale.x;
			transformList[j].SetParent(earsHolder.transform);
		}
		transformList.Clear();
	}
}
