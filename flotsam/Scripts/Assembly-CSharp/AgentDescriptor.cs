using System;
using UnityEngine;
using UnityEngine.Events;

public class AgentDescriptor : ActorDescriptor
{
	[Serializable]
	protected class PersistentData : PersistentDataBase
	{
		private readonly Agent.EGender _gender = Agent.EGender.Male;

		private readonly int _voicePackID;

		private readonly float _voicePitch = 1f;

		private readonly int _lookPropertiesID;

		private readonly DrifterLookProperties.Indices _lookIndices;

		private readonly int _attributesVariation;

		private readonly bool _isRefugee;

		private readonly int _pastBackgroundID;

		private readonly int _presentBackgroundID;

		public PersistentData(AgentDescriptor descriptor)
			: base(descriptor)
		{
			_gender = descriptor.Gender;
			if (descriptor.VoicePack != null)
			{
				_voicePackID = GameManager.PersistenceManager.ReturnPropertiesIndex(descriptor.VoicePack);
			}
			_voicePitch = descriptor.VoicePitch;
			if (descriptor.LookProperties != null)
			{
				_lookPropertiesID = GameManager.PersistenceManager.ReturnPropertiesIndex(descriptor.LookProperties);
			}
			_lookIndices = descriptor.LookIndices;
			_attributesVariation = descriptor.AttributesVariation;
			_isRefugee = descriptor.IsRefugee;
			if (descriptor.PastBackground != null)
			{
				_pastBackgroundID = GameManager.PersistenceManager.ReturnPropertiesIndex(descriptor.PastBackground);
			}
			if (descriptor.PresentBackground != null)
			{
				_presentBackgroundID = GameManager.PersistenceManager.ReturnPropertiesIndex(descriptor.PresentBackground);
			}
		}

		public static PersistentData Get(AgentDescriptor actorDescriptor)
		{
			if (actorDescriptor == null)
			{
				Debug.LogException(new ArgumentException("Trying to persist an ActorDescriptor that is NULL."));
				return null;
			}
			return new PersistentData(actorDescriptor);
		}

		public static bool TryGet(AgentDescriptor actorDescriptor, out PersistentData persistentData)
		{
			persistentData = Get(actorDescriptor);
			return persistentData != null;
		}

