using UnityEngine;

namespace Slicer2D
{
	[CreateAssetMenu(fileName = "Data", menuName = "Slicer2D/Settings Profile", order = 1)]
	public class Slicer2DSettingsProfile : ScriptableObject
	{
		public bool garbageCollector;

		public float garbageCollectorSize;

		public int explosionPieces;

		public Slicer2DSettings.Batching batching;

		public Slicer2DSettings.Triangulation triangulation;

		public Slicer2DSettings.InstantiationMethod componentsCopy;

		public Slicer2DSettings.RenderingPipeline renderingPipeline;

		public Slicer2DSettings.CenterOfSliceTransform centerOfSliceTransform;
	}
}
