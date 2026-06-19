using System;
using System.Collections.Generic;
using OUSystems.Basics.UI;
using UnityEngine;

public class BuildingDeconstructable : MonoBehaviour
{
	public Building Building;

	public BoxCollider2D AreaBox;

	public GameObject TargetGameObject;

	private List<Func<IEnumerable<ItemStack>>> _getItems;

	[SerializeField]
	private HoverListener _hoverListener;

	private bool _hovered;

	public bool NoDestroy;

	public void Initiate(Building building, GameObject targetGameObject)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetHoverListener(HoverListener hoverListener)
	{
	}

	public void SetHovered(bool hovered)
	{
	}

	public void DestroyIntoItems(GameObject destroyedObject, Vector2 centerPosition, Vector2 areaSize, IEnumerable<ItemStack> items)
	{
	}

	public void AddDropItemsGetter(Func<IEnumerable<ItemStack>> getItemsFunc)
	{
	}

	public bool TryDeconstruct()
	{
		return false;
	}
}
