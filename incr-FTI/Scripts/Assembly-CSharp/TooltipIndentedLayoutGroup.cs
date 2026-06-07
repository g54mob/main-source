using UnityEngine;
using UnityEngine.UI;

public class TooltipIndentedLayoutGroup : MonoBehaviour
{
	public LayoutGroup layoutGroup;

	public RectTransform indentRegion;

	public int placementIndex;

	public void ResetDisplay()
	{
		placementIndex = 0;
	}

	public void SetIndentLevel(int level)
	{
		layoutGroup.padding.left = level * 40;
	}
}