		public override ActorDescriptor Restore()
		{
			AgentDescriptor agentDescriptor = new AgentDescriptor(this);
			agentDescriptor.Properties = GetProperties();
			agentDescriptor.AgentProfile = agentDescriptor.ActorProfile as AgentProfile;
			agentDescriptor.Gender = _gender;
			if (_voicePackID != -1)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<VoicePackProperties>(_voicePackID, out var reference))
				{
					agentDescriptor.VoicePack = reference;
				}
				else
				{
					Debug.LogError("Could not restore voicePack for " + base.Name + ".");
				}
			}
			agentDescriptor.VoicePitch = _voicePitch;
			if (_lookPropertiesID != -1)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterLookProperties>(_lookPropertiesID, out var reference2))
				{
					agentDescriptor.LookProperties = reference2;
				}
				else
				{
					Debug.LogError("Could not restore lookProperties for " + base.Name + ".");
				}
			}
			agentDescriptor.LookIndices = _lookIndices;
			agentDescriptor.AttributesVariation = _attributesVariation;
			agentDescriptor.IsRefugee = _isRefugee;
			if (_pastBackgroundID != -1)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterAttributesEffect>(_pastBackgroundID, out var reference3))
				{
					agentDescriptor.PastBackground = reference3;
				}
				else
				{
					Debug.LogError("Could not restore pastBackground for " + base.Name + ".");
				}
			}
			if (_presentBackgroundID != -1)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterAttributesEffect>(_presentBackgroundID, out var reference4))
				{
					agentDescriptor.PresentBackground = reference4;
				}
				else
				{
					Debug.LogError("Could not restore presentBackground for " + base.Name + ".");
				}
			}
			return agentDescriptor;
		}
	}

	public Agent Agent { get; private set; }

	public AgentProperties Properties { get; private set; }

	public AgentProfile AgentProfile { get; private set; }

	public Agent.EGender Gender { get; private set; } = Agent.EGender.Male;

	public VoicePackProperties VoicePack { get; private set; }

	public float VoicePitch { get; private set; } = 1f;

	public DrifterLookProperties LookProperties { get; private set; }

	public DrifterLookProperties AlternativeLook { get; private set; }

	public DrifterLookProperties.Indices LookIndices { get; private set; }

	public int AttributesVariation { get; private set; }

	public bool IsRefugee { get; private set; }

	public DrifterAttributesEffect PastBackground { get; private set; }

	public DrifterAttributesEffect PresentBackground { get; private set; }

	public DialogueTreeProperties DialogueProperties
	{
		get
		{
			if (!(AgentProfile != null))
			{
				return null;
			}
			return AgentProfile.DialogueProperties;
		}
	}

	public override PanelID PanelID => PanelID.AgentPanel;

	public override WorldMapScoutingId ScoutingId
	{
		get
		{
			if (!(PastBackground != null))
			{
				return WorldMapScoutingId.Drifter;
			}
			return PastBackground.ScoutingId;
		}
	}

	public UnityEvent OnLookUpdated { get; } = new UnityEvent();

	private AgentDescriptor(AgentProperties properties)
		: base(properties.ActorType)
	{
		Properties = properties;
	}

	private AgentDescriptor(AgentProfile agentProfile)
		: base(agentProfile)
	{
		Properties = agentProfile.Properties;
		AgentProfile = agentProfile;
	}

	private AgentDescriptor(PersistentData persistentData)
		: base(persistentData)
	{
	}

	public static AgentDescriptor CreateInstance()
	{
		AgentDescriptor agentDescriptor = new AgentDescriptor(GetProperties());
		agentDescriptor.Initialize();
		return agentDescriptor;
	}

	public static AgentDescriptor CreateInstance(DrifterAttributesEffect pastBackground = null)
	{
		AgentDescriptor agentDescriptor = new AgentDescriptor(GetProperties());
		agentDescriptor.Initialize(pastBackground);
		return agentDescriptor;
	}

	public static AgentDescriptor CreateInstance(AgentProfile agentProfile)
	{
		AgentDescriptor agentDescriptor = new AgentDescriptor(agentProfile);
		agentDescriptor.Initialize(agentProfile.GetRandomGender(), agentProfile.Name, agentProfile.PastBackground);
		return agentDescriptor;
	}

	public static AgentDescriptor Restore(AgentPersistentData persistentData)
	{
		AgentDescriptor agentDescriptor = new AgentDescriptor(GetProperties());
		if (!GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterAttributesEffect>(persistentData.PastBackground, out var reference))
		{
			Debug.LogException(new Exception("Could not restore past background for " + persistentData.Name + "."));
		}
		if (!GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterAttributesEffect>(persistentData.PresentBackground, out var reference2))
		{
			Debug.LogException(new Exception("Could not restore present background for " + persistentData.Name + "."));
		}
		agentDescriptor.Initialize(persistentData.Gender, persistentData.Name, reference, reference2);
		agentDescriptor.SetVoicePack(persistentData.VoicePackIndex);
		if (persistentData.VoicePitch > 0f)
		{
			agentDescriptor.SetVoicePitch(persistentData.VoicePitch);
		}
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<DrifterLookProperties>(persistentData.LookProperties, out var reference3))
		{
			agentDescriptor.SetLookProperties(reference3);
		}
		else
		{
			Debug.LogException(new Exception("Could not restore looks for " + persistentData.Name + "."));
		}
		return agentDescriptor;
	}

	protected override ActorBehaviour SpawnActor(Community community, Vector3 position)
	{
		return Spawn<Agent>(community, position);
	}

	protected override T SpawnActor<T>(Community community, Vector3 position)
	{
		if (Agent == null)
		{
			Agent = UnityEngine.Object.Instantiate(Properties.Prefab, position, Quaternion.identity, GameManager.AgentManager.AgentParent);
			Agent.Spawn(this, community);
			PortraitGenerator.GeneratePortrait(this);
		}
		return Agent as T;
	}

	protected override T RestoreActor<T>(Community community, PersistentReference<T> persitentData)
	{
		if (!(persitentData is AgentPersistentData agentPersistentData))
		{
			Debug.LogException(new NotImplementedException());
			return null;
		}
		if (Agent == null)
		{
			Agent = UnityEngine.Object.Instantiate(Properties.Prefab, agentPersistentData.Position, Quaternion.identity, GameManager.AgentManager.AgentParent);
			Agent.RestoreSpawn(this, community, agentPersistentData);
		}
		return Agent as T;
	}

	private void Initialize()
	{
		Initialize(Properties.GetRandomGender());
	}

	private void Initialize(DrifterAttributesEffect pastBackground, DrifterAttributesEffect presentBackground = null)
	{
		Initialize(Properties.GetRandomGender(), null, pastBackground, presentBackground);
	}

	private void Initialize(Agent.EGender gender, string name = null, DrifterAttributesEffect pastBackground = null, DrifterAttributesEffect presentBackground = null)
	{
		PresentBackground = ((presentBackground == null) ? Properties.PresentBackgrounds.GetRandom() : presentBackground);
		SetPastBackground((pastBackground == null) ? Properties.PastBackgrounds.GetRandom() : pastBackground, gender);
		SetName(name.IsNullOrEmpty() ? GenerateName() : name);
		SetAttributeVariation(PastBackground, PresentBackground);
	}

	public void Reroll(DrifterAttributesEffect pastBackground, DrifterAttributesEffect presentBackground)
	{
		Initialize(Properties.GetRandomGender(), null, pastBackground, presentBackground);
	}

	public void ApplyLooks(DrifterRig rig)
	{
		LookProperties.ApplyIndices(rig, LookIndices);
	}

	public void ApplyLooksForPortrait(DrifterRig rig, DrifterLookCamera camera, bool applyAlternativeLook)
	{
		ApplyLooks(rig);
		if (applyAlternativeLook && AlternativeLook != null)
		{
			AlternativeLook.Apply(rig, camera);
		}
	}

	public void ApplyAlternativeLook(DrifterLookProperties alternativeLookProperties, DrifterRig rig)
	{
		if (AlternativeLook != null)
		{
			UndoAlternativeLook(AlternativeLook, rig);
		}
		AlternativeLook = alternativeLookProperties;
		AlternativeLook.Apply(rig);
		OnLookUpdated.Invoke();
	}

	public void UndoAlternativeLook(DrifterLookProperties alternativeLookProperties, DrifterRig rig)
	{
		if ((bool)alternativeLookProperties && AlternativeLook == alternativeLookProperties)
		{
			AlternativeLook = null;
			LookProperties.ApplyIndices(rig, LookIndices);
			OnLookUpdated.Invoke();
		}
	}

	public void OnAgentKilled()
	{
		OnActorKilled(Agent);
		Agent = null;
	}

	protected override string GenerateName()
	{
		return Gender switch
		{
			Agent.EGender.Female => FlotsamGame.Random(Properties.FemaleNameGenerators).ReturnName(), 
			Agent.EGender.Male => FlotsamGame.Random(Properties.MaleNameGenerators).ReturnName(), 
			_ => throw new NotImplementedException($"No name generators set for gender {Gender}."), 
		};
	}

	private bool SetGender(Agent.EGender gender)
	{
		Gender = gender;
		VoicePack = Properties.ReturnRandomVoicePack(gender);
		VoicePitch = UnityEngine.Random.Range(Properties.MinVoicePitch, Properties.MaxVoicePitch);
		return true;
	}

	public void SetLookProperties(DrifterLookProperties lookProperties)
	{
		if (!LookProperties || !(LookProperties == lookProperties))
		{
			LookProperties = ((lookProperties != null) ? lookProperties : Properties.DrifterLooks.ReturnRandomLookProperties(Gender));
			LookIndices = LookProperties.GetRandomIndices();
		}
	}

	public void SetVoicePack(int index)
	{
		VoicePack = Properties.ReturnVoicePack(Gender, index);
	}

	public void SetVoicePitch(float pitch)
	{
		VoicePitch = pitch;
	}

	public void SetIsRefugee(bool isRefugee)
	{
		IsRefugee = isRefugee;
	}

	public void SetPastBackground(DrifterAttributesEffect background)
	{
		SetPastBackground(background, Gender);
	}

	private void SetPastBackground(DrifterAttributesEffect background, Agent.EGender gender)
	{
		PastBackground = background;
		SetGender(PastBackground.ReturnGender(gender));
		SetLookProperties(PastBackground.Look);
	}

	public void SetAttributesVariation(int variation)
	{
		AttributesVariation = variation;
	}

	private void SetAttributeVariation(params DrifterAttributesEffect[] backgrounds)
	{
		using ListPool<DrifterAttributeModifier>.List list = ListPool<DrifterAttributeModifier>.Get();
		int num = 0;
		for (int i = 0; i < backgrounds.Length; i++)
		{
			DrifterAttributeModifier[] modifiers = backgrounds[i].Modifiers;
			foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
			{
				if (num < drifterAttributeModifier.Affinity)
				{
					list.Clear();
					list.Add(drifterAttributeModifier);
					num = drifterAttributeModifier.Affinity;
				}
				else if (num == drifterAttributeModifier.Affinity)
				{
					list.Add(drifterAttributeModifier);
				}
			}
		}
		if (0 < list.Count)
		{
			SetAttributesVariation((int)list.GetRandom().Type);
		}
	}

	public bool TryGetQuestToStart(out QuestProperties questProperties)
	{
		if (HasQuestToStart())
		{
			questProperties = AgentProfile.Quest;
			return true;
		}
		questProperties = null;
		return false;
	}

	public bool HasQuestToStart()
	{
		if ((bool)AgentProfile)
		{
			return AgentProfile.HasQuestToStart(this);
		}
		return false;
	}

	public override Sprite GetBearingIcon()
	{
		if (!HasQuestToStart())
		{
			if (!AgentProfile || !AgentProfile.BearingIcon)
			{
				return null;
			}
			return AgentProfile.BearingIcon;
		}
		return GameSettings.Instance.LandmarkSettings.DistressSignalBearingIcon;
	}

	public static AgentProperties GetProperties()
	{
		return ActorDescriptor.GetActorProperties<AgentProperties>();
	}

	public static bool operator ==(AgentDescriptor a, AgentDescriptor b)
	{
		if ((object)a != null || (object)b != null)
		{
			if ((object)a != null && (object)b != null)
			{
				return a.UniqueID == b.UniqueID;
			}
			return false;
		}
		return true;
	}

	public static bool operator !=(AgentDescriptor a, AgentDescriptor b)
	{
		return !(a == b);
	}

	public override bool Equals(object other)
	{
		if (other is AgentDescriptor agentDescriptor)
		{
			return this == agentDescriptor;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.UniqueID;
	}

	public void RestoreLooks(DrifterRig drifterRig)
	{
		LookIndices = LookProperties.ReturnIndices(drifterRig, out var reapply);
		if (reapply)
		{
			ApplyLooks(drifterRig);
		}
	}

	public override PersistentDataBase GetPersistentData()
	{
		return new PersistentData(this);
	}
}
