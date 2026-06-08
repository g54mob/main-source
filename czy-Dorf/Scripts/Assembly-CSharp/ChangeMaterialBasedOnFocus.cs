using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeMaterialBasedOnFocus : MonoBehaviour, IBiomeAffectedObject
{
	[FormerlySerializedAs("waterMaterial")]
	[SerializeField]
	private Material material;

	[SerializeField]
	private GroupType groupType;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private ColorOption nonDynamicColorSet;

	[SerializeField]
	private bool lerpColors;

	[SerializeField]
	private float colorLerpSpeed = 1f;

	private BiomeObjectConfiguration currentBiomeConfiguration;

	private Dictionary<string, Color> currentColors = new Dictionary<string, Color>();

	private Dictionary<string, Color> targetColors = new Dictionary<string, Color>();

	public GroupType GroupType => groupType;

	public ElementType ElementType => null;

	public ElementSubType SubType => null;

	public int Seed => 0;

	public float VariationAlpha => 0.5f;

	private void Start()
	{
		if ((bool)settingsRouter)
		{
			settingsRouter.OnEnableDynamicBackground += EnableDynamicBackground;
			EnableDynamicBackground(settingsRouter.DynamicBackgroundEnabled);
		}
	}

	private void EnableDynamicBackground(bool dynamicBackgroundEnabled)
	{
		if (dynamicBackgroundEnabled)
		{
			if (currentBiomeConfiguration != null)
			{
				ApplyBiomeConfiguration(currentBiomeConfiguration);
			}
			return;
		}
		Color color = nonDynamicColorSet.possibleColors.Evaluate(0f);
		if (!targetColors.ContainsKey(nonDynamicColorSet.propertyName))
		{
			targetColors.Add(nonDynamicColorSet.propertyName, color);
		}
		if (!currentColors.ContainsKey(nonDynamicColorSet.propertyName))
		{
			currentColors.Add(nonDynamicColorSet.propertyName, color);
		}
		targetColors[nonDynamicColorSet.propertyName] = color;
		UpdateColorTo(nonDynamicColorSet.propertyName, color);
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		currentBiomeConfiguration = new BiomeObjectConfiguration(biomeConfiguration);
		if ((bool)settingsRouter && !settingsRouter.DynamicBackgroundEnabled)
		{
			return;
		}
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			if (biomeEffectValue.value is Color value)
			{
				if (!lerpColors)
				{
					material.SetColor(biomeEffectValue.key, value);
				}
				else if (!targetColors.ContainsKey(biomeEffectValue.key))
				{
					targetColors.Add(biomeEffectValue.key, value);
				}
				else
				{
					targetColors[biomeEffectValue.key] = value;
				}
			}
			else if (biomeEffectValue.value is Texture2D value2)
			{
				material.SetTexture(biomeEffectValue.key, value2);
			}
		}
		if (!lerpColors || currentColors.Count != 0 || targetColors.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, Color> targetColor in targetColors)
		{
			currentColors.Add(targetColor.Key, targetColor.Value);
			UpdateColorTo(targetColor.Key, targetColor.Value);
		}
	}

	private void Update()
	{
		if (!lerpColors || targetColors.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, Color> targetColor in targetColors)
		{
			if (currentColors.ContainsKey(targetColor.Key) && currentColors[targetColor.Key] != targetColor.Value)
			{
				UpdateColorTo(targetColor.Key, Color.Lerp(currentColors[targetColor.Key], targetColor.Value, Time.deltaTime * colorLerpSpeed));
			}
		}
	}

	private void UpdateColorTo(string propertyName, Color targetColor)
	{
		currentColors[propertyName] = targetColor;
		material.SetColor(propertyName, targetColor);
	}

	private void OnDestroy()
	{
		if ((bool)settingsRouter)
		{
			settingsRouter.OnEnableDynamicBackground -= EnableDynamicBackground;
		}
	}
}
