using Aggro.Core;
using UnityEngine;

public class OrientTransform : EntityBehaviourBase
{
	public float speed = 1f;

	public Vector3 dir = Vector3.forward;

	public Vector3 up = Vector3.up;

	protected override void OnUpdatePresentation()
	{
		Quaternion b = Quaternion.LookRotation(dir, up);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * speed);
	}
}
