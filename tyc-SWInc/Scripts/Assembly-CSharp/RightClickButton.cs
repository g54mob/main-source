using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RightClickButton : MonoBehaviour, ICursorOverride
{
	public float Pos;

	public float ActualPos;

	public float DegWidth;

	public string Description;

	public SelectorController.CounterButton Counter;

	public RightClickPanel MainPanel;

	public Image Icon;

	public Image CheckMark;

	public Action OnClick;

	private RectTransform r;

	public SelectorController.ContextButtonGroup Order = SelectorController.ContextButtonGroup.Manage;

	public Color MainColor;

	public Color CheckYes;

	public Color CheckNo;

	public Color[] BColors = new Color[6]
	{
		new Color32(byte.MaxValue, 127, 142, byte.MaxValue),
		new Color32(213, 174, byte.MaxValue, byte.MaxValue),
		new Color32(133, 188, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, 191, 133, byte.MaxValue),
		new Color32(154, 241, 138, byte.MaxValue),
		new Color32(119, 210, 213, byte.MaxValue)
	};

	public static Color[] ButtonColors = new Color[6]
	{
		new Color32(byte.MaxValue, 127, 142, byte.MaxValue),
		new Color32(213, 174, byte.MaxValue, byte.MaxValue),
		new Color32(133, 188, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, 191, 133, byte.MaxValue),
		new Color32(154, 241, 138, byte.MaxValue),
		new Color32(119, 210, 213, byte.MaxValue)
	};

	private bool Highlight;

	public string CursorOverrideName
	{
		get
		{
			return "Finger";
		}
	}

	public void Init()
	{
		if (Order == SelectorController.ContextButtonGroup.Group)
		{
			Icon.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
			Icon.DOColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.2f);
			MainColor = new Color32(150, 150, 150, byte.MaxValue);
		}
		else
		{
			Icon.color = new Color32(49, 49, 49, 0);
			Icon.DOColor(new Color32(49, 49, 49, byte.MaxValue), 0.2f);
			MainColor = BColors[(int)Order % BColors.Length];
		}
		Image component = GetComponent<Image>();
		component.fillAmount = 0f;
		component.DOFillAmount((DegWidth - 0.5f) / 360f, 0.2f);
		component.color = MainColor;
		r = GetComponent<RectTransform>();
		r.rotation = Quaternion.identity;
		r.DORotate(new Vector3(0f, 0f, Pos), 0.2f);
		if (Order == SelectorController.ContextButtonGroup.Group)
		{
			r.localScale = new Vector3(1.05f, 1.05f, 1f);
		}
		Icon.GetComponent<RectTransform>().anchoredPosition = Quaternion.Euler(0f, 0f, (0f - DegWidth) / 2f) * new Vector2(0f, 96f);
		Icon.transform.rotation = Quaternion.Euler(0f, 0f, 0f - Pos);
	}

	private Color HighlightColor(Color c)
	{
		Vector3 vector = Utilities.RGBToHSV(c);
		return Utilities.HSVToRGB(vector.x * 360f, vector.y * 2f, vector.z * 0.6f).ToVector4(1f);
	}

	private void Update()
	{
		Vector2 anchoredPosition = MainPanel.SelfRect.anchoredPosition;
		Vector2 vector = new Vector2(Input.mousePosition.x, Input.mousePosition.y - (float)Screen.height) / Options.UISize;
		float magnitude = (anchoredPosition - vector).magnitude;
		float num = Mathf.DeltaAngle(Mathf.Atan2(vector.y - anchoredPosition.y, vector.x - anchoredPosition.x) * 57.29578f, Pos + 90f);
		if (magnitude > 64f && magnitude < 128f && num > 0f && num < DegWidth)
		{
			if (!Highlight)
			{
				GetComponent<Image>().DOColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.5f);
				GetComponent<RectTransform>().DOScale(new Vector3(1.1f, 1.1f, 1f), 0.5f).SetEase(Ease.OutElastic);
				Icon.DOColor(HighlightColor(MainColor), 0.5f);
				MainPanel.Description.text = Description;
				MainPanel.KillRingTween();
				MainPanel.ActiveRingTween = MainPanel.CenterRing.GetComponent<Image>().DOColor(MainColor + new Color(0.25f, 0.25f, 0.25f, 0f), 0.5f);
				Highlight = true;
				UISoundFX.PlaySFX("HighlightTick");
			}
		}
		else if (Highlight)
		{
			GetComponent<Image>().DOColor(MainColor, 0.5f);
			GetComponent<RectTransform>().DOScale((Order == SelectorController.ContextButtonGroup.Group) ? new Vector3(1.05f, 1.05f, 1f) : new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.OutBounce);
			Icon.DOColor((Order == SelectorController.ContextButtonGroup.Group) ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue) : new Color32(49, 49, 49, byte.MaxValue), 0.5f);
			if (MainPanel.Description.text == Description)
			{
				MainPanel.Description.text = "";
				MainPanel.KillRingTween();
				MainPanel.ActiveRingTween = MainPanel.CenterRing.GetComponent<Image>().DOColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.5f);
			}
			Highlight = false;
			MainPanel.HandleCounter(null, 0f);
		}
		if (Highlight)
		{
			MainPanel.HandleCounter(Counter, ActualPos * ((float)Math.PI / 180f));
			if (Input.GetMouseButtonUp(0) && OnClick != null)
			{
				UISoundFX.PlaySFX("ButtonClick");
				OnClick();
			}
		}
	}
}
