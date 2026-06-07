using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MadMoonProjectile : Projectile
	{
		private Camera _camera;

		private float bounceBack;

		private float scaleUp;

		private bool bigWin;

		private int reel;

		public SpriteTrail trail;

		[FormerlySerializedAs("symbol")]
		public MadMoonSymbol madMoonSymbol;

		public MadMoonSymbolType type;

		private Tween _positionTween;

		private Tween _scaleTween;

		private Vector3 initialCamPos;

		private MadMoonWeapon _parentWeapon;

		private MultiTargetTween _groundTween;

		public float Duration_ScaleAnimation;

		public float Duration_FadeOut;

		public float Duration_Starting;

		public float Duration_Landing;

		public float Duration_Spinning;

		private PhaserSprite _GroundFx { get; set; }

		private PhaserSprite _GroundFxRing { get; set; }

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void PlayGroundFX()
		{
		}

		public void SetBigWin(bool _bigWin)
		{
		}

		public void AfterInit(MadMoonSymbolType type, MadMoonSymbol madMoonSymbol, int reel, Vector2 pos)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void setSprite(MadMoonSymbol madMoonSymbol)
		{
		}

		private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
		{
			return 0f;
		}

		private void DoScaleEffect()
		{
		}

		public void startMoving()
		{
		}

		private void GetComponents()
		{
		}

		private void KeepUpWithCameraMovement(float f)
		{
		}

		private void LandingFinished()
		{
		}

		public void ScaleAnimation()
		{
		}

		public Tween FadeOut()
		{
			return null;
		}

		public Tween FadeOn()
		{
			return null;
		}
	}
}
