using Unity.Mathematics;

namespace Digger.Modules.Core.Sources
{
	public struct Voxel
	{
		private uint properties;

		public const uint Unaltered = 0u;

		public const uint OnSurface = 1u;

		public const uint NearBelowSurface = 2u;

		public const uint NearAboveSurface = 3u;

		public const uint FarBelowSurface = 4u;

		public const uint FarAboveSurface = 5u;

		public const uint Hole = 6u;

		public float Value { get; private set; }

		public uint FirstTextureIndex
		{
			get
			{
				return properties & 0x1F;
			}
			set
			{
				properties |= value & 0x1F;
				properties &= value | 0xFFFFFFE0u;
			}
		}

		public uint SecondTextureIndex
		{
			get
			{
				return (properties & 0x3E0) >> 5;
			}
			set
			{
				properties |= (value & 0x1F) << 5;
				properties &= ((value | 0xFFFFFFE0u) << 5) | 0x1F;
			}
		}

		private uint TextureLerp
		{
			get
			{
				return (properties & 0xFC00) >> 10;
			}
			set
			{
				properties |= (value & 0x3F) << 10;
				properties &= ((value | 0xFFFFFFC0u) << 10) | 0x3FF;
			}
		}

		private uint WetnessWeight
		{
			get
			{
				return (properties & 0x70000) >> 16;
			}
			set
			{
				properties |= (value & 7) << 16;
				properties &= ((value | 0xFFFFFFF8u) << 16) | 0xFFFF;
			}
		}

		private uint PuddlesWeight
		{
			get
			{
				return (properties & 0x380000) >> 19;
			}
			set
			{
				properties |= (value & 7) << 19;
				properties &= ((value | 0xFFFFFFF8u) << 19) | 0x7FFFF;
			}
		}

		private uint MaxValue
		{
			get
			{
				return (properties & 0xFC00000) >> 22;
			}
			set
			{
				properties |= (value & 0x3F) << 22;
				properties &= ((value | 0xFFFFFFC0u) << 22) | 0x3FFFFF;
			}
		}

		public uint Alteration
		{
			get
			{
				return (properties & 0xF0000000u) >> 28;
			}
			set
			{
				properties |= (value & 0xF) << 28;
				properties &= ((value | 0xFFFFFFF0u) << 28) | 0xFFFFFFF;
			}
		}

		public float NormalizedTextureLerp
		{
			get
			{
				return (float)TextureLerp / 63f;
			}
			set
			{
				TextureLerp = (uint)(math.clamp(value, 0f, 1f) * 63f);
			}
		}

		public float NormalizedWetnessWeight
		{
			get
			{
				return (float)WetnessWeight / 7f;
			}
			set
			{
				WetnessWeight = (uint)(math.clamp(value, 0f, 1f) * 7f);
			}
		}

		public float NormalizedPuddlesWeight
		{
			get
			{
				return (float)PuddlesWeight / 7f;
			}
			set
			{
				PuddlesWeight = (uint)(math.clamp(value, 0f, 1f) * 7f);
			}
		}

		public bool IsIndestructible => MaxValue >= 32;

		public bool IsInside => Value < 0f;

		public bool IsInsideInclusive => Value < 0.0001f;

		public bool IsAlteredNearBelowSurface => Alteration == 2;

		public bool IsAlteredNearAboveSurface => Alteration == 3;

		public bool IsAlteredFarOrNearSurface => Alteration >= 2;

		public bool IsAlteredFarSurface => Alteration >= 4;

		public bool IsUnalteredOrOnSurface => Alteration <= 1;

		public void SetValue(float value, float maxAbsValue)
		{
			Value = math.clamp(value, 0f - maxAbsValue, maxAbsValue);
		}

		public float SetMaxValue(float maxValue, float maxAbsValue)
		{
			maxValue = math.clamp(maxValue, 0f - maxAbsValue, maxAbsValue);
			float num = (maxValue + maxAbsValue) / (2f * maxAbsValue);
			uint num2 = (MaxValue = 63 - (uint)(num * 63f));
			return num2;
		}

		public float GetMaxValue(float maxAbsValue)
		{
			return (float)(63 - MaxValue) / 63f * 2f * maxAbsValue - maxAbsValue;
		}

		public void ResetMaxValue()
		{
			MaxValue = 0u;
		}

		public Voxel(float value, float maxAbsValue)
		{
			Value = math.clamp(value, 0f - maxAbsValue, maxAbsValue);
			properties = 0u;
		}

		public void AddTexture(uint textureIndex, float intensity)
		{
			if (textureIndex == FirstTextureIndex)
			{
				NormalizedTextureLerp -= intensity;
			}
			else if (textureIndex == SecondTextureIndex)
			{
				NormalizedTextureLerp += intensity;
			}
			else if (NormalizedTextureLerp < 0.5f)
			{
				SecondTextureIndex = textureIndex;
				NormalizedTextureLerp = intensity;
			}
			else
			{
				FirstTextureIndex = textureIndex;
				NormalizedTextureLerp = 1f - intensity;
			}
		}

		public void SetTexture(uint textureIndex, float intensity)
		{
			if (textureIndex == FirstTextureIndex)
			{
				NormalizedTextureLerp = intensity;
			}
			else if (textureIndex == SecondTextureIndex)
			{
				NormalizedTextureLerp = intensity;
			}
			else if (NormalizedTextureLerp < 0.5f)
			{
				SecondTextureIndex = textureIndex;
				NormalizedTextureLerp = intensity;
			}
			else
			{
				FirstTextureIndex = textureIndex;
				NormalizedTextureLerp = 1f - intensity;
			}
		}
	}
}
