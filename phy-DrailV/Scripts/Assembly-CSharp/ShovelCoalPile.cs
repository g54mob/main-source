using System.Collections.Generic;
using DV.Simulation.Controllers;
using UnityEngine;

public class ShovelCoalPile : MonoBehaviour, ICoalPile
{
	[Tooltip("Whether this coal pile supplies infinite coal")]
	public bool isInfinite;

	public float coalChunkMass;

	private int validOverlapMask;

	private Collider shovelTrigger;

	private CoalPileSimController controller;

	private Dictionary<Collider, Shovel> knownShovels = new Dictionary<Collider, Shovel>();

	private void Awake()
	{
		validOverlapMask = LayerMask.GetMask("Grabbed_Item", "World_Item");
	}

	private void OnEnable()
	{
		shovelTrigger = GetComponent<Collider>();
		if (!isInfinite)
		{
			controller = TrainCar.Resolve(base.gameObject)?.SimController?.coalPile;
			if (controller == null)
			{
				Debug.LogError("Could not find CoalPileSimController");
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isInfinite || controller.CoalAvailable() != 0f)
		{
			int num = 1 << other.gameObject.layer;
			Shovel value;
			if (num == 0 || (num & validOverlapMask) != num)
			{
				Physics.IgnoreCollision(shovelTrigger, other);
			}
			else if (!knownShovels.TryGetValue(other, out value))
			{
				value = DealWithOverlap(other);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		Shovel shovel = DealWithOverlap(other);
		if (shovel != null && !isInfinite && controller.CoalAvailable() > 0f)
		{
			shovel.RequestSpawnCoal(this);
		}
	}

	private Shovel DealWithOverlap(Collider col)
	{
		if (!knownShovels.TryGetValue(col, out var value))
		{
			value = col.GetComponentInParent<Shovel>();
			if (value != null && value.shovelTip == col)
			{
				knownShovels[col] = value;
			}
			else
			{
				Physics.IgnoreCollision(shovelTrigger, col);
			}
		}
		return value;
	}

	public float CoalChunkMass()
	{
		if (isInfinite)
		{
			return coalChunkMass;
		}
		return controller.coalChunkMass;
	}

	public float CoalAvailable()
	{
		if (isInfinite)
		{
			return float.PositiveInfinity;
		}
		return controller.CoalAvailable();
	}

	public float SpaceForCoal()
	{
		if (isInfinite)
		{
			return float.PositiveInfinity;
		}
		return controller.SpaceForCoal();
	}

	public float TryAddCoal(float coalAmount)
	{
		if (isInfinite)
		{
			return coalAmount;
		}
		return controller.TryAddCoal(coalAmount);
	}

	public float TryRemoveCoal(float coalAmount)
	{
		if (isInfinite)
		{
			return coalAmount;
		}
		return controller.TryRemoveCoal(coalAmount);
	}
}
