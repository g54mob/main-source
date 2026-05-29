using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9UnshackledWidgetBall : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		[SerializeField]
		private float _velocity;

		private T9UnshackledWidgetPuzzle _parent;

		private Vector2 _move;

		private bool _isGhost;

		private void Awake()
		{
			_parent = GetComponentInParent<T9UnshackledWidgetPuzzle>();
			_move = new Vector2(SeededRandom.Global.RandomBool() ? 1f : (-1f), 1f).normalized;
		}

		private void Update()
		{
			Transform transform = null;
			if (!_isGhost)
			{
				RaycastHit2D raycastHit2D = Physics2D.Raycast(base.transform.position, (_move.y > 0f) ? Vector2.up : Vector2.down, 0.16f);
				if ((bool)raycastHit2D.collider)
				{
					_move.y *= -1f;
					transform = raycastHit2D.transform;
				}
				RaycastHit2D raycastHit2D2 = Physics2D.Raycast(base.transform.position, (_move.x > 0f) ? Vector2.right : Vector2.left, 0.16f);
				if ((bool)raycastHit2D2.collider)
				{
					_move.x *= -1f;
					transform = raycastHit2D2.transform;
				}
			}
			if ((bool)transform)
			{
				if (transform.gameObject.name == "BoundsBottom")
				{
					StartCoroutine(_ballLost());
				}
				else
				{
					T9UnshackledWidgetBrick component = transform.GetComponent<T9UnshackledWidgetBrick>();
					if ((bool)component)
					{
						Object.Destroy(component.gameObject);
						_parent.BrickDestroyed();
					}
					else if ((bool)transform.GetComponent<T9UnshackledWidgetBat>())
					{
						_velocity += 0.25f;
					}
				}
			}
			Vector3 vector = _move * (_velocity * Time.deltaTime);
			base.transform.position = base.transform.position + vector;
		}

		private IEnumerator _ballLost()
		{
			_isGhost = true;
			_move.y *= -1f;
			_parent.BallLost();
			float progress = 0f;
			while (progress < 1f)
			{
				progress += Time.deltaTime * 2f;
				_sprite.color = new Color(1f, 1f, 1f, 1f - progress);
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
