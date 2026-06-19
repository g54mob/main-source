using System.Collections.Generic;
using UnityEngine;

public class AdventureDogBoxes : MonoBehaviour
{
	public AdventureGUI guiRef;

	public GameObject dogBoxRef;

	private float offsetX = 250f;

	private float offsetY = -325f;

	private int elementsPerRow = 5;

	private List<AdventureDogBox> activeBoxes = new List<AdventureDogBox>();

	private DogRegistration dogRegRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void OnEnable()
	{
		CreateBoxes();
	}

	private void OnDisable()
	{
		for (int num = activeBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(activeBoxes[num].gameObject);
		}
		activeBoxes.Clear();
	}

	private void CreateBoxes()
	{
		List<GameObject> allInWorldOwnedDogs = dogRegRef.GetAllInWorldOwnedDogs();
		for (int i = 0; i < allInWorldOwnedDogs.Count; i++)
		{
			AdventureDogBox component = Object.Instantiate(dogBoxRef).GetComponent<AdventureDogBox>();
			ulong iDFromDog = dogRegRef.GetIDFromDog(allInWorldOwnedDogs[i]);
			component.SetGUIRef(guiRef);
			component.SetAssociatedDogID(iDFromDog);
			component.SetDogIcon(dogRegRef.GetDefaultThumbnailForDogID(iDFromDog));
			component.SetDogName(dogRegRef.GetSaveableDogFromID(iDFromDog).dogName);
			int num = activeBoxes.Count % elementsPerRow;
			int num2 = Mathf.FloorToInt(activeBoxes.Count / elementsPerRow);
			component.transform.SetParent(base.transform);
			component.transform.localScale = Vector3.one;
			component.transform.localPosition = new Vector3(offsetX * (float)num, offsetY * (float)num2, 0f);
			activeBoxes.Add(component);
		}
	}
}
