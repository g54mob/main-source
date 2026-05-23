using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
	public Vector3 angle;

	private void Update()
	{
		base.transform.localRotation *= Quaternion.Euler(angle * Time.deltaTime);
	}
}
