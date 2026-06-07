using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class GradientEditorHandleScript : MonoBehaviour
	{
		[SerializeField]
		private Color _normalColour = new Color(1f, 1f, 1f, 0.6f);

		[SerializeField]
		private Color _selectedColour = Color.white;

		private float _position;

		private RectTransform _rectTransform;

		private Image _image;

		private bool _selected;

		public float Alpha { get; set; }

		public Color Color { get; set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					_image.color = (value ? _selectedColour : _normalColour);
				}
			}
		}

		public GradientAlphaKey AlphaKey
		{
			get
			{
				return new GradientAlphaKey(Alpha, Position);
			}
			set
			{
				Alpha = value.alpha;
				Position = value.time;
			}
		}

		public GradientColorKey ColorKey
		{
			get
			{
				return new GradientColorKey(Color, Position);
			}
			set
			{
				Color = value.color;
				Position = value.time;
			}
		}

		public bool Active
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public bool Reserved { get; set; }

		public bool CanReuse
		{
			get
			{
				if (!Active)
				{
					return !Reserved;
				}
				return false;
			}
		}

		public float Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
				_rectTransform.anchorMin = new Vector2(value, _rectTransform.anchorMin.y);
				_rectTransform.anchorMax = new Vector2(value, _rectTransform.anchorMax.y);
			}
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_image = GetComponent<Image>();
			_image.color = (_selected ? _selectedColour : _normalColour);
		}
	}
}
