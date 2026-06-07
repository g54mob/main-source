using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace ModApi.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Payload")]
	public class PayloadData : PartModifierData<PayloadScript>, IPayload
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _contractNumber;

		[DesignerPropertySpinner(Label = "Contract", NeverSerialize = true, PreserveState = false, Order = 7, Tooltip = "Normally Auto is fine, but if you are attempting to complete multiple contracts at the same time with the same type of payload, then it might be necessary to manually link specific contracts with specific payloads.")]
		private string _contractNumberString = "0";

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Label = "This payload is not connected to the craft.", Tooltip = "Disconnected parts do not count for contracts.")]
		private string _disconnectedWarning = string.Empty;

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Label = "Payload Count", Tooltip = "The number of payloads connected to this craft that have been explicitly assigned to this contract.")]
		private string _payloadCount = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _payloadId;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _payloadTrackingId;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _setCraftTrackingIdOnActive;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _setCraftNameOnActive;

		public int ContractNumber
		{
			get
			{
				return _contractNumber;
			}
			set
			{
				_contractNumber = value;
			}
		}

		public string PayloadId
		{
			get
			{
				return _payloadId;
			}
			set
			{
				_payloadId = value;
			}
		}

		public string PayloadTrackingId
		{
			get
			{
				return _payloadTrackingId;
			}
			set
			{
				_payloadTrackingId = value;
			}
		}

		public string CraftName => _setCraftNameOnActive;

		public string CraftTrackingId => _setCraftTrackingIdOnActive;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			if (Game.Instance.GameState.Validator.IsCareerMode)
			{
				_contractNumberString = _contractNumber.ToString();
				d.OnVisibilityRequested(() => _contractNumberString, (bool x) => _payloadId != null);
				Dictionary<int, string> map = Game.Instance.GameState.Career.GetContractNamesAndIDsForPayloadId(_payloadId);
				d.OnSpinnerValuesRequested(() => _contractNumberString, delegate(List<string> list)
				{
					list.Add("0");
					foreach (int key in map.Keys)
					{
						list.Add(key.ToString());
					}
				});
				d.OnPropertyChanged(() => _contractNumberString, delegate(string newVal, string oldVal)
				{
					_contractNumber = int.Parse(newVal);
					d.Manager.Flyout.RefreshUI();
				});
				d.OnValueLabelRequested(() => _contractNumberString, (string x) => (_contractNumber == 0 || !map.ContainsKey(_contractNumber)) ? "Auto" : $"{map[_contractNumber]}#{_contractNumber}");
				d.OnVisibilityRequested(() => _disconnectedWarning, (bool x) => base.Part.PartScript.Disconnected);
				d.OnVisibilityRequested(() => _payloadCount, (bool x) => _contractNumber > 0);
				d.OnValueLabelRequested(() => _payloadCount, delegate
				{
					CountPayloads();
					return _payloadCount;
				});
			}
			else
			{
				d.OnVisibilityRequested(() => _contractNumberString, (bool x) => false);
			}
		}

		private void CountPayloads()
		{
			List<PayloadData> modifiers = base.Part.PartScript.CraftScript.Data.Assembly.GetModifiers<PayloadData>();
			_payloadCount = modifiers.Count((PayloadData x) => x.ContractNumber == _contractNumber && !x.Part.PartScript.Disconnected).ToString();
		}
	}
}
