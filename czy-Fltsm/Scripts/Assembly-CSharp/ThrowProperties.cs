using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProperties : IDisposable
{
	public List<Item> Items = new List<Item>();

	public string Name;

	public FlotsamProperties FlotsamProperties;

	public Vector3 StartPosition;

	public Vector3 TargetPosition;

	public Transform TargetTransform;

	public float Duration = 0.5f;

	public bool VisualsOnly = true;

	public bool ScaleUp;

	public Quaternion Rotation;

	public float MaximumScale = 1.2f;

	public float MinimumScale = 0.2f;

	private static Queue<ThrowProperties> _instances = new Queue<ThrowProperties>();

	private ThrowProperties()
	{
	}

	public static ThrowProperties ReturnTransferProperties(Item item, Inventory targetInventory, SubInventoryType targetSubInventory = SubInventoryType.Storage)
	{
		ThrowProperties throwProperties = ReturnInstance();
		throwProperties.Items.Add(item);
		throwProperties.Name = item.Properties.name;
		throwProperties.FlotsamProperties = item.Properties.FlotsamProperties;
		throwProperties.ScaleUp = targetInventory.Type != InventoryType.Agent;
		throwProperties.StartPosition = item.Owner.transform.position;
		throwProperties.TargetTransform = targetInventory.ReturnDropOffTarget(targetSubInventory);
		throwProperties.Rotation = UnityEngine.Random.rotation;
		return throwProperties;
	}

	public void Dispose()
	{
		_instances.Enqueue(this);
	}

	private static ThrowProperties ReturnInstance()
	{
		if (!_instances.TryDequeue(out var result))
		{
			return new ThrowProperties();
		}
		return result;
	}
}
