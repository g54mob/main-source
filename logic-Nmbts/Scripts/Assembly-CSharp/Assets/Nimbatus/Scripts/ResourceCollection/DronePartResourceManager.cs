using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.ResourceCollection
{
	public class DronePartResourceManager
	{
		private readonly List<IHasResources> _parts;

		private float _amount;

		private float _capacity;

		private readonly EResourceType _resourceType;

		public DronePartResourceManager(EResourceType resourceType)
		{
			_resourceType = resourceType;
			_parts = new List<IHasResources>();
			Reset();
		}

		public void Reset()
		{
			_amount = 0f;
			_capacity = 0f;
			_parts.Clear();
		}

		public void Update()
		{
			float num = 0f;
			float num2 = 0f;
			foreach (IHasResources part in _parts)
			{
				float num3 = Mathf.Min(part.GetResourceCapacity(_resourceType) - part.GetResourceAmount(_resourceType), part.GetRechargePerSecond(_resourceType) * Time.deltaTime);
				part.SetResourceAmount(_resourceType, num3 + part.GetResourceAmount(_resourceType));
				num += part.GetResourceAmount(_resourceType);
				num2 += part.GetResourceCapacity(_resourceType);
			}
			_capacity = num2;
			_amount = num;
		}

		public void RegisterPart(IHasResources part)
		{
			if (!_parts.Contains(part))
			{
				_parts.Add(part);
			}
		}

		public void UnregisterPart(IHasResources part, bool destroyed = true)
		{
			if (_parts.Contains(part))
			{
				_parts.Remove(part);
			}
		}

		public bool HasResource(float amount)
		{
			if (_amount >= amount)
			{
				return true;
			}
			return false;
		}

		public void UseResourceFromParts(float amount)
		{
			float amount2 = _amount;
			float num = Mathf.Max(_amount - amount, 0f);
			float num2 = Mathf.Max(amount2 - num, 0f);
			foreach (IHasResources part in _parts)
			{
				float resourceAmount = part.GetResourceAmount(_resourceType);
				float num3 = Mathf.Min(resourceAmount, num2);
				num2 -= num3;
				part.SetResourceAmount(_resourceType, resourceAmount - num3);
				if (num2 <= 0f)
				{
					break;
				}
			}
			_amount = num;
		}

		public void AddResourceToParts(float amount)
		{
			float num = Math.Min(amount, _capacity - _amount);
			float amount2 = Mathf.Min(_capacity, _amount + num);
			foreach (IHasResources part in _parts)
			{
				float num2 = Mathf.Min(part.GetResourceCapacity(_resourceType) - part.GetResourceAmount(_resourceType), num);
				num -= num2;
				part.SetResourceAmount(_resourceType, part.GetResourceAmount(_resourceType) + num2);
				if (num <= 0f)
				{
					break;
				}
			}
			_amount = amount2;
		}

		public bool HasCapacity(float collectAmount)
		{
			return _capacity - _amount > 0f;
		}
	}
}
