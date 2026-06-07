using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Watertight Hull")]
	public sealed class WatertightHull : ManagedBehaviour<WaterRenderer>
	{
		[Serializable]
		internal sealed class DebugFields
		{
			[SerializeField]
			public bool _DrawBounds;
		}

		private static class ShaderIDs
		{
			public static int s_Inverted = Shader.PropertyToID("_Crest_Inverted");
		}

		private sealed class ClipInput : ILodInput
		{
			private readonly WatertightHull _Input;

			public bool Enabled => _Input.Enabled;

			public bool IsCompute => false;

			public int Queue => _Input.Queue;

			public int Pass => -1;

			public Rect Rect => _Input.Rect;

			public MonoBehaviour Component => _Input;

			public ClipInput(WatertightHull input)
			{
				_Input = input;
			}

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
			{
				_Input.DrawClip(lod, buffer, target, pass, weight, slice);
			}
		}

		private sealed class DisplacementInput : ILodInput
		{
			private readonly WatertightHull _Input;

			public bool Enabled => _Input.Enabled;

			public bool IsCompute => false;

			public int Queue => _Input.Queue;

			public int Pass => 2;

			public Rect Rect => _Input.Rect;

			public MonoBehaviour Component => _Input;

			public DisplacementInput(WatertightHull input)
			{
				_Input = input;
			}

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
			{
				_Input.DrawDisplacement(lod, buffer, target, pass, weight, slice);
			}
		}

		[Tooltip("The convex hull to keep water out.")]
		[SerializeField]
		internal Mesh _Mesh;

		[Tooltip("Order this input will render.\n\nQueue is 'Queue + SiblingIndex'")]
		[SerializeField]
		private int _Queue;

		[Tooltip("Which mode to use.")]
		[SerializeField]
		private WatertightHullMode _Mode;

		[Tooltip("Inverts the effect to remove clipping (ie add water).")]
		[SerializeField]
		private bool _Inverted;

		[Tooltip("Whether to also to clip the surface when using displacement mode.\n\nDisplacement mode can have a leaky hull by allowing chop top push waves across the hull boundaries slightly. Clipping the surface will remove these interior leaks.")]
		[SerializeField]
		private bool _UseClipWithDisplacement = true;

		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		private Material _ClipMaterial;

		private Material _AnimatedWavesMaterial;

		private bool _RecalculateBounds = true;

		private Rect _Rect;

		private readonly SampleCollisionHelper _SampleCollisionHelper = new SampleCollisionHelper();

		private Vector3 _Displacement;

		private ClipInput _ClipInput;

		private DisplacementInput _AnimatedWavesInput;

		internal bool Enabled
		{
			get
			{
				if (base.enabled)
				{
					return _Mesh != null;
				}
				return false;
			}
		}

		internal Rect Rect
		{
			get
			{
				if (_RecalculateBounds)
				{
					_Rect = base.transform.TransformBounds(_Mesh.bounds).RectXZ();
					_RecalculateBounds = false;
				}
				return _Rect;
			}
		}

		internal bool UsesClip
		{
			get
			{
				if (_Mode != WatertightHullMode.Clip)
				{
					return _UseClipWithDisplacement;
				}
				return true;
			}
		}

		internal bool UsesDisplacement => _Mode == WatertightHullMode.Displacement;

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private protected override Action<WaterRenderer> OnLateUpdateMethod => OnLateUpdate;

		private protected override int Version => Mathf.Max(base.Version, 1);

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

		public Mesh Mesh
		{
			get
			{
				return _Mesh;
			}
			set
			{
				_Mesh = value;
			}
		}

		public WatertightHullMode Mode
		{
			get
			{
				return _Mode;
			}
			set
			{
				SetMode(_Mode, _Mode = value);
			}
		}

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

		public bool UseClipWithDisplacement
		{
			get
			{
				return _UseClipWithDisplacement;
			}
			set
			{
				SetUseClipWithDisplacement(_UseClipWithDisplacement, _UseClipWithDisplacement = value);
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (UsesClip)
			{
				if (_ClipInput == null)
				{
					_ClipInput = new ClipInput(this);
				}
				_ClipMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._ClipConvexHull);
				ILodInput.Attach(_ClipInput, ClipLod.s_Inputs);
			}
			if (UsesDisplacement)
			{
				if (_AnimatedWavesInput == null)
				{
					_AnimatedWavesInput = new DisplacementInput(this);
				}
				_AnimatedWavesMaterial = new Material(Shader.Find("Crest/Inputs/Animated Waves/Push Water Under Convex Hull"));
				_AnimatedWavesMaterial.SetFloat(LodInput.ShaderIDs.s_Weight, 1f);
				ILodInput.Attach(_AnimatedWavesInput, AnimatedWavesLod.s_Inputs);
			}
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			Helpers.Destroy(_ClipMaterial);
			ILodInput.Detach(_ClipInput, ClipLod.s_Inputs);
			Helpers.Destroy(_AnimatedWavesMaterial);
			ILodInput.Detach(_AnimatedWavesInput, AnimatedWavesLod.s_Inputs);
		}

		private void OnUpdate(WaterRenderer water)
		{
			if (_Mode == WatertightHullMode.Displacement)
			{
				_SampleCollisionHelper.SampleDisplacement(base.transform.position, out _Displacement);
			}
			if (base.transform.hasChanged)
			{
				_RecalculateBounds = true;
			}
		}

		private void OnLateUpdate(WaterRenderer water)
		{
			base.transform.hasChanged = false;
		}

		private void DrawClip(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			_ClipMaterial.SetBoolean(ShaderIDs.s_Inverted, _Inverted);
			buffer.DrawMesh(_Mesh, base.transform.localToWorldMatrix, _ClipMaterial);
		}

		private void DrawDisplacement(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			_AnimatedWavesMaterial.SetVector(LodInput.ShaderIDs.s_DisplacementAtInputPosition, _Displacement);
			buffer.DrawMesh(_Mesh, base.transform.localToWorldMatrix, _AnimatedWavesMaterial);
		}

		private void SetQueue(int previous, int current)
		{
			if (previous != current && _ClipInput != null && base.isActiveAndEnabled)
			{
				if (UsesClip)
				{
					ILodInput.Attach(_ClipInput, ClipLod.s_Inputs);
				}
				if (UsesDisplacement)
				{
					ILodInput.Attach(_AnimatedWavesInput, AnimatedWavesLod.s_Inputs);
				}
			}
		}

		private void SetMode(WatertightHullMode previous, WatertightHullMode current)
		{
			if (previous != current)
			{
				OnDisable();
				OnEnable();
			}
		}

		private void SetUseClipWithDisplacement(bool previous, bool current)
		{
			if (previous != current)
			{
				OnDisable();
				OnEnable();
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				_Mode = WatertightHullMode.Clip;
			}
		}
	}
}
