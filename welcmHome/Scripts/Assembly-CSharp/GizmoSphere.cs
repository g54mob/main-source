using UnityEngine;

public class GizmoSphere : MonoBehaviour
{
	public float radius = 0.5f;

	public Color color = Color.blue;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawSphere(base.transform.position, radius);
	}
}
