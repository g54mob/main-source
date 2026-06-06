using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
	[Header("Orbit Settings")]
	[Tooltip("The object the camera will circle around.")]
	public Transform target;

	[Tooltip("Distance from the target.")]
	public float radius = 5f;

	[Tooltip("How fast the camera rotates.")]
	public float speed = 0.5f;

	[Tooltip("Height of the camera relative to the target.")]
	public float height = 2f;

	private float _angle;

	private void Update()
	{
		if ((bool)target && !Database.State.Studio.Paused.Value)
		{
			_angle += speed * Time.deltaTime;
			UpdatePosition();
		}
	}

	private void UpdatePosition()
	{
		float x = target.position.x + Mathf.Cos(_angle) * radius;
		float z = target.position.z + Mathf.Sin(_angle) * radius;
		float y = target.position.y + height;
		base.transform.position = new Vector3(x, y, z);
		base.transform.LookAt(target);
	}
}
