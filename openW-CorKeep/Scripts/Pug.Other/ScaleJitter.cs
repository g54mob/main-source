using UnityEngine;

public class ScaleJitter : MonoBehaviour
{
	public Vector2 minLocalScale;

	public Vector2 maxLocalScale;

	public void LateUpdate()
	{
		base.transform.localScale = new Vector3(Random.Range(minLocalScale.x, maxLocalScale.x), Random.Range(minLocalScale.y, maxLocalScale.y), 1f);
	}
}
