using System.Collections;
using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Go through steps of item placement tutorial")]
[UnitTitle("Place item")]
[UnitCategory("Interaction")]
public class ItemPlacingUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput grabTrigger;

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput messagePlace;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput messageRotate;

	protected override void Definition()
	{
		grabTrigger = ControlOutput("Grabbed");
		targetItem = ValueInput<GameObject>("Item", null);
		messagePlace = ValueInput<string>("Place msg.", null);
		messageRotate = ValueInput<string>("Rotete msg.", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
		Requirement(targetItem, inputTrigger);
	}

	private IEnumerator Routine(Flow flow)
	{
		flow.GetValue<GameObject>(targetItem).GetComponentInChildren<InventoryItemSpec>();
		bool shownFloatie = false;
		string value = flow.GetValue<string>(messagePlace);
		if (!string.IsNullOrEmpty(value))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(value, null);
			shownFloatie = true;
		}
		string message2 = flow.GetValue<string>(messageRotate);
		bool done = false;
		yield return WaitFor.EndOfFrame;
		ItemPlacerNonVr itemPlacer = SingletonBehaviour<TutorialHelper>.Instance.NonVRGrab.GetComponentInChildren<ItemPlacerNonVr>();
		itemPlacer.ItemPlacementStarted -= OnItemPlacementStarted;
		itemPlacer.ItemPlacementStarted += OnItemPlacementStarted;
		while (!done)
		{
			yield return null;
		}
		yield return grabTrigger;
		void OnItemPlacementFinished(ItemBase itemToPlace, bool success, GameObject targetContainer)
		{
			if (success && targetContainer == null)
			{
				itemPlacer.ItemPlacementFinished -= OnItemPlacementFinished;
				if (shownFloatie)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
					shownFloatie = false;
				}
				done = true;
			}
		}
		void OnItemPlacementStarted(ItemBase itemToPlace, bool success, GameObject targetContainer)
		{
			if (success)
			{
				if (shownFloatie)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
					shownFloatie = false;
				}
				if (!string.IsNullOrEmpty(message2))
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message2, null);
					shownFloatie = true;
				}
				itemPlacer.ItemPlacementStarted -= OnItemPlacementStarted;
				itemPlacer.ItemPlacementStarted -= OnItemPlacementFinished;
				itemPlacer.ItemPlacementFinished += OnItemPlacementFinished;
			}
		}
	}
}
