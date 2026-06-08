using System;
using TMPro;
using UnityEngine;

public class TextScroll : ObjectScroll
{
	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		rectCloneTransform.gameObject.GetComponent<TextMeshProUGUI>().text = scrollingObject.GetComponent<TextMeshProUGUI>().text;
		Vector2 vector = new Vector3(scrollSpeed * 20f * Time.deltaTime, 0f, 0f);
		rectTransform.anchoredPosition += vector;
		float rightBound = objectAreaWidth + Math.Abs(startAnchoredPos.x - startAnchoredPosClone.x) - rectTransform.rect.width;
		if (ExceededBounds(rectTransform, rightBound))
		{
			rectTransform.anchoredPosition = startAnchoredPos;
			rectTransform.anchoredPosition -= new Vector2(rectTransform.rect.width, 0f);
		}
		rectCloneTransform.anchoredPosition += vector;
		if (ExceededBounds(rectCloneTransform, rightBound))
		{
			rectCloneTransform.anchoredPosition = startAnchoredPos;
			rectCloneTransform.anchoredPosition -= new Vector2(rectTransform.rect.width, 0f);
		}
	}

	public bool ExceededBounds(RectTransform rt, float rightBound)
	{
		bool flag = rt.anchoredPosition.x > rightBound;
		return scrollSpeed >= 0f && flag;
	}

	public override void SetClonePosition(float offset)
	{
		rectTransform = scrollingObject.GetComponent<RectTransform>();
		startAnchoredPosClone = new Vector3(0f - offset, startAnchoredPos.y, startAnchoredPos.z);
		rectCloneTransform.anchoredPosition = startAnchoredPosClone;
		rectCloneTransform.localPosition = new Vector3(rectCloneTransform.localPosition.x, rectCloneTransform.localPosition.y, 0f);
	}
}
