using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipPanel : MonoBehaviour
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

	public Camera MainCamera;

	public static TooltipPanel Instance;

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
		ShowTooltip(panel, hoverOverObject, "", text);
	}

	public void ShowTooltip(GameObject panel, GameObject hoverOverObject, string title, string text)
	{
		_originator = panel;
		_dynamicInfo = null;
		Title.text = title;
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
		_originator = panel;
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
		float num = Camera.main.orthographicSize / 7f;
		base.transform.localScale = new Vector3(num, num, 1f);
		Vector3 position = _originator.transform.position;
		Vector3 vector = Camera.main.WorldToScreenPoint(position);
		RectTransform component = _originator.GetComponent<RectTransform>();
		RectTransform component2 = GetComponent<RectTransform>();
		if (vector.x < (float)(Screen.width / 2))
		{
			float x = component.anchoredPosition.x + component.rect.width * _originator.transform.localScale.x + 10f * _originator.transform.localScale.x;
			component2.anchoredPosition = new Vector2(x, component.anchoredPosition.y);
		}
		else
		{
			float x = component.anchoredPosition.x - component2.rect.width * _originator.transform.localScale.x - 20f * _originator.transform.localScale.x;
			component2.anchoredPosition = new Vector2(x, component.anchoredPosition.y);
		}
	}
}
