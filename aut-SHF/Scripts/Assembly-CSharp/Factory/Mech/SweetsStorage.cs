using System;
using Factory.FieldData;
using Factory.FieldObject;
using UnityEngine;

namespace Factory.Mech
{
	public class SweetsStorage : MechBase
	{
		public Vector2 medianPoint;

		private BillboardAnimationSpecificLayer layer1Pot;

		private BillboardAnimationSpecificLayer layer2Need;

		private BillboardAnimationSpecificLayer layer3Fuel;

		private int fuelGaugeSweetsStock;

		private eLuggage billboardSweetsId;

		public bool HasSweets => false;

		public eLuggage SweetsId
		{
			get
			{
				return default(eLuggage);
			}
			private set
			{
			}
		}

		private int SweetsStock
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private bool IsSweetsStockIsNotFull => false;

		public SweetsStorage(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public double GetSweets()
		{
			return 0.0;
		}

		public override void Update(double deltaTime)
		{
		}

		private bool IsSweets(eLuggage fromStrHasLuggageId)
		{
			return false;
		}

		private bool IsSameSweets(eLuggage fromStrHasLuggageId)
		{
			return false;
		}

		private void UpdateBillboardAnimation(bool updateSweets = false)
		{
		}

		public override bool IsInsertable(ILuggageCarrier fromCarrier, Structure to, out ILuggageCarrier toCarrier, out double luggageRate, out bool visible, out bool? cautionIcon, out Action<ILuggageCarrier> successCallback)
		{
			toCarrier = null;
			luggageRate = default(double);
			visible = default(bool);
			cautionIcon = null;
			successCallback = null;
			return false;
		}
	}
}
