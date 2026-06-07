using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComboboxPanel : MonoBehaviour
{
	public static ComboboxPanel Instance;

	public Button ButtonPrefab;

	public Scrollbar Scroll;

	public RectTransform Content;

	public RectTransform SelfRect;

	public Font ActualFont;

	public int FontSize;

	private int _offset;

	private int _shown = 1;

	private List<Button> _buttons = new List<Button>();

	private string[] _labels;

	private string[] _tooltips;

	private GUICombobox _caller;

	private bool _justOpened;

	public static GUICombobox OpenCombo
	{
		get
		{
			if (!(Instance == null) && Instance.gameObject.activeSelf)
			{
				return Instance._caller;
			}
			return null;
		}
	}

	public int Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
			UpdateContent();
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void Close()
	{
		_caller = null;
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (!_justOpened)
		{
			if (Input.GetMouseButtonUp(0) && !RectTransformUtility.RectangleContainsScreenPoint(SelfRect, Input.mousePosition, UICamSize.GetUICam()) && !RectTransformUtility.RectangleContainsScreenPoint(Scroll.GetComponent<RectTransform>(), Input.mousePosition, UICamSize.GetUICam()))
			{
				Close();
			}
		}
		else
		{
			_justOpened = false;
		}
	}

	public void Show(GUICombobox caller)
	{
		if (caller == _caller)
		{
			Close();
		}
		else
		{
			if (caller.Items.Count <= 0)
			{
				return;
			}
			_justOpened = true;
			_caller = caller;
			_shown = Mathf.Min(caller.Items.Count, caller.MaxItems);
			if (_shown == caller.Items.Count)
			{
				Scroll.gameObject.SetActive(false);
			}
			else
			{
				Scroll.gameObject.SetActive(true);
			}
			int i;
			for (i = 0; i < _buttons.Count; i++)
			{
				_buttons[i].gameObject.SetActive(i < _shown);
			}
			for (; i < _shown; i++)
			{
				Button button = Object.Instantiate(ButtonPrefab);
				button.transform.SetParent(Content, false);
				int i2 = i;
				button.onClick.AddListener(delegate
				{
					Click(i2);
				});
				_buttons.Add(button);
			}
			_labels = new string[caller.Items.Count];
			_tooltips = new string[caller.Items.Count];
			for (int num = 0; num < caller.Items.Count; num++)
			{
				string[] labelFromObject = caller.GetLabelFromObject(caller.Items[num], num);
				_labels[num] = labelFromObject[0];
				_tooltips[num] = ((labelFromObject.Length > 1) ? labelFromObject[1] : "");
			}
			Scroll.numberOfSteps = Mathf.Max(0, caller.Items.Count - _shown + 1);
			Scroll.value = 0f;
			float num2 = 1f;
			for (int num3 = 0; num3 < _labels.Length; num3++)
			{
				string text = _labels[num3];
				float num4 = 0f;
				for (int num5 = 0; num5 < text.Length; num5++)
				{
					CharacterInfo info;
					if (ActualFont.GetCharacterInfo(text[num5], out info, FontSize))
					{
						num4 += (float)info.advance;
					}
				}
				num2 = Mathf.Max(num2, num4);
			}
			Vector2 uIScreenPosition = caller.transform.GetUIScreenPosition();
			Offset = 0;
			SelfRect.sizeDelta = new Vector2(Mathf.Max(num2 + 16f, caller.rectTransform.rect.width), SelfRect.sizeDelta.y);
			float y = Mathf.Clamp((uIScreenPosition.y - (float)Screen.height) / Options.UISize - caller.rectTransform.rect.height * caller.rectTransform.pivot.y, (float)(-Screen.height) / Options.UISize + (float)(_shown * 28), 0f);
			float x = Mathf.Clamp(uIScreenPosition.x / Options.UISize - caller.rectTransform.rect.width * caller.rectTransform.pivot.x, 0f, (float)Screen.width / Options.UISize - SelfRect.sizeDelta.x - (float)((_shown < _labels.Length) ? 20 : 0));
			SelfRect.anchoredPosition = new Vector2(x, y);
			base.gameObject.SetActive(true);
		}
	}

	private void Click(int i)
	{
		_caller.UpdateSelection(i + Offset);
		Close();
	}

	private void UpdateContent()
	{
		for (int i = 0; i < _shown && i < _buttons.Count; i++)
		{
			Button button = _buttons[i];
			int num = i + Offset;
			if (num >= 0 && num < _labels.Length)
			{
				button.GetComponentInChildren<Text>().text = _labels[num];
				button.GetComponentInChildren<GUIToolTipper>().TooltipDescription = _tooltips[num];
			}
			else
			{
				button.GetComponentInChildren<Text>().text = "";
				button.GetComponentInChildren<GUIToolTipper>().TooltipDescription = "";
			}
		}
	}

	public void ScrollChanged()
	{
		Offset = Mathf.FloorToInt(Scroll.value * (float)Mathf.Max(0, _caller.Items.Count - _shown));
	}

	public void OnScroll(BaseEventData eData)
	{
		PointerEventData pointerEventData = (PointerEventData)eData;
		Scroll.value -= pointerEventData.scrollDelta.y / (float)Mathf.Max(1, _caller.Items.Count - _shown);
	}
}
