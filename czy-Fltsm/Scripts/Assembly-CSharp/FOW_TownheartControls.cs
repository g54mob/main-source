using PajamaLlama.Generic;
using UnityEngine;

public class FOW_TownheartControls : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 10f)]
	private float _acceleration = 1f;

	[SerializeField]
	private RangedFloat _velocityRange = new RangedFloat(-2.5f, 10f);

	[SerializeField]
	[Range(0f, 10f)]
	private float _drag = 0.25f;

	[SerializeField]
	[Range(0f, 45f)]
	private float _rotationSpeed = 1f;

	private float _velocity;

	private void Update()
	{
		float deltaTime = Time.deltaTime;
		if (Input.GetKey(KeyCode.UpArrow))
		{
			_velocity = Mathf.Min(_velocityRange.Maximum, _velocity + _acceleration * deltaTime);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			_velocity = Mathf.Max(_velocityRange.Minimum, _velocity - _acceleration * deltaTime);
		}
		else if (_velocity < 0f)
		{
			_velocity = Mathf.Min(0f, _velocity + _drag * deltaTime);
		}
		else
		{
			_velocity = Mathf.Max(0f, _velocity - _drag * deltaTime);
		}
		Quaternion rotation = base.transform.rotation;
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rotation *= Quaternion.AngleAxis((0f - _rotationSpeed) * deltaTime, Vector2.up);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rotation *= Quaternion.AngleAxis(_rotationSpeed * deltaTime, Vector2.up);
		}
		base.transform.rotation = rotation;
		base.transform.position = base.transform.position + base.transform.forward * _velocity * deltaTime;
	}
}
