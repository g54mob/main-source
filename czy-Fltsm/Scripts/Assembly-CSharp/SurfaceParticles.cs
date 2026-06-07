using UnityEngine;

public class SurfaceParticles : MonoBehaviour
{
	private Vector3 _targetPosition = Vector3.zero;

	private void Start()
	{
		_targetPosition = base.gameObject.transform.position;
		_targetPosition.y = 0.05f;
	}

	private void Update()
	{
		_targetPosition.x = base.gameObject.transform.position.x;
		_targetPosition.y = 0.05f;
		_targetPosition.z = base.gameObject.transform.position.z;
	}
}
