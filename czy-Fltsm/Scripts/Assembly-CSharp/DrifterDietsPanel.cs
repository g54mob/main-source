using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterDietsPanel : DrifterPanelBase
{
	[SerializeField]
	private ChildBehaviourCache<InventoryPanelItemSlot> _foodSlotCache;

	[SerializeField]
	private ChildBehaviourCache<DrifterDietRow> _drifterDietRowCache;

	[SerializeField]
	private DrifterDietRow _templateDietRow;

	[SerializeField]
	private RewiredAction _increaseAction;

	[SerializeField]
	private RewiredAction _decreaseAction;

	[SerializeField]
	private DrifterFieldInfo _drifterFieldInfo;

	private List<ItemProperties> _foodItemProperties;

	private CommunityInventory _communityInventory;

	private DrifterDietRow _selectedDietRow;

	private int _selectedFoodIndex;

	private List<Agent> _drifters;

	private void OnEnable()
	{
		_increaseAction.ActivateWait();
		_decreaseAction.ActivateWait();
	}

	private void LateUpdate()
	{
		if (_increaseAction.GetButtonDown())
		{
			_selectedDietRow.IncreaseSelected();
		}
		if (_decreaseAction.GetButtonDown())
		{
			_selectedDietRow.DecreaseSelected();
		}
	}

	private void OnDisable()
	{
		_foodSlotCache.DeactivateParent();
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!base.Open(id, context))
		{
			return false;
		}
		GameManager.AgentManager.DistributeConsumables(isSimulation: true);
		_foodItemProperties = GameManager.Settings.ItemSettings.ReturnFoodItemProperties();
		_communityInventory = Community.PlayerCommunity.Inventory;
		RewiredAction.AddToActionInfoBar(_increaseAction, _decreaseAction);
		GameEventDispatcher.AddListener(GameEventType.CommunityInventoryUpdated, UpdateState);
		GameEventDispatcher.AddListener(GameEventType.AgentDietUpdated, UpdateState);
		UpdateFoodSlots();
		return true;
	}

	public override void Close()
	{
		RewiredAction.RemoveFromActionInfoBar(_increaseAction, _decreaseAction);
		GameEventDispatcher.RemoveListener(GameEventType.CommunityInventoryUpdated, UpdateState);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDietUpdated, UpdateState);
		base.Close();
	}

	public override void UpdateDrifters(List<Agent> drifters)
	{
		if (drifters == null)
		{
			return;
		}
		_drifters = drifters;
		_drifterDietRowCache.Reset();
		foreach (Agent drifter in _drifters)
		{
			_drifterDietRowCache.Get(active: true).Initialize(drifter);
		}
		_drifterDietRowCache.Trim();
	}

	public override void SetSelectedDrifter(Agent drifter)
	{
		foreach (DrifterDietRow instance in _drifterDietRowCache.Instances)
		{
			if (instance.Drifter == drifter && instance.gameObject.activeInHierarchy)
			{
				if ((bool)_selectedDietRow)
				{
					_selectedDietRow.Deselect();
				}
				_selectedDietRow = instance;
				_selectedFoodIndex = _selectedDietRow.Select(_selectedFoodIndex);
			}
		}
	}

	private void UpdateFoodSlots()
	{
		_foodSlotCache.Reset();
		foreach (ItemProperties foodItemProperty in _foodItemProperties)
		{
			_foodSlotCache.Get(active: true).Initialize(foodItemProperty, _communityInventory.ReturnCount(foodItemProperty));
		}
		_foodSlotCache.Trim();
	}

	private void UpdateState(GameEvent gameEvent)
	{
		GameManager.AgentManager.DistributeConsumables(isSimulation: true);
		UpdateFoodSlots();
		UpdateDrifters(_drifters);
	}

	public override void OnMove(AxisEventData axisEventData)
	{
		switch (axisEventData.moveDir)
		{
		case MoveDirection.Left:
			_selectedFoodIndex = _selectedDietRow.SelectLeft(_selectedFoodIndex);
			break;
		case MoveDirection.Right:
			_selectedFoodIndex = _selectedDietRow.SelectRight(_selectedFoodIndex);
			break;
		}
	}

	public void IncreaseSelected()
	{
		_selectedDietRow.IncreaseSelected();
	}

	public void DecreaseSelected()
	{
		_selectedDietRow.DecreaseSelected();
	}
}
