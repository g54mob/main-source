using UnityEngine;

[CreateAssetMenu(fileName = "NewVoiceProfile", menuName = "Dialogue/Character Voice Profile")]
public class CharacterVoiceProfile : ScriptableObject
{
	[Header("Volume & Pitch")]
	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0.3f, 2f)]
	public float minPitch = 0.95f;

	[Range(0.3f, 2f)]
	public float maxPitch = 1.05f;

	[Header("Optional Clip Override")]
	[Tooltip("Leave empty to use the DialogueManager's default typing sounds.")]
	public AudioClip[] typingSounds;

	[Header("Timing")]
	[Range(1f, 10f)]
	public int playSoundEveryNLetters = 2;
}
