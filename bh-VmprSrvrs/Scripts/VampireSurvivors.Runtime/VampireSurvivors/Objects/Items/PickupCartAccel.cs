using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCartAccel : NetworkPickup
	{
		private Timer _selfCleanTimer;

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

		private void OnRecycle()
		{
		}

		private void SelfClean()
		{
		}

		public override void GetTaken()
		{
		}

		private void TryAccelerate()
		{
		}

		public override void UpdateDepth()
		{
		}
	}
}
