using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class AbsorptionLod : ColorLod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_SampleAbsorptionSimulation = Shader.PropertyToID("g_Crest_SampleAbsorptionSimulation");
		}

		internal static readonly Color s_GizmoColor = new Color(1f, 0.64705884f, 0f, 0.5f);

		internal static readonly Color s_DefaultColor = new Color(0.342f, 0.695f, 0.85f, 0.102f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Absorption";

		internal override string Name => "Absorption";

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
				if (surface.Material != null && surface.Material.HasVector(WaterRenderer.ShaderIDs.s_Absorption))
				{
					result = surface.Material.GetVector(WaterRenderer.ShaderIDs.s_Absorption);
					result.a = 0f;
				}
				return result;
			}
		}

		private protected override int GlobalShaderID => ShaderIDs.s_SampleAbsorptionSimulation;

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		internal AbsorptionLod()
		{
			_ShorelineColor = (s_DefaultColor * 1.5f).Clamped01();
		}

		private protected override void SetShorelineColor(Color previous, Color current)
		{
			if (!(previous == current))
			{
				_ShorelineColorValue = WaterRenderer.CalculateAbsorptionValueFromColor(current);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}
	}
}
