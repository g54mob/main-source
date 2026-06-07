using System;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Fltsm;
using UnityEngine;
using UnityEngine.Events;

public class MedPod : MonoBehaviour, IBuildableExtendable, IPersistentReference, IWorkPlace, IItemReserver
{
	[Serializable]
	public class PersistentData : BuildableExtendablePersistentData<MedPod>
	{
		public PersistentReference<Project>.Reference PatientProject;

		public PersistentReference<Project>.Reference DoctorProject;

		public PersistentReference<Item>.Reference Medication;

		public PersistentReference<Agent>.Reference IncomingPatient;

		public PersistentReference<Agent>.Reference OccupyingPatient;

		public float DoctorWorkTime;

		public PersistentData(MedPod medPod)
			: base(medPod)
		{
			base.Instance = medPod;
		}

		public override void PopulateReferences()
		{
			PatientProject = base.Instance._patientProject;
			DoctorProject = base.Instance._doctorProject;
			Medication = base.Instance.Medication;
			IncomingPatient = base.Instance.IncomingPatient;
			OccupyingPatient = base.Instance.OccupyingPatient;
			DoctorWorkTime = base.Instance._doctorWorkTime;
		}

		public override void RestoreData(Buildable buildable)
		{
			if (buildable.TryGetComponent<MedPod>(out var component))
			{
				base.Instance = component;
			}
		}

		public override void RestoreReferences()
		{
			if (!(base.Instance == null))
			{
				base.Instance.Medication = Medication;
				if (IncomingPatient.TryReturn(out var instance))
				{
					SetIncomingPatient(instance);
				}
				if (OccupyingPatient.TryReturn(out instance))
				{
					SetIncomingPatient(instance);
				}
				if (PatientProject.TryReturn(out base.Instance._patientProject))
				{
					base.Instance._patientProject.FinishedEvent.AddListener(base.Instance.OnPatientProjectFinished);
				}
				if (DoctorProject.TryReturn(out base.Instance._doctorProject))
				{
					base.Instance._doctorProject.FinishedEvent.AddListener(base.Instance.OnDoctorProjectFinished);
				}
				base.Instance._doctorWorkTime = DoctorWorkTime;
			}
		}

		private void SetIncomingPatient(Agent patient)
		{
			Pollution pollution = patient.Vitals.Pollution;
			if ((bool)pollution.CurrentDisease)
			{
				base.Instance.IncomingPatient = patient;
				base.Instance._conslutDuration = pollution.CurrentDisease.MedicationDuration;
				base.Instance.SetPatientDisease(pollution.CurrentDisease);
				pollution.CurrentDiseaseMedPod = base.Instance;
			}
			else
			{
				Debug.LogErrorFormat("Unable to restore '{0}' as incoming patient because CurrentDisease is null", patient.Name);
			}
		}
	}

	[SerializeField]
	private ProjectProperties _patientProjectProperties;

	[SerializeField]
	private Transform _patientSlot;

	[SerializeField]
	private Activity _patientActivity;

	[SerializeField]
	private ProjectProperties _doctorProjectProperties;

	[SerializeField]
	private Transform _doctorSlot;

	[SerializeField]
	private Activity _doctorActivity;

	[SerializeField]
	private float _conslutDuration = 100f;

	[Space]
	public Obstacle Obstalce;

	private Project _patientProject;

	private Disease _patientDisease;

	private float _treatementDuration;

	private Project _doctorProject;

	private float _doctorWorkTime;

