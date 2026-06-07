using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obj_TetrisBlock))]
public class TetrisModule_DamageMonstersAround : MonoBehaviour
{
	[SerializeField]
	private Obj_TetrisBlock block;

	[SerializeField]
	private float updateInterval;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float range;

	[SerializeField]
	private Material material;

	[SerializeField]
	private eDamageType damageType;

	private float timer;

	private List<Vector3> list_BlockPos;

	public void Setup(Obj_TetrisBlock block, int damage, float updateInterval, float range, eDamageType damageType)
	{
	}

	private void Update()
	{
	}
}
