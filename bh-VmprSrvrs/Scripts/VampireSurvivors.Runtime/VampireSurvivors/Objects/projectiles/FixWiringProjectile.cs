using System;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FixWiringProjectile : Projectile
	{
		private PhaserSprite _line;

		private PhaserSprite _wireCap;

		private FixWiringWeapon _trueWeapon;

		private bool _followCap;

		private MultiTargetTween _lineTween;

		private MultiTargetTween _wireCapTween;

		[NonSerialized]
		public bool Connected;

		[NonSerialized]
		public uint Color;

		[NonSerialized]
		public float2 StartPos;

		[NonSerialized]
		public float2 TargetPos;

		[NonSerialized]
		public int Num;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void Cleanup()
		{
		}

		public void setWireCapPos(float2 worldPos)
		{
		}

		public void startLine(float2 from, float2 to, uint color, int num)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void connectLine()
		{
		}

		public void SetCapVisible(bool visible)
		{
		}

		public void clearLine()
		{
		}

		public override void Despawn()
		{
		}
	}
}
