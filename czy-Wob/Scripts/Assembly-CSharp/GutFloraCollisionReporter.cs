using UnityEngine;

public class GutFloraCollisionReporter : MonoBehaviour
{
	public GutFloraBase baseRef;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		baseRef.OnCollision(collision);
	}
}
