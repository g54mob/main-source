using System;
using System.Collections.Generic;
using Coffee.UIParticleExtensions;
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

		public enum AutoScalingMode
		{
			None = 0,
			UIParticle = 1,
			Transform = 2
		}

		[HideInInspector]
		[SerializeField]
		internal bool m_IsTrail;

		[HideInInspector]
		[FormerlySerializedAs("m_IgnoreParent")]
		[SerializeField]
		private bool m_IgnoreCanvasScaler;

		[HideInInspector]
		[SerializeField]
		private bool m_AbsoluteMode;

		[Tooltip("Particle effect scale")]
		[SerializeField]
		private Vector3 m_Scale3D = new Vector3(10f, 10f, 10f);

		[Tooltip("Animatable material properties.\nIf you want to change the material properties of the ParticleSystem in Animation, enable it.")]
		[SerializeField]
		internal AnimatableProperty[] m_AnimatableProperties = new AnimatableProperty[0];

		[Tooltip("Particles")]
		[SerializeField]
		private List<ParticleSystem> m_Particles = new List<ParticleSystem>();

		[Tooltip("Mesh sharing.\nNone: disable mesh sharing.\nAuto: automatically select Primary/Replica.\nPrimary: provides particle simulation results to the same group.\nPrimary Simulator: Primary, but do not render the particle (simulation only).\nReplica: render simulation results provided by the primary.")]
		[SerializeField]
		private MeshSharing m_MeshSharing;

		[Tooltip("Mesh sharing group ID.\nIf non-zero is specified, particle simulation results are shared within the group.")]
		[SerializeField]
		private int m_GroupId;

		[SerializeField]
		private int m_GroupMaxId;

		[Tooltip("Relative: The particles will be emitted from the scaled position of ParticleSystem.\nAbsolute: The particles will be emitted from the world position of ParticleSystem.")]
		[SerializeField]
		private PositionMode m_PositionMode;

		[SerializeField]
		[Tooltip("Prevent the root-Canvas scale from affecting the hierarchy-scaled ParticleSystem.")]
		private bool m_AutoScaling = true;

		[SerializeField]
		[Tooltip("Transform: Transform.lossyScale (=world scale) will be set to (1, 1, 1).UIParticle: UIParticle.scale will be adjusted.")]
		private AutoScalingMode m_AutoScalingMode = AutoScalingMode.Transform;

		[SerializeField]
		private bool m_ResetScaleOnEnable;

		private readonly List<UIParticleRenderer> _renderers = new List<UIParticleRenderer>();

		private int _groupId;

		private Camera _orthoCamera;

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
					UpdateTracker();
				}
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
				if (autoScalingMode != AutoScalingMode.UIParticle)
				{
					return m_Scale3D;
				}
				return m_Scale3D.GetScaled(canvasScale);
			}
		}

		public List<ParticleSystem> particles => m_Particles;

		public IEnumerable<Material> materials
		{
			get
			{
				for (int i = 0; i < _renderers.Count; i++)
				{
					UIParticleRenderer uIParticleRenderer = _renderers[i];
					if ((bool)uIParticleRenderer && (bool)uIParticleRenderer.material)
					{
						yield return uIParticleRenderer.material;
					}
				}
			}
		}

		public override Material materialForRendering => null;

		public bool isPaused { get; private set; }

		public Vector3 parentScale { get; private set; }

		public Vector3 canvasScale { get; private set; }

		protected override void OnEnable()
		{
			ResetGroupId();
			UpdateTracker();
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
			if (m_ResetScaleOnEnable)
			{
				m_ResetScaleOnEnable = false;
				base.transform.localScale = Vector3.one;
			}
		}

		protected override void OnDisable()
		{
			UpdateTracker();
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
				m_ResetScaleOnEnable = true;
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
			foreach (Transform item in base.transform)
			{
				GameObject gameObject = item.gameObject;
				gameObject.SetActive(value: false);
				if (destroyOldParticles)
				{
					Misc.Destroy(gameObject);
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
			particles.RemoveAll((ParticleSystem x) => x.GetComponentInParent<UIParticle>(includeInactive: true) != this);
			for (int num = 0; num < particles.Count; num++)
			{
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = particles[num].textureSheetAnimation;
				if (textureSheetAnimation.mode == ParticleSystemAnimationMode.Sprites && textureSheetAnimation.uvChannelMask == (UVChannelFlags)0)
				{
					textureSheetAnimation.uvChannelMask = UVChannelFlags.UV0;
				}
			}
			RefreshParticles(particles);
		}

		public void RefreshParticles(List<ParticleSystem> particles)
		{
			_renderers.Clear();
			foreach (Transform item in base.transform)
			{
				UIParticleRenderer component = item.GetComponent<UIParticleRenderer>();
				if (component != null)
				{
					_renderers.Add(component);
				}
			}
			for (int i = 0; i < _renderers.Count; i++)
			{
				_renderers[i].Reset(i);
			}
			int num = 0;
			for (int j = 0; j < particles.Count; j++)
			{
				ParticleSystem particleSystem = particles[j];
				if ((bool)particleSystem)
				{
					GetRenderer(num++).Set(this, particleSystem, isTrail: false);
					if (particleSystem.trails.enabled)
					{
						GetRenderer(num++).Set(this, particleSystem, isTrail: true);
					}
				}
			}
		}

		internal void UpdateTransformScale()
		{
			canvasScale = base.canvas.rootCanvas.transform.localScale.Inverse();
			parentScale = base.transform.parent.lossyScale;
			if (autoScalingMode == AutoScalingMode.Transform)
			{
				Vector3 vector = parentScale.Inverse();
				if (base.transform.localScale != vector)
				{
					base.transform.localScale = vector;
				}
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

		internal void UpdateParticleCount()
		{
			for (int i = 0; i < _renderers.Count; i++)
			{
				UIParticleRenderer uIParticleRenderer = _renderers[i];
				if ((bool)uIParticleRenderer)
				{
					uIParticleRenderer.UpdateParticleCount();
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
			Canvas rootCanvas = base.canvas.rootCanvas;
			if (rootCanvas.renderMode != RenderMode.ScreenSpaceOverlay)
			{
				if (!rootCanvas.worldCamera)
				{
					return Camera.main;
				}
				return rootCanvas.worldCamera;
			}
			if (!_orthoCamera)
			{
				foreach (Transform item in base.transform)
				{
					Camera component = item.GetComponent<Camera>();
					if ((bool)component && component.name == "[generated] UIParticleOverlayCamera")
					{
						_orthoCamera = component;
						break;
					}
				}
				if (!_orthoCamera)
				{
					GameObject gameObject = new GameObject("[generated] UIParticleOverlayCamera")
					{
						hideFlags = HideFlags.DontSave
					};
					gameObject.SetActive(value: false);
					gameObject.transform.SetParent(base.transform, worldPositionStays: false);
					_orthoCamera = gameObject.AddComponent<Camera>();
					_orthoCamera.enabled = false;
				}
			}
			Vector2 size = ((RectTransform)rootCanvas.transform).rect.size;
			_orthoCamera.orthographicSize = Mathf.Max(size.x, size.y) * rootCanvas.scaleFactor;
			_orthoCamera.transform.SetPositionAndRotation(new Vector3(0f, 0f, -1000f), Quaternion.identity);
			_orthoCamera.orthographic = true;
			_orthoCamera.farClipPlane = 2000f;
			return _orthoCamera;
		}

		private void UpdateTracker()
		{
			if (!base.enabled || !autoScaling || autoScalingMode != AutoScalingMode.Transform)
			{
				_tracker.Clear();
			}
			else
			{
				_tracker.Add(this, base.rectTransform, DrivenTransformProperties.Scale);
			}
		}
	}
}
