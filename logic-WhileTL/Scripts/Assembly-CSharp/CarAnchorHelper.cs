using UnityEngine;

public class CarAnchorHelper : MonoBehaviour
{
	public RectTransform staticObject;

	public RectTransform leftDynamic;

	public RectTransform rightDynamic;

	private RectTransform selfRect;

	private void Start()
	{
		selfRect = base.gameObject.GetComponent<RectTransform>();
	}

	private void LateUpdate()
	{
		if (!(staticObject == null))
		{
			float num = selfRect.rect.width - staticObject.rect.width;
			num /= 2f;
			num -= staticObject.transform.localPosition.x;
			float num2 = selfRect.rect.width - staticObject.rect.width;
			num2 /= 2f;
			num2 += staticObject.transform.localPosition.x;
			leftDynamic.sizeDelta = Vector2.one * num2;
			rightDynamic.sizeDelta = Vector2.one * num;
			Vector3 localPosition = rightDynamic.transform.localPosition;
			localPosition.x = staticObject.rect.width / 2f + num / 2f + staticObject.transform.localPosition.x;
			rightDynamic.localPosition = localPosition;
			Vector3 localPosition2 = leftDynamic.transform.localPosition;
			localPosition2.x = (0f - staticObject.rect.width) / 2f + (0f - num2) / 2f + staticObject.transform.localPosition.x;
			leftDynamic.localPosition = localPosition2;
		}
	}
}
