using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class StoreBaskets : CTSSingleton<StoreBaskets>
	{
		[SerializeField]
		private SerializableDictionary<StringKey, MissionBasket> _missionBaskets;

		[field: SerializeField]
		[field: Inject(false)]
		public BuyBasket BuyBasket { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		public SellBasket SellBasket { get; private set; }

		[field: SerializeField]
		public StringKey MainMissionBasketKey { get; private set; }

		[field: SerializeField]
		public StringKey SecondaryMissionBasketKey { get; private set; }

		public ReadOnlyDictionary<StringKey, MissionBasket> MissionBaskets => _missionBaskets;

		public MissionBasket MainMissionBasket => MissionBaskets.GetValueOrDefault(MainMissionBasketKey);

		public MissionBasket SecondaryMissionBasket => MissionBaskets.GetValueOrDefault(SecondaryMissionBasketKey);

		public MissionBasket GetMissionBasket(StringKey key)
		{
			if (!_missionBaskets.TryGetValue(key, out var value))
			{
				return null;
			}
			return value;
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
