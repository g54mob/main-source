using System.Collections.Generic;
using UnityEngine;

public class PlantConstructor : MonoBehaviour
{
	[SerializeField]
	private PotsSO potsSO;

	private int listSize = 3;

	private List<int> pots2x2UsedList = new List<int>();

	private List<int> pots3x3UsedList = new List<int>();

	private List<int> pots4x4UsedList = new List<int>();

	public static PlantConstructor Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public (Transform, int) GetRandomPot(Vector2Int size)
	{
		Transform item = null;
		int num = 0;
		if (size == new Vector2Int(2, 2) && potsSO.pots2x2.Count != 0)
		{
			num = GetUniquePotIndex(potsSO.pots2x2, pots2x2UsedList);
			item = potsSO.pots2x2[num].transform;
		}
		if (size == new Vector2Int(3, 3) && potsSO.pots3x3.Count != 0)
		{
			num = GetUniquePotIndex(potsSO.pots3x3, pots3x3UsedList);
			item = potsSO.pots3x3[num].transform;
		}
		if (size == new Vector2Int(4, 4) && potsSO.pots4x4.Count != 0)
		{
			num = GetUniquePotIndex(potsSO.pots4x4, pots4x4UsedList);
			item = potsSO.pots4x4[num].transform;
		}
		return (item, num);
	}

	public Transform GetPotByIndex(Vector2Int size, int index)
	{
		switch (size.x)
		{
		case 2:
			if (size.y != 2)
			{
				break;
			}
			return potsSO.pots2x2[index].transform;
		case 3:
			if (size.y != 3)
			{
				break;
			}
			return potsSO.pots3x3[index].transform;
		case 4:
			if (size.y != 4)
			{
				break;
			}
			return potsSO.pots4x4[index].transform;
		}
		return null;
	}

	private int GetUniquePotIndex(List<Transform> potsList, List<int> potsUsedList)
	{
		int num = Random.Range(0, potsList.Count);
		if (potsUsedList.Count != 0)
		{
			do
			{
				num = Random.Range(0, potsList.Count);
			}
			while (potsUsedList.Contains(num));
		}
		if (potsUsedList.Count < listSize)
		{
			potsUsedList.Add(num);
		}
		else
		{
			for (int i = 0; i < potsUsedList.Count - 1; i++)
			{
				potsUsedList[i] = potsUsedList[i + 1];
			}
			potsUsedList[listSize - 1] = num;
		}
		return num;
	}
}
