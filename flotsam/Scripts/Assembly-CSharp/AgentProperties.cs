using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent Properties")]
public class AgentProperties : ActorProperties
{
	[Header("General")]
	[SerializeField]
	private Agent _prefab;

	[SerializeField]
	private int _storageCapacity = 5;

	[Header("Name")]
	[SerializeField]
	private List<NameGenerator> _maleNameGenerators = new List<NameGenerator>();

	[SerializeField]
	private List<NameGenerator> _femaleNameGenerators = new List<NameGenerator>();

	[Header("Attributes")]
	[SerializeField]
	private DrifterAttributes _attributeProperties;

	[SerializeField]
	private List<DrifterAttributesEffect> _pastBackgrounds = new List<DrifterAttributesEffect>();

	[SerializeField]
	private List<DrifterAttributesEffect> _presentBackgrounds = new List<DrifterAttributesEffect>();

	[SerializeField]
	private List<DrifterAttributesEffect> _specializedBackgrounds = new List<DrifterAttributesEffect>();

	[Header("Vitals")]
	[SerializeField]
	private VitalProperties _vitalProperties;

	[Header("Visuals")]
	[SerializeField]
	[ConditionalHide("IsHuman")]
	private GameObject _backpackPrefab;

	[SerializeField]
	private DrifterLookSettings _drifterLooks;

	[Space]
	[SerializeField]
	private VisualPrefab _agentRemains;

	[SerializeField]
	private Sprite _portraitSprite;

	[Header("Sound")]
	[SerializeField]
	private List<VoicePackProperties> _maleVoicePacks = new List<VoicePackProperties>();

	[SerializeField]
	private List<VoicePackProperties> _femaleVoicePacks = new List<VoicePackProperties>();

	[SerializeField]
	private float _minVoicePitch = 1f;

	[SerializeField]
	private float _maxVoicePitch = 1f;

	[Header("Idle Feedback")]
	[SerializeField]
	private RandomInRange _idleTimeBeforeFeedback = new RandomInRange(100f, 120f);

	[SerializeField]
	private float _attentionDuration = 5f;

	[SerializeField]
	private RandomInRange _attentionInterval = new RandomInRange(10f, 15f);

	[EnumFlag(1)]
	[SerializeField]
	private ProjectBlocker _handledBlockers = ProjectBlocker.StorageSpace;

	public Agent Prefab => _prefab;

	public int StorageCapacity => _storageCapacity;

	public IReadOnlyList<NameGenerator> MaleNameGenerators => _maleNameGenerators;

	public IReadOnlyList<NameGenerator> FemaleNameGenerators => _femaleNameGenerators;

	public DrifterAttributes AttributeProperties => _attributeProperties;

	public IReadOnlyList<DrifterAttributesEffect> PastBackgrounds => _pastBackgrounds;

	public IReadOnlyList<DrifterAttributesEffect> PresentBackgrounds => _presentBackgrounds;

	public IReadOnlyList<DrifterAttributesEffect> SpecializedBackgrounds => _specializedBackgrounds;

	public VitalProperties VitalProperties => _vitalProperties;

	public GameObject BackpackPrefab => _backpackPrefab;

	public DrifterLookSettings DrifterLooks => _drifterLooks;

	public VisualPrefab AgentRemains => _agentRemains;

	public Sprite PortraitSprite => _portraitSprite;

	public IReadOnlyList<VoicePackProperties> MaleVoicePacks => _maleVoicePacks;

	public IReadOnlyList<VoicePackProperties> FemaleVoicePacks => _femaleVoicePacks;

	public float MinVoicePitch => _minVoicePitch;

	public float MaxVoicePitch => _maxVoicePitch;

	public RandomInRange IdleTimeBeforeFeedback => _idleTimeBeforeFeedback;

	public float AttentionDuration => _attentionDuration;

	public RandomInRange AttentionInterval => _attentionInterval;

	public ProjectBlocker HandledBlockers => _handledBlockers;

	public override void Initialize()
	{
		VitalProperties.Initialize();
	}

	public Agent.EGender GetRandomGender(DrifterAttributesEffect drifterAttributesEffect = null)
	{
		return drifterAttributesEffect.ReturnGender(FlotsamGame.RandomEnum<Agent.EGender>());
	}

	public int ReturnVoicePackIndex(AgentDescriptor descriptor)
	{
		return descriptor.Gender switch
		{
			Agent.EGender.Female => FemaleVoicePacks.IndexOf(descriptor.VoicePack), 
			Agent.EGender.Male => MaleVoicePacks.IndexOf(descriptor.VoicePack), 
			_ => throw new NotImplementedException($"No voicepack set for {descriptor.Gender}."), 
		};
	}

	public VoicePackProperties ReturnRandomVoicePack(Agent.EGender gender)
	{
		return gender switch
		{
			Agent.EGender.Female => FlotsamGame.Random(FemaleVoicePacks), 
			Agent.EGender.Male => FlotsamGame.Random(MaleVoicePacks), 
			_ => throw new NotImplementedException($"No voicepacks set for {gender}."), 
		};
	}

	public VoicePackProperties ReturnVoicePack(Agent.EGender gender, int index)
	{
		return gender switch
		{
			Agent.EGender.Female => ReturnVoicePack(FemaleVoicePacks, index), 
			Agent.EGender.Male => ReturnVoicePack(MaleVoicePacks, index), 
			_ => throw new NotImplementedException($"No voicepacks set for {gender}."), 
		};
	}

	private VoicePackProperties ReturnVoicePack(IReadOnlyList<VoicePackProperties> voicePacks, int index)
	{
		if (voicePacks == null || voicePacks.Count == 0)
		{
			return null;
		}
		if (index < 0 || voicePacks.Count <= index)
		{
			return FlotsamGame.Random(voicePacks);
		}
		return voicePacks[index];
	}
}
