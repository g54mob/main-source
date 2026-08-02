using UnityEngine;

namespace UltimateRadialMenuExample.CharacterInventory2D
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		public float speed = 10f;

		private Rigidbody2D myRigidbody;

		private SpriteRenderer mySpriteRenderer;

		private void Start()
		{
			myRigidbody = GetComponent<Rigidbody2D>();
			mySpriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void FixedUpdate()
		{
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			if (Mathf.Abs(axis) > 0f)
			{
				mySpriteRenderer.flipX = Mathf.Sign(axis) == -1f;
			}
			Vector3 position = Camera.main.WorldToViewportPoint(myRigidbody.position + new Vector2(axis, axis2) * speed);
			position.x = Mathf.Clamp(position.x, 0.05f, 0.95f);
			position.y = Mathf.Clamp(position.y, 0.1f, 0.9f);
			myRigidbody.MovePosition(Camera.main.ViewportToWorldPoint(position));
		}
	}
}
