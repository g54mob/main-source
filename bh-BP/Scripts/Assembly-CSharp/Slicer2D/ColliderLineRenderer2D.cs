using UnityEngine;

namespace Slicer2D
{
	[ExecuteInEditMode]
	public class ColliderLineRenderer2D : MonoBehaviour
	{
		public bool customColor;

		public Color color;

		public float lineWidth;

		private VisualMesh visualMesh;

		private Polygon2D polygon;

		private float lineWidthSet;

		private SmartMaterial material;

		private static SmartMaterial staticMaterial;

		public bool drawEdgeCollider;

		private const float lineOffset = -0.01f;

		public SmartMaterial GetMaterial()
		{
			return null;
		}

		public SmartMaterial GetStaticMaterial()
		{
			return null;
		}

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		private void OnDestroy()
		{
		}

		public void LateUpdate()
		{
		}

		public Polygon2D GetPolygon()
		{
			return null;
		}

		public void GenerateMesh()
		{
		}

		public void Draw()
		{
		}
	}
}
