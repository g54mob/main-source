using System;
using Coffee.UIEffectInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public abstract class UIEffectBase : UIBehaviour, IMeshModifier, IMaterialModifier, ICanvasRaycastFilter, ITimeControl
	{
		private static readonly InternalObjectPool<UIEffectContext> s_ContextPool;

		private Graphic _graphic;

		private Material _material;

		private UIEffectContext _context;

		private Action _onBeforeCanvasRebuild;

		private Action _onAfterCanvasRebuild;

		private bool _canModifyMesh;

		private Matrix4x4 _prevTransformHash;

		private Canvas _canvas;

		private bool _canvasCached;

		public Material effectMaterial => null;

		public Graphic graphic => null;

		public virtual uint effectId => 0u;

		public virtual float actualSamplingScale => 0f;

		public virtual bool canModifyShape => false;

		protected Canvas canvas => null;

		public virtual UIEffectContext context => null;

		public virtual RectTransform transitionRoot => null;

		protected Material GetCurrentMaterial()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnBeforeCanvasRebuild()
		{
		}

		private void OnAfterCanvasRebuild()
		{
		}

		protected override void OnCanvasHierarchyChanged()
		{
		}

		public void ModifyMesh(Mesh mesh)
		{
		}

		public virtual void ModifyMesh(VertexHelper vh)
		{
		}

		private bool CanModifyMesh()
		{
			return false;
		}

		public virtual Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		public virtual void SetVerticesDirty()
		{
		}

		public virtual void SetMaterialDirty()
		{
		}

		internal void ReleaseMaterial()
		{
		}

		internal abstract void UpdateContext(UIEffectContext c);

		public virtual void ApplyContextToMaterial(Material material)
		{
		}

		public abstract void SetRate(float rate, UIEffectTweener.CullingMask cullingMask);

		public abstract bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);

		public void SetTime(double _)
		{
		}

		public void OnControlTimeStart()
		{
		}

		public void OnControlTimeStop()
		{
		}
	}
}
