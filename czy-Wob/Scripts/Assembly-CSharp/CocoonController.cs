using UnityEngine;

public class CocoonController : MonoBehaviour
{
	public bool enterCocoon;

	public InventoryItem cocoon;

	public GameObject smokeParticles;

	private string cocoonSpawnSound = "object_spawn";

	private GameObject currentCocoon;

	private bool needsCocoon;

	private DogHome homeRef;

	private PenFocus penFocusRef;

	private DogRegistration dogRegRef;

	private void Start()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
	}

	private void Update()
	{
		if (needsCocoon)
		{
			SetReadyForCocoon();
		}
	}

	public bool EnterCocoon()
	{
		if (homeRef == null || dogRegRef == null)
		{
			return false;
		}
		if (currentCocoon != null)
		{
			return true;
		}
		DenInteriorManager.ExpelObjectFromDen(base.gameObject);
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		Vector3 boxCenter = component.GetBoxCenter();
		currentCocoon = homeRef.TrySpawnItem(cocoon, boxCenter, component.GetRoomUID(), moveToGoodLocation: true, cocoon.itemPrefab.transform.localScale * base.transform.localScale.x);
		Vector3 boxCenter2 = currentCocoon.GetComponent<BoundingBoxComponent>().GetBoxCenter();
		Object.Instantiate(smokeParticles, boxCenter2, Quaternion.identity);
		dogRegRef.SaveDog(base.gameObject, inWorld: true, inCocoon: true);
		AudioController.Play(cocoonSpawnSound, boxCenter2);
		currentCocoon.GetComponent<Cocoon>().SetAssociatedDogID(dogRegRef.GetIDFromDog(base.gameObject));
		bool flag = false;
		if (penFocusRef.IsCameraFollowingObject(base.gameObject))
		{
			flag = true;
			penFocusRef.ClearFollowCam(fromRoomFocus: false, playSounds: false, playPenFocusSound: false);
		}
		dogRegRef.RefreshThumbnailForDog(base.gameObject);
		if (flag)
		{
			penFocusRef.RequestFollowCam(currentCocoon.GetComponent<Cocoon>().GetFocusTransform());
		}
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnCocoonCreated();
		}
		DogRegistration.SafeDestroy(base.gameObject);
		return true;
	}

	public void SetReadyForCocoon()
	{
		if (dogRegRef == null)
		{
			needsCocoon = true;
			return;
		}
		needsCocoon = false;
		dogRegRef.SetCocoonableDog(base.gameObject);
	}
}
