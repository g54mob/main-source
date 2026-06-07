using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class PartCountRequirement : ContractRequirement, ISupportsPayload
	{
		public enum ComparisonType
		{
			Equal = 0,
			Less = 1,
			Greater = 2
		}

		private ComparisonType _comparisonType;

		private int _currentNum;

		private int _num;

		private PartCountRequirement _parent;

		private string _partId;

		private string _payloadId;

		private bool _requiresActive;

		private bool _requiresRecount;

		public override string DisplayValue => $"{_currentNum}";

		int ISupportsPayload.NumPayloadParts => _num;

		string ISupportsPayload.PayloadId => _payloadId;

		public string PayloadTrackingId { get; private set; }

		bool ISupportsPayload.RequiresPayload => !string.IsNullOrEmpty(_payloadId);

		public PartCountRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_num = xml.GetIntAttribute("num");
			_comparisonType = xml.GetEnumAttribute("op", ComparisonType.Equal);
			_payloadId = xml.GetStringAttribute("payloadId");
			_partId = xml.GetStringAttribute("partId");
			_requiresActive = xml.GetBoolAttribute("active");
			PayloadTrackingId = xml.GetStringAttribute("payloadTrackingId");
		}

		public bool IsTrackingPayload(string payloadTrackingId)
		{
			if (!string.IsNullOrEmpty(PayloadTrackingId))
			{
				return PayloadTrackingId == payloadTrackingId;
			}
			return false;
		}

		public override void OnFlightEnd()
		{
			base.FlightContext.CraftStructureChanged -= OnCraftStructureChanged;
			base.FlightContext.CraftChanged -= OnCraftChanged;
			base.OnFlightEnd();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			flightContext.CraftStructureChanged += OnCraftStructureChanged;
			flightContext.CraftChanged += OnCraftChanged;
			_requiresRecount = true;
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			_parent = GetParentRequirement<PartCountRequirement>();
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("payloadTrackingId", PayloadTrackingId);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (_parent != null)
			{
				_parent.IsBypassed = true;
				if (_payloadId == _parent._payloadId)
				{
					PayloadTrackingId = _parent.PayloadTrackingId;
				}
			}
			if (_requiresRecount)
			{
				_requiresRecount = false;
				TagPayloadParts(base.FlightContext);
				_currentNum = base.FlightContext.CountCraftParts(_partId, PayloadTrackingId, _requiresActive);
			}
			else if (_requiresActive)
			{
				_currentNum = base.FlightContext.CountCraftParts(_partId, PayloadTrackingId, activated: true);
			}
			return _comparisonType switch
			{
				ComparisonType.Greater => _currentNum >= _num, 
				ComparisonType.Less => _currentNum < _num, 
				_ => _currentNum == _num, 
			};
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_currentNum = 0;
			PayloadTrackingId = null;
			_requiresRecount = true;
		}

		private void OnCraftChanged()
		{
			_requiresRecount = true;
		}

		private void OnCraftStructureChanged()
		{
			_requiresRecount = true;
		}

		private void TagPayloadParts(IFlightContext flightContext)
		{
			if (string.IsNullOrEmpty(_payloadId) || !string.IsNullOrEmpty(PayloadTrackingId) || _parent != null)
			{
				return;
			}
			PayloadTrackingId = Guid.NewGuid().ToString();
			List<PartData> list = new List<PartData>();
			for (int i = 0; i < _num; i++)
			{
				IPartScript payloadPart = flightContext.CraftNode.CraftScript.GetPayloadPart(_payloadId, base.Contract.ContractNumber, null);
				if (payloadPart == null)
				{
					break;
				}
				payloadPart.Data.Payload.PayloadTrackingId = PayloadTrackingId;
				list.Add(payloadPart.Data);
			}
			if (list.Count == _num)
			{
				return;
			}
			Debug.Log($"Could not find enough payload parts in the craft for contract {base.Contract.ContractNumber}.");
			foreach (PartData item in list)
			{
				item.Payload.PayloadTrackingId = null;
			}
		}
	}
}
