using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Construction))]
public class WalkwayPonton : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	[SerializeField]
	private DecorationSlots _energyPoleSlots;

	private EnergyGridPole _energyPole;

	private List<WalkwaySegment> _neighbouringWalkwaySegments = new List<WalkwaySegment>();

	private Construction _construction;

	private bool _canSalvage;

	public Buildable Buildable { get; private set; }

	public Construction Construction => _construction;

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public EnergyGridPole EnergyPole => _energyPole;

	public IReadOnlyList<WalkwaySegment> NeighbouringWalkwaySegments => _neighbouringWalkwaySegments;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		_construction = Buildable.GetComponent<Construction>();
		_construction.OnNeighbourChangeEvent.AddListener(UpdateWalkwayNeighbours);
		UpdateWalkwayNeighbours();
		if (_energyPoleSlots != null)
		{
			if (_energyPole == null)
			{
				DecorationSlots energyPoleSlots = _energyPoleSlots;
				energyPoleSlots.OnDecorationAdded = (Action<Decoration>)Delegate.Combine(energyPoleSlots.OnDecorationAdded, new Action<Decoration>(AttachEnergyPole));
			}
			else
			{
				DecorationSlots energyPoleSlots2 = _energyPoleSlots;
				energyPoleSlots2.OnDecorationRemoved = (Action<Decoration>)Delegate.Combine(energyPoleSlots2.OnDecorationRemoved, new Action<Decoration>(DetachEnergyPole));
			}
		}
		Buildable.Community.AddWalkwayPonton(this);
		Construction.OnNeighboursChangedEvent.AddListener(UpdateCanSalvage);
	}

	public void Remove()
	{
		Buildable.Community.RemoveWalkwayPonton(this);
		RemoveListeners();
	}

	private void OnDestroy()
	{
		RemoveListeners();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public bool CanBeSalvaged()
	{
		if (_canSalvage)
		{
			if (!(_energyPoleSlots == null))
			{
				return _energyPoleSlots.CanBeSalvaged();
			}
			return true;
		}
		return false;
	}

	public bool CanBeUpgraded()
	{
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PontonPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		PontonPersistentData pontonPersistentData = persistentData as PontonPersistentData;
		if (pontonPersistentData.EnergyGridPole != null && pontonPersistentData.EnergyGridPole.TryReturn(out var instance))
		{
			AttachEnergyPole(instance);
			AttachTransform(instance.transform);
		}
		if (Buildable.BuildPhase != BuildPhase.HaulFrom && Buildable.BuildPhase != BuildPhase.Finished)
		{
			Buildable.BuildBuildable();
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		PontonPersistentData pontonPersistentData = persistentData as PontonPersistentData;
		if (_energyPole != null && _energyPole.Buildable != null)
		{
			pontonPersistentData.EnergyGridPole = _energyPole;
		}
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return CanBeSalvaged();
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

	public float ReturnWeight()
	{
		return 0f;
	}

	public void AttachEnergyPole(EnergyGridPole pole)
	{
		_energyPole = pole;
		Buildable.OnBuildableUpgradedEvent.AddListener(MoveEnergyPole);
		if (pole.Decoration != null)
		{
			if (_energyPoleSlots != null)
			{
				DecorationSlots energyPoleSlots = _energyPoleSlots;
				energyPoleSlots.OnDecorationAdded = (Action<Decoration>)Delegate.Remove(energyPoleSlots.OnDecorationAdded, new Action<Decoration>(AttachEnergyPole));
				DecorationSlots energyPoleSlots2 = _energyPoleSlots;
				energyPoleSlots2.OnDecorationRemoved = (Action<Decoration>)Delegate.Combine(energyPoleSlots2.OnDecorationRemoved, new Action<Decoration>(DetachEnergyPole));
			}
			return;
		}
		if (pole.Buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
		{
			Construction.AddNeighbourConstruction(buildableExtendable);
		}
		pole.Buildable.OnBuildableRemovedEvent.AddListener(DetachEnergyPole);
		if (_energyPoleSlots != null)
		{
			_energyPoleSlots.SetPlacementAllowed(allowed: false);
		}
		Construction.OnNeighboursChangedEvent.Invoke();
	}

	private void AttachEnergyPole(Decoration decoration)
	{
		if (_energyPole == null && decoration.TryGetExtendable<EnergyGridPole>(out var extendable))
		{
			AttachEnergyPole(extendable);
		}
	}

	public void MoveEnergyPole(Buildable removed, Buildable upgraded)
	{
		if (_energyPole != null && upgraded.TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable))
		{
			buildableExtendable.AttachEnergyPole(_energyPole);
			if (_energyPole.Buildable != null)
			{
				buildableExtendable.AttachTransform(_energyPole.Buildable.transform);
			}
		}
		DetachEnergyPole();
	}

	public void DetachEnergyPole(Buildable buildable = null)
	{
		EnergyGridPole energyPole = _energyPole;
		_energyPole = null;
		Buildable.OnBuildableUpgradedEvent.RemoveListener(MoveEnergyPole);
		if (energyPole.Decoration != null)
		{
			if (_energyPoleSlots != null)
			{
				DecorationSlots energyPoleSlots = _energyPoleSlots;
				energyPoleSlots.OnDecorationRemoved = (Action<Decoration>)Delegate.Remove(energyPoleSlots.OnDecorationRemoved, new Action<Decoration>(DetachEnergyPole));
				DecorationSlots energyPoleSlots2 = _energyPoleSlots;
				energyPoleSlots2.OnDecorationAdded = (Action<Decoration>)Delegate.Combine(energyPoleSlots2.OnDecorationAdded, new Action<Decoration>(AttachEnergyPole));
			}
			return;
		}
		if (energyPole.Buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
		{
			Construction.RemoveNeighbour(buildableExtendable);
		}
		energyPole.Buildable.OnBuildableRemovedEvent.RemoveListener(DetachEnergyPole);
		if (_energyPoleSlots != null)
		{
			_energyPoleSlots.SetPlacementAllowed(allowed: true);
		}
		Construction.OnNeighboursChangedEvent.Invoke();
	}

	private void DetachEnergyPole(Decoration decoration)
	{
		if (_energyPole != null && _energyPole.Decoration == decoration)
		{
			DetachEnergyPole();
		}
	}

	public void AttachTransform(Transform transform)
	{
		transform.SetParent(Buildable.BuoyantTransform);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Finish(bool restored = false)
	{
		int count = _construction.NeighbourConstructions.Count;
		if (count == 0 || count != _neighbouringWalkwaySegments.Count)
		{
			return;
		}
		foreach (WalkwaySegment neighbouringWalkwaySegment in _neighbouringWalkwaySegments)
		{
			neighbouringWalkwaySegment.Buildable.CancelDeconstruction();
		}
	}

	private void RemoveListeners()
	{
		_construction.OnNeighbourChangeEvent.RemoveListener(UpdateWalkwayNeighbours);
		for (int i = 0; i < _neighbouringWalkwaySegments.Count; i++)
		{
			_neighbouringWalkwaySegments[i].Buildable.OnBuildableRemovedEvent.RemoveListener(RemoveWalkwayNeighbour);
		}
		if (_energyPole != null)
		{
			if (_energyPole.Buildable != null)
			{
				_energyPole.Buildable.OnBuildableRemovedEvent.RemoveListener(DetachEnergyPole);
			}
			Buildable.OnBuildableUpgradedEvent.RemoveListener(MoveEnergyPole);
		}
		if (_energyPoleSlots != null)
		{
			DecorationSlots energyPoleSlots = _energyPoleSlots;
			energyPoleSlots.OnDecorationAdded = (Action<Decoration>)Delegate.Remove(energyPoleSlots.OnDecorationAdded, new Action<Decoration>(AttachEnergyPole));
			DecorationSlots energyPoleSlots2 = _energyPoleSlots;
			energyPoleSlots2.OnDecorationRemoved = (Action<Decoration>)Delegate.Remove(energyPoleSlots2.OnDecorationRemoved, new Action<Decoration>(DetachEnergyPole));
		}
		Construction.OnNeighboursChangedEvent.RemoveListener(UpdateCanSalvage);
	}

	private void UpdateWalkwayNeighbours()
	{
		_neighbouringWalkwaySegments.Clear();
		for (int i = 0; i < _construction.NeighbourConstructions.Count; i++)
		{
			AddWalkwayNeighbour(_construction.NeighbourConstructions[i].Buildable);
		}
	}

	private void AddWalkwayNeighbour(Buildable buildable)
	{
		WalkwaySegment component = buildable.GetComponent<WalkwaySegment>();
		if (!(component == null))
		{
			buildable.OnBuildableRemovedEvent.RemoveListener(RemoveWalkwayNeighbour);
			buildable.OnBuildableRemovedEvent.AddListener(RemoveWalkwayNeighbour);
			_neighbouringWalkwaySegments.AddUnique(component);
		}
	}

	private void RemoveWalkwayNeighbour(Buildable buildable)
	{
		for (int num = _neighbouringWalkwaySegments.Count - 1; num >= 0; num--)
		{
			if (!(_neighbouringWalkwaySegments[num].Buildable != buildable))
			{
				_neighbouringWalkwaySegments.RemoveAt(num);
				buildable.OnBuildableRemovedEvent.RemoveListener(RemoveWalkwayNeighbour);
			}
		}
		if (_neighbouringWalkwaySegments.Count == 0)
		{
			Buildable.Remove();
		}
	}

	public void SalvageWalkwayNeighbours()
	{
		for (int num = _neighbouringWalkwaySegments.Count - 1; num >= 0; num--)
		{
			_neighbouringWalkwaySegments[num].Buildable.Salvage();
		}
	}

	public bool RemoveAttachedWalkwaySegment()
	{
		_ = _neighbouringWalkwaySegments.Count;
		if (_neighbouringWalkwaySegments.Count == 1)
		{
			WalkwaySegment walkwaySegment = _neighbouringWalkwaySegments[0];
			walkwaySegment.Buildable.Deactivate();
			walkwaySegment.Buildable.Remove();
			_neighbouringWalkwaySegments.Clear();
			return true;
		}
		if (NeighbouringWalkwaySegments.Count > 1)
		{
			Debug.LogException(new NotSupportedException("Only pontons with a 1 or no walkway segment attached should invoke RemoveAttachedWalkwaySegment."));
		}
		return false;
	}

	public void UpdateCanSalvage()
	{
		_canSalvage = ReturnCanSalvage();
	}

	private bool ReturnCanSalvage()
	{
		if (_energyPole != null || (_energyPoleSlots != null && !_energyPoleSlots.CanBeSalvaged()))
		{
			return false;
		}
		int count = _construction.NeighbourConstructions.Count;
		if (count == 0)
		{
			return true;
		}
		if (count != _neighbouringWalkwaySegments.Count)
		{
			return false;
		}
		foreach (WalkwaySegment neighbouringWalkwaySegment in _neighbouringWalkwaySegments)
		{
			if (neighbouringWalkwaySegment.ReturnNeighboursBlockSalvaging())
			{
				return false;
			}
			if (!neighbouringWalkwaySegment.Construction.IsConnectedToTownheart(_construction))
			{
				return false;
			}
		}
		return true;
	}

	public void ReturnBlockingNeighbours(ref ListPool<VisualPrefab>.List blockingConstructions)
	{
		if (Construction == null)
		{
			return;
		}
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			blockingConstructions.Add(neighbourConstruction.Buildable.SpawnedVisual);
		}
		if (_energyPole != null && _energyPole.Decoration != null)
		{
			blockingConstructions.Add(_energyPole.Decoration.SpawnedVisual);
		}
	}

	public bool NeighbouringWalkwaysFinished()
	{
		foreach (WalkwaySegment neighbouringWalkwaySegment in _neighbouringWalkwaySegments)
		{
			if (neighbouringWalkwaySegment.Buildable.BuildPhase != BuildPhase.Finished)
			{
				return false;
			}
		}
		return true;
	}
}
