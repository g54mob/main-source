using UnityEngine;
using WaveHarmonic.Crest.Splines;

namespace WaveHarmonic.Crest
{
	public static class _Extensions
	{
		public static T AddComponent<T>(this GameObject gameObject, LodInputMode mode) where T : LodInput
		{
			T val = gameObject.AddComponent<T>();
			val._Mode = mode;
			if (mode != LodInputMode.Global && mode != LodInputMode.Primitive && mode != LodInputMode.Unset)
			{
				AddData(val, mode);
			}
			val.InferBlend();
			return val;
		}

		private static void AddData<T>(this LodInput input, LodInputMode mode) where T : LodInputData, new()
		{
			input.Data = new T();
			input.Data._Input = input;
		}

		private static void AddData(LodInput input, LodInputMode mode)
		{
			switch (mode)
			{
			case LodInputMode.Renderer:
				if (input is AbsorptionLodInput)
				{
					input.AddData<AbsorptionRendererLodInputData>(mode);
				}
				else if (input is AlbedoLodInput)
				{
					input.AddData<AlbedoRendererLodInputData>(mode);
				}
				else if (input is AnimatedWavesLodInput)
				{
					input.AddData<AnimatedWavesRendererLodInputData>(mode);
				}
				else if (input is ClipLodInput)
				{
					input.AddData<ClipRendererLodInputData>(mode);
				}
				else if (input is DepthLodInput)
				{
					input.AddData<DepthRendererLodInputData>(mode);
				}
				else if (input is DynamicWavesLodInput)
				{
					input.AddData<DynamicWavesRendererLodInputData>(mode);
				}
				else if (input is FlowLodInput)
				{
					input.AddData<FlowRendererLodInputData>(mode);
				}
				else if (input is FoamLodInput)
				{
					input.AddData<FoamRendererLodInputData>(mode);
				}
				else if (input is LevelLodInput)
				{
					input.AddData<LevelRendererLodInputData>(mode);
				}
				else if (input is ScatteringLodInput)
				{
					input.AddData<ScatteringRendererLodInputData>(mode);
				}
				else if (input is ShadowLodInput)
				{
					input.AddData<ShadowRendererLodInputData>(mode);
				}
				else if (input is ShapeWaves)
				{
					input.AddData<ShapeWavesRendererLodInputData>(mode);
				}
				break;
			case LodInputMode.Texture:
				if (input is AbsorptionLodInput)
				{
					input.AddData<AbsorptionTextureLodInputData>(mode);
				}
				else if (input is ClipLodInput)
				{
					input.AddData<ClipTextureLodInputData>(mode);
				}
				else if (input is DepthLodInput)
				{
					input.AddData<DepthTextureLodInputData>(mode);
				}
				else if (input is FlowLodInput)
				{
					input.AddData<FlowTextureLodInputData>(mode);
				}
				else if (input is FoamLodInput)
				{
					input.AddData<FoamTextureLodInputData>(mode);
				}
				else if (input is LevelLodInput)
				{
					input.AddData<LevelTextureLodInputData>(mode);
				}
				else if (input is ScatteringLodInput)
				{
					input.AddData<ScatteringTextureLodInputData>(mode);
				}
				else if (input is ShapeWaves)
				{
					input.AddData<ShapeWavesTextureLodInputData>(mode);
				}
				break;
			case LodInputMode.Spline:
				if (input is AbsorptionLodInput)
				{
					input.AddData<AbsorptionSplineLodInputData>(mode);
				}
				else if (input is FlowLodInput)
				{
					input.AddData<FlowSplineLodInputData>(mode);
				}
				else if (input is FoamLodInput)
				{
					input.AddData<FoamSplineLodInputData>(mode);
				}
				else if (input is LevelLodInput)
				{
					input.AddData<LevelSplineLodInputData>(mode);
				}
				else if (input is ScatteringLodInput)
				{
					input.AddData<ScatteringSplineLodInputData>(mode);
				}
				else if (input is ShapeWaves)
				{
					input.AddData<ShapeWavesSplineLodInputData>(mode);
				}
				break;
			case LodInputMode.Geometry:
				if (input is DepthLodInput)
				{
					input.AddData<DepthGeometryLodInputData>(mode);
				}
				else if (input is LevelLodInput)
				{
					input.AddData<LevelGeometryLodInputData>(mode);
				}
				break;
			case LodInputMode.Primitive:
			case LodInputMode.Global:
				break;
			}
		}
	}
}
