using UnityEngine;

public class ScreenPlaneFollower : MonoBehaviour
{
	private Camera m_Camera;

	private Vector3 m_TargetPosition;

	private Vector3 m_CurrentVelocity;

	[SerializeField]
	private float m_SmoothSpeed;

	public Vector2 ScreenPosition { get; set; }

	public Plane Plane { get; set; }

	private void Awake()
	{
	}

	public void ResetTargetPosition()
	{
	}

	private void Update()
	{
	}
}
