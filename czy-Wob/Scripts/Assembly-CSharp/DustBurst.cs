using UnityEngine;

public class DustBurst : MonoBehaviour
{
	private DustBurstController controllerRef;

	private void Awake()
	{
		controllerRef = base.transform.root.gameObject.GetComponent<DustBurstController>();
	}

	private void OnCollisionEnter(Collision c)
	{
		if (!(c.transform.root == base.transform.root) && !(controllerRef == null))
		{
			controllerRef.RequestBurst(c);
		}
	}
}
