using System.Collections.Generic;
using UnityEngine;

public class BarkParticlePulse : MonoBehaviour
{
	private float minAlpha;

	private float maxAlpha = 0.5f;

	private float pulseMaxTime = 0.025f;

	private float pulseHoldMaxTime = 0.1f;

	private float pulseMinTime = 0.25f;

	private float pulseHoldMinTime = 0.25f;

	private List<Renderer> renderers = new List<Renderer>();

	private int stage;

	private float stageTime;

	private string colorName = "_TintColor";

	private void Awake()
	{
		SetMaterialAlphas(minAlpha);
		renderers.Clear();
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		foreach (Renderer item in componentsInChildren)
		{
			renderers.Add(item);
		}
	}

	private void Update()
	{
		Pulse();
	}

	private void Pulse()
	{
		float num = 0f;
		switch (stage)
		{
		case 0:
			num = pulseMaxTime;
			SetMaterialAlphas(Mathf.Min(maxAlpha, maxAlpha * (stageTime / num)));
			break;
		case 1:
			num = pulseHoldMaxTime;
			break;
		case 2:
			num = pulseMinTime;
			SetMaterialAlphas(Mathf.Max(minAlpha, maxAlpha * ((pulseMinTime - stageTime) / num)));
			break;
		case 3:
			num = pulseHoldMinTime;
			break;
		}
		if (stageTime >= num)
		{
			stage++;
			if (stage >= 4)
			{
				stage = 0;
			}
			stageTime = 0f;
		}
		else
		{
			stageTime += Time.deltaTime;
		}
	}

	private void SetMaterialAlphas(float alpha)
	{
		for (int i = 0; i < renderers.Count; i++)
		{
			Color color = renderers[i].material.GetColor(colorName);
			renderers[i].material.SetColor(colorName, new Color(color.r, color.g, color.b, alpha));
		}
	}
}
