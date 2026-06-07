using System;
using UnityEngine;

public class Holdable : MonoBehaviour
{
	[Serializable]
	public struct HoldableData
	{
		public string Type;

		public SDateTime Spawned;

		public float MiscValue;

		public float Worth;

		public HoldableData(Holdable h)
		{
			if (h == null)
			{
				Type = null;
				Spawned = default(SDateTime);
				MiscValue = 0f;
				Worth = 0f;
			}
			else
			{
				Type = h.Type.Replace("(Clone)", "");
				Spawned = h.Spawned;
				MiscValue = h.MiscValue;
				Worth = h.Worth;
			}
		}
	}

	public string Type;

	public Vector3 OffsetTranslation;

	public Vector3 OffsetRotation;

	public TableScript Parent;

	public Actor Holder;

	public bool HoldStraight = true;

	public bool HoldBoth;

	public Renderer[] Renderers;

	public SDateTime Spawned;

	public bool DestroyOnDespawn;

	public float MiscValue;

	public float Worth;

	public HoldableData Serialize()
	{
		return new HoldableData(this);
	}

	public void Deserialize(HoldableData data)
	{
		Spawned = data.Spawned;
		MiscValue = data.MiscValue;
		Worth = data.Worth;
	}

	public void DecoupleFromParent()
	{
		if (Parent != null)
		{
			Parent.DecoupleHoldable(this);
			Parent = null;
		}
		if (Holder != null)
		{
			Holder.LeaveItem(this);
		}
	}

	public void DestroyMe()
	{
		if (this != null && base.gameObject != null && ItemDispenser.Instance != null)
		{
			ItemDispenser.Instance.DestroyItem(this);
		}
	}

	public void SetUVX(float uvx)
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetFloat("_CutOff", uvx);
		Renderers[0].SetPropertyBlock(materialPropertyBlock);
	}

	public void RemoveActorChildren(Actor a)
	{
		for (int i = 0; i < Renderers.Length; i++)
		{
			Renderer renderer = Renderers[i];
			for (int j = 0; j < a.Children.Count; j++)
			{
				if (a.Children[j] == renderer)
				{
					a.Children.RemoveAt(j);
					break;
				}
			}
		}
	}
}
