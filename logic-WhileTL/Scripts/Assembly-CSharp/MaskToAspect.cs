using UnityEngine;

public class MaskToAspect : ActiveComponent
{
	private GameObject canvas;

	protected override void OnInit()
	{
		Transform parent = base.transform.parent;
		if (canvas == null)
		{
			canvas = GameObject.Find("CanvasHolder");
		}
		base.transform.SetParent(canvas.transform);
		base.transform.localScale = Vector3.one;
		base.transform.localPosition = Vector3.zero;
		Rect rect = canvas.GetComponent<RectTransform>().rect;
		GetComponent<RectTransform>().sizeDelta = new Vector2(rect.width, rect.height);
		base.transform.SetParent(parent);
		Vector3 localScale = base.transform.localScale;
		base.transform.localPosition = Vector3.zero;
		base.transform.localScale = localScale;
	}
}
