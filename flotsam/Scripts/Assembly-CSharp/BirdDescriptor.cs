using System;
using UnityEngine;

public class BirdDescriptor : AnimalDescriptor
{
	[Serializable]
	public class PersistentData : AnimaleDescriptorPersistentData
	{
		public PersistentData(AnimalDescriptor animalDescriptor)
			: base(animalDescriptor)
		{
		}

		public override ActorDescriptor Restore()
		{
			return new BirdDescriptor(ActorDescriptor.GetActorProperties<BirdProperties>(), this);
		}
	}

	public Bird Bird { get; private set; }

	public BirdProperties Properties { get; private set; }

	public override WorldMapScoutingId ScoutingId => WorldMapScoutingId.Seagull;

	private BirdDescriptor(BirdProperties properties)
		: base(properties)
	{
		Properties = properties;
	}

	private BirdDescriptor(BirdProperties birdProperties, PersistentData persistentData)
		: base(birdProperties, persistentData)
	{
		Properties = birdProperties;
	}

	public new static BirdDescriptor CreateInstance(ActorType actorType = ActorType.Seagull)
	{
		return new BirdDescriptor(ActorDescriptor.GetActorProperties<BirdProperties>(actorType));
	}

	public static BirdDescriptor RestoreInstance(BirdPersistentData birdPersistentData)
	{
		BirdDescriptor birdDescriptor = new BirdDescriptor(ActorDescriptor.GetActorProperties<BirdProperties>(ActorType.Seagull));
		birdDescriptor.SetName(birdPersistentData.Name);
		birdDescriptor.SetPortraitIndex(birdPersistentData.PortraitIndex);
		return birdDescriptor;
	}

	protected override ActorBehaviour SpawnActor(Community community, Vector3 position)
	{
		return SpawnActor<Bird>(community, position);
	}

	protected override T SpawnActor<T>(Community community, Vector3 position)
	{
		if (Bird == null)
		{
			Bird = UnityEngine.Object.Instantiate(Properties.Prefab, position, Quaternion.identity, GameManager.AgentManager.AgentParent);
			Bird.Initialize(this, community);
		}
		return Bird as T;
	}

	protected override T RestoreActor<T>(Community community, PersistentReference<T> persitentData)
	{
		if (!(persitentData is BirdPersistentData birdPersistentData))
		{
			Debug.LogException(new NotImplementedException());
			return null;
		}
		if (Bird == null)
		{
			Bird = UnityEngine.Object.Instantiate(Properties.Prefab, birdPersistentData.Position, Quaternion.identity, GameManager.AgentManager.AgentParent);
			Bird.Initialize(this, community, birdPersistentData);
			Bird.Restore(birdPersistentData);
		}
		return Bird as T;
	}

	public override PersistentDataBase GetPersistentData()
	{
		return new PersistentData(this);
	}
}
