using UnityEngine;

public class ObjMover : MonoBehaviour
{
	public Vector3 startPosition;

	public Vector3 endPosition;

	public bool move;

	private int direction = 6;

	private void Update()
	{
		if (!move)
		{
			return;
		}
		if (direction == 6)
		{
			base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, endPosition, 4f * Time.deltaTime);
			if (Vector3.Distance(base.transform.localPosition, endPosition) < 0.1f)
			{
				direction = 4;
			}
		}
		else
		{
			base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, startPosition, 4f * Time.deltaTime);
			if (Vector3.Distance(base.transform.localPosition, startPosition) < 0.1f)
			{
				direction = 6;
			}
		}
	}
}
