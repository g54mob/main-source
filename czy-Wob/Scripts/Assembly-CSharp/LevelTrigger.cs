using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Renderer>().enabled = false;
		base.gameObject.layer = RaycastUtil.triggerLayer;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.CompareTag(Tags.DOG))
		{
			OnDogEnter(other.transform.root.gameObject);
		}
	}

	protected virtual void OnDogEnter(GameObject dog)
	{
	}
}
