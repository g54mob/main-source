using System;
using UnityEngine;

public class HarvestTool : MonoBehaviour
{
	public Data.Resource resourceType;

	[NonSerialized]
	public Weapon weapon;

	private void Awake()
	{
		weapon = GetComponent<Weapon>();
	}
}
