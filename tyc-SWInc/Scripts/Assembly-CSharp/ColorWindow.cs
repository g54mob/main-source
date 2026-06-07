using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ColorWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Slider DarknessSlider;

	public RectTransform ColorPoint;

	public RectTransform ColorMap;

	public Image MainColor;

	public Image ColorMapImg;

	public Image SliderBack;

	public Color[] Colors;

	public bool[] Changed;

	public GameObject ButtonPrefab;

	public GameObject TogglePrefab;

	public GameObject ColorButtonPanel;

	public GameObject TabButtonPanel;

	public InputField HexText;

	public RectTransform MainPanel;

	public RectTransform ApplyButton;

	public int ActiveTab;

	[NonSerialized]
	private Action ExtraClose;

	[NonSerialized]
	private Action OnApply;

	private bool Initializing = true;

	public static bool Open;

	public Material SBMat;

	private Material _generatedMat;

	public Sprite Brightness;

	public Sprite Hue;

	public Toggle HSMode;

	public bool ContinualUpdates = true;

	private Action<Color>[] ColorActions;

	private bool _hexChange;

	public void UpdateHSMode()
	{
		Options.SetAndSave("ColorBrightnessSlider", HSMode.isOn);
		if (_generatedMat != null)
		{
			UnityEngine.Object.Destroy(_generatedMat);
			_generatedMat = null;
		}
		if (HSMode.isOn)
		{
			ColorMapImg.material = null;
		}
		else
		{
			_generatedMat = new Material(SBMat);
			ColorMapImg.material = _generatedMat;
		}
		SliderBack.sprite = (HSMode.isOn ? Brightness : Hue);
		if (!HSMode.isOn)
		{
			SliderBack.color = Color.white;
		}
		SetColor(MainColor.color);
	}

	private static float GetOrder(Color c)
	{
		Vector3 vector = Utilities.RGBToHSV(c);
		float num = vector.x / 360f;
		return (1f - vector.z + 1f) * 100f + (num + 1f) * 10f + vector.y;
	}

	public void Init(IList<string> tabs, IList<Action<Color>> actions, IList<Color> colors, HashSet<Color> defaults = null, Action extraClose = null, Action onApply = null)
	{
		Initializing = true;
		HSMode.isOn = Options.ColorBrightnessSlider;
		OnApply = onApply;
		ExtraClose = extraClose;
		ColorActions = actions.Take(tabs.Count).ToArray();
		Changed = new bool[tabs.Count];
		Colors = colors.Take(tabs.Count).ToArray();
		int l = tabs.Count;
		Color[] c = colors.ToArray();
		Window.OnClose = delegate
		{
			if (ContinualUpdates)
			{
				for (int i = 0; i < l; i++)
				{
					if (Changed[i])
					{
						ColorActions[i](c[i]);
					}
				}
			}
			Open = false;
			Action extraClose2 = ExtraClose;
			if (extraClose2 != null)
			{
				extraClose2();
			}
		};
		SetColor(Colors[ActiveTab]);
		Transform transform = ColorButtonPanel.transform;
		int childCount = transform.childCount;
		for (int num = 0; num < childCount; num++)
		{
			UnityEngine.Object.Destroy(transform.GetChild(num).gameObject);
		}
		RectTransform component = Window.GetComponent<RectTransform>();
		if (defaults != null && defaults.Count > 0)
		{
			foreach (Color item in defaults.OrderBy(GetOrder))
			{
				Color col = item;
				GameObject obj = UnityEngine.Object.Instantiate(ButtonPrefab);
				obj.transform.SetParent(transform, false);
				obj.GetComponent<Image>().color = col;
				obj.GetComponent<Button>().onClick.AddListener(delegate
				{
					SetColor(col);
				});
			}
			component.sizeDelta = new Vector2(312f, component.sizeDelta.y);
		}
		else
		{
			ColorButtonPanel.SetActive(false);
			component.sizeDelta = new Vector2(272f, component.sizeDelta.y);
		}
		if (tabs.Count > 1)
		{
			for (int num2 = 0; num2 < tabs.Count; num2++)
			{
				int k = num2;
				GameObject obj2 = UnityEngine.Object.Instantiate(TogglePrefab);
				obj2.transform.SetParent(TabButtonPanel.transform, false);
				obj2.GetComponentInChildren<Text>().text = tabs[num2];
				Toggle component2 = obj2.GetComponent<Toggle>();
				component2.isOn = num2 == 0;
				component2.onValueChanged.AddListener(delegate
				{
					ChangeTab(k);
				});
				component2.group = TabButtonPanel.GetComponent<ToggleGroup>();
			}
			component.sizeDelta = new Vector2(component.sizeDelta.x, 471f);
		}
		else
		{
			TabButtonPanel.SetActive(false);
			component.sizeDelta = new Vector2(component.sizeDelta.x, 433f);
			MainPanel.offsetMax = new Vector2(-4f, -4f);
			MainPanel.offsetMin = new Vector2(4f, 4f);
		}
		Open = true;
		UpdateHSMode();
		Initializing = false;
	}

	private void OnDestroy()
	{
		if (_generatedMat != null)
		{
			UnityEngine.Object.Destroy(_generatedMat);
			_generatedMat = null;
		}
	}

	public void ChangeTab(int newTab)
	{
		ActiveTab = newTab;
		Initializing = true;
		SetColor(Colors[ActiveTab]);
		Initializing = false;
	}

	public void SetHex()
	{
		if (!_hexChange)
		{
			_hexChange = true;
			HexText.text = ColorUtility.ToHtmlStringRGB(MainColor.color);
			_hexChange = false;
		}
	}

	public void HexUpdate()
	{
		if (!Initializing && !_hexChange)
		{
			_hexChange = true;
			Color color;
			if (ColorUtility.TryParseHtmlString("#" + HexText.text, out color))
			{
				SetColor(color);
			}
			_hexChange = false;
		}
	}

	public void SetColorPassive(Color color)
	{
		Initializing = true;
		SetColor(color);
		Initializing = false;
	}

	private void SetColor(Color color)
	{
		Vector3 vector = Utilities.RGBToHSV(color);
		if (HSMode.isOn)
		{
			DarknessSlider.value = 1f - vector.z;
			ColorPoint.anchoredPosition = new Vector3((1f - vector.y) * 256f, float.IsNaN(vector.x) ? 0f : ((0f - vector.x) * 256f));
		}
		else
		{
			DarknessSlider.value = (float.IsNaN(vector.x) ? 0f : vector.x);
			ColorPoint.anchoredPosition = new Vector3(vector.z * 256f, (0f - vector.y) * 256f);
		}
		UpdateColor();
	}

	public void ColorMapClick()
	{
		Vector2 uIScreenPosition = ColorMap.GetUIScreenPosition();
		Vector2 vector = new Vector2(Input.mousePosition.x / Options.UISize - uIScreenPosition.x / Options.UISize + 128f, Input.mousePosition.y / Options.UISize - uIScreenPosition.y / Options.UISize - 128f);
		vector = new Vector2(Mathf.Clamp(vector.x, 0f, 256f), Mathf.Clamp(vector.y, -256f, 0f));
		ColorPoint.anchoredPosition = vector;
		UpdateColor();
	}

	public void UpdateColor()
	{
		Vector3 vector = (HSMode.isOn ? Utilities.HSVToRGB((0f - ColorPoint.anchoredPosition.y) / 256f * 360f, 1f - ColorPoint.anchoredPosition.x / 256f, 1f - DarknessSlider.value) : Utilities.HSVToRGB(DarknessSlider.value * 360f, (0f - ColorPoint.anchoredPosition.y) / 256f, ColorPoint.anchoredPosition.x / 256f));
		MainColor.color = new Color(vector.x, vector.y, vector.z);
		Vector3 vector2 = (HSMode.isOn ? Utilities.HSVToRGB((0f - ColorPoint.anchoredPosition.y) / 256f * 360f, 1f - ColorPoint.anchoredPosition.x / 256f, 1f) : Utilities.HSVToRGB(DarknessSlider.value * 360f, 1f, 1f));
		Color color = new Color(vector2.x, vector2.y, vector2.z, 1f);
		SetHex();
		if (HSMode.isOn)
		{
			ColorMapImg.color = new Color(1f - DarknessSlider.value, 1f - DarknessSlider.value, 1f - DarknessSlider.value, 1f);
			SliderBack.color = color;
		}
		else
		{
			ColorMapImg.material.color = color;
		}
		if (!Initializing)
		{
			Changed[ActiveTab] = true;
			Colors[ActiveTab] = MainColor.color;
			if (ContinualUpdates)
			{
				ColorActions[ActiveTab](Colors[ActiveTab]);
			}
		}
	}

	public void CloseNoEffect()
	{
		Open = false;
		Window.OnClose = null;
		Window.Close();
	}

	public void Apply()
	{
		Open = false;
		Window.OnClose = null;
		for (int i = 0; i < Colors.Length; i++)
		{
			if (Changed[i])
			{
				ColorActions[i](Colors[i]);
			}
		}
		Action extraClose = ExtraClose;
		if (extraClose != null)
		{
			extraClose();
		}
		Action onApply = OnApply;
		if (onApply != null)
		{
			onApply();
		}
		Window.Close();
	}
}
