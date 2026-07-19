using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Colorpicker : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[Header("Components")]
	public RectTransform valuePanel;

	public RectTransform valuePicker;

	public RectTransform huePanel;

	public RectTransform huePicker;

	private RectTransform rectTransform;

	private Texture2D valueTexture;

	private Color color = Color.red;

	private float colorHue;

	private float colorSaturation;

	private float colorBrightness;

	private bool dragging;

	private bool dragValue;

	[Header("Events")]
	[SerializeField]
	private UnityColorEvent colorEvent;

	[SerializeField]
	private UnityColorEvent colorSet;

	public Color GetColor()
	{
		return color;
	}

	public string GetHex()
	{
		return ColorUtility.ToHtmlStringRGB(color);
	}

	public void SetColor(string _hex)
	{
		ColorUtility.TryParseHtmlString(_hex, out var color);
		SetColor(color);
	}

	public void SetColor(Color _color)
	{
		color = _color;
		Color.RGBToHSV(color, out colorHue, out colorSaturation, out colorBrightness);
		GenerateValueMap();
		UpdateSliders();
		ColorChanged();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		DragStart();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		dragging = false;
		colorSet.Invoke(color);
	}

	private void DragStart()
	{
		Vector2 vector = rectTransform.InverseTransformPoint(Input.mousePosition);
		dragValue = (vector - rectTransform.rect.position).x < rectTransform.rect.width - huePanel.rect.width;
		dragging = true;
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		SetColor(color);
		GenerateHueMap();
	}

	private void Update()
	{
		if (dragging)
		{
			Vector2 mouse = rectTransform.InverseTransformPoint(Input.mousePosition);
			mouse -= rectTransform.rect.position;
			mouse.y = rectTransform.rect.height - mouse.y;
			if (dragValue)
			{
				SlideValue(mouse);
			}
			else
			{
				SlideHue(mouse);
			}
		}
	}

	private void SlideValue(Vector2 mouse)
	{
		float num = Mathf.Clamp(mouse.x, 0f, valuePanel.rect.width);
		float num2 = Mathf.Clamp(mouse.y, 0f, valuePanel.rect.height);
		float num3 = num * 100f / valuePanel.rect.width;
		float num4 = num2 * 100f / valuePanel.rect.height;
		colorSaturation = num3 / 100f;
		colorBrightness = 1f - num4 / 100f;
		UpdateSliders();
		ColorChanged();
	}

	private void SlideHue(Vector2 mouse)
	{
		float num = Mathf.Clamp(mouse.y, 0f, huePanel.rect.height);
		colorHue = num * 100f / huePanel.rect.height / 100f;
		GenerateValueMap();
		UpdateSliders();
		ColorChanged();
	}

	private void UpdateSliders()
	{
		float num = colorHue * 100f * huePanel.rect.height / 100f;
		num -= huePicker.rect.height / 2f;
		huePicker.anchoredPosition = new Vector2(0f, 0f - num);
		float num2 = colorSaturation * 100f;
		float num3 = colorBrightness * 100f;
		float num4 = num2 * valuePanel.rect.width / 100f;
		float num5 = valuePanel.rect.height - num3 * valuePanel.rect.height / 100f;
		valuePicker.anchoredPosition = new Vector2(num4 - valuePicker.rect.width / 2f, 0f - num5 + valuePicker.rect.height / 2f);
		color = Color.HSVToRGB(colorHue, colorSaturation, colorBrightness);
	}

	private void ColorChanged()
	{
		colorEvent.Invoke(color);
	}

	private void GenerateHueMap()
	{
		int num = 256;
		Texture2D texture2D = new Texture2D(1, num);
		texture2D.filterMode = FilterMode.Point;
		texture2D.hideFlags = HideFlags.DontSave;
		Color32[] array = new Color32[num];
		for (int i = 0; i < num; i++)
		{
			float num2 = i * 100 / num;
			array[i] = Color.HSVToRGB(1f - num2 / 100f, 1f, 1f);
		}
		texture2D.SetPixels32(array);
		texture2D.Apply();
		huePanel.GetComponent<RawImage>().texture = texture2D;
	}

	private void GenerateValueMap()
	{
		int num = 100;
		Texture2D texture2D = new Texture2D(num, num);
		texture2D.wrapMode = TextureWrapMode.Clamp;
		texture2D.filterMode = FilterMode.Point;
		texture2D.hideFlags = HideFlags.DontSave;
		for (int i = 0; i < num; i++)
		{
			Color32[] array = new Color32[num];
			for (int j = 0; j < num; j++)
			{
				array[j] = Color.HSVToRGB(colorHue, (float)i / 100f, (float)j / 100f);
			}
			texture2D.SetPixels32(i, 0, 1, num, array);
		}
		texture2D.Apply();
		valueTexture = texture2D;
		valuePanel.GetComponent<RawImage>().texture = valueTexture;
	}
}
