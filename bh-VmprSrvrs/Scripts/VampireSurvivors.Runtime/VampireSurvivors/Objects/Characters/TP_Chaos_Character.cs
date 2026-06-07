using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Chaos_Character : TP_Character
	{
		private PhaserSprite _spriteRing0;

		private PhaserSprite _spriteRing1;

		private PhaserSprite _spriteRing2;

		private PhaserSprite _spriteStatue1;

		private PhaserSprite _spriteStatue2;

		private PhaserSprite _spriteStatue3;

		private PhaserSprite _spriteBackground;

		private float _radius;

		private List<ArcanaType> arcanas;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
