using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Clinic : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	[Serializable]
	public class PersistentData : BuildableExtendablePersistentData<Clinic>
	{
		public PersistentReference<Project>.Reference Project;

		public float ConsultTime;

		public PersistentData(Clinic clinic)
			: base(clinic)
		{
			base.Instance = clinic;
			ConsultTime = clinic._consultTime;
		}

		public override void PopulateReferences()
		{
			Project = base.Instance._project;
		}

		public override void RestoreData(Buildable buildable)
		{
			if (buildable.TryGetComponent<Clinic>(out var component))
			{
				base.Instance = component;
				base.Instance._consultTime = ConsultTime;
			}
		}

		public override void RestoreReferences()
		{
			if (!(base.Instance == null))
			{
				base.Instance._project = Project;
				if (base.Instance._project != null)
				{
					base.Instance._project.FinishedEvent.AddListener(base.Instance.OnProjectFinished);
				}
			}
		}
	}

	[SerializeField]
	private ProjectProperties _projectProperties;

	[SerializeField]
	[Tooltip("The time a doctor will wait for the first patient to arrive")]
	private float _waitDuration = 30f;

	[SerializeField]
	private float _conslutDuration = 100f;

	[Space]
	public Obstacle Obstalce;

	[SerializeField]
	[FormerlySerializedAs("WorkerSlots")]
	private AttachableSlots _workerSlots;

	private Project _project;

	private float _consultTime;

	private Queue<Agent> _appointments;

	private bool _isWaitingForFirstPatient;

	private float _waitTime;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; }

	public float WaitDuration => _waitDuration;

	public Agent Doctor { get; private set; }

	public Agent Patient { get; private set; }

	public event UnityAction<Clinic> OnUpdated;

	public void Open(Agent agent)
	{
		Doctor = agent;
		_workerSlots.Attach(Doctor.transform);
		_appointments?.Clear();
		_isWaitingForFirstPatient = true;
		_waitTime = 0f;
		this.OnUpdated.SafeInvoke(this);
	}

	public void Close()
	{
		_workerSlots.Detach(Doctor.transform, GameManager.AgentManager.AgentParent);
		Doctor = null;
		this.OnUpdated.SafeInvoke(this);
	}

	public bool TakeAppointment(Agent agent)
	{
		if (_appointments == null)
		{
			_appointments = new Queue<Agent>();
		}
		if (!_appointments.Contains(agent))
		{
			_appointments.Enqueue(agent);
			return true;
		}
		return false;
	}

	public bool Enter(Agent agent)
	{
		if ((bool)Doctor && Patient == null && _appointments.Peek() == agent)
		{
			_appointments.Dequeue();
			_isWaitingForFirstPatient = false;
			_consultTime = 0f;
			Patient = agent;
			this.OnUpdated.SafeInvoke(this);
			return true;
		}
		return false;
	}

	public bool IsDiagnosed(Agent agent)
	{
		if (agent != Patient)
		{
			return false;
		}
		if (_consultTime <= _conslutDuration)
		{
			_consultTime += Time.deltaTime;
			return false;
		}
		Patient = null;
		this.OnUpdated.SafeInvoke(this);
		return true;
	}

	public void Activate()
	{
		Active = true;
		GameEventDispatcher.AddListener(GameEventType.DaytimeStarted, OnGameEvent);
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		return false;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Finish(bool restored = false)
	{
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
	}

	public bool IsEnabled()
	{
		throw new NotImplementedException();
	}

	public void OnDeconstruct()
	{
		throw new NotImplementedException();
	}

	public void Remove()
	{
		throw new NotImplementedException();
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public void ShowResearchInfo(RectTransform parent)
	{
		throw new NotImplementedException();
	}

	public void Shutdown()
	{
		throw new NotImplementedException();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public void Upgrade(Buildable buildable)
	{
		throw new NotImplementedException();
	}

	private void OnGameEvent(GameEvent gameEvent)
	{
		if (_project == null)
		{
			_project = new Project(_projectProperties, base.gameObject);
			_project.FinishedEvent.AddListener(OnProjectFinished);
			Community.PlayerCommunity.QueueProject(_project);
		}
	}

	private void OnProjectFinished(Project project, bool succes)
	{
		if (_project != project)
		{
			throw new NotSupportedException();
		}
		_project.FinishedEvent.RemoveListener(OnProjectFinished);
		_project = null;
	}

	public bool CanClose()
	{
		if ((bool)Patient)
		{
			return false;
		}
		if (!TimeManager.ReturnIsDayTime())
		{
			return true;
		}
		if (_isWaitingForFirstPatient && _waitTime < WaitDuration)
		{
			_waitTime += Time.deltaTime;
			return false;
		}
		if (_appointments != null && 0 < _appointments.Count)
		{
			return false;
		}
		return true;
	}

	public bool IsBusy()
	{
		if ((bool)Doctor)
		{
			return Patient;
		}
		return false;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public List<Agent> GetWorkers(List<Agent> listToPopulate)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<Agent>(1);
		}
		listToPopulate.AddUnique(Doctor);
		return listToPopulate;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogError("TODO: Implement Persistence");
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogError("TODO: Implement Persistence");
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogError("TODO: Implement Persistence");
	}
}
