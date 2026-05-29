using UnityEngine;

namespace GameKit.Utilities.Types.CanvasContainers
{
	public class ImageButtonData : ButtonData
	{
		public Sprite DisplayImage { get; protected set; }

		public void Initialize(Sprite sprite, string text, PressedDelegate callback, string key = "")
		{
		}

		public override void ResetState()
		{
		}
	}
}
