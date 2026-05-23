using UnityEngine;

public class PushPlayer2D : MonoBehaviour
{
	private PlayerMovement pm;

	private Transform ptrans;

	[SerializeField]
	private float ensureDistance = 10f;

	private void Start()
	{
		pm = PlayerMovement.instance;
		ptrans = pm.transform;
	}

	private void Update()
	{
		Vector3 vector = new Vector3(ptrans.position.x - base.transform.position.x, 0f, ptrans.position.z - base.transform.position.z);
		float magnitude = vector.magnitude;
		if (magnitude < ensureDistance)
		{
			Vector3 normalized = vector.normalized;
			pm.TeleportTo(ptrans.position + normalized * (ensureDistance - magnitude));
		}
	}
}
