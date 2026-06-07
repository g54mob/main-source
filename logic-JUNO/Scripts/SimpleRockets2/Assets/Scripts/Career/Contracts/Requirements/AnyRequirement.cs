using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class AnyRequirement : ContractRequirement
	{
		private int _num;

		private int _numChildrenComplete;

		public override string DisplayValue => $"{_numChildrenComplete} Complete";

		public AnyRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			base.ShowCheckmarkWhenPassed = false;
			_num = xml.GetIntAttribute("num", 1);
			if (string.IsNullOrEmpty(base.Description))
			{
				base.Description = $"Complete at least {_num}";
			}
		}

		protected override ContractRequirement CreateChildRequirement(XElement xml)
		{
			ContractRequirement contractRequirement = base.CreateChildRequirement(xml);
			contractRequirement.IsSequential = false;
			return contractRequirement;
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			return true;
		}

		protected override bool UpdateChildren(ICraftNode craftNode, bool parentsPassing)
		{
			_numChildrenComplete = 0;
			foreach (ContractRequirement child in base.Children)
			{
				child.OnFlightUpdate(craftNode, parentsPassing);
				if (child.Status == RequirementStatus.Complete)
				{
					_numChildrenComplete++;
				}
			}
			return _numChildrenComplete >= _num;
		}
	}
}
