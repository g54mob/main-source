using UnityEngine;

public class Microrift : UnitManager
{
	public GameObject ring;

	public GameObject effect;

	public override bool unitEnabled
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

	public override void BuildComplete()
	{
	}

	public override void GameUpdate()
	{
	}

	public new void Update()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}
}
