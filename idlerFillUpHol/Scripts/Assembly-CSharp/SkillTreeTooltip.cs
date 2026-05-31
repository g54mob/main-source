using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTreeTooltip : MonoBehaviour
{
	public class TooltipInfo
	{
		public string Title;

		public string Level;

		public string Description;

		public string Cost;

		public TooltipInfo Update(string title, string level, string description, string cost)
		{
			Title = title;
			Level = level;
			Description = description;
			Cost = cost;
			return this;
		}
	}

	public static SkillTreeTooltip Instance;

	public TMP_Text Title;

	public TMP_Text Level;

	public TMP_Text Description;

	public TMP_Text Cost;

	private GameObject _originator;

	private Func<TooltipInfo, TooltipInfo> _dynamicInfo;

	private TooltipInfo _infoInstance = new TooltipInfo();

	private float _updateTimer;

	private Tween _shakeAnimation;

	private static DateTime _lastShake = DateTime.Now;

	private const float SHAKE_DELAY = 200f;

	public GameObject SkillTreeInnerPanel;

	public RectTransform MaskPanel;

	private void Start()
	{
		Instance = this;
		HideTooltip();
	}

	private void Update()
	{
		SetPosition();
		if (_dynamicInfo != null)
		{
			_updateTimer += Time.deltaTime;
			if (_updateTimer >= 0.5f)
			{
				_updateTimer = 0f;
				SetDynamicText();
			}
		}
	}

	public void HideTooltip()
	{
		_lastShake = DateTime.Now;
		base.gameObject.SetActive(value: false);
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void ShowTooltip(GameObject panel, GameObject hoverOverObject, string text)
	{
		_originator = panel;
		_dynamicInfo = null;
		Title.text = "";
		Level.text = "";
		Description.text = text;
		Cost.text = "";
		SetPosition();
		base.gameObject.SetActive(value: true);
		if ((_shakeAnimation == null || !_shakeAnimation.active) && (DateTime.Now - _lastShake).TotalMilliseconds >= 200.0)
		{
			_shakeAnimation = GetComponent<RectTransform>().DOShakeRotation(0.1f, new Vector3(0f, 0f, 5f)).SetLoops(2, LoopType.Restart);
		}
	}

	public void ShowDynamicTooltip(GameObject panel, GameObject hoverOverObject, Func<TooltipInfo, TooltipInfo> tooltipInfo)
	{
		_originator = hoverOverObject;
		_dynamicInfo = tooltipInfo;
		SetPosition();
		SetDynamicText();
		base.gameObject.SetActive(value: true);
		if ((_shakeAnimation == null || !_shakeAnimation.active) && (DateTime.Now - _lastShake).TotalMilliseconds >= 200.0)
		{
			_shakeAnimation = GetComponent<RectTransform>().DOShakeRotation(0.1f, new Vector3(0f, 0f, 5f)).SetLoops(2, LoopType.Restart);
		}
	}

	private void SetDynamicText()
	{
		_dynamicInfo(_infoInstance);
		Title.text = _infoInstance.Title;
		Level.text = _infoInstance.Level;
		Description.text = _infoInstance.Description;
		Cost.text = _infoInstance.Cost;
	}

	private void SetPosition()
	{
		float x = 0f;
		float y = 0f;
		RectTransform component = _originator.GetComponent<RectTransform>();
		RectTransform component2 = GetComponent<RectTransform>();
		float x2 = SkillTreeInnerPanel.GetComponent<RectTransform>().localScale.x;
		float y2 = SkillTreeInnerPanel.GetComponent<RectTransform>().localScale.y;
		float x3 = SkillTreeInnerPanel.GetComponent<RectTransform>().anchoredPosition.x;
		float y3 = SkillTreeInnerPanel.GetComponent<RectTransform>().anchoredPosition.y;
		float num = component.anchoredPosition.x + x3;
		float num2 = component.anchoredPosition.y + y3;
		Vector3 vector = Camera.main.WorldToScreenPoint(_originator.transform.position);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.transform.parent.GetComponent<RectTransform>(), vector, Camera.main, out var localPoint);
		num = localPoint.x;
		num2 = localPoint.y;
		if (num >= 0f && num2 >= 0f)
		{
			x = num - component.rect.width * x2 - component2.rect.width / 2f;
			y = num2 - component.rect.height * y2 - component2.rect.height / 2f;
		}
		else if (num < 0f && num2 >= 0f)
		{
			x = num + component.rect.width * x2 + component2.rect.width / 2f;
			y = num2 - component.rect.height * y2 - component2.rect.height / 2f;
		}
		else if (num >= 0f && num2 < 0f)
		{
			x = num - component.rect.width * x2 - component2.rect.width / 2f;
			y = num2 + component.rect.height * y2 + component2.rect.height / 2f;
		}
		else if (num < 0f && num2 < 0f)
		{
			x = num + component.rect.width * x2 + component2.rect.width / 2f;
			y = num2 + component.rect.height * y2 + component2.rect.height / 2f;
		}
		component2.anchoredPosition = new Vector2(x, y);
		EnsureTooltipIsVisible();
	}

	private void EnsureTooltipIsVisible()
	{
		RectTransform component = GetComponent<RectTransform>();
		Vector2 size = MaskPanel.rect.size;
		Vector2 anchoredPosition = MaskPanel.anchoredPosition;
		Vector2 size2 = component.rect.size;
		Vector2 anchoredPosition2 = component.anchoredPosition;
		float num = anchoredPosition.x - size.x * 0.5f;
		float num2 = anchoredPosition.x + size.x * 0.5f;
		float num3 = anchoredPosition.y - size.y * 0.5f;
		float num4 = anchoredPosition.y + size.y * 0.5f;
		float num5 = anchoredPosition2.x - size2.x * 0.5f;
		float num6 = anchoredPosition2.x + size2.x * 0.5f;
		float num7 = anchoredPosition2.y - size2.y * 0.5f;
		float num8 = anchoredPosition2.y + size2.y * 0.5f;
		Vector2 zero = Vector2.zero;
		if (num5 < num)
		{
			zero.x += num - num5;
		}
		if (num6 > num2)
		{
			zero.x -= num6 - num2;
		}
		if (num7 < num3)
		{
			zero.y += num3 - num7;
		}
		if (num8 > num4)
		{
			zero.y -= num8 - num4;
		}
		component.anchoredPosition += zero;
	}
}
