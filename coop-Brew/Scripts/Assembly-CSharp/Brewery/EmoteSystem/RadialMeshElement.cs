using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.EmoteSystem
{
	public class RadialMeshElement : VisualElement
	{
		public new class UxmlFactory : UxmlFactory<RadialMeshElement, UxmlTraits>
		{
		}

		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			private UxmlIntAttributeDescription m_WedgeCount;

			private UxmlIntAttributeDescription m_HighlightedIndex;

			private UxmlFloatAttributeDescription m_InnerRadius;

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
			}
		}

		private int _wedgeCount;

		private int _highlightedIndex;

		private float _innerRadius;

		private static readonly Color DefaultHighlightColor;

		private static readonly Color DefaultHighlightBorderColor;

		private Color _bgColor;

		private Color _innerBgColor;

		private Color _dividerColor;

		private Color _highlightColor;

		private Color _highlightBorderColor;

		private Color _ringColor;

		private const int ARC_SEGMENTS = 16;

		private float _highlightAmount;

		private float _easedHighlightAmount;

		private int _prevHighlightedIndex;

		private float _extraAngleDeg;

		private float _animationSpeed;

		private float _idlePulseTime;

		private bool _isIdlePulsing;

		private const float PulseSpeed = 2.5f;

		private const float PulseMinAlpha = 0.02f;

		private const float PulseMaxAlpha = 0.12f;

		private const float PulseRadiusOffset = 3f;

		private bool[] _recentWedges;

		private static readonly Color RecentBandColor;

		private static readonly Color RecentBandEdgeColor;

		private const float RecentBandWidth = 5f;

		private float[] _wedgeSizes;

		private float[] _wedgeStarts;

		public int wedgeCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int highlightedIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float innerRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color highlightColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color highlightBorderColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public void ResetHighlightColors()
		{
		}

		public void SetRecentWedges(bool[] recent)
		{
		}

		public void ClearRecentWedges()
		{
		}

		private static float ElasticOut(float t)
		{
			return 0f;
		}

		public bool UpdateAnimation(float deltaTime)
		{
			return false;
		}

		private void ComputeWedgeLayout()
		{
		}

		private static Vector2 PointOnCircle(float cx, float cy, float radius, float angleDeg)
		{
			return default(Vector2);
		}

		private static void DrawArcPath(Painter2D painter, float cx, float cy, float radius, float startAngleDeg, float endAngleDeg, int segments, bool moveToFirst)
		{
		}

		private void OnGenerateVisualContent(MeshGenerationContext mgc)
		{
		}
	}
}
