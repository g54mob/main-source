using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Drifter Rig Event")]
public class DrifterRigItemEvent : ScriptableObject
{
	public delegate void Handler(DrifterRigItemEvent evt);

	public enum ID
	{
		SetItem = 0,
		ClearItem = 1
	}

	public enum Target
	{
		LeftFloater = 0,
		RightFloater = 1,
		LeftHip = 2,
		RightHip = 3
	}

	[Serializable]
	public struct ItemObject
	{
		public ItemProperties ItemProperties;

		public UnityEngine.Object Object;
	}

	[SerializeField]
	private ID _id;

	[SerializeField]
	private Target _target;

	[Header("Items")]
	[SerializeField]
	private UnityEngine.Object _empty;

	[SerializeField]
	private ItemObject[] _itemObjects;

	public ID Id => _id;

	public AnimationTools AnimationTools { get; private set; }

	public void Dispatch(AnimationTools animationTools)
	{
		if (animationTools.DrifterRigEvent != null)
		{
			AnimationTools = animationTools;
			AnimationTools.DrifterRigEvent.Invoke(this);
		}
	}

	public void ClearItem()
	{
		SetObject(_empty);
	}

	public void SetItem(ItemProperties itemProperties)
	{
		if (TryReturnObject(itemProperties, out var obj))
		{
			SetObject(obj);
		}
	}

	private void SetObject(UnityEngine.Object obj)
	{
		switch (_target)
		{
		case Target.LeftFloater:
			AnimationTools.SetLeftFloater(obj);
			break;
		case Target.RightFloater:
			AnimationTools.SetRightFloater(obj);
			break;
		case Target.LeftHip:
			AnimationTools.SetLeftHip(obj);
			break;
		case Target.RightHip:
			AnimationTools.SetRightHip(obj);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private bool TryReturnObject(ItemProperties itemProperties, out UnityEngine.Object obj)
	{
		ItemObject[] itemObjects = _itemObjects;
		for (int i = 0; i < itemObjects.Length; i++)
		{
			ItemObject itemObject = itemObjects[i];
			if (itemObject.ItemProperties == itemProperties)
			{
				obj = itemObject.Object;
				return obj != null;
			}
		}
		obj = null;
		return false;
	}
}
