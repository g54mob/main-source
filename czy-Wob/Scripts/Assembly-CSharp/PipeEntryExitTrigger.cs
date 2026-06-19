using UnityEngine;

public class PipeEntryExitTrigger : MonoBehaviour
{
	public GameObject segmentRef;

	private Pipe pipeRef;

	private void Start()
	{
		pipeRef = base.transform.root.GetComponent<Pipe>();
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (pipeRef == null)
		{
			pipeRef = base.transform.root.GetComponent<Pipe>();
		}
		GameObject gameObject = collider.transform.root.gameObject;
		if (!(gameObject == base.transform.root.gameObject) && (gameObject.CompareTag(Tags.DOG) || !(gameObject.GetComponent<ObjectID>() == null)))
		{
			pipeRef.OnObjectInEntrance(collider.gameObject, base.gameObject);
		}
	}
}
