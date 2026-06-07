using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Enemies
{
	[Serializable]
	[Title("Collider Override")]
	public class ColliderOverride
	{
		[Title("Radius")]
		public float radius { get; set; }

		[Title("Offset X")]
		public float offsetX { get; set; }

		[Title("Offset Y")]
		public float offsetY { get; set; }

		[Title("Update collider based on FlipX")]
		public bool updateBasedOnFlipX { get; set; }

		[Title("Offset X When Flipped")]
		public float offsetXWhenFlipped { get; set; }
	}
}
