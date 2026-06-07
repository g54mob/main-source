using UnityEngine;

public class WingLineGizmo : MonoBehaviour
{
	public Transform startPoint;

	public Transform endPoint;

	public float thickness = 0.1f;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Connect(Transform start, Vector3 end)
	{
		float z = Vector3.Distance(start.position, end);
		Vector3 localScale = new Vector3(thickness, thickness, z);
		if (base.transform.parent != null)
		{
			base.transform.localScale = new Vector3(localScale.x / base.transform.parent.lossyScale.x, localScale.y / base.transform.parent.lossyScale.y, localScale.z / base.transform.parent.lossyScale.z);
		}
		else
		{
			base.transform.localScale = localScale;
		}
		base.transform.position = (start.position + end) / 2f;
		base.transform.LookAt(end);
	}
}
