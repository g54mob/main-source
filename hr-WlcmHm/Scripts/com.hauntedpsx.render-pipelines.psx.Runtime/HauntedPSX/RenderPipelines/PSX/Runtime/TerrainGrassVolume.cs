using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/TerrainGrassVolume")]
	public class TerrainGrassVolume : VolumeComponent
	{
		[Serializable]
		public enum TextureFilterMode
		{
			TextureImportSettings = 0,
			Point = 1,
			PointMipmaps = 2,
			N64 = 3,
			N64Mipmaps = 4
		}

		[Serializable]
		public sealed class TextureFilterModeParameter : VolumeParameter<TextureFilterMode>
		{
			public TextureFilterModeParameter(TextureFilterMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		public TextureFilterModeParameter textureFilterMode = new TextureFilterModeParameter(TextureFilterMode.TextureImportSettings);

		private static TerrainGrassVolume s_Default;

		public static TerrainGrassVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<TerrainGrassVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
