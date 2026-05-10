using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class GradientModifier : BaseMeshEffect
	{
		public enum Style
		{
			Horizontal = 0,
			Vertical = 1,
			Radial = 2,
			Diamond = 3
		}

		public enum Blend
		{
			Override = 0,
			Add = 1,
			Multiply = 2
		}

		[SerializeField]
		private Style gradientStyle;

		[SerializeField]
		private Blend blend;

		[SerializeField]
		private bool moreVertices;

		[SerializeField]
		[Range(-1f, 1f)]
		private float offset;

		[SerializeField]
		[Range(0.1f, 10f)]
		private float scale;

		[SerializeField]
		private Gradient gradient;

		private List<UIVertex> vertexList;

		private List<float> gradientKeysPos;

		private List<int> originIndices;

		private List<UIVertex> starts;

		private List<UIVertex> ends;

		private float[] cachedVertexPositions;

		public Style GradientStyle
		{
			get
			{
				return default(Style);
			}
			set
			{
			}
		}

		public Blend BlendMode
		{
			get
			{
				return default(Blend);
			}
			set
			{
			}
		}

		public bool MoreVertices
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Scale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Gradient Gradient
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Color BlendColor(Color colorA, Color colorB)
		{
			return default(Color);
		}

		public override void ModifyMesh(VertexHelper helper)
		{
		}

		private void ModifyMeshForHorizontal(VertexHelper helper)
		{
		}

		private void ModifyMeshForVertical(VertexHelper helper)
		{
		}

		private void ModifyMeshForDiamond(VertexHelper helper)
		{
		}

		private void ModifyMeshForRadial(VertexHelper helper)
		{
		}

		private Rect GetVertsBounds(List<UIVertex> vertices)
		{
			return default(Rect);
		}

		private void SplitOneTriangle(List<UIVertex> vertexList, VertexHelper helper, int triangleIndex)
		{
		}

		private void SplitTrianglesAtGradientKeys(List<UIVertex> vertexList, Rect bounds, float zoomOffset, VertexHelper helper)
		{
		}

		private float[] GetVertexPositions(List<UIVertex> vertexList, int index)
		{
			return null;
		}

		private void FindGradientKeysPos(float zoomOffset, Rect bounds)
		{
		}

		private UIVertex CreateSplitVertex(UIVertex vertex1, UIVertex vertex2, float stop)
		{
			return default(UIVertex);
		}
	}
}
