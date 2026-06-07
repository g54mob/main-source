using UnityEngine;

public class HierarchicalGridLeafNodeUI : MonoBehaviour
{
	public int Size;

	public RectTransform RectTransform { get; private set; }

	private void Awake()
	{
		RectTransform = base.transform as RectTransform;
		RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Size);
		RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Size);
	}
}
