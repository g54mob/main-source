using System;
using NBT.Tags;
using UnityEngine;

public class DeliveryPad : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int resourceType;

		private int capacity;

		private bool repeatMission;

		public ClonePack(int resourceType, int capacity, bool repeatMission)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	public GameObject deliveryPadPanePrefab;

	[NonSerialized]
	public DeliveryDrone deliveryDrone;

	private int buildDroneInterval;

	private int buildDroneCounter;

	[NonSerialized]
	public Pod pod;

	private int buildPodInterval;

	private int buildPodCounter;

	private TargetIndicator targetIndicator;

	public GameObject typeQuad;

	private DeliveryPadPane deliveryPadPane;

	private int hideCounter;

	private int showingPathCount;

	[NonSerialized]
	public bool repeatMission;

	[NonSerialized]
	public bool autoBeam;

	[NonSerialized]
	public string autoBeamPlayer;

	private int _capacity;

	private int _resourceType;

	private Vector2 _deliveryTarget;

	public int capacity
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int resourceType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Vector2 deliveryTarget
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	public override bool selected
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

	public override void BuildComplete()
	{
	}

	public override void OnMouseOver()
	{
	}

	public void ShowPath()
	{
	}

	public override TargetIndicator CreateTargetIndicator()
	{
		return null;
	}

	public override IClonePack GetClonePack()
	{
		return null;
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

	public void CreateMVerseUnit()
	{
	}

	public override void GameUpdate()
	{
	}

	public override void IndicateTarget(TargetIndicator ti)
	{
	}

	public float GetPodStorage()
	{
		return 0f;
	}

	private void SetRequirements(bool energy)
	{
	}

	public void CancelRoute()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
