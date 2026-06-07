using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Collections.Managed;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActorDescriptor : IPanelContext
{
	[Serializable]
	public abstract class PersistentDataBase
	{
		[OptionalField(VersionAdded = 1)]
		private ushort _uniqueID;

		[OptionalField(VersionAdded = 2)]
		private ActorType _actorType;

		[OptionalField(VersionAdded = 1)]
		private string _name;

		[OptionalField(VersionAdded = 1)]
		private int _actorProfileIndex;

		public ActorType ActorType => _actorType;

		public string Name => _name;

		protected PersistentDataBase(ActorDescriptor actorDescriptor)
		{
			_uniqueID = actorDescriptor.UniqueID;
			_actorType = actorDescriptor.ActorType;
			_name = actorDescriptor.Name;
			_actorProfileIndex = ((actorDescriptor.ActorProfile != null) ? GameManager.PersistenceManager.ReturnPropertiesIndex(actorDescriptor.ActorProfile) : (-1));
		}

		public abstract ActorDescriptor Restore();

		public virtual void Restore(ActorDescriptor instance)
		{
			instance.UniqueID = _uniqueID;
			instance.Restored = true;
			instance.ActorType = _actorType;
			instance.Name = _name;
			if (-1 < _actorProfileIndex && GameManager.PersistenceManager.TryReturnPropertiesReference<ActorProfile>(_actorProfileIndex, out var reference))
			{
				instance.ActorProfile = reference;
			}
		}
	}

	private static ManagedDictionary<ushort, ActorDescriptor> _actorDescriptors = new ManagedDictionary<ushort, ActorDescriptor>();

	public ushort UniqueID { get; private set; }

	public bool Restored { get; private set; }

	public ActorBehaviour Actor { get; private set; }

	public ActorType ActorType { get; private set; }

	public ActorProfile ActorProfile { get; protected set; }

	public string Name { get; protected set; }

	public abstract PanelID PanelID { get; }

	public abstract WorldMapScoutingId ScoutingId { get; }

	public UnityEvent<ActorDescriptor> UpdatedEvent { get; } = new UnityEvent<ActorDescriptor>();

	protected ActorDescriptor(ActorType actorType)
	{
		Dictionary<ushort, ActorDescriptor> dictionary = _actorDescriptors.Get();
		UniqueID = GenerateUniqueID(dictionary);
		ActorType = actorType;
		dictionary.Add(UniqueID, this);
	}

	protected ActorDescriptor(ActorProfile actorProfile)
		: this(actorProfile.ActorProperties.ActorType)
	{
		ActorProfile = actorProfile;
	}

	protected ActorDescriptor(PersistentDataBase persistentData)
	{
		persistentData.Restore(this);
		_actorDescriptors.Get().Add(UniqueID, this);
	}

	public static ActorDescriptor CreateInstance(ActorType actorType)
	{
		switch (actorType)
		{
		case ActorType.Agent:
			return AgentDescriptor.CreateInstance();
		case ActorType.Seagull:
			return BirdDescriptor.CreateInstance(actorType);
		default:
			Debug.LogException(new NotSupportedException());
			return null;
		}
	}

	public ActorBehaviour Spawn(Community community, Vector3 position)
	{
		Actor = SpawnActor(community, position);
		return Actor;
	}

	public T Spawn<T>(Community community, Vector3 position) where T : ActorBehaviour
	{
		return (T)(Actor = SpawnActor<T>(community, position));
	}

	public T Restore<T>(Community community, PersistentReference<T> persitentData) where T : ActorBehaviour, IPersistentReference
	{
		return (T)(Actor = RestoreActor(community, persitentData));
	}

	protected abstract ActorBehaviour SpawnActor(Community community, Vector3 position);

	protected abstract T SpawnActor<T>(Community community, Vector3 position) where T : ActorBehaviour;

	protected abstract T RestoreActor<T>(Community community, PersistentReference<T> persitentData) where T : ActorBehaviour, IPersistentReference;

	protected abstract string GenerateName();

	protected void OnActorKilled(ActorBehaviour actor)
	{
		if (Actor == actor)
		{
			Actor = null;
		}
	}

	public void SetName(string name)
	{
		Name = (string.IsNullOrWhiteSpace(name) ? GenerateName() : name);
		UpdatedEvent.Invoke(this);
	}

	public static bool TryGet<T>(out T actorDescriptor, ActorProfile actorProfile) where T : ActorDescriptor
	{
		foreach (ActorDescriptor value in _actorDescriptors.Get().Values)
		{
			if (!(value.ActorProfile != actorProfile))
			{
				actorDescriptor = value as T;
				return actorDescriptor != null;
			}
		}
		actorDescriptor = null;
		return false;
	}

	public static bool TryGet<T>(out T actorDescriptor, ushort id) where T : ActorDescriptor
	{
		actorDescriptor = null;
		if (id != 0 && _actorDescriptors.Get().TryGetValue(id, out var value))
		{
			actorDescriptor = value as T;
		}
		return actorDescriptor != null;
	}

	public static bool TryGet<T>(out T actorDescriptor, string localizationParameter) where T : ActorDescriptor
	{
		foreach (ActorDescriptor value in _actorDescriptors.Get().Values)
		{
			if ((bool)value.ActorProfile && value.ActorProfile.LocalizationParameter == localizationParameter)
			{
				actorDescriptor = value as T;
				return actorDescriptor != null;
			}
		}
		actorDescriptor = null;
		return false;
	}

	protected static T GetActorProperties<T>() where T : ActorProperties
	{
		if (GameManager.Settings.AgentSettings.TryGetActorProperties<T>(out var properties))
		{
			return properties;
		}
		Debug.LogException(new Exception("Unable to find ActorProperties of Type '" + typeof(T).Name + "'. Add an ActorProperties for this Type to AgentSettings!"));
		return null;
	}

	protected static T GetActorProperties<T>(ActorType actorType) where T : ActorProperties
	{
		if (GameManager.Settings.AgentSettings.TryGetActorProperties<T>(out var properties, actorType))
		{
			return properties;
		}
		Debug.LogException(new Exception($"Unable to find ActorProperties for ActorType.{actorType}. Add an ActorProperties for this type to AgentSettings!"));
		return null;
	}

	public virtual Sprite GetBearingIcon()
	{
		return null;
	}

	private ushort GenerateUniqueID(Dictionary<ushort, ActorDescriptor> actorDescriptors)
	{
		ushort num = 0;
		while (num++ < ushort.MaxValue)
		{
			if (!actorDescriptors.ContainsKey(num))
			{
				return num;
			}
		}
		Debug.LogException(new Exception("Unable to assign unique ID to ActorDescriptor, it seems al ids have been taken!"));
		return 0;
	}

	public abstract PersistentDataBase GetPersistentData();

	public static ActorDescriptorPersistentData ToPersistentData()
	{
		return new ActorDescriptorPersistentData(_actorDescriptors.Get().Values);
	}
}
