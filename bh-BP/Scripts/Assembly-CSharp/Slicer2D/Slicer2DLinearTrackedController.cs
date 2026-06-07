using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DLinearTrackedController : MonoBehaviour
	{
		public LinearSlicerTracker trackerObject;

		public float lineWidth;

		private Mesh mesh;

		private static SmartMaterial material;

		public Material GetStaticMaterial()
		{
			return null;
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}
	}
}
