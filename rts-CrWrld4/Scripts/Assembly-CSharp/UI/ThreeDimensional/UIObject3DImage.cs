using UnityEngine;
using UnityEngine.UI;

namespace UI.ThreeDimensional
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class UIObject3DImage : Image, ILayoutElement
	{
		float ILayoutElement.flexibleHeight => 0f;

		float ILayoutElement.flexibleWidth => 0f;

		int ILayoutElement.layoutPriority => 0;

		float ILayoutElement.minHeight => 0f;

		float ILayoutElement.minWidth => 0f;

		float ILayoutElement.preferredHeight => 0f;

		float ILayoutElement.preferredWidth => 0f;

		void ILayoutElement.CalculateLayoutInputHorizontal()
		{
		}

		void ILayoutElement.CalculateLayoutInputVertical()
		{
		}
	}
}
