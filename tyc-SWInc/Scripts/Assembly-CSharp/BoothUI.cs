using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoothUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	public Text Label;

	public Image Back;

	public RectTransform SelectMarker;

	public RawImage Icon;

	public Texture2D OkTex;

	public Texture2D CancelTex;

	public RectTransform Self;

	public Color ActiveColor;

	public Color InactiveColor;

	public Color TakenColor;

	[NonSerialized]
	private Color _backColor = Color.white;

	[NonSerialized]
	private bool _hovered;

	[NonSerialized]
	public ConferenceController.Booth MyBooth;

	[NonSerialized]
	private string _tip;

	public void OnClick()
	{
		GameSettings.Instance.ConferenceController.SetActiveBooth(MyBooth);
	}

	public void UpdateMe(ConferenceController con, float max)
	{
		SelectMarker.gameObject.SetActive(GameSettings.Instance.ConferenceController.ActiveBooth == MyBooth);
		if (SelectMarker.gameObject.activeSelf)
		{
			SelectMarker.anchoredPosition = new Vector2(0f, Mathf.PingPong(Time.realtimeSinceStartup, 0.5f) * 16f);
		}
		if (con.IsRunning)
		{
			if (MyBooth.Owner == null)
			{
				Icon.texture = CancelTex;
				Icon.color = new Color32(50, 50, 50, byte.MaxValue);
				Icon.uvRect = new Rect(0f, 0f, 1f, 1f);
				Self.sizeDelta = new Vector2(24f, 24f);
				Label.gameObject.SetActive(false);
				_backColor = TakenColor;
				_tip = null;
			}
			else
			{
				Icon.texture = LogoController.Instance.LogoTexture;
				Icon.uvRect = LogoController.Instance.GetLogoRect(MyBooth.Owner);
				Icon.color = Color.white;
				Label.gameObject.SetActive(true);
				Label.text = MyBooth.Counter.ToString();
				Self.sizeDelta = new Vector2(40f, 24f);
				_backColor = ((max == 0f) ? Color.white : Color.Lerp(Color.white, ActiveColor, ConferenceController.GetDisplay(MyBooth, con.DisplayType) / max));
				_tip = MyBooth.Owner.Name;
			}
		}
		else
		{
			_backColor = ((MyBooth.Owner == GameSettings.Instance.MyCompany) ? ActiveColor : ((MyBooth.Owner != null) ? TakenColor : InactiveColor));
			Self.sizeDelta = new Vector2(24f, 24f);
			Label.gameObject.SetActive(false);
			if (MyBooth.Owner != null)
			{
				Icon.texture = LogoController.Instance.LogoTexture;
				Icon.uvRect = LogoController.Instance.GetLogoRect(MyBooth.Owner);
				Icon.color = Color.white;
				_tip = MyBooth.Owner.Name;
			}
			else
			{
				_tip = "Vacant";
				Icon.texture = OkTex;
				Icon.color = new Color32(50, 50, 50, byte.MaxValue);
				Icon.uvRect = new Rect(0f, 0f, 1f, 1f);
			}
		}
		UpdateColor();
	}

	private void UpdateColor()
	{
		Back.color = (_hovered ? _backColor.MultColorPart(0.8f) : _backColor);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		OnClick();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_hovered = true;
		UpdateColor();
		if (_tip != null)
		{
			Tooltip.SetToolTip(_tip, null, Self);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_hovered = false;
		UpdateColor();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
