using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[CreateAssetMenu(menuName = "CTS/UI/Button Swapper (Image Sprite)")]
	public class SelectableImageSpriteSwapData : SelectableSwapData<Image>
	{
		[SerializeField]
		private Sprite _normalSprite;

		[SerializeField]
		private Sprite _highlightedSprite;

		[SerializeField]
		private Sprite _pressedSprite;

		[SerializeField]
		private Sprite _selectedSprite;

		[SerializeField]
		private Sprite _disabledSprite;

		protected override void OnAppliedTo(Image image, ESelectionState selectionState)
		{
			image.overrideSprite = selectionState switch
			{
				ESelectionState.Normal => _normalSprite, 
				ESelectionState.Highlighted => _highlightedSprite ?? _normalSprite, 
				ESelectionState.Pressed => _pressedSprite ?? _normalSprite, 
				ESelectionState.Selected => _selectedSprite ?? _normalSprite, 
				ESelectionState.Disabled => _disabledSprite ?? _normalSprite, 
				_ => throw new ArgumentOutOfRangeException("selectionState", selectionState, null), 
			};
		}
	}
}
