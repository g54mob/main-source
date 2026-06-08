using Timberborn.BaseComponentSystem;
using Timberborn.BonusSystem;
using Timberborn.Characters;
using Timberborn.Persistence;
using Timberborn.TickSystem;
using Timberborn.TimeSystem;
using Timberborn.WorldPersistence;

namespace Timberborn.LifeSystem
{
	public class LifeProgressor : TickableComponent, IAwakableComponent, IPersistentEntity, IChildhoodInfluenced
	{
		private static readonly string LifeExpectancyBonusId = "LifeExpectancy";

		private static readonly ComponentKey LifeProgressorKey = new ComponentKey("LifeProgressor");

		private static readonly PropertyKey<float> LifeProgressKey = new PropertyKey<float>("LifeProgress");

		private readonly IDayNightCycle _dayNightCycle;

		private readonly LifeService _lifeService;

		private BonusManager _bonusManager;

		private ILongevity _longevity;

		private float _lifeProgressIncreasePerTick;

		public float LifeProgress { get; set; }

		public bool ShouldDie => LifeProgress > _longevity.ExpectedLongevity;

		public LifeProgressor(IDayNightCycle dayNightCycle, LifeService lifeService)
		{
			_dayNightCycle = dayNightCycle;
			_lifeService = lifeService;
		}

		public void Awake()
		{
			_bonusManager = GetComponent<BonusManager>();
			_longevity = GetComponent<ILongevity>();
		}

		public override void StartTickable()
		{
			_lifeProgressIncreasePerTick = 1f / 24f * _dayNightCycle.FixedDeltaTimeInHours / (float)_lifeService.AverageLifespan;
		}

		public override void Tick()
		{
			IncreaseLifeProgress();
		}

		public void Save(IEntitySaver entitySaver)
		{
			entitySaver.GetComponent(LifeProgressorKey).Set(LifeProgressKey, LifeProgress);
		}

		public void Load(IEntityLoader entityLoader)
		{
			IObjectLoader component = entityLoader.GetComponent(LifeProgressorKey);
			LifeProgress = component.Get(LifeProgressKey);
		}

		public void InfluenceByChildhood(Character child)
		{
			LifeProgress = child.GetComponent<LifeProgressor>().LifeProgress;
		}

		private void IncreaseLifeProgress()
		{
			LifeProgress += _lifeProgressIncreasePerTick / _bonusManager.Multiplier(LifeExpectancyBonusId);
		}
	}
}
