using System;
using System.Text.RegularExpressions;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnergyGridConnector))]
public class EnergyManualProducer : SceneBehaviour, IBuildableExtendable, IPersistentReference, IEnergyGridProducer, IEnergyGridComponent, IComparable<IEnergyGridProducer>
{
	public float RechargeSpeed = 1f;

	public AttachableSlots Slots;

	[SerializeField]
	private Activity _activity = Activity.ManualGenerating;

	[SerializeField]
	private int _priority;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _FMODEventReference_Production;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Project RechargeProject { get; private set; }

	public Agent GeneratingAgent { get; private set; }

	public DrifterAttributes.AttributeType GenerationAttribute => DrifterAttributes.AttributeType.Athletics;

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public float Production => ReturnAgentEnergyGeneration();

	public int Priority => _priority;

	public bool IsGenerating { get; private set; }

	public float EnergyFillPercentage { get; private set; } = 0.5f;

	public UnityEvent OnStartGenerating { get; private set; } = new UnityEvent();

	public UnityEvent OnStopGenerating { get; private set; } = new UnityEvent();

	public UnityEvent OnEnergyFillPercentageUpdated { get; private set; } = new UnityEvent();

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
		if (RechargeProject != null)
		{
			RechargeProject.Stop(ProjectFlags.BuildableRemoved);
			RechargeProject = null;
		}
		Connector.RemoveComponent(this);
	}

	private void OnDestroy()
	{
		if (base.gameObject.scene.isLoaded)
		{
			RechargeProject?.Stop(ProjectFlags.BuildableRemoved);
		}
	}

	public void SetEnergyFillPercentage(float percentage)
	{
		EnergyFillPercentage = percentage;
		OnEnergyFillPercentageUpdated.Invoke();
	}

	public void StartGenerating(Agent agent)
	{
		GeneratingAgent = agent;
		agent.ReturnNavigator().UpdateTerrain(Navigator.TerrainType.Construction, overrideUpdate: true);
		Slots.Attach(agent.transform);
		agent.UpdateActivity(_activity);
		Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
		Buildable.FMODEventEmitter.Emit(_FMODEventReference_Production);
		IsGenerating = true;
		OnStartGenerating.Invoke();
		AchievementEvent.Dispatch(GameEventType.ManualPowerGenerationStarted, this);
	}

	public void EndGenerating(Agent agent)
	{
		Navigator navigator = agent.ReturnNavigator();
		Slots.Detach(agent.transform, GameManager.AgentManager.AgentParent);
		agent.transform.SetParent(GameManager.AgentManager.AgentParent);
		if ((bool)navigator)
		{
			navigator.AttachToTarget(agent.ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
		}
		Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
		Buildable.FMODEventEmitter.Stop(_FMODEventReference_Production);
		IsGenerating = false;
		if (GeneratingAgent == agent)
		{
			GeneratingAgent = null;
		}
		OnStopGenerating.Invoke();
		AchievementEvent.Dispatch(GameEventType.ManualPowerGenerationStopped, this);
	}

	public bool IsHighestPriority()
	{
		if (IsEnabled() && EnergyGrid != null)
		{
			return EnergyGrid.IsHighestPriority(this);
		}
		return false;
	}

	public bool ReturnCanRun()
	{
		if (Active)
		{
			return GameManager.TimeManager.CurrentDay.DayTime == Day.E_DayTime.Day;
		}
		return false;
	}

	public float ReturnAgentEnergyGeneration()
	{
		if (GeneratingAgent == null)
		{
			return 0f;
		}
		return RechargeSpeed * GeneratingAgent.Attributes.ReturnAttributeModifier(GenerationAttribute);
	}

	public float ReturnAgentEnergyModifier()
	{
		if (GeneratingAgent == null)
		{
			return 0f;
		}
		return RechargeSpeed * (GeneratingAgent.Attributes.ReturnAttributeModifier(GenerationAttribute) - 1f);
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
		if (RechargeProject == null)
		{
			RechargeProject = new Project(GameManager.Settings.ProjectSettings.ManualEnergyProducingProject, base.gameObject);
			Buildable.Community.QueueProject(RechargeProject);
		}
	}

	public void Deactivate()
	{
		Active = false;
		if (RechargeProject != null)
		{
			RechargeProject.Stop(ProjectFlags.Cancelled);
			RechargeProject = null;
		}
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new EnergyManualProducerPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		EnergyManualProducerPersistentData energyManualProducerPersistentData = persistentData as EnergyManualProducerPersistentData;
		EnergyFillPercentage = energyManualProducerPersistentData.EnergyFillPercentage;
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		EnergyManualProducerPersistentData energyManualProducerPersistentData = persistentData as EnergyManualProducerPersistentData;
		if (energyManualProducerPersistentData.RechargeProject != null && energyManualProducerPersistentData.RechargeProject.TryReturn(out var instance))
		{
			RechargeProject = instance;
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		(persistentData as EnergyManualProducerPersistentData).RechargeProject = RechargeProject;
	}

	public void OnDeconstruct()
	{
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

	public string ReturnDescription(string text)
	{
		text = Regex.Replace(text, "%ENERGY_PRODUCTION%", $"<b>{RechargeSpeed}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public int CompareTo(IEnergyGridProducer other)
	{
		return other?.Priority.CompareTo(Priority) ?? (-1);
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.AddProducer(this);
		grid.AddComponent(this);
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		if (grid != null)
		{
			grid.RemoveProducer(this);
			grid.RemoveComponent(this);
		}
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		if (!EnergyManualProducerOverviewUI.TryReturnAvailableUI(out var ui))
		{
			ui = UnityEngine.Object.Instantiate(GameManager.Settings.UISettings.EnergyManualProducerOverviewUIPrefab);
		}
		ui.Initialize(this);
		return ui;
	}
}
