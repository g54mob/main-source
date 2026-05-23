using UnityEngine;

public class SetWidthToTarget : MonoBehaviour
{
	public RectTransform target;

	public float padding;

	public float minWidth = 800f;

	private RectTransform rt;

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
		if (rt.sizeDelta.x < minWidth)
		{
			rt.sizeDelta = new Vector2(minWidth, rt.sizeDelta.y);
		}
	}

	private void Update()
	{
		if (target.sizeDelta.x + padding * 2f > minWidth && !Mathf.Approximately(rt.sizeDelta.x - padding * 2f, target.sizeDelta.x))
		{
			rt.sizeDelta = new Vector2(target.sizeDelta.x + padding * 2f, rt.sizeDelta.y);
		}
	}
}
