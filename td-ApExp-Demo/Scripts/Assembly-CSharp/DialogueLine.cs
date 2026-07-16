using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class DialogueLine
{
	public bool noText;

	public bool noPause;

	public string characterName;

	public LocalizedString localizedCharacterName;

	public Sprite characterPortrait;

	public string fallbackDialogueText;

	public LocalizedString localizedText;

	public float preDelay;

	public float postDelay;

	public bool waitForEventToStart;

	public bool waitForEventToProgress;

	public bool autoNext;

	public string conditionExpression = string.Empty;

	public GameObject[] additionalObjectPrefabs;

	public GameObject[] additionalUIElementPrefabs;

	public AudioClip sound;
}
