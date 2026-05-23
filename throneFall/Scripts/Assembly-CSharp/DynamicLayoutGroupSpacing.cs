using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class DynamicLayoutGroupSpacing : MonoBehaviour
{
	public int maxSpacing = 10;

	public float maxWidth = 1070f;

	private HorizontalLayoutGroup layout;

	private RectTransform rectT;

	private int bufferedChildCount;

	private void Awake()
	{
		layout = GetComponent<HorizontalLayoutGroup>();
		rectT = GetComponent<RectTransform>();
	}

	private void Update()
	{
		if (rectT.childCount != bufferedChildCount)
		{
			Refresh();
		}
	}

	[ContextMenu("REFRESH")]
	private void Refresh()
	{
		int num = 0;
		float num2 = 0f;
		foreach (RectTransform item in rectT)
		{
			num++;
			num2 += item.sizeDelta.x;
		}
		float num3 = (maxWidth - num2) / ((float)num - 1f);
		if (num3 > (float)maxSpacing)
		{
			num3 = maxSpacing;
		}
		layout.spacing = num3;
		bufferedChildCount = rectT.childCount;
	}
}
