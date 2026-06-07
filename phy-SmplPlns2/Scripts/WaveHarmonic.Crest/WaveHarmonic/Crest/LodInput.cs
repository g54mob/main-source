using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	public abstract class LodInput : ManagedBehaviour<WaterRenderer>
	{
		internal static class ShaderIDs
		{
			public static int s_Weight = Shader.PropertyToID("_Crest_Weight");

			public static int s_DisplacementAtInputPosition = Shader.PropertyToID("_Crest_DisplacementAtInputPosition");

			public static readonly int s_BlendSource = Shader.PropertyToID("_Crest_BlendSource");

			public static readonly int s_BlendTarget = Shader.PropertyToID("_Crest_BlendTarget");

			public static readonly int s_BlendOperation = Shader.PropertyToID("_Crest_BlendOperation");
		}

		private sealed class Input : ILodInput
		{
			private readonly LodInput _Input;

			public bool Enabled => _Input.Enabled;

			public bool IsCompute => _Input.IsCompute;

			public int Queue => _Input.Queue;

			public int Pass => _Input.Pass;

			public Rect Rect => _Input.Rect;

			public MonoBehaviour Component => _Input;

			public IReportsHeight HeightReporter => _Input._HeightReporter;

			public IReportsDisplacement DisplacementReporter => _Input._DisplacementReporter;

			public IReportWaveDisplacement WaveDisplacementReporter => _Input._WaveDisplacementReporter;

			public Input(LodInput input)
			{
				_Input = input;
			}

			public float Filter(WaterRenderer water, int slice)
			{
				return _Input.Filter(water, slice);
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
			{
				_Input.Draw(lod, buffer, target, pass, weight, slice);
			}
		}

		[Tooltip("The mode for this input.\n\nSee the manual for more details about input modes. Use AddComponent(LodInputMode) to set the mode via scripting. The mode cannot be changed after creation.")]
		[SerializeField]
		internal LodInputMode _Mode;

		[Tooltip("Scales the input.")]
		[SerializeField]
		private float _Weight = 1f;

		[Tooltip("The order this input will render.\n\nOrder is Queue plus SiblingIndex")]
		[SerializeField]
		private int _Queue;

		[Tooltip("How this input blends into existing data.\n\nSimilar to blend operations in shaders. For inputs which have materials, use the blend functionality on the shader/material.")]
		[SerializeField]
		internal LodInputBlend _Blend = LodInputBlend.Additive;

		[Tooltip("The width of the feathering to soften the edges to blend inputs.\n\nInputs that do not support feathering will have this field disabled or hidden in UI.")]
		[SerializeField]
		private float _FeatherWidth = 0.1f;

		[Tooltip("How this input responds to horizontal displacement.\n\nIf false, data will not move horizontally with the waves. Has a small performance overhead when disabled. Only suitable for inputs of small size.")]
		[SerializeField]
		private protected bool _FollowHorizontalWaveMotion;

		[SerializeReference]
		internal LodInputData _Data;

		[SerializeField]
		internal bool _DrawBounds;

		internal const int k_DebugGroupOrder = 10;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private Vector3 _Displacement;

		private protected bool _RecalculateBounds = true;

		private Input _Input;

		private protected IReportsHeight _HeightReporter;

		internal IReportsDisplacement _DisplacementReporter;

		private protected IReportWaveDisplacement _WaveDisplacementReporter;

		internal abstract Color GizmoColor { get; }

		internal abstract LodInputMode DefaultMode { get; }

		private protected abstract SortedList<int, ILodInput> Inputs { get; }

		public bool ForceRenderingOff { get; set; }

		public LodInputData Data
		{
			get
			{
				return _Data;
			}
			internal set
			{
				_Data = value;
			}
		}

		internal bool IsCompute
		{
			get
			{
				LodInputMode mode = Mode;
				return mode == LodInputMode.Texture || mode == LodInputMode.Paint || mode == LodInputMode.Global || mode == LodInputMode.Primitive;
			}
		}

		internal virtual int Pass => -1;

		internal virtual Rect Rect
		{
			get
			{
				Rect result = Rect.zero;
				if (_Data != null)
				{
					result = _Data.Rect;
					result.center -= _Displacement.XZ();
				}
				return result;
			}
		}

		internal virtual bool Enabled
		{
			get
			{
				bool flag = base.enabled && !ForceRenderingOff;
				if (flag)
				{
					bool flag2 = Mode != LodInputMode.Unset && (Data?.IsEnabled ?? false);
					flag = flag2;
				}
				return flag;
			}
		}

		private protected virtual bool FollowHorizontalMotion
		{
			get
			{
				LodInputMode mode = Mode;
				if (mode != LodInputMode.Global && mode != LodInputMode.Spline)
				{
					return _FollowHorizontalWaveMotion;
				}
				return true;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private protected override Action<WaterRenderer> OnLateUpdateMethod => OnLateUpdate;

		public LodInputBlend Blend
		{
			get
			{
				return _Blend;
			}
			set
			{
				_Blend = value;
			}
		}

		public float FeatherWidth
		{
			get
			{
				return _FeatherWidth;
			}
			set
			{
				_FeatherWidth = value;
			}
		}

		public bool FollowHorizontalWaveMotion
		{
			get
			{
				return _FollowHorizontalWaveMotion;
			}
			set
			{
				_FollowHorizontalWaveMotion = value;
			}
		}

		public LodInputMode Mode => _Mode;

		public int Queue
		{
			get
			{
				return _Queue;
			}
			set
			{
				SetQueue(_Queue, _Queue = value);
			}
		}

		public float Weight
		{
			get
			{
				return _Weight;
			}
			set
			{
				_Weight = value;
			}
		}

		public T GetData<T>() where T : LodInputData
		{
			LodInputMode mode = _Mode;
			if (mode == LodInputMode.Global || mode == LodInputMode.Primitive || mode == LodInputMode.Unset)
			{
				return null;
			}
			return Data as T;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			Data?.OnEnable();
			Attach();
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			Detach();
			Data?.OnDisable();
		}

		private protected virtual void OnUpdate(WaterRenderer water)
		{
			if (base.transform.hasChanged)
			{
				_RecalculateBounds = true;
			}
			if (!FollowHorizontalMotion)
			{
				_SampleHeightHelper.SampleDisplacement(base.transform.position, out _Displacement);
			}
			else
			{
				_Displacement = Vector3.zero;
			}
			Data?.OnUpdate();
		}

		private protected virtual void OnLateUpdate(WaterRenderer water)
		{
			Data?.OnLateUpdate();
			base.transform.hasChanged = false;
		}

		private protected virtual void Attach()
		{
			if (_Input == null)
			{
				_Input = new Input(this);
			}
			ILodInput.Attach(_Input, Inputs);
		}

		private protected virtual void Detach()
		{
			ILodInput.Detach(_Input, Inputs);
		}

		internal virtual void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			if (weight != 0f)
			{
				PropertyWrapperBuffer propertyWrapperBuffer = new PropertyWrapperBuffer(buffer);
				propertyWrapperBuffer.SetFloat(ShaderIDs.s_Weight, weight * _Weight);
				propertyWrapperBuffer.SetVector(ShaderIDs.s_DisplacementAtInputPosition, _Displacement);
				Data?.Draw(simulation, this, buffer, target, slice);
			}
		}

		internal virtual float Filter(WaterRenderer water, int slice)
		{
			return 1f;
		}

		internal static void SetBlendFromPreset(Material material, LodInputBlend preset)
		{
			BlendMode value = BlendMode.One;
			BlendMode value2 = BlendMode.One;
			BlendOp value3 = BlendOp.Add;
			switch (preset)
			{
			case LodInputBlend.Off:
				value = BlendMode.One;
				value2 = BlendMode.Zero;
				break;
			case LodInputBlend.Alpha:
			case LodInputBlend.AlphaClip:
				value = BlendMode.One;
				value2 = BlendMode.OneMinusSrcAlpha;
				break;
			case LodInputBlend.Maximum:
				value3 = BlendOp.Max;
				break;
			case LodInputBlend.Minimum:
				value3 = BlendOp.Min;
				break;
			}
			material.SetInt(ShaderIDs.s_BlendSource, (int)value);
			material.SetInt(ShaderIDs.s_BlendTarget, (int)value2);
			material.SetInt(ShaderIDs.s_BlendOperation, (int)value3);
		}

		private void SetQueue(int previous, int current)
		{
			if (previous != current && base.isActiveAndEnabled)
			{
				Attach();
			}
		}

		internal virtual void InferBlend()
		{
			_Blend = LodInputBlend.Additive;
		}
	}
}
