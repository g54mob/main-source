using UnityEngine;

public class WeaponSway : MonoBehaviour
{
	public Transform xTarg;

	public Transform yTarg;

	public float rotSmooth;

	private float lastKnownYRot;

	private void Start()
	{
		lastKnownYRot = yTarg.eulerAngles.y;
	}

	private void Update()
	{
		if (yTarg.eulerAngles.y != lastKnownYRot)
		{
			base.transform.localEulerAngles += new Vector3(0f, lastKnownYRot - yTarg.eulerAngles.y, 0f);
			lastKnownYRot = yTarg.eulerAngles.y;
		}
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		float x = xTarg.rotation.eulerAngles.x;
		float y = yTarg.rotation.eulerAngles.y;
		float x2 = Mathf.LerpAngle(eulerAngles.x, x, Time.deltaTime * rotSmooth);
		float y2 = Mathf.LerpAngle(eulerAngles.y, y, Time.deltaTime * rotSmooth);
		float z = eulerAngles.z;
		Quaternion rotation = Quaternion.Euler(x2, y2, z);
		base.transform.rotation = rotation;
	}
}
