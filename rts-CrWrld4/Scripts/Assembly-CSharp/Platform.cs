using System.Collections.Generic;
using UnityEngine;

public class Platform : UnitManager
{
	public const int PLACEMENT_RANGE = 22;

	private Vector3 deployedPlatformPosition;

	public ParticleSystem[] exhausts;

	public GameObject tower;

	private float AMMO_USE;

	private bool _canPass;

	private bool _elevatedHeight;

	private bool canPass
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override string officialName => null;

	private bool elevatedHeight
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public override void MovedInEdit()
	{
	}

	private HashSet<UnitManager> GetLandedUnits()
	{
		return null;
	}

	private void DeployPlatform(bool deploy)
	{
	}

	private void DeployPlatform(bool deploy, int gsx, int gsy)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	private void SetTowerColor(Color32 color)
	{
	}
}
