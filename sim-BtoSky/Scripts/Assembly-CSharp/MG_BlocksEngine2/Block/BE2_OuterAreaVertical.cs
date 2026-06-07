using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	public class BE2_OuterAreaVertical : BE2_OuterArea
	{
		public BE2_OuterAreaVertical(Transform transform)
			: base(transform)
		{
			(transform as RectTransform).pivot = new Vector2(0f, 1f);
		}

		protected override void InitializeLayoutGroup()
		{
			LayoutGroup component = Transform.GetComponent<LayoutGroup>();
			if (!(component is VerticalLayoutGroup))
			{
				Object.Destroy(component);
			}
			VerticalLayoutGroup verticalLayoutGroup = Transform.GetComponent<VerticalLayoutGroup>();
			if (!verticalLayoutGroup)
			{
				verticalLayoutGroup = Transform.gameObject.AddComponent<VerticalLayoutGroup>();
			}
			verticalLayoutGroup.padding.left = 0;
			verticalLayoutGroup.padding.right = 0;
			verticalLayoutGroup.padding.top = -10;
			verticalLayoutGroup.padding.bottom = 0;
			verticalLayoutGroup.spacing = -10f;
			verticalLayoutGroup.childControlHeight = false;
			verticalLayoutGroup.childControlWidth = false;
			verticalLayoutGroup.childForceExpandHeight = false;
			verticalLayoutGroup.childForceExpandWidth = false;
		}
	}
}
