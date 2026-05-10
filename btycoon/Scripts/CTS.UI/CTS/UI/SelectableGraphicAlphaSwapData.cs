using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[CreateAssetMenu(menuName = "CTS/UI/Button Swapper (Graphic Alpha")]
	public class SelectableGraphicAlphaSwapData : SelectableSwapData<Graphic>
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _normalAlpha = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _highlightedAlpha = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _pressedAlpha = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _selectedAlpha = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _disabledAlpha = 1f;

		protected override void OnAppliedTo(Graphic obj, ESelectionState selectionState)
		{
			Color color = obj.color;
			color.a = selectionState switch
			{
				ESelectionState.Normal => _normalAlpha, 
				ESelectionState.Highlighted => _highlightedAlpha, 
				ESelectionState.Pressed => _pressedAlpha, 
				ESelectionState.Selected => _selectedAlpha, 
				ESelectionState.Disabled => _disabledAlpha, 
				_ => throw new ArgumentOutOfRangeException("selectionState", selectionState, null), 
			};
			obj.color = color;
		}
	}
}
