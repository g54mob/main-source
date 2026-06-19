using UnityEngine;

public class AttachmentString : MonoBehaviour
{
	public GameObject geometry;

	public Transform topTransform;

	public Transform bottomTransform;

	public GameObject attachmentSphere;

	private Vector3 sphereOffset = new Vector3(0f, 0.075f, 0f);

	public Vector3 GetOffsetAttachmentPoint(Vector3 p)
	{
		return p - sphereOffset;
	}

	public void AttachString(Vector3 p1, Vector3 p2)
	{
		float num = Vector3.Distance(p1, p2);
		geometry.transform.localScale = new Vector3(geometry.transform.localScale.x, num / 2f, geometry.transform.localScale.z);
		geometry.transform.position = MathUtil.GetLineCenter(p1, p2);
		Vector3 vector = p1 - geometry.transform.position;
		if (vector == Vector3.zero)
		{
			geometry.transform.rotation = Quaternion.identity;
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(vector);
		rotation *= Quaternion.FromToRotation(Vector3.forward, Vector3.up);
		geometry.transform.rotation = rotation;
		attachmentSphere.transform.position = p2 + sphereOffset;
	}
}
