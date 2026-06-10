using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class DialogueLine
{
	public string characterName = "The Old Angler";

	public LocalizedString localizedCharacterName;

	public Sprite characterPortrait;

	[TextArea(3, 10)]
	public string dialogueText;

	public LocalizedString localizedDialogue;

	[Tooltip("Optional voice profile for this line. Leave empty to use the default Fisherman voice.")]
	public CharacterVoiceProfile voiceProfile;
}
