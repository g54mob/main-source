using System;
using System.Collections.Generic;
using Factory.FieldData;
using Factory.FieldObject;

namespace Factory.Mech
{
	public class Repainter : MechBase
	{
		private readonly eSecondaryMachineCategory _secondaryMachineCategory;

		private Structure fromStr;

		private int materialCount;

		private eLuggage product;

		public override double Efficiency => 0.0;

		public override eLuggage Product => default(eLuggage);

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override bool IsSerialize => false;

		public Repainter(Structure[] structures)
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

		public override void Update(double deltaTime)
		{
		}

		private eLuggage SearchRepainterBlueprint(Luggage input)
		{
			return default(eLuggage);
		}

		public override List<eLuggage> GetFilterLuggageList()
		{
			return null;
		}

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}

		public override bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
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
