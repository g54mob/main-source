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
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void ToggleSprites()
		{
		}

		private void UpdateSprites()
		{
		}

		private void UpdateSprites(bool selected)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}
