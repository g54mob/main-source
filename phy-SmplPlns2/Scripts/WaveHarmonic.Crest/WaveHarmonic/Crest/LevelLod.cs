using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class LevelLod : Lod
	{
		internal static readonly Color s_GizmoColor = new Color(0.29411766f, 0f, 26f / 51f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Level";

		internal override string Name => "Water Level";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.black;

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override GraphicsFormat RequestedTextureFormat
		{
			get
			{
				switch (_TextureFormatMode)
				{
				case LodTextureFormatMode.Automatic:
				{
					GraphicsFormat result;
					if (base.Water == null)
					{
						result = GraphicsFormat.None;
					}
					else
					{
						GraphicsFormat graphicsFormat = ((base.Water.AnimatedWavesLod.TextureFormatMode != LodTextureFormatMode.Precision) ? GraphicsFormat.R16_SFloat : GraphicsFormat.R32_SFloat);
						result = graphicsFormat;
					}
					return result;
				}
				case LodTextureFormatMode.Performance:
					return GraphicsFormat.R16_SFloat;
				case LodTextureFormatMode.Precision:
					return GraphicsFormat.R32_SFloat;
				case LodTextureFormatMode.Manual:
					return _TextureFormat;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		internal LevelLod()
		{
			_Enabled = false;
			_OverrideResolution = false;
			_TextureFormatMode = LodTextureFormatMode.Automatic;
			_TextureFormat = GraphicsFormat.R16_SFloat;
			_BlurIterations = 4;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}
	}
}
