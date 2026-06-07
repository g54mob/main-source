using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkScavengeable : LandmarkInteractableWithComposition
{
	[SerializeField]
	private Target _scavengeTarget;

	[SerializeField]
	private RotationShaker _main;

	[SerializeField]
	private RotationShaker[] _secondaries;

	public bool IsBeingScavenged { get; private set; }

	public override void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
	}

	public IEnumerator ScavengeCoroutine(Agent agent, Project project, List<Item> itemsToScavenge)
	{
		IsBeingScavenged = true;
		Navigator navigator = agent.ReturnNavigator();
		navigator.enabled = false;
		agent.UpdateActivity(Activity.Moving);
		agent.LookAtObject(_scavengeTarget.transform);
		yield return MoveAgentToTargetCoroutine(agent, _scavengeTarget, navigator.ReturnSpeed());
		agent.UpdateActivity(Activity.Scavenge);
		yield return _main.ShakeCoroutine(5f);
		if (_secondaries != null)
		{
			RotationShaker[] secondaries = _secondaries;
			foreach (RotationShaker rotationShaker in secondaries)
			{
				yield return rotationShaker.ShakeCoroutine(5f);
				yield return _main.ShakeCoroutine(1f);
			}
		}
		if (0 < itemsToScavenge.Count)
		{
			Item item = itemsToScavenge[0];
			while (item.Inventory == base.Inventory && 0 < agent.Inventory.ReturnAvailableStorageCapacity())
			{
				if (agent.Inventory.FitsInInventory(item))
				{
					base.Inventory.TakeItem(item);
					itemsToScavenge.Remove(item);
					throw new NotImplementedException("TODO: Implement method adds item to agent inventory and handles it state in ProjectAssignment!");
				}
				if (0 >= itemsToScavenge.Count)
				{
					break;
				}
				item = itemsToScavenge[0];
			}
		}
		yield return MoveAgentToTargetCoroutine(agent, Target, navigator.ReturnSpeed());
		navigator.enabled = true;
		IsBeingScavenged = false;
	}

	private IEnumerator MoveAgentToTargetCoroutine(Agent agent, Target target, float speed)
	{
		Vector3 startPosition = agent.transform.position;
		Vector3 targetPosition = target.transform.position;
		float time = 0f;
		float duration = Vector3.Distance(startPosition, targetPosition) / speed;
		agent.LookAtObject(target.transform);
		agent.UpdateActivity(Activity.Moving);
		while (time < duration)
		{
			yield return null;
			time += Time.deltaTime;
			agent.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
		}
		agent.transform.position = targetPosition;
	}

	public void InterruptScavenging()
	{
		IsBeingScavenged = false;
		StopAllCoroutines();
		_main.InterruptShaking();
		RotationShaker[] secondaries = _secondaries;
		for (int i = 0; i < secondaries.Length; i++)
		{
			secondaries[i].InterruptShaking();
		}
	}

	public void CountScavengedItems(InventoryAuditor auditor)
	{
		foreach (IInventorySlot slot in _compositionInventory.Slots)
		{
			int num = slot.Capacity - slot.Count;
			if (num != 0)
			{
				auditor.CountItemProperties(slot.ItemProperties, num);
			}
		}
	}

	public List<Item> ReturnAllItems()
	{
		return _compositionInventory.ReturnAllItems();
	}
}
