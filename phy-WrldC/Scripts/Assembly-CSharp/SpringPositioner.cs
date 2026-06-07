using UnityEngine;

public class SpringPositioner : MonoBehaviour
{
	public GameObject topObject;

	public GameObject bottomObject;

	[SerializeField]
	private float defaultDistance = 0.3f;

	private void Update()
	{
		float num = Vector3.Distance(bottomObject.transform.position, topObject.transform.position);
		Vector3 normalized = (bottomObject.transform.InverseTransformPoint(topObject.transform.position) - base.transform.localPosition).normalized;
		float num2 = ((normalized.y != 0f) ? (normalized.y / Mathf.Abs(normalized.y)) : 0f);
		float y = 1f + num / defaultDistance * num2;
		base.transform.SetLocalScaleY(y);
		base.transform.SetLocalPositionY(num * num2 / 2f);
	}
}
