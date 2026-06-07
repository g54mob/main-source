using UnityEngine;
using UnityEngine.UI;

namespace Motorways
{
	[RequireComponent(typeof(RectTransform))]
	public class RoadCursor : MonoBehaviour
	{
		private RectTransform _rectTransform;

		private Image _sprite;

		public bool IsVisible
		{
			get
			{
				return _sprite.enabled;
			}
			set
			{
				_sprite.enabled = value;
			}
		}

		public Vector2 Position
		{
			get
			{
				return _rectTransform.anchoredPosition;
			}
			set
			{
				_rectTransform.anchoredPosition = value;
			}
		}

		private void Awake()
		{
			_sprite = GetComponent<Image>();
			_rectTransform = GetComponent<RectTransform>();
			IsVisible = false;
		}
	}
}
