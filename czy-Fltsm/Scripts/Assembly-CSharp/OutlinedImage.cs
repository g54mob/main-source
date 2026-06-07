using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OutlinedImage : MonoBehaviour
{
	private const string MATERIAL_PROPERTY_OUTLINE_COLOR = "_OutlineColor";

	private const string MATERIAL_PROPERTY_OUTLINE_SIZE = "_OutlineSize";

	[SerializeField]
	private RawImage _mainImage;

	[SerializeField]
	private RawImage _outlineImage;

	private Material _outlineMaterial;

	private Color _outlineColor;

	private float _outlineSize;

	private IEnumerator _blinkRoutine;

	public Material OutlineMaterial
	{
		get
		{
			if (_outlineMaterial == null)
			{
				_outlineMaterial = Object.Instantiate(_outlineImage.material);
				_outlineImage.material = _outlineMaterial;
			}
			return _outlineMaterial;
		}
	}

	private void Awake()
	{
		_outlineColor = OutlineMaterial.GetColor("_OutlineColor");
		_outlineSize = OutlineMaterial.GetFloat("_OutlineSize");
	}

	public void Initialize(Texture2D texture)
	{
		_mainImage.texture = texture;
		_outlineImage.texture = texture;
	}

	public void RestoreOutlineColor()
	{
		StopBlinkRoutine();
		SetOutlineColor(_outlineColor);
	}

	public void OverrideOutlineColor(Color color)
	{
		StopBlinkRoutine();
		SetOutlineColor(color);
	}

	public void Blink(Color color, float duration)
	{
		StopBlinkRoutine();
		_blinkRoutine = BlinkRoutine(color, duration);
		StartCoroutine(_blinkRoutine);
	}

	private IEnumerator BlinkRoutine(Color color, float duration)
	{
		float time = 0f;
		Color from = _outlineColor;
		Color to = color;
		while (true)
		{
			SetOutlineColor(Color.Lerp(from, to, time / duration));
			if (duration < time)
			{
				time = 0f;
				Color color2 = from;
				from = to;
				to = color2;
			}
			yield return null;
			time += Time.deltaTime;
		}
	}

	public void Glow(Color toColor, float toSize, float duration, int count = 1)
	{
		StartCoroutine(GlowRoutine(toColor, toSize, duration, count));
	}

	private IEnumerator GlowRoutine(Color toColor, float toSize, float duration, int count)
	{
		Color fromColor = toColor;
		toColor.a = 0f;
		for (int i = 0; i < count; i++)
		{
			float time = 0f;
			float num = 0f;
			while (num < 1f)
			{
				yield return null;
				time += Time.deltaTime;
				num = time / duration;
				SetOutlineColor(Color.Lerp(fromColor, toColor, num));
				SetOutlineSize(Mathf.Lerp(_outlineSize, toSize, num));
			}
		}
		yield return null;
		SetOutlineColor(fromColor);
		SetOutlineSize(_outlineSize);
	}

	private void StopBlinkRoutine()
	{
		if (_blinkRoutine != null)
		{
			StopCoroutine(_blinkRoutine);
			_blinkRoutine = null;
		}
	}

	private void SetOutlineColor(Color color)
	{
		OutlineMaterial.SetColor("_OutlineColor", color);
	}

	private void SetOutlineSize(float size)
	{
		OutlineMaterial.SetFloat("_OutlineSize", size);
	}
}
