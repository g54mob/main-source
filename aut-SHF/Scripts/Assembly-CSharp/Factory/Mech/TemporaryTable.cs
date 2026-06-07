using System;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class TemporaryTable : MechBase
	{
		private Structure inputFromStr;

		public override bool HasToggleSwitch => false;

		public override bool HasRotateSwitch => false;

		public TemporaryTable(Structure[] structures)
			: base(null)
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

		public override void SwitchToggle()
		{
		}

		public override void SwitchRotate(StructureAddr addr)
		{
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
