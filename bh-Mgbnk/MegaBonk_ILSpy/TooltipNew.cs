using TMPro;
using UnityEngine;

public class TooltipNew : MonoBehaviour
{
	public Transform tooltipTransform;

	public TextMeshProUGUI t_tip;

	public TextSizer textSizer;

	public unsafe void Set(string text, RectTransform uiElement)
	{
		//IL_0062: Expected O, but got Ref
		GameObject gameObject = tooltipTransform.gameObject;
		gameObject.SetActive(value: true);
		Vector3[] fourCornersArray = new Vector3[4];
		uiElement.GetWorldCorners(fourCornersArray);
		float num = default(float);
		tooltipTransform.position = (Vector3)(&num);
		t_tip.text = text;
		textSizer.Refresh();
		textSizer.Recalculate();
	}

	public void Hide()
	{
		GameObject gameObject = tooltipTransform.gameObject;
		gameObject.SetActive(value: false);
	}
}
