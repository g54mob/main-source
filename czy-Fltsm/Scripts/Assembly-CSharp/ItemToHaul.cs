using System;
using System.Collections;
using UnityEngine;

public class ItemToHaul
{
	public enum HaulState
	{
		None = 0,
		Pickup = 1,
		Transit = 2,
		Finished = 3
	}

	private const float DRIFTER_RIG_EVENT_TIMEOUT = 10f;

	private ProjectAssignment _projectAssignment;

	private int _drifterEventAmount;

	private float _drifterFailsafeTimer;

	private DrifterRigEventType _drifterRigEventType;

	public Item Item { get; private set; }

	public HaulState State { get; private set; }

	public Inventory TargetInventory { get; private set; }

	public SubInventoryType TargetSubInventory { get; private set; }

	public Target MoveToTarget { get; private set; }

	public bool IsGeneralListItem { get; private set; }

	private ItemToHaul(ProjectAssignment projectAssignment, Item item, Inventory targetInventory, SubInventoryType targetSubInventory, bool isGeneralListItem)
	{
		_projectAssignment = projectAssignment;
		IsGeneralListItem = isGeneralListItem;
		Item = item;
		Item.Project = projectAssignment.Project;
		TargetInventory = targetInventory;
		TargetSubInventory = targetSubInventory;
		if (item.Inventory == TargetInventory && item.SubInventory == TargetSubInventory)
		{
			SetState(HaulState.Finished);
		}
		else if (item.Inventory == _projectAssignment.ReturnTransitInventory())
		{
			SetState(HaulState.Transit);
		}
		else
		{
			SetState(HaulState.Pickup);
		}
	}

	public static bool TryGet(out ItemToHaul itemToHaul, ProjectAssignment assignment, Item item, SubInventoryType targetSubInventory, bool isGeneralListItem)
	{
		Inventory inventory;
		if ((bool)item.MoveToInventory)
		{
			inventory = item.MoveToInventory;
			targetSubInventory = inventory.ReturnCorrectItemSubInventory(item, targetSubInventory);
		}
		else if ((bool)assignment.Boat)
		{
			inventory = assignment.Boat.Buildable.Inventory;
			targetSubInventory = SubInventoryType.Storage;
		}
		else
		{
			inventory = assignment.ReturnTargetInventory();
			if (inventory != null)
			{
				targetSubInventory = inventory.ReturnCorrectItemSubInventory(item, targetSubInventory);
			}
		}
		if (inventory == null)
		{
			itemToHaul = null;
			return false;
		}
		itemToHaul = new ItemToHaul(assignment, item, inventory, targetSubInventory, isGeneralListItem);
		return true;
	}

	public IEnumerator IncrementStateCoroutine(DrifterRigEventType rigEventType, DrifterAttributes.AttributeType modifierType = DrifterAttributes.AttributeType.None)
	{
		if (Item == null || Item.Owner == null || Item.Inventory == null || !HasValidProject())
		{
			yield break;
		}
		Agent agent = _projectAssignment.Agent;
		InventoryBase inventory = Item.Inventory;
		switch (State)
		{
		case HaulState.Pickup:
		{
			Inventory inventory2 = _projectAssignment.ReturnTransitInventory();
			if (!(inventory2 == TargetInventory))
			{
				yield return TransferItemCoroutine(agent, rigEventType, inventory.PickupActivity, inventory.AnimationCycles, modifierType, inventory2);
				if (HasValidProject())
				{
					SetState(HaulState.Transit);
				}
				break;
			}
			goto case HaulState.Transit;
		}
		case HaulState.Transit:
			yield return TransferItemCoroutine(agent, rigEventType, inventory.DropoffActivity, inventory.AnimationCycles, modifierType, TargetInventory, TargetSubInventory);
			if (HasValidProject())
			{
				SetState(HaulState.Finished);
			}
			break;
		}
	}

	public bool Consume()
	{
		if (State == HaulState.Pickup && Item.Inventory == null)
		{
			SetState(HaulState.Finished);
			return true;
		}
		return false;
	}

	public void Remove()
	{
		Item.TakeFromInventory();
		Item.Inventory = null;
		SetState(HaulState.Finished);
	}

