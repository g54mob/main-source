using UnityEngine;

public class RotateAroundAxisAnimator : MonoBehaviour
{
	public enum Axis
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	[SerializeField]
	private float _speed = 1f;

	[SerializeField]
	private float _startOffset;

	[SerializeField]
	private Axis _axis = Axis.Z;

	[SerializeField]
	private bool _animateOnStart = true;

	[SerializeField]
	private Transform _transform;

	private Vector3 _eulerRotation;

	public bool IsAnimating { get; private set; }

	public float Speed => _speed;

	private void Start()
	{
		IsAnimating = _animateOnStart;
		if (_transform == null)
		{
			_transform = base.transform;
		}
		_eulerRotation = _transform.localEulerAngles;
		switch (_axis)
		{
		case Axis.X:
			_eulerRotation.x += _startOffset;
			break;
		case Axis.Y:
			_eulerRotation.y += _startOffset;
			break;
		case Axis.Z:
			_eulerRotation.z += _startOffset;
			break;
		}
	}

	public void StartAnimation()
	{
		IsAnimating = true;
	}

	public void StopAnimation()
	{
		IsAnimating = false;
	}

	private void Update()
	{
		if (!IsAnimating)
		{
			return;
		}
		switch (_axis)
		{
		case Axis.X:
			_eulerRotation.x += _speed * Time.unscaledDeltaTime;
			if (_eulerRotation.x > 360f)
			{
				_eulerRotation.x -= 360f;
			}
			if (_eulerRotation.x < 0f)
			{
				_eulerRotation.x += 360f;
			}
			break;
		case Axis.Y:
			_eulerRotation.y += _speed * Time.unscaledDeltaTime;
			if (_eulerRotation.y > 360f)
			{
				_eulerRotation.y -= 360f;
			}
			if (_eulerRotation.y < 0f)
			{
				_eulerRotation.y += 360f;
			}
			break;
		case Axis.Z:
			_eulerRotation.z += _speed * Time.unscaledDeltaTime;
			if (_eulerRotation.z > 360f)
			{
				_eulerRotation.z -= 360f;
			}
			if (_eulerRotation.z < 0f)
			{
				_eulerRotation.z += 360f;
			}
			break;
		}
		_transform.localEulerAngles = _eulerRotation;
	}
}
