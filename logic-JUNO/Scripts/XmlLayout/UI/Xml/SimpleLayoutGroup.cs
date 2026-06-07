using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	[RequireComponent(typeof(RectTransform))]
	public class SimpleLayoutGroup : HorizontalLayoutGroup
	{
		protected override void Awake()
		{
			base.Awake();
		}

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();
		}

		public override void CalculateLayoutInputVertical()
		{
			base.CalculateLayoutInputVertical();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
		}

		public override void SetLayoutHorizontal()
		{
			base.SetLayoutHorizontal();
		}

		public override void SetLayoutVertical()
		{
			base.SetLayoutVertical();
		}
	}
}
