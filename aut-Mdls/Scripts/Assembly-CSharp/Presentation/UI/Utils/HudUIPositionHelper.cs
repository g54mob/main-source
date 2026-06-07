using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Presentation.UI.Utils
{
	public class HudUIPositionHelper : MonoBehaviour
	{
		[SerializeField]
		private List<HudUIPosition> _hudUIPositions;

		private RectTransform _rectTransform;

		private Vector2 _position;

		private void Awake()
		{
			_rectTransform = base.transform as RectTransform;
			_position = _rectTransform.anchoredPosition;
			for (int i = 0; i < _hudUIPositions.Count; i++)
			{
				_hudUIPositions[i].BoolVariable.ValueChanged += OnValueChanged;
				SetPosition(_hudUIPositions[i]);
			}
		}

		public void Refresh()
		{
			if (_rectTransform == null)
			{
				_rectTransform = base.transform as RectTransform;
				_position = _rectTransform.anchoredPosition;
			}
			for (int i = 0; i < _hudUIPositions.Count; i++)
			{
				SetPosition(_hudUIPositions[i]);
			}
		}

		private void OnDestroy()
		{
			for (int i = 0; i < _hudUIPositions.Count; i++)
			{
				_hudUIPositions[i].BoolVariable.ValueChanged -= OnValueChanged;
			}
		}

		private void OnValueChanged(bool value)
		{
			for (int i = 0; i < _hudUIPositions.Count; i++)
			{
				SetPosition(_hudUIPositions[i]);
			}
		}

		private void SetPosition(HudUIPosition hudUIIPosition)
		{
			Vector2 vector = (hudUIIPosition.BoolVariable.Value ? hudUIIPosition.ActivePosition : hudUIIPosition.InactivePosition);
			if ((hudUIIPosition.IgnoreZero && vector.x != 0f) || !hudUIIPosition.IgnoreZero)
			{
				_position.x = vector.x;
			}
			if ((hudUIIPosition.IgnoreZero && vector.y != 0f) || !hudUIIPosition.IgnoreZero)
			{
				_position.y = vector.y;
			}
			_rectTransform.DOKill();
			_rectTransform.DOAnchorPos(_position, 0.5f).SetEase(Ease.InOutExpo);
		}
	}
}
