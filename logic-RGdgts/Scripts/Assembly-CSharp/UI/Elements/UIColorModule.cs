using UI.Common;

namespace UI.Elements
{
	public class UIColorModule
	{
		private UIColorMapperController colorController;

		public string currentColorMapper;

		public void Init(UIColorMapperController colorController, bool isSelected, bool hasSecondColor = false)
		{
		}

		public void ResetElement(bool isInteractable, bool isSelected = false, bool hasSecondColor = false)
		{
		}

		public void SetColor(UIColorStates color)
		{
		}

		public void SetDisabledColor(bool hasSecondColor = false)
		{
		}

		public void SetNormalColor(bool isSelected, bool hasSecondColor = false)
		{
		}

		public void SetPressedColor(bool isSelected, bool hasSecondColor = false)
		{
		}

		public void SetHighlightedColor(bool isSelected, bool hasSecondColor = false)
		{
		}

		public void Disable()
		{
		}

		public void Enable()
		{
		}

		public void SetSelectedColor(bool hasSecondColor = false)
		{
		}

		public void OnUnselected(bool hasSecondColor = false)
		{
		}
	}
}
