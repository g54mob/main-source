using System;
using Factory.FieldData;

namespace Factory.Mech
{
	public class TrashCan : MechBase
	{
		public TrashCan(Structure[] structures)
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

		private void EnterCallback(ILuggageCarrier luggageCarrier)
		{
		}

		private void PlayBillboardAnimation(bool play, bool? loopOnce = null, float? specificRate = null)
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
