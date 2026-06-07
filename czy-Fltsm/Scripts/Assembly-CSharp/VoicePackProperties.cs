using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Audio/Voice Pack")]
public class VoicePackProperties : PersistentProperties
{
	public AudioClipProperties StartTaskSounds;

	public AudioClipProperties OnDeathSounds;

	public AudioClipProperties AttentionSounds;

	public AudioClipProperties IdlingSounds;

	public AudioClipProperties HelloSounds;

	public override Types Type => Types.VoicePack;
}
