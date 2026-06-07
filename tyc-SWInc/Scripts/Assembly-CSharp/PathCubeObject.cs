using UnityEngine;

public class PathCubeObject : MonoBehaviour
{
	public Transform PathCap;

	public Transform PathCap2;

	public Transform PathCube;

	public void Set(Vector2 p, float width = -1f)
	{
		Vector2 vector = base.transform.position.FlattenVector3();
		if (vector != p)
		{
			base.gameObject.SetActive(true);
			Vector2 v = p - vector;
			base.transform.rotation = Quaternion.LookRotation(v.ToVector3(0f));
			float magnitude = (p - vector).magnitude;
			float num = ((width > 0f) ? width : PathCube.localScale.x);
			PathCube.localScale = new Vector3(num, 1f, magnitude);
			Transform pathCap = PathCap;
			Vector3 localScale = (PathCap2.localScale = new Vector3(num, 1f, num));
			pathCap.localScale = localScale;
			PathCap.localPosition = new Vector3(0f, 0f, magnitude);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}
}
