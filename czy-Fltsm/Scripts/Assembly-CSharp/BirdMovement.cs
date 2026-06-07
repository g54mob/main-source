using PajamaLlama.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	[Tooltip("Movement speed of the bird.")]
	private float _speed = 10f;

	[SerializeField]
	[Tooltip("Rotation speed of the bird.")]
	private float _rotationSpeed = 165f;

	[SerializeField]
	[Tooltip("Preferred altitude for birds to fly on.")]
	private float _cruisingAltitude = 18f;

	[SerializeField]
	[Tooltip("The radius of the circle the bird folows when circling the town.")]
	[MinMaxRangeFloat(0f, 50f)]
	private RangedFloat _circlingRadiusRange = new RangedFloat(10f, 35f);

	[SerializeField]
	[Tooltip("The radius of the circle the bird folows when circling the town.")]
	[MinMaxRangeFloat(-5f, 5f)]
	private RangedFloat _circlingAltitudeOffsetRange = new RangedFloat(-2f, 2f);

	[SerializeField]
	private float _circleRadiusIncreaseSpeed = 2f;

	[SerializeField]
	private float _circleAltitudeDuration = 2f;

	private Bird _bird;

	private Vector3 _position;

	private float _circleTargetRadius;

	private float _circleRadius;

	private float _circlingDirection = 1f;

	private float _circleTargetAltitude;

	private float _circleAltitude;

	private float _circleAltitudeSpeed;

	private float _heightOffset;

	private float _angle;

	private void Awake()
	{
		_bird = GetComponent<Bird>();
		BegingCirclePoint();
		_circleRadius = _circleTargetRadius;
	}

	public void Initialize()
	{
		Vector3 position = base.transform.position;
		position.x = (float.IsNaN(position.x) ? 0f : position.x);
		position.y = (float.IsNaN(position.y) ? _cruisingAltitude : position.y);
		position.z = (float.IsNaN(position.z) ? 0f : position.y);
		base.transform.position = position;
	}

	public bool MoveTo(Vector3 targetPosition)
	{
		_position = base.transform.position;
		float num = Vector3.Distance(_position, targetPosition);
		if (num <= 2f)
		{
			return true;
		}
		if (num > 25f)
		{
			Vector3 normalized = (targetPosition - _position).normalized;
			normalized *= 10f;
			targetPosition = (_position + normalized).SetY(_cruisingAltitude);
		}
		Vector3 vector = targetPosition - _position;
		Quaternion to = ((vector == Vector3.zero) ? Quaternion.identity : Quaternion.LookRotation(vector));
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, _rotationSpeed * Time.deltaTime);
		Vector3 vector2 = base.transform.forward * _speed;
		base.transform.position += vector2 * Time.deltaTime;
		_bird.Animator.SetFloat("VerticalVelocity", vector2.y);
		return false;
	}

	public void BegingCirclePoint()
	{
		_circleTargetRadius = _circlingRadiusRange.ReturnRandom();
		_circleRadius = 0f;
		_circlingDirection = Mathf.Sign(Random.Range(-1, 1));
		_circleAltitude = base.transform.position.y;
		_circleTargetAltitude = Mathf.Max(_cruisingAltitude + _circlingAltitudeOffsetRange.ReturnRandom(), base.transform.position.y);
		_circleAltitudeSpeed = (_circleTargetAltitude - _circleAltitude) / _circleAltitudeDuration;
		_heightOffset = _circlingAltitudeOffsetRange.ReturnRandom();
	}

	public void CirclePoint(Vector3 point)
	{
		_circleRadius = Mathf.Min(_circleRadius + _circleRadiusIncreaseSpeed * Time.deltaTime, _circleTargetRadius);
		_circleAltitude = Mathf.Min(_circleAltitude + _circleAltitudeDuration * Time.deltaTime, _circleTargetAltitude);
		point.y = _circleAltitude;
		_angle += _speed / _circleRadius * Time.deltaTime * _circlingDirection;
		Vector3 position = base.transform.position;
		Vector2 vector = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _circleRadius;
		Vector3 vector2 = point + vector.Vector3TopDown();
		Vector3 forward = vector2 - position;
		base.transform.SetPositionAndRotation(vector2, Quaternion.LookRotation(forward));
	}
}
