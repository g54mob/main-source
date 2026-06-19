using System;
using System.Collections.Generic;
using UnityEngine;

public class Debris : ClickHitDummy
{
	public GameObject OnFinishEffect;

	public ItemType ItemType;

	public int ID;

	public static int HighestID;

	public static Dictionary<int, Debris> DebrisDictionary;

	public Action<Debris> AnnounceRemove;

	public DebrisAnimator Animator;

	public int DropCount;

	public bool Offline;

	public void OnSpawn()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public override void OnFinishingHit()
	{
	}

	public void AddDropCount(int count)
	{
	}
}
