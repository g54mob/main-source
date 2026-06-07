using System;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Ui;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class PayloadRequirement : ContractRequirement, ISupportsPayload
	{
		public enum DestroyOnCompleteType
		{
			None = 0,
			Immediately = 1,
			ExitFlight = 2
		}

		public enum TrackingMode
		{
			Launch = 0,
			Recover = 1
		}

		private bool _allowWarp;

		private ButtonInformation _buttonInfo;

		private DestroyOnCompleteType _destroyCraftOnComplete;

		private TrackingMode _mode;

		private string _payloadName;

		private CraftTracker _tracker;

		public override ButtonInformation ButtonInfo
		{
			get
			{
				if (IsPayloadLost)
				{
					if (_buttonInfo == null)
					{
						_buttonInfo = new ButtonInformation("Payload is missing", "Ui/Sprites/Menu/IconExclamation");
					}
				}
				else
				{
					_buttonInfo = null;
				}
				return _buttonInfo;
			}
		}

		public override string DisplayValue
		{
			get
			{
				if (_tracker.IsDestroyed)
				{
					return "Destroyed";
				}
				if (!_tracker.IsTrackingPayload)
				{
					return "Payload is missing";
				}
				return "Nominal";
			}
		}

		public bool IsTracking => _tracker.IsTrackingPayload;

		public int NumPayloadParts
		{
			get
			{
				if (!IsTracking)
				{
					return 1;
				}
				return 0;
			}
		}

		public IPartScript Part => _tracker.Part;

		public string PayloadId => _tracker.PayloadId;

		public bool RequiresPayload => true;

		protected override ICraftNode CraftNodeOverride => _tracker.CraftNode;

		private bool IsPayloadLost
		{
			get
			{
				if (!string.IsNullOrEmpty(_tracker.PayloadId) && _tracker.PartTrackingId != null && _tracker.CraftNode?.CraftScript != null && _tracker.Part == null)
				{
					return !base.FlightContext.IsNewLaunch;
				}
				return false;
			}
		}

		public PayloadRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_destroyCraftOnComplete = xml.GetEnumAttribute("destroyCraftOnComplete", DestroyOnCompleteType.None);
			_payloadName = xml.Attribute("payloadName").Value;
			_mode = xml.GetEnumAttribute("mode", TrackingMode.Launch);
			_allowWarp = xml.GetBoolAttribute("allowWarp");
			string value = xml.Attribute("payloadId").Value;
			_tracker = new CraftTracker(base.Contract.ContractNumber, xml, value);
			if (string.IsNullOrWhiteSpace(base.Description) && _mode == TrackingMode.Launch)
			{
				base.Description = "Launch with " + _payloadName;
			}
			if (_mode == TrackingMode.Recover && (string.IsNullOrWhiteSpace(_tracker.CraftTrackingId) || string.IsNullOrWhiteSpace(PayloadId)))
			{
				throw new ContractException("Payload requirement must have a craftTrackingId and payloadId when set to Recover mode.");
			}
		}

		public override string CanWarp()
		{
			if (!_allowWarp && _tracker != null && _tracker.IsTrackingPayload)
			{
				ICraftNode craftNode = _tracker.CraftNode;
				if (craftNode != null && craftNode.IsLoadedInGameView)
				{
					return "Cannot warp while carrying this payload.";
				}
			}
			return null;
		}

		public bool IsTrackingPayload(string payloadTrackingId)
		{
			return _tracker.PartTrackingId == payloadTrackingId;
		}

		public override void OnClick(Action refreshUI)
		{
			base.OnClick(refreshUI);
			if (!IsPayloadLost)
			{
				return;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "We can't find the payload part. Would you like me to check your current craft for it?";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				_tracker.SetCraftNode(base.FlightContext.CraftNode);
				if (_tracker.Part != null)
				{
					Game.Instance.UserInterface.CreateMessageDialog("We found it! Please, carry on with your rocket science.");
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog("Sadly, we could not find the payload part in this craft.");
				}
				refreshUI?.Invoke();
			};
		}

		public override void OnContractClosed(FlightStateData flightStateData)
		{
			base.OnContractClosed(flightStateData);
			_tracker.StopTracking();
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			_tracker.OnFlightEnd();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			_tracker.OnFlightStart(flightContext, _mode == TrackingMode.Recover || (_mode == TrackingMode.Launch && flightContext.IsNewLaunch));
			if (_mode == TrackingMode.Launch)
			{
				if (!_tracker.IsTrackingPayload)
				{
					base.Contract.RequiresReset = true;
				}
				else if (_tracker.IsDestroyed)
				{
					base.Contract.Status = ContractStatus.Terminated;
				}
			}
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			_tracker.SaveXml(base.Xml);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (_mode == TrackingMode.Recover && !_tracker.IsTrackingCraft)
			{
				_tracker.StartTracking();
			}
			_tracker.Update();
			if (_tracker.IsDestroyed)
			{
				MarkAsFailed();
				base.Contract.Status = ContractStatus.Terminated;
			}
			if (_tracker.IsTrackingPayload)
			{
				return !_tracker.IsDestroyed;
			}
			return false;
		}

		protected override void OnStatusChanged()
		{
			base.OnStatusChanged();
			if (base.Status == RequirementStatus.Complete && _tracker.CraftNode != null && !_tracker.CraftNode.IsPlayer)
			{
				if (_destroyCraftOnComplete == DestroyOnCompleteType.ExitFlight)
				{
					_tracker.CraftNode.DestroyOnExitFlightScene = true;
				}
				else if (_destroyCraftOnComplete == DestroyOnCompleteType.Immediately)
				{
					CraftNode obj = _tracker.CraftNode as CraftNode;
					obj.Enabled = false;
					obj.DestroyCraft();
				}
			}
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_tracker.ResetStatus();
		}
	}
}
