using System.Xml.Linq;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class TrackSpawnedCraftRequirement : ContractRequirement
	{
		private CraftTracker _tracker;

		public override string DisplayValue
		{
			get
			{
				if (_tracker.IsDestroyed)
				{
					return "Destroyed";
				}
				return string.Empty;
			}
		}

		public bool IgnoreDestroyedCraft { get; set; }

		public ICraftNode SpawnedCraftNode => _tracker?.CraftNode;

		protected override ICraftNode CraftNodeOverride => _tracker.CraftNode;

		public TrackSpawnedCraftRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			string stringAttribute = xml.GetStringAttribute("payloadId");
			_tracker = new CraftTracker(base.Contract.ContractNumber, xml, stringAttribute);
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
			_tracker.OnFlightStart(flightContext, generateCraftTrackingId: true);
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			_tracker.SaveXml(base.Xml);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (!_tracker.IsTrackingCraft)
			{
				_tracker.StartTracking();
			}
			if (_tracker.IsTrackingCraft)
			{
				_tracker.Update();
				if (!IgnoreDestroyedCraft && _tracker.IsDestroyed)
				{
					base.OnFail = RequirementFailureType.Cancel;
				}
				if (_tracker.IsTrackingCraft)
				{
					if (!IgnoreDestroyedCraft)
					{
						return !_tracker.IsDestroyed;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
		}
	}
}
