using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[RequireComponent(typeof(Graphic))]
	[RequireComponent(typeof(RectTransform))]
	[ExecuteAlways]
	public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier
	{
		private RectTransform _rectTransform;

		private Graphic _graphic;

		private GraphicConnector _connector;

		internal readonly List<UISyncEffect> syncEffects;

		protected GraphicConnector connector => null;

		public Graphic graphic => null;

		protected RectTransform rectTransform => null;

		public virtual void ModifyMesh(Mesh mesh)
		{
		}

		public virtual void ModifyMesh(VertexHelper vh)
		{
		}

		public virtual void ModifyMesh(VertexHelper vh, Graphic graphic)
		{
		}

		protected virtual void SetVerticesDirty()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected virtual void SetEffectParamsDirty()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}
	}
}
