using System;
using System.Collections.Generic;
using Coffee.UIParticleInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
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
		[SerializeField]
		[Obsolete]
		internal bool m_IsTrail;

		[HideInInspector]
		[FormerlySerializedAs("m_IgnoreParent")]
		[SerializeField]
		[Obsolete]
		private bool m_IgnoreCanvasScaler;

		[HideInInspector]
		[SerializeField]
		[Obsolete]
		internal bool m_AbsoluteMode;

		[Tooltip("Scale the rendering particles. When the `3D` toggle is enabled, 3D scale (x, y, z) is supported.")]
		[SerializeField]
		private Vector3 m_Scale3D = new Vector3(10f, 10f, 10f);

		[Tooltip("If you want to update material properties (e.g. _MainTex_ST, _Color) in AnimationClip, use this to mark as animatable.")]
		[SerializeField]
		internal AnimatableProperty[] m_AnimatableProperties = new AnimatableProperty[0];

		[Tooltip("Particles")]
		[SerializeField]
		private List<ParticleSystem> m_Particles = new List<ParticleSystem>();

		[Tooltip("Particle simulation results are shared within the same group. A large number of the same effects can be displayed with a small load.\nNone: Disable mesh sharing.\nAuto: Automatically select Primary/Replica.\nPrimary: Provides particle simulation results to the same group.\nPrimary Simulator: Primary, but do not render the particle (simulation only).\nReplica: Render simulation results provided by the primary.")]
		[SerializeField]
		private MeshSharing m_MeshSharing;

		[Tooltip("Mesh sharing group ID.\nIf non-zero is specified, particle simulation results are shared within the group.")]
		[SerializeField]
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
		private AutoScalingMode m_AutoScalingMode = AutoScalingMode.Transform;

		[SerializeField]
		[Tooltip("Use a custom view.\nUse this if the particles are not displayed correctly due to min/max particle size.")]
		private bool m_UseCustomView;

		[SerializeField]
		[Tooltip("Custom view size.\nChange the bake view size.")]
		private float m_CustomViewSize = 10f;

		[SerializeField]
		[Tooltip("Time scale multiplier.")]
		private float m_TimeScaleMultiplier = 1f;

		private readonly List<UIParticleRenderer> _renderers = new List<UIParticleRenderer>();

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
				return m_MeshSharing;
			}
			set
			{
				m_MeshSharing = value;
			}
		}

		public int groupId
		{
			get
			{
				return _groupId;
			}
			set
			{
				if (m_GroupId != value)
				{
					m_GroupId = value;
					if (m_GroupId != m_GroupMaxId)
					{
						ResetGroupId();
					}
				}
			}
		}

		public int groupMaxId
		{
			get
			{
				return m_GroupMaxId;
			}
			set
			{
				if (m_GroupMaxId != value)
				{
					m_GroupMaxId = value;
					ResetGroupId();
				}
			}
		}

		public PositionMode positionMode
		{
			get
			{
				return m_PositionMode;
			}
			set
			{
				m_PositionMode = value;
			}
		}

		[Obsolete("The absoluteMode is now obsolete. Please use the autoScalingMode instead.", false)]
		public bool absoluteMode
		{
			get
			{
				return m_PositionMode == PositionMode.Absolute;
			}
			set
			{
				positionMode = (value ? PositionMode.Absolute : PositionMode.Relative);
			}
		}

		[Obsolete("The autoScaling is now obsolete. Please use the autoScalingMode instead.", false)]
		public bool autoScaling
		{
			get
			{
				return m_AutoScalingMode != AutoScalingMode.None;
			}
			set
			{
				autoScalingMode = (value ? AutoScalingMode.Transform : AutoScalingMode.None);
			}
		}

		public AutoScalingMode autoScalingMode
		{
			get
			{
				return m_AutoScalingMode;
			}
			set
			{
				if (m_AutoScalingMode != value)
				{
					m_AutoScalingMode = value;
					if (autoScalingMode != AutoScalingMode.Transform && _isScaleStored)
					{
						base.transform.localScale = _storedScale;
						_isScaleStored = false;
					}
				}
			}
		}

		public bool useCustomView
		{
			get
			{
				return m_UseCustomView;
			}
			set
			{
				m_UseCustomView = value;
			}
		}

		public float customViewSize
		{
			get
			{
				return m_CustomViewSize;
			}
			set
			{
				m_CustomViewSize = Mathf.Max(0.1f, value);
			}
		}

		public float timeScaleMultiplier
		{
			get
			{
				return m_TimeScaleMultiplier;
			}
			set
			{
				m_TimeScaleMultiplier = value;
			}
		}

		internal bool useMeshSharing => m_MeshSharing != MeshSharing.None;

		internal bool isPrimary
		{
			get
			{
				if (m_MeshSharing != MeshSharing.Primary)
				{
					return m_MeshSharing == MeshSharing.PrimarySimulator;
				}
				return true;
			}
		}

		internal bool canSimulate
		{
			get
			{
				if (m_MeshSharing != MeshSharing.None && m_MeshSharing != MeshSharing.Auto && m_MeshSharing != MeshSharing.Primary)
				{
					return m_MeshSharing == MeshSharing.PrimarySimulator;
				}
				return true;
			}
		}

		internal bool canRender
		{
			get
			{
				if (m_MeshSharing != MeshSharing.None && m_MeshSharing != MeshSharing.Auto && m_MeshSharing != MeshSharing.Primary)
				{
					return m_MeshSharing == MeshSharing.Replica;
				}
				return true;
			}
		}

		public float scale
		{
			get
			{
				return m_Scale3D.x;
			}
			set
			{
				m_Scale3D = new Vector3(value, value, value);
			}
		}

		public Vector3 scale3D
		{
			get
			{
				return m_Scale3D;
			}
			set
			{
				m_Scale3D = value;
			}
		}

		public Vector3 scale3DForCalc
		{
			get
			{
				if (autoScalingMode != AutoScalingMode.Transform)
				{
					return m_Scale3D.GetScaled(canvasScale, base.transform.localScale);
				}
				return m_Scale3D;
			}
		}

		public List<ParticleSystem> particles => m_Particles;

		public bool isPaused { get; private set; }

		public Vector3 parentScale { get; private set; }

		public Vector3 canvasScale { get; private set; }

		protected override void OnEnable()
		{
			_isScaleStored = false;
			ResetGroupId();
			UIParticleUpdater.Register(this);
			RegisterDirtyMaterialCallback(UpdateRendererMaterial);
			if (0 < particles.Count)
			{
				RefreshParticles(particles);
			}
			else
			{
				RefreshParticles();
			}
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			_tracker.Clear();
			if (autoScalingMode == AutoScalingMode.Transform && _isScaleStored)
			{
				base.transform.localScale = _storedScale;
			}
			_isScaleStored = false;
			UIParticleUpdater.Unregister(this);
			_renderers.ForEach(delegate(UIParticleRenderer r)
			{
				r.Reset();
			});
			UnregisterDirtyMaterialCallback(UpdateRendererMaterial);
			base.OnDisable();
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (m_IgnoreCanvasScaler || m_AutoScaling)
			{
				m_IgnoreCanvasScaler = false;
				m_AutoScaling = false;
				m_AutoScalingMode = AutoScalingMode.Transform;
			}
			if (m_AbsoluteMode)
			{
				m_AbsoluteMode = false;
				m_PositionMode = PositionMode.Absolute;
			}
		}

		public void Play()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				p.Simulate(0f, withChildren: false, restart: true);
			});
			isPaused = false;
		}

		public void Pause()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				p.Pause();
			});
			isPaused = true;
		}

		public void Resume()
		{
			isPaused = false;
		}

		public void Stop()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				p.Stop();
			});
			isPaused = true;
		}

		public void StartEmission()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				ParticleSystem.EmissionModule emission = p.emission;
				emission.enabled = true;
			});
		}

		public void StopEmission()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				ParticleSystem.EmissionModule emission = p.emission;
				emission.enabled = false;
			});
		}

		public void Clear()
		{
			particles.Exec(delegate(ParticleSystem p)
			{
				p.Clear();
			});
			isPaused = true;
		}

		public void GetMaterials(List<Material> result)
		{
			if (result == null)
			{
				return;
			}
			for (int i = 0; i < _renderers.Count; i++)
			{
				UIParticleRenderer uIParticleRenderer = _renderers[i];
				if ((bool)uIParticleRenderer && (bool)uIParticleRenderer.material)
				{
					result.Add(uIParticleRenderer.material);
				}
			}
		}

		public void SetParticleSystemInstance(GameObject instance)
		{
			SetParticleSystemInstance(instance, destroyOldParticles: true);
		}

		public void SetParticleSystemInstance(GameObject instance, bool destroyOldParticles)
		{
			if (!instance)
			{
				return;
			}
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GameObject gameObject = base.transform.GetChild(i).gameObject;
				if ((!gameObject.TryGetComponent<Camera>(out var component) || !(component == _bakeCamera)) && !gameObject.TryGetComponent<UIParticleRenderer>(out var _))
				{
					gameObject.SetActive(value: false);
					if (destroyOldParticles)
					{
						Misc.Destroy(gameObject);
					}
				}
			}
			Transform obj = instance.transform;
			obj.SetParent(base.transform, worldPositionStays: false);
			obj.localPosition = Vector3.zero;
			RefreshParticles(instance);
		}

		public void SetParticleSystemPrefab(GameObject prefab)
		{
			if ((bool)prefab)
			{
				SetParticleSystemInstance(UnityEngine.Object.Instantiate(prefab.gameObject), destroyOldParticles: true);
			}
		}

		public void RefreshParticles()
		{
			RefreshParticles(base.gameObject);
		}

		private void RefreshParticles(GameObject root)
		{
			if (!root)
			{
				return;
			}
			root.GetComponentsInChildren(includeInactive: true, particles);
			int num = particles.Count - 1;
			while (0 <= num)
			{
				ParticleSystem particleSystem = particles[num];
				if (!particleSystem || particleSystem.GetComponentInParent<UIParticle>(includeInactive: true) != this)
				{
					particles.RemoveAt(num);
				}
				num--;
			}
			for (int i = 0; i < particles.Count; i++)
			{
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = particles[i].textureSheetAnimation;
				if (textureSheetAnimation.mode == ParticleSystemAnimationMode.Sprites && textureSheetAnimation.uvChannelMask == (UVChannelFlags)0)
				{
					textureSheetAnimation.uvChannelMask = UVChannelFlags.UV0;
				}
			}
			RefreshParticles(particles);
		}

		public void RefreshParticles(List<ParticleSystem> particleSystems)
		{
			_renderers.Clear();
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				if (base.transform.GetChild(i).TryGetComponent<UIParticleRenderer>(out var component))
				{
					_renderers.Add(component);
				}
			}
			for (int j = 0; j < _renderers.Count; j++)
			{
				_renderers[j].Reset(j);
			}
			int num = 0;
			for (int k = 0; k < particleSystems.Count; k++)
			{
				ParticleSystem particleSystem = particleSystems[k];
				if ((bool)particleSystem)
				{
					ParticleSystem mainEmitter = particleSystem.GetMainEmitter(particleSystems);
					GetRenderer(num++).Set(this, particleSystem, isTrail: false, mainEmitter);
					if (particleSystem.trails.enabled)
					{
						GetRenderer(num++).Set(this, particleSystem, isTrail: true, mainEmitter);
					}
				}
			}
		}

		internal void UpdateTransformScale()
		{
			_tracker.Clear();
			canvasScale = base.canvas.rootCanvas.transform.localScale.Inverse();
			parentScale = base.transform.parent.lossyScale;
			if (autoScalingMode != AutoScalingMode.Transform)
			{
				if (_isScaleStored)
				{
					base.transform.localScale = _storedScale;
				}
				_isScaleStored = false;
				return;
			}
			Vector3 localScale = base.transform.localScale;
			if (!_isScaleStored)
			{
				_storedScale = (localScale.IsVisible() ? localScale : Vector3.one);
				_isScaleStored = true;
			}
			_tracker.Add(this, base.rectTransform, DrivenTransformProperties.Scale);
			Vector3 vector = parentScale.Inverse();
			if (localScale != vector)
			{
				base.transform.localScale = vector;
			}
		}

		internal void UpdateRenderers()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			for (int i = 0; i < _renderers.Count; i++)
			{
				if (!_renderers[i])
				{
					RefreshParticles(particles);
					break;
				}
			}
			Camera bakeCamera = GetBakeCamera();
			for (int j = 0; j < _renderers.Count; j++)
			{
				UIParticleRenderer uIParticleRenderer = _renderers[j];
				if ((bool)uIParticleRenderer)
				{
					uIParticleRenderer.UpdateMesh(bakeCamera);
				}
			}
		}

		internal void ResetGroupId()
		{
			_groupId = ((m_GroupId == m_GroupMaxId) ? m_GroupId : UnityEngine.Random.Range(m_GroupId, m_GroupMaxId + 1));
		}

		protected override void UpdateMaterial()
		{
		}

		protected override void UpdateGeometry()
		{
		}

		private void UpdateRendererMaterial()
		{
			for (int i = 0; i < _renderers.Count; i++)
			{
				UIParticleRenderer uIParticleRenderer = _renderers[i];
				if ((bool)uIParticleRenderer)
				{
					uIParticleRenderer.maskable = base.maskable;
					uIParticleRenderer.SetMaterialDirty();
				}
			}
		}

		internal UIParticleRenderer GetRenderer(int index)
		{
			if (_renderers.Count <= index)
			{
				_renderers.Add(UIParticleRenderer.AddRenderer(this, index));
			}
			if (!_renderers[index])
			{
				_renderers[index] = UIParticleRenderer.AddRenderer(this, index);
			}
			return _renderers[index];
		}

		private Camera GetBakeCamera()
		{
			if (!base.canvas)
			{
				return Camera.main;
			}
			if (!useCustomView && base.canvas.renderMode != RenderMode.ScreenSpaceOverlay && (bool)base.canvas.rootCanvas.worldCamera)
			{
				return base.canvas.rootCanvas.worldCamera;
			}
			if ((bool)_bakeCamera)
			{
				_bakeCamera.orthographicSize = (useCustomView ? customViewSize : 10f);
				return _bakeCamera;
			}
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				if (base.transform.GetChild(i).TryGetComponent<Camera>(out var component) && component.name == "[generated] UIParticle BakingCamera")
				{
					_bakeCamera = component;
					break;
				}
			}
			if (!_bakeCamera)
			{
				GameObject gameObject = new GameObject("[generated] UIParticle BakingCamera");
				gameObject.SetActive(value: false);
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				_bakeCamera = gameObject.AddComponent<Camera>();
			}
			_bakeCamera.enabled = false;
			_bakeCamera.orthographicSize = (useCustomView ? customViewSize : 10f);
			_bakeCamera.transform.SetPositionAndRotation(new Vector3(0f, 0f, -1000f), Quaternion.identity);
			_bakeCamera.orthographic = true;
			_bakeCamera.farClipPlane = 2000f;
			_bakeCamera.clearFlags = CameraClearFlags.Nothing;
			_bakeCamera.cullingMask = 0;
			_bakeCamera.allowHDR = false;
			_bakeCamera.allowMSAA = false;
			_bakeCamera.renderingPath = RenderingPath.Forward;
			_bakeCamera.useOcclusionCulling = false;
			_bakeCamera.gameObject.SetActive(value: false);
			_bakeCamera.gameObject.hideFlags = UIParticleProjectSettings.globalHideFlags;
			return _bakeCamera;
		}
	}
}
