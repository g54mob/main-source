using TMPro;
using UnityEngine;

public class CharacterDisplayer : MonoBehaviour
{
	[SerializeField]
	private GameObject warrior;

	[SerializeField]
	private GameObject rogue;

	[SerializeField]
	private GameObject wizard;

	[SerializeField]
	private GameObject bard;

	[SerializeField]
	private TextMeshProUGUI username;

	private void Start()
	{
		Character character = newhampshire_player.GetCharacter(username.text);
		SetClassesInactive();
		GameObject activeClass = GetActiveClass(character.type);
		ClearSelections(activeClass);
		activeClass.transform.Find($"Hair {character.hair}").gameObject.SetActive(value: true);
		activeClass.transform.Find($"Shirt {character.shirt}").gameObject.SetActive(value: true);
	}

	private GameObject GetActiveClass(Character.Class currClass)
	{
		switch (currClass)
		{
		case Character.Class.Warrior:
			warrior.SetActive(value: true);
			return warrior;
		case Character.Class.Rogue:
			rogue.SetActive(value: true);
			return rogue;
		case Character.Class.Wizard:
			wizard.SetActive(value: true);
			return wizard;
		case Character.Class.Bard:
			bard.SetActive(value: true);
			return bard;
		default:
			return null;
		}
	}

	private void SetClassesInactive()
	{
		warrior.SetActive(value: false);
		rogue.SetActive(value: false);
		wizard.SetActive(value: false);
		bard.SetActive(value: false);
	}

	private void ClearSelections(GameObject gameObject)
	{
		foreach (Transform item in gameObject.transform)
		{
			if (item.name != "Template")
			{
				item.gameObject.SetActive(value: false);
			}
		}
	}
}
