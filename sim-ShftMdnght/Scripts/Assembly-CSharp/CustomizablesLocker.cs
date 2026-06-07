using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizablesLocker : MonoBehaviour
{
	public Animator[] slotAnimators;

	public int curSelection;

	public TextMeshProUGUI title;

	public Button equipButton;

	public GameObject equipped;

	public ThirdPersonManager thirdPersonMan;

	private void OnEnable()
	{
		foreach (int item in SaveManager.Instance.customizablesUnlocked)
		{
			slotAnimators[item].SetBool("Locked", value: false);
		}
		if (SaveManager.Instance.customizablesUnlocked.Contains(PlayerPrefs.GetInt("CurrentHatSelection", 0)))
		{
			Select(PlayerPrefs.GetInt("CurrentHatSelection", 0));
			return;
		}
		PlayerPrefs.SetInt("CurrentHatSelection", 0);
		Select(0);
	}

	public void Select(int index)
	{
		Animator[] array = slotAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetTrigger("Deselect");
		}
		slotAnimators[index].SetTrigger("Select");
		curSelection = index;
		HatsRenderer.Instance.SelectHat(index);
		title.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		title.text = JSONAccess.Instance.GetMiscText("Customizables", index.ToString());
		if (index == PlayerPrefs.GetInt("CurrentHatSelection", 0))
		{
			equipButton.GetComponent<Animator>().SetBool("On", value: false);
			equipped.SetActive(value: true);
		}
		else
		{
			equipButton.GetComponent<Animator>().SetBool("On", value: true);
			equipped.SetActive(value: false);
		}
	}

	public void Equip()
	{
		PlayerPrefs.SetInt("CurrentHatSelection", curSelection);
		equipButton.GetComponent<Animator>().SetBool("On", value: false);
		equipped.SetActive(value: true);
		thirdPersonMan.UpdateHat();
	}
}
