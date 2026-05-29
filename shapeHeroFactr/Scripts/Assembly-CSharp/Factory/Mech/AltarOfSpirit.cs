using System;
using Factory.FieldData;
using Factory.FieldObject;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Factory.Mech
{
	public class AltarOfSpirit : MechBase
	{
		public class StateInfo
		{
			public FactoryContext.AltarOfSpiritType type;

			public eLuggage luggage;

			public double speed;

			public int energy;

			public Structure structure;
		}

		public Vector2 medianPoint;

		private double lastProductionTime;

		private StateInfo _stateInfo;

		private SpiritCounterCell _spiritCounterCell;

		private Image _spiritCounterCellIcon;

		private bool lastLoopOnce;

		private double lastOperationStartTime;

		private double lastOperationEndTime;

		private double lastOperationDuration;

		private bool HasSpiritKey => false;

		private bool IsProcessing => false;

		public override double FixedProductionTime => 0.0;

		public AltarOfSpirit(Structure[] structures)
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

		private void EnterCallback(ILuggageCarrier luggageCarrier)
		{
		}

		private bool IsOkCategory(Luggage fromStrLuggage)
		{
			return false;
		}

		private void PlayBillboardAnimation(bool init = false, bool loopOnce = false)
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

		public override string ToDump()
		{
			return null;
		}
	}
}
