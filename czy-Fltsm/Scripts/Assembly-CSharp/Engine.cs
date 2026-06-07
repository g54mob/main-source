using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(EnergyGridConnector))]
public class Engine : SceneBehaviour, IBuildableExtendable, IPersistentReference, IEnergyGridComponent
{
	[SerializeField]
	private bool _isTownheartEngine;

	[SerializeField]
	private float _tugCapacity = 2000f;

	[FormerlySerializedAs("WeightTiers")]
	[SerializeField]
	[ConditionalHide("_isTownheartEngine", true)]
	private WeightTier[] _weightTiers;

	[SerializeField]
	[ConditionalHide("_isTownheartEngine", true)]
	[Tooltip("The cooldown is based on the last distance moved. The distance is multiplied by this value to be able to tweak the effect")]
	private float _cooldownThreshold = 10f;

	[Header("Energy")]
	[SerializeField]
	private float _startEnergy = 5000f;

	[Header("Audio")]
	[SerializeField]
	private StudioEventEmitter _engineEventEmitter;

	[Header("Malfunctions")]
	[SerializeField]
	private PlaceableAlertProperties _notConnectedToTownHeart;

	private static float _townTugCapacity;

	private static Engine _townheartEngine;

	private static List<Engine> _engines;

	private BuildableVisual _visual;

	private bool _updateMalfunctions;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public WeightTier[] WeightTiers => _weightTiers;

	public static float TownWeight { get; private set; }

	public static WeightTier WeightTier { get; private set; }

	public static float TownUsedTugCapacityPercentage { get; private set; }

	public static float TownAvailableTugCapacity { get; private set; }

	public static float TownTugCapacity => _townTugCapacity;

	public static bool IsCoolingDown { get; private set; }

