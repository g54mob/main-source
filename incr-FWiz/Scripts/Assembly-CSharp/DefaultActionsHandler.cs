using System.Collections.Generic;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class DefaultActionsHandler : PlayerActionMode
{
	public enum Action
	{
		None = 0,
		Press = 1,
		Collect = 2,
		Drop = 3
	}

	[SerializeField]
	private Camera _camera;

	private PlayerInventory _inventory;

	private int _disablingRequests;

	private List<ClickHoldActionHandler> _hoverActionHandlers;

	private ClickHoldActionHandler _lastHoldActionHandler;

	[Header("Collecting")]
	[SerializeField]
	private float _collectFromSupplierBuffer;

	[SerializeField]
	private float _collectItemDistance;

	[SerializeField]
	private float _attractItemDist;

	[SerializeField]
	private float _attractItemForce;

	[SerializeField]
	private EventReference _pickupSupplierSound;

	private float _collectFromSupplierTimer;

	private List<PickupSupplier> _hoveredPickupSuppliers;

	[SerializeField]
	private float _collectComboSoundCooldown;

	private float _collectSoundTimer;

	private int _collectSoundComboCount;

	private const string _collectSpeedParamId = "PickupSpeed";

	[Header("Dropping")]
	[SerializeField]
	private float _minDropBuffer;

	[SerializeField]
	private float _totalDropBufferGrowth;

	[SerializeField]
	private float _dropsTillMaxBufferGrowth;

	[SerializeField]
	private float _dropStackExhaustedBuffer;

	[SerializeField]
	private float _dropCollectorChangeBuffer;

	private float _successiveDropCount;

	private float _dropTimer;

	private bool _wasUsingDropCollector;

	private bool _currentDropCancelled;

	private List<DropCollector> _hoveredDropObjects;

	[Header("Inventory")]
	[SerializeField]
	private EventReference _rotateInventorySound;

	public bool CanSprintDropAndCollect;

	public override bool PlayerCanMove => false;

	public bool Disabled => false;

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}

	public void AddDisableRequest()
	{
	}

	public void RemoveDisableRequest()
	{
	}

	public void OnInventoryCountChange(ValueUpdateData<int> countUpdate)
	{
	}

	public void OnHoverOverClickObject(ClickHoldActionHandler clickObject)
	{
	}

	public void OnEndHoverOverClickObject(ClickHoldActionHandler clickObject)
	{
	}

	public void OnHoverDropCollector(DropCollector dropObject)
	{
	}

	public void OnEndHoverDropCollector(DropCollector dropObject)
	{
	}

	public void OnHoverCollectSupplier(PickupSupplier collectSupplier)
	{
	}

	public void OnEndHoverCollectSupplier(PickupSupplier collectSupplier)
	{
	}

	public void OnScroll(int scroll)
	{
	}

	public void OnPress()
	{
	}

	private void Update()
	{
	}

	public Action DoSomething()
	{
		return default(Action);
	}

	private void TryDropItemsUpdate()
	{
	}

	public void TryCollectUpdate()
	{
	}

	public void UnlockSprintCollecting()
	{
	}
}
