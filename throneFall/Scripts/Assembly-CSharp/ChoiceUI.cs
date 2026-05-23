using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
	public Choice choice;

	public TMP_Text title;

	public TMP_Text description;

	public GameObject selected;

	public Image icon;

	public GameObject unlocked;

	public GameObject locked;

	private bool isunlocked;

	public bool IsUnlocked => isunlocked;

	public void SetChoice(Choice _choice)
	{
		if (!_choice.requiresUnlocked)
		{
			isunlocked = true;
		}
		else
		{
			isunlocked = _choice.CanBePicked;
		}
		if (_choice.disabledInThisMode)
		{
			isunlocked = false;
		}
		unlocked.SetActive(isunlocked);
		locked.SetActive(!isunlocked);
		choice = _choice;
		title.text = _choice.name;
		description.text = _choice.tooltip;
		icon.sprite = _choice.icon;
		SetHighlighted(_highlighted: false);
	}

	public void SetHighlighted(bool _highlighted)
	{
		selected.SetActive(_highlighted);
	}
}
