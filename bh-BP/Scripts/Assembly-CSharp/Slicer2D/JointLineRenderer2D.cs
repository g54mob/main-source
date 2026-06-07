using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[ExecuteInEditMode]
	public class JointLineRenderer2D : MonoBehaviour
	{
		public bool customColor;

		public Color color;

		public float lineWidth;

		private List<Joint2D> joints;

		private SmartMaterial material;

		private static SmartMaterial staticMaterial;

		private VisualMesh visualMesh;

		private const float lineOffset = -0.001f;

		public SmartMaterial GetMaterial()
		{
			return null;
		}

		public SmartMaterial GetStaticMaterial()
		{
			return null;
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void Draw(Pair2 pair)
		{
		}
	}
}
