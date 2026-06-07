using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Obj_OrcTotem : MonoBehaviour
{
	[SerializeField]
	private float range;

	[SerializeField]
	private float healPercentPerSecond;

	[SerializeField]
	private float healInterval;

	[SerializeField]
	private Transform node_AreaRing;

	[SerializeField]
	private Obj_AreaMonsterDetector monsterDetector;

	[SerializeField]
	private Transform node_Totem;

	private float healTimer;

	private List<AMonsterBase> list_DetectedMonsters;

	private Tweener tween_ShakeTotem;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void HealMonstersInArea()
	{
	}
}
