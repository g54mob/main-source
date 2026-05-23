using UnityEngine;
using UnityEngine.UI;

public class TextBackgroundFitter : MonoBehaviour
{
	private RectTransform ownRT;

	public RectTransform target;

	public ContentSizeFitter csf;

	public float horizontalPaddingPerSide;

	public float verticalPaddingPerSide;

	private void OnEnable()
	{
		ownRT = GetComponent<RectTransform>();
		csf.enabled = false;
		csf.enabled = true;
		LayoutRebuilder.ForceRebuildLayoutImmediate(target);
		ownRT.sizeDelta = new Vector2(target.sizeDelta.x + horizontalPaddingPerSide * 2f, target.sizeDelta.y + verticalPaddingPerSide * 2f);
	}
}
