using System;
using Factory.FieldData;
using Models;
using UnityEngine;

namespace Factory.Mech
{
	public class Copier : MechBase
	{
		private int outMain;

		private int outSub;

		private StructureAddr inputBeltAddr;

		private Structure fromStr;

		private Vector2 effectOffsetXY;

		private readonly Vector3 medianPoint;

		private Vector3 copyLuggagePoint;

		private bool Copier_Color_Tech;

		private eLuggage product;

		public override double outputPortUtilizationAverageMain => 0.0;

		public override double outputPortUtilizationAverageSub => 0.0;

		public override eLuggage Product => default(eLuggage);

		public override bool HasToggleSwitch => false;

		public Copier(Structure[] structures)
			: base(null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void _UpdateCircuitData()
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override void Update(double deltaTime)
		{
		}

		private void PrepareMechView()
		{
		}

		private void PlayBillboardAnimationAndUpdateView(bool play)
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

		public override string ToDump()
		{
			return null;
		}
	}
}
