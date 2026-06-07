using CTS.Core;

namespace CTS
{
	public class SaveMissionBasket : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("MainBasket", CTSSingleton<StoreBaskets>.Instance.MainMissionBasket, settings);
			ES3.Save("SecondaryBasket", CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, settings);
			ES3.Save("CharacterDeliveries", CTSSingleton<CharacterDeliveries>.Instance, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			if (ES3.KeyExists("MissionBasket"))
			{
				LoadInto("MissionBasket", CTSSingleton<StoreBaskets>.Instance.MainMissionBasket, settings);
				return;
			}
			LoadInto("MainBasket", CTSSingleton<StoreBaskets>.Instance.MainMissionBasket, settings);
			LoadInto("SecondaryBasket", CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, settings);
			LoadInto("CharacterDeliveries", CTSSingleton<CharacterDeliveries>.Instance, settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
			LoadInit(settings);
		}
	}
}
