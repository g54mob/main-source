using UI.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Elements
{
	public class UIColoredButton : UIButton
	{
		[SerializeField]
		private bool changeColorWhenSelected;

		public bool isSecondaryColor;

		private string currentColorMapper;

		private IUIButtonModule[] buttonModules;

		private UIColorMapperController colorController;

		public override void Init(ButtonParameters? buttonP = null)
		{
		}

		public void SetColor(UIColorStates color)
		{
		}

		public void SetDisabledColor()
		{
		}

		public void SetNormalColor()
		{
		}

		public void SetPressedColor()
		{
		}

		public void SetHighlightedColor()
		{
		}

		public override void Disable()
		{
		}

		public override void Enable()
		{
		}

		public void SetSelectedColor()
		{
		}

		public override void SetSelected()
		{
		}

		public void SetPrimaryColor()
		{
		}

		public void SetSecondaryColor()
		{
		}

		public override void SetNotSelected()
		{
		}

		public override void SetActive(bool active)
		{
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
