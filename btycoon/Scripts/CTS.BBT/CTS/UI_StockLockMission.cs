using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_StockLockMission : UI_StockItemLocker
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ShopBasket> _basket;

		protected ShopBasket Basket => _basket;

		protected override void OnEnabled()
		{
			MissionBasket.MissionStarted += OnMissionStarted;
			MissionBasket.MissionEnded += OnMissionEnded;
			base.OnEnabled();
		}

		protected override void OnDisabled()
		{
			MissionBasket.MissionStarted -= OnMissionStarted;
			MissionBasket.MissionEnded -= OnMissionEnded;
			base.OnDisabled();
		}

		private void OnMissionStarted(MissionBasket basket)
		{
			if (!(basket != Basket))
			{
				UpdateVisual();
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult obj)
		{
			if (!(basket != Basket))
			{
				UpdateVisual();
			}
		}

		protected override bool IsLocked()
		{
			if (base.IsLocked())
			{
				return true;
			}
			if (!(Basket is MissionBasket missionBasket))
			{
				return true;
			}
			if (!missionBasket.HasMission())
			{
				return true;
			}
			return !missionBasket.CurrentMissionStatus.ContainsKey(_itemSO);
		}
	}
}
