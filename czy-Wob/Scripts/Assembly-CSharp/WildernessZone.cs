using UnityEngine;

public class WildernessZone : MonoBehaviour
{
	public GameObject spawnPoints;

	private DogRegistration dogRegRef;

	public void LoadZone(SceneManagerBase.PreloadCallback callback)
	{
		Camera.main.gameObject.AddComponent<WildernessCam>().focusObject = base.gameObject;
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		for (int i = 0; i < spawnPoints.transform.childCount; i++)
		{
			Transform child = spawnPoints.transform.GetChild(i);
			dogRegRef.RequestNewDog(child.position, child.rotation, null, null, manualDog: false, DogCreationCallback);
		}
		spawnPoints.SetActive(value: false);
		callback();
	}

	private void DogCreationCallback(GameObject newDog)
	{
		newDog.GetComponent<BoundingBoxComponent>().MoveToGoodLocation();
	}
}
