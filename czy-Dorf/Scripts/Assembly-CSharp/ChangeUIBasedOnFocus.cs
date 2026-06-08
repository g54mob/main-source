using System;
using System.Collections.Generic;
using Dorfromantik.UI;
using Dorfromantik.UI.Components;
using UnityEngine;

public class ChangeUIBasedOnFocus : MonoBehaviour, IBiomeAffectedObject
{
	[SerializeField]
	private Color debugUiColor;

	private List<Ui_BiomeAffected> biomeAffectedUis;

	private static BiomeObjectConfiguration biomeObjectConfiguration;

	private readonly GroupType _003CGroupType_003Ek__BackingField;

	private readonly ElementType _003CElementType_003Ek__BackingField;

	private readonly ElementSubType _003CSubType_003Ek__BackingField;

	private readonly int _003CSeed_003Ek__BackingField;

	private readonly float _003CVariationAlpha_003Ek__BackingField;

	public GroupType GroupType => _003CGroupType_003Ek__BackingField;

	public ElementType ElementType => _003CElementType_003Ek__BackingField;

	public ElementSubType SubType => _003CSubType_003Ek__BackingField;

	public int Seed => _003CSeed_003Ek__BackingField;

	public float VariationAlpha => _003CVariationAlpha_003Ek__BackingField;

	public static event Action<BiomeObjectConfiguration> OnFocusBiomeChanged;

	private void Awake()
	{
		biomeAffectedUis = new List<Ui_BiomeAffected>();
	}

	public void AddListener(Ui_BiomeAffected biomeAffectedUi)
	{
		biomeAffectedUis.Add(biomeAffectedUi);
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		biomeObjectConfiguration = new BiomeObjectConfiguration(biomeConfiguration);
		foreach (Ui_BiomeAffected biomeAffectedUi in biomeAffectedUis)
		{
			biomeAffectedUi.ApplyBiomeAffectedModifiers(biomeConfiguration);
		}
		ChangeUIBasedOnFocus.OnFocusBiomeChanged?.Invoke(biomeConfiguration);
		debugUiColor = biomeConfiguration.GetEffectValue<Color>("background");
	}

	public static void ApplyBiomeTo(Ui_BiomeAffected affectedUi)
	{
		if (biomeObjectConfiguration != null)
		{
			affectedUi.ApplyBiomeAffectedModifiers(biomeObjectConfiguration);
		}
	}

	public static void ApplyBiomeTo(UiInputFieldBiomeAffected affectedUiInputField)
	{
		if (biomeObjectConfiguration != null)
		{
			affectedUiInputField.ApplyBiomeAffectedModifiers(biomeObjectConfiguration);
		}
	}
}
