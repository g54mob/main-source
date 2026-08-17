using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI;

public static class UiUtility
{
	public static void RebuildUi(Transform root)
	{
		//IL_0036: Expected O, but got I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_015a: Expected O, but got I4
		LayoutGroup[] componentsInChildren = root.GetComponentsInChildren<LayoutGroup>();
		bool flag = (nint)componentsInChildren < 0;
		object obj = componentsInChildren.Length - 1;
		if (!flag)
		{
			object obj3;
			do
			{
				componentsInChildren[obj].CalculateLayoutInputHorizontal();
				componentsInChildren[obj].CalculateLayoutInputVertical();
				Transform transform = componentsInChildren[obj].transform;
				bool flag2 = (nint)transform < 0;
				bool flag3 = (object)transform == null;
				RectTransform layoutRoot = null;
				if (!flag3)
				{
					object obj2 = (object)transform - (object)typeof(RectTransform);
					flag2 = (nint)obj2 < 0;
					bool flag4 = (object)transform.GetType() != typeof(RectTransform);
					layoutRoot = null;
					if (!flag4)
					{
						layoutRoot = (RectTransform)transform;
					}
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
				obj--;
				obj3 = !flag2;
			}
			while (obj3 != null);
		}
		RectTransform component = root.GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
	}
}
