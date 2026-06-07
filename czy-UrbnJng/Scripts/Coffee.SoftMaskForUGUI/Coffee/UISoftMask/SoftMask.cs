using System;
using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	public class SoftMask : Mask, IMeshModifier, IMaskable, IMaskingShapeContainerOwner, ISerializationCallbackReceiver
	{
		public enum DownSamplingRate
		{
			None = 0,
			x1 = 1,
			x2 = 2,
			x4 = 4,
			x8 = 8
		}

		public enum MaskingMode
		{
			SoftMasking = 0,
			AntiAliasing = 1,
			Normal = 2
		}

		public static Action<SoftMask> onRenderSoftMaskBuffer = null;

		private static readonly Camera.MonoOrStereoscopicEye[] s_MonoEyes = new Camera.MonoOrStereoscopicEye[1] { Camera.MonoOrStereoscopicEye.Mono };

		private static readonly Camera.MonoOrStereoscopicEye[] s_StereoEyes = new Camera.MonoOrStereoscopicEye[2]
		{
			Camera.MonoOrStereoscopicEye.Left,
			Camera.MonoOrStereoscopicEye.Right
		};

		[Tooltip("Masking mode.\n\nSoftMasking: Use RenderTexture as a soft mask buffer. The alpha of the masking graphic can be used.\nAntiAliasing: Suppress the jaggedness of the masking graphic. The masking graphic cannot be displayed.\nNormal: Same as Mask component's stencil mask.")]
		[SerializeField]
		private MaskingMode m_MaskingMode;

		[Tooltip("The transparent part of the mask cannot be clicked.\nThis can be achieved by enabling Read/Write enabled in the Texture Import Settings for the texture.\n\nNOTE: Enable this only if necessary, as it will require more graphics memory and processing time.")]
		[SerializeField]
		private bool m_AlphaHitTest;

		[Tooltip("The minimum and maximum alpha values used for soft masking.\nThe larger the gap between these values, the stronger the softness effect.")]
		[SerializeField]
		private MinMax01 m_SoftnessRange = new MinMax01(0f, 1f);

		[Tooltip("The down sampling rate for soft mask buffer.\nThe higher this value, the lower the quality of the soft masking, but the performance will improve.")]
		[SerializeField]
		private DownSamplingRate m_DownSamplingRate = DownSamplingRate.x1;

		[Tooltip("The threshold for anti-alias masking.\nThe smaller this value, the less jagged it is.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AntiAliasingThreshold;

		[SerializeField]
		[Obsolete]
		internal float m_Alpha = -1f;

		[SerializeField]
		[Obsolete]
		internal float m_Softness = -1f;

		[SerializeField]
		[Obsolete]
		private bool m_PartOfParent;

		private CanvasGroup _canvasGroup;

		private CommandBuffer _cb;

		private List<SoftMask> _children;

		private bool _hasResolutionChanged;

		private bool _hasSoftMaskBufferDrawn;

		private Mesh _mesh;

		private MaterialPropertyBlock _mpb;

		private Action _onBeforeCanvasRebuild;

		private Action _onCanvasViewChanged;

		private SoftMask _parent;

		private Matrix4x4 _prevTransformMatrix;

		private Action _renderSoftMaskBuffer;

		private Canvas _rootCanvas;

		private UnityAction _setSoftMaskDirty;

		private MaskingShapeContainer _shapeContainer;

		internal RenderTexture _softMaskBuffer;

		private UnityAction _updateParentSoftMask;

		private CanvasViewChangeTrigger _viewChangeTrigger;

		private List<SoftMask> children
		{
			get
			{
				if (_children == null)
				{
					return _children = ListPool<SoftMask>.Rent();
				}
				return _children;
			}
		}

		public MaskingMode maskingMode
		{
			get
			{
				return m_MaskingMode;
			}
			set
			{
				if (m_MaskingMode != value)
				{
					m_MaskingMode = value;
					AddSoftMaskableOnChildren();
					UpdateAntiAlias();
					SetDirtyAndNotify();
					if ((bool)base.graphic)
					{
						base.graphic.SetMaterialDirty();
					}
				}
			}
		}

		public DownSamplingRate downSamplingRate
		{
			get
			{
				return m_DownSamplingRate;
			}
			set
			{
				if (m_DownSamplingRate != value)
				{
					m_DownSamplingRate = value;
					SetDirtyAndNotify();
				}
			}
		}

		public float antiAliasingThreshold
		{
			get
			{
				return m_AntiAliasingThreshold;
			}
			set
			{
				m_AntiAliasingThreshold = value;
			}
		}

		public bool alphaHitTest
		{
			get
			{
				return m_AlphaHitTest;
			}
			set
			{
				m_AlphaHitTest = value;
			}
		}

		public int softMaskDepth
		{
			get
			{
				int num = -1;
				SoftMask softMask = this;
				while ((bool)softMask)
				{
					if (softMask.SoftMaskingEnabled())
					{
						num++;
					}
					softMask = softMask._parent;
				}
				return num;
			}
		}

		[Obsolete("Use MaskingShape component instead.", false)]
		public bool partOfParent
		{
			get
			{
				return m_PartOfParent;
			}
			set
			{
				m_PartOfParent = value;
			}
		}

		[Obsolete("Use softnessRange instead.", false)]
		public float softness
		{
			get
			{
				return softnessRange.max;
			}
			set
			{
				softnessRange = new MinMax01(0f, Mathf.Clamp01(value));
				m_Softness = -1f;
			}
		}

		public bool hasSoftMaskBuffer => _softMaskBuffer;

		public RenderTexture softMaskBuffer
		{
			get
			{
				if (SoftMaskingEnabled())
				{
					Vector2Int screenSize = RenderTextureRepository.GetScreenSize((int)downSamplingRate);
					Hash128 hash = new Hash128((uint)GetInstanceID(), (uint)screenSize.x, (uint)screenSize.y, 0u);
					if (!RenderTextureRepository.Valid(hash, _softMaskBuffer))
					{
						RenderTextureRepository.Get(hash, ref _softMaskBuffer, (Vector2Int x) => new RenderTexture(RenderTextureRepository.GetDescriptor(x, useStencil: false))
						{
							hideFlags = HideFlags.DontSave
						}, screenSize);
					}
					return _softMaskBuffer;
				}
				RenderTextureRepository.Release(ref _softMaskBuffer);
				return null;
			}
		}

		public MinMax01 softnessRange
		{
			get
			{
				return m_SoftnessRange;
			}
			set
			{
				if (!m_SoftnessRange.Approximately(value))
				{
					m_SoftnessRange = value;
					SetSoftMaskDirty();
				}
			}
		}

		public float alpha
		{
			get
			{
				if (!base.graphic)
				{
					return 1f;
				}
				return base.graphic.color.a;
			}
			set
			{
				value = Mathf.Clamp01(value);
				if ((bool)this && !Mathf.Approximately(alpha, value))
				{
					isDirty = true;
					if ((bool)base.graphic)
					{
						Color color = base.graphic.color;
						color.a = value;
						base.graphic.color = color;
					}
				}
			}
		}

		public Color clearColor { get; set; }

		public bool isDirty { get; private set; }

		protected override void OnEnable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild += OnBeforeCanvasRebuild;
			UIExtraCallbacks.onAfterCanvasRebuild += RenderSoftMaskBuffer;
			if ((bool)base.graphic)
			{
				base.graphic.RegisterDirtyMaterialCallback(UpdateParentSoftMask);
				base.graphic.RegisterDirtyVerticesCallback(SetSoftMaskDirty);
				base.graphic.SetVerticesDirty();
			}
			AddSoftMaskableOnChildren();
			OnCanvasHierarchyChanged();
			_shapeContainer = GetComponent<MaskingShapeContainer>();
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= OnBeforeCanvasRebuild;
			UIExtraCallbacks.onAfterCanvasRebuild -= RenderSoftMaskBuffer;
			if ((bool)base.graphic)
			{
				base.graphic.UnregisterDirtyMaterialCallback(UpdateParentSoftMask);
				base.graphic.UnregisterDirtyVerticesCallback(SetSoftMaskDirty);
				base.graphic.SetVerticesDirty();
			}
			UpdateParentSoftMask(null);
			children.Clear();
			MeshExtensions.Return(ref _mesh);
			SoftMaskUtils.materialPropertyBlockPool.Return(ref _mpb);
			SoftMaskUtils.commandBufferPool.Return(ref _cb);
			RenderTextureRepository.Release(ref _softMaskBuffer);
			UpdateCanvasViewChangeTrigger(null);
			_rootCanvas = null;
			_shapeContainer = null;
			UpdateAntiAlias();
			base.OnDisable();
		}

		protected override void OnDestroy()
		{
			ListPool<SoftMask>.Return(ref _children);
			_onBeforeCanvasRebuild = null;
			_renderSoftMaskBuffer = null;
			_setSoftMaskDirty = null;
			_onCanvasViewChanged = null;
			_updateParentSoftMask = null;
		}

		protected override void OnCanvasHierarchyChanged()
		{
			if (base.isActiveAndEnabled)
			{
				_rootCanvas = this.GetRootComponent<Canvas>();
				UpdateCanvasViewChangeTrigger(null);
			}
		}

		protected override void OnDidApplyAnimationProperties()
		{
			SetSoftMaskDirty();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			SetDirtyAndNotifyIfBufferSizeChanged();
		}

		protected void OnTransformChildrenChanged()
		{
			AddSoftMaskableOnChildren();
		}

		protected override void OnTransformParentChanged()
		{
			UpdateParentSoftMask();
			UpdateCanvasViewChangeTrigger(CanvasViewChangeTrigger.Find(base.transform));
		}

		void IMaskable.RecalculateMasking()
		{
			SetSoftMaskDirty();
			if (!SoftMaskingEnabled() && (bool)_softMaskBuffer)
			{
				RenderTextureRepository.Release(ref _softMaskBuffer);
			}
		}

		void IMaskingShapeContainerOwner.Register(MaskingShapeContainer container)
		{
			_shapeContainer = container;
		}

		void IMeshModifier.ModifyMesh(Mesh mesh)
		{
		}

		void IMeshModifier.ModifyMesh(VertexHelper verts)
		{
			if (!SoftMaskingEnabled())
			{
				MeshExtensions.Return(ref _mesh);
				return;
			}
			if (!_mesh)
			{
				_mesh = MeshExtensions.Rent();
			}
			_mesh.Clear(keepVertexLayout: false);
			verts.FillMesh(_mesh);
			_mesh.RecalculateBounds();
		}

		private void SetDirtyAndNotifyIfBufferSizeChanged()
		{
			if (SoftMaskingEnabled() && (bool)_softMaskBuffer)
			{
				Vector2Int screenSize = RenderTextureRepository.GetScreenSize((int)downSamplingRate);
				if (!RenderTextureRepository.Valid(new Hash128((uint)GetInstanceID(), (uint)screenSize.x, (uint)screenSize.y, 0u), _softMaskBuffer))
				{
					SetDirtyAndNotify();
				}
			}
		}

		private void AddSoftMaskableOnChildren()
		{
			if (base.isActiveAndEnabled && SoftMaskingEnabled())
			{
				this.AddComponentOnChildren<SoftMaskable>(UISoftMaskProjectSettings.hideFlagsForTemp, includeSelf: true);
			}
		}

		private void OnBeforeCanvasRebuild()
		{
			switch (maskingMode)
			{
			case MaskingMode.SoftMasking:
				if (base.transform.HasChanged(ref _prevTransformMatrix, UISoftMaskProjectSettings.sensitivity))
				{
					SetSoftMaskDirty();
				}
				if (!_viewChangeTrigger && (bool)_rootCanvas)
				{
					UpdateCanvasViewChangeTrigger(CanvasViewChangeTrigger.Find(base.transform));
					SetSoftMaskDirty();
				}
				break;
			case MaskingMode.AntiAliasing:
				if ((bool)this && (bool)base.graphic)
				{
					Utils.UpdateAntiAlias(base.graphic, base.isActiveAndEnabled, antiAliasingThreshold);
				}
				break;
			}
		}

		private void UpdateCanvasViewChangeTrigger(CanvasViewChangeTrigger trigger)
		{
			if (_viewChangeTrigger != trigger)
			{
				if ((bool)_viewChangeTrigger)
				{
					_viewChangeTrigger.onCanvasViewChanged -= OnCanvasViewChanged;
				}
				if ((bool)trigger)
				{
					trigger.onCanvasViewChanged += OnCanvasViewChanged;
				}
			}
			_viewChangeTrigger = trigger;
		}

		public override bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (FrameCache.TryGet<bool>(this, "IsRaycastLocationValid", out var result))
			{
				return result;
			}
			if (!base.isActiveAndEnabled)
			{
				FrameCache.Set(this, "IsRaycastLocationValid", result: true);
				return true;
			}
			if ((bool)_parent && !_parent.IsRaycastLocationValid(sp, eventCamera))
			{
				FrameCache.Set(this, "IsRaycastLocationValid", result: false);
				return false;
			}
			result = base.IsRaycastLocationValid(sp, eventCamera);
			if (!SoftMaskingEnabled())
			{
				FrameCache.Set(this, "IsRaycastLocationValid", result);
				return result;
			}
			if (result && alphaHitTest)
			{
				result = Utils.AlphaHitTestValid(base.graphic, sp, eventCamera, 0.01f);
			}
			if ((bool)_shapeContainer)
			{
				result |= _shapeContainer.IsInside(sp, eventCamera, defaultValid: false, 0.5f);
			}
			FrameCache.Set(this, "IsRaycastLocationValid", result);
			return result;
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			if (!base.isActiveAndEnabled)
			{
				return baseMaterial;
			}
			if (SoftMaskingEnabled() && !UISoftMaskProjectSettings.useStencilOutsideScreen)
			{
				base.graphic.canvasRenderer.hasPopInstruction = false;
				base.graphic.canvasRenderer.popMaterialCount = 0;
				if (!base.showMaskGraphic)
				{
					return null;
				}
				return baseMaterial;
			}
			return base.GetModifiedMaterial(baseMaterial);
		}

		private void SetDirtyAndNotify()
		{
			SetSoftMaskDirty();
			MaskUtilities.NotifyStencilStateChanged(this);
		}

		private void OnCanvasViewChanged()
		{
			_hasResolutionChanged = true;
			SetDirtyAndNotify();
		}

		public void SetSoftMaskDirty()
		{
			if (isDirty || !this || !base.isActiveAndEnabled)
			{
				return;
			}
			isDirty = true;
			for (int num = children.Count - 1; num >= 0; num--)
			{
				if ((bool)children[num])
				{
					children[num].SetSoftMaskDirty();
				}
				else
				{
					children.RemoveAt(num);
				}
			}
		}

		public bool SoftMaskingEnabled()
		{
			if (GetActualMaskingMode() == MaskingMode.SoftMasking)
			{
				return MaskEnabled();
			}
			return false;
		}

		public bool AntiAliasingEnabled()
		{
			if (GetActualMaskingMode() == MaskingMode.AntiAliasing)
			{
				return MaskEnabled();
			}
			return false;
		}

		internal MaskingMode GetActualMaskingMode()
		{
			if (maskingMode != MaskingMode.Normal)
			{
				if (!UISoftMaskProjectSettings.softMaskEnabled || maskingMode != MaskingMode.SoftMasking)
				{
					return MaskingMode.AntiAliasing;
				}
				return MaskingMode.SoftMasking;
			}
			return MaskingMode.Normal;
		}

		private void UpdateParentSoftMask()
		{
			if (SoftMaskingEnabled())
			{
				Transform stopAfter = MaskUtilities.FindRootSortOverrideCanvas(base.transform);
				SoftMask componentInParent = base.transform.GetComponentInParent(includeSelf: false, stopAfter, (SoftMask x) => x.SoftMaskingEnabled());
				UpdateParentSoftMask(componentInParent);
			}
			else
			{
				UpdateParentSoftMask(null);
			}
		}

		private void UpdateParentSoftMask(SoftMask newParent)
		{
			if ((bool)_parent && _parent.children.Contains(this))
			{
				_parent.children.Remove(this);
			}
			if ((bool)newParent && !newParent.children.Contains(this))
			{
				newParent.children.Add(this);
			}
			if (_parent != newParent)
			{
				SetSoftMaskDirty();
			}
			_parent = newParent;
		}

		private void UpdateAntiAlias()
		{
			bool flag = base.isActiveAndEnabled && maskingMode == MaskingMode.AntiAliasing;
			Utils.UpdateAntiAlias(base.graphic, flag, antiAliasingThreshold);
		}

		private bool IsInScreen()
		{
			if ((bool)base.graphic && base.graphic.IsInScreen())
			{
				return true;
			}
			if ((bool)_shapeContainer && _shapeContainer.IsInScreen())
			{
				return true;
			}
			return false;
		}

		private void RenderSoftMaskBuffer()
		{
			if (!SoftMaskingEnabled() || FrameCache.TryGet<bool>(this, "RenderSoftMaskBuffer", out var _))
			{
				return;
			}
			FrameCache.Set(this, "RenderSoftMaskBuffer", result: true);
			if (!isDirty)
			{
				return;
			}
			isDirty = false;
			if ((bool)_parent)
			{
				_parent.RenderSoftMaskBuffer();
			}
			int num = softMaskDepth;
			if (num < 0 || 4 <= num)
			{
				return;
			}
			if (_cb == null)
			{
				_cb = SoftMaskUtils.commandBufferPool.Rent();
				_cb.name = "[SoftMask] SoftMaskBuffer";
			}
			if (_mpb == null)
			{
				_mpb = SoftMaskUtils.materialPropertyBlockPool.Rent();
				_mpb.Clear();
			}
			if (!IsInScreen())
			{
				if (_hasSoftMaskBufferDrawn || _hasResolutionChanged)
				{
					_cb.Clear();
					_cb.SetRenderTarget(softMaskBuffer);
					_cb.ClearRenderTarget(clearDepth: true, clearColor: true, clearColor);
					Graphics.ExecuteCommandBuffer(_cb);
				}
				_hasSoftMaskBufferDrawn = false;
				_hasResolutionChanged = false;
				return;
			}
			_cb.Clear();
			_cb.SetRenderTarget(softMaskBuffer);
			if (softMaskDepth == 0 || _hasResolutionChanged)
			{
				_cb.ClearRenderTarget(clearDepth: true, clearColor: true, clearColor);
			}
			Camera.MonoOrStereoscopicEye[] array = (base.graphic.canvas.IsStereoCanvas() ? s_StereoEyes : s_MonoEyes);
			for (int i = 0; i < array.Length; i++)
			{
				RenderSoftMaskBuffer(_cb, array[i]);
			}
			Graphics.ExecuteCommandBuffer(_cb);
			_hasSoftMaskBufferDrawn = true;
			_hasResolutionChanged = false;
			onRenderSoftMaskBuffer?.Invoke(this);
		}

		private void RenderSoftMaskBuffer(CommandBuffer cb, Camera.MonoOrStereoscopicEye eye)
		{
			if (_hasResolutionChanged)
			{
				SoftMask parent = _parent;
				while ((bool)parent)
				{
					parent.RenderSoftMaskBuffer(cb, eye);
					parent = parent._parent;
				}
			}
			base.graphic.canvas.rootCanvas.GetViewProjectionMatrix(eye, out var vMatrix, out var pMatrix);
			cb.SetViewProjectionMatrices(vMatrix, pMatrix);
			Texture mainTexture = base.graphic.mainTexture;
			SoftMaskUtils.ApplyMaterialPropertyBlock(_mpb, softMaskDepth, mainTexture, softnessRange, alpha);
			if (!_hasResolutionChanged && eye != Camera.MonoOrStereoscopicEye.Right && (bool)_parent && (bool)_parent.softMaskBuffer)
			{
				_cb.Blit(_parent.softMaskBuffer, softMaskBuffer);
			}
			if (eye != Camera.MonoOrStereoscopicEye.Mono)
			{
				float num = (float)softMaskBuffer.width * 0.5f;
				int height = softMaskBuffer.height;
				cb.SetViewport(new Rect(num * (float)eye, 0f, num, height));
			}
			Mesh mesh = _mesh;
			if ((bool)mesh)
			{
				Material softMaskingMaterial = SoftMaskUtils.GetSoftMaskingMaterial(MaskingShape.MaskingMethod.Additive);
				cb.DrawMesh(mesh, base.transform.localToWorldMatrix, softMaskingMaterial, 0, 0, _mpb);
			}
			if ((bool)_shapeContainer)
			{
				_shapeContainer.DrawSoftMaskBuffer(cb, softMaskDepth);
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (0f <= m_Softness)
			{
				m_SoftnessRange = new MinMax01(0f, Mathf.Clamp01(m_Softness));
				m_Softness = -1f;
			}
			if (m_PartOfParent)
			{
				Debug.LogWarning("[SoftMask] The 'partOfParent' property is obsolete. Use MaskingShape component instead.", this);
			}
		}
	}
}
