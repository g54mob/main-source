using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
	private LightDimmerKnob extensionKnob;

	private List<LightDimmerKnob> sourceKnobs;

	private void Start()
	{
		sourceKnobs = new List<LightDimmerKnob>();
		LightcastLight[] componentsInChildren = GetComponentsInChildren<LightcastLight>(true);
		foreach (LightcastLight lightcastLight in componentsInChildren)
		{
			LightDimmerKnob item = LightDimmer.AttachKnob(lightcastLight.gameObject);
			if (lightcastLight.name.Contains("extension"))
			{
				extensionKnob = item;
			}
			else
			{
				sourceKnobs.Add(item);
			}
		}
	}

	private void Update()
	{
		float num = 0f;
		for (int i = 0; i < sourceKnobs.Count; i++)
		{
			LightDimmerKnob lightDimmerKnob = sourceKnobs[i];
			lightDimmerKnob.illum = 0.8f / (float)(sourceKnobs.Count - 1) * GetFlicker((float)i * 10f, Util.LerpScale(Mathf.Cos(Clock.play.time * Util.LerpScale(i, 0f, sourceKnobs.Count - 1, 1f, 2.3f) + (float)i * 1.5f), -1f, 1f, 0.5f, 1f));
			num += lightDimmerKnob.illum;
		}
		extensionKnob.illum = Util.LerpScale(num, 0f, 1f, 0.75f, 1f);
	}

	private float GetFlicker(float offset, float steadyT)
	{
		float a = Mathf.Lerp(0f, 0.8f, steadyT);
		float b = Mathf.Lerp(0.5f, 1f, steadyT);
		float num = Clock.play.time + offset;
		float t = Mathf.Lerp((Mathf.Cos(30f * num) > 0f) ? 1 : 0, Mathf.PerlinNoise(5f * num, 0f), 1f);
		return Mathf.Lerp(a, b, t);
	}
}
