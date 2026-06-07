using System.Collections;
using UnityEngine;

public class MaterialFader : MonoBehaviour
{
	[SerializeField]
	private float autoFadeInDuration = 1f;

	private Material _mat;

	private Color _baseColor;

	private Coroutine _active;

	private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

	private static readonly int Surface = Shader.PropertyToID("_Surface");

	private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");

	private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");

	private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");

	private void Awake()
	{
		_mat = GetComponent<Renderer>().material;
		_baseColor = (_mat.HasProperty(BaseColor) ? _mat.GetColor(BaseColor) : Color.white);
		SetBaseColorAlpha(0f);
		SetSurfaceTransparent();
	}

	private void Start()
	{
		Invoke("Start_", 0.5f);
	}

	private void Start_()
	{
		_active = StartCoroutine(FadeIn(autoFadeInDuration));
	}

	public IEnumerator FadeIn(float duration)
	{
		SetSurfaceTransparent();
		float startA = GetBaseColorAlpha();
		float endA = 1f;
		float t = 0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			float baseColorAlpha = Mathf.Lerp(startA, endA, Mathf.Clamp01(t / duration));
			SetBaseColorAlpha(baseColorAlpha);
			yield return null;
		}
		SetBaseColorAlpha(1f);
		SetSurfaceOpaque();
		_active = null;
	}

	public IEnumerator FadeOut(float duration)
	{
		SetSurfaceTransparent();
		float startA = GetBaseColorAlpha();
		float endA = 0f;
		float t = 0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			float baseColorAlpha = Mathf.Lerp(startA, endA, Mathf.Clamp01(t / duration));
			SetBaseColorAlpha(baseColorAlpha);
			yield return null;
		}
		SetBaseColorAlpha(0f);
		_active = null;
	}

	public void PlayFadeIn(float duration)
	{
		if (_active != null)
		{
			StopCoroutine(_active);
		}
		_active = StartCoroutine(FadeIn(duration));
	}

	public void PlayFadeOut(float duration)
	{
		if (_active != null)
		{
			StopCoroutine(_active);
		}
		_active = StartCoroutine(FadeOut(duration));
	}

	private float GetBaseColorAlpha()
	{
		_baseColor = _mat.GetColor(BaseColor);
		return _baseColor.a;
	}

	private void SetBaseColorAlpha(float a)
	{
		_baseColor = _mat.GetColor(BaseColor);
		_baseColor.a = a;
		_mat.SetColor(BaseColor, _baseColor);
	}

	private void SetSurfaceOpaque()
	{
		_mat.SetFloat(Surface, 0f);
		_mat.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
		_mat.EnableKeyword("_SURFACE_TYPE_OPAQUE");
		_mat.SetFloat(SrcBlend, 1f);
		_mat.SetFloat(DstBlend, 0f);
		_mat.SetFloat(ZWrite, 1f);
		_mat.renderQueue = 2000;
		_mat.SetOverrideTag("RenderType", "Opaque");
	}

	private void SetSurfaceTransparent()
	{
		_mat.SetFloat(Surface, 1f);
		_mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
		_mat.DisableKeyword("_SURFACE_TYPE_OPAQUE");
		_mat.SetFloat(SrcBlend, 5f);
		_mat.SetFloat(DstBlend, 10f);
		_mat.SetFloat(ZWrite, 0f);
		_mat.renderQueue = 3000;
		_mat.SetOverrideTag("RenderType", "Transparent");
	}
}
