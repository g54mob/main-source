using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T6MicroprocessorPuzzle : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		[SerializeField]
		private float _minDistance;

		[SerializeField]
		private float _maxDistance;

		private float _extent;

		private bool _dragging;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_extent = base.transform.localPosition.y;
		}

		private void OnMouseDrag()
		{
			_dragging = true;
			Vector3 vector = PlayerControls.MouseWorld;
			_extent = Mathf.Clamp((vector - base.transform.parent.position).y, _minDistance, _maxDistance);
			_updateSprites();
		}

		private void Update()
		{
			if (_dragging)
			{
				_dragging = false;
				return;
			}
			_extent = Mathf.Clamp(_extent - Time.deltaTime, _minDistance, _maxDistance);
			_updateSprites();
		}

		private void _updateSprites()
		{
			_sprite.size = new Vector2(_sprite.size.x, -1f * (_extent - _minDistance));
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, _extent, base.transform.localPosition.z);
		}

		public void ButtonClicked()
		{
			if (_extent > _minDistance)
			{
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T6MicroprocessorWarning");
			}
		}
	}
}
