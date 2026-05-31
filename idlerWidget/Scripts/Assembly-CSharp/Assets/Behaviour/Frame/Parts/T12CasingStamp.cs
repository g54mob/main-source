using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12CasingStamp : MonoBehaviour
	{
		[SerializeField]
		private float _minY;

		[SerializeField]
		private float _maxY;

		[SerializeField]
		private float _rectractSpeed;

		[SerializeField]
		private SpriteRenderer _cylinderSprite;

		[SerializeField]
		private T12CasingConveyor _conveyor;

		private float _heightStart;

		private bool _dragging;

		private bool _stamped;

		private ActiveWorldFrame _parent;

		private void Awake()
		{
			_heightStart = _cylinderSprite.size.y;
		}

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			Vector3 localPosition = base.transform.localPosition;
			if (!_dragging)
			{
				localPosition.y = Mathf.Clamp(localPosition.y + _rectractSpeed * Time.deltaTime, _minY, _maxY);
				base.transform.localPosition = localPosition;
			}
			else
			{
				_dragging = false;
				localPosition.y = Mathf.Clamp(PlayerControls.MouseWorld.y - base.transform.parent.position.y - 0.5f, _minY, _maxY);
			}
			if (localPosition.y == _minY)
			{
				if (!_stamped)
				{
					_conveyor.Stamp(base.transform.position.x + 0.05f);
				}
				_stamped = true;
			}
			else
			{
				_stamped = false;
			}
			base.transform.localPosition = localPosition;
			_cylinderSprite.size = new Vector2(_cylinderSprite.size.x, 0f - (localPosition.y + _maxY + _heightStart));
		}

		private void OnMouseDrag()
		{
			_dragging = true;
		}
	}
}
