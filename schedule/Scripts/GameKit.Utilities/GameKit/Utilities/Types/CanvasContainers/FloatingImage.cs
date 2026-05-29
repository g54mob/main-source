using GameKit.Dependencies.Inspectors;
using UnityEngine;
using UnityEngine.UI;

namespace GameKit.Utilities.Types.CanvasContainers
{
	public class FloatingImage : FloatingContainer
	{
		[Tooltip("Renderer to apply sprite on.")]
		[Group("Components", false)]
		[SerializeField]
		protected Image Renderer;

		public virtual void SetSprite(Sprite sprite, Vector3? sizeOverride)
		{
		}
	}
}
