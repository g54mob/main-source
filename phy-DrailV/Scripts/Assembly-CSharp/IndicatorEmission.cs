using System;
using UnityEngine;

public class IndicatorEmission : Indicator
{
	private static readonly int emissionColorId = Shader.PropertyToID("_EmissionColor");

	private static readonly int tintColorId = Shader.PropertyToID("_TintColor");

	[Tooltip("If enabled, the lamp can only be fully on or fully off.")]
	[Header("Behaviour")]
	public bool binary = true;

	[Tooltip("The lamp will only be lit if the value if higher than this.")]
	public float valueThreshold = 0.5f;

	[Tooltip("How many seconds does it take for lamp to light. Default: 0.05")]
	public float lag = 0.05f;

	[Header("Emission")]
	public Color emissionColor = Color.white;

	public Light emissionLight;

	public float lightIntensity = 1f;

	[Tooltip("(Optional) The renderers to apply the emission color to. It'll use the first child renderer if unset.")]
	public Renderer[] renderers;

	[Header("Glare")]
	public Color glareColor = Color.white;

	public Renderer glareRenderer;

	private MaterialPropertyBlock tintPropertyBlock;

	private MaterialPropertyBlock emissionPropertyBlock;

	private float smoothVelo;

	private float smoothValue;

	private bool lampOn;

	private bool hasLight;

	private bool hasGlare;

	public float EmissionValue
	{
		get
		{
			if (lag != 0f)
			{
				return smoothValue;
			}
			if (!binary)
			{
				return GetNormalizedValue();
			}
			return (GetNormalizedValue() > valueThreshold) ? 1 : 0;
		}
	}

	public event Action<float> OnEmissionValueChange;

	private void Awake()
	{
		if (renderers == null || renderers.Length == 0)
		{
			renderers = new Renderer[1] { GetComponentInChildren<Renderer>() };
		}
		hasLight = emissionLight;
		hasGlare = glareRenderer;
		if (hasGlare)
		{
			tintPropertyBlock = new MaterialPropertyBlock();
		}
		emissionPropertyBlock = new MaterialPropertyBlock();
		SetColor(0f);
		SetLight(0f);
	}

	protected override void OnValueSet()
	{
		float num = GetNormalizedValue();
		if (binary)
		{
			num = ((value > valueThreshold) ? 1 : 0);
		}
		if (lag != 0f)
		{
			num = (smoothValue = Mathf.SmoothDamp(smoothValue, num, ref smoothVelo, lag));
		}
		this.OnEmissionValueChange?.Invoke(num);
		SetColor(num);
		SetLight(num);
	}

	private void SetColor(float value)
	{
		if (hasGlare)
		{
			tintPropertyBlock.SetColor(tintColorId, glareColor * value);
			glareRenderer.SetPropertyBlock(tintPropertyBlock);
		}
		emissionPropertyBlock.SetColor(emissionColorId, emissionColor * value);
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlock(emissionPropertyBlock);
		}
	}

	private void SetLight(float value)
	{
		bool flag = value > 0f;
		if (hasGlare && flag != lampOn)
		{
			glareRenderer.enabled = value > 0f;
		}
		if (hasLight)
		{
			emissionLight.intensity = lightIntensity * value;
		}
		lampOn = value > 0f;
	}
}
