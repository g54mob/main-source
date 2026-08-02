using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Sprite Rotation")]
	public sealed class SpriteRotation : MonoBehaviour
	{
		[Tooltip("The transform of the sprite that should be flipped.")]
		public Transform SpriteTransform;

		private float scaleY;

		private void Start()
		{
			if (SpriteTransform == null)
			{
				base.enabled = false;
			}
			else
			{
				scaleY = SpriteTransform.localScale.y;
			}
		}

		private void Update()
		{
			float num = ((base.transform.up.normalized.x > 0f) ? 1f : (-1f));
			SpriteTransform.localScale = new Vector3(SpriteTransform.localScale.x, scaleY * num, SpriteTransform.localScale.z);
		}
	}
}
