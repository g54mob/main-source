using UnityEngine;

public class ScaleNew : MonoBehaviour
{
	private void Awake()
	{
		ScaleAround(base.gameObject, new Vector3(0f, 0f, 0.5f), new Vector3(1f, 1f, 4f));
	}

	public void ScaleAround(GameObject target, Vector3 pivot, Vector3 scaleFactor)
	{
		Vector3 vector = target.transform.localPosition - pivot;
		vector.Scale(scaleFactor);
		target.transform.localPosition = pivot + vector;
		Vector3 localScale = target.transform.localScale;
		localScale.Scale(scaleFactor);
		target.transform.localScale = localScale;
	}
}
