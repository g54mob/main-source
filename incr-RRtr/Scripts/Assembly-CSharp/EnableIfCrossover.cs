using System.Collections.Generic;
using UnityEngine;

public class EnableIfCrossover : MonoBehaviour
{
	[SerializeField]
	private List<CrossoverFarmType> crossoverFarmTypes;

	private void Start()
	{
		if (!crossoverFarmTypes.Contains(SaveData.ins.crossoverFarmType))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
