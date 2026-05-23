using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField]
	private Transform _flock;

	[SerializeField]
	private Animator _animator;

	private float _offset;

	private float _offset2;

	private float _speed;

	private void Start()
	{
		_offset = Random.Range(-2, 2);
		_offset2 = Random.Range(-4f, 4f);
		_speed = Random.Range(0.5f, 2f);
		_animator.SetFloat("CycleOffset", Random.value);
	}

	private void Update()
	{
		FollowFlock();
	}

	private void FollowFlock()
	{
		Vector3 b = _flock.position + new Vector3(_offset2, _offset, _offset2);
		base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * _speed);
		base.transform.rotation = _flock.rotation;
	}
}
