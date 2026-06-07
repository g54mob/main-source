using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GuiNew
{
	[ExecuteInEditMode]
	public class StackPanelScript : MonoBehaviour
	{
		[SerializeField]
		private bool _fitHeightToContent;

		[SerializeField]
		private bool _horizontal;

		[SerializeField]
		private float _padding = 5f;

		protected virtual void Update()
		{
			if (_horizontal)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				List<RectTransform> list = new List<RectTransform>();
				for (int i = 0; i < base.transform.childCount; i++)
				{
					RectTransform component = base.transform.GetChild(i).GetComponent<RectTransform>();
					if (component != null && component.gameObject.activeInHierarchy)
					{
						num3 += component.rect.width + _padding;
						list.Add(component);
					}
				}
				float num4 = 0f - num3 / 2f;
				foreach (RectTransform item in list)
				{
					num += item.rect.width + _padding;
					if (item.rect.height > num2)
					{
						num2 = item.rect.height;
					}
					item.transform.localPosition = new Vector3(num4, item.transform.localPosition.y, 0f);
					num4 += item.rect.width + _padding;
				}
				if (_fitHeightToContent)
				{
					GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, num);
				}
				return;
			}
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			for (int j = 0; j < base.transform.childCount; j++)
			{
				RectTransform component2 = base.transform.GetChild(j).GetComponent<RectTransform>();
				if (component2 != null && component2.gameObject.activeInHierarchy)
				{
					num5 += component2.rect.height + _padding;
					if (component2.rect.width > num6)
					{
						num6 = component2.rect.width;
					}
					component2.transform.localPosition = new Vector3(component2.transform.localPosition.x, num7, 0f);
					num7 -= component2.rect.height + _padding;
				}
			}
			if (_fitHeightToContent)
			{
				GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, num5);
			}
		}
	}
}
