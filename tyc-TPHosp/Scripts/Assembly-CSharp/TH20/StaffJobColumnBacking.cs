using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffJobColumnBacking : MonoBehaviour
	{
		[SerializeField]
		private Image _backingImage;

		[SerializeField]
		private LayoutElement _layoutElement;

		private Color _defaultColor;

		[HideInInspector]
		public Color DefaultColor
		{
			get
			{
				return _defaultColor;
			}
			set
			{
				_defaultColor = value;
				SetColor(null);
			}
		}

		public void SetColor(Color? color)
		{
			_backingImage.color = (color.HasValue ? color.Value : DefaultColor);
		}

		public void SetColumnPreferredHeight(float height)
		{
			_layoutElement.preferredHeight = height;
		}
	}
}
