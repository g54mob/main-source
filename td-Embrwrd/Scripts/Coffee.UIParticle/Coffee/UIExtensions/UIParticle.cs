using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[ExecuteAlways]
	public class UIParticle : MaskableGraphic, ISerializationCallbackReceiver
	{
		public enum AutoScalingMode
		{
			None = 0,
			UIParticle = 1,
			Transform = 2
		}

		public enum MeshSharing
		{
			None = 0,
			Auto = 1,
			Primary = 2,
			PrimarySimulator = 3,
			Replica = 4
		}

		public enum PositionMode
		{
			Relative = 0,
			Absolute = 1
		}

		[HideInInspector]
		[Obsolete]
		[SerializeField]
		internal bool m_IsTrail;

		[FormerlySerializedAs("m_IgnoreParent")]
		[HideInInspector]
		[SerializeField]
		[Obsolete]
		private bool m_IgnoreCanvasScaler;

		[HideInInspector]
		[SerializeField]
		[Obsolete]
		internal bool m_AbsoluteMode;

		[Tooltip("Scale the rendering particles. When the `3D` toggle is enabled, 3D scale (x, y, z) is supported.")]
		[SerializeField]
		private Vector3 m_Scale3D;

		[Tooltip("If you want to update material properties (e.g. _MainTex_ST, _Color) in AnimationClip, use this to mark as animatable.")]
		[SerializeField]
		internal AnimatableProperty[] m_AnimatableProperties;

		[Tooltip("Particles")]
		[SerializeField]
		private List<ParticleSystem> m_Particles;

		[SerializeField]
		[Tooltip("Particle simulation results are shared within the same group. A large number of the same effects can be displayed with a small load.\nNone: Disable mesh sharing.\nAuto: Automatically select Primary/Replica.\nPrimary: Provides particle simulation results to the same group.\nPrimary Simulator: Primary, but do not render the particle (simulation only).\nReplica: Render simulation results provided by the primary.")]
		private MeshSharing m_MeshSharing;

		[SerializeField]
		[Tooltip("Mesh sharing group ID.\nIf non-zero is specified, particle simulation results are shared within the group.")]
		private int m_GroupId;

		[SerializeField]
		private int m_GroupMaxId;

		[Tooltip("Emission position mode.\nRelative: The particles will be emitted from the scaled position.\nAbsolute: The particles will be emitted from the world position.")]
		[SerializeField]
		private PositionMode m_PositionMode;

		[SerializeField]
		[Obsolete]
		internal bool m_AutoScaling;

		[SerializeField]
		[Tooltip("How to automatically adjust when the Canvas scale is changed by the screen size or reference resolution.\nNone: Do nothing.\nTransform: Transform.lossyScale (=world scale) will be set to (1, 1, 1).\nUIParticle: UIParticle.scale will be adjusted.")]
		private AutoScalingMode m_AutoScalingMode;

		[Tooltip("Use a custom view.\nUse this if the particles are not displayed correctly due to min/max particle size.")]
		[SerializeField]
		private bool m_UseCustomView;

		[SerializeField]
		[Tooltip("Custom view size.\nChange the bake view size.")]
		private float m_CustomViewSize;

		[SerializeField]
		[Tooltip("Time scale multiplier.")]
		private float m_TimeScaleMultiplier;

		private readonly List<UIParticleRenderer> _renderers;

		private Camera _bakeCamera;

		private int _groupId;

		private bool _isScaleStored;

		private Vector3 _storedScale;

		private DrivenRectTransformTracker _tracker;

		public override bool raycastTarget
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MeshSharing meshSharing
		{
			get
			{
				return default(MeshSharing);
			}
			set
			{
			}
		}

		public int groupId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int groupMaxId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public PositionMode positionMode
		{
			get
			{
				return default(PositionMode);
			}
			set
			{
			}
		}

		[Obsolete("The absoluteMode is now obsolete. Please use the autoScalingMode instead.", false)]
		public bool absoluteMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("The autoScaling is now obsolete. Please use the autoScalingMode instead.", false)]
		public bool autoScaling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AutoScalingMode autoScalingMode
		{
			get
			{
				return default(AutoScalingMode);
			}
			set
			{
			}
		}

		public bool useCustomView
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float customViewSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float timeScaleMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal bool useMeshSharing => false;

		internal bool isPrimary => false;

		internal bool canSimulate => false;

		internal bool canRender => false;

		public float scale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 scale3D
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 scale3DForCalc => default(Vector3);

		public List<ParticleSystem> particles => null;

		public bool isPaused { get; private set; }

		public Vector3 parentScale { get; private set; }

		public Vector3 canvasScale { get; private set; }

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public void Play()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void Stop()
		{
		}

		public void StartEmission()
		{
		}

		public void StopEmission()
		{
		}

		public void Clear()
		{
		}

		public void GetMaterials(List<Material> result)
		{
		}

		public void SetParticleSystemInstance(GameObject instance)
		{
		}

		public void SetParticleSystemInstance(GameObject instance, bool destroyOldParticles)
		{
		}

		public void SetParticleSystemPrefab(GameObject prefab)
		{
		}

		public void RefreshParticles()
		{
		}

		private void RefreshParticles(GameObject root)
		{
		}

		public void RefreshParticles(List<ParticleSystem> particleSystems)
		{
		}

		internal void UpdateTransformScale()
		{
		}

		internal void UpdateRenderers()
		{
		}

		internal void ResetGroupId()
		{
		}

		protected override void UpdateMaterial()
		{
		}

		protected override void UpdateGeometry()
		{
		}

		private void UpdateRendererMaterial()
		{
		}

		internal UIParticleRenderer GetRenderer(int index)
		{
			return null;
		}

		private Camera GetBakeCamera()
		{
			return null;
		}
	}
}
