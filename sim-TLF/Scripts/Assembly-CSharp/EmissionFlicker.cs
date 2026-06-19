using System;
using System.Collections.Generic;
using UnityEngine;

public class EmissionFlicker : MonoBehaviour
{
	[Serializable]
	public class FlickerTarget
	{
		[Tooltip("Renderer об'єкта (MeshRenderer / SkinnedMeshRenderer)")]
		public Renderer renderer;

		[Tooltip("Індекси матеріалів, де є Emission. Залиште порожнім — обробить усі.")]
		public int[] materialIndices;

		[Tooltip("Базовий колір емісії (HDR!)")]
		[ColorUsage(true, true)]
		public Color baseColor = new Color(1f, 0.85f, 0.4f, 1f) * 2f;

		[HideInInspector]
		public float phaseOffset;

		[HideInInspector]
		public MaterialPropertyBlock mpb;
	}

	[Header("Targets")]
	[Tooltip("Список Renderer-ів та їх налаштувань")]
	public List<FlickerTarget> targets = new List<FlickerTarget>();

	[Header("Flicker Settings")]
	[Tooltip("Базова інтенсивність множника (HDR intensity)")]
	public float baseIntensity = 2.5f;

	[Tooltip("Амплітуда коливання ±")]
	public float amplitude = 1f;

	[Tooltip("Швидкість основного «дихання» (Гц)")]
	public float frequency = 0.4f;

	[Tooltip("Додаткова висока гармоніка для «живого» ефекту")]
	public float harmonicFrequency = 1.7f;

	[Tooltip("Сила вищої гармоніки (відносно amplitude)")]
	[Range(0f, 1f)]
	public float harmonicStrength = 0.25f;

	[Tooltip("Мінімальна інтенсивність (щоб лампа не гасла повністю)")]
	public float minIntensity = 0.3f;

	[Header("Randomization")]
	[Tooltip("Максимальний випадковий зсув фази між targets (секунди)")]
	public float maxPhaseOffset = 3f;

	[Tooltip("Рандомізувати при кожному старті")]
	public bool randomizeOnStart = true;

	private static readonly int EmissionColorID = Shader.PropertyToID("_EmissionColor");

	private void Start()
	{
		foreach (FlickerTarget target in targets)
		{
			if (!(target.renderer == null))
			{
				target.mpb = new MaterialPropertyBlock();
				target.phaseOffset = (randomizeOnStart ? UnityEngine.Random.Range(0f, maxPhaseOffset) : 0f);
			}
		}
	}

	private void Update()
	{
		float time = Time.time;
		foreach (FlickerTarget target in targets)
		{
			if (target.renderer == null)
			{
				continue;
			}
			float num = time + target.phaseOffset;
			float num2 = (Mathf.Sin(num * frequency * 2f * MathF.PI) + harmonicStrength * Mathf.Sin(num * harmonicFrequency * 2f * MathF.PI + 1.3f) + 1f + harmonicStrength) / (2f + 2f * harmonicStrength);
			float num3 = Mathf.Max(minIntensity, baseIntensity + amplitude * (num2 * 2f - 1f));
			Color value = target.baseColor * num3;
			target.renderer.GetPropertyBlock(target.mpb);
			if (target.materialIndices == null || target.materialIndices.Length == 0)
			{
				target.mpb.SetColor(EmissionColorID, value);
				target.renderer.SetPropertyBlock(target.mpb);
				continue;
			}
			int[] materialIndices = target.materialIndices;
			foreach (int materialIndex in materialIndices)
			{
				target.renderer.GetPropertyBlock(target.mpb, materialIndex);
				target.mpb.SetColor(EmissionColorID, value);
				target.renderer.SetPropertyBlock(target.mpb, materialIndex);
			}
		}
	}

	public void AddTarget(Renderer r, Color hdrColor, int[] matIndices = null)
	{
		FlickerTarget item = new FlickerTarget
		{
			renderer = r,
			baseColor = hdrColor,
			materialIndices = (matIndices ?? new int[0]),
			phaseOffset = UnityEngine.Random.Range(0f, maxPhaseOffset),
			mpb = new MaterialPropertyBlock()
		};
		targets.Add(item);
	}

	public void SetStatic(float intensity)
	{
		base.enabled = false;
		foreach (FlickerTarget target in targets)
		{
			if (!(target.renderer == null))
			{
				target.renderer.GetPropertyBlock(target.mpb);
				target.mpb.SetColor(EmissionColorID, target.baseColor * intensity);
				target.renderer.SetPropertyBlock(target.mpb);
			}
		}
	}
}
