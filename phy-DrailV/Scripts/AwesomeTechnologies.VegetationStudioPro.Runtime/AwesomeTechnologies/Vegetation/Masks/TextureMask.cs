using System;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.Masks
{
	[Serializable]
	public class TextureMask
	{
		public Rect TextureRect;

		public Vector2 Repeat = Vector2.one;

		public Texture2D MaskTexture;

		private NativeArray<RGBABytes> _rgbaNativeArray;

		public JobHandle SampleIncludeMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskType textureMaskType, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			if (!spawnRect.Overlaps(TextureRect))
			{
				return dependsOn;
			}
			if (MaskTexture == null)
			{
				return dependsOn;
			}
			if (textureMaskType == TextureMaskType.RGBAChannel)
			{
				_rgbaNativeArray = MaskTexture.GetRawTextureData<RGBABytes>();
				bool booleanPropertyValue = textureMaskRule.GetBooleanPropertyValue("Inverse");
				int num = textureMaskRule.GetIntPropertyValue("ChannelSelector");
				if (MaskTexture.format == TextureFormat.RGBA32)
				{
					num--;
					if (num == -1)
					{
						num = 3;
					}
				}
				return new SampleRgbaChannelIncludeMaskJob
				{
					Width = MaskTexture.width,
					Height = MaskTexture.height,
					Repeat = Repeat,
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					TextureMaskData = instanceData.TextureMaskData.AsDeferredJobArray(),
					RgbaNativeArray = _rgbaNativeArray,
					SelectedChannel = num,
					Inverse = booleanPropertyValue,
					TextureRect = TextureRect,
					MinValue = textureMaskRule.MinDensity,
					MaxValue = textureMaskRule.MaxDensity
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleExcludeMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskType textureMaskType, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			if (!spawnRect.Overlaps(TextureRect))
			{
				return dependsOn;
			}
			if (MaskTexture == null)
			{
				return dependsOn;
			}
			if (textureMaskType == TextureMaskType.RGBAChannel)
			{
				_rgbaNativeArray = MaskTexture.GetRawTextureData<RGBABytes>();
				bool booleanPropertyValue = textureMaskRule.GetBooleanPropertyValue("Inverse");
				int num = textureMaskRule.GetIntPropertyValue("ChannelSelector");
				if (MaskTexture.format == TextureFormat.RGBA32)
				{
					num--;
					if (num == -1)
					{
						num = 3;
					}
				}
				return new SampleRgbaChannelExcludeMaskJob
				{
					Width = MaskTexture.width,
					Height = MaskTexture.height,
					Repeat = Repeat,
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					RgbaNativeArray = _rgbaNativeArray,
					SelectedChannel = num,
					Inverse = booleanPropertyValue,
					TextureRect = TextureRect,
					MinValue = textureMaskRule.MinDensity,
					MaxValue = textureMaskRule.MaxDensity
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleScaleMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskType textureMaskType, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			if (!spawnRect.Overlaps(TextureRect))
			{
				return dependsOn;
			}
			if (MaskTexture == null)
			{
				return dependsOn;
			}
			if (textureMaskType == TextureMaskType.RGBAChannel)
			{
				_rgbaNativeArray = MaskTexture.GetRawTextureData<RGBABytes>();
				bool booleanPropertyValue = textureMaskRule.GetBooleanPropertyValue("Inverse");
				int num = textureMaskRule.GetIntPropertyValue("ChannelSelector");
				if (MaskTexture.format == TextureFormat.RGBA32)
				{
					num--;
					if (num == -1)
					{
						num = 3;
					}
				}
				return new SampleRgbaChannelScaleMaskJob
				{
					Width = MaskTexture.width,
					Height = MaskTexture.height,
					Repeat = Repeat,
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					Scale = instanceData.Scale.AsDeferredJobArray(),
					RgbaNativeArray = _rgbaNativeArray,
					SelectedChannel = num,
					Inverse = booleanPropertyValue,
					TextureRect = TextureRect,
					ScaleMultiplier = textureMaskRule.ScaleMultiplier
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleDensityMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskType textureMaskType, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			if (!spawnRect.Overlaps(TextureRect))
			{
				return dependsOn;
			}
			if (MaskTexture == null)
			{
				return dependsOn;
			}
			if (textureMaskType == TextureMaskType.RGBAChannel)
			{
				_rgbaNativeArray = MaskTexture.GetRawTextureData<RGBABytes>();
				bool booleanPropertyValue = textureMaskRule.GetBooleanPropertyValue("Inverse");
				int num = textureMaskRule.GetIntPropertyValue("ChannelSelector");
				if (MaskTexture.format == TextureFormat.RGBA32)
				{
					num--;
					if (num == -1)
					{
						num = 3;
					}
				}
				return new SampleRgbaChannelDensityMaskJob
				{
					Width = MaskTexture.width,
					Height = MaskTexture.height,
					Repeat = Repeat,
					SpawnLocations = instanceData.SpawnLocations.AsDeferredJobArray(),
					RgbaNativeArray = _rgbaNativeArray,
					SelectedChannel = num,
					Inverse = booleanPropertyValue,
					TextureRect = TextureRect,
					DensityMultiplier = textureMaskRule.DensityMultiplier
				}.Schedule(instanceData.SpawnLocations, 32, dependsOn);
			}
			return dependsOn;
		}

		public void Dispose()
		{
		}
	}
}
