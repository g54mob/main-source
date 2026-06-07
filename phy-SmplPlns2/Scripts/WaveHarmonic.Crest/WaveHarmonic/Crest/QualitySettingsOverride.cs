using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class QualitySettingsOverride
	{
		[Tooltip("Whether to override the LOD bias.")]
		[SerializeField]
		internal bool _OverrideLodBias;

		[Tooltip("Overrides the LOD bias for meshes.\n\nHighest quality is infinity.")]
		[SerializeField]
		internal float _LodBias;

		[Tooltip("Whether to override the maximum LOD level.")]
		[SerializeField]
		internal bool _OverrideMaximumLodLevel;

		[Tooltip("Overrides the maximum LOD level.\n\nHighest quality is zero.")]
		[SerializeField]
		internal int _MaximumLodLevel;

		[Tooltip("Whether to override the terrain pixel error.")]
		[SerializeField]
		internal bool _OverrideTerrainPixelError;

		[Tooltip("Overrides the pixel error value for terrains.\n\nHighest quality is zero.")]
		[SerializeField]
		internal float _TerrainPixelError;

		private float _OldLodBias;

		private int _OldMaximumLodLevelOverride;

		private float _OldTerrainPixelError;

		private TerrainQualityOverrides _OldTerrainOverrides;

		public float LodBias
		{
			get
			{
				return _LodBias;
			}
			set
			{
				_LodBias = value;
			}
		}

		public int MaximumLodLevel
		{
			get
			{
				return _MaximumLodLevel;
			}
			set
			{
				_MaximumLodLevel = value;
			}
		}

		public bool OverrideLodBias
		{
			get
			{
				return _OverrideLodBias;
			}
			set
			{
				_OverrideLodBias = value;
			}
		}

		public bool OverrideMaximumLodLevel
		{
			get
			{
				return _OverrideMaximumLodLevel;
			}
			set
			{
				_OverrideMaximumLodLevel = value;
			}
		}

		public bool OverrideTerrainPixelError
		{
			get
			{
				return _OverrideTerrainPixelError;
			}
			set
			{
				_OverrideTerrainPixelError = value;
			}
		}

		public float TerrainPixelError
		{
			get
			{
				return _TerrainPixelError;
			}
			set
			{
				_TerrainPixelError = value;
			}
		}

		internal void Override()
		{
			if (_OverrideLodBias)
			{
				_OldLodBias = QualitySettings.lodBias;
				QualitySettings.lodBias = _LodBias;
			}
			if (_OverrideMaximumLodLevel)
			{
				_OldMaximumLodLevelOverride = QualitySettings.maximumLODLevel;
				QualitySettings.maximumLODLevel = _MaximumLodLevel;
			}
			if (_OverrideTerrainPixelError)
			{
				_OldTerrainOverrides = QualitySettings.terrainQualityOverrides;
				_OldTerrainPixelError = QualitySettings.terrainPixelError;
				QualitySettings.terrainQualityOverrides = TerrainQualityOverrides.PixelError;
				QualitySettings.terrainPixelError = _TerrainPixelError;
			}
		}

		internal void Restore()
		{
			if (_OverrideLodBias)
			{
				QualitySettings.lodBias = _OldLodBias;
			}
			if (_OverrideMaximumLodLevel)
			{
				QualitySettings.maximumLODLevel = _OldMaximumLodLevelOverride;
			}
			if (_OverrideTerrainPixelError)
			{
				QualitySettings.terrainQualityOverrides = _OldTerrainOverrides;
				QualitySettings.terrainPixelError = _OldTerrainPixelError;
			}
		}

		public override int GetHashCode()
		{
			int hash = Hash.CreateHash();
			Hash.AddBool(_OverrideLodBias, ref hash);
			Hash.AddFloat(_LodBias, ref hash);
			Hash.AddBool(_OverrideMaximumLodLevel, ref hash);
			Hash.AddInt(_MaximumLodLevel, ref hash);
			Hash.AddBool(_OverrideTerrainPixelError, ref hash);
			Hash.AddFloat(_TerrainPixelError, ref hash);
			return hash;
		}
	}
}
