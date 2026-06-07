using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class Coin : Pickup, ICountedPickup
	{
		private GoldFeverController _goldFever;

		private bool _isJewel;

		private List<string> jewelFrames;

		public int AmountOnCollection { get; set; }

		[Inject]
		private void InjectGoldFever(GoldFeverController gold)
		{
		}

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void Despawn()
		{
		}

		public override void GetTaken()
		{
		}

		public override void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
		{
		}

		public void Bejewel()
		{
		}

		public void PublicSetSprite(string frameName, string textureName)
		{
		}
	}
}
