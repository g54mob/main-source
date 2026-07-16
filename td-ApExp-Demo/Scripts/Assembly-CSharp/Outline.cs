using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outline : MonoBehaviour
{
	public SpriteRenderer outlineSr;

	public Image outlineImage;

	public SpriteRenderer[] outlineSrArr;

	public Image[] outlineImageArr;

	private float fadeOutDuration = 0.25f;

	private bool fadeAlpha = true;

	private const string ThicknessProp = "_OutlineThickness";

	private const string ColorProp = "_OutlineColor";

	private Coroutine fadeRoutine;

	private Coroutine _stationCoroutine;

	public Color currentColor { get; private set; }

	protected void Awake()
	{
		currentColor = Color.white;
		if (outlineSr == null)
		{
			outlineSr = GetComponent<SpriteRenderer>();
		}
		if (outlineImage == null)
		{
			outlineImage = GetComponent<Image>();
		}
		if ((bool)outlineImage)
		{
			outlineImage.material = new Material(outlineImage.material);
		}
	}

	public void SetOutline(bool isActive, Color color)
	{
		if (isActive)
		{
			currentColor = color;
		}
		else
		{
			color = currentColor;
		}
		if (isActive)
		{
			if (fadeRoutine != null)
			{
				StopCoroutine(fadeRoutine);
			}
			SetColorAll(color);
			SetThicknessAll(1f);
			return;
		}
		SetColorAll(color);
		if (fadeRoutine != null)
		{
			StopCoroutine(fadeRoutine);
		}
		if (fadeOutDuration <= 0f)
		{
			SetThicknessAll(0f);
			if (fadeAlpha)
			{
				SetAlphaAll(0f);
			}
		}
		else
		{
			fadeRoutine = StartCoroutine(FadeOutRoutine());
		}
	}

	private IEnumerator FadeOutRoutine()
	{
		List<Material> mats = GetAllMaterials();
		int n = mats.Count;
		float[] startThickness = new float[n];
		float[] startAlpha = (fadeAlpha ? new float[n] : null);
		for (int i = 0; i < n; i++)
		{
			Material material = mats[i];
			startThickness[i] = (((bool)material && material.HasProperty("_OutlineThickness")) ? material.GetFloat("_OutlineThickness") : 1f);
			if (fadeAlpha)
			{
				if ((bool)material && material.HasProperty("_OutlineColor"))
				{
					startAlpha[i] = material.GetColor("_OutlineColor").a;
				}
				else
				{
					startAlpha[i] = 1f;
				}
			}
		}
		float t = 0f;
		while (t < fadeOutDuration)
		{
			t += Time.deltaTime;
			float t2 = Mathf.Clamp01(t / fadeOutDuration);
			for (int j = 0; j < n; j++)
			{
				Material material2 = mats[j];
				if ((bool)material2)
				{
					if (material2.HasProperty("_OutlineThickness"))
					{
						material2.SetFloat("_OutlineThickness", Mathf.LerpUnclamped(startThickness[j], 0f, t2));
					}
					if (fadeAlpha && material2.HasProperty("_OutlineColor"))
					{
						Color color = material2.GetColor("_OutlineColor");
						color.a = Mathf.LerpUnclamped(startAlpha[j], 0f, t2);
						material2.SetColor("_OutlineColor", color);
					}
				}
			}
			yield return null;
		}
		SetThicknessAll(0f);
		if (fadeAlpha)
		{
			SetAlphaAll(0f);
		}
		fadeRoutine = null;
	}

	private List<Material> GetAllMaterials()
	{
		List<Material> list = new List<Material>((outlineSr ? 1 : 0) + (outlineImage ? 1 : 0) + ((outlineSrArr != null) ? outlineSrArr.Length : 0) + ((outlineImageArr != null) ? outlineImageArr.Length : 0));
		if ((bool)outlineSr)
		{
			list.Add(outlineSr.material);
		}
		if ((bool)outlineImage)
		{
			list.Add(outlineImage.material);
		}
		if (outlineSrArr != null)
		{
			SpriteRenderer[] array = outlineSrArr;
			foreach (SpriteRenderer spriteRenderer in array)
			{
				if ((bool)spriteRenderer)
				{
					list.Add(spriteRenderer.material);
				}
			}
		}
		if (outlineImageArr != null)
		{
			Image[] array2 = outlineImageArr;
			foreach (Image image in array2)
			{
				if ((bool)image)
				{
					list.Add(image.material);
				}
			}
		}
		return list;
	}

	private void SetThicknessAll(float v)
	{
		foreach (Material allMaterial in GetAllMaterials())
		{
			if (allMaterial != null && allMaterial.HasProperty("_OutlineThickness"))
			{
				allMaterial.SetFloat("_OutlineThickness", v);
			}
		}
	}

	private void SetAlphaAll(float a)
	{
		foreach (Material allMaterial in GetAllMaterials())
		{
			if (allMaterial != null && allMaterial.HasProperty("_OutlineColor"))
			{
				Color color = allMaterial.GetColor("_OutlineColor");
				color.a = a;
				allMaterial.SetColor("_OutlineColor", color);
			}
		}
	}

	private void SetColorAll(Color c)
	{
		foreach (Material allMaterial in GetAllMaterials())
		{
			if (allMaterial != null && allMaterial.HasProperty("_OutlineColor"))
			{
				allMaterial.SetColor("_OutlineColor", c);
			}
		}
	}

	public void Animate(bool play)
	{
		if (_stationCoroutine != null)
		{
			StopCoroutine(_stationCoroutine);
			_stationCoroutine = null;
		}
		if (play)
		{
			_stationCoroutine = StartCoroutine(NewStationAnimation());
		}
	}

	private IEnumerator NewStationAnimation()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			SetOutline(isActive: true, Color.yellow);
			yield return new WaitForSeconds(0.5f);
			SetOutline(isActive: false, Color.yellow);
			yield return new WaitForSeconds(0.5f);
			SetOutline(isActive: true, Color.white);
			yield return new WaitForSeconds(0.5f);
			SetOutline(isActive: false, Color.white);
		}
	}
}
