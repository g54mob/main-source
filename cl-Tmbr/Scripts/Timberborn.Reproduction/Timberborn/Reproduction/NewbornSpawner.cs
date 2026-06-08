using System;
using Timberborn.BaseComponentSystem;
using Timberborn.Beavers;
using Timberborn.Buildings;
using Timberborn.CharactersGame;
using Timberborn.DwellingSystem;
using Timberborn.EnterableSystem;
using Timberborn.GameDistricts;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace Timberborn.Reproduction
{
	public class NewbornSpawner
	{
		private readonly BeaverFactory _beaverFactory;

		private readonly EventBus _eventBus;

		public NewbornSpawner(BeaverFactory beaverFactory, EventBus eventBus)
		{
			_beaverFactory = beaverFactory;
			_eventBus = eventBus;
		}

		public void SpawnAdult(BaseComponent spawner)
		{
			SpawnBeaver(spawner, _beaverFactory.CreateNewbornAdult);
		}

		public void SpawnChild(BaseComponent spawner)
		{
			SpawnBeaver(spawner, _beaverFactory.CreateNewbornChild);
		}

		private void SpawnBeaver(BaseComponent spawner, Func<Vector3, Beaver> beaverFactory)
		{
			Vector3? unblockedSingleAccess = spawner.GetComponent<BuildingAccessible>().Accessible.UnblockedSingleAccess;
			if (unblockedSingleAccess.HasValue)
			{
				Vector3 valueOrDefault = unblockedSingleAccess.GetValueOrDefault();
				Beaver beaver = beaverFactory(valueOrDefault);
				AssignToDwelling(spawner, beaver);
				DistrictCenter district = spawner.GetComponent<DistrictBuilding>().District;
				if ((bool)district)
				{
					beaver.GetComponent<Citizen>().AssignInitialDistrict(district);
				}
				beaver.GetComponent<CharacterBirthNotifier>().EnableNotification();
				_eventBus.Post(new BeaverBornEvent());
			}
		}

		private static void AssignToDwelling(BaseComponent baseComponent, Beaver newBeaver)
		{
			Dwelling component = baseComponent.GetComponent<Dwelling>();
			if ((bool)component)
			{
				component.AssignDweller(newBeaver.GetComponent<Dweller>());
				newBeaver.GetComponent<Enterer>().Enter(baseComponent.GetComponent<Enterable>());
			}
		}
	}
}
