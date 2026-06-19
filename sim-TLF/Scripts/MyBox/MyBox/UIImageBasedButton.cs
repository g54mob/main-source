using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyBox
{
	[RequireComponent(typeof(Button), typeof(Image))]
	public class UIImageBasedButton : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		[MustBeAssigned]
		private Sprite _regularSprite;

		[SerializeField]
		[MustBeAssigned]
		private Sprite _regularSelectedSprite;

		[SerializeField]
		[MustBeAssigned]
		private Sprite _clickedSprite;

		[SerializeField]
		[MustBeAssigned]
		private Sprite _clickedSelectedSprite;

		public Action<bool> OnToggled;

		private bool _alternative;

		private bool _selected;

		private Image _image;

		private Button _button;

		public bool AlternativeSpriteset
		{
			get
			{
				return _alternative;
			}
			set
			{
				_alternative = value;
			}
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(ToggleSprites);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(ToggleSprites);
		}

		private void ToggleSprites()
		{
			_alternative = !_alternative;
			OnToggled?.Invoke(_alternative);
			UpdateSprites();
		}

		private void UpdateSprites()
		{
			_image.sprite = (_alternative ? ((!_selected) ? _clickedSprite : _clickedSelectedSprite) : ((!_selected) ? _regularSprite : _regularSelectedSprite));
		}

		private void UpdateSprites(bool selected)
		{
			_selected = selected;
			UpdateSprites();
		}

		public void OnSelect(BaseEventData eventData)
		{
			UpdateSprites(selected: true);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			UpdateSprites(selected: false);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UpdateSprites(selected: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UpdateSprites(selected: false);
		}
	}
}