	private static List<MedPod> _instances = new List<MedPod>();

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; }

	public Item Medication { get; private set; }

	public Agent IncomingPatient { get; private set; }

	public Agent OccupyingPatient { get; private set; }

	public Agent Doctor { get; private set; }

	public bool IsAvailable
	{
		get
		{
			if (IsEnabled())
			{
				return _patientProject == null;
			}
			return false;
		}
	}

	public ITarget Target => Obstalce;

	public float Progress
	{
		get
		{
			if (!Doctor)
			{
				return 0f;
			}
			return _doctorWorkTime / _treatementDuration;
		}
	}

	public event UnityAction<MedPod> OnUpdated;

	private void OnEnable()
	{
		_instances.Add(this);
	}

	private void OnDisable()
	{
		_instances.Remove(this);
	}

	public bool Reserve(Agent patient)
	{
		if (!IsAvailable)
		{
			return false;
		}
		Disease currentDisease = patient.Vitals.Pollution.CurrentDisease;
		if (currentDisease == null || currentDisease.Medication == null)
		{
			return false;
		}
		Item item = patient.Community.Inventory.ReturnItem(currentDisease.Medication, SubInventoryType.Storage);
		if (item != null && item.Reserve())
		{
			if (patient.Vitals.Pollution.InstantiateProject(_patientProjectProperties, base.gameObject, out _patientProject))
			{
				_patientProject.FinishedEvent.AddListener(OnPatientProjectFinished);
				Medication = item;
				IncomingPatient = patient;
				IncomingPatient.Vitals.Pollution.CurrentDiseaseMedPod = this;
				SetPatientDisease(currentDisease);
				InvokeUpdatedEvent();
				return true;
			}
			item.CancelReservation();
		}
		return false;
	}

	public bool Unreserve(Agent patient)
	{
		if ((bool)patient && IncomingPatient == patient)
		{
			if (Medication != null)
			{
				Medication.CancelReservation();
				Medication = null;
			}
			if (_patientProject != null)
			{
				_patientProject.Stop(ProjectFlags.Cancelled);
				_patientProject = null;
			}
			ClearPatientDisease();
			IncomingPatient.Vitals.Pollution.CurrentDiseaseMedPod = null;
			IncomingPatient = null;
			InvokeUpdatedEvent();
			return true;
		}
		return false;
	}

	public bool Occupy(Agent patient)
	{
		if (patient == null || patient != IncomingPatient)
		{
			return false;
		}
		IncomingPatient = null;
		if (patient.Quirks.HasQuirk<IlDottore>())
		{
			CurePatient(patient);
			if (_doctorProject != null)
			{
				_doctorProject.Stop(ProjectFlags.BugFix);
			}
			return false;
		}
		OccupyingPatient = patient;
		AttachToSlot(patient, _patientSlot, _patientActivity);
		if (_doctorProject == null)
		{
			_doctorProject = new Project(_doctorProjectProperties, base.gameObject);
			_doctorProject.AddAssignmentType(AssignmentType.Medicine);
		}
		patient.Community.QueueProject(_doctorProject);
		GameManager.AgentManager.SendDiseaseEvent();
		InvokeUpdatedEvent();
		return true;
	}

	public bool StartWorking(Agent doctor)
	{
		if (!IsEnabled() || OccupyingPatient == null || (bool)Doctor)
		{
			return false;
		}
		Doctor = doctor;
		AttachToSlot(doctor, _doctorSlot, _doctorActivity);
		InvokeUpdatedEvent();
		return true;
	}

	public bool IsWorking(Agent doctor)
	{
		if (Doctor == doctor)
		{
			if (_doctorWorkTime < _treatementDuration)
			{
				_doctorWorkTime += Time.deltaTime;
				InvokeUpdatedEvent();
				return true;
			}
			CurePatient(OccupyingPatient);
			OccupyingPatient = null;
			Doctor = null;
			_doctorWorkTime = 0f;
		}
		InvokeUpdatedEvent();
		return false;
	}

	public void Activate()
	{
		Buildable.Community.AddItemReserver(this);
		Active = true;
	}

	public bool CanBeDeconstructed()
	{
		if (IncomingPatient == null)
		{
			return OccupyingPatient == null;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		if (IncomingPatient == null)
		{
			return OccupyingPatient == null;
		}
		return false;
	}

	public void Deactivate()
	{
		if ((bool)IncomingPatient)
		{
			Unreserve(IncomingPatient);
		}
		if ((bool)OccupyingPatient)
		{
			if (_patientProject != null)
			{
				_patientProject.Stop(ProjectFlags.Cancelled);
			}
			if (_doctorProject != null)
			{
				_doctorProject.Stop(ProjectFlags.Cancelled);
			}
			OccupyingPatient.Vitals.Pollution.CurrentDiseaseMedPod = null;
			OccupyingPatient = null;
			GameManager.AgentManager.SendDiseaseEvent();
		}
		InvokeUpdatedEvent();
		Active = false;
		Buildable.Community.RemoveItemReserver(this);
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
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public void OnDeconstruct()
	{
	}

	public void Remove()
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
	}

	public void Upgrade(Buildable buildable)
	{
	}

	private void SetPatientDisease(Disease disease)
	{
		if (!(_patientDisease == disease))
		{
			if (_patientDisease != null)
			{
				Debug.LogWarning("Patient disease overriden!");
			}
			_patientDisease = disease;
			_treatementDuration = disease.MedicationDuration;
			_patientDisease.OnFinishEvent.AddListener(OnPatientDiseaseFinished);
		}
	}

	private void ClearPatientDisease()
	{
		if ((bool)_patientDisease)
		{
			_patientDisease.OnFinishEvent.RemoveListener(OnPatientDiseaseFinished);
			_patientDisease = null;
		}
	}

	private void OnPatientProjectFinished(Project project, bool succes)
	{
		if (_patientProject != project)
		{
			throw new NotSupportedException();
		}
		_patientProject.FinishedEvent.RemoveListener(OnPatientProjectFinished);
		_patientProject = null;
		if (succes)
		{
			return;
		}
		if ((bool)IncomingPatient)
		{
			Unreserve(IncomingPatient);
		}
		if ((bool)OccupyingPatient)
		{
			OccupyingPatient.ReturnNavigator().AttachToTarget(Obstalce);
			OccupyingPatient.transform.localPosition = Vector3.zero;
			OccupyingPatient.transform.localRotation = Quaternion.identity;
			OccupyingPatient = null;
			if (Medication != null)
			{
				Medication.CancelReservation();
			}
			InvokeUpdatedEvent();
		}
	}

	private void OnDoctorProjectFinished(Project project, bool succes)
	{
		if (_doctorProject != project)
		{
			throw new NotSupportedException();
		}
		_doctorProject.FinishedEvent.RemoveListener(OnDoctorProjectFinished);
		_doctorProject = null;
		_doctorWorkTime = 0f;
		InvokeUpdatedEvent();
	}

	private void OnPatientDiseaseFinished(Disease disease)
	{
		if (disease == _patientDisease)
		{
			if (_patientProject != null)
			{
				_patientProject.Stop(ProjectFlags.Cancelled);
			}
			if (_doctorProject != null)
			{
				_doctorProject.Stop(ProjectFlags.Cancelled);
			}
			if (Medication != null)
			{
				Medication.CancelReservation();
			}
			ClearPatientDisease();
		}
	}

	private void AttachToSlot(Agent agent, Transform slot, Activity activity)
	{
		agent.transform.SetParent(slot, worldPositionStays: true);
		agent.transform.Reset();
		agent.UpdateActivity(activity);
	}

	private void CurePatient(Agent patient)
	{
		if (Medication != null)
		{
			Medication.Inventory.TakeItem(Medication);
		}
		if ((bool)patient)
		{
			patient.Vitals.Pollution.CurrentDisease.FinishDisease(patient);
			patient.Vitals.Pollution.CurrentDiseaseMedPod = null;
		}
	}

	private void InvokeUpdatedEvent()
	{
		this.OnUpdated.SafeInvoke(this);
	}

	public static bool TryReserve(Agent agent)
	{
		foreach (MedPod instance in _instances)
		{
			if (instance.Reserve(agent))
			{
				return true;
			}
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

	public AgentDescriptor GetPatientDescriptor()
	{
		if ((bool)OccupyingPatient)
		{
			return OccupyingPatient.Descriptor;
		}
		if ((bool)IncomingPatient)
		{
			return IncomingPatient.Descriptor;
		}
		return null;
	}

	public AgentDescriptor GetDoctorDescriptor()
	{
		if ((bool)Doctor)
		{
			return Doctor.Descriptor;
		}
		return null;
	}

	public bool HasItemReserved(Item item)
	{
		return item == Medication;
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
