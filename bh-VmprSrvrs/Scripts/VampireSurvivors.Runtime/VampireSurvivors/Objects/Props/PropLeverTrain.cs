using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class PropLeverTrain : Destructible
	{
		private Stage _stage;

		private bool _hasFired;

		private GameObject _PizzaCircleObj;

		public PizzaCircle PizzaCircle;

		private MultiTargetTween _tween1;

		private Timer _selfCleanTimer;

		[Inject]
		private void Construct(Stage stage)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
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

		protected void OnTriggeredByPlayer()
		{
		}
	}
}
