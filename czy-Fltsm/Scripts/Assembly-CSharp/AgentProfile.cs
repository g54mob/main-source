using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentProfile", menuName = "Flotsam/Actor Profile")]
public class AgentProfile : ActorProfile
{
	[Header("Agent")]
	[SerializeField]
	private AgentProperties _properties;

	[SerializeField]
	private List<Agent.EGender> _genders = new List<Agent.EGender>();

	[SerializeField]
	private DrifterAttributesEffect _pastBackground;

	[SerializeField]
	private ItemProperties[] _items;

	[SerializeField]
	private Sprite _bearingIcon;

	[Header("Spawning")]
	[SerializeField]
	private QuestProperties _quest;

	[SerializeField]
	private bool _questRequiresSaveWithMinimumVersion;

	[SerializeField]
	private GameVersion _questMinimumVersion;

	[SerializeField]
	private LandmarkBehaviour _landmark;

	[SerializeField]
	private WorldRegionType[] _regions;

	public AgentProperties Properties => _properties;

	public override ActorProperties ActorProperties => _properties;

	public DrifterAttributesEffect PastBackground => _pastBackground;

	public ItemProperties[] Items => _items;

	public Sprite BearingIcon => _bearingIcon;

	public QuestProperties Quest => _quest;

	public WorldRegionType[] Regions => _regions;

	public bool HasQuestToStart(AgentDescriptor agentDescriptor)
	{
		SaveMetaInfo saveMetaInfo = PersistenceManager.SaveMetaInfo;
		if (Quest != null && !StoryManager.TryGetQuest(Quest, out var _))
		{
			if (agentDescriptor.Restored && _questRequiresSaveWithMinimumVersion && saveMetaInfo != null)
			{
				return !saveMetaInfo.Version.ReturnComesBefore(_questMinimumVersion);
			}
			return true;
		}
		return false;
	}

	public override bool Spawn(ILandmarkPickerSettings settings)
	{
		if (settings.SpawnDrifter(GetDescriptor(), _quest, _landmark))
		{
			return true;
		}
		Debug.LogException(new Exception("Unable to spawn drifter profile '" + base.name + "'"));
		return false;
	}

	public override bool Spawn(ILandmarkPickerSettings settings, out LandmarkSpawner landmarkSpawner)
	{
		if (settings.SpawnDrifter(out landmarkSpawner, GetDescriptor(), _quest, _landmark))
		{
			return true;
		}
		Debug.LogException(new Exception("Unable to spawn drifter profile '" + base.name + "'"));
		landmarkSpawner = null;
		return false;
	}

	public Agent.EGender GetRandomGender()
	{
		if (!_genders.IsNullOrEmpty())
		{
			return _genders.GetRandom();
		}
		return _properties.GetRandomGender();
	}

	public override ActorDescriptor GetActorDiscriptor()
	{
		return GetDescriptor();
	}

	public AgentDescriptor GetDescriptor(AgentDescriptor descriptorToPopulate = null)
	{
		if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, this))
		{
			return actorDescriptor;
		}
		return AgentDescriptor.CreateInstance(this);
	}
}
