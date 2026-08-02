using UnityEngine;

public class PositionLerp : MonoBehaviour
{
	public Transform target;

	public float lerpMultiplier = 3f;

	private void Update()
	{
		base.transform.position = Vector3.Lerp(base.transform.position, target.position, lerpMultiplier * Time.deltaTime);
	}
}
