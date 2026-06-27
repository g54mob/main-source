using System;
using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class BlocksModule : CozyBiomeModuleBase<BlocksModule>
	{
		[Serializable]
		public class Block
		{
			[Range(0f, 1f)]
			public float startKey;

			[Range(0f, 1f)]
			public float endKey;

			public BlocksBlendable[] colorBlocks;

			[HideInInspector]
			public int seed;

			public BlocksBlendable selectedBlock;

			public void GetColorBlock(CozyWeather weather)
			{
				if (colorBlocks.Length == 0)
				{
					return;
				}
				BlocksBlendable blocksBlendable = null;
				List<float> list = new List<float>();
				float num = 0f;
				BlocksBlendable[] array = colorBlocks;
				foreach (BlocksBlendable blocksBlendable2 in array)
				{
					if ((bool)blocksBlendable2)
					{
						float num2 = blocksBlendable2.chance;
						list.Add(num2);
						num += num2;
					}
				}
				if (num == 0f)
				{
					selectedBlock = colorBlocks[0];
					return;
				}
				float num3 = (float)new System.Random(seed).NextDouble() * num;
				int num4 = 0;
				float num5 = 0f;
				while (num5 <= num3)
				{
					if (num3 >= num5 && num3 < num5 + list[num4])
					{
						blocksBlendable = colorBlocks[num4];
						break;
					}
					num5 += list[num4];
					num4++;
				}
				if (!blocksBlendable)
				{
					blocksBlendable = colorBlocks[0];
				}
				selectedBlock = blocksBlendable;
			}

			public Block(float _startKey, float _endKey, BlocksBlendable[] _blocks)
			{
				startKey = _startKey;
				endKey = _endKey;
				colorBlocks = _blocks;
			}

			public Block(CozyTransitModule.TimeBlock block, BlocksBlendable[] _blocks)
			{
				startKey = block.start;
				endKey = block.end;
				colorBlocks = _blocks;
			}
		}

		[ColorUsage(true, true)]
		public Color skyZenithColor;

		[ColorUsage(true, true)]
		public Color skyHorizonColor;

		[ColorUsage(true, true)]
		public Color cloudColor;

		[ColorUsage(true, true)]
		public Color cloudHighlightColor;

		[ColorUsage(true, true)]
		public Color highAltitudeCloudColor;

		[ColorUsage(true, true)]
		public Color sunlightColor;

		[ColorUsage(true, true)]
		public Color starColor;

		[ColorUsage(true, true)]
		public Color ambientLightHorizonColor;

		[ColorUsage(true, true)]
		public Color ambientLightZenithColor;

		public float galaxyIntensity;

		[ColorUsage(true, true)]
		public Color fogColor1;

		[ColorUsage(true, true)]
		public Color fogColor2;

		[ColorUsage(true, true)]
		public Color fogColor3;

		[ColorUsage(true, true)]
		public Color fogColor4;

		[ColorUsage(true, true)]
		public Color fogColor5;

		[ColorUsage(true, true)]
		public Color fogFlareColor;

		public float gradientExponent = 0.364f;

		public float ambientLightMultiplier;

		public float sunSize = 0.7f;

		[ColorUsage(true, true)]
		public Color sunColor;

		public float sunFalloff = 43.7f;

		[ColorUsage(true, true)]
		public Color sunFlareColor;

		public float moonFalloff = 24.4f;

		[ColorUsage(true, true)]
		public Color moonlightColor;

		[ColorUsage(true, true)]
		public Color moonFlareColor;

		[ColorUsage(true, true)]
		public Color galaxy1Color;

		[ColorUsage(true, true)]
		public Color galaxy2Color;

		[ColorUsage(true, true)]
		public Color galaxy3Color;

		[ColorUsage(true, true)]
		public Color lightScatteringColor;

		public float fogStart1 = 2f;

		public float fogStart2 = 5f;

		public float fogStart3 = 10f;

		public float fogStart4 = 30f;

		public float fogVariationAmount = 0.5f;

		public float fogHeight = 0.85f;

		public float fogSmoothness = 0.5f;

		public float fogDensityMultiplier;

		public float fogLightFlareIntensity = 1f;

		public float fogLightFlareFalloff = 21f;

		public float fogLightFlareSquish = 1f;

		[ColorUsage(true, true)]
		public Color cloudMoonColor;

		[ColorUsage(true, true)]
		public Color cloudTextureColor;

		public float cloudSunHighlightFalloff = 14.1f;

		public float cloudMoonHighlightFalloff = 22.9f;

		public float rainbowIntensity;

		public BlockProfile blockProfile;

		public AtmosphereProfile defaultSettings;

		public List<Block> blocks = new List<Block>();

		public List<float> keys = new List<float>();

		public BlocksBlendable currentBlock;

		public BlocksBlendable testColorBlock;

		public bool useSingleBlock;

		public override void InitializeModule()
		{
			base.InitializeModule();
			base.SetupModule(new Type[1] { typeof(CozyTransitModule) });
			if (base.isBiomeModule)
			{
				AddBiome();
				return;
			}
			testColorBlock = null;
			GetBlocks();
		}

		public override void PropogateVariables()
		{
			if (!base.isBiomeModule)
			{
				if ((bool)testColorBlock)
				{
					SingleBlock(testColorBlock);
				}
				else if (blocks.Count > 0)
				{
					SetColorsFromBlocks();
				}
				else if ((bool)blockProfile)
				{
					GetBlocks();
				}
				ComputeBiomeWeights();
				ApplyPropertiesToWeatherSphere();
			}
		}

		public void ApplyPropertiesToWeatherSphere()
		{
			ResetWeatherSphere();
			base.weatherSphere.gradientExponent = Mathf.Lerp(base.weatherSphere.gradientExponent, gradientExponent, weight);
			base.weatherSphere.ambientLightHorizonColor = Color.Lerp(base.weatherSphere.ambientLightHorizonColor, ambientLightHorizonColor, weight);
			base.weatherSphere.ambientLightZenithColor = Color.Lerp(base.weatherSphere.ambientLightZenithColor, ambientLightZenithColor, weight);
			base.weatherSphere.ambientLightMultiplier = Mathf.Lerp(base.weatherSphere.ambientLightMultiplier, ambientLightMultiplier, weight);
			base.weatherSphere.cloudColor = Color.Lerp(base.weatherSphere.cloudColor, cloudColor, weight);
			base.weatherSphere.cloudHighlightColor = Color.Lerp(base.weatherSphere.cloudHighlightColor, cloudHighlightColor, weight);
			base.weatherSphere.cloudMoonColor = Color.Lerp(base.weatherSphere.cloudMoonColor, cloudMoonColor, weight);
			base.weatherSphere.cloudMoonHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudMoonHighlightFalloff, cloudMoonHighlightFalloff, weight);
			base.weatherSphere.cloudSunHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudSunHighlightFalloff, cloudSunHighlightFalloff, weight);
			base.weatherSphere.cloudTextureColor = Color.Lerp(base.weatherSphere.cloudTextureColor, cloudTextureColor, weight);
			base.weatherSphere.fogColor1 = Color.Lerp(base.weatherSphere.fogColor1, fogColor1, weight);
			base.weatherSphere.fogColor2 = Color.Lerp(base.weatherSphere.fogColor2, fogColor2, weight);
			base.weatherSphere.fogColor3 = Color.Lerp(base.weatherSphere.fogColor3, fogColor3, weight);
			base.weatherSphere.fogColor4 = Color.Lerp(base.weatherSphere.fogColor4, fogColor4, weight);
			base.weatherSphere.fogColor5 = Color.Lerp(base.weatherSphere.fogColor5, fogColor5, weight);
			base.weatherSphere.fogStart1 = Mathf.Lerp(base.weatherSphere.fogStart1, fogStart1, weight);
			base.weatherSphere.fogStart2 = Mathf.Lerp(base.weatherSphere.fogStart2, fogStart2, weight);
			base.weatherSphere.fogStart3 = Mathf.Lerp(base.weatherSphere.fogStart3, fogStart3, weight);
			base.weatherSphere.fogStart4 = Mathf.Lerp(base.weatherSphere.fogStart4, fogStart4, weight);
			base.weatherSphere.fogFlareColor = Color.Lerp(base.weatherSphere.fogFlareColor, fogFlareColor, weight);
			base.weatherSphere.fogHeight = Mathf.Lerp(base.weatherSphere.fogHeight, fogHeight, weight);
			base.weatherSphere.fogSmoothness = Mathf.Lerp(base.weatherSphere.fogSmoothness, fogSmoothness, weight);
			base.weatherSphere.fogDensityMultiplier = Mathf.Lerp(base.weatherSphere.fogDensityMultiplier, fogDensityMultiplier, weight);
			base.weatherSphere.fogLightFlareFalloff = Mathf.Lerp(base.weatherSphere.fogLightFlareFalloff, fogLightFlareFalloff, weight);
			base.weatherSphere.fogLightFlareIntensity = Mathf.Lerp(base.weatherSphere.fogLightFlareIntensity, fogLightFlareIntensity, weight);
			base.weatherSphere.fogLightFlareSquish = Mathf.Lerp(base.weatherSphere.fogLightFlareSquish, fogLightFlareSquish, weight);
			base.weatherSphere.galaxy1Color = Color.Lerp(base.weatherSphere.galaxy1Color, galaxy1Color, weight);
			base.weatherSphere.galaxy2Color = Color.Lerp(base.weatherSphere.galaxy2Color, galaxy2Color, weight);
			base.weatherSphere.galaxy3Color = Color.Lerp(base.weatherSphere.galaxy3Color, galaxy3Color, weight);
			base.weatherSphere.galaxyIntensity = Mathf.Lerp(base.weatherSphere.galaxyIntensity, galaxyIntensity, weight);
			base.weatherSphere.highAltitudeCloudColor = Color.Lerp(base.weatherSphere.highAltitudeCloudColor, highAltitudeCloudColor, weight);
			base.weatherSphere.lightScatteringColor = Color.Lerp(base.weatherSphere.lightScatteringColor, lightScatteringColor, weight);
			base.weatherSphere.moonlightColor = Color.Lerp(base.weatherSphere.moonlightColor, moonlightColor, weight);
			base.weatherSphere.moonFalloff = Mathf.Lerp(base.weatherSphere.moonFalloff, moonFalloff, weight);
			base.weatherSphere.moonFlareColor = Color.Lerp(base.weatherSphere.moonFlareColor, moonFlareColor, weight);
			base.weatherSphere.skyHorizonColor = Color.Lerp(base.weatherSphere.skyHorizonColor, skyHorizonColor, weight);
			base.weatherSphere.skyZenithColor = Color.Lerp(base.weatherSphere.skyZenithColor, skyZenithColor, weight);
			base.weatherSphere.starColor = Color.Lerp(base.weatherSphere.starColor, starColor, weight);
			base.weatherSphere.sunColor = Color.Lerp(base.weatherSphere.sunColor, sunColor, weight);
			base.weatherSphere.sunFalloff = Mathf.Lerp(base.weatherSphere.sunFalloff, sunFalloff, weight);
			base.weatherSphere.sunFlareColor = Color.Lerp(base.weatherSphere.sunFlareColor, sunFlareColor, weight);
			base.weatherSphere.sunlightColor = Color.Lerp(base.weatherSphere.sunlightColor, sunlightColor, weight);
			base.weatherSphere.sunSize = Mathf.Lerp(base.weatherSphere.sunSize, sunSize, weight);
			foreach (BlocksModule biome in biomes)
			{
				if (!(biome == null) && biome.system.weight != 0f && biome.weight > 0f)
				{
					base.weatherSphere.gradientExponent = Mathf.Lerp(base.weatherSphere.gradientExponent, biome.gradientExponent, biome.weight);
					base.weatherSphere.ambientLightHorizonColor = Color.Lerp(base.weatherSphere.ambientLightHorizonColor, biome.ambientLightHorizonColor, biome.weight);
					base.weatherSphere.ambientLightZenithColor = Color.Lerp(base.weatherSphere.ambientLightZenithColor, biome.skyZenithColor, biome.weight);
					base.weatherSphere.ambientLightMultiplier = Mathf.Lerp(base.weatherSphere.ambientLightMultiplier, biome.ambientLightMultiplier, biome.weight);
					base.weatherSphere.cloudColor = Color.Lerp(base.weatherSphere.cloudColor, biome.cloudColor, biome.weight);
					base.weatherSphere.cloudHighlightColor = Color.Lerp(base.weatherSphere.cloudHighlightColor, biome.cloudHighlightColor, biome.weight);
					base.weatherSphere.cloudMoonColor = Color.Lerp(base.weatherSphere.cloudMoonColor, biome.cloudMoonColor, biome.weight);
					base.weatherSphere.cloudMoonHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudMoonHighlightFalloff, biome.cloudMoonHighlightFalloff, biome.weight);
					base.weatherSphere.cloudSunHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudSunHighlightFalloff, biome.cloudSunHighlightFalloff, biome.weight);
					base.weatherSphere.cloudTextureColor = Color.Lerp(base.weatherSphere.cloudTextureColor, biome.cloudTextureColor, biome.weight);
					base.weatherSphere.fogColor1 = Color.Lerp(base.weatherSphere.fogColor1, biome.fogColor1, biome.weight);
					base.weatherSphere.fogColor2 = Color.Lerp(base.weatherSphere.fogColor2, biome.fogColor2, biome.weight);
					base.weatherSphere.fogColor3 = Color.Lerp(base.weatherSphere.fogColor3, biome.fogColor3, biome.weight);
					base.weatherSphere.fogColor4 = Color.Lerp(base.weatherSphere.fogColor4, biome.fogColor4, biome.weight);
					base.weatherSphere.fogColor5 = Color.Lerp(base.weatherSphere.fogColor5, biome.fogColor5, biome.weight);
					base.weatherSphere.fogStart1 = Mathf.Lerp(base.weatherSphere.fogStart1, biome.fogStart1, biome.weight);
					base.weatherSphere.fogStart2 = Mathf.Lerp(base.weatherSphere.fogStart2, biome.fogStart2, biome.weight);
					base.weatherSphere.fogStart3 = Mathf.Lerp(base.weatherSphere.fogStart3, biome.fogStart3, biome.weight);
					base.weatherSphere.fogStart4 = Mathf.Lerp(base.weatherSphere.fogStart4, biome.fogStart4, biome.weight);
					base.weatherSphere.fogFlareColor = Color.Lerp(base.weatherSphere.fogFlareColor, biome.fogFlareColor, biome.weight);
					base.weatherSphere.fogHeight = Mathf.Lerp(base.weatherSphere.fogHeight, biome.fogHeight, biome.weight);
					base.weatherSphere.fogSmoothness = Mathf.Lerp(base.weatherSphere.fogSmoothness, biome.fogSmoothness, biome.weight);
					base.weatherSphere.fogDensityMultiplier = Mathf.Lerp(base.weatherSphere.fogDensityMultiplier, biome.fogDensityMultiplier, biome.weight);
					base.weatherSphere.fogLightFlareFalloff = Mathf.Lerp(base.weatherSphere.fogLightFlareFalloff, biome.fogLightFlareFalloff, biome.weight);
					base.weatherSphere.fogLightFlareIntensity = Mathf.Lerp(base.weatherSphere.fogLightFlareIntensity, biome.fogLightFlareIntensity, biome.weight);
					base.weatherSphere.fogLightFlareSquish = Mathf.Lerp(base.weatherSphere.fogLightFlareSquish, biome.fogLightFlareSquish, biome.weight);
					base.weatherSphere.galaxy1Color = Color.Lerp(base.weatherSphere.galaxy1Color, biome.galaxy1Color, biome.weight);
					base.weatherSphere.galaxy2Color = Color.Lerp(base.weatherSphere.galaxy2Color, biome.galaxy2Color, biome.weight);
					base.weatherSphere.galaxy3Color = Color.Lerp(base.weatherSphere.galaxy3Color, biome.galaxy3Color, biome.weight);
					base.weatherSphere.galaxyIntensity = Mathf.Lerp(base.weatherSphere.galaxyIntensity, biome.galaxyIntensity, biome.weight);
					base.weatherSphere.highAltitudeCloudColor = Color.Lerp(base.weatherSphere.highAltitudeCloudColor, biome.highAltitudeCloudColor, biome.weight);
					base.weatherSphere.lightScatteringColor = Color.Lerp(base.weatherSphere.lightScatteringColor, biome.lightScatteringColor, biome.weight);
					base.weatherSphere.moonlightColor = Color.Lerp(base.weatherSphere.moonlightColor, biome.moonlightColor, biome.weight);
					base.weatherSphere.moonFalloff = Mathf.Lerp(base.weatherSphere.moonFalloff, biome.moonFalloff, biome.weight);
					base.weatherSphere.moonFlareColor = Color.Lerp(base.weatherSphere.moonFlareColor, biome.moonFlareColor, biome.weight);
					base.weatherSphere.skyHorizonColor = Color.Lerp(base.weatherSphere.skyHorizonColor, biome.skyHorizonColor, biome.weight);
					base.weatherSphere.skyZenithColor = Color.Lerp(base.weatherSphere.skyZenithColor, biome.skyZenithColor, biome.weight);
					base.weatherSphere.starColor = Color.Lerp(base.weatherSphere.starColor, biome.starColor, biome.weight);
					base.weatherSphere.sunColor = Color.Lerp(base.weatherSphere.sunColor, biome.sunColor, biome.weight);
					base.weatherSphere.sunFalloff = Mathf.Lerp(base.weatherSphere.sunFalloff, biome.sunFalloff, biome.weight);
					base.weatherSphere.sunFlareColor = Color.Lerp(base.weatherSphere.sunFlareColor, biome.sunFlareColor, biome.weight);
					base.weatherSphere.sunlightColor = Color.Lerp(base.weatherSphere.sunlightColor, biome.sunlightColor, biome.weight);
					base.weatherSphere.sunSize = Mathf.Lerp(base.weatherSphere.sunSize, biome.sunSize, biome.weight);
				}
			}
			base.weatherSphere.UpdateShaderVariables();
		}

		private void ResetWeatherSphere()
		{
			base.weatherSphere.gradientExponent = 0f;
			base.weatherSphere.ambientLightHorizonColor = Color.clear;
			base.weatherSphere.ambientLightZenithColor = Color.clear;
			base.weatherSphere.ambientLightMultiplier = 0f;
			base.weatherSphere.cloudColor = Color.clear;
			base.weatherSphere.cloudHighlightColor = Color.clear;
			base.weatherSphere.cloudMoonColor = Color.clear;
			base.weatherSphere.cloudMoonHighlightFalloff = 0f;
			base.weatherSphere.cloudSunHighlightFalloff = 0f;
			base.weatherSphere.cloudTextureColor = Color.clear;
			base.weatherSphere.fogColor1 = Color.clear;
			base.weatherSphere.fogColor2 = Color.clear;
			base.weatherSphere.fogColor3 = Color.clear;
			base.weatherSphere.fogColor4 = Color.clear;
			base.weatherSphere.fogColor5 = Color.clear;
			base.weatherSphere.fogStart1 = 0f;
			base.weatherSphere.fogStart2 = 0f;
			base.weatherSphere.fogStart3 = 0f;
			base.weatherSphere.fogStart4 = 0f;
			base.weatherSphere.fogFlareColor = Color.clear;
			base.weatherSphere.fogHeight = 0f;
			base.weatherSphere.fogDensityMultiplier = 0f;
			base.weatherSphere.fogLightFlareFalloff = 0f;
			base.weatherSphere.fogLightFlareIntensity = 0f;
			base.weatherSphere.fogLightFlareSquish = 0f;
			base.weatherSphere.galaxy1Color = Color.clear;
			base.weatherSphere.galaxy2Color = Color.clear;
			base.weatherSphere.galaxy3Color = Color.clear;
			base.weatherSphere.galaxyIntensity = 0f;
			base.weatherSphere.highAltitudeCloudColor = Color.clear;
			base.weatherSphere.lightScatteringColor = Color.clear;
			base.weatherSphere.moonlightColor = Color.clear;
			base.weatherSphere.moonFalloff = 0f;
			base.weatherSphere.moonFlareColor = Color.clear;
			base.weatherSphere.skyHorizonColor = Color.clear;
			base.weatherSphere.skyZenithColor = Color.clear;
			base.weatherSphere.starColor = Color.clear;
			base.weatherSphere.sunColor = Color.clear;
			base.weatherSphere.sunFalloff = 0f;
			base.weatherSphere.sunFlareColor = Color.clear;
			base.weatherSphere.sunlightColor = Color.clear;
			base.weatherSphere.sunSize = 0f;
		}

		public void GetBlocks()
		{
			if (blockProfile == null)
			{
				return;
			}
			List<Block> list = new List<Block>();
			new List<BlocksBlendable>();
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.dawn))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.dawnBlock, blockProfile.dawn.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.morning))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.morningBlock, blockProfile.morning.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.day))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.dayBlock, blockProfile.day.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.afternoon))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.afternoonBlock, blockProfile.afternoon.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.evening))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.eveningBlock, blockProfile.evening.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.twilight))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.twilightBlock, blockProfile.twilight.ToArray()));
			}
			if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.night))
			{
				list.Add(new Block(base.weatherSphere.timeModule.transit.nightBlock, blockProfile.night.ToArray()));
			}
			blocks = list;
			foreach (Block block in blocks)
			{
				block.GetColorBlock(base.weatherSphere);
			}
		}

		private void SetColorsFromBlocks()
		{
			float num = (base.weatherSphere.usePhysicalSunHeight ? base.weatherSphere.modifiedDayPercentage : base.weatherSphere.dayPercentage);
			if (keys.Count > 0)
			{
				keys.Clear();
			}
			foreach (Block block in blocks)
			{
				if (block.colorBlocks.Length != 0)
				{
					keys.Add(block.startKey);
					keys.Add(block.endKey);
				}
			}
			int num2 = 0;
			foreach (float key in keys)
			{
				if (num > key)
				{
					num2++;
					if (num2 == keys.Count)
					{
						List<Block> list = blocks;
						SingleBlock(list[list.Count - 1].selectedBlock);
						blocks[0].GetColorBlock(base.weatherSphere);
					}
					continue;
				}
				BlocksBlendable selectedBlock;
				if (num2 <= 1)
				{
					List<Block> list2 = blocks;
					selectedBlock = list2[list2.Count - 1].selectedBlock;
				}
				else
				{
					selectedBlock = blocks[num2 / 2 - 1].selectedBlock;
				}
				BlocksBlendable blocksBlendable = selectedBlock;
				if (num2 % 2 == 1)
				{
					TwoBlock(blocksBlendable, blocks[Mathf.FloorToInt(num2 / 2)].selectedBlock, (num - keys[num2 - 1]) / (key - keys[num2 - 1]));
					break;
				}
				SingleBlock(blocksBlendable);
				if (num2 == keys.Count - 2)
				{
					blocks[0].seed = new System.Random().Next();
					blocks[0].GetColorBlock(base.weatherSphere);
				}
				else
				{
					blocks[Mathf.FloorToInt(num2 / 2) + 1].seed = new System.Random().Next();
					blocks[Mathf.FloorToInt(num2 / 2) + 1].GetColorBlock(base.weatherSphere);
				}
				break;
			}
		}

		private void SingleBlock(BlocksBlendable colorBlock)
		{
			if (!(colorBlock == null))
			{
				colorBlock.SingleBlockBlend(this);
				currentBlock = colorBlock;
			}
		}

		private void TwoBlock(BlocksBlendable colorBlock1, BlocksBlendable colorBlock2, float blend)
		{
			if (!(colorBlock1 == null) && !(colorBlock2 == null))
			{
				ColorBlock values = colorBlock1.GetValues(this);
				ColorBlock values2 = colorBlock2.GetValues(this);
				gradientExponent = Mathf.Lerp(values.gradientExponent, values2.gradientExponent, blend);
				ambientLightHorizonColor = Color.Lerp(values.ambientLightHorizonColor, values2.ambientLightHorizonColor, blend);
				ambientLightZenithColor = Color.Lerp(values.ambientLightZenithColor, values2.ambientLightZenithColor, blend);
				ambientLightMultiplier = Mathf.Lerp(values.ambientLightMultiplier, values2.ambientLightMultiplier, blend);
				cloudColor = Color.Lerp(values.cloudColor, values2.cloudColor, blend);
				cloudHighlightColor = Color.Lerp(values.cloudHighlightColor, values2.cloudHighlightColor, blend);
				cloudMoonColor = Color.Lerp(values.cloudMoonColor, values2.cloudMoonColor, blend);
				cloudMoonHighlightFalloff = Mathf.Lerp(values.cloudMoonHighlightFalloff, values2.cloudMoonHighlightFalloff, blend);
				cloudSunHighlightFalloff = Mathf.Lerp(values.cloudSunHighlightFalloff, values2.cloudSunHighlightFalloff, blend);
				cloudTextureColor = Color.Lerp(values.cloudTextureColor, values2.cloudTextureColor, blend);
				fogColor1 = Color.Lerp(values.fogColor1, values2.fogColor1, blend);
				fogColor2 = Color.Lerp(values.fogColor2, values2.fogColor2, blend);
				fogColor3 = Color.Lerp(values.fogColor3, values2.fogColor3, blend);
				fogColor4 = Color.Lerp(values.fogColor4, values2.fogColor4, blend);
				fogColor5 = Color.Lerp(values.fogColor5, values2.fogColor5, blend);
				fogStart1 = Mathf.Lerp(values.fogStart1, values2.fogStart1, blend);
				fogStart2 = Mathf.Lerp(values.fogStart2, values2.fogStart2, blend);
				fogStart3 = Mathf.Lerp(values.fogStart3, values2.fogStart3, blend);
				fogStart4 = Mathf.Lerp(values.fogStart4, values2.fogStart4, blend);
				fogFlareColor = Color.Lerp(values.fogFlareColor, values2.fogFlareColor, blend);
				fogHeight = Mathf.Lerp(values.fogHeight, values2.fogHeight, blend);
				fogSmoothness = Mathf.Lerp(values.fogSmoothness, values2.fogSmoothness, blend);
				fogDensityMultiplier = Mathf.Lerp(values.fogDensity, values2.fogDensity, blend);
				fogLightFlareFalloff = Mathf.Lerp(values.fogLightFlareFalloff, values2.fogLightFlareFalloff, blend);
				fogLightFlareIntensity = Mathf.Lerp(values.fogLightFlareIntensity, values2.fogLightFlareIntensity, blend);
				fogLightFlareSquish = Mathf.Lerp(values.fogLightFlareSquish, values2.fogLightFlareSquish, blend);
				galaxy1Color = Color.Lerp(values.galaxy1Color, values2.galaxy1Color, blend);
				galaxy2Color = Color.Lerp(values.galaxy2Color, values2.galaxy2Color, blend);
				galaxy3Color = Color.Lerp(values.galaxy3Color, values2.galaxy3Color, blend);
				galaxyIntensity = Mathf.Lerp(values.galaxyIntensity, values2.galaxyIntensity, blend);
				highAltitudeCloudColor = Color.Lerp(values.highAltitudeCloudColor, values2.highAltitudeCloudColor, blend);
				lightScatteringColor = Color.Lerp(values.lightScatteringColor, values2.lightScatteringColor, blend);
				moonlightColor = Color.Lerp(values.moonlightColor, values2.moonlightColor, blend);
				moonFalloff = Mathf.Lerp(values.moonFalloff, values2.moonFalloff, blend);
				moonFlareColor = Color.Lerp(values.moonFlareColor, values2.moonFlareColor, blend);
				skyHorizonColor = Color.Lerp(values.skyHorizonColor, values2.skyHorizonColor, blend);
				skyZenithColor = Color.Lerp(values.skyZenithColor, values2.skyZenithColor, blend);
				starColor = Color.Lerp(values.starColor, values2.starColor, blend);
				sunColor = Color.Lerp(values.sunColor, values2.sunColor, blend);
				sunFalloff = Mathf.Lerp(values.sunFalloff, values2.sunFalloff, blend);
				sunFlareColor = Color.Lerp(values.sunFlareColor, values2.sunFlareColor, blend);
				sunlightColor = Color.Lerp(values.sunlightColor, values2.sunlightColor, blend);
				if (values.extension != null && values2.extension != null)
				{
					values.extension.TwoBlock(values2.extension, blend);
				}
				currentBlock = (((double)blend > 0.5) ? colorBlock2 : colorBlock1);
			}
		}
	}
}
