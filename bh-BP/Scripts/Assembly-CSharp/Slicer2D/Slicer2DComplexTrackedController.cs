using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DComplexTrackedController : MonoBehaviour
	{
		public ComplexSlicerTracker trackerObject;

		public Color color;

		public float lineWidth;

		public float zPosition;

		private Mesh mesh;

		private static SmartMaterial material;

		public Slicer2DVisuals visuals;

		public Material GetStaticMaterial()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}
	}
}
