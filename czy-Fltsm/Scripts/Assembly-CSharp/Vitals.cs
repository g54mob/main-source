using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Fltsm;
using UnityEngine;
using UnityEngine.Events;

public class Vitals : SceneBehaviour, IEnumerable<Vital>, IEnumerable
{
	[Tooltip("Base properties of this Agent.")]
	public VitalProperties Properties;

	private Dictionary<VitalType, Vital> _vitals = new Dictionary<VitalType, Vital>();

	private Dictionary<VitalType, DietVital> _dietVitals = new Dictionary<VitalType, DietVital>();

	private List<Vital> _projectFailedToInstantiate = new List<Vital>();

	private Rest _rest;

	public Agent Agent { get; private set; }

	public Hunger Hunger { get; private set; }

	public Thirst Thirst { get; private set; }

	public Pollution Pollution { get; private set; }

	private void Start()
	{
		foreach (Vital value in _vitals.Values)
		{
			value.Start();
		}
	}

	private void LateUpdate()
	{
		if (!Agent.IsAlive)
		{
			return;
		}
		if (IsMarkedForDeath() && Agent.Assignment == null)
		{
			KillAgent();
			return;
		}
		Agent.DrifterRig.MeshAnimator.UpdateAnimator();
		foreach (Vital value in _vitals.Values)
		{
			value.LateUpdate();
		}
	}

	private void OnDestroy()
	{
		foreach (Vital value in _vitals.Values)
		{
			value.OnDestroy();
		}
		if (Hunger != null)
		{
			Hunger.Updated.RemoveListener(UpdateMortalDangerIcon);
		}
		if (Thirst != null)
		{
			Thirst.Updated.RemoveListener(UpdateMortalDangerIcon);
		}
	}

	public void Initialize(Agent agent)
	{
		Agent = agent;
		Properties = agent.Properties.VitalProperties;
		Hunger = new Hunger(this);
		Hunger.Updated.AddListener(UpdateMortalDangerIcon);
		AddVital(Hunger);
		Thirst = new Thirst(this);
		Thirst.Updated.AddListener(UpdateMortalDangerIcon);
		AddVital(Thirst);
		Pollution = new Pollution(this);
		AddVital(Pollution);
		_rest = new Rest(this);
		AddVital(_rest);
	}

	private void AddVital(Vital vital)
	{
		_vitals.Add(vital.VitalType, vital);
		if (vital is DietVital dietVital)
		{
			_dietVitals.Add(dietVital.VitalType, dietVital);
		}
	}

	private void UpdateMortalDangerIcon()
	{
		if (IsInMortalDanger())
		{
			Agent.WorldIconHandler.AddIcon(GameManager.Settings.AgentSettings.DrifterMortalDangerIconProperties);
		}
		else
		{
			Agent.WorldIconHandler.RemoveIcon(GameManager.Settings.AgentSettings.DrifterMortalDangerIconProperties);
		}
	}

	public bool AssignProject()
	{
		if (Agent.Assignment == null)
		{
			foreach (Vital value in _vitals.Values)
			{
				if (value.StartProject())
				{
					return true;
				}
			}
			if (!IsGoingToDie())
			{
				int count = _projectFailedToInstantiate.Count;
				while (0 < count--)
				{
					Vital vital = _projectFailedToInstantiate[count];
					if (vital.RetryInstantiateProject())
					{
						_projectFailedToInstantiate.RemoveAt(count);
						return vital.StartProject();
					}
				}
			}
		}
		return false;
	}

	public void RestoreProject(Project project)
	{
		if (_vitals.TryGetValue(project.Vital, out var value))
		{
			value.RestoreProjectReference(project);
		}
		else
		{
			Debug.LogWarning($"Unable to restore vital project with vital '{project.Vital}' because a project for this vital is already in the projects list.");
		}
	}

	public void IncreaseVital(VitalType vitalType, bool noDeath = false)
	{
		if (_dietVitals.TryGetValue(vitalType, out var value))
		{
			value.IncreaseAmount(noDeath);
		}
	}

	public void DecreaseVital(VitalType vitalType)
	{
		if (_dietVitals.TryGetValue(vitalType, out var value))
		{
			value.DecreaseAmount();
		}
	}

	public void ResetAllVitals()
	{
		foreach (Vital value in _vitals.Values)
		{
			value.Reset();
		}
	}

	public void OnDayStarted(GameEvent gameEvent)
	{
		foreach (Vital value in _vitals.Values)
		{
			value.OnDayStarted();
		}
	}

	public void KillAgent()
	{
		if (Agent.Community.IsPlayerCommunity() && Agent.IsAlive)
		{
			NotificationProperties properties = Properties.DefaultDeathNotification;
			switch (ReturnCauseOfDeath())
			{
			case VitalType.Hunger:
				properties = Properties.DiedOfHungerNotification;
				break;
			case VitalType.Thirst:
				properties = Properties.DiedOfThirstNotification;
				break;
			}
			GameManager.UIManager.NotificationHandler.AddNotification(properties, base.gameObject, ObjectType.Agent);
		}
		foreach (Vital value in _vitals.Values)
		{
			value.OnKillAgent();
		}
		Agent.KillAgent();
	}

