using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lean.Common
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Graphic))]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSelectableGraphicColor")]
	[AddComponentMenu("Lean/Common/Lean Selectable Graphic Color")]
	public class LeanSelectableGraphicColor : LeanSelectableBehaviour
	{
		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Color selectedColor;

		[NonSerialized]
		private Graphic cachedGraphic;

		public Color DefaultColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color SelectedColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		protected override void OnSelected(LeanSelect select)
		{
		}

		protected override void OnDeselected(LeanSelect select)
		{
		}

		public void UpdateColor()
		{
		}
	}
}
