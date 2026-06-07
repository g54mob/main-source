using System;
using System.Collections.Generic;
using Coffee.UIParticleInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu("")]
	internal class UIParticleRenderer : MaskableGraphic
	{
		private static readonly CombineInstance[] s_CombineInstances = new CombineInstance[1];

		private static readonly List<Material> s_Materials = new List<Material>(2);

		private static MaterialPropertyBlock s_Mpb;

		private static readonly Vector3[] s_Corners = new Vector3[4];

		private bool _delay;

		private int _index;

		private bool _isPrevStored;

		private bool _isTrail;

		private Bounds _lastBounds;

		private Material _materialForRendering;

		private Material _modifiedMaterial;

		private UIParticle _parent;

		private ParticleSystem _particleSystem;

		private float _prevCanvasScale;

		private Vector3 _prevPsPos;

		private Vector3 _prevScale;

		private Vector2Int _prevScreenSize;

		private bool _preWarm;

		private ParticleSystemRenderer _renderer;

		public override Texture mainTexture
		{
			get
			{
				if (!_isTrail)
				{
					return _particleSystem.GetTextureForSprite();
				}
				return null;
			}
		}

		public override bool raycastTarget => false;

		private Rect rootCanvasRect
		{
			get
			{
				s_Corners[0] = base.transform.TransformPoint(_lastBounds.min.x, _lastBounds.min.y, 0f);
				s_Corners[1] = base.transform.TransformPoint(_lastBounds.min.x, _lastBounds.max.y, 0f);
				s_Corners[2] = base.transform.TransformPoint(_lastBounds.max.x, _lastBounds.max.y, 0f);
				s_Corners[3] = base.transform.TransformPoint(_lastBounds.max.x, _lastBounds.min.y, 0f);
				if ((bool)base.canvas)
				{
					Matrix4x4 worldToLocalMatrix = base.canvas.rootCanvas.transform.worldToLocalMatrix;
					for (int i = 0; i < 4; i++)
					{
						s_Corners[i] = worldToLocalMatrix.MultiplyPoint(s_Corners[i]);
					}
				}
				Vector2 vector = s_Corners[0];
				Vector2 vector2 = s_Corners[0];
				for (int j = 1; j < 4; j++)
				{
					if (s_Corners[j].x < vector.x)
					{
						vector.x = s_Corners[j].x;
					}
					else if (s_Corners[j].x > vector2.x)
					{
						vector2.x = s_Corners[j].x;
					}
					if (s_Corners[j].y < vector.y)
					{
						vector.y = s_Corners[j].y;
					}
					else if (s_Corners[j].y > vector2.y)
					{
						vector2.y = s_Corners[j].y;
					}
				}
				return new Rect(vector, vector2 - vector);
			}
		}

		public override Material materialForRendering
		{
			get
			{
				if (!_materialForRendering)
				{
					_materialForRendering = base.materialForRendering;
				}
				return _materialForRendering;
			}
		}

		public void Reset(int index = -1)
		{
			if ((bool)_renderer)
			{
				_renderer.enabled = true;
			}
			_parent = null;
			_particleSystem = null;
			_renderer = null;
			if (0 <= index)
			{
				_index = index;
			}
			if ((bool)this && base.isActiveAndEnabled)
			{
				material = null;
				base.canvasRenderer.Clear();
				_lastBounds = default(Bounds);
				base.enabled = false;
			}
			else
			{
				MaterialRepository.Release(ref _modifiedMaterial);
				_materialForRendering = null;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			base.hideFlags = UIParticleProjectSettings.globalHideFlags;
			if (!s_CombineInstances[0].mesh)
			{
				s_CombineInstances[0].mesh = new Mesh
				{
					name = "[UIParticleRenderer] Combine Instance Mesh",
					hideFlags = HideFlags.HideAndDontSave
				};
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			MaterialRepository.Release(ref _modifiedMaterial);
			_materialForRendering = null;
			_isPrevStored = false;
		}

		public static UIParticleRenderer AddRenderer(UIParticle parent, int index)
		{
			GameObject obj = new GameObject("[generated] UIParticleRenderer", typeof(UIParticleRenderer))
			{
				hideFlags = UIParticleProjectSettings.globalHideFlags,
				layer = parent.gameObject.layer
			};
			Transform obj2 = obj.transform;
			obj2.SetParent(parent.transform, worldPositionStays: false);
			obj2.localPosition = Vector3.zero;
			obj2.localRotation = Quaternion.identity;
			obj2.localScale = Vector3.one;
			UIParticleRenderer component = obj.GetComponent<UIParticleRenderer>();
			component._parent = parent;
			component._index = index;
			return component;
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			if (!IsActive() || !_parent)
			{
				MaterialRepository.Release(ref _modifiedMaterial);
				return baseMaterial;
			}
			Material modifiedMaterial = base.GetModifiedMaterial(baseMaterial);
			Texture texture = mainTexture;
			if (texture == null && _parent.m_AnimatableProperties.Length == 0)
			{
				MaterialRepository.Release(ref _modifiedMaterial);
				return modifiedMaterial;
			}
			Hash128 hash = new Hash128(modifiedMaterial ? ((uint)modifiedMaterial.GetInstanceID()) : 0u, texture ? ((uint)texture.GetInstanceID()) : 0u, (_parent.m_AnimatableProperties.Length != 0) ? ((uint)GetInstanceID()) : 0u, 0u);
			if (!MaterialRepository.Valid(hash, _modifiedMaterial))
			{
				MaterialRepository.Get(hash, ref _modifiedMaterial, ((Material mat, Texture texture) x) => new Material(x.mat)
				{
					hideFlags = HideFlags.HideAndDontSave,
					mainTexture = (x.texture ? x.texture : x.mat.mainTexture)
				}, (modifiedMaterial, texture));
			}
			return _modifiedMaterial;
		}

		public void Set(UIParticle parent, ParticleSystem ps, bool isTrail)
		{
			_parent = parent;
			base.maskable = parent.maskable;
			base.gameObject.layer = parent.gameObject.layer;
			_particleSystem = ps;
			_preWarm = _particleSystem.main.prewarm;
			if (_particleSystem.isPlaying || _preWarm)
			{
				_particleSystem.Clear();
				_particleSystem.Pause();
			}
			ps.TryGetComponent<ParticleSystemRenderer>(out _renderer);
			_renderer.enabled = false;
			_isTrail = isTrail;
			_renderer.GetSharedMaterials(s_Materials);
			material = s_Materials[isTrail ? 1 : 0];
			s_Materials.Clear();
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = ps.textureSheetAnimation;
			if (textureSheetAnimation.mode == ParticleSystemAnimationMode.Sprites && textureSheetAnimation.uvChannelMask == (UVChannelFlags)0)
			{
				textureSheetAnimation.uvChannelMask = UVChannelFlags.UV0;
			}
			_prevScale = GetWorldScale();
			_prevPsPos = _particleSystem.transform.position;
			_prevScreenSize = new Vector2Int(Screen.width, Screen.height);
			_prevCanvasScale = (base.canvas ? base.canvas.scaleFactor : 1f);
			_delay = true;
			base.canvasRenderer.SetTexture(null);
			base.enabled = true;
		}

		public void UpdateMesh(Camera bakeCamera)
		{
			if (!base.isActiveAndEnabled || !_particleSystem || !_parent || !base.canvasRenderer || !base.canvas || !bakeCamera || _parent.meshSharing == UIParticle.MeshSharing.Replica || !base.transform.lossyScale.GetScaled(_parent.scale3DForCalc).IsVisible() || (!_particleSystem.IsAlive() && !_particleSystem.isPlaying) || (_isTrail && !_particleSystem.trails.enabled) || base.canvasRenderer.GetInheritedAlpha() < 0.01f)
			{
				Graphic.workerMesh.Clear();
				base.canvasRenderer.SetMesh(Graphic.workerMesh);
				_lastBounds = default(Bounds);
				return;
			}
			ParticleSystem.MainModule main = _particleSystem.main;
			Vector3 worldScale = GetWorldScale();
			Vector3 position = _particleSystem.transform.position;
			if (!_isTrail && _parent.canSimulate)
			{
				ResolveResolutionChange(position, worldScale);
				Simulate(worldScale, _parent.isPaused || _delay);
				if (_delay && !_parent.isPaused)
				{
					Simulate(worldScale, _parent.isPaused);
				}
				if (!main.loop && main.duration <= _particleSystem.time && (_particleSystem.IsAlive() || _particleSystem.particleCount == 0))
				{
					_particleSystem.Stop(withChildren: false);
				}
				_prevScale = worldScale;
				_prevPsPos = position;
				_delay = false;
			}
			s_CombineInstances[0].mesh.Clear(keepVertexLayout: false);
			float x = s_CombineInstances[0].mesh.bounds.extents.x;
			if (!float.IsNaN(x) && !float.IsInfinity(x) && 0f < x)
			{
				s_CombineInstances[0].mesh.RecalculateBounds();
			}
			if (_isTrail && _parent.canSimulate && 0 < _particleSystem.particleCount)
			{
				_renderer.BakeTrailsMesh(s_CombineInstances[0].mesh, bakeCamera, ParticleSystemBakeMeshOptions.BakeRotationAndScale);
			}
			else if (!_isTrail && _renderer.CanBakeMesh())
			{
				_particleSystem.ValidateShape();
				_renderer.BakeMesh(s_CombineInstances[0].mesh, bakeCamera, ParticleSystemBakeMeshOptions.BakeRotationAndScale);
			}
			if (65535 <= s_CombineInstances[0].mesh.vertexCount)
			{
				Debug.LogErrorFormat(this, "Too many vertices to render. index={0}, isTrail={1}, vertexCount={2}(>=65535)", _index, _isTrail, s_CombineInstances[0].mesh.vertexCount);
				s_CombineInstances[0].mesh.Clear(keepVertexLayout: false);
			}
			if (_parent.canSimulate)
			{
				if (_parent.positionMode == UIParticle.PositionMode.Absolute)
				{
					s_CombineInstances[0].transform = base.canvasRenderer.transform.worldToLocalMatrix * GetWorldMatrix(position, worldScale);
				}
				else
				{
					Vector3 self = _particleSystem.transform.position - _parent.transform.position;
					s_CombineInstances[0].transform = base.canvasRenderer.transform.worldToLocalMatrix * Matrix4x4.Translate(self.GetScaled(worldScale - Vector3.one)) * GetWorldMatrix(position, worldScale);
				}
				Graphic.workerMesh.CombineMeshes(s_CombineInstances, mergeSubMeshes: true, useMatrices: true);
				Graphic.workerMesh.RecalculateBounds();
				Bounds bounds = Graphic.workerMesh.bounds;
				Vector3 center = bounds.center;
				center.z = 0f;
				bounds.center = center;
				Vector3 extents = bounds.extents;
				extents.z = 0f;
				bounds.extents = extents;
				Graphic.workerMesh.bounds = bounds;
				_lastBounds = bounds;
				if (UIParticleProjectSettings.enableLinearToGamma && base.canvas.ShouldGammaToLinearInMesh())
				{
					Graphic.workerMesh.LinearToGamma();
				}
				List<Component> toRelease = ListPool<Component>.Rent();
				GetComponents(typeof(IMeshModifier), toRelease);
				for (int i = 0; i < toRelease.Count; i++)
				{
					((IMeshModifier)toRelease[i]).ModifyMesh(Graphic.workerMesh);
				}
				ListPool<Component>.Return(ref toRelease);
			}
			UpdateMaterialProperties();
			List<UIParticleRenderer> toRelease2 = ListPool<UIParticleRenderer>.Rent();
			if (_parent.useMeshSharing)
			{
				UIParticleUpdater.GetGroupedRenderers(_parent.groupId, _index, toRelease2);
			}
			for (int j = 0; j < toRelease2.Count; j++)
			{
				UIParticleRenderer uIParticleRenderer = toRelease2[j];
				if (!(uIParticleRenderer == this))
				{
					uIParticleRenderer.canvasRenderer.SetMesh(Graphic.workerMesh);
					uIParticleRenderer._lastBounds = _lastBounds;
					uIParticleRenderer.canvasRenderer.materialCount = 1;
					uIParticleRenderer.canvasRenderer.SetMaterial(materialForRendering, 0);
				}
			}
			ListPool<UIParticleRenderer>.Return(ref toRelease2);
			if (_parent.canRender)
			{
				base.canvasRenderer.SetMesh(Graphic.workerMesh);
			}
			else
			{
				Graphic.workerMesh.Clear();
			}
		}

		public override void SetMaterialDirty()
		{
			_materialForRendering = null;
			base.SetMaterialDirty();
		}

		protected override void UpdateGeometry()
		{
		}

		public override void Cull(Rect clipRect, bool validRect)
		{
			bool flag = _lastBounds.extents == Vector3.zero || !validRect || !clipRect.Overlaps(rootCanvasRect, allowInverse: true);
			if (base.canvasRenderer.cull != flag)
			{
				base.canvasRenderer.cull = flag;
				UISystemProfilerApi.AddMarker("MaskableGraphic.cullingChanged", this);
				base.onCullStateChanged.Invoke(flag);
				OnCullingChanged();
			}
		}

		private Vector3 GetWorldScale()
		{
			Vector3 scaled = _parent.scale3DForCalc.GetScaled(_parent.parentScale);
			if (_parent.autoScalingMode == UIParticle.AutoScalingMode.UIParticle && _particleSystem.main.scalingMode == ParticleSystemScalingMode.Local && (bool)_parent.canvas)
			{
				scaled = scaled.GetScaled(_parent.canvas.rootCanvas.transform.localScale);
			}
			return scaled;
		}

		private Matrix4x4 GetWorldMatrix(Vector3 psPos, Vector3 scale)
		{
			ParticleSystemSimulationSpace particleSystemSimulationSpace = _particleSystem.GetActualSimulationSpace();
			if (_isTrail && _particleSystem.trails.worldSpace)
			{
				particleSystemSimulationSpace = ParticleSystemSimulationSpace.World;
			}
			return particleSystemSimulationSpace switch
			{
				ParticleSystemSimulationSpace.Local => Matrix4x4.Translate(psPos) * Matrix4x4.Scale(scale), 
				ParticleSystemSimulationSpace.World => Matrix4x4.Scale(scale), 
				ParticleSystemSimulationSpace.Custom => Matrix4x4.Translate(_particleSystem.main.customSimulationSpace.position.GetScaled(scale)) * Matrix4x4.Scale(scale), 
				_ => throw new NotSupportedException(), 
			};
		}

		private void ResolveResolutionChange(Vector3 psPos, Vector3 scale)
		{
			Vector2Int vector2Int = new Vector2Int(Screen.width, Screen.height);
			bool flag = _particleSystem.IsWorldSpace();
			float b = (_parent.canvas ? _parent.canvas.scaleFactor : 1f);
			if ((_prevScreenSize != vector2Int || !Mathf.Approximately(_prevCanvasScale, b)) && flag && _isPrevStored)
			{
				int particleCount = _particleSystem.particleCount;
				ParticleSystem.Particle[] particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
				_particleSystem.GetParticles(particleArray, particleCount);
				Vector3 scaled = psPos.GetScaled(scale.Inverse(), _prevPsPos.Inverse(), _prevScale);
				for (int i = 0; i < particleCount; i++)
				{
					ParticleSystem.Particle particle = particleArray[i];
					particle.position = particle.position.GetScaled(scaled);
					particleArray[i] = particle;
				}
				_particleSystem.SetParticles(particleArray, particleCount);
				_delay = true;
				_prevScale = scale;
				_prevPsPos = psPos;
				_isPrevStored = true;
			}
			_prevCanvasScale = (base.canvas ? base.canvas.scaleFactor : 1f);
			_prevScreenSize = vector2Int;
		}

		private void Simulate(Vector3 scale, bool paused)
		{
			ParticleSystem.MainModule main = _particleSystem.main;
			float num = (paused ? 0f : (main.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime));
			if (0f < num && _preWarm)
			{
				num += main.duration;
				_preWarm = false;
			}
			bool flag = _particleSystem.IsLocalSpace();
			Transform transform = _particleSystem.transform;
			Vector3 localPosition = transform.localPosition;
			Quaternion localRotation = transform.localRotation;
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;
			ParticleSystem.EmissionModule emission = _particleSystem.emission;
			if (emission.enabled && 0f < emission.rateOverDistance.constant && 0f < emission.rateOverDistanceMultiplier && !paused && _isPrevStored)
			{
				Vector3 position2 = (flag ? _prevPsPos : _prevPsPos.GetScaled(_prevScale.Inverse()));
				transform.SetPositionAndRotation(position2, rotation);
				_particleSystem.Simulate(0f, withChildren: false, restart: false, fixedTimeStep: false);
			}
			Vector3 position3 = (flag ? position : position.GetScaled(scale.Inverse()));
			transform.SetPositionAndRotation(position3, rotation);
			_particleSystem.Simulate(num, withChildren: false, restart: false, fixedTimeStep: false);
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
		}

		private void UpdateMaterialProperties()
		{
			if (_parent.m_AnimatableProperties.Length == 0)
			{
				return;
			}
			if (s_Mpb == null)
			{
				s_Mpb = new MaterialPropertyBlock();
			}
			_renderer.GetPropertyBlock(s_Mpb);
			if (!s_Mpb.isEmpty && (bool)materialForRendering)
			{
				for (int i = 0; i < _parent.m_AnimatableProperties.Length; i++)
				{
					_parent.m_AnimatableProperties[i].UpdateMaterialProperties(materialForRendering, s_Mpb);
				}
				s_Mpb.Clear();
			}
		}
	}
}
