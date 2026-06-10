using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	public class VoxelType : NSEipix.Base.Model
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private byte byteId;

		[SerializeField]
		private string mapMaskColor = string.Empty;

		[SerializeField]
		private int mapMaskBlock;

		[SerializeField]
		private int maskValue;

		[SerializeField]
		private bool mustBeInBounds;

		[SerializeField]
		private string thermalModelID;

		[SerializeField]
		private SoundWalkableMaterialCategory soundWalkableMaterialCategory;

		[SerializeField]
		private short health = 400;

		[SerializeField]
		private byte digAmount = 1;

		[SerializeField]
		private string digMarker = string.Empty;

		[SerializeField]
		private string overrideBy = string.Empty;

		[SerializeField]
		private bool overrideIsGrass;

		[SerializeField]
		private bool canGrowGrass;

		[SerializeField]
		private float spawnWater;

		[SerializeField]
		private float grassFlammabilityAdd;

		[NonSerialized]
		private Color colorForMapMask;

		[NonSerialized]
		private ThermalModel thermalModelCache;

		[NonSerialized]
		private bool thermalModelCacheInitialized;

		[NonSerialized]
		private bool isOverride;

		[NonSerialized]
		private string textKey;

		[NonSerialized]
		private bool textKeyInitialized;

		public string TextKey
		{
			get
			{
				if (!textKeyInitialized)
				{
					textKeyInitialized = true;
					textKey = "voxel_" + GetID();
				}
				return textKey;
			}
		}

		public byte ByteId => byteId;

		public bool IsDiggable => health != -1;

		public int MapMaskBlock => mapMaskBlock;

		public int MaskValue => maskValue;

		public bool MustBeInBounds => mustBeInBounds;

		public short Health => health;

		public byte DigAmount => digAmount;

		public string DigMarker => digMarker;

		public string OverrideBy => overrideBy;

		public bool OverrideIsGrass => overrideIsGrass;

		public bool IsOverride => isOverride;

		public float GrassFlammabilityAdd => grassFlammabilityAdd;

		public Color ColorForMapMask => colorForMapMask;

		public ThermalModel ThermalModel
		{
			get
			{
				if (!thermalModelCacheInitialized)
				{
					thermalModelCacheInitialized = true;
					if (!string.IsNullOrEmpty(thermalModelID))
					{
						thermalModelCache = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModelID);
					}
				}
				return thermalModelCache;
			}
		}

		public SoundWalkableMaterialCategory SoundWalkableMaterialCategory => soundWalkableMaterialCategory;

		public bool CanGrowGrass => canGrowGrass;

		public float SpawnWater => spawnWater;

		public override string GetID()
		{
			return id;
		}

		public void Initialize()
		{
			isOverride = !string.IsNullOrEmpty(overrideBy);
			colorForMapMask = new Color(0f, 0f, 0f, 0f);
			ColorUtility.TryParseHtmlString(mapMaskColor, out colorForMapMask);
		}
	}
}
