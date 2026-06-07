using System;
using UnityEngine;

[Serializable]
public class BuildSlots
{
	public Transform Parent;

	public BuildSlot[] Slots;

	private Transform _child;

	private float _progress;

	public void Attach(Transform transform)
	{
		_child = transform;
		transform.SetParent(Parent, worldPositionStays: true);
		SetProgress(_progress);
	}

	public void SetProgress(float progress)
	{
		_progress = progress;
		if (!(_child == null) && Slots.Length != 0)
		{
			int num = 0;
			for (int i = 0; i < Slots.Length && !(Slots[i].Threshold > progress); i++)
			{
				num = i;
			}
			Slots[num].TransformData.Apply(_child);
		}
	}

	public void Detach(Transform newParent)
	{
		if (_child == null)
		{
			Debug.LogWarning("Detach was called on BuildSlots when no Child was present.");
			return;
		}
		_child.SetParent(newParent, worldPositionStays: true);
		_child.localScale = Vector3.one;
		_child.localRotation = Quaternion.identity;
		_child = null;
	}

	public void FillTransforms()
	{
		if (!(Parent == null))
		{
			Slots = new BuildSlot[Parent.childCount];
			for (int num = Parent.childCount - 1; num >= 0; num--)
			{
				Transform child = Parent.GetChild(num);
				Slots[num] = new BuildSlot(0f, new TransformData(child.localPosition, child.eulerAngles, child.localScale));
				UnityEngine.Object.DestroyImmediate(child.gameObject);
			}
			PrefabHelper.SavePrefab();
		}
	}
}
