using System;
using UnityEngine;

[Serializable]
public class Cost
{
	[SerializeField]
	private ResourceData resource;

	[SerializeField]
	private int amount;

	public ResourceData Resource
	{
		get
		{
			return resource;
		}
		set
		{
			resource = value;
		}
	}

	public int Amount
	{
		get
		{
			return amount;
		}
		set
		{
			amount = value;
		}
	}

	public Cost(ResourceData resource, int amount)
	{
		Resource = resource;
		Amount = amount;
	}
}
