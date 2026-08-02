using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class RadialColorPicker : MonoBehaviour
{
	[Serializable]
	public class ColorEvent : UnityEvent<Color>
	{
	}

	private const string RebuildFn = "EditorRebuild";

	private const string MenuRootName = "RadialColorMenu";

	[Tooltip("İç halkadaki saf ana renkler. Her birinin tonları otomatik üretilir.")]
	public Color[] mainColors = DefaultPalette();

	public float mainRadius = 155f;

	public float mainDiameter = 64f;

	public int shadeInnerCount = 4;

	public int shadeOuterCount = 5;

	public float shadeInnerRadius = 258f;

	public float shadeOuterRadius = 360f;

	public float shadeDiameter = 52f;

	[Tooltip("Aynı renk ailesi içindeki düğme aralığı = çap * bu. Büyük = grup geniş, kategoriler-arası boşluk azalır.")]
	public float shadeInnerSpacingFactor = 1.15f;

	public float shadeOuterSpacingFactor = 1.48f;

	public float openDuration = 0.45f;

	public float swatchStagger = 0.035f;

	public float spiralDegrees = 150f;

	public float hoverScale = 1.28f;

	public Color ringColor = new Color(1f, 1f, 1f, 0.95f);

	public ColorEvent onColorSelected = new ColorEvent();

	[Tooltip("Open/Close ile aktif edilip kapatılan obje. Boşsa otomatik 'RadialColorMenu' oluşturulur. Kendi UI objeni atayıp 'UI'ı Yeniden Kur'a basarsan menü onun içine kurulur (çocukları temizlenir).")]
	public GameObject menuRoot;

	[SerializeField]
	[HideInInspector]
	private List<GameObject> shadeGroups = new List<GameObject>();

	[SerializeField]
	[HideInInspector]
	private List<RadialColorSwatch> allSwatches = new List<RadialColorSwatch>();

	private Action<Color> pickedCallback;

	public bool IsOpen { get; private set; }

	private void Awake()
	{
		if (menuRoot != null)
		{
			menuRoot.SetActive(value: false);
		}
		IsOpen = false;
	}

	public void Open(Action<Color> onPicked = null)
	{
		pickedCallback = onPicked;
		IsOpen = true;
		if (menuRoot != null)
		{
			menuRoot.SetActive(value: true);
		}
		foreach (GameObject shadeGroup in shadeGroups)
		{
			if (shadeGroup != null)
			{
				shadeGroup.SetActive(value: true);
			}
		}
		CanvasGroup canvasGroup = ((menuRoot != null) ? menuRoot.GetComponent<CanvasGroup>() : null);
		if (canvasGroup != null)
		{
			canvasGroup.DOKill();
			canvasGroup.alpha = 1f;
		}
		for (int i = 0; i < allSwatches.Count; i++)
		{
			if (allSwatches[i] != null)
			{
				allSwatches[i].PlayOpen((float)allSwatches[i].ringIndex * swatchStagger);
			}
		}
		TrainGameManager.RequestInputLock("RadialColorPicker");
		TrainGameManager.RequestMouseLock("RadialColorPicker");
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Close()
	{
		bool isOpen = IsOpen;
		IsOpen = false;
		pickedCallback = null;
		if (menuRoot != null && menuRoot.activeSelf && isOpen)
		{
			float num = 0f;
			for (int i = 0; i < allSwatches.Count; i++)
			{
				RadialColorSwatch radialColorSwatch = allSwatches[i];
				if (!(radialColorSwatch == null))
				{
					float num2 = (float)radialColorSwatch.ringIndex * swatchStagger;
					radialColorSwatch.PlayClose(num2);
					num = Mathf.Max(num, num2);
				}
			}
			float num3 = num + openDuration * 0.7f + 0.02f;
			CanvasGroup cg = menuRoot.GetComponent<CanvasGroup>();
			if (cg != null)
			{
				cg.DOKill();
				cg.DOFade(0f, num3).SetUpdate(isIndependentUpdate: true);
			}
			DOVirtual.DelayedCall(num3, delegate
			{
				if (!IsOpen && menuRoot != null)
				{
					menuRoot.SetActive(value: false);
					if (cg != null)
					{
						cg.alpha = 1f;
					}
				}
			}).SetUpdate(isIndependentUpdate: true);
		}
		else if (menuRoot != null)
		{
			CanvasGroup component = menuRoot.GetComponent<CanvasGroup>();
			if (component != null)
			{
				component.alpha = 1f;
			}
			menuRoot.SetActive(value: false);
		}
		TrainGameManager.ReleaseInputLock("RadialColorPicker");
		TrainGameManager.ReleaseMouseLock("RadialColorPicker");
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void Toggle(Action<Color> onPicked = null)
	{
		if (IsOpen)
		{
			Close();
		}
		else
		{
			Open(onPicked);
		}
	}

	public void Select(Color c)
	{
		pickedCallback?.Invoke(c);
		onColorSelected?.Invoke(c);
		Close();
	}

	public static Color[] GenerateShades(Color baseColor, int count)
	{
		Color.RGBToHSV(baseColor, out var H, out var _, out var _);
		Color[] array = new Color[count];
		for (int i = 0; i < count; i++)
		{
			float num = ((count == 1) ? 0.5f : ((float)i / (float)(count - 1)));
			float value;
			float value2;
			if (num < 0.5f)
			{
				float t = num / 0.5f;
				value = 1f;
				value2 = Mathf.Lerp(0.4f, 1f, t);
			}
			else
			{
				float t2 = (num - 0.5f) / 0.5f;
				value = Mathf.Lerp(1f, 0.3f, t2);
				value2 = 1f;
			}
			array[i] = Color.HSVToRGB(H, Mathf.Clamp01(value), Mathf.Clamp01(value2));
			array[i].a = 1f;
		}
		return array;
	}

	public static Color[] DefaultPalette()
	{
		return new Color[6]
		{
			Hue(0f),
			Hue(0.083f),
			Hue(0.167f),
			Hue(0.333f),
			Hue(0.6f),
			Hue(0.8f)
		};
	}

	private static Color Hue(float h)
	{
		Color result = Color.HSVToRGB(Mathf.Repeat(h, 1f), 1f, 1f);
		result.a = 1f;
		return result;
	}

	public void EditorRebuild()
	{
	}
}
