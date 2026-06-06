using System;
using System.Collections.Generic;

[Serializable]
public class Dialogue
{
	public int ID;

	public CharacterSO characterSO;

	public string characterName;

	public bool isPhone;

	public List<DialoguePart> dialogueParts;

	public bool onRight;

	public bool isFinished;

	public bool TryGetDialoguePart(int index)
	{
		if (index < dialogueParts.Count)
		{
			return true;
		}
		return false;
	}
}
