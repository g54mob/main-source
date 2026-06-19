using System;
using Aggro.Core;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ContractShift
{
	[Serializable]
	public class Order
	{
		public ShiftOrderObject order;

		[Range(0f, 3f)]
		public int randomOrderIndex = 1;

		[Min(0f)]
		public int cardCount;

		[HideInInspector]
		public ContractObject owner;

		public bool isExplicitContract
		{
			get
			{
				if (owner != null)
				{
					return owner.type == ContractType.Explicit;
				}
				return false;
			}
		}

		public bool isRandomContract
		{
			get
			{
				if (owner != null)
				{
					return owner.type == ContractType.Random;
				}
				return false;
			}
		}

		private ValueDropdownList<ShiftOrderObject> ValueDropDownGetTypes()
		{
			if (owner == null)
			{
				return new ValueDropdownList<ShiftOrderObject>();
			}
			ValueDropdownList<ShiftOrderObject> valueDropdownList = new ValueDropdownList<ShiftOrderObject>();
			for (int i = 0; i < owner.orders.Length; i++)
			{
				ShiftOrderObject shiftOrderObject = owner.orders[i];
				valueDropdownList.Add(shiftOrderObject.name, shiftOrderObject);
			}
			return valueDropdownList;
		}

		private bool ValidateType(ShiftOrderObject order, ref string errorMessage)
		{
			if (owner == null)
			{
				errorMessage = "Owner Contract is null!";
				return false;
			}
			if (order == null)
			{
				errorMessage = "Null Order Object!";
				return false;
			}
			if (Array.IndexOf(owner.orders, order) < 0)
			{
				errorMessage = "Order object not part of Contract's orders!";
				return false;
			}
			return true;
		}
	}

	[Serializable]
	public class Inbound
	{
		[Min(1f)]
		public int bayCount = 1;

		[Min(1f)]
		public int boxCount = 3;

		[Tooltip("Normalized from start of the shift until the calculated last outbound truck.")]
		[Range(0f, 1f)]
		public float normalizedTime;
	}

	[Serializable]
	public class Outbound
	{
		[Min(1f)]
		public int bayCount = 1;

		[Range(1f, 20f)]
		public int boxCount = 3;

		[Min(0f)]
		public float secondsFromPrevious = 10f;
	}

	[Min(0f)]
	public float truckPatienceDuration = 90f;

	[Min(1f)]
	public int payOutAmount = 500;

	public Order[] orders = new Order[0];

	public Inbound[] inbound = new Inbound[0];

	public Outbound[] outbound = new Outbound[0];

	[HideInInspector]
	public ContractObject owner;

	public int GetInboundInventoryCount(float multiplier)
	{
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < this.inbound.Length; i++)
		{
			Inbound inbound = this.inbound[i];
			if (multiplier != 1f)
			{
				for (int j = 0; j < inbound.bayCount; j++)
				{
					num2 += (float)inbound.boxCount * multiplier;
					int num3 = Mathf.CeilToInt(num2);
					num2 -= (float)num3;
					num += num3;
				}
			}
			else
			{
				num += inbound.bayCount * inbound.boxCount;
			}
		}
		return num;
	}

	public int GetOutboundInventoryCount(float multiplier)
	{
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < this.outbound.Length; i++)
		{
			Outbound outbound = this.outbound[i];
			if (multiplier != 1f)
			{
				for (int j = 0; j < outbound.bayCount; j++)
				{
					num2 += (float)outbound.boxCount * multiplier;
					int num3 = Mathf.CeilToInt(num2);
					num2 -= (float)num3;
					num += num3;
				}
			}
			else
			{
				num += outbound.bayCount * outbound.boxCount;
			}
		}
		return num;
	}

	public int GetTotalPayout(float multiplier)
	{
		return Mathf.CeilToInt((float)payOutAmount * multiplier);
	}

	public int GetTotalPayout(float multiplier, int outboundCount)
	{
		return Mathf.Max(Mathf.RoundToInt(MathUtil.RoundToIncrement((float)payOutAmount * multiplier / (float)outboundCount, 2f)) * outboundCount, 2);
	}
}
