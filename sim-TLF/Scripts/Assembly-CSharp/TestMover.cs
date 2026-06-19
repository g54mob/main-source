using UnityEngine;

public class TestMover : MonoBehaviour
{
	[SerializeField]
	private Transform _movePoint;

	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private float speed = 5f;

	private void FixedUpdate()
	{
		Vector3 vector = _movePoint.position - _rigidbody.position;
		_rigidbody.linearVelocity = vector * speed;
	}
}
