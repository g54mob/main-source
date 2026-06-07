using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RelativeToElementPositioner : MonoBehaviour
{
	public enum VerticalAlignment
	{
		Top = 0,
		Middle = 1,
		Bottom = 2
	}

	public enum HorizontalAlignment
	{
		Right = 0,
		Center = 1,
		Left = 2
	}

	[SerializeField]
	private GameObject element;

	[SerializeField]
	private VerticalAlignment elementVerticalAlignment = VerticalAlignment.Middle;

	[SerializeField]
	private HorizontalAlignment elementHorizontalAlignment = HorizontalAlignment.Center;

	[SerializeField]
	private VerticalAlignment thisVerticalAlignment = VerticalAlignment.Middle;

	[SerializeField]
	private HorizontalAlignment thisHorizontalAlignment = HorizontalAlignment.Center;

	[Tooltip("Valor positivo move para cima e negativo para baixo")]
	[SerializeField]
	private float verticalOffset;

	[Tooltip("Valor positivo move para direita e negativo para esquerda")]
	[SerializeField]
	private float horizontalOffset;

	[SerializeField]
	private bool shouldIgnoreVerticalPosition;

	[SerializeField]
	private bool shouldIgnoreHorizontalPosition;

	[SerializeField]
	private bool shouldRefreshContinuously;

	private RectTransform elementRectTransform;

	private RectTransform thisRectTransform;

	private Vector3[] elementFourCorners;

	private Vector3[] thisFourCorners;

	private float uiPixelScale;

	private void Awake()
	{
		uiPixelScale = GetComponentInParent<Canvas>().transform.localScale.x;
		if (element != null)
		{
			elementRectTransform = element.transform as RectTransform;
		}
		thisRectTransform = base.transform as RectTransform;
		elementFourCorners = new Vector3[4];
		thisFourCorners = new Vector3[4];
	}

	private void Update()
	{
		if (shouldRefreshContinuously)
		{
			RefreshPosition();
		}
	}

	private void OnEnable()
	{
		RefreshPosition();
		StartCoroutine(RefreshOneFrameLater());
		IEnumerator RefreshOneFrameLater()
		{
			yield return new WaitForEndOfFrame();
			RefreshPosition();
		}
	}

	private void RefreshPosition()
	{
		if (element == null)
		{
			return;
		}
		elementRectTransform.GetWorldCorners(elementFourCorners);
		thisRectTransform.GetWorldCorners(thisFourCorners);
		float num = elementFourCorners[1].y - elementFourCorners[0].y;
		float num2 = elementFourCorners[2].x - elementFourCorners[1].x;
		float y = elementFourCorners[1].y;
		float y2 = elementFourCorners[0].y + num / 2f;
		float y3 = elementFourCorners[0].y;
		float x = elementFourCorners[2].x;
		float x2 = elementFourCorners[1].x + num2 / 2f;
		float x3 = elementFourCorners[1].x;
		float num3 = thisFourCorners[1].y - thisFourCorners[0].y;
		float num4 = thisFourCorners[2].x - thisFourCorners[1].x;
		if (!shouldIgnoreVerticalPosition)
		{
			if (elementVerticalAlignment == VerticalAlignment.Top)
			{
				base.transform.SetPositionY(y);
			}
			else if (elementVerticalAlignment == VerticalAlignment.Middle)
			{
				base.transform.SetPositionY(y2);
			}
			else
			{
				base.transform.SetPositionY(y3);
			}
			if (thisVerticalAlignment == VerticalAlignment.Top)
			{
				base.transform.SetPositionY(base.transform.position.y - num3 / 2f);
			}
			else if (thisVerticalAlignment == VerticalAlignment.Bottom)
			{
				base.transform.SetPositionY(base.transform.position.y + num3 / 2f);
			}
		}
		if (!shouldIgnoreHorizontalPosition)
		{
			if (elementHorizontalAlignment == HorizontalAlignment.Right)
			{
				base.transform.SetPositionX(x);
			}
			else if (elementHorizontalAlignment == HorizontalAlignment.Center)
			{
				base.transform.SetPositionX(x2);
			}
			else
			{
				base.transform.SetPositionX(x3);
			}
			if (thisHorizontalAlignment == HorizontalAlignment.Right)
			{
				base.transform.SetPositionX(base.transform.position.x + num4 / 2f);
			}
			else if (thisHorizontalAlignment == HorizontalAlignment.Right)
			{
				base.transform.SetPositionX(base.transform.position.x - num4 / 2f);
			}
		}
		base.transform.SetPositionX(base.transform.position.x + horizontalOffset * uiPixelScale);
		base.transform.SetPositionY(base.transform.position.y + verticalOffset * uiPixelScale);
	}
}
