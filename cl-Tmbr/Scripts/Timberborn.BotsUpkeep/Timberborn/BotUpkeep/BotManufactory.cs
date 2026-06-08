using System;
using Timberborn.BaseComponentSystem;
using Timberborn.Bots;
using Timberborn.Buildings;
using Timberborn.CharactersGame;
using Timberborn.EnterableSystem;
using Timberborn.GameDistricts;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;

namespace Timberborn.BotUpkeep
{
	internal class BotManufactory : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private readonly EventBus _eventBus;

		private readonly BotFactory _botFactory;

		private Manufactory _manufactory;

		private BuildingAccessible _buildingAccessible;

		private Enterable _enterable;

		public BotManufactory(EventBus eventBus, BotFactory botFactory)
		{
			_eventBus = eventBus;
			_botFactory = botFactory;
		}

		public void Awake()
		{
			_buildingAccessible = GetComponent<BuildingAccessible>();
			_manufactory = GetComponent<Manufactory>();
			_enterable = GetComponent<Enterable>();
		}

		public void Start()
		{
			_manufactory.ProductionFinished += OnProductionFinished;
		}

		private void OnProductionFinished(object sender, EventArgs e)
		{
			Bot bot = _botFactory.Create(_buildingAccessible.CalculateAccessFromLocalAccess(), _enterable.ExitWorldSpaceRotation);
			DistrictCenter district = GetComponent<DistrictBuilding>().District;
			if ((bool)district)
			{
				bot.GetComponent<Citizen>().AssignInitialDistrict(district);
			}
			bot.GetComponent<CharacterBirthNotifier>().EnableNotification();
			_eventBus.Post(new BotManufacturedEvent());
		}
	}
}
