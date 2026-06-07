using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DControllerObject
	{
		public Slicer2DInputController input;

		public Slicer2DControllerEventHandling eventHandler;

		public Slicer2DVisuals visuals;

		public Slice2DLayer sliceLayer;

		public void SetController(GameObject gameObject, Slicer2DInputController inputController, Slicer2DVisuals visualsSettings, Slice2DLayer layerObject, Slicer2DControllerEventHandling eventHandling)
		{
		}
	}
}
