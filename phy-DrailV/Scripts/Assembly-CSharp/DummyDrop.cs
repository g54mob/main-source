using System.Collections;
using System.Linq;
using Bolt;
using DV.CabControls;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Adds all of the items to a given container item")]
[UnitCategory("Items")]
[UnitTitle("Dummy Drop")]
[TypeIcon(typeof(BoxCollider))]
public class DummyDrop : Unit
{
	public enum DisposalMethod
	{
		Destroy = 0,
		Disable = 1
	}

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput originalObjectReference;

	[DoNotSerialize]
	public ValueInput disposalMethod;

	[DoNotSerialize]
	public ValueInput dummyObjectReference;

	[DoNotSerialize]
	public ValueInput targetTransformReference;

	[DoNotSerialize]
	public ValueInput durationValue;

	[DoNotSerialize]
	public ValueInput soundPlayStart;

	[DoNotSerialize]
	public ValueInput soundPlayEnd;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		originalObjectReference = ValueInput<GameObject>("Original", null);
		disposalMethod = ValueInput("Disposal", DisposalMethod.Destroy);
		dummyObjectReference = ValueInput<GameObject>("Dummy", null);
		targetTransformReference = ValueInput<GameObject>("Target", null);
		durationValue = ValueInput("Duration", 1f);
		soundPlayStart = ValueInput<AudioClip>("Sound Start", null);
		soundPlayEnd = ValueInput<AudioClip>("Sound End", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(originalObjectReference);
		DisposalMethod value2 = flow.GetValue<DisposalMethod>(disposalMethod);
		GameObject dummyObject = flow.GetValue<GameObject>(dummyObjectReference);
		GameObject targetObject = flow.GetValue<GameObject>(targetTransformReference);
		float duration = flow.GetValue<float>(durationValue);
		AudioClip value3 = flow.GetValue<AudioClip>(soundPlayStart);
		AudioClip soundEnd = flow.GetValue<AudioClip>(soundPlayEnd);
		if (!value || !dummyObject || !targetObject)
		{
			Debug.LogError("One or more references are not assigned, skipping.");
			yield return doneTrigger;
			yield break;
		}
		Vector3 startingPosition = value.transform.position;
		Quaternion startingRotation = value.transform.rotation;
		ItemBase component = value.GetComponent<ItemBase>();
		if ((bool)component && (bool)component.InventorySpecs)
		{
			component.InventorySpecs.BelongsToPlayer = false;
		}
		if ((bool)component && value2 != DisposalMethod.Destroy && SingletonBehaviour<StorageController>.Instance.StorageWorld.ContainsItem(component))
		{
			SingletonBehaviour<StorageController>.Instance.StorageWorld.RemoveItem(component);
		}
		int num = SingletonBehaviour<Inventory>.Instance.IndexOf(value);
		if (num >= 0)
		{
			if (SingletonBehaviour<Inventory>.Instance.GetSlotLockState(num))
			{
				SingletonBehaviour<Inventory>.Instance.ToggleSlotLock(num);
			}
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(value);
		}
		AItemContainer component2 = value.GetComponent<AItemContainer>();
		if ((bool)component2)
		{
			for (int i = 0; i < component2.Capacity; i++)
			{
				if (!component2[i])
				{
					continue;
				}
				SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(component2[i]);
				if (value2 != DisposalMethod.Destroy)
				{
					ItemBase component3 = component2[i].GetComponent<ItemBase>();
					if ((bool)component3 && SingletonBehaviour<StorageController>.Instance.StorageWorld.ContainsItem(component3))
					{
						SingletonBehaviour<StorageController>.Instance.StorageWorld.RemoveItem(component3);
					}
				}
			}
		}
		if (value2 == DisposalMethod.Destroy)
		{
			if ((bool)component2)
			{
				for (int j = 0; j < component2.Capacity; j++)
				{
					if ((bool)component2[j])
					{
						component2.RemoveItem(component2[j], activateItem: false, dropItem: false);
						Object.Destroy(component2[j]);
					}
				}
			}
			Object.Destroy(value);
		}
		else
		{
			value.SetActive(value: false);
		}
		dummyObject.SetActive(value: true);
		dummyObject.transform.position = startingPosition;
		dummyObject.transform.rotation = startingRotation;
		if (value3 != null)
		{
			value3.Play(startingPosition);
		}
		Collider[] colliders = (from c in dummyObject.GetComponentsInChildren<Collider>()
			where c.enabled
			select c).ToArray();
		Collider[] array = colliders;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			array[num2].enabled = false;
		}
		for (float t = 0f; t < 1f; t += Time.deltaTime / duration)
		{
			float t2 = 1f - Mathf.Pow(1f - t, 2f);
			dummyObject.transform.position = Vector3.Lerp(startingPosition, targetObject.transform.position, t2);
			dummyObject.transform.rotation = Quaternion.Slerp(startingRotation, targetObject.transform.rotation, t2);
			yield return null;
		}
		dummyObject.transform.position = targetObject.transform.position;
		dummyObject.transform.rotation = targetObject.transform.rotation;
		if (soundEnd != null)
		{
			soundEnd.Play(targetObject.transform.position);
		}
		array = colliders;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			array[num2].enabled = true;
		}
		yield return doneTrigger;
	}
}
