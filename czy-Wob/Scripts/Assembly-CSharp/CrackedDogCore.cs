using I2.Loc;
using UnityEngine;

public class CrackedDogCore : MonoBehaviour
{
	public GameObject colliderObjectA;

	public GameObject colliderObjectB;

	public GameObject lifeExtensionParticles;

	public GameObject worldMessagePrefab;

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private string dogCoreConsumeSound = "dogCore_consume";

	private CoreQuality associatedQuality;

	private void Awake()
	{
		IgnoreCollisions();
	}

	public void SetAssociatedCoreQuality(CoreQuality quality)
	{
		associatedQuality = quality;
	}

	public CoreQuality GetCoreQuality()
	{
		return associatedQuality;
	}

	public void TransferLifeBonusToConsumingDog(GameObject dog)
	{
		BoundingBoxComponent component = dog.GetComponent<BoundingBoxComponent>();
		Object.Instantiate(lifeExtensionParticles, component.GetBoxCenter(), Quaternion.identity);
		dog.GetComponent<DoggyBrain>().AddLifeExtension(DoggyBrain.coreQualityToLifeExtensionDict[associatedQuality]);
		GameObject gameObject = Object.Instantiate(worldMessagePrefab, component.GetBoxCenter() + messageOffset, Quaternion.identity);
		gameObject.transform.localScale = Vector3.one;
		WorldMessage component2 = gameObject.GetComponent<WorldMessage>();
		component2.SetStartDelay(1.75f);
		component2.SetFadeTime(2f);
		component2.SetDisplayColor(Color.green);
		component2.SetDisplayMessage(ScriptLocalization.GUI.GUI_MESSAGE_LIFESPANUP);
		AudioController.Play(dogCoreConsumeSound, gameObject.transform.position);
	}

	private void IgnoreCollisions()
	{
		Collider[] componentsInChildren = colliderObjectA.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = colliderObjectB.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider, collider2);
			}
		}
	}
}
