using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class CoinBag1 : Pickup, ICountedPickup
	{
		private GoldFeverController _goldFever;

		public int AmountOnCollection { get; set; }

		[Inject]
		private void InjectGoldFever(GoldFeverController gold)
		{
		}

		protected override void Awake()
		{
		}

		public override void GetTaken()
		{
		}

		public override void Despawn()
		{
		}
	}
}
