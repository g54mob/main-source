using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "DialogueCharacter_", menuName = "Project/Dialogue/Character")]
public class DialogueCharacter : ScriptableObject
{
	public LocalizedString Title;

	public List<DialogueCharacterGraphic> Graphics;
}
