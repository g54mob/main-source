using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCartGoal : NetworkPickup
	{
		private Timer _selfCleanTimer;

		private MultiTargetTween _tween1;

		private bool AlreadyTaken;

		[Inject]
		private void Construct(GameSessionData gameSessionData)
		{
		}

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void UpdateDepth()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void OnRecycle()
		{
		}

		private void SelfClean()
		{
		}

		public override void GetTaken()
		{
		}

		private void TakenTween()
		{
		}

		private void TryTrigger()
		{
		}
	}
}
