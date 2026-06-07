using System;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Construction))]
public class ResearchStation : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	[Tooltip("Slot where the drifters are attached when researching.")]
	public AttachableSlots Slots;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _FMODEventReference_Production;

	private CommunityResearch _communityResearch;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Agent ReservingAgent { get; set; }

	public bool IsResearching { get; private set; }

	public float Progress { get; private set; }

	public float NormalizedProgress => Progress / GameSettings.Instance.GameplaySettings.ResearchTimePerItem;

	public UnityEvent OnStartResearching { get; private set; } = new UnityEvent();

	public UnityEvent OnStopResearching { get; private set; } = new UnityEvent();

	public UnityEvent OnResearch { get; private set; } = new UnityEvent();

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		_communityResearch = buildable.Community.Research;
		_communityResearch.AddResearchStation(this);
	}

	public void Remove()
	{
		Buildable.Community.Research.RemoveResearchStation(this);
	}

	public void Finish(bool restored = false)
	{
		if (!restored)
		{
			new GameEvent(GameEventType.ResearchStationBuilt).Dispatch();
		}
	}

	public void StartResearch(Agent agent)
	{
		agent.UpdateActivity(Activity.Researching);
		Slots.Attach(agent.transform);
		if ((bool)Buildable.BuildableAnimator.Animator)
		{
			Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
		}
		IsResearching = true;
		Buildable.FMODEventEmitter.Emit(_FMODEventReference_Production);
		OnStartResearching.Invoke();
		GameEventDispatcher.Dispatch(GameEventType.ResearchStationStart);
	}

	public void StopResearch()
	{
		Progress = 0f;
		FinishResearch();
	}

	public void FinishResearch()
	{
		ResetReservedAgent();
		if ((bool)Buildable.BuildableAnimator.Animator)
		{
			Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
		}
		IsResearching = false;
		Buildable.FMODEventEmitter.Stop(_FMODEventReference_Production);
		OnStopResearching.Invoke();
		GameEventDispatcher.Dispatch(GameEventType.ResearchStationStop);
	}

	public bool Research(Agent agent)
	{
		float num = agent.Attributes.ReturnAttributeModifier(DrifterAttributes.AttributeType.Research);
		float num2 = Time.deltaTime * num;
		Progress += num2;
		OnResearch.Invoke();
		if (Progress >= GameSettings.Instance.GameplaySettings.ResearchTimePerItem)
		{
			Progress = 0f;
			new AgentActionEvent(GameEventType.AgentActionResearched, agent, DrifterAttributes.AttributeType.Research).Dispatch();
			return _communityResearch.ResearchPoint();
		}
		return false;
	}

	public void ResetReservedAgent()
	{
		if (ReservingAgent == null)
		{
			return;
		}
		if (Slots.IsAttached(ReservingAgent.transform))
		{
			Slots.Detach(ReservingAgent.transform, GameManager.AgentManager.AgentParent);
			if (!ReservingAgent.ReturnNavigator().AttachToTarget(GetComponent<Target>()))
			{
				ReservingAgent.ReturnNavigator().AttachToTarget(ReservingAgent.ReturnClosestWalkwayConstruction().Target);
			}
		}
		ReservingAgent = null;
	}

	public bool ReturnCanRun()
	{
		if (!IsEnabled())
		{
			return false;
		}
		if (GameManager.TimeManager.CurrentDay.DayTime == Day.E_DayTime.Night)
		{
			return false;
		}
		return true;
	}

	public void Activate()
	{
		Active = true;
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Deactivate()
	{
		Active = false;
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

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		ResearchStationPersistentData researchStationPersistentData = persistentData as ResearchStationPersistentData;
		Progress = researchStationPersistentData.Progress;
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new ResearchStationPersistentData(this);
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
