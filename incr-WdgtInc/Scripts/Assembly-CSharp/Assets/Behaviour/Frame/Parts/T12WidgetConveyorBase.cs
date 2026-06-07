using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12WidgetConveyorBase : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			_impartForce(collision.rigidbody);
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			_impartForce(collision.rigidbody);
		}

		private void _impartForce(Rigidbody2D body)
		{
			if ((bool)body)
			{
				Vector2 linearVelocity = body.linearVelocity;
				if (linearVelocity.x < 1f)
				{
					linearVelocity.x += 0.2f;
				}
				body.linearVelocity = linearVelocity;
			}
		}
	}
}
