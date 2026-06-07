using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AscendedWidgetObstacle : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private float _destroyY;

		private Collider2D _collider;

		private T10AscendedWidgetPuzzle _parent;

		private bool _crashed;

		private bool _scored;

		private void Start()
		{
			_collider = GetComponent<Collider2D>();
			_parent = GetComponentInParent<T10AscendedWidgetPuzzle>();
		}

		private void Update()
		{
			if (!_parent.PuzzleActive)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Vector3 position = base.transform.position;
			position.y -= _speed * Time.deltaTime;
			base.transform.position = position;
			if (position.y < _destroyY)
			{
				Object.Destroy(base.gameObject);
			}
			if (!_crashed && _parent.Rocket.Touches(_collider))
			{
				_crashed = true;
				_renderer.color = new Color(0.8f, 0f, 0f);
				_parent.ObstacleImpact(this);
			}
			if (!_crashed && !_scored && position.y < _parent.Rocket.transform.position.y)
			{
				_scored = true;
				_parent.ObstacleScored(this);
			}
		}
	}
}
