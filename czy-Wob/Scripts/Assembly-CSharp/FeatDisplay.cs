using TMPro;
using UnityEngine;

public class FeatDisplay : MonoBehaviour
{
	public TextMeshPro featText;

	public TextMeshPro dogNameText;

	public SpriteRenderer dogIconImageHolder;

	public void DisplayFeat(FeatStruct newFeat)
	{
		featText.text = newFeat.featText;
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		SaveableDog saveableDogFromID = globalComponent.GetSaveableDogFromID(newFeat.featOwnerUID.Value);
		dogNameText.text = saveableDogFromID.dogName;
		dogIconImageHolder.sprite = globalComponent.GetDefaultThumbnailForDogID(newFeat.featOwnerUID);
	}
}
