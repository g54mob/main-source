using System;
using System.Collections;
using PajamaLlama.Debugging;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Construction))]
public class MooringPoint : MooringPointBase, IBuildableExtendable
{
	[Header("Malfunctions")]
	[SerializeField]
	private PlaceableAlertProperties _blockedMalfunction;

	[Header("Townheart MooringPoint")]
	[SerializeField]
	[Tooltip("The target used to embark a moored boat.")]
	private Target _embarkTarget;

	[SerializeField]
	private BuildableProperties _startingBoat;

	private Coroutine _evaluateBlockedCoroutine;

	private int _evaluateBlockedFrame;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public override bool IsInTown => true;

	public override bool IsAvailableForMooring
	{
		get
		{
			if (base.IsAvailableForMooring && LinkedBoat == null)
			{
				return Buildable.BuildPhase == BuildPhase.Finished;
			}
			return false;
		}
	}

	public Boat LinkedBoat { get; private set; }

	public UnityEvent OnBoatLinkUpdatedEvent { get; private set; } = new UnityEvent();

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		base.EmbarkTarget = ((_embarkTarget != null) ? _embarkTarget : buildable.ReturnExtendable<Construction>().Target);
		base.MooringPointUpdated.AddListener(UpdateFreeMooringPointIcon);
		FreeMooringPointPrefab.SetActive(value: false);
		Buildable.Community.AddMooringPoint(this);
		GameEventDispatcher.AddListener(GameEventType.ConstructionGraphUpdated, EvaluateBlocked);
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, EvaluateBlocked);
	}

	public void Finish(bool restored = false)
	{
		Buildable.Community.UpdateMooringPoints();
		base.MooringPointUpdated.Invoke();
		EvaluateBlocked();
	}

	protected override void FixedUpdate()
	{
		if (base.MooredBoat != null)
		{
			base.MooredBoat.Buildable.transform.position = ReturnBoatPosition();
			base.MooredBoat.Buildable.transform.rotation = MooringTransform.rotation;
			base.MooredBoat.Buildable.BuoyantTransform.localRotation = Quaternion.identity;
		}
		base.FixedUpdate();
	}

	public void Remove()
	{
		RemoveListeners();
		if (base.MooredBoat != null)
		{
			UnmoorBoat();
		}
		Buildable.Community.RemoveMooringPoint(this);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.ConstructionGraphUpdated, EvaluateBlocked);
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, EvaluateBlocked);
	}

	public void SpawnStartingBoat()
	{
		if (!_startingBoat)
		{
			return;
		}
		Boat boat = Buildable.Place(_startingBoat.Prefab, MooringTransform.position, MooringTransform.rotation, 0, instantPlacement: true).GetComponent<Boat>();
		LinkBoat(boat);
		if (LoadingScreen.IsLoading)
		{
			FinalUpdate.RegisterGameStartOneShot(delegate
			{
				MoorBoat(boat);
			});
		}
		else
		{
			FinalUpdate.RegisterOneShot(delegate
			{
				MoorBoat(boat);
			});
		}
	}

	public bool LinkBoat(Boat boat)
	{
		LogBlock.Begin();
		if ((bool)LinkedBoat && LinkedBoat != boat)
		{
			LogBlock.LogFormat("Unable to link Boat '{0}' to Mooringpoint '{1}' because the MooringPoint is already linked to Boat '{2}'", boat.Buildable.Name, Buildable.Name, LinkedBoat.Buildable.Name);
		}
		if ((bool)boat.TownMooringPoint && boat.TownMooringPoint != this)
		{
			LogBlock.LogFormat("Unable to link Boat '{0}' to Mooringpoint '{1}' because the boat is already linked to MooringPoint '{2}'", boat.Buildable.Name, Buildable.Name, boat.TownMooringPoint.Buildable.Name);
		}
		if (LogBlock.End(out var log))
		{
			Debug.LogWarning(log);
			return false;
		}
		LinkedBoat = boat;
		boat.TownMooringPoint = this;
		OnBoatLinkUpdatedEvent.Invoke();
		return true;
	}

	public void UnlinkBoat(Boat boat)
	{
		LinkedBoat = null;
		boat.TownMooringPoint = null;
		OnBoatLinkUpdatedEvent.Invoke();
	}

	public override bool MoorBoat(Boat boat, bool restored = false)
	{
		if (ValidateLink(boat) && base.MoorBoat(boat, restored))
		{
			if (boat.Buildable.Community.CommunityType == Community.Type.Abandoned)
			{
				boat.AddToCommunity(Buildable.Community);
			}
			if (!boat.Buildable.Inventory.HasItems(SubInventoryType.Storage))
			{
				boat.UpdateMooredStoredItems();
			}
			boat.ResourceProvider.Register();
			return true;
		}
		return false;
	}

	public override bool UnmoorBoat(Agent agent)
	{
		Boat mooredBoat = base.MooredBoat;
		if (base.UnmoorBoat(agent))
		{
			mooredBoat.ResourceProvider.Unregister();
			return true;
		}
		return false;
	}

	private bool ValidateLink(Boat boat)
	{
		if (LinkedBoat == boat && boat.TownMooringPoint == this)
		{
			return true;
		}
		LogBlock.Begin();
		if ((bool)LinkedBoat)
		{
			LogBlock.LogFormat("Unable to validate link between MooringPoint '{0}' and Boat '{1}' because the MooringPoint is linked to Boat '{2}'.", Buildable.Name, boat.Buildable.Name, LinkedBoat.Buildable.Name);
		}
		else
		{
			LogBlock.LogFormat("Unable to validate link between MooringPoint '{0}' and Boat '{1}' because the MooringPoint has no linked Boat.", Buildable.Name, boat.Buildable.Name);
		}
		if ((bool)boat.TownMooringPoint)
		{
			LogBlock.LogFormat("Unable to validate link between Boat '{0}' and MooringPoint '{1}' because the Boat is linked to MooringPoint '{2}'.", boat.Buildable.Name, Buildable.Name, boat.TownMooringPoint.Buildable.Name);
		}
		else
		{
			LogBlock.LogFormat("Unable to validate link between Boat '{0}' and MooringPoint '{1}' because the Boat has no linked MooringPoint.", boat.Buildable.Name, Buildable.Name);
		}
		if (LogBlock.End(out var log))
		{
			Debug.LogError(log);
		}
		return false;
	}

	public Vector3 ReturnBoatPosition()
	{
		return ReturnBoatPosition(base.MooredBoat.MooringOffset, base.MooredBoat.Buildable.transform.position);
	}

	public Vector3 ReturnBoatPosition(Vector3 mooringOffset, Vector3 position)
	{
		return (MooringTransform.position + mooringOffset).SetY(position.y);
	}

	public bool ReturnHasAvailableBoat(BoatType boatType)
	{
		if (Active && !base.IsBlocked && base.ReservingAgent == null && base.MooredBoat != null && base.MooredBoat.Type == boatType && base.MooredBoat.Buildable.BuildPhase == BuildPhase.Finished)
		{
			return base.MooredBoat.Buildable.Inventory.ReturnIsEmpty();
		}
		return false;
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
		if (!base.IsEmpty)
		{
			return false;
		}
		if (LinkedBoat != null)
		{
			return false;
		}
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

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		if (base.IsReserved)
		{
			return false;
		}
		if (LinkedBoat == null)
		{
			return true;
		}
		return false;
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

	public void UpdateFreeMooringPointIcon()
	{
		if (!GameManager.UIManager.DisplayFreeMooringPointIcons)
		{
			FreeMooringPointPrefab.SetActive(value: false);
		}
		else
		{
			FreeMooringPointPrefab.SetActive(IsAvailableForMooring && Buildable.BuildPhase == BuildPhase.Finished);
		}
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new MooringPointPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		MooringPointPersistentData obj = persistentData as MooringPointPersistentData;
		obj.MooredBoat = base.MooredBoat;
		obj.LinkedBoat = LinkedBoat;
	}

	private void EvaluateBlocked(GameEvent gameEvent = null)
	{
		if (base.gameObject.activeInHierarchy && _evaluateBlockedFrame != Time.frameCount)
		{
			if (_evaluateBlockedCoroutine != null)
			{
				StopCoroutine(_evaluateBlockedCoroutine);
			}
			_evaluateBlockedCoroutine = StartCoroutine(EvaluateBlockedRoutine());
			_evaluateBlockedFrame = Time.frameCount;
		}
	}

	private IEnumerator EvaluateBlockedRoutine()
	{
		yield return new WaitForEndOfFrame();
		_evaluateBlockedCoroutine = null;
		if (Pathfinder.HasInstance)
		{
			MooringPointBlockedQuery query = MooringPointBlockedQuery.Get(this, 3);
			Pathfinder.QueueQuery(query);
			while (query.IsExecuting)
			{
				yield return null;
			}
			base.IsBlocked = query.IsBlocked;
			query.Return();
		}
		else
		{
			base.IsBlocked = false;
		}
		if (base.IsBlocked)
		{
			Buildable.AddMalfunction(_blockedMalfunction);
		}
		else
		{
			Buildable.RemoveMalfunction(_blockedMalfunction);
		}
	}
}
