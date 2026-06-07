using System;
using Assets.Scripts.Settings;
using JBooth.MicroSplat;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Environment.Terrain
{
	public class MicrosplatTerrainQualityScript : MonoBehaviour
	{
		[SerializeField]
		private MicrosplatMaterialData _lowQuality;

		[SerializeField]
		private MicrosplatMaterialData _mediumQuality;

		[SerializeField]
		private MicrosplatMaterialData _highQuality;

		private int _snowRimProperty;

		private int _lightColorProperty;

		private MicroSplatTerrain[] _microSplatTerrains;

		private EnumSetting<EnvironmentQualitySettings.TerrainQualityLevel> _terrainQualitySetting;

		protected virtual void Awake()
		{
			_terrainQualitySetting = Game.Instance.Settings.Quality.Environment.TerrainQuality;
			_terrainQualitySetting.Changed += OnTerrainQualitySettingsChanged;
			_snowRimProperty = Shader.PropertyToID("_SnowRimColor");
			_lightColorProperty = Shader.PropertyToID("_DirectLightColor");
			ApplyQualitySetting(_terrainQualitySetting.Value);
		}

		protected virtual void OnDestroy()
		{
			_terrainQualitySetting.Changed -= OnTerrainQualitySettingsChanged;
		}

		protected virtual void Update()
		{
			Color globalColor = Shader.GetGlobalColor(_lightColorProperty);
			float num = Mathf.Min(Mathf.Min(globalColor.r, globalColor.g), globalColor.b);
			globalColor = 0.5f * Color.Lerp(globalColor, new Color(num, num, num), 0.7f);
			MicroSplatTerrain[] microSplatTerrains = _microSplatTerrains;
			for (int i = 0; i < microSplatTerrains.Length; i++)
			{
				microSplatTerrains[i].terrain.materialTemplate.SetColor(_snowRimProperty, globalColor);
			}
		}

		private void ApplyMaterialData(MicrosplatMaterialData materialData)
		{
			_microSplatTerrains = GetTerrains();
			MicroSplatTerrain[] microSplatTerrains = _microSplatTerrains;
			foreach (MicroSplatTerrain obj in microSplatTerrains)
			{
				obj.terrain.materialTemplate = null;
				obj.templateMaterial = materialData.Material;
				obj.keywordSO = materialData.Keywords;
				obj.propData = materialData.PropData;
				obj.procTexCfg = materialData.ProceduralTextureConfig;
				obj.Sync();
			}
		}

		private void ApplyQualitySetting(EnvironmentQualitySettings.TerrainQualityLevel quality)
		{
			ApplyMaterialData(quality switch
			{
				EnvironmentQualitySettings.TerrainQualityLevel.Low => _lowQuality, 
				EnvironmentQualitySettings.TerrainQualityLevel.Medium => _mediumQuality, 
				EnvironmentQualitySettings.TerrainQualityLevel.High => _highQuality, 
				_ => throw new ArgumentOutOfRangeException("quality", quality, $"Quality setting of '{quality}' is not currently supported."), 
			});
		}

		private MicroSplatTerrain[] GetTerrains()
		{
			return GetComponentsInChildren<MicroSplatTerrain>(includeInactive: true);
		}

		private void OnTerrainQualitySettingsChanged(object sender, SettingChangedEventArgs<EnvironmentQualitySettings.TerrainQualityLevel> e)
		{
			ApplyQualitySetting(e.Setting.Value);
		}
	}
}
