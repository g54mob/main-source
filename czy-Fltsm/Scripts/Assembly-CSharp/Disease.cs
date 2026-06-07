using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Disease : PersistentProperties, ITooltipProvider
{
	public LocalizedString Name = "";

	public IconProperties Icon;

	public float DiseaseTime = 500f;

	[Tooltip("Number of days the disease is active. 0 (or lower) = always")]
	public int DiseaseDays;

	public NotificationProperties Notification;

	public DrifterLookProperties DiseaseLookMale;

	public DrifterLookProperties DiseaseLookFemale;

	[Header("Tooltip")]
	public LocalizedString Description;

	public LocalizedString EffectDescription;

	public LocalizedString DurationDescription;

	[Header("Medication")]
	[FormerlySerializedAs("Cure")]
	public ItemProperties Medication;

	public Activity MedicationActivity;

	public float MedicationDuration;

	public Project MedicationProject;

	public DiseaseEvent OnFinishEvent = new DiseaseEvent();

	private GameObject _visual;

	public float CurrentTime { get; private set; }

	public int CurrentDay { get; private set; }

	public float NormalizedProgress => CurrentTime / DiseaseTime;

	public Disease PropertiesReference { get; protected set; }

	public override Types Type => Types.DiseaseProperties;

	public Disease CreateInstance()
	{
		Disease disease = Object.Instantiate(this);
		disease.PropertiesReference = this;
		return disease;
	}

	public virtual void StartDisease(Agent agent)
	{
		GameManager.UIManager.NotificationHandler.AddNotification(Notification, agent.gameObject, ObjectType.CommunityMember);
		if (TryReturnDiseaseLook(agent, out var diseaseLook))
		{
			agent.ApplyAlternativeLook(diseaseLook);
		}
		CurrentTime = 0f;
		CurrentDay = 0;
	}

	public virtual void UpdateDisease(Agent agent)
	{
		TryReserveMedPod(agent);
	}

	public virtual bool Progress(Agent agent, float progress)
	{
		CurrentTime += progress;
		if (CurrentTime >= DiseaseTime)
		{
			FinishDisease(agent);
			return true;
		}
		return false;
	}

	public virtual void FinishDisease(Agent agent)
	{
		OnFinishEvent.Invoke(this);
		if (_visual != null)
		{
			Object.Destroy(_visual);
		}
		if (TryReturnDiseaseLook(agent, out var diseaseLook))
		{
			agent.UndoAlternativeLook(diseaseLook);
		}
	}

	public virtual void RestoreDisease(Agent agent, DiseasePersistentData data)
	{
		if (TryReturnDiseaseLook(agent, out var diseaseLook))
		{
			agent.ApplyAlternativeLook(diseaseLook);
		}
		CurrentTime = data.CurrentTime;
		CurrentDay = data.CurrentDay;
	}

	public virtual void OnDayStarted(Agent agent)
	{
		CurrentDay++;
		if (0 < DiseaseDays && DiseaseDays < CurrentDay)
		{
			FinishDisease(agent);
		}
	}

	public bool TryReserveMedPod(Agent agent)
	{
		Vitals vitals = agent.Vitals;
		if ((bool)agent.Vitals.Pollution.CurrentDiseaseMedPod || Medication == null || vitals.ReturnHasProject(VitalType.Disease))
		{
			return true;
		}
		return MedPod.TryReserve(agent);
	}

	public virtual DiseasePersistentData ReturnPersistentData()
	{
		return new DiseasePersistentData(this);
	}

	private bool TryReturnDiseaseLook(Agent agent, out DrifterLookProperties diseaseLook)
	{
		diseaseLook = ((agent.Descriptor.Gender == Agent.EGender.Male) ? DiseaseLookMale : DiseaseLookFemale);
		return diseaseLook != null;
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		tooltipBuilder.Append(Description);
		AddEffectsToTooltip(tooltipBuilder);
		tooltipBuilder.AppendParagraph(string.Concat(DurationDescription, " ", (DiseaseDays - CurrentDay).ToString()));
		return tooltipBuilder.ToString();
	}

	protected virtual void AddEffectsToTooltip(TooltipBuilder builder)
	{
		builder.AppendEffect(EffectDescription);
	}

	public virtual string GetEffectDescription()
	{
		return EffectDescription;
	}
}
