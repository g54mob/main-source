using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindowBase : MonoBehaviour
{
	private int rebuildAfterFrames;

	protected void QueueRebuild()
	{
		rebuildAfterFrames = 3;
	}

	private void LateUpdate()
	{
		//IL_0081: Expected O, but got I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d3: Expected O, but got I4
		if (rebuildAfterFrames < 0)
		{
			return;
		}
		int num = rebuildAfterFrames - 1;
		rebuildAfterFrames = num;
		if (rebuildAfterFrames != 0)
		{
			return;
		}
		Transform transform = base.transform;
		LayoutGroup[] componentsInChildren = transform.GetComponentsInChildren<LayoutGroup>();
		bool flag = (nint)componentsInChildren < 0;
		object obj = componentsInChildren.Length - 1;
		if (!flag)
		{
			object obj3;
			do
			{
				componentsInChildren[obj].CalculateLayoutInputHorizontal();
				componentsInChildren[obj].CalculateLayoutInputVertical();
				Transform transform2 = componentsInChildren[obj].transform;
				bool flag2 = (nint)transform2 < 0;
				bool flag3 = (object)transform2 == null;
				RectTransform layoutRoot = null;
				if (!flag3)
				{
					object obj2 = (object)transform2 - (object)typeof(RectTransform);
					flag2 = (nint)obj2 < 0;
					bool flag4 = (object)transform2.GetType() != typeof(RectTransform);
					layoutRoot = null;
					if (!flag4)
					{
						layoutRoot = (RectTransform)transform2;
					}
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
				obj--;
				obj3 = !flag2;
			}
			while (obj3 != null);
		}
		RectTransform component = transform.GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		ButtonManager.Refresh();
	}

	public DWindowBase()
	{
		//IL_000f: Expected I4, but got I8
		rebuildAfterFrames = -1;
		base._002Ector();
	}
}
