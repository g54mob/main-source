using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[CreateAssetMenu(menuName = "CTS/UI/Button Swapper (Shadow Color)")]
	public class SelectableShadowColorSwapData : SelectableSwapData<Shadow>
	{
		[SerializeField]
		private PaletteData _normalColor;

		[SerializeField]
		private PaletteData _highlightedColor;

		[SerializeField]
		private PaletteData _pressedColor;

		[SerializeField]
		private PaletteData _selectedColor;

		[SerializeField]
		private PaletteData _disabledColor;

		protected override void OnAppliedTo(Shadow obj, ESelectionState selectionState)
		{
			obj.effectColor = selectionState switch
			{
				ESelectionState.Normal => _normalColor.GetColor(), 
				ESelectionState.Highlighted => _highlightedColor ? _highlightedColor.GetColor() : _normalColor.GetColor(), 
				ESelectionState.Pressed => _pressedColor ? _pressedColor.GetColor() : _normalColor.GetColor(), 
				ESelectionState.Selected => _selectedColor ? _selectedColor.GetColor() : _normalColor.GetColor(), 
				ESelectionState.Disabled => _disabledColor ? _disabledColor.GetColor() : _normalColor.GetColor(), 
				_ => throw new ArgumentOutOfRangeException("selectionState", selectionState, null), 
			};
		}
	}
}
