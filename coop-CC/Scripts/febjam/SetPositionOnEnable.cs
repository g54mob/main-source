using UnityEngine;

public class SetPositionOnEnable : MonoBehaviour
{
	public bool xPos;

	public bool yPos;

	public bool zPos;

	public Vector3 pos;

	private void OnEnable()
	{
		Vector3 position = base.transform.position;
		if (xPos)
		{
			position.x = pos.x;
		}
		if (yPos)
		{
			position.y = pos.y;
		}
		if (zPos)
		{
			position.z = pos.z;
		}
		base.transform.position = position;
	}
}
