using System;
using UnityEngine;

public class MissileLauncherRangeIndicator : MonoBehaviour
{
	public bool MoveGhost;

	[NonSerialized]
	public MissileLauncher unit;

	[NonSerialized]
	public int range;

	private float rangeUpgradeBoost;

	private void Awake()
	{
	}

	public void Start()
	{
	}

	public int MyRange()
	{
		return 0;
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}
}
