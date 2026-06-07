using System;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesProvider : APreferencesProvider
{
	private readonly APreferencesCustomizer[] customizers = new APreferencesCustomizer[3]
	{
		new GraphicsPresetCustomizer(),
		new SteamDeckControlsCustomizer(),
		new SteamDeckGraphicsCustomizer()
	};

	private readonly Dictionary<Preferences, Type> enumerablePreferences = new Dictionary<Preferences, Type>
	{
		{
			Preferences.Crosshair,
			typeof(InfoVisibilityValues)
		},
		{
			Preferences.ItemHoldType,
			typeof(GrabMethodValues)
		},
		{
			Preferences.RotationMode,
			typeof(RotationModeValue)
		}
	};

	public override PreferencesExclusivity GetExclusivity()
	{
		if (!VRManager.IsVREnabled())
		{
			return PreferencesExclusivity.NonVR;
		}
		return PreferencesExclusivity.VR;
	}

	public override APreferencesCustomizer[] GetCustomizers()
	{
		return customizers;
	}

	public override Dictionary<Preferences, Type> GetEnumerablePreferencesMapping()
	{
		return enumerablePreferences;
	}

	public override bool UpgradePreferences(PreferencesStore vrStore, PreferencesPersistence vrPersistence, PreferencesStore nonVrStore, PreferencesPersistence nonVrPersistence)
	{
		bool flag = vrPersistence.ReadPreferences();
		bool flag2 = nonVrPersistence.ReadPreferences();
		bool flag3 = false;
		if (flag || flag2)
		{
			int num = vrPersistence.WrittenPreferencesVersion;
			if (num != 8)
			{
				vrPersistence.CreateBackupFile("_old_version");
				if (num > 8)
				{
					Debug.LogError("PreferencesProvider could not upgrade preferences - written version is greater than the current.");
					return false;
				}
				if (num == 0)
				{
					vrPersistence.PurgeWrittenPreferences();
					nonVrPersistence.ReadPreferences();
					vrPersistence.ReadPreferences();
					num = 8;
				}
				if (num == 1)
				{
					if (flag && !vrPersistence.LoadedAsDefaultValue(Preferences.RunSpeedMultiplier))
					{
						float num2 = vrStore.Get<float>(Preferences.RunSpeedMultiplier);
						num2 *= 2f;
						vrStore.Set(Preferences.RunSpeedMultiplier, num2);
					}
					num = 2;
				}
				if (num == 2)
				{
					if (flag)
					{
						int num3 = vrStore.Get<int>(Preferences.VegetationQualityIndex);
						if (num3 == 6 || num3 == 7)
						{
							num3--;
							vrStore.Set(Preferences.VegetationQualityIndex, num3);
						}
					}
					if (flag2)
					{
						int num4 = nonVrStore.Get<int>(Preferences.VegetationQualityIndex);
						if (num4 == 6 || num4 == 7)
						{
							num4--;
							nonVrStore.Set(Preferences.VegetationQualityIndex, num4);
						}
					}
					num = 3;
				}
				if (num == 3)
				{
					num = 4;
				}
				if (num == 4)
				{
					nonVrPersistence.PurgeWrittenPreferences();
					vrStore.ResetPreferencesToDefault();
					nonVrStore.ResetPreferencesToDefault();
					PreferencesPurged_Fire();
					num = 5;
				}
				if (num == 5)
				{
					vrStore.Set(Preferences.SnapRotationAngle, Array.IndexOf(RotatePlayer.SNAP_VALUES, 90f));
					vrStore.Set(Preferences.PlayerRoomscaleHeight, 0f);
					vrStore.Set(Preferences.PlayerSeatedHeight, 0f);
					num = 6;
				}
				if (num == 6)
				{
					if (vrStore.Get<int>(Preferences.RainQualityIndex) > 3)
					{
						vrStore.Set(Preferences.RainQualityIndex, 3);
					}
					if (nonVrStore.Get<int>(Preferences.RainQualityIndex) > 3)
					{
						nonVrStore.Set(Preferences.RainQualityIndex, 3);
					}
					num = 7;
				}
				if (num == 7)
				{
					string incompatiblePreferenceRawValue = nonVrPersistence.GetIncompatiblePreferenceRawValue("SSAO");
					string incompatiblePreferenceRawValue2 = vrPersistence.GetIncompatiblePreferenceRawValue("SSAO");
					if (!string.IsNullOrEmpty(incompatiblePreferenceRawValue) && bool.TryParse(incompatiblePreferenceRawValue, out var result))
					{
						nonVrStore.Set(Preferences.AmbientOcclusionQualityIndex, result ? 2 : 0);
					}
					else
					{
						nonVrStore.Set(Preferences.AmbientOcclusionQualityIndex, 0);
					}
					if (!string.IsNullOrEmpty(incompatiblePreferenceRawValue2) && bool.TryParse(incompatiblePreferenceRawValue2, out var result2))
					{
						vrStore.Set(Preferences.AmbientOcclusionQualityIndex, result2 ? 2 : 0);
					}
					else
					{
						vrStore.Set(Preferences.AmbientOcclusionQualityIndex, 0);
					}
					nonVrPersistence.DeleteIncompatiblePreference("SSAO");
					vrPersistence.DeleteIncompatiblePreference("SSAO");
					num = 8;
				}
				flag3 = true;
			}
		}
		nonVrPersistence.WritePreferences();
		vrPersistence.WritePreferences();
		if (flag3)
		{
			PreferencesUpgraded_Fire();
		}
		return flag3;
	}
}
