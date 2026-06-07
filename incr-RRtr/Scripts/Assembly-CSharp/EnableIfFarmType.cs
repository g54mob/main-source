using System.Collections.Generic;
using UnityEngine;

public class EnableIfFarmType : MonoBehaviour
{
	[SerializeField]
	private List<SaveData.FarmType> farmTypes;

	private void Start()
	{
		if (!farmTypes.Contains(SaveData.ins.farmType))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
