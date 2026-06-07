using System.Xml.Linq;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class PlanetRequirement : ContractRequirement
	{
		private string _currentParentName;

		public override bool DefaultListedInMenu => false;

		public override RequirementVisibilityType DefaultVisibility => RequirementVisibilityType.HiddenWhenPassed;

		public override string DisplayValue => _currentParentName;

		public string PlanetName { get; private set; }

		public PlanetRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			PlanetName = xml.Attribute("name").Value;
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_currentParentName = craftNode.Parent.Name;
			return _currentParentName == PlanetName;
		}
	}
}
