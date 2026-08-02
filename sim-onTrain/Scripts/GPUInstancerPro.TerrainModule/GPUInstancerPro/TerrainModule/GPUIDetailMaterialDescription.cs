using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[CreateAssetMenu(menuName = "Rendering/GPU Instancer Pro/Detail Material Description", order = 711)]
	public class GPUIDetailMaterialDescription : GPUIMPBDescription
	{
		public string mainTextureProperty;

		public string healthyColorProperty;

		public bool isDryColorActive;

		public string dryColorProperty;

		public bool isWavingTintActive;

		public string wavingTintProperty;

		public bool isBillboardActive;

		public string isBillboardProperty;

		public bool isHealthyDryNoiseTextureActive;

		public string healthyDryNoiseTextureProperty;

		public static readonly int PROP_WindWaveSize = Shader.PropertyToID("_WindWaveSize");

		public static readonly int PROP_AmbientOcclusion = Shader.PropertyToID("_AmbientOcclusion");

		public static readonly int PROP_NoiseSpread = Shader.PropertyToID("_NoiseSpread");

		public static readonly int PROP_WindVector = Shader.PropertyToID("_WindVector");

		public static readonly int PROP_WindWavesOn = Shader.PropertyToID("_WindWavesOn");

		public static readonly int PROP_WindWaveSway = Shader.PropertyToID("_WindWaveSway");

		public static readonly int PROP_WindIdleSway = Shader.PropertyToID("_WindIdleSway");

		public static readonly int PROP_GradientContrastRatioTint = Shader.PropertyToID("_GradientContrastRatioTint");

		private int _mainTexturePropertyID;

		private int _healthyColorPropertyID;

		private int _dryColorPropertyID;

		private int _wavingTintPropertyID;

		private int _isBillboardPropertyID;

		private int _healthyDryNoiseTexturePropertyID;

		private bool _isDefaultShader;

		public void SetPropertyIDs()
		{
			_mainTexturePropertyID = Shader.PropertyToID(mainTextureProperty);
			_healthyColorPropertyID = Shader.PropertyToID(healthyColorProperty);
			if (!string.IsNullOrEmpty(dryColorProperty))
			{
				_dryColorPropertyID = Shader.PropertyToID(dryColorProperty);
			}
			if (!string.IsNullOrEmpty(wavingTintProperty))
			{
				_wavingTintPropertyID = Shader.PropertyToID(wavingTintProperty);
			}
			if (!string.IsNullOrEmpty(isBillboardProperty))
			{
				_isBillboardPropertyID = Shader.PropertyToID(isBillboardProperty);
			}
			if (!string.IsNullOrEmpty(healthyDryNoiseTextureProperty))
			{
				_healthyDryNoiseTexturePropertyID = Shader.PropertyToID(healthyDryNoiseTextureProperty);
			}
			_isDefaultShader = GPUITerrainConstants.IsDefaultDetailShader(shader);
		}

		public override void SetMPBValues(GPUIRenderSourceGroup rsg, GPUIManager manager, int prototypeIndex)
		{
			if (!(manager is GPUIDetailManager gPUIDetailManager))
			{
				return;
			}
			if (_mainTexturePropertyID == 0 || !_isDefaultShader)
			{
				SetPropertyIDs();
			}
			GPUIDetailPrototypeData prototypeData = gPUIDetailManager.GetPrototypeData(prototypeIndex);
			if (prototypeData != null && prototypeData.detailTexture != null)
			{
				rsg.AddMaterialPropertyOverride(_mainTexturePropertyID, prototypeData.detailTexture);
				rsg.AddMaterialPropertyOverride(_healthyColorPropertyID, prototypeData.healthyColor);
				if (isDryColorActive && !string.IsNullOrEmpty(dryColorProperty))
				{
					rsg.AddMaterialPropertyOverride(_dryColorPropertyID, prototypeData.dryColor);
				}
				if (isWavingTintActive && !string.IsNullOrEmpty(wavingTintProperty))
				{
					rsg.AddMaterialPropertyOverride(_wavingTintPropertyID, prototypeData.windWaveTintColor);
				}
				if (isBillboardActive && !string.IsNullOrEmpty(isBillboardProperty))
				{
					rsg.AddMaterialPropertyOverride(_isBillboardPropertyID, prototypeData.isBillboard ? 1 : 0);
				}
				if (isHealthyDryNoiseTextureActive && !string.IsNullOrEmpty(healthyDryNoiseTextureProperty))
				{
					if (prototypeData.isOverrideHealthyDryNoiseTexture && prototypeData.healthyDryNoiseTexture != null)
					{
						rsg.AddMaterialPropertyOverride(_healthyDryNoiseTexturePropertyID, prototypeData.healthyDryNoiseTexture);
					}
					else if (gPUIDetailManager.healthyDryNoiseTexture != null)
					{
						rsg.AddMaterialPropertyOverride(_healthyDryNoiseTexturePropertyID, gPUIDetailManager.healthyDryNoiseTexture);
					}
				}
			}
			if (_isDefaultShader)
			{
				rsg.AddMaterialPropertyOverride(PROP_WindWaveSize, prototypeData.windWaveSize);
				rsg.AddMaterialPropertyOverride(PROP_AmbientOcclusion, prototypeData.ambientOcclusion);
				rsg.AddMaterialPropertyOverride(PROP_NoiseSpread, prototypeData.GetNoiseSpread());
				rsg.AddMaterialPropertyOverride(PROP_WindVector, gPUIDetailManager.windVector);
				rsg.AddMaterialPropertyOverride(PROP_WindWavesOn, prototypeData.windWavesOn ? 1 : 0);
				rsg.AddMaterialPropertyOverride(PROP_WindWaveSway, prototypeData.windWaveSway);
				rsg.AddMaterialPropertyOverride(PROP_WindIdleSway, prototypeData.windIdleSway);
				rsg.AddMaterialPropertyOverride(PROP_GradientContrastRatioTint, new Vector4(prototypeData.gradientPower, prototypeData.contrast, prototypeData.healthyDryRatio, prototypeData.windWaveTint));
			}
		}

		public void SetDefaultValues()
		{
			shader = GPUITerrainConstants.GetDefaultDetailShader();
			mainTextureProperty = "_MainTex";
			healthyColorProperty = "_HealthyColor";
			isDryColorActive = true;
			dryColorProperty = "_DryColor";
			isWavingTintActive = true;
			wavingTintProperty = "_WindWaveTintColor";
			isBillboardActive = true;
			isBillboardProperty = "_IsBillboard";
			isHealthyDryNoiseTextureActive = true;
			healthyDryNoiseTextureProperty = "_HealthyDryNoiseTexture";
		}
	}
}
