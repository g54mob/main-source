using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Math;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class TimerRequirement : ContractRequirement
	{
		private double _currentTime;

		private double? _maximum;

		private double? _minimum;

		public override string DisplayValue => Units.GetStopwatchTimeString(_currentTime);

		public TimerRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_minimum = xml.GetDoubleAttributeOrNull("min");
			_maximum = xml.GetDoubleAttributeOrNull("max");
			if (_minimum.HasValue && _maximum.HasValue)
			{
				throw new ContractException("TimerRequirement cannot define both min and max attributes.");
			}
			if (!_minimum.HasValue && !_maximum.HasValue)
			{
				throw new ContractException("TimerRequirement must define min or max attribute.");
			}
			_currentTime = xml.GetDoubleAttribute("t");
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("t", _currentTime);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_currentTime += base.FlightContext.DeltaTime;
			if (_minimum.HasValue)
			{
				return _currentTime >= _minimum;
			}
			return _currentTime <= _maximum;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_currentTime = 0.0;
		}
	}
}
