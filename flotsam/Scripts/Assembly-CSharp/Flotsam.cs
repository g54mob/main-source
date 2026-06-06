using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Flotsam : FlotsamBehaviour, ISelectable, IPersistentReference
{
	[Header("HACK")]
	[SerializeField]
	public NonInteractableFlotsam NonInteractablePrefab;

	[Header("References")]
	[SerializeField]
	private FlotsamInventory _inventory;

	[SerializeField]
	private Target _target;

	public string LocalizedName { get; private set; } = "";

	public bool Initialized { get; protected set; }

	public bool IsPointOfInterest { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Vector3 Position { get; private set; }

	public ObjectType ObjectType => ObjectType.None;

	public GameObject RelatedGameObject => base.gameObject;

	public override bool Interactable => true;

	public FlotsamInventory Inventory => _inventory;

	public override bool Initialize(FlotsamProperties properties, int visualPrefabIndex)
	{
		if (!base.Initialize(properties, visualPrefabIndex))
		{
			return false;
		}
		Inventory.TransferAnimationCycles = properties.AnimationCycles;
		Inventory.Pickup = properties.SalvageActivity;
		Inventory.Dropoff = properties.SalvageActivity;
		InitializeVisual();
		AddFlotsamToWorldlist();
		base.transform.rotation = base.VisualPrefab.ReturnRandomRotation();
		if (base.transform.parent == null)
		{
			base.transform.SetParent(GameManager.WorldManager.FlotsamParent, worldPositionStays: true);
		}
		if (!base.Properties.Static)
		{
			_target.Radius = base.Properties.TargetRadius;
		}
		Initialized = true;
		return true;
	}

	public override void InitializeComposition(CompositionInventory compositionInventory)
	{
		_inventory.Initialize(compositionInventory);
		_inventory.CompositionUpdatedEvent += OnCompositionUpdated;
		Item item = compositionInventory.PeekAtFirstItem();
		base.gameObject.name = item.Properties.name;
		LocalizedName = item.Properties.LocalizedName;
		if (compositionInventory.ReturnProgress() < 1f)
		{
			OnCompositionUpdated(compositionInventory.ReturnProgress());
		}
	}

	protected virtual void LateUpdate()
	{
		Position = base.transform.position;
	}

	private void OnDestroy()
	{
		if (_inventory != null)
		{
			_inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
		}
		SafelyDestroy(clearProject: true, release: false);
	}

	public override void UpdatePositionAndRotation(Vector3 position, Quaternion rotation)
	{
		base.UpdatePositionAndRotation(position, rotation);
		Position = position;
	}

	public override void Throw(ThrowProperties throwProperties)
	{
		StartCoroutine(ThrowCoroutine(throwProperties));
	}

	protected virtual IEnumerator ThrowCoroutine(ThrowProperties throwProperties)
	{
		RemoveFlotsamFromWorldlist();
		yield return ThrowMovementCoroutine(throwProperties);
		base.transform.localScale = Vector3.one;
		AddFlotsamToWorldlist();
		GameManager.WorldManager.AddFlotsam(this);
	}

	public void AddFlotsamToWorldlist()
	{
		Position = base.transform.position;
		GameManager.WorldManager.FlotsamInWorld.AddUnique(this);
	}

	public void RemoveFlotsamFromWorldlist()
	{
		GameManager.WorldManager.FlotsamInWorld.RemoveSafely(this);
	}

	public void SafelyDestroy(bool clearProject = true, bool release = true)
	{
		Remove(clearProject);
		if (release)
		{
			FlotsamPool.Instance.Release(this);
		}
	}

	private void Remove(bool removeForAgents = true)
	{
		RemoveFlotsamFromWorldlist();
		if (!removeForAgents)
		{
			return;
		}
		List<Item> list = Inventory.ReturnAllItems();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Project != null)
			{
				list[i].Project.RemoveItem(list[i]);
			}
		}
	}

	private void OnCompositionUpdated(float progress)
	{
		if (progress == 0f)
		{
			SafelyDestroy(clearProject: false);
			FlotsamEvent.Dispatch(GameEventType.FlotsamSalvage, this);
			base.OnSalvage.Invoke();
			return;
		}
		if (base.VisualPrefab == null)
		{
			throw new NotSupportedException();
		}
		base.VisualPrefab.SetProgress(progress);
	}

	public override void Activate(Vector3 position)
	{
		base.Activate(position);
		AddFlotsamToWorldlist();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		RemoveFlotsamFromWorldlist();
		if ((bool)_inventory)
		{
			_inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
		}
	}

	public FlotsamProperties ReturnProperties()
	{
		return base.Properties;
	}

	public override float ReturnCompositionProgress()
	{
		return _inventory.ReturnCompositionProgress();
	}
}
