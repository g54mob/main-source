using UnityEngine;

public class Zone : MonoBehaviour
{
	public enum Category
	{
		Footstep = 0
	}

	public Category category;

	public string id;

	private Bounds localBounds;

	private Bounds worldBounds;

	private void Start()
	{
		localBounds = new Bounds(Vector3.zero, Vector3.one);
		worldBounds = Util.ToWorldBounds(localBounds, base.transform.localToWorldMatrix);
	}

	public bool Contains(Vector3 pos)
	{
		if (!worldBounds.Contains(pos))
		{
			return false;
		}
		Vector3 point = base.transform.worldToLocalMatrix.MultiplyPoint(pos);
		return localBounds.Contains(point);
	}
}
