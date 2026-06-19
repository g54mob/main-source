using System.Collections.Generic;
using System.Linq;
using Computer.Sites.Services.Delivery;
using JSAM;
using Services.Missions;
using UnityEngine;
using Zenject;

namespace UI.Map.MapIndicators
{
	public class MainIslandMapIndicatorViewModel : MapIndicatorViewModel
	{
		[Inject]
		private ISiteDeliveryService _deliveryService;

		[Inject]
		private readonly MissionEventBus _missionEventBus;

		public MainIslandMapIndicatorViewModel(Sprite indicatorSprite)
			: base(indicatorSprite)
		{
		}

		public override void OnIndicatorClick()
		{
			Debug.Log("main island clicked");
			List<DeliveryOrder> list = _deliveryService.ActiveOrders.Where((DeliveryOrder o) => !o.InProgress).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			AudioManager.PlaySound(UILibrarySounds.UIMapDeliverySet);
			_missionEventBus.Emit("interact", "selectIsland");
			foreach (DeliveryOrder item in list)
			{
				item.DestinationSet = true;
				item.InProgress = true;
			}
		}
	}
}
