using UnityEngine;

public class DestroyObjectAnimationEvent : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToDestroy;

	public void DestroyObject()
	{
		Object.Destroy(objectToDestroy);
	}
}
