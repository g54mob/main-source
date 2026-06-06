using UnityEngine;

namespace PajamaLlama.Fltsm
{
	public class Pollution : Vital
	{
		public DiseaseEvent OnCurrentDiseaseUpdatedEvent = new DiseaseEvent();

		private float _pollutionMaximum;

		private float _swimmingPollutionPerSecond;

		public override VitalType VitalType => VitalType.Pollution;

		public float Level { get; private set; }

		public float LevelNormalized => Level / _pollutionMaximum;

		public Disease CurrentDisease { get; private set; }

		public bool CurrentDiseaseDiagnosed { get; set; }

		public MedPod CurrentDiseaseMedPod { get; set; }

		public Pollution(Vitals vitals)
			: base(vitals)
		{
			_pollutionMaximum = vitals.Properties.PollutionMaximum;
		}

		public override void Start()
		{
			OnTownheartMoved();
			GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		}

		public override void LateUpdate()
		{
			if (IsSwimming())
			{
				Increase(_swimmingPollutionPerSecond * TimeManager.GetDeltaTime());
			}
		}

		public override void OnDestroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		}

		public override void Reset()
		{
			Set(0f);
		}

		public void Set(float amount)
		{
			amount = Mathf.Clamp(amount, 0f, base.Properties.PollutionMaximum);
			if (Level != amount)
			{
				Level = amount;
				if (Level >= (float)base.Properties.PollutionMaximum)
				{
					Level = base.Properties.PollutionReturn;
					AssignDisease();
				}
				new AgentEvent(GameEventType.PollutionUpdated, base.Agent).Dispatch();
				base.Updated.Invoke();
				GameManager.AgentManager.SendVitalsEvent();
			}
		}

		public void Increase(float amount)
		{
			if (!(amount <= 0f))
			{
				Set(Level + amount);
			}
		}

		public void Decrease(float amount)
		{
			if (!(amount <= 0f))
			{
				Set(Level - amount);
			}
		}

		public bool InstantiateProject(ProjectProperties properties, GameObject target, out Project project)
		{
			project = null;
			if (InstantiateProject(properties, target))
			{
				project = base.Project;
			}
			return project != null;
		}

		public override void ConsumeItem(Item item)
		{
			if (CurrentDisease != null && item.Properties == CurrentDisease.Medication)
			{
				CurrentDisease.FinishDisease(base.Agent);
				AgentItemPropertiesEvent.Dispatch(GameEventType.AgentMedicated, base.Agent, item.Properties);
			}
			else
			{
				Increase(item.Properties.ConsumptionPollution);
			}
		}

		private void AssignDisease()
		{
			if (CurrentDisease == null)
			{
				CurrentDisease = FlotsamGame.Random(base.Properties.Diseases).CreateInstance();
				CurrentDisease.StartDisease(base.Agent);
				CurrentDisease.OnFinishEvent.AddListener(OnDiseaseFinish);
				OnCurrentDiseaseUpdatedEvent.Invoke(CurrentDisease);
				GameManager.AgentManager.RegisterDiseasedAgent(base.Agent);
			}
		}

		private void OnDiseaseFinish(Disease disease)
		{
			if (disease == CurrentDisease)
			{
				CurrentDisease = null;
			}
			OnCurrentDiseaseUpdatedEvent.Invoke(null);
			GameManager.AgentManager.UnregisterDiseasedAgent(base.Agent);
			disease.OnFinishEvent.RemoveListener(OnDiseaseFinish);
		}

		public override void OnDayStarted()
		{
			if ((bool)CurrentDisease)
			{
				CurrentDisease.OnDayStarted(base.Agent);
			}
		}

		public override void OnKillAgent()
		{
			base.OnKillAgent();
			if ((bool)CurrentDisease)
			{
				CurrentDisease.OnFinishEvent.RemoveListener(OnDiseaseFinish);
				CurrentDisease = null;
			}
		}

		private void OnTownheartMoved(GameEvent gameEvent = null)
		{
			_swimmingPollutionPerSecond = base.Properties.ReturnSwimmingPollutionPerSecond();
		}

		public bool IsSwimming()
		{
			if ((bool)base.Agent && (base.Agent.CurrentActivity == Activity.Moving || base.Agent.CurrentActivity == Activity.MovingWithItem))
			{
				return base.Agent.ReturnNavigator().Terrain == Navigator.TerrainType.WaterSurface;
			}
			return false;
		}

		private bool TryReturnAttendedClinicWithMedication(Agent agent, out Clinic clinic, out Item medication)
		{
			foreach (Buildable buildable in agent.Community.Buildables)
			{
				if (buildable.TryReturnBuildableExtendable<Clinic>(out clinic) && (bool)clinic.Doctor && clinic.Buildable.Inventory.TryReturnItem(CurrentDisease.Medication, out medication))
				{
					return true;
				}
			}
			clinic = null;
			medication = null;
			return false;
		}

		public void Restore(float level)
		{
			Set(level);
		}

		public void RestoreDisease(DiseasePersistentData data)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<Disease>(data.DiseaseProperties, out var reference))
			{
				CurrentDisease = reference.CreateInstance();
				CurrentDisease.RestoreDisease(base.Agent, data);
				CurrentDisease.OnFinishEvent.AddListener(OnDiseaseFinish);
				OnCurrentDiseaseUpdatedEvent.Invoke(CurrentDisease);
				GameManager.AgentManager.RegisterDiseasedAgent(base.Agent);
			}
		}
	}
}
