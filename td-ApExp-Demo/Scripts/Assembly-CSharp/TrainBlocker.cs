using UnityEngine;

public class TrainBlocker : MonoBehaviour
{
	[SerializeField]
	private BoxCollider2D collider;

	[SerializeField]
	private float pushDirectionXNormalized = -1f;

	[SerializeField]
	private float pushForce = 1f;

	private Vector2 pushVector;

	private void Start()
	{
		pushVector = new Vector2(pushDirectionXNormalized * pushForce, 0f);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerController component = collision.gameObject.GetComponent<PlayerController>();
		if ((object)component != null)
		{
			Rigidbody2D component2 = collision.gameObject.GetComponent<Rigidbody2D>();
			if ((object)component2 != null)
			{
				component.WallStopPush();
				component2.AddForce(pushVector, ForceMode2D.Force);
			}
		}
	}
}
