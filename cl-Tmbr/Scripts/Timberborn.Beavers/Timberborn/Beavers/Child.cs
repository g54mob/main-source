using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BonusSystem;
using Timberborn.Characters;
using Timberborn.LifeSystem;
using Timberborn.Localization;
using Timberborn.NotificationSystem;
using Timberborn.Persistence;
using Timberborn.SelectionSystem;
using Timberborn.TickSystem;
using Timberborn.TimeSystem;
using Timberborn.WorldPersistence;

namespace Timberborn.Beavers
{
	public class Child : TickableComponent, IAwakableComponent, IPersistentEntity
	{
		private static readonly string BonusId = "GrowthSpeed";

		private static readonly string GrewUpLocKey = "Beaver.GrewUp";

		private static readonly ComponentKey ChildKey = new ComponentKey("Child");

		private static readonly PropertyKey<float> GrowthProgressKey = new PropertyKey<float>("GrowthProgress");

		private readonly BeaverFactory _beaverFactory;

		private readonly NotificationBus _notificationBus;

		private readonly LifeService _lifeService;

		private readonly IDayNightCycle _dayNightCycle;

		private readonly EntitySelectionService _entitySelectionService;

		private readonly ILoc _loc;

		private Character _character;

		private BonusManager _bonusManager;

		private bool _grownUp;

		public float GrowthProgress { get; private set; }

		public bool IsNewborn => _character.Age == 0;

		public Child(BeaverFactory beaverFactory, NotificationBus notificationBus, LifeService lifeService, IDayNightCycle dayNightCycle, EntitySelectionService entitySelectionService, ILoc loc)
		{
			_beaverFactory = beaverFactory;
			_notificationBus = notificationBus;
			_lifeService = lifeService;
			_dayNightCycle = dayNightCycle;
			_entitySelectionService = entitySelectionService;
			_loc = loc;
		}

		public void Awake()
		{
			_character = GetComponent<Character>();
			_bonusManager = GetComponent<BonusManager>();
		}

		public override void Tick()
		{
			UpdateGrowthProgress();
		}

		public void Save(IEntitySaver entitySaver)
		{
			entitySaver.GetComponent(ChildKey).Set(GrowthProgressKey, GrowthProgress);
		}

		public void Load(IEntityLoader entityLoader)
		{
			IObjectLoader component = entityLoader.GetComponent(ChildKey);
			GrowthProgress = component.Get(GrowthProgressKey);
		}

		public void FastForwardGrowthProgress(float growthProgress)
		{
			GrowthProgress += growthProgress;
		}

		public bool GrowUpIfItIsTime()
		{
			if (!_grownUp && GrowthProgress >= 1f)
			{
				GrowUp();
			}
			return _grownUp;
		}

		private void UpdateGrowthProgress()
		{
			GrowthProgress = Math.Min(GrowthProgress + GrowthProgressPerTick(), 1f);
		}

		private float GrowthProgressPerTick()
		{
			return _lifeService.CalculateGrowthProgress(_dayNightCycle.FixedDeltaTimeInHours) * _bonusManager.Multiplier(BonusId);
		}

		private void GrowUp()
		{
			SelectableObject component = GetComponent<SelectableObject>();
			base.GameObject.SetActive(value: false);
			Beaver beaver = _beaverFactory.CreateAdultFromChild(this);
			SelectableObject component2 = beaver.GetComponent<SelectableObject>();
			_entitySelectionService.Replace(component, component2);
			_character.DestroyCharacter();
			_notificationBus.Post(_loc.T(GrewUpLocKey, _character.FirstName), beaver);
			_grownUp = true;
		}
	}
}
