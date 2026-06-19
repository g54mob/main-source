using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class Terrarium : Chest, IMiniSimCritterPresenter
{
	[Serializable]
	public struct VivariumAnimal
	{
		public Transform transform;

		public VisualObjectSelector visualObjectSelector;
	}

	public List<VivariumAnimal> animals;

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
			ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[i];
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObjectsBuffer2.objectID, containedObjectsBuffer2.variation);
			if (objectInfo != null && objectInfo.objectID != ObjectID.None)
			{
				vivariumAnimal.visualObjectSelector.DisplayObject(objectInfo);
			}
			else
			{
				vivariumAnimal.visualObjectSelector.HideObject();
			}
		}
	}

	public void UpdateSimulationPosition(int index, float3 position)
	{
		animals[index].transform.localPosition = position;
	}

	public void PlayAnimationForVisual(int index, int animationID, int orientationHash, bool flipX)
	{
		animals[index].visualObjectSelector.PlayAnimation(animationID, orientationHash);
		animals[index].visualObjectSelector.SetFlipped(flipX);
	}
}
