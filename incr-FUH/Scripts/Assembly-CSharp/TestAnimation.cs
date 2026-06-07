using UnityEngine;

public class TestAnimation : MonoBehaviour
{
	private Animator _animator;

	private float _delay;

	private int _state;

	public AnimationClip Clip1;

	public AnimationClip Clip2;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_animator.SetTrigger("RunBaloon");
	}

	private void Update()
	{
		_delay += Time.deltaTime;
		if (_delay >= 5f && _state == 0)
		{
			_state = 1;
			_animator.ResetTrigger("RunBaloon");
			_animator.SetTrigger("RunBar");
		}
	}
}
