using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BonusSystem;
using Timberborn.CharacterMovementSystem;
using Timberborn.Characters;
using Timberborn.Common;
using Timberborn.Goods;
using Timberborn.Persistence;
using Timberborn.WorldPersistence;

namespace Timberborn.Carrying
{
	public class GoodCarrier : BaseComponent, IAwakableComponent, IPersistentEntity, IMovementSpeedAffector
	{
		private static readonly string CarryingCapacityBonusId = "CarryingCapacity";

		private static readonly ComponentKey GoodCarrierKey = new ComponentKey("GoodCarrier");

		private static readonly PropertyKey<GoodAmount> CarriedGoodsKey = new PropertyKey<GoodAmount>("CarriedGoods");

		private static readonly PropertyKey<bool> CountGoodsAsAvailableKey = new PropertyKey<bool>("CountGoodAsAvailable");

		private readonly GoodAmountSerializer _goodAmountSerializer;

		private BonusManager _bonusManager;

		private GoodCarrierSpec _goodCarrierSpec;

		public GoodAmount CarriedGoods { get; private set; }

		public bool CountGoodsAsAvailable { get; private set; }

		public int LiftingCapacity
		{
			get
			{
				double num = Math.Round(_bonusManager.Multiplier(CarryingCapacityBonusId), 2);
				return (int)((double)_goodCarrierSpec.BaseLiftingCapacity * num);
			}
		}

		public bool IsCarrying => CarriedGoods.Amount > 0;

		public bool IsMovementSlowed => IsCarrying;

		public event EventHandler<CarriedGoodsChangedEventArgs> CarriedGoodsChanged;

		public GoodCarrier(GoodAmountSerializer goodAmountSerializer)
		{
			_goodAmountSerializer = goodAmountSerializer;
		}

		public void Awake()
		{
			GetComponent<Character>().Died += OnDied;
			_bonusManager = GetComponent<BonusManager>();
			_goodCarrierSpec = GetComponent<GoodCarrierSpec>();
		}

		public void PutGoodsInHands(GoodAmount goods, bool countAsAvailable)
		{
			if (!IsCarrying)
			{
				SetCarriedGoods(goods);
				CountGoodsAsAvailable = countAsAvailable;
				return;
			}
			throw new InvalidOperationException($"Tried to put {goods} in {base.Name}'s hands " + "but they are already carrying something");
		}

		public void EmptyHands()
		{
			SetCarriedGoods(new GoodAmount(null, 0));
		}

		public void Save(IEntitySaver entitySaver)
		{
			if (IsCarrying)
			{
				IObjectSaver component = entitySaver.GetComponent(GoodCarrierKey);
				component.Set(CarriedGoodsKey, CarriedGoods, _goodAmountSerializer);
				component.Set(CountGoodsAsAvailableKey, CountGoodsAsAvailable);
			}
		}

		[BackwardCompatible(2026, 2, 23, Compatibility.Save)]
		public void Load(IEntityLoader entityLoader)
		{
			if (entityLoader.TryGetComponent(GoodCarrierKey, out var objectLoader) && objectLoader.GetObsoletable(CarriedGoodsKey, _goodAmountSerializer, out var value))
			{
				bool countAsAvailable = objectLoader.Has(CountGoodsAsAvailableKey) && objectLoader.Get(CountGoodsAsAvailableKey);
				PutGoodsInHands(value, countAsAvailable);
			}
			else
			{
				EmptyHands();
			}
		}

		private void OnDied(object sender, EventArgs e)
		{
			EmptyHands();
		}

		private void SetCarriedGoods(GoodAmount goods)
		{
			CarriedGoods = goods;
			this.CarriedGoodsChanged?.Invoke(this, new CarriedGoodsChangedEventArgs(CarriedGoods));
		}
	}
}
