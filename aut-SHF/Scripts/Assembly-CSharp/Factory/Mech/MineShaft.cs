using System;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class MineShaft : MechBase
	{
		private double MineShaft_SpeedUp;

		private StructureAddr _inputBeltAddr;

		private static int _unitCounterThreshold;

		private bool lastLoopOnce;

		private double lastOperationStartTime;

		private double lastOperationEndTime;

		private double lastOperationDuration;

		public override eLuggage Product => default(eLuggage);

		private int UnitCounter
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override bool UseLuggageFilterIcon => false;

		public MineShaft(Structure[] structures)
			: base(null)
		{
		}

		private void PlayBillboardAnimation(bool init = false, bool loopOnce = false, bool counterOnly = false)
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

		private bool IsFilterOk(ILuggageCarrier carrier)
		{
			return false;
		}

		private void EnterCallback(ILuggageCarrier luggageCarrier)
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

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}

		public override void SetFilterLuggage(eLuggage luggage)
		{
		}

		public override void RestoreFilterLuggage()
		{
		}
	}
}
