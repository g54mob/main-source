using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Water Depth Input")]
	public sealed class DepthLodInput : LodInput
	{
		internal new static class ShaderIDs
		{
			public static readonly int s_HeightOffset = Shader.PropertyToID("_Crest_HeightOffset");

			public static readonly int s_SDF = Shader.PropertyToID("_Crest_SDF");
		}

		[Tooltip("Whether the data is relative to the input height.\n\nUseful for procedural placement.")]
		[SerializeField]
		internal bool _Relative = true;

		[Tooltip("Whether to copy the signed distance field.")]
		[SerializeField]
		internal bool _CopySignedDistanceField;

		internal override LodInputMode DefaultMode => LodInputMode.Geometry;

		internal override Color GizmoColor => DepthLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => DepthLod.s_Inputs;

		public bool CopySignedDistanceField
		{
			get
			{
				return _CopySignedDistanceField;
			}
			set
			{
				_CopySignedDistanceField = value;
			}
		}

		public bool Relative
		{
			get
			{
				return _Relative;
			}
			set
			{
				_Relative = value;
			}
		}

		internal override void InferBlend()
		{
			base.InferBlend();
			_Blend = LodInputBlend.Maximum;
		}

		internal override void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			PropertyWrapperBuffer propertyWrapperBuffer = new PropertyWrapperBuffer(buffer);
			propertyWrapperBuffer.SetFloat(ShaderIDs.s_HeightOffset, _Relative ? base.transform.position.y : 0f);
			if (base.IsCompute)
			{
				propertyWrapperBuffer.SetInteger(ShaderIDs.s_SDF, _CopySignedDistanceField ? 1 : 0);
				buffer.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Compute._DepthTexture, ScriptableSingleton<WaterResources>.Instance.Keywords.DepthTextureSDF, simulation._Water._DepthLod._EnableSignedDistanceFields);
			}
			base.Draw(simulation, buffer, target, pass, weight, slice);
		}
	}
}
