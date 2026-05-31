using System;
using UnityEngine;

namespace Lean.Common
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSelectableSpriteRendererColor")]
	[AddComponentMenu("Lean/Common/Lean Selectable SpriteRenderer Color")]
	public class LeanSelectableSpriteRendererColor : LeanSelectableBehaviour
	{
		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Color selectedColor;

		[NonSerialized]
		private SpriteRenderer cachedSpriteRenderer;

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
