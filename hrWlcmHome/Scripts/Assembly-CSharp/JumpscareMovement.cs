using System.Collections;
using DG.Tweening;
using UnityEngine;

public class JumpscareMovement : Jumpscare
{
	[SerializeField]
	private GameObject _destination;

	[SerializeField]
	private float _lerpDuration;

	[SerializeField]
	private float startWalking = 2f;

	[SerializeField]
	private float rotationDuration = 0.5f;

	private float _timeElapsed;

	private bool _triggered;

	private Vector3 _startPosition;

	private bool isCoroutine;

	private Animator _anim;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		_startPosition = base.transform.position;
		_anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (isCoroutine)
		{
			base.transform.position = Vector3.Lerp(_startPosition, _destination.transform.position, Mathf.Clamp01(_timeElapsed / _lerpDuration));
			_timeElapsed += Time.deltaTime;
		}
	}

	public override void Scare()
	{
		base.gameObject.SetActive(value: true);
		_triggered = true;
		StartCoroutine(StartSequence());
	}

	private IEnumerator StartSequence()
	{
		yield return new WaitForSeconds(startWalking);
		RotateTowardsDestination();
		_anim.SetBool("isWalking", value: true);
		isCoroutine = true;
		yield return new WaitForSeconds(10f);
		Object.Destroy(base.gameObject);
	}

	private void RotateTowardsDestination()
	{
		Vector3 normalized = (_destination.transform.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, rotationDuration);
	}
}
