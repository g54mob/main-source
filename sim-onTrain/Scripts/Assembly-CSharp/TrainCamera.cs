using UnityEngine;

public class TrainCamera : MonoBehaviour
{
	public Transform target;

	public Vector3 offset;

	public float speed = 1f;

	private Transform trs;

	private void Awake()
	{
		trs = base.transform;
	}

	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(target.position + target.right * offset.x + target.up * offset.y + target.forward * offset.z - trs.position);
		trs.rotation = Quaternion.Slerp(trs.rotation, b, Time.deltaTime * speed);
	}
}
