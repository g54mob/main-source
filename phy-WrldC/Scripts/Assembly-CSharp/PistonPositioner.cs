using UnityEngine;

public class PistonPositioner : MonoBehaviour
{
	public GameObject topObject;

	public GameObject bottomObject;

	private float defaultDistance = 0.3f;

	private void Update()
	{
		float num = Vector3.Distance(bottomObject.transform.localPosition, topObject.transform.localPosition);
		float y = 1f + num / defaultDistance;
		base.transform.SetLocalScaleY(y);
		base.transform.SetLocalPositionY((0f - num) / 2f);
	}
}
