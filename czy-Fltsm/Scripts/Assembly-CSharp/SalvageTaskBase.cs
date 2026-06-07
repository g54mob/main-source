using System;
using System.Collections;
using UnityEngine;

public abstract class SalvageTaskBase : TaskBase
{
	public enum Sorting
	{
		Distance = 0,
		UnityNavMesh = 1
	}

	[SerializeField]
	protected Sorting _sortingMethod;

	[SerializeField]
	protected bool _sortingUpdatesPosition;

	public DrifterAttributes.AttributeType Attribute;

	public DrifterRigEventType AnimationEventType;

	protected ISalvageTarget _salvageTarget;

	protected ItemToHaul _itemToSalvage;

	public override void Initialize(ProjectAssignment assignment)
	{
		base.Initialize(assignment);
		_salvageTarget = assignment.Project.SalvageTarget;
		if (_salvageTarget == null)
		{
			Debug.LogException(new Exception("'" + assignment.Agent.Name + "' initialized the salvage task for project '" + assignment.Project.Properties.name + "', but the project its SalvageTarget == NULL."));
		}
	}

	protected void FillItemsToSalvage()
	{
		if (_salvageTarget != null)
		{
			_salvageTarget.PopulateItemsToHaul(_assignment);
		}
	}

	protected IEnumerator SalvageItem(ItemToHaul itemToSalvage)
	{
		_itemToSalvage = itemToSalvage;
		yield return MoveAgentCoroutine(_itemToSalvage.MoveToTarget, ValidateItemToSalvage);
		if (_itemToSalvage == null)
		{
			UpdateItemsToSalvage();
			yield break;
		}
		AwardAdditionalSalvageExperience(_itemToSalvage);
		yield return _itemToSalvage.IncrementStateCoroutine(AnimationEventType, Attribute);
		OnItemSalvaged(_itemToSalvage);
	}

	protected virtual void OnItemSalvaged(ItemToHaul salvagedItem)
	{
	}

	private void UpdateItemsToSalvage()
	{
		bool flag = false;
		int count = _assignment.ItemsToHaul.Count;
		while (0 < count--)
		{
			ItemToHaul itemToHaul = _assignment.ItemsToHaul[count];
			if (itemToHaul.State == ItemToHaul.HaulState.Pickup && !IsSalvageableItem(itemToHaul.Item) && _assignment.RemoveItemToHaul(itemToHaul))
			{
				flag = true;
			}
		}
		if (flag)
		{
			FillItemsToSalvage();
		}
	}

	private bool ValidateItemToSalvage(ITarget target)
	{
		if (IsSalvageableItem(_itemToSalvage.Item))
		{
			return true;
		}
		_itemToSalvage = null;
		return false;
	}

	private void AwardAdditionalSalvageExperience(ItemToHaul itemToSalvage)
	{
		if (_project.SalvageTarget != null)
		{
			float num = _project.SalvageTarget.ReturnSalvageItemExperience(itemToSalvage.Item);
			if (0f < num)
			{
				GameManager.ExpertiseManager.IncreaseExperience(_agent, num);
			}
		}
	}

	private bool IsSalvageableItem(Item item)
	{
		if (_salvageTarget != null)
		{
			return _salvageTarget.ReturnIsSalvageableItem(item);
		}
		return false;
	}
}