	public static float CooldownStartTime { get; private set; }

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.OnBuildableVisualRegister.AddListener(RegisterVisual);
		Buildable.OnBuildableVisualUnregister.AddListener(UnregisterVisual);
		GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionAdded, OnEnergyGridConnectionUpdated);
		GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionRemoved, OnEnergyGridConnectionUpdated);
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
		if (_isTownheartEngine)
		{
			_townheartEngine = this;
		}
		if (_engines == null)
		{
			_engines = new List<Engine>();
		}
		_engines.Add(this);
	}

	public void Finish(bool restored = false)
	{
		if (_isTownheartEngine)
		{
			if (Buildable.Community.Engine != null)
			{
				Debug.LogError("Multiple engines were added to the community. This is not possible.");
			}
			Buildable.Community.Engine = this;
		}
		else
		{
			if (Buildable.Community.Engine == null)
			{
				Debug.LogError("A tugger engine is finished, but the Community engine is not yet fixed");
			}
			RotateVisual();
		}
		if (!restored)
		{
			EnergyGrid.FillStorageEnergy(_startEnergy);
		}
		GraphManager.RefreshNavigatorPaths();
		_engineEventEmitter?.Play();
		_updateMalfunctions = true;
	}

	public void Remove()
	{
	}

	private void LateUpdate()
	{
		if (Buildable == null)
		{
			return;
		}
		if (_isTownheartEngine)
		{
			float townWeight = TownWeight;
			TownWeight = Buildable.Community.ReturnWeight();
			float townTugCapacity = _townTugCapacity;
			_townTugCapacity = ReturnTownTugCapacity();
			TownUsedTugCapacityPercentage = Mathf.Clamp(TownWeight / _townTugCapacity, 0f, 1f);
			TownAvailableTugCapacity = Mathf.Max(_townTugCapacity - TownWeight, 0f);
			WeightTier weightTier = WeightTier;
			WeightTier = ReturnWeightTier(TownUsedTugCapacityPercentage);
			if (TownWeight != townWeight || _townTugCapacity != townTugCapacity)
			{
				WeightEvent.Dispatch(GameEventType.TownWeightUpdated, TownWeight, WeightTier);
			}
			if (WeightTier != weightTier)
			{
				WeightEvent.Dispatch(GameEventType.WeightTierUpdated, TownWeight, WeightTier);
			}
			if (IsCoolingDown)
			{
				IsCoolingDown = EnergyGrid.ReturnStorageEnergy() < _cooldownThreshold;
			}
		}
		else if (_updateMalfunctions)
		{
			UpdateMalfunctions();
		}
	}

	private void OnDestroy()
	{
		if (Buildable != null)
		{
			Buildable.OnBuildableVisualRegister.RemoveListener(RegisterVisual);
			Buildable.OnBuildableVisualUnregister.RemoveListener(UnregisterVisual);
		}
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionAdded, OnEnergyGridConnectionUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionRemoved, OnEnergyGridConnectionUpdated);
		if (_townheartEngine == this)
		{
			_townheartEngine = null;
		}
		if (!_engines.IsNullOrEmpty())
		{
			_engines.Remove(this);
		}
	}

	public bool ConsumeEnergy(float distance)
	{
		if (EnergyDevTools.FreeMovement)
		{
			return true;
		}
		EnergyGrid.RequestStorageEnergy(ReturnEnergyCost(distance));
		if (!IsCoolingDown && ReturnEnergyRange() == 0f)
		{
			IsCoolingDown = true;
			CooldownStartTime = Time.realtimeSinceStartup;
		}
		return true;
	}

	private void UpdateMalfunctions()
	{
		if (!_isTownheartEngine)
		{
			if (IsConnectedToTownheartEnergyGrid())
			{
				Buildable.RemoveMalfunction(_notConnectedToTownHeart);
			}
			else
			{
				Buildable.AddMalfunction(_notConnectedToTownHeart);
			}
			_updateMalfunctions = false;
		}
	}

	private void RegisterVisual(BuildableVisual visual)
	{
		_visual = visual;
		if (Buildable.BuildPhase == BuildPhase.Finished)
		{
			RotateVisual();
		}
	}

	private void UnregisterVisual(BuildableVisual visual)
	{
		if (_visual == visual)
		{
			_visual.transform.localRotation = Quaternion.identity;
		}
	}

	private void RotateVisual()
	{
		if (!(_visual == null))
		{
			_visual.transform.forward = Buildable.Community.Engine.transform.forward;
		}
	}

	private void OnEnergyGridConnectionUpdated(GameEvent gameEvent)
	{
		_updateMalfunctions = true;
	}

	public float ReturnMovementSpeed()
	{
		return Buildable.ReturnModifier(ModifierType.MovementSpeed);
	}

	public float ReturnMoveableDistance(float desiredDistance)
	{
		if (IsCoolingDown)
		{
			return 0f;
		}
		return desiredDistance;
	}

	private WeightTier ReturnWeightTier(float capacityPercentage)
	{
		WeightTier[] weightTiers = WeightTiers;
		foreach (WeightTier weightTier in weightTiers)
		{
			if (weightTier.IsInRange(capacityPercentage))
			{
				return weightTier;
			}
		}
		throw new NotImplementedException("No tier for weight " + capacityPercentage.ToString("F1"));
	}

	public float ReturnEnergyCost(float distance)
	{
		if (_townTugCapacity == 0f)
		{
			return 1f;
		}
		return distance * ReturnEelsPerUnit();
	}

	public float ReturnEnergyRange()
	{
		return ReturnEnergyRange(EnergyGrid.ReturnStorageEnergy());
	}

	public float ReturnEnergyRange(float energy)
	{
		return energy / ReturnEelsPerUnit();
	}

	private float ReturnEelsPerUnit()
	{
		return GameplaySettings.ReturnEelsPerUnit(TownWeight) * Buildable.ReturnModifier(ModifierType.MovementEnergyCost);
	}

	private bool IsConnectedToTownheartEnergyGrid()
	{
		if (EnergyGrid != null)
		{
			return EnergyGrid.IsTownheartGrid;
		}
		return false;
	}

	private float ReturnTownTugCapacity()
	{
		if (_engines.IsNullOrEmpty())
		{
			return 0f;
		}
		float num = 0f;
		foreach (Engine engine in _engines)
		{
			if (engine.IsEnabled() || engine._isTownheartEngine)
			{
				num += engine._tugCapacity;
			}
		}
		return num;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public static bool CanTug(PlaceableProperties placeableProperties)
	{
		if (_townheartEngine == null)
		{
			return false;
		}
		return placeableProperties.GetWeightModeWeight() <= TownAvailableTugCapacity;
	}

	public static WeightTier[] ReturnWeightTiers()
	{
		if ((bool)_townheartEngine)
		{
			return _townheartEngine.WeightTiers;
		}
		return null;
	}

	public static float ReturnRange()
	{
		if ((bool)_townheartEngine)
		{
			return _townheartEngine.ReturnEnergyRange();
		}
		return 0f;
	}

	public void Activate()
	{
		Active = true;
		RotateVisual();
	}

	public bool CanBeSalvaged()
	{
		return !_isTownheartEngine;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public bool IsEnabled()
	{
		if (Active && Buildable.BuildPhase == BuildPhase.Finished)
		{
			if (!(this == _townheartEngine))
			{
				return IsConnectedToTownheartEnergyGrid();
			}
			return true;
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
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new EnginePersistentData(this);
	}

	public void Shutdown()
	{
	}

	public void ShutdownImmediately()
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
		return text;
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.AddComponent(this);
		_updateMalfunctions = true;
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		if (grid != null)
		{
			grid.RemoveComponent(this);
			_updateMalfunctions = true;
		}
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		return null;
	}
}
