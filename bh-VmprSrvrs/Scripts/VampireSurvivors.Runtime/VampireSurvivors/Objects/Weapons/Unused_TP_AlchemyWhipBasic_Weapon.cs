using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_AlchemyWhipBasic_Weapon : Weapon
	{
		public class alchemyWhipData
		{
			public bool active;

			public PhaserSprite sprite;

			public MultiTargetTween spriteTweenIn;

			public MultiTargetTween spriteTweenOut;
		}

		public List<float> indexDegreeList;

		public float offsetPhysicsPos;

		public float offsetSpritePos;

		public List<float2> indexPosList;

		public List<alchemyWhipData> _whipData;

		private alchemyWhipData nextWhipSprite()
		{
			return null;
		}

		public void addWhipSprite(float2 pos, int rotationIndex)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
