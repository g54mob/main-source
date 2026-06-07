using System;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
	[Serializable]
	public class StandardLight
	{
		public Light light;

		public float baseIntensity;

		public StandardLight(Light light_)
		{
			light = light_;
			baseIntensity = light.intensity;
		}
	}

	[SerializeField]
	private StandardLight standardLight;

	[SerializeField]
	private LightcastLight lightcastLight;

	[SerializeField]
	private List<int> lightcasterDynamicLayerIndexes;

	[SerializeField]
	private List<LightDimmerKnob> knobs = new List<LightDimmerKnob>();

	[SerializeField]
	private List<LightDimmerKnob> descendentKnobs = new List<LightDimmerKnob>();

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		PublishIllum(0f);
	}

	private void LateUpdate()
	{
		float num = 1f;
		foreach (LightDimmerKnob knob in knobs)
		{
			num *= knob.illum;
		}
		PublishIllum(num);
	}

	private void PublishIllum(float illum)
	{
		if (standardLight != null && standardLight.light != null)
		{
			standardLight.light.intensity = illum * standardLight.baseIntensity;
			standardLight.light.enabled = standardLight.light.intensity > 0.01f;
		}
		if (lightcastLight != null)
		{
			lightcastLight.illum = illum;
		}
		if (lightcasterDynamicLayerIndexes != null)
		{
			foreach (int lightcasterDynamicLayerIndex in lightcasterDynamicLayerIndexes)
			{
				Lightcaster.instance.SetDynamicLayerAlpha(lightcasterDynamicLayerIndex, illum);
			}
		}
		foreach (LightDimmerKnob descendentKnob in descendentKnobs)
		{
			descendentKnob.illum = illum;
		}
	}

	private LightDimmerKnob AllocKnob(GameObject holderGo)
	{
		LightDimmerKnob lightDimmerKnob = holderGo.AddComponent<LightDimmerKnob>();
		knobs.Add(lightDimmerKnob);
		return lightDimmerKnob;
	}

	private static LightDimmer AttachDimmer(GameObject go)
	{
		LightDimmer component = go.GetComponent<LightDimmer>();
		if (component != null)
		{
			return component;
		}
		LightcastLight component2 = go.GetComponent<LightcastLight>();
		if (component2 != null)
		{
			LightDimmer lightDimmer = go.AddComponent<LightDimmer>();
			lightDimmer.lightcastLight = component2;
			AddHierarchyKnobs(lightDimmer);
			return lightDimmer;
		}
		Light component3 = go.GetComponent<Light>();
		if (component3 != null)
		{
			LightDimmer lightDimmer2 = go.AddComponent<LightDimmer>();
			lightDimmer2.standardLight = new StandardLight(component3);
			AddHierarchyKnobs(lightDimmer2);
			return lightDimmer2;
		}
		WindowLightDimmer component4 = go.GetComponent<WindowLightDimmer>();
		if (component4 != null)
		{
			LightDimmer lightDimmer3 = go.AddComponent<LightDimmer>();
			AddHierarchyKnobs(lightDimmer3);
			return lightDimmer3;
		}
		return null;
	}

	public static LightDimmerKnob AttachKnob(GameObject targetGo)
	{
		LightDimmer lightDimmer = targetGo.GetComponent<LightDimmer>();
		if (lightDimmer == null)
		{
			foreach (GameObject item in targetGo.AllDescendents())
			{
				lightDimmer = AttachDimmer(item);
				if (lightDimmer != null)
				{
					break;
				}
			}
		}
		if (lightDimmer != null)
		{
			LightDimmerKnob lightDimmerKnob = targetGo.AddComponent<LightDimmerKnob>();
			lightDimmer.knobs.Add(lightDimmerKnob);
			return lightDimmerKnob;
		}
		return null;
	}

	public static LightDimmerKnob AttachKnob(GameObject hostGo, string lightcasterFamilyId)
	{
		if (Lightcaster.instance == null)
		{
			return null;
		}
		List<int> dynamicLayerIndexes = Lightcaster.instance.GetDynamicLayerIndexes(lightcasterFamilyId);
		if (dynamicLayerIndexes.Count == 0)
		{
			return null;
		}
		LightDimmer lightDimmer = hostGo.GetComponent<LightDimmer>();
		if (lightDimmer != null)
		{
			if (lightDimmer.lightcasterDynamicLayerIndexes != null)
			{
				foreach (int item in dynamicLayerIndexes)
				{
					if (!lightDimmer.lightcasterDynamicLayerIndexes.Contains(item))
					{
						lightDimmer.lightcasterDynamicLayerIndexes.Add(item);
					}
				}
			}
			else
			{
				lightDimmer.lightcasterDynamicLayerIndexes = dynamicLayerIndexes;
			}
		}
		else
		{
			lightDimmer = hostGo.AddComponent<LightDimmer>();
			lightDimmer.lightcasterDynamicLayerIndexes = dynamicLayerIndexes;
			AddHierarchyKnobs(lightDimmer);
		}
		LightDimmerKnob lightDimmerKnob = hostGo.AddComponent<LightDimmerKnob>();
		lightDimmer.knobs.Add(lightDimmerKnob);
		return lightDimmerKnob;
	}

	private static void AddHierarchyKnobs(LightDimmer dimmer)
	{
		foreach (GameObject item in dimmer.gameObject.AllDescendents(false))
		{
			LightDimmer lightDimmer = AttachDimmer(item);
			if (lightDimmer != null)
			{
				dimmer.descendentKnobs.Add(lightDimmer.AllocKnob(dimmer.gameObject));
			}
		}
		foreach (GameObject item2 in dimmer.gameObject.AllAntecedents(false))
		{
			LightDimmer component = item2.GetComponent<LightDimmer>();
			if (component != null)
			{
				component.descendentKnobs.Add(dimmer.AllocKnob(component.gameObject));
				break;
			}
		}
	}
}
