using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Vento2ExploProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private uint[] _colorss;

		private SpriteAnimation _anims;

		private PhaserSprite _ghost1;

		private PhaserSprite _ghost2;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private int _repeatCount;

		private int _colorCount;

		private static float[] s_detunes;

		private static int s_detunesIndex;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
