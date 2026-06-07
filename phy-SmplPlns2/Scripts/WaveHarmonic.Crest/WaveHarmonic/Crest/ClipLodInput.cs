using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Clip Input")]
	public sealed class ClipLodInput : LodInput
	{
		[Tooltip("The primitive to render (signed distance) into the simulation.")]
		[SerializeField]
		internal LodInputPrimitive _Primitive = LodInputPrimitive.Cube;

		[Tooltip("Removes clip surface data instead of adding it.")]
		[SerializeField]
		private bool _Inverted;

		[Tooltip("Prevents inputs from cancelling each other out when aligned vertically.\n\nIt is imperfect so custom logic might be needed for your use case.")]
		[SerializeField]
		private bool _WaterHeightDistanceCulling;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private bool _Enabled = true;

		private Rect _Rect;

		internal override LodInputMode DefaultMode => LodInputMode.Primitive;

		private protected override bool FollowHorizontalMotion => true;

		private ComputeShader PrimitiveShader => ScriptableSingleton<WaterResources>.Instance.Compute._ClipPrimitive;

		private static LocalKeyword KeywordInverted => ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveInverted;

		private static LocalKeyword KeywordSphere => ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveSphere;

		private static LocalKeyword KeywordCube => ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveCube;

		private static LocalKeyword KeywordRectangle => ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveRectangle;

		internal override bool Enabled
		{
			get
			{
				bool flag = _Enabled;
				if (flag)
				{
					bool flag2 = ((base.Mode != LodInputMode.Primitive) ? base.Enabled : (base.enabled && PrimitiveShader != null));
					flag = flag2;
				}
				return flag;
			}
		}

		internal override Rect Rect
		{
			get
			{
				if (base.Mode == LodInputMode.Primitive)
				{
					if (_RecalculateBounds)
					{
						_Rect = base.transform.Bounds().RectXZ();
						_RecalculateBounds = false;
					}
					return _Rect;
				}
				return base.Rect;
			}
		}

		internal override Color GizmoColor => ClipLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => ClipLod.s_Inputs;

		public bool Inverted
		{
			get
			{
				return _Inverted;
			}
			set
			{
				_Inverted = value;
			}
		}

		public LodInputPrimitive Primitive
		{
			get
			{
				return _Primitive;
			}
			set
			{
				_Primitive = value;
			}
		}

		public bool WaterHeightDistanceCulling
		{
			get
			{
				return _WaterHeightDistanceCulling;
			}
			set
			{
				_WaterHeightDistanceCulling = value;
			}
		}

		internal override void InferBlend()
		{
			base.InferBlend();
			_Blend = LodInputBlend.Maximum;
		}

		internal override void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
		{
			if (base.Mode == LodInputMode.Primitive)
			{
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, PrimitiveShader, 0);
				propertyWrapperCompute.SetMatrix(WaveHarmonic.Crest.ShaderIDs.s_Matrix, base.transform.worldToLocalMatrix);
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_Position, base.transform.position);
				propertyWrapperCompute.SetFloat(WaveHarmonic.Crest.ShaderIDs.s_Diameter, base.transform.lossyScale.Maximum());
				propertyWrapperCompute.SetKeyword(KeywordInverted, _Inverted);
				propertyWrapperCompute.SetKeyword(KeywordSphere, _Primitive == LodInputPrimitive.Sphere);
				propertyWrapperCompute.SetKeyword(KeywordCube, _Primitive == LodInputPrimitive.Cube);
				propertyWrapperCompute.SetKeyword(KeywordRectangle, _Primitive == LodInputPrimitive.Quad);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
				int num = simulation.Resolution / 8;
				propertyWrapperCompute.Dispatch(num, num, slices);
			}
			else
			{
				base.Draw(simulation, buffer, target, pass, weight, slices);
			}
		}

		private protected override void OnUpdate(WaterRenderer water)
		{
			base.OnUpdate(water);
			if (base.Mode != LodInputMode.Renderer)
			{
				_Enabled = true;
			}
			else if (base.Enabled && base.Data is RendererLodInputData rendererLodInputData && !(rendererLodInputData._Renderer == null) && _WaterHeightDistanceCulling)
			{
				Vector3 position = base.transform.position;
				if (_SampleHeightHelper.SampleHeight(position, out var height))
				{
					position.y = height;
					_Enabled = Mathf.Abs(rendererLodInputData._Renderer.bounds.ClosestPoint(position).y - height) < 1f;
				}
			}
		}
	}
}
