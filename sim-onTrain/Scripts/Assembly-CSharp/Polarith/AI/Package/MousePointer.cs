using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Mouse Pointer")]
	public sealed class MousePointer : MonoBehaviour
	{
		[Tooltip("An optional reference to a SpriteRenderer representing a crosshair.")]
		public SpriteRenderer CrosshairRenderer;

		private Vector3 position;

		public Vector3 Position => position;

		private void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			new Plane(Vector3.forward, new Vector3(0f, 0f, 0f)).Raycast(ray, out var enter);
			position = ray.GetPoint(enter);
			if (CrosshairRenderer != null)
			{
				CrosshairRenderer.transform.position = new Vector3(position.x, position.y, CrosshairRenderer.transform.position.z);
			}
		}
	}
}