	public bool TryReserveItemToConsume(VitalType vitalType, AssignmentPriority priority)
	{
		if (_dietVitals.TryGetValue(vitalType, out var value) && value.Diet != null)
		{
			return value.Diet.TryReserveItemToConsume(priority);
		}
		Debug.LogException(new Exception($"Unable to reserve diet item for vital '{vitalType}', no diet was found!"));
		return false;
	}

	public void UnreserveItemToConsume(params VitalType[] vitals)
	{
		foreach (VitalType key in vitals)
		{
			if (_dietVitals.TryGetValue(key, out var value) && value.Diet != null)
			{
				value.Diet.ClearItemToConsume();
			}
		}
	}

	public bool TryAddConsumeProject(VitalType vitalType, bool noDeath = false)
	{
		if (_dietVitals.TryGetValue(vitalType, out var value))
		{
			if (value.TryInstantiateProject(noDeath))
			{
				return true;
			}
			AgentEvent.Dispatch(value.Diet.FailedEvent, Agent);
			_projectFailedToInstantiate.AddUnique(value);
			return false;
		}
		Debug.LogException(new Exception($"Unable to add consume project for vital '{vitalType}'!"));
		return false;
	}

	public void ConsumeItem(Item item)
	{
		foreach (Vital value in _vitals.Values)
		{
			value.ConsumeItem(item);
		}
	}

	public void ClearLastReservedItemToConsume(params VitalType[] vitals)
	{
		foreach (VitalType key in vitals)
		{
			if (_dietVitals.TryGetValue(key, out var value))
			{
				value.Diet.ClearLastReservedItemToCosume();
			}
		}
	}

	public bool IsProjectItem(Item item)
	{
		foreach (Vital value in _vitals.Values)
		{
			if (value.Project != null && value.Project.ContainsItem(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnHasProject()
	{
		foreach (Vital value in _vitals.Values)
		{
			if (value.HasProject())
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnHasProject(VitalType vitalType)
	{
		if (_vitals.TryGetValue(vitalType, out var value))
		{
			return value.HasProject();
		}
		return false;
	}

	public bool TryReturnProject(VitalType vitalType, out Project project)
	{
		project = null;
		if (_vitals.TryGetValue(vitalType, out var value))
		{
			project = value.Project;
		}
		return project != null;
	}

	public bool TryReturnDiet(VitalType vital, out Diet diet)
	{
		diet = (_dietVitals.TryGetValue(vital, out var value) ? value.Diet : null);
		return diet != null;
	}

	public bool IsInMortalDanger()
	{
		foreach (DietVital value in _dietVitals.Values)
		{
			if (value.IsInDangerOfDying())
			{
				return true;
			}
		}
		return false;
	}

	public bool IsGoingToDie()
	{
		foreach (DietVital value in _dietVitals.Values)
		{
			if (value.IsGoingToDie())
			{
				return true;
			}
		}
		return false;
	}

	public bool IsGoingToDieOfAnyOther(Vital vitalToExclude)
	{
		foreach (DietVital value in _dietVitals.Values)
		{
			if (value != vitalToExclude && value.IsGoingToDie())
			{
				return true;
			}
		}
		return false;
	}

	public bool IsMarkedForDeath()
	{
		foreach (DietVital value in _dietVitals.Values)
		{
			if (value.IsCauseOfDeath())
			{
				return true;
			}
		}
		return false;
	}

	public int ReturnDangerScore()
	{
		int num = 0;
		foreach (DietVital value in _dietVitals.Values)
		{
			if (value.IsInDangerOfDying())
			{
				num++;
			}
		}
		return num;
	}

	public VitalType ReturnCauseOfDeath()
	{
		foreach (KeyValuePair<VitalType, DietVital> dietVital in _dietVitals)
		{
			if (dietVital.Value.IsCauseOfDeath())
			{
				return dietVital.Key;
			}
		}
		return VitalType.None;
	}

	public int ReturnVitalAmount(VitalType type)
	{
		if (_dietVitals.TryGetValue(type, out var value))
		{
			return value.Amount;
		}
		return 0;
	}

	public int ReturnVitalLimit(VitalType type)
	{
		if (_dietVitals.TryGetValue(type, out var value))
		{
			return value.Limit;
		}
		return 0;
	}

	public UnityEvent ReturnVitalEvent(VitalType type)
	{
		if (_vitals.TryGetValue(type, out var value))
		{
			return value.Updated;
		}
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _vitals.Values.GetEnumerator();
	}

	IEnumerator<Vital> IEnumerable<Vital>.GetEnumerator()
	{
		return _vitals.Values.GetEnumerator();
	}
}
