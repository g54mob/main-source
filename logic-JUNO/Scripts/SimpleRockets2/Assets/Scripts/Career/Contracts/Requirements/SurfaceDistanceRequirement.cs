using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Math;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class SurfaceDistanceRequirement : ContractRequirement
	{
		private double _distance;

		private double? _maximum;

		private double? _minimum;

		public override string DisplayValue => Units.GetDistanceString((float)_distance);

		public SurfaceDistanceRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_minimum = xml.GetDoubleAttributeOrNull("min");
			_maximum = xml.GetDoubleAttributeOrNull("max");
			_distance = xml.GetDoubleAttribute("distance");
			if (_minimum.HasValue && _maximum.HasValue)
			{
				throw new ContractException("SurfaceDistanceRequirement cannot define both min and max attributes.");
			}
			if (!_minimum.HasValue && !_maximum.HasValue)
			{
				throw new ContractException("SurfaceDistanceRequirement must define min or max attribute.");
			}
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("distance", _distance);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_distance += base.FlightContext.FrameDistanceSurface;
			if (_minimum.HasValue)
			{
				return _distance >= _minimum;
			}
			return _distance <= _maximum;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_distance = 0.0;
		}
	}
}
