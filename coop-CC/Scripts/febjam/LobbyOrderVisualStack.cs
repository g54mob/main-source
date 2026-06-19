using Aggro.Core;
using UnityEngine;

public class LobbyOrderVisualStack : EntityBehaviourBase
{
	private static readonly int Lean = Animator.StringToHash("lean");

	public Transform[] slots;

	public Transform[] tape;

	private Animator _animator;

	private Vector3 _lastPos;

	public float maxSpeed = 5f;

	public float lerpSpeed = 5f;

	private float _speed;

	protected override void OnEntityCreated()
	{
		_animator = base.entity.GetObject<Animator>();
		_lastPos = base.transform.position;
	}

	protected override void OnUpdatePresentation()
	{
		_speed = _lastPos.x - base.transform.position.x;
		float b = (0f - _speed) / maxSpeed;
		_animator.SetFloat(Lean, Mathf.Lerp(_animator.GetFloat(Lean), b, Time.deltaTime * lerpSpeed));
		_lastPos = base.transform.position;
	}
}
