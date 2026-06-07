using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
	public enum MovementType
	{
		Random = 0,
		Loop = 1
	}

	public enum CreatureType
	{
		Crawler = 0,
		Bird = 1
	}

	[SerializeField]
	private List<GameObject> _targets;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private GameObject _scanner;

	[SerializeField]
	private float _moveSpeed = 5f;

	[SerializeField]
	private float _rotationSpeed = 5f;

	[SerializeField]
	private float _waitTime = 3f;

	[SerializeField]
	private bool _sineMovement = true;

	[SerializeField]
	private float _sineFrequency = 1f;

	[SerializeField]
	private MovementType _movementType;

	[SerializeField]
	private CreatureType _creatureType = CreatureType.Bird;

	private Vector3 _toPoint;

	private Vector3 _lookDir;

	private int _getTo;

	private bool _isPaused;

	private int _previousGetTo = -1;

	private float _elapsedTime;

	private float _interpolator;

	private void Update()
	{
		_toPoint = _targets[_getTo].transform.position;
		if (_creatureType == CreatureType.Bird)
		{
			_lookDir = GetNext(_getTo) - base.transform.position;
		}
		else
		{
			_lookDir = _toPoint - base.transform.position;
		}
		_lookDir.Normalize();
		Vector3.Dot(base.transform.forward, _lookDir);
		float num = 1f;
		if (_sineMovement)
		{
			num = Mathf.Sin(_elapsedTime * _sineFrequency * MathF.PI * 2f + 1f) * 0.5f;
			num = Mathf.Clamp01(num);
		}
		else
		{
			num = 1f;
		}
		_elapsedTime += Time.deltaTime;
		float num2 = Vector3.Distance(GetPrevious(_getTo), GetNext(_getTo)) / _moveSpeed;
		_interpolator = _elapsedTime / num2;
		if (_creatureType == CreatureType.Bird)
		{
			base.transform.position = QuadraticLerp(GetPrevious(_getTo), _toPoint, GetNext(_getTo), _interpolator);
		}
		else
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, _toPoint, _moveSpeed * num * Time.deltaTime);
		}
		GetTargetPoint();
		float num3 = Vector3.SignedAngle(base.transform.forward, _lookDir, base.transform.up);
		base.transform.Rotate(Vector3.up, num3 * Time.deltaTime * _rotationSpeed);
		if (_scanner != null && _creatureType == CreatureType.Crawler)
		{
			Scan();
		}
	}

	private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
	{
		Vector3 a2 = Vector3.Lerp(a, b, t);
		Vector3 b2 = Vector3.Lerp(b, c, t);
		return Vector3.Lerp(a2, b2, t);
	}

	private void GetTargetPoint()
	{
		if (_creatureType == CreatureType.Bird)
		{
			if (_interpolator >= 1f && !_isPaused)
			{
				_getTo++;
				_getTo++;
				if (_getTo >= _targets.Count)
				{
					_getTo = 0;
				}
				_elapsedTime = 0f;
			}
		}
		else if (Vector3.Distance(base.transform.position, _toPoint) < 0.1f && !_isPaused)
		{
			StartCoroutine(Pause());
		}
	}

	private IEnumerator Pause()
	{
		_animator.enabled = false;
		_isPaused = true;
		yield return new WaitForSeconds(_waitTime);
		_animator.enabled = true;
		if (_movementType == MovementType.Random)
		{
			do
			{
				_getTo = UnityEngine.Random.Range(0, _targets.Count);
			}
			while (_getTo == _previousGetTo);
		}
		if (_movementType == MovementType.Loop)
		{
			_getTo++;
			if (_getTo >= _targets.Count)
			{
				_getTo = 0;
			}
		}
		_previousGetTo = _getTo;
		_isPaused = false;
	}

	private void Scan()
	{
		if (_isPaused)
		{
			_scanner.SetActive(value: true);
		}
		else
		{
			_scanner.SetActive(value: false);
		}
		float num = Mathf.Sin(_elapsedTime * _sineFrequency * MathF.PI * 2f) * 1f * 1f;
		Quaternion localRotation = Quaternion.Euler(_scanner.transform.localRotation.x, 90f, num * 5f);
		_scanner.transform.localRotation = localRotation;
	}

	private Vector3 GetPrevious(int index)
	{
		if (index <= 0)
		{
			return _targets[_targets.Count - 1].transform.position;
		}
		return _targets[index - 1].transform.position;
	}

	private Vector3 GetNext(int index)
	{
		if (index >= _targets.Count - 1)
		{
			return _targets[0].transform.position;
		}
		return _targets[index + 1].transform.position;
	}
}
