using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Levels;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class FuelRequirement : ContractRequirement
	{
		private double _fuel;

		private double _used;

		private double? _lastUsed;

		public override string DisplayValue => Units.GetMassString((float)(_used * 0.009999999776482582));

		public FuelRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_fuel = xml.GetDoubleAttribute("fuel");
			_used = xml.GetDoubleAttribute("used");
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("used", _used);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			FuelMonitor fuelMonitor = craftNode.CraftScript?.GetOrCreateFuelMonitor();
			if (fuelMonitor != null)
			{
				if (_lastUsed.HasValue)
				{
					double num = Mathd.Max(0.0, (double)fuelMonitor.FuelUsedInKG - _lastUsed.Value);
					_used += num;
				}
				_lastUsed = fuelMonitor.FuelUsedInKG;
			}
			else
			{
				_lastUsed = null;
			}
			return _used <= _fuel;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_used = 0.0;
			_lastUsed = null;
		}
	}
}
