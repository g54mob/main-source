using System;
using Timberborn.BaseComponentSystem;
using Timberborn.CharacterModelSystem;
using Timberborn.Characters;
using Timberborn.Common;
using Timberborn.EntitySystem;
using Timberborn.MortalComponents;
using Timberborn.NotificationSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.TickSystem;
using Timberborn.TimeSystem;
using Timberborn.WorldPersistence;

namespace Timberborn.MortalSystem
{
	public class Mortal : TickableComponent, IAwakableComponent, IPersistentEntity, IInitializableEntity, IPostInitializableEntity, IDeadNeededComponent
	{
		private static readonly ComponentKey MortalKey = new ComponentKey("Mortal");

		private static readonly PropertyKey<bool> ShouldDieKey = new PropertyKey<bool>("ShouldDie");

		private static readonly PropertyKey<bool> DiePubliclyKey = new PropertyKey<bool>("DiePublicly");

		private static readonly PropertyKey<string> DeathMessageKey = new PropertyKey<string>("DeathMessage");

		private static readonly PropertyKey<float> BodyDisappearanceDayKey = new PropertyKey<float>("BodyDisappearanceDay");

		private static readonly float MinHoursForBodyToDisappear = 0.75f;

		private static readonly float MaxHoursForBodyToDisappear = 1.75f;

		private readonly NotificationBus _notificationBus;

		private readonly IDayNightCycle _dayNightCycle;

		private readonly EventBus _eventBus;

		private readonly IRandomNumberGenerator _randomNumberGenerator;

		private readonly LongLastingCorpsesService _longLastingCorpsesService;

		private readonly DeadComponentDisabler _deadComponentDisabler;

		private Character _character;

		private CharacterAnimator _characterAnimator;

		private DeadStatus _deadStatus;

		private float _bodyDisappearanceDay;

		private string _deathMessage;

		public bool ShouldDiePublicly { get; private set; }

		public bool ShouldDie { get; private set; }

		public bool Dead => !_character.Alive;

		public bool IsTimeToDie
		{
			get
			{
				if (!Dead)
				{
					return ShouldDie;
				}
				return false;
			}
		}

		public Mortal(NotificationBus notificationBus, IDayNightCycle dayNightCycle, EventBus eventBus, IRandomNumberGenerator randomNumberGenerator, LongLastingCorpsesService longLastingCorpsesService, DeadComponentDisabler deadComponentDisabler)
		{
			_notificationBus = notificationBus;
			_dayNightCycle = dayNightCycle;
			_eventBus = eventBus;
			_randomNumberGenerator = randomNumberGenerator;
			_longLastingCorpsesService = longLastingCorpsesService;
			_deadComponentDisabler = deadComponentDisabler;
		}

		public void Awake()
		{
			_character = GetComponent<Character>();
			_characterAnimator = GetComponent<CharacterAnimator>();
			_deadStatus = GetComponent<DeadStatus>();
		}

		public override void Tick()
		{
			DestroyBodyIfItIsTime();
		}

		public void InitializeEntity()
		{
			if (!Dead)
			{
				_eventBus.Post(new CharacterCreatedEvent(_character));
			}
		}

		public void PostInitializeEntity()
		{
			if (Dead)
			{
				BecomeCorpse(postLoad: true);
			}
		}

		public void DiePubliclyAsSoonAsPossible(string deathMessage)
		{
			DieEventually(diePublicly: true, deathMessage);
		}

		public void DieSilentlyAsSoonAsPossible(string deathMessage)
		{
			DieEventually(diePublicly: false, deathMessage);
		}

		public void DieIfItIsTime()
		{
			if (IsTimeToDie)
			{
				BecomeCorpse(postLoad: false);
				_character.KillCharacter();
				_notificationBus.Post(_deathMessage, _character);
				return;
			}
			throw new InvalidOperationException("DieIfItIsTime was called even though IsTimeToDie is false.");
		}

		public void DieInstantly(string deathMessage)
		{
			DiePubliclyAsSoonAsPossible(deathMessage);
			DieIfItIsTime();
		}

		public void Save(IEntitySaver entitySaver)
		{
			if (ShouldDie)
			{
				IObjectSaver component = entitySaver.GetComponent(MortalKey);
				component.Set(ShouldDieKey, ShouldDie);
				component.Set(DiePubliclyKey, ShouldDiePublicly);
				component.Set(DeathMessageKey, _deathMessage);
				component.Set(BodyDisappearanceDayKey, _bodyDisappearanceDay);
			}
		}

		public void Load(IEntityLoader entityLoader)
		{
			if (entityLoader.TryGetComponent(MortalKey, out var objectLoader))
			{
				ShouldDie = objectLoader.Get(ShouldDieKey);
				ShouldDiePublicly = objectLoader.Get(DiePubliclyKey);
				_deathMessage = objectLoader.Get(DeathMessageKey);
				_bodyDisappearanceDay = objectLoader.Get(BodyDisappearanceDayKey);
			}
		}

		private void BecomeCorpse(bool postLoad)
		{
			_deadComponentDisabler.DisableComponentsDeadDoNotNeed(this);
			if (!postLoad)
			{
				SetBodyDisappearanceTimestamp();
			}
			_characterAnimator.SetBool(postLoad ? "DeadNoAnimation" : "Dead", value: true);
			_deadStatus.Activate(ShouldDiePublicly);
		}

		private void DieEventually(bool diePublicly, string deathMessage)
		{
			if (!ShouldDie)
			{
				ShouldDie = true;
				ShouldDiePublicly = diePublicly;
				_deathMessage = deathMessage;
			}
		}

		private void SetBodyDisappearanceTimestamp()
		{
			float hours;
			if (_longLastingCorpsesService.Enabled)
			{
				hours = 48f;
			}
			else
			{
				float inclusiveMax = MaxHoursForBodyToDisappear - MinHoursForBodyToDisappear;
				hours = _randomNumberGenerator.Range(0f, inclusiveMax) + MinHoursForBodyToDisappear;
			}
			_bodyDisappearanceDay = _dayNightCycle.DayNumberHoursFromNow(hours);
		}

		private void DestroyBodyIfItIsTime()
		{
			if (Dead && _dayNightCycle.PartialDayNumber > _bodyDisappearanceDay)
			{
				base.GameObject.SetActive(value: false);
				_character.DestroyCharacter();
			}
		}
	}
}
