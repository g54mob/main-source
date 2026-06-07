using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class AlbedoLod : Lod
	{
		internal static readonly Color s_GizmoColor = new Color(1f, 0f, 1f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Albedo";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.clear;

		private protected override bool NeedToReadWriteTextureData => base.Blur;

		internal override bool SkipEndOfFrame => true;

		private protected override GraphicsFormat RequestedTextureFormat
		{
			get
			{
				if (_TextureFormatMode == LodTextureFormatMode.Manual)
				{
					return _TextureFormat;
				}
				return GraphicsFormat.R8G8B8A8_UNorm;
			}
		}

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		internal AlbedoLod()
		{
			_Resolution = 768;
			_TextureFormat = GraphicsFormat.R8G8B8A8_UNorm;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}
	}
}
