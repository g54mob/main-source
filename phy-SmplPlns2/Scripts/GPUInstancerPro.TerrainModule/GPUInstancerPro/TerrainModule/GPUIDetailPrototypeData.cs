using System;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[Serializable]
	public class GPUIDetailPrototypeData : GPUIPrototypeData
	{
		public class GPUIDetailPrototypeSubSettings : IGPUIParameterBufferData
		{
			public float minWidth;

			public float maxWidth;

			public float minHeight;

			public float maxHeight;

			public int noiseSeed;

			[Range(0f, 1f)]
			public float alignToGround;

			public float detailUniqueValue;

			public int noiseSeedAdjustment;

			public void SetParameterBufferData()
			{
				if (GPUIRenderingSystem.IsActive)
				{
					GPUIDataBuffer<float> parameterBuffer = GPUIRenderingSystem.Instance.ParameterBuffer;
					if (TryGetParameterBufferIndex(out var index))
					{
						parameterBuffer[index] = minWidth;
						parameterBuffer[index + 1] = maxWidth;
						parameterBuffer[index + 2] = minHeight;
						parameterBuffer[index + 3] = maxHeight;
						parameterBuffer[index + 4] = noiseSeed;
						parameterBuffer[index + 5] = alignToGround;
						parameterBuffer[index + 6] = GetUniqueValue();
					}
					else
					{
						GPUIRenderingSystem.Instance.ParameterBufferIndexes.Add(this, parameterBuffer.Length);
						parameterBuffer.Add(minWidth, maxWidth, minHeight, maxHeight, noiseSeed, alignToGround, GetUniqueValue());
					}
				}
			}

			public bool TryGetParameterBufferIndex(out int index)
			{
				return GPUIRenderingSystem.Instance.ParameterBufferIndexes.TryGetValue(this, out index);
			}

			public float GetUniqueValue()
			{
				if (detailUniqueValue == 0f)
				{
					UnityEngine.Random.InitState(noiseSeed + noiseSeedAdjustment);
					detailUniqueValue = (float)Math.Round(UnityEngine.Random.Range(0.001f, 0.999f), 3);
				}
				return detailUniqueValue;
			}
		}

		public GPUIDetailMaterialDescription mpbDescription;

		public Texture2D detailTexture;

		public float noiseSpread = 0.1f;

		public Color healthyColor = Color.white;

		public Color dryColor = Color.white;

		public bool isBillboard;

		[Range(0f, 1f)]
		public float ambientOcclusion = 0.2f;

		[Range(0f, 1f)]
		public float gradientPower = 0.5f;

		public Color windWaveTintColor = new Color(0.69803923f, 0.6f, 0.5019608f);

		public bool isOverrideHealthyDryNoiseTexture;

		public Texture2D healthyDryNoiseTexture;

		[Range(0f, 1f)]
		public float windIdleSway = 0.6f;

		public bool windWavesOn = true;

		[Range(0f, 1f)]
		public float windWaveSize = 0.8f;

		[Range(0f, 1f)]
		public float windWaveTint = 0.5f;

		[Range(0f, 1f)]
		public float windWaveSway = 0.5f;

		[Range(0f, 4f)]
		public float contrast = 1f;

		[Range(0f, 4f)]
		public float healthyDryRatio = 1f;

		public bool isUseDensityReduction = true;

		public float densityReduceDistance = 200f;

		[Range(1f, 128f)]
		public float densityReduceMultiplier = 16f;

		[Range(0f, 64f)]
		public float densityReduceMaxScale;

		[Range(0f, 1f)]
		public float densityReduceHeightScale;

		public int initialBufferSize = 1024;

		[Range(1f, 255f)]
		public int maxDetailInstanceCountPerUnit = 16;

		[Range(0f, 4f)]
		public float detailBufferSizePercentageDifferenceForReduction = 0.5f;

		[Range(0.05f, 1f)]
		public float detailExtraBufferSizePercentage = 0.2f;

		[Range(0.0625f, 16f)]
		public float densityAdjustment = 1f;

		[Range(-4f, 4f)]
		public float healthyDryScaleAdjustment;

		public int noiseSeedAdjustment;

		[Range(0f, 4f)]
		public float noiseSpreadAdjustment = 1f;

		public GPUIProceduralDetailObject proceduralDensityData;

		[NonSerialized]
		internal Bounds _bounds;

		[NonSerialized]
		private GPUIDetailPrototypeSubSettings[] _prototypeSubSettings;

		public void ReadFromDetailPrototypeData(DetailPrototype detailPrototype, int subSettingIndex, GPUIDetailManager detailManager, int prototypeIndex)
		{
			GPUIDetailPrototypeSubSettings subSettings = GetSubSettings(subSettingIndex);
			bool flag = healthyColor != detailPrototype.healthyColor;
			healthyColor = detailPrototype.healthyColor;
			flag |= dryColor != detailPrototype.dryColor;
			dryColor = detailPrototype.dryColor;
			flag |= detailTexture != detailPrototype.prototypeTexture;
			detailTexture = detailPrototype.prototypeTexture;
			flag |= subSettings.minWidth != detailPrototype.minWidth;
			subSettings.minWidth = detailPrototype.minWidth;
			flag |= subSettings.maxWidth != detailPrototype.maxWidth;
			subSettings.maxWidth = detailPrototype.maxWidth;
			flag |= subSettings.minHeight != detailPrototype.minHeight;
			subSettings.minHeight = detailPrototype.minHeight;
			flag |= subSettings.maxHeight != detailPrototype.maxHeight;
			subSettings.maxHeight = detailPrototype.maxHeight;
			flag |= subSettings.noiseSeed != detailPrototype.noiseSeed;
			subSettings.noiseSeed = detailPrototype.noiseSeed;
			subSettings.detailUniqueValue = 0f;
			flag |= noiseSpread != detailPrototype.noiseSpread;
			noiseSpread = detailPrototype.noiseSpread;
			flag |= subSettings.alignToGround != detailPrototype.alignToGround;
			subSettings.alignToGround = detailPrototype.alignToGround;
			flag |= isBillboard != (detailPrototype.renderMode == DetailRenderMode.GrassBillboard);
			isBillboard = detailPrototype.renderMode == DetailRenderMode.GrassBillboard;
			if (detailPrototype.prototype == null && mpbDescription == null)
			{
				mpbDescription = GPUITerrainConstants.DefaultDetailMaterialDescription;
			}
			if (initialBufferSize <= 0)
			{
				initialBufferSize = 1024;
			}
			if (detailManager.IsInitialized && flag)
			{
				SetParameterBufferData();
				subSettings.SetParameterBufferData();
				if (detailTexture != null && GPUIRenderingSystem.TryGetRenderSourceGroup(detailManager.GetRenderKey(prototypeIndex), out var renderSourceGroup))
				{
					SetMPBValues(detailManager, prototypeIndex, renderSourceGroup);
				}
			}
		}

		public bool IsMatchingPrefabAndTexture(DetailPrototype detailPrototype, GPUIPrototype prototype, bool checkPropertyValues = true)
		{
			if (prototype.prototypeType == GPUIPrototypeType.Prefab && detailPrototype.usePrototypeMesh && prototype.prefabObject.EqualOrParentOf(detailPrototype.prototype))
			{
				return true;
			}
			if (prototype.prototypeType == GPUIPrototypeType.MeshAndMaterial && !detailPrototype.usePrototypeMesh && detailPrototype.prototypeTexture == detailTexture && (!checkPropertyValues || (detailPrototype.healthyColor.Approximately(healthyColor) && detailPrototype.dryColor.Approximately(dryColor) && detailPrototype.noiseSpread == noiseSpread && detailPrototype.renderMode == DetailRenderMode.GrassBillboard == isBillboard)))
			{
				return true;
			}
			return false;
		}

		public bool HasSameSettingsWith(DetailPrototype detailPrototype, int subSettingIndex)
		{
			GPUIDetailPrototypeSubSettings gPUIDetailPrototypeSubSettings = _prototypeSubSettings[subSettingIndex];
			if (detailPrototype.minWidth == gPUIDetailPrototypeSubSettings.minWidth && detailPrototype.maxWidth == gPUIDetailPrototypeSubSettings.maxWidth && detailPrototype.minHeight == gPUIDetailPrototypeSubSettings.minHeight && detailPrototype.maxHeight == gPUIDetailPrototypeSubSettings.maxHeight && detailPrototype.alignToGround == gPUIDetailPrototypeSubSettings.alignToGround)
			{
				return true;
			}
			return false;
		}

		public void SetMPBValues(GPUIDetailManager detailManager, int prototypeIndex, GPUIRenderSourceGroup rsg)
		{
			if (mpbDescription != null)
			{
				mpbDescription.SetMPBValues(rsg, detailManager, prototypeIndex);
			}
		}

		private void CreateSubSettingAtIndex(int subSettingIndex)
		{
			if (_prototypeSubSettings == null)
			{
				_prototypeSubSettings = new GPUIDetailPrototypeSubSettings[subSettingIndex + 1];
				for (int i = 0; i <= subSettingIndex; i++)
				{
					_prototypeSubSettings[i] = new GPUIDetailPrototypeSubSettings();
				}
			}
			else if (_prototypeSubSettings.Length <= subSettingIndex)
			{
				int num = _prototypeSubSettings.Length;
				Array.Resize(ref _prototypeSubSettings, subSettingIndex + 1);
				for (int j = num; j <= subSettingIndex; j++)
				{
					_prototypeSubSettings[j] = new GPUIDetailPrototypeSubSettings();
				}
			}
		}

		public GPUIDetailPrototypeSubSettings GetSubSettings(int subSettingIndex)
		{
			CreateSubSettingAtIndex(subSettingIndex);
			return _prototypeSubSettings[subSettingIndex];
		}

		public int GetSubSettingCount()
		{
			if (_prototypeSubSettings != null)
			{
				return _prototypeSubSettings.Length;
			}
			return 0;
		}

		public float GetNoiseSpread()
		{
			return noiseSpread * noiseSpreadAdjustment;
		}

		public override void SetParameterBufferData()
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				return;
			}
			GPUIDataBuffer<float> parameterBuffer = GPUIRenderingSystem.Instance.ParameterBuffer;
			if (TryGetParameterBufferIndex(out var index))
			{
				parameterBuffer[index] = densityReduceDistance;
				parameterBuffer[index + 1] = densityReduceMultiplier;
				parameterBuffer[index + 2] = densityReduceMaxScale;
				parameterBuffer[index + 3] = densityReduceHeightScale;
				parameterBuffer[index + 4] = densityAdjustment;
				parameterBuffer[index + 5] = (isBillboard ? 1f : 0f);
				parameterBuffer[index + 6] = maxDetailInstanceCountPerUnit;
				parameterBuffer[index + 7] = GetNoiseSpread();
				parameterBuffer[index + 8] = healthyDryScaleAdjustment;
			}
			else
			{
				GPUIRenderingSystem.Instance.ParameterBufferIndexes.Add(this, parameterBuffer.Length);
				parameterBuffer.Add(densityReduceDistance, densityReduceMultiplier, densityReduceMaxScale, densityReduceHeightScale, densityAdjustment, isBillboard ? 1f : 0f, maxDetailInstanceCountPerUnit, GetNoiseSpread(), healthyDryScaleAdjustment);
			}
			if (_prototypeSubSettings == null)
			{
				return;
			}
			GPUIDetailPrototypeSubSettings[] prototypeSubSettings = _prototypeSubSettings;
			foreach (GPUIDetailPrototypeSubSettings gPUIDetailPrototypeSubSettings in prototypeSubSettings)
			{
				if (gPUIDetailPrototypeSubSettings.noiseSeedAdjustment != noiseSeedAdjustment)
				{
					gPUIDetailPrototypeSubSettings.detailUniqueValue = 0f;
					gPUIDetailPrototypeSubSettings.noiseSeedAdjustment = noiseSeedAdjustment;
				}
				gPUIDetailPrototypeSubSettings.SetParameterBufferData();
			}
		}
	}
}
