using SuperTiled2Unity;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class PropDoubleDoor : Destructible
	{
		private Stage _stage;

		private bool _hasFired;

		private GameObject _PizzaCircleObj;

		public PizzaCircle PizzaCircle;

		private MultiTargetTween _tween1;

		private Timer _selfCleanTimer;

		private bool hasSprites;

		private PhaserSprite _leftSprite;

		private PhaserSprite _rightSprite;

		private SuperObject _SuperObject;

		private SuperCustomProperties _SuperCustomProperties;

		private int _wallWidth;

		private int _wallHeight;

		[Inject]
		private void Construct(Stage stage)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void SetupAnimations()
		{
		}

		public override void Init(PropType destructibleType)
		{
		}

		private void SelfClean()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void OnDestructibleSpawned(SuperObject tiledScriptObject)
		{
		}

		protected void OnTriggeredByPlayer()
		{
		}

		protected void OpenWallTiles()
		{
		}

		protected void CloseWallTiles()
		{
		}

		protected void SpawnEnemyWallColliders()
		{
		}

		public override bool DoesAllowVenting()
		{
			return false;
		}
	}
}
