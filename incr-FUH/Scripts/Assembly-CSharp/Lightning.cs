using UnityEngine;

public class Lightning : MonoBehaviour
{
	public void SetPosition(Vector2 start, Vector2 end)
	{
		float x = Vector2.Distance(start, end);
		Vector2 vector = (start + end) / 2f;
		base.transform.position = vector;
		Vector2 vector2 = end - start;
		float z = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
		base.transform.rotation = Quaternion.Euler(0f, 0f, z);
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		Vector2 size = component.size;
		size.x = x;
		component.size = size;
	}

	public void StartLigning()
	{
		base.gameObject.SetActive(value: true);
		Object.Destroy(base.gameObject, 0.2f);
	}
}
