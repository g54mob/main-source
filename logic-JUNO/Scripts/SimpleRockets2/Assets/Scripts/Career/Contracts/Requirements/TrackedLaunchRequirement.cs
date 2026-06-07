using System;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Ui;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class TrackedLaunchRequirement : ContractRequirement
	{
		private ButtonInformation _buttonInfo;

		private bool _craftMatches;

		private bool _customDescription = true;

		private int _nodeID = -1;

		public override ButtonInformation ButtonInfo
		{
			get
			{
				if (CanReset())
				{
					if (_buttonInfo == null)
					{
						_buttonInfo = new ButtonInformation("Track this craft", "Ui/Sprites/Flight/IconRetry");
					}
				}
				else
				{
					_buttonInfo = null;
				}
				return _buttonInfo;
			}
		}

		public override bool DefaultResetChildrenWhenNotPassing => false;

		public override RequirementVisibilityType DefaultVisibility => RequirementVisibilityType.HiddenWhenPassed;

		public override string DisplayValue
		{
			get
			{
				if (!_craftMatches)
				{
					return "Wrong Craft";
				}
				return string.Empty;
			}
		}

		public override string FlightDescription
		{
			get
			{
				if (!_customDescription)
				{
					return "This contract is assigned to other craft<br>Click the button to update it";
				}
				return base.Description;
			}
		}

		public TrackedLaunchRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_nodeID = xml.GetIntAttribute("nodeID", -1);
			if (string.IsNullOrWhiteSpace(base.Description))
			{
				base.Description = "Launch a new craft";
				_customDescription = false;
			}
		}

		public override void OnClick(Action refreshUI)
		{
			base.OnClick(refreshUI);
			if (CanReset())
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "Would you like to start tracking this craft instead?";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					base.Contract.ResetStatus();
					refreshUI?.Invoke();
				};
			}
		}

		public override void OnContractClosed(FlightStateData flightStateData)
		{
			base.OnContractClosed(flightStateData);
			StopTracking();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			StartTracking(flightContext);
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("nodeID", _nodeID);
		}

		public override void Validate(ValidationResult result)
		{
			if (base.Parent.Parent != null)
			{
				result.AddMessage("TrackedLaunch should always be the root requirement.");
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_craftMatches = _nodeID >= 0 && craftNode.InitialCraftNodeIds.Contains(_nodeID);
			if (_craftMatches && craftNode.IsDestroyed)
			{
				MarkAsFailed();
			}
			return _craftMatches;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_nodeID = -1;
			if (base.FlightContext != null)
			{
				StartTracking(base.FlightContext);
			}
		}

		private bool CanReset()
		{
			if (base.FlightContext.IsNewLaunch && !_craftMatches)
			{
				return !base.FlightContext.CraftNode.IsDestroyed;
			}
			return false;
		}

		private void StartTracking(IFlightContext flightContext)
		{
			if (_nodeID == -1)
			{
				if (flightContext.IsNewLaunch)
				{
					_nodeID = flightContext.CraftNode.NodeId;
				}
				return;
			}
			CraftNode craftNode = flightContext.FlightState.GetCraftNode((CraftNode x) => x.InitialCraftNodeIds.Contains(_nodeID));
			if (craftNode == null || craftNode.IsDestroyed)
			{
				base.Contract.RequiresReset = true;
			}
		}

		private void StopTracking()
		{
			_nodeID = -1;
		}
	}
}
