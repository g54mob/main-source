using System;
using System.Collections.Generic;
using UnityEngine;

public class SwapForCrossover : MonoBehaviour
{
	[Serializable]
	public struct SwapObject
	{
		public CrossoverFarmType crossoverFarmType;

		public GameObject swapObject;
	}

	[SerializeField]
	private bool destroyInstead;

	[Header("Deactivate this object and enable one from the list below")]
	public List<SwapObject> swapObjects;

	private void Start()
	{
		if (!SaveData.ins.checkIfCrossover(out var crossover))
		{
			return;
		}
		for (int i = 0; i < swapObjects.Count; i++)
		{
			if (crossover == swapObjects[i].crossoverFarmType)
			{
				Debug.Log(i, this);
				swapObjects[i].swapObject.SetActive(value: true);
				base.gameObject.SetActive(value: false);
				if (destroyInstead)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			}
		}
	}
}
