using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class CoinBagMax : Pickup
	{
		private GoldFeverController _goldFever;

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
	}
}
