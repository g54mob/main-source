using JSAM;
using UnityEngine;

namespace Minigames.Core
{
	public class ScrewdriverTool : MonoBehaviour, ITool
	{
		[SerializeField]
		private RectTransform _transform;

		[SerializeField]
		private RectTransform _tipPoint;

		[SerializeField]
		private float _rotationOffset;

		private bool _isEngaged;

		private Vector2 _engagedPosition;

		public RectTransform Transform => _transform;

		public RectTransform InteractionPoint => _tipPoint;

		public float RotationOffset => _rotationOffset;

		public bool IsEngaged => _isEngaged;

		public void UpdatePosition(Vector2 localPosition)
		{
			if (!_isEngaged)
			{
				_transform.localPosition = localPosition;
			}
		}

		public void UpdateRotation(float angle)
		{
			_transform.rotation = Quaternion.Euler(0f, 0f, angle);
		}

		public void RotateAroundAxis(float angleDelta)
		{
			_transform.Rotate(angleDelta, 0f, 0f, Space.Self);
		}

		public bool CanEngage(IFastener fastener)
		{
			return !_isEngaged;
		}

		public void Engage(Vector2 position)
		{
			_isEngaged = true;
			_engagedPosition = position;
			AudioManager.PlaySound(MiniGamesLibrarySounds.ScrewSnap);
		}

		public void Disengage()
		{
			_isEngaged = false;
			AudioManager.PlaySound(MiniGamesLibrarySounds.ScrewUnSnap);
		}
	}
}
