using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkChevronItem : MonoBehaviour
	{
		[SerializeField]
		private Image _chevronImage;

		[SerializeField]
		private Image _chevronImageGlow;

		[SerializeField]
		private float _imageAlpha = 0.6f;

		private float _alpha = 1f;

		private Color _color;

		private float _glow;

		public float ChevronAlpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = value;
				Refresh();
			}
		}

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				Refresh();
			}
		}

		public float Glow
		{
			get
			{
				return _glow;
			}
			set
			{
				_glow = value;
				Refresh();
			}
		}

		private void Refresh()
		{
			_chevronImage.color = new Color(_color.r, _color.g, _color.b, _imageAlpha * _alpha);
			_chevronImageGlow.color = new Color(_color.r, _color.g, _color.b, _glow * _alpha);
		}
	}
}
