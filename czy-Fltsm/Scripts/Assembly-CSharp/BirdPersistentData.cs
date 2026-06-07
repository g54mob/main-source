using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class BirdPersistentData : PersistentReference<Bird>
{
	[OptionalField]
	private ushort _descriptorId;

	public Vector3 Position;

	public Bird.BirdState State;

	[OptionalField(VersionAdded = 3)]
	public int Happiness = int.MaxValue;

	public bool Fed;

	public bool CurrentlyEating;

	public float EatTimer;

	public InventoryPersistentData Inventory;

	public PersistentReference<BirdHouse>.Reference Birdhouse;

	public PersistentReference<Item>.Reference ReservedItem;

	public bool ItemPickedUp;

	public Vector3 OutsideWorldTarget;

	public int PortraitIndex;

	[OptionalField(VersionAdded = 2)]
	public string Name;

	public int CyclesWithoutFood;

	private BirdPersistentData(Bird bird)
		: base(bird)
	{
		Position = bird.transform.position;
		Name = bird.Name;
		State = bird.State;
		Happiness = bird.Happiness;
		Fed = bird.IsFed;
		CurrentlyEating = bird.CurrentlyEating;
		EatTimer = bird.EatTimer;
		ItemPickedUp = bird.ItemPickedUp;
		OutsideWorldTarget = bird.OutsideWorldTarget;
		PortraitIndex = bird.PortraitIndex;
		Inventory = new InventoryPersistentData(bird.Inventory);
		bird.PopulateReferences(this);
	}

	public static bool TryPersist(Bird bird, out BirdPersistentData birdPersistentData)
	{
		birdPersistentData = null;
		if (bird == null)
		{
			Debug.LogException(new Exception("Unable to persist Bird."));
		}
		else
		{
			birdPersistentData = new BirdPersistentData(bird);
		}
		return birdPersistentData != null;
	}

	public void Restore(Community community)
	{
		Restore();
		base.Instance = RestoreDescriptor().Restore(community, this);
	}

	public BirdDescriptor RestoreDescriptor()
	{
		if (ActorDescriptor.TryGet<BirdDescriptor>(out var actorDescriptor, _descriptorId))
		{
			return actorDescriptor;
		}
		return actorDescriptor = BirdDescriptor.RestoreInstance(this);
	}
}
