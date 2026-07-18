using UnityEngine;

public class CatapultAmmoController : MonoBehaviour
{
	[SerializeField]
	private float launchSpeed;

	private Transform spawnPoint;

	[SerializeField]
	private Rigidbody rb;

	private Collider collider;

	private bool _oneTime;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<Collider>();
	}

	private void FixedUpdate()
	{
		if (_oneTime && spawnPoint != null)
		{
			rb.AddForce(-spawnPoint.transform.parent.parent.parent.right * launchSpeed, ForceMode.Impulse);
			_oneTime = false;
		}
	}

	public void LaunchAmmo(Transform _spawnPoint, float timeTillDestroyed)
	{
		spawnPoint = _spawnPoint;
		_oneTime = true;
		Invoke("DisableCollider", 0.5f);
		Object.Destroy(base.gameObject, timeTillDestroyed);
	}

	private void DisableCollider()
	{
		collider.enabled = false;
	}
}
