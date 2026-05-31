using System;
using UnityEngine;

namespace Lean.Common
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Renderer))]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSelectableRendererColor")]
	[AddComponentMenu("Lean/Common/Lean Selectable Renderer Color")]
	public class LeanSelectableRendererColor : LeanSelectableBehaviour
	{
		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Color selectedColor;

		[NonSerialized]
		private Renderer cachedRenderer;

		[NonSerialized]
		private MaterialPropertyBlock properties;

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

		protected override void Start()
		{
		}

		public void UpdateColor()
		{
		}
	}
}
