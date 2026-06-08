using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
	[SerializeField]
	protected GameObject scrollingObject;

	protected RectTransform rectTransform;

	public float scrollSpeed;

	protected Vector3 startAnchoredPos;

	protected Vector3 startAnchoredPosClone;

	protected float objectAreaWidth;

	protected RectTransform rectCloneTransform;

	protected virtual void Start()
	{
		rectTransform = scrollingObject.GetComponent<RectTransform>();
		startAnchoredPos = rectTransform.anchoredPosition;
		startAnchoredPos.z = 0f;
		rectCloneTransform = Object.Instantiate(scrollingObject).GetComponent<RectTransform>();
		objectAreaWidth = GetComponent<RectTransform>().rect.width;
		rectCloneTransform.SetParent(rectTransform.parent);
		rectCloneTransform.localScale = Vector3.one;
		SetClonePosition(objectAreaWidth);
	}

	protected virtual void Update()
	{
		Vector2 vector = new Vector3(scrollSpeed * 20f * Time.deltaTime, 0f, 0f);
		rectTransform.anchoredPosition += vector;
		if (ExceededBounds(rectTransform, startAnchoredPos.x + rectTransform.rect.width, startAnchoredPos.x - rectTransform.rect.width))
		{
			rectTransform.anchoredPosition = startAnchoredPos;
			if (scrollSpeed >= 0f)
			{
				rectTransform.anchoredPosition -= new Vector2(rectTransform.rect.width, 0f);
			}
			else
			{
				rectTransform.anchoredPosition += new Vector2(rectTransform.rect.width, 0f);
			}
		}
		rectCloneTransform.anchoredPosition += vector;
		if (ExceededBounds(rectCloneTransform, startAnchoredPos.x + rectTransform.rect.width, startAnchoredPos.x - rectTransform.rect.width))
		{
			rectCloneTransform.anchoredPosition = startAnchoredPos;
			if (scrollSpeed >= 0f)
			{
				rectCloneTransform.anchoredPosition -= new Vector2(rectTransform.rect.width, 0f);
			}
			else
			{
				rectCloneTransform.anchoredPosition += new Vector2(rectTransform.rect.width, 0f);
			}
		}
	}

	public virtual bool ExceededBounds(RectTransform rt, float rightBound, float leftBound)
	{
		bool flag = rt.anchoredPosition.x > rightBound;
		bool flag2 = rt.anchoredPosition.x < leftBound;
		if (!(scrollSpeed >= 0f && flag))
		{
			return scrollSpeed < 0f && flag2;
		}
		return true;
	}

	public void SetScrollSpeed(float speed)
	{
		scrollSpeed = speed;
	}

	public void ResetPosition()
	{
		if (!(rectTransform == null))
		{
			rectTransform.anchoredPosition = startAnchoredPos;
			rectCloneTransform.anchoredPosition = startAnchoredPosClone;
		}
	}

	public virtual void SetClonePosition(float offset)
	{
		rectTransform = scrollingObject.GetComponent<RectTransform>();
		startAnchoredPosClone = ((scrollSpeed >= 0f) ? (startAnchoredPos - new Vector3(rectCloneTransform.rect.width, 0f, 0f)) : (startAnchoredPos + new Vector3(rectCloneTransform.rect.width, 0f, 0f)));
		rectCloneTransform.anchoredPosition = startAnchoredPosClone;
		rectCloneTransform.localPosition = new Vector3(rectCloneTransform.localPosition.x, rectCloneTransform.localPosition.y, 0f);
	}
}
