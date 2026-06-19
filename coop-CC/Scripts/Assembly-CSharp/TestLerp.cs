using Aggro.Core;
using UnityEngine;

public class TestLerp : EntityBehaviourBase
{
	public float radius;

	public float angularSpeed;

	public float rotationSpeed;

	private float _angle;

	private float _rot;

	private Vector3 _origin;

	protected override void OnEntityCreated()
	{
		_origin = base.transform.position;
	}

	protected override void OnUpdateSimulation()
	{
		_angle += angularSpeed * Time.deltaTime;
		_angle = Mathf.Repeat(_angle, 360f);
		base.transform.position = _origin + Quaternion.Euler(0f, _angle, 0f) * Vector3.forward * radius;
		_rot += rotationSpeed * Time.deltaTime;
		_rot = Mathf.Repeat(_rot, 360f);
		base.transform.rotation = Quaternion.Euler(0f, _rot, 0f);
	}
}
