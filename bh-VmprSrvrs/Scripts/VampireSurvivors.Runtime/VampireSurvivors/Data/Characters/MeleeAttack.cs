using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	[Title("Melee Attack")]
	public class MeleeAttack
	{
		[Title("Texture Name")]
		public string textureName { get; set; }

		[Title("Sprite Name")]
		public string spriteName { get; set; }

		[Title("Frames Number")]
		public int framesNumber { get; set; }

		[Title("Frame Rate")]
		public int frameRate { get; set; }
	}
}
