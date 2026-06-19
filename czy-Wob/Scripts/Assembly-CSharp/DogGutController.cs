using System.Collections.Generic;
using UnityEngine;

public class DogGutController : MonoBehaviour
{
	public GameObject gutPrefab;

	public int startingGutFlora = 10;

	public InventoryItem ectoplasmObject;

	public InventoryItem hockedUpFoodObject;

	public GutFloraResource startingGutFloraType;

	private DogGut gutRef;

	private DogGutsManager gutsManagerRef;

	public void OnCreate(List<string> customFloraPool, bool customEmptyGut)
	{
		gutsManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		CreateGut(customFloraPool, customEmptyGut);
	}

	private void OnDestroy()
	{
		if (!(gutRef == null) && !(gutRef.gameObject == null))
		{
			gutsManagerRef.RemoveGut(gutRef);
			Object.Destroy(gutRef.gameObject);
		}
	}

	public DogGut GetDogGut()
	{
		return gutRef;
	}

	private void CreateGut(List<string> customFloraPool, bool customEmptyGut)
	{
		if (gutRef != null)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(gutPrefab);
		gutsManagerRef.AddNewGut(gameObject);
		gutRef = gameObject.GetComponent<DogGut>();
		gutRef.AssignController(this);
		if (customEmptyGut)
		{
			return;
		}
		if (customFloraPool == null || customFloraPool.Count == 0)
		{
			for (int i = 0; i < startingGutFlora; i++)
			{
				gutRef.SpawnNewGutFlora(startingGutFloraType);
			}
			return;
		}
		DogGutsManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		for (int j = 0; j < startingGutFlora; j++)
		{
			string randomElement = ListUtil.GetRandomElement(customFloraPool);
			GutFloraResource floraForPath = globalComponent.GetFloraForPath(randomElement);
			if (floraForPath == null)
			{
				floraForPath = startingGutFloraType;
			}
			gutRef.SpawnNewGutFlora(floraForPath);
		}
	}
}
