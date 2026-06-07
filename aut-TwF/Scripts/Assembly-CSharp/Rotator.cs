using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 rotation;

	[SerializeField]
	private Space space;

	private void Update()
	{
		base.transform.Rotate(rotation * Time.deltaTime, space);
	}
}
