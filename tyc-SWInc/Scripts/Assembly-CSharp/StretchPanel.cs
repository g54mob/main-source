using UnityEngine;

public class StretchPanel : MonoBehaviour
{
	public RectTransform Self;

	public RectTransform Splitter;

	public RectTransform APanel;

	public RectTransform BPanel;

	public RectTransform SplitterIcon;

	public Vector2 Limits = new Vector2(64f, 64f);

	public CursorOverride CursorController;

	public bool Horizontal;

	public bool CanCollapseA = true;

	public bool CanCollapseB = true;

	public float Split = 0.5f;

	public float Spread = 8f;

	public float DefaultSplit = 0.5f;

	private bool _isDragging;

	private bool _wasCollapsedA;

	private bool _wasCollapsedB;

	[ContextMenu("Initialize panels")]
	public void DoSet()
	{
		SetSizes();
	}

	private void Start()
	{
		SetSizes();
	}

	private void OnEnable()
	{
		HelpTipPanel.Show(HintController.Hints.HintStretchPanel, Splitter);
		CursorController.Cursor = (Horizontal ? "HorizontalStretch" : "VerticalStretch");
	}

	private void Update()
	{
		if (_isDragging)
		{
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
			float num = (Horizontal ? Self.rect.width : Self.rect.height);
			float num2 = (Horizontal ? localPoint.x : localPoint.y);
			float num3 = (Horizontal ? Limits.x : Limits.y);
			float num4 = (Horizontal ? Limits.y : Limits.x);
			bool flag = !_wasCollapsedA && (Horizontal ? CanCollapseA : CanCollapseB);
			bool flag2 = !_wasCollapsedB && (Horizontal ? CanCollapseB : CanCollapseA);
			if (num2 < num3)
			{
				Split = (flag ? 0f : (num3 / num));
			}
			else if (num2 > num - num4)
			{
				Split = (flag2 ? 1f : (1f - num4 / num));
			}
			else if (DefaultSplit > 0f && Mathf.Abs(DefaultSplit * num - num2) < Spread * 2f)
			{
				Split = DefaultSplit;
			}
			else
			{
				Split = Mathf.Clamp01(num2 / num);
			}
			SetSizes();
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
		}
	}

	public void SetSizes()
	{
		float x = (Horizontal ? Split : 0f);
		float x2 = (Horizontal ? Split : 1f);
		float y = (Horizontal ? 0f : Split);
		float y2 = (Horizontal ? 1f : Split);
		float num = (Horizontal ? Spread : 0f);
		float num2 = (Horizontal ? 0f : Spread);
		float num3 = num / 2f;
		float num4 = num2 / 2f;
		RectTransform rectTransform = (Horizontal ? APanel : BPanel);
		RectTransform rectTransform2 = (Horizontal ? BPanel : APanel);
		rectTransform.anchorMin = new Vector2(0f, 0f);
		rectTransform.anchorMax = new Vector2(x2, y2);
		rectTransform2.anchorMin = new Vector2(x, y);
		rectTransform2.anchorMax = new Vector2(1f, 1f);
		Splitter.anchorMin = new Vector2(x, y);
		Splitter.anchorMax = new Vector2(x2, y2);
		Splitter.anchoredPosition = Vector2.zero;
		Splitter.sizeDelta = new Vector2(num, num2);
		Vector2 offsetMax = (rectTransform.offsetMin = Vector2.zero);
		rectTransform2.offsetMax = offsetMax;
		rectTransform.offsetMax = new Vector2(0f - num3, 0f - num4);
		rectTransform2.offsetMin = new Vector2(num3, num4);
		if (Split <= 0f)
		{
			rectTransform.gameObject.SetActive(false);
			rectTransform2.gameObject.SetActive(true);
			rectTransform2.offsetMin = new Vector2(num, num2);
			Splitter.anchoredPosition = new Vector2(num3, num4);
		}
		else if (Split >= 1f)
		{
			rectTransform.gameObject.SetActive(true);
			rectTransform2.gameObject.SetActive(false);
			rectTransform.offsetMax = new Vector2(0f - num, 0f - num2);
			Splitter.anchoredPosition = new Vector2(0f - num3, 0f - num4);
		}
		else
		{
			rectTransform.gameObject.SetActive(true);
			rectTransform2.gameObject.SetActive(true);
		}
		SplitterIcon.rotation = Quaternion.Euler(0f, 0f, (!Horizontal) ? 90 : 0);
	}

	public void StartDrag()
	{
		_wasCollapsedA = Split <= 0f;
		_wasCollapsedB = Split >= 1f;
		_isDragging = true;
		HelpTipPanel.DismissHint(HintController.Hints.HintStretchPanel);
	}
}
