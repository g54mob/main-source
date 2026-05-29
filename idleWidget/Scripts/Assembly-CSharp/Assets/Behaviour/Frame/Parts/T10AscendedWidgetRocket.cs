using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AscendedWidgetRocket : MonoBehaviour
	{
		[SerializeField]
		private Rect _bounds;

		private Collider2D _collider;

		private T10AscendedWidgetPuzzle _parent;

		private bool _initialized;

		private float _pauseTimer = 1f;

		private void Start()
		{
			_collider = GetComponent<Collider2D>();
			_parent = GetComponentInParent<T10AscendedWidgetPuzzle>();
		}

		private void Update()
		{
			Vector2 mouseWorld = PlayerControls.MouseWorld;
			mouseWorld -= (Vector2)base.transform.parent.position;
			float num = Mathf.Clamp(mouseWorld.x, _bounds.xMin, _bounds.xMax);
			float y = Mathf.Clamp(mouseWorld.y, _bounds.yMin, _bounds.yMax);
			if (num == mouseWorld.x)
			{
				_initialized = true;
				_pauseTimer = 1f;
			}
			else
			{
				_pauseTimer -= Time.deltaTime;
			}
			if (_initialized && _pauseTimer > 0f)
			{
				base.transform.localPosition = new Vector3(num, y, -0.1f);
			}
			_parent.SetPuzzleActive(_pauseTimer > 0f);
		}

		public bool Touches(Collider2D other)
		{
			return _collider.IsTouching(other);
		}
	}
}
