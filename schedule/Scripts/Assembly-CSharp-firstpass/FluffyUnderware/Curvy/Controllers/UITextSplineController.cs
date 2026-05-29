using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Controllers
{
	[RequireComponent(typeof(Text))]
	[HelpURL("https://curvyeditor.com/doclink/uitextsplinecontroller")]
	[AddComponentMenu("Curvy/Controllers/UI Text Spline Controller")]
	public class UITextSplineController : SplineController, IMeshModifier
	{
		protected class GlyphPlain : IGlyph
		{
			public Vector3[] V;

			public Rect Rect;

			public Vector3 Center => default(Vector3);

			public void Load(ref Vector3[] verts, int index)
			{
			}

			public void calcRect()
			{
			}

			public void Save(ref Vector3[] verts, int index)
			{
			}

			public void Transpose(Vector3 v)
			{
			}

			public void Rotate(Quaternion rotation)
			{
			}
		}

		protected class GlyphQuad : IGlyph
		{
			public UIVertex[] V;

			public Rect Rect;

			public Vector3 Center => default(Vector3);

			public void Load(List<UIVertex> verts, int index)
			{
			}

			public void LoadTris(List<UIVertex> verts, int index)
			{
			}

			public void calcRect()
			{
			}

			public void Save(List<UIVertex> verts, int index)
			{
			}

			public void Save(VertexHelper vh)
			{
			}

			public void Transpose(Vector3 v)
			{
			}

			public void Rotate(Quaternion rotation)
			{
			}
		}

		protected interface IGlyph
		{
			Vector3 Center { get; }

			void Transpose(Vector3 v);

			void Rotate(Quaternion rotation);
		}

		[Section("Orientation", true, false, 100)]
		[Tooltip("If true, the text characters will keep the same orientation regardless of the spline they follow")]
		[SerializeField]
		private bool staticOrientation;

		private Graphic m_Graphic;

		private RectTransform rectTransform;

		private Text text;

		public bool StaticOrientation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override bool ShowOrientationSection => false;

		protected override bool ShowOffsetSection => false;

		protected Text Text => null;

		protected RectTransform Rect => null;

		protected Graphic graphic => null;

		public override CurvySpline Spline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void InitializedApplyDeltaTime(float deltaTime)
		{
		}

		public void ModifyMesh(Mesh verts)
		{
		}

		public void ModifyMesh(VertexHelper vertexHelper)
		{
		}

		[UsedImplicitly]
		private void UpdateGlyph(IGlyph glyph)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnValidate()
		{
		}

		protected override void BindEvents()
		{
		}

		protected override void UnbindEvents()
		{
		}

		private void BindSplineRelatedEvents()
		{
		}

		private void UnbindSplineRelatedEvents()
		{
		}

		private void OnSplineRefreshed(CurvySplineEventArgs e)
		{
		}
	}
}
