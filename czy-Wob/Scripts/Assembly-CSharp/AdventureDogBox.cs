using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureDogBox : MonoBehaviour
{
	public Image dogIconHolder;

	public TextMeshProUGUI dogNameText;

	public CoreButtonUnityGUI boxButton;

	private ulong associatedDogID;

	private AdventureGUI guiRef;

	public void SetGUIRef(AdventureGUI newRef)
	{
		guiRef = newRef;
	}

	public void SetAssociatedDogID(ulong newID)
	{
		associatedDogID = newID;
	}

	public void SetDogName(string dogName)
	{
		dogNameText.text = dogName;
	}

	public void SetDogIcon(Sprite iconSprite)
	{
		dogIconHolder.sprite = iconSprite;
	}

	public void OnDogSelected()
	{
		guiRef.OnDogSelected(associatedDogID);
	}
}
