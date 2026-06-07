using System;
using System.Text.RegularExpressions;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnergyGridConnector))]
public class EnergyPassiveGenerator : SceneBehaviour, IBuildableExtendable, IPersistentReference, IEnergyGridProducer, IEnergyGridComponent, IComparable<IEnergyGridProducer>
{
	[Tooltip("Energy rate in Eels / Second.")]
	public float EnergyRate = 0.1f;

	[SerializeField]
	private EnergyPassiveGeneratorRequirement[] _requirements = new EnergyPassiveGeneratorRequirement[0];

	[Header("Animations")]
	[SerializeField]
	private BuildableAnimator _buildableAnimator;

	[Header("FMOD Events")]
	[SerializeField]
	private FMODEventEmitter _fmodEventEmitter;

	[SerializeField]
	[ConditionalHide("_fmodEventEmitter", true)]
	private EventReference _activeEvent;

	private bool _running;

	public bool IsRunning { get; private set; } = true;

	public int PersistentIndex { get; set; }

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public float Production
	{
		get
		{
			if (!IsRunning)
			{
				return 0f;
			}
			return EnergyRate;
		}
	}

	public int Priority => 100;

	public float EnergyFillPercentage => 1f;

	public bool IsGenerating => IsRunning;

	public UnityEvent OnUpdateGeneratingEnergy { get; private set; } = new UnityEvent();

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
		Connector.RemoveComponent(this);
	}

	private void Update()
	{
		if (Buildable == null)
		{
			Debug.LogError($"ENERGYPASSIVEGENERATOR::Buildable was null in update in {base.name}");
		}
		IsRunning = ReturnCanRun();
		if (_running != IsRunning)
		{
			if (OnUpdateGeneratingEnergy == null)
			{
				Debug.LogError($"ENERGYPASSIVEGENERATOR::OnUpdateGeneratingEnergy was null in update in {base.name}");
			}
			OnUpdateGeneratingEnergy.Invoke();
			_running = IsRunning;
		}
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
		if ((bool)_buildableAnimator && (bool)_buildableAnimator.Animator)
		{
			_buildableAnimator.Animator?.SetInteger("IsWorking", 1);
		}
		if ((bool)_fmodEventEmitter)
		{
			_fmodEventEmitter.Emit(_activeEvent);
		}
	}

	public void Deactivate()
	{
		Active = false;
		if ((bool)_buildableAnimator && (bool)_buildableAnimator.Animator)
		{
			_buildableAnimator.Animator?.SetInteger("IsWorking", 0);
		}
		if ((bool)_fmodEventEmitter)
		{
			_fmodEventEmitter.Stop(_activeEvent);
		}
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new EnergyPassiveGeneratorPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
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
		text = Regex.Replace(text, "%ENERGY_PRODUCTION%", $"<b>{EnergyRate}</b>", RegexOptions.IgnoreCase);
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
		if (!EnergyPassiveOverviewUI.TryReturnAvailableUI(out var ui))
		{
			ui = UnityEngine.Object.Instantiate(GameManager.Settings.UISettings.EnergyPassiveOverviewUIPrefab);
		}
		ui.Initialize(this);
		return ui;
	}

	public bool ReturnCanRun()
	{
		if (Buildable.BuildPhase != BuildPhase.Finished)
		{
			return false;
		}
		if (!Active)
		{
			return false;
		}
		EnergyPassiveGeneratorRequirement[] requirements = _requirements;
		for (int i = 0; i < requirements.Length; i++)
		{
			if (!requirements[i].MeetsRequirement(this))
			{
				return false;
			}
		}
		return true;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
