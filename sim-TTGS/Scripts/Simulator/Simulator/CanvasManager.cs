using UnityEngine;

namespace Simulator
{
	public static class CanvasManager
	{
		public static Canvas CurrentMainCanvas { get; private set; }

		public static void SetMainCanvas(Canvas canvas)
		{
			CurrentMainCanvas = canvas;
		}
	}
}
