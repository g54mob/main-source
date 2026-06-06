using UnityEngine;

public abstract class ActorProfile : PersistentProperties
{
	[Header("Actor")]
	[SerializeField]
	private string _name;

	[SerializeField]
	private DialogueTreeProperties _actorDialogue;

	[SerializeField]
	private Sprite _dialoguePortrait;

	[SerializeField]
	private string _localizationParameter;

	public override Types Type => Types.ActorProfile;

	public abstract ActorProperties ActorProperties { get; }

	public string Name => _name;

	public DialogueTreeProperties DialogueProperties => _actorDialogue;

	public Sprite DialoguePortrait => _dialoguePortrait;

	public string LocalizationParameter => _localizationParameter;

	public abstract bool Spawn(ILandmarkPickerSettings settings);

	public abstract bool Spawn(ILandmarkPickerSettings settings, out LandmarkSpawner landmarkSpawner);

	public abstract ActorDescriptor GetActorDiscriptor();
}
