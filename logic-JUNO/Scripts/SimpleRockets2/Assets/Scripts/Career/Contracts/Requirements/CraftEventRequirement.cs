using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Sim;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class CraftEventRequirement : ContractRequirement
	{
		public enum EventType
		{
			Destroyed = 0,
			Docked = 1,
			Explosion = 2
		}

		private double _accumulatedPower;

		private bool _complete;

		private string _displayValue;

		private string _dockedCraftTrackingId;

		private EventType _event;

		private float? _power;

		private CraftTracker _tracker;

		public override string DisplayValue => _displayValue;

		public CraftEventRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_event = xml.GetEnumAttribute("event", EventType.Destroyed);
			_power = xml.GetFloatAttributeOrNull("power");
			_dockedCraftTrackingId = xml.GetStringAttribute("dockedCraftTrackingId");
			_tracker = new CraftTracker(contract.ContractNumber, xml);
			_tracker.OnSubscribeCraftScriptEvents = delegate(ICraftScript craftScript, bool subscribe)
			{
				if (subscribe)
				{
					craftScript.PartExploded += OnPartExploded;
				}
				else
				{
					craftScript.PartExploded -= OnPartExploded;
				}
			};
			_tracker.OnSubscribeCraftNodeEvents = delegate(ICraftNode craftNode, bool subscribe)
			{
				if (subscribe)
				{
					craftNode.CraftNodeMerged += OnCraftNodeMerged;
					craftNode.Destroyed += OnCraftNodeDestroyed;
				}
				else
				{
					craftNode.CraftNodeMerged -= OnCraftNodeMerged;
					craftNode.Destroyed -= OnCraftNodeDestroyed;
				}
			};
			if (string.IsNullOrWhiteSpace(base.Description))
			{
				base.Description = _event.ToString();
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			_tracker.OnFlightEnd();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			_displayValue = string.Empty;
			_accumulatedPower = 0.0;
			_tracker.OnFlightStart(flightContext, generateCraftTrackingId: false);
			if (_event == EventType.Destroyed)
			{
				TrackSpawnedCraftRequirement parentRequirement = GetParentRequirement<TrackSpawnedCraftRequirement>();
				if (parentRequirement != null)
				{
					parentRequirement.IgnoreDestroyedCraft = true;
				}
			}
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (!_complete && !_tracker.IsDestroyed)
			{
				_tracker.SetCraftNode(craftNode as CraftNode);
			}
			else if (_tracker.CraftNode != null && _event != EventType.Destroyed)
			{
				_tracker.SetCraftNode(null);
			}
			return _complete;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_tracker.ResetStatus();
		}

		private void OnCraftNodeDestroyed(INode node)
		{
			if (_event == EventType.Destroyed)
			{
				_complete = true;
			}
		}

		private void OnCraftNodeMerged(ICraftNode targetCraftNode, ICraftNode sourceCraftNode)
		{
			if (_event == EventType.Docked && (_dockedCraftTrackingId == null || (_dockedCraftTrackingId != null && (targetCraftNode.ContractTrackingId == _dockedCraftTrackingId || sourceCraftNode.ContractTrackingId == _dockedCraftTrackingId))))
			{
				_complete = true;
			}
		}

		private void OnPartExploded(PartData part)
		{
			if (_event != EventType.Explosion)
			{
				return;
			}
			if (!_power.HasValue || _power <= 0f)
			{
				_complete = true;
				return;
			}
			FuelTankData modifier = part.GetModifier<FuelTankData>();
			if (modifier != null)
			{
				_accumulatedPower += modifier.Fuel * (double)modifier.FuelType.ExplosivePower * (double)part.Config.Explosiveness;
				_complete |= _accumulatedPower > (double?)_power;
				_displayValue = $"{_accumulatedPower:n0}";
			}
		}
	}
}
