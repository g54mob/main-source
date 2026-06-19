using OUSystems.Basics.DataStructures;
using UnityEngine;

public abstract class ItemStackAnimator : MonoBehaviour
{
	private ItemStack _itemStack;

	public void Initiate(ItemStack item)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public void OnUpdate(ValueUpdateData<int> update)
	{
	}

	public abstract void Grow();

	public abstract void Shrink();

	public static string GetHierarchyPath(GameObject gameObject)
	{
		return null;
	}
}
