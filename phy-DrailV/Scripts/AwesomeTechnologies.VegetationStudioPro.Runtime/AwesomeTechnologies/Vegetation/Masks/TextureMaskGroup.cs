using System;
using System.Collections.Generic;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.Masks
{
	[Serializable]
	public class TextureMaskGroup
	{
		public List<TextureMask> TextureMaskList = new List<TextureMask>();

		public string TextureMaskName;

		public TextureMaskType TextureMaskType;

		public List<TextureFormat> RequiredTextureFormatList = new List<TextureFormat>();

		public string TextureMaskGroupID;

		public TextureMaskSettings Settings;

		public TextureMaskGroup(TextureMaskType textureMaskType)
		{
			TextureMaskType = textureMaskType;
			TextureMaskName = "New texture mask";
			TextureMaskGroupID = Guid.NewGuid().ToString();
			Settings = new TextureMaskSettings();
			if (textureMaskType == TextureMaskType.RGBAChannel)
			{
				Settings.AddRgbaSelectorProperty("ChannelSelector", "Select channel", "", 0);
				Settings.AddBooleanProperty("Inverse", "Inverse", "", defaultValue: false);
				RequiredTextureFormatList.Add(TextureFormat.RGBA32);
				RequiredTextureFormatList.Add(TextureFormat.ARGB32);
			}
		}

		public Texture2D GetPreviewTexture()
		{
			for (int i = 0; i <= TextureMaskList.Count - 1; i++)
			{
				if ((bool)TextureMaskList[i].MaskTexture)
				{
					return TextureMaskList[i].MaskTexture;
				}
			}
			return null;
		}

		public JobHandle SampleIncludeMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			for (int i = 0; i <= TextureMaskList.Count - 1; i++)
			{
				dependsOn = TextureMaskList[i].SampleIncludeMask(instanceData, spawnRect, TextureMaskType, textureMaskRule, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleExcludeMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			for (int i = 0; i <= TextureMaskList.Count - 1; i++)
			{
				dependsOn = TextureMaskList[i].SampleExcludeMask(instanceData, spawnRect, TextureMaskType, textureMaskRule, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleScaleMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			for (int i = 0; i <= TextureMaskList.Count - 1; i++)
			{
				dependsOn = TextureMaskList[i].SampleScaleMask(instanceData, spawnRect, TextureMaskType, textureMaskRule, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleDensityMask(VegetationInstanceData instanceData, Rect spawnRect, TextureMaskRule textureMaskRule, JobHandle dependsOn)
		{
			for (int i = 0; i <= TextureMaskList.Count - 1; i++)
			{
				dependsOn = TextureMaskList[i].SampleDensityMask(instanceData, spawnRect, TextureMaskType, textureMaskRule, dependsOn);
			}
			return dependsOn;
		}
	}
}
