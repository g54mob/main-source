using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Pickups;

public class PickupStackableList
{
	private int maxObjects;

	private EPickup ePickup;

	public LinkedList<Pickup> pickupsList;

	private int combineThreshold;

	public PickupStackableList(int nMax, EPickup ePickup)
	{
		LinkedList<Pickup> linkedList = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A570");
		pickupsList = linkedList;
		combineThreshold = 500;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		maxObjects = nMax;
		this.ePickup = ePickup;
	}

	public unsafe Pickup AddPickup(Vector3 pos)
	{
		//IL_0214: Expected O, but got Ref
		LinkedList<Pickup> linkedList = pickupsList;
		if (pickupsList != null)
		{
			if (linkedList.count < maxObjects)
			{
				goto IL_0321;
			}
			LinkedList<Pickup> linkedList2 = pickupsList;
			if (pickupsList != null)
			{
				LinkedListNode<Pickup> head = linkedList2.head;
				if (linkedList2.head != null)
				{
					LinkedListNode<Pickup> next = linkedList2.head.Next;
					if (next == null)
					{
						goto IL_0321;
					}
					if ((object)next.item != null)
					{
						next.item.AddValue(head.item);
						if (pickupsList != null)
						{
							pickupsList.Remove(linkedList2.head);
							Pickup item = head.item;
							if ((object)head.item != null)
							{
								item.linkedListNode = null;
								if ((object)PickupManager.Instance != null)
								{
									PickupManager.Instance.DespawnPickup(head.item);
									Pickup item2 = next.item;
									if ((object)next.item != null)
									{
										if (item2.value < combineThreshold)
										{
											goto IL_0321;
										}
										if (pickupsList != null)
										{
											pickupsList.Remove(next);
											if (pickupsList != null)
											{
												pickupsList.AddLast(next);
												goto IL_0321;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_02a3;
		IL_02a3:
		return (Pickup)(object)new NullReferenceException();
		IL_0321:
		if ((object)PickupManager.Instance != null)
		{
			object obj = default(object);
			GameObject newPickup = PickupManager.Instance.GetNewPickup(ePickup, (Vector3)(&obj));
			if ((object)newPickup != null)
			{
				Pickup component = newPickup.GetComponent<Pickup>();
				if (pickupsList != null)
				{
					LinkedListNode<object> linkedListNode = ((LinkedList<object>)(object)pickupsList).AddLast((object)component);
					if ((object)component != null)
					{
						component.linkedListNode = (LinkedListNode<Pickup>)(object)linkedListNode;
						return component;
					}
				}
			}
		}
		goto IL_02a3;
	}

	private void CombineOldestObjects()
	{
		LinkedList<Pickup> linkedList = pickupsList;
		LinkedListNode<Pickup> head = linkedList.head;
		LinkedListNode<Pickup> next = linkedList.head.Next;
		if (next != null)
		{
			next.item.AddValue(head.item);
			pickupsList.Remove(linkedList.head);
			Pickup item = head.item;
			item.linkedListNode = null;
			PickupManager.Instance.DespawnPickup(head.item);
			Pickup item2 = next.item;
			if (item2.value >= combineThreshold)
			{
				pickupsList.Remove(next);
				pickupsList.AddLast(next);
			}
		}
	}

	public void RemovePickup(Pickup pickup)
	{
		bool flag = ((LinkedList<object>)(object)pickupsList).Remove((object)pickup);
	}
}
