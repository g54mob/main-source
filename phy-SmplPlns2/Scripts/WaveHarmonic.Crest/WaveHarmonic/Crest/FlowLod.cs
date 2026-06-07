using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class FlowLod : Lod<IFlowProvider>
	{
		private new static class ShaderIDs
		{
			public static readonly int s_Flow = Shader.PropertyToID("g_Crest_Flow");
		}

		private const string k_FlowKeyword = "CREST_FLOW_ON_INTERNAL";

		internal static readonly Color s_GizmoColor = new Color(0f, 0f, 1f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Flow";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.black;

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Performance => GraphicsFormat.R16G16_SFloat, 
			LodTextureFormatMode.Precision => GraphicsFormat.R32G32_SFloat, 
			LodTextureFormatMode.Manual => _TextureFormat, 
			_ => throw new NotImplementedException(), 
		};

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		internal FlowLod()
		{
			_Resolution = 128;
			_TextureFormat = GraphicsFormat.R16G16_SFloat;
			_MaximumQueryCount = 1024;
		}

		internal override void Enable()
		{
			base.Enable();
			Shader.EnableKeyword("CREST_FLOW_ON_INTERNAL");
		}

		internal override void Disable()
		{
			base.Disable();
			Shader.DisableKeyword("CREST_FLOW_ON_INTERNAL");
		}

		internal override void BuildCommandBuffer(WaterRenderer water, CommandBuffer buffer)
		{
			float currentTime = water.CurrentTime;
			float num = 1f;
			float num2 = num * 0.5f;
			float num3 = Helpers.Fmod(currentTime, num);
			float num4 = num3 / num2;
			if (num4 > 1f)
			{
				num4 = 2f - num4;
			}
			float z = Helpers.Fmod(currentTime + num2, num);
			float w = 1f - num4;
			Shader.SetGlobalVector(ShaderIDs.s_Flow, new Vector4(num3, num4, z, w));
			base.BuildCommandBuffer(water, buffer);
		}

		private protected override IFlowProvider CreateProvider(bool onEnable)
		{
			base.Queryable?.CleanUp();
			if (!onEnable || !base.Enabled || base.QuerySource != LodQuerySource.GPU)
			{
				return IFlowProvider.None;
			}
			return IFlowProvider.Create(_Water);
		}

		internal override void SetGlobals(bool onEnable)
		{
			base.SetGlobals(onEnable);
			Shader.SetGlobalVector(ShaderIDs.s_Flow, new Vector4(0f, 1f, 0f, 0f));
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}
	}
}
