using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class ScatteringLod : ColorLod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_SampleScatteringSimulation = Shader.PropertyToID("g_Crest_SampleScatteringSimulation");
		}

		internal static readonly Color s_GizmoColor = new Color(1f, 0.64705884f, 0f, 0.5f);

		internal static readonly Color s_DefaultColor = new Color(0f, 0.098f, 0.2f, 1f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Scattering";

		internal override string Name => "Scattering";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override bool RequiresClearBorder => true;

		private protected override bool AlwaysClear => true;

		private protected override Color ClearColor
		{
			get
			{
				Color result = Color.clear;
				SurfaceRenderer surface = _Water.Surface;
				if (surface.Material != null && surface.Material.HasColor(WaterRenderer.ShaderIDs.s_Scattering))
				{
					result = surface.Material.GetColor(WaterRenderer.ShaderIDs.s_Scattering).MaybeLinear();
					result.a = 0f;
				}
				return result;
			}
		}

		private protected override int GlobalShaderID => ShaderIDs.s_SampleScatteringSimulation;

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		internal ScatteringLod()
		{
			_ShorelineColor = (s_DefaultColor * 6f).Clamped01();
		}

		private protected override void SetShorelineColor(Color previous, Color current)
		{
			if (!(previous == current))
			{
				_ShorelineColorValue = current.MaybeLinear();
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}
	}
}
