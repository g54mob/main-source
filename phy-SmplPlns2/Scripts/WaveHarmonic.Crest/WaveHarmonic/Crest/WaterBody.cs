using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Crest Water Body")]
	public sealed class WaterBody : ManagedBehaviour<WaterRenderer>
	{
		private sealed class ClipInput : ILodInput
		{
			private readonly WaterBody _Owner;

			private readonly Transform _Transform;

			public bool Enabled
			{
				get
				{
					if (ManagerBehaviour<WaterRenderer>.Instance != null)
					{
						return ManagerBehaviour<WaterRenderer>.Instance._ClipLod._DefaultClippingState == DefaultClippingState.EverythingClipped;
					}
					return false;
				}
			}

			public bool IsCompute => true;

			public int Pass => -1;

			public int Queue => 0;

			public MonoBehaviour Component => _Owner;

			public Rect Rect => _Owner.Rect;

			public ClipInput(WaterBody owner)
			{
				_Owner = owner;
				_Transform = owner.transform;
			}

			public void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
			{
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, ScriptableSingleton<WaterResources>.Instance.Compute._ClipPrimitive, 0);
				propertyWrapperCompute.SetMatrix(ShaderIDs.s_Matrix, _Transform.worldToLocalMatrix);
				propertyWrapperCompute.SetVector(ShaderIDs.s_Position, _Transform.position);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_Diameter, _Transform.lossyScale.Maximum());
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveInverted, value: true);
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveSphere, value: false);
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveCube, value: false);
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ClipPrimitiveRectangle, value: true);
				propertyWrapperCompute.SetTexture(ShaderIDs.s_Target, target);
				int num = simulation.Resolution / 8;
				propertyWrapperCompute.Dispatch(num, num, slices);
			}

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}
		}

		[Tooltip("Makes sure this water body is not clipped.\n\nIf clipping is enabled and set to clip everywhere by default, this option will register this water body to ensure its area does not get clipped.")]
		[SerializeField]
		private bool _Clip = true;

		[Tooltip("Water chunks that overlap this waterbody area will be assigned this material.\n\nThis is useful for varying water appearance across different water bodies. If no override material is specified, the default material assigned to the WaterRenderer component will be used.")]
		[SerializeField]
		internal Material _Material;

		[Tooltip("Overrides the property on the Water Renderer with the same name when the camera is inside the bounds.")]
		[SerializeField]
		internal Material _BelowSurfaceMaterial;

		[Tooltip("Overrides the Water Renderer's volume material when the camera is inside the bounds.")]
		[SerializeField]
		internal Material _VolumeMaterial;

		private bool _RecalculateRect = true;

		private bool _RecalculateBounds = true;

		internal Material _MotionVectorMaterial;

		private Bounds _Bounds;

		private Rect _Rect;

		private ClipInput _ClipInput;

		public Material BelowSurfaceMaterial
		{
			get
			{
				return _BelowSurfaceMaterial;
			}
			set
			{
				_BelowSurfaceMaterial = value;
			}
		}

		public bool Clipped
		{
			get
			{
				return _Clip;
			}
			set
			{
				_Clip = value;
			}
		}

		public Material AboveSurfaceMaterial
		{
			get
			{
				return _Material;
			}
			set
			{
				_Material = value;
			}
		}

		public Material VolumeMaterial
		{
			get
			{
				return _VolumeMaterial;
			}
			set
			{
				_VolumeMaterial = value;
			}
		}

		internal static List<WaterBody> WaterBodies { get; } = new List<WaterBody>();

		internal Bounds AABB
		{
			get
			{
				if (_RecalculateBounds)
				{
					CalculateBounds();
					_RecalculateBounds = false;
				}
				return _Bounds;
			}
		}

		private Rect Rect
		{
			get
			{
				if (_RecalculateRect)
				{
					_Rect = AABB.RectXZ();
					_RecalculateRect = false;
				}
				return _Rect;
			}
		}

		internal Material AboveOrBelowSurfaceMaterial
		{
			get
			{
				if (!(_BelowSurfaceMaterial == null))
				{
					return _BelowSurfaceMaterial;
				}
				return _Material;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private protected override Action<WaterRenderer> OnLateUpdateMethod => OnLateUpdate;

		private protected override void Initialize()
		{
			base.Initialize();
			CalculateBounds();
			WaterBodies.Add(this);
			HandleClipInputRegistration();
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			WaterBodies.Remove(this);
			if (_ClipInput != null)
			{
				ILodInput.Detach(_ClipInput, ClipLod.s_Inputs);
				_ClipInput = null;
			}
		}

		internal void CalculateBounds()
		{
			Bounds bounds = default(Bounds);
			bounds.center = base.transform.position;
			bounds.Encapsulate(base.transform.TransformPoint(Vector3.right / 2f + Vector3.forward / 2f));
			bounds.Encapsulate(base.transform.TransformPoint(Vector3.right / 2f - Vector3.forward / 2f));
			bounds.Encapsulate(base.transform.TransformPoint(-Vector3.right / 2f + Vector3.forward / 2f));
			bounds.Encapsulate(base.transform.TransformPoint(-Vector3.right / 2f - Vector3.forward / 2f));
			_Bounds = bounds;
		}

		private void HandleClipInputRegistration()
		{
			bool num = _ClipInput != null;
			bool clip = _Clip;
			if (num != clip)
			{
				if (clip)
				{
					_ClipInput = new ClipInput(this);
					ILodInput.Attach(_ClipInput, ClipLod.s_Inputs);
				}
				else
				{
					ILodInput.Detach(_ClipInput, ClipLod.s_Inputs);
					_ClipInput = null;
				}
			}
		}

		private void OnUpdate(WaterRenderer water)
		{
			if (base.transform.hasChanged)
			{
				_RecalculateRect = (_RecalculateBounds = true);
			}
		}

		private void OnLateUpdate(WaterRenderer water)
		{
			base.transform.hasChanged = false;
		}
	}
}
