using System;
using System.Collections.Generic;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Goal : MechBase
	{
		private readonly HashSet<ArrivePair> goalPairSet;

		private bool _originalPortal;

		private bool Goal_OriginalPortalOnly;

		public Goal(Structure[] structures)
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

		public bool CheckGoalLuggage(eLuggage luggageID, StructureAddr mechAddr)
		{
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
