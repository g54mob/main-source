using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CritterCatcher : CraftingBuilding, IMiniSimCritterPresenter
{
	private enum SlotState
	{
		None = 0,
		Bait = 1,
		Critter = 2
	}

	[Serializable]
	public struct BaitVisualSlot
	{
		public SpriteRenderer SR;

		public ColorReplacer colorReplacer;
	}

	[Serializable]
	public struct VivariumAnimal
	{
		public Transform transform;

		public VisualObjectSelector visualObjectSelector;
	}

	private SlotState[] previousSlotStates;

	public List<BaitVisualSlot> baitVisualSlots;

	public List<VivariumAnimal> animals;

	protected override void Awake()
	{
		base.Awake();
		previousSlotStates = new SlotState[animals.Count];
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		for (int i = 0; i < animals.Count; i++)
		{
			previousSlotStates[i] = SlotState.None;
			HideBait(i);
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		foreach (VivariumAnimal animal in animals)
		{
			animal.visualObjectSelector.HideObject();
		}
	}

	public void UpdateDisplayedObjects(DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer)
	{
		int num = Mathf.Min(animals.Count, containedObjectsBuffer.Length);
		for (int i = 0; i < num; i++)
		{
			VivariumAnimal vivariumAnimal = animals[i];
			ContainedObjectsBuffer containedObject = containedObjectsBuffer[i];
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObject.objectID, containedObject.variation);
			SlotState slotState = SlotState.None;
			if (objectInfo != null && objectInfo.objectID != ObjectID.None)
			{
				if (objectInfo.objectType == ObjectType.Critter)
				{
					slotState = SlotState.Critter;
					vivariumAnimal.visualObjectSelector.DisplayObject(objectInfo);
					HideBait(i);
					if (previousSlotStates[i] == SlotState.Bait)
					{
						AudioManager.Sfx(SfxID.ui_plop_1_01, Vector3.zero, 0.08f, 1f, 0.011f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
						AudioManager.Sfx(SfxTableID.critterMunchSfx, Vector3.zero);
						Manager.effects.PlayPuff(PuffID.LeafDebris, baitVisualSlots[i].SR.transform.position, 4);
					}
				}
				else
				{
					slotState = SlotState.Bait;
					vivariumAnimal.visualObjectSelector.HideObject();
					DisplayBait(i, containedObject);
				}
			}
			else
			{
				slotState = SlotState.None;
				vivariumAnimal.visualObjectSelector.HideObject();
				HideBait(i);
			}
			previousSlotStates[i] = slotState;
		}
		for (int j = num; j < animals.Count; j++)
		{
			previousSlotStates[j] = SlotState.None;
		}
	}

	public void DisplayBait(int index, ContainedObjectsBuffer containedObject)
	{
		BaitVisualSlot baitVisualSlot = baitVisualSlots[index];
		SpriteRenderer sR = baitVisualSlot.SR;
		ColorReplacer colorReplacer = baitVisualSlot.colorReplacer;
		ObjectID objectID = containedObject.objectID;
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject.objectData, getSmallIcon: true);
		sR.sprite = ((iconOverride != null) ? iconOverride : PugDatabase.GetObjectInfo(objectID, containedObject.variation)?.smallIcon);
		colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
		Manager.ui.ApplyAnyIconGradientMap(containedObject, sR);
	}

	private void HideBait(int index)
	{
		baitVisualSlots[index].SR.sprite = null;
	}

	public void UpdateSimulationPosition(int index, float3 position)
	{
		animals[index].transform.localPosition = position;
		animals[index].visualObjectSelector.DisplayOnGround(displayOnGround: true);
	}

	public void PlayAnimationForVisual(int index, int animationID, int orientationHash, bool flipX)
	{
		animals[index].visualObjectSelector.PlayAnimation(animationID, orientationHash);
		animals[index].visualObjectSelector.SetFlipped(flipX);
	}
}
