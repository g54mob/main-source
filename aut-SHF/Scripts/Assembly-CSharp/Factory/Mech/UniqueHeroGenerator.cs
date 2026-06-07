using System;
using System.Collections.Generic;
using Factory.FieldData;
using Factory.FieldObject;
using Models;

namespace Factory.Mech
{
	public class UniqueHeroGenerator : MechBase
	{
		public enum State
		{
			need = 0,
			failure = 1,
			dead = 2,
			success = 3
		}

		private State state;

		private Dictionary<State, string> stateName;

		private int outMain;

		private int outSub;

		private StructureAddr inputBeltAddr;

		private eMachine _machine;

		private eLuggage inputUnit;

		private eLuggage generateUnit;

		private eLuggage generateUnitFailure;

		private LuggageFlag generateUnitFailureFlag;

		private double inputUnitDeathRateDown;

		private double SwordOfChoice_SpeedUp;

		private eLuggage product;

		private State lastAnimeState;

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

		private int UnitCounterThreshold => 0;

		private double SwordOfChoice_RateDown => 0.0;

		public override double outputPortUtilizationAverageMain => 0.0;

		public override double outputPortUtilizationAverageSub => 0.0;

		public override eLuggage Product => default(eLuggage);

		public override bool HasToggleSwitch => false;

		public UniqueHeroGenerator(Structure[] structures)
			: base(null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void _UpdatePortAddrs()
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

		public override void Update(double deltaTime)
		{
		}

		private void EnterCallback(ILuggageCarrier luggageCarrier)
		{
		}

		private void PlayBillboardAnimation()
		{
		}

		public override void SwitchToggle()
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
