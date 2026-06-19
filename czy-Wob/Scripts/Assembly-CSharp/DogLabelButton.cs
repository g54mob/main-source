using UnityEngine;
using UnityEngine.UI;

public class DogLabelButton : MonoBehaviour
{
	public DogLabelType labelType;

	public Image labelImage;

	public DogStorageGUIManager guiRef;

	private void Awake()
	{
		labelImage.sprite = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetSpriteForLabel(labelType);
	}

	public void OnPressed()
	{
		guiRef.OnLabelSelected(labelType);
	}
}