	private IEnumerator TransferItemCoroutine(Agent agent, DrifterRigEventType rigEventType, Activity agentActivity, int animationCycles, DrifterAttributes.AttributeType modifierType, Inventory targetInventory, SubInventoryType targetSubInventory = SubInventoryType.Storage)
	{
		if (targetInventory.FitsInInventory(Item, targetSubInventory))
		{
			agent.UpdateActivity(agentActivity);
			if (targetInventory.Type == InventoryType.Boat || targetInventory.Type == InventoryType.Agent)
			{
				agent.LookAtObject(Item.Owner.transform);
			}
			else
			{
				agent.LookAtObject(targetInventory.ReturnDropOffTarget(targetSubInventory));
			}
			_drifterRigEventType = rigEventType;
			_drifterEventAmount = 0;
			float num = agent.Attributes.ReturnAttributeModifier(modifierType);
			AnimatorHelper.AddDrifterRigTypeEventListener(agent, OnDrifterEvent);
			AnimatorHelper.SetFloat(agent, "Speed Multiplier", num);
			bool flag = HasValidProject();
			float drifterRigEventTimeout = 10f / Mathf.Max(0.1f, num);
			_drifterFailsafeTimer = 0f;
			while (_drifterEventAmount < animationCycles && flag)
			{
				_drifterFailsafeTimer += Time.deltaTime;
				if (_drifterFailsafeTimer >= drifterRigEventTimeout)
				{
					Debug.LogWarning($"DrifterRigEvent timed out after {_drifterFailsafeTimer} seconds for '{agent.Name}' trying to transfer item '{Item.Properties.LocalizedName}'");
					OnDrifterEvent(_drifterRigEventType);
				}
				yield return null;
				flag = HasValidProject();
			}
			AnimatorHelper.RemoveDrifterRigTypeEventListener(agent, OnDrifterEvent);
			AnimatorHelper.SetFloat(agent, "Speed Multiplier", 1f);
			if (flag)
			{
				GameManager.WorldManager.SpawnAndThrowFlotsam(ThrowProperties.ReturnTransferProperties(Item, targetInventory, targetSubInventory));
				AudioManager.Play(Item.Properties.FlotsamProperties.HaulingAudio, Item.Owner.transform);
				GameManager.Settings.AudioSettings.PlayInventoryTypeSound(Item.Inventory.Type, Item.Inventory.transform);
				TransferItemToInventory(targetInventory, targetSubInventory);
			}
		}
		else
		{
			Debug.LogErrorFormat("'{0}' was unable to increment state of ItemToHaul '{1}' because it does not fit in the current states target inventory '{2}->{3}'!", agent.Name, Item.Properties.name, TargetInventory.name, TargetSubInventory);
		}
	}

	private void OnDrifterEvent(DrifterRigEventType evt)
	{
		if (evt == _drifterRigEventType)
		{
			_drifterEventAmount++;
			_drifterFailsafeTimer = 0f;
		}
	}

	private void TransferItemToInventory(Inventory transferToInventory, SubInventoryType transferToSubInventory)
	{
		Item item = Item.Inventory.TakeItem(Item);
		if (item == null || !transferToInventory.AddItem(item, transferToSubInventory))
		{
			Debug.LogException(new Exception($"Unable to transfer item '{Item.Properties.name}' from inventory '{Item.Inventory.name}/{Item.SubInventory}' to inventory '{transferToInventory.name}/{transferToSubInventory}'"));
		}
	}

	private void SetState(HaulState state)
	{
		if (State != state)
		{
			State = state;
			switch (state)
			{
			case HaulState.Pickup:
				MoveToTarget = Item.Inventory.Target;
				break;
			case HaulState.Transit:
				MoveToTarget = TargetInventory.GetComponentInChildren<Target>();
				break;
			case HaulState.Finished:
				Dispose(finished: true);
				_projectAssignment.RemoveItemToHaul(this);
				MoveToTarget = null;
				break;
			}
		}
	}

	public void Dispose(bool finished = false)
	{
		HaulState state = State;
		if (state != HaulState.Pickup)
		{
			if (state == HaulState.Transit)
			{
				if (finished)
				{
					throw new NotSupportedException($"Assignment for project '{_projectAssignment.Project.Properties.name}' has finished, but ItemToHaul '{Item.Properties.LocalizedName}' is in transit state, this is a bug!");
				}
				goto IL_0128;
			}
		}
		else
		{
			if (finished)
			{
				Debug.LogErrorFormat("ItemToHaul '{0}' was disposed in pickup state, but '{1}' its assignment for project '{2}' has already finished!", Item.Properties.LocalizedName, _projectAssignment.Agent.Name, _projectAssignment.Project.Properties.name);
			}
			if (IsGeneralListItem)
			{
				Item.Project.GeneralItems.Add(Item);
				return;
			}
		}
		if (Item.UnreserveMoveToInventory() && finished)
		{
			Debug.LogWarningFormat("ItemToHaul '{0}' was disposed while it had a inventory space reserved!", Item.Properties.LocalizedName);
		}
		if (Item.CancelReservation() && finished)
		{
			Debug.LogWarningFormat("ItemToHaul '{0}' was disposed while it was reserved!", Item.Properties.LocalizedName);
		}
		goto IL_0128;
		IL_0128:
		Item.Project = null;
	}

	public bool ReturnCanIncrementState()
	{
		return State switch
		{
			HaulState.Pickup => _projectAssignment.Agent.Inventory.FitsInInventory(Item), 
			HaulState.Transit => TargetInventory.FitsInInventory(Item, TargetSubInventory), 
			_ => false, 
		};
	}

	public bool HasValidProject()
	{
		return Item.Project?.IsValid() ?? false;
	}

	public bool HasStorageSpaceReserved()
	{
		if (TargetInventory.Type == InventoryType.Storage && (bool)TargetInventory.Storage)
		{
			return TargetInventory.Storage.HasItemIncoming(Item);
		}
		return false;
	}
}
