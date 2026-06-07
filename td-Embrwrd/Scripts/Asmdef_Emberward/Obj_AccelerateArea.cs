using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_AccelerateArea : MonoBehaviour
{
	[SerializeField]
	private Obj_AreaMonsterDetector detector;

	[SerializeField]
	private float accelerateMultiplier;

	private float detectInterval;

	private float detectTimer;

	public Action<List<AMonsterBase>> OnDetectMonsters;

	private List<AMonsterBase> list_DetectedMonsters;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void Detect()
	{
	}

	private void CalculateMonsterMoveSpeedChange(AMonsterBase monster, Vector3 direction)
	{
	}
}
