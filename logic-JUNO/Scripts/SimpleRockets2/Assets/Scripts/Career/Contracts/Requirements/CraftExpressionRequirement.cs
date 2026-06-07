using System.Xml.Linq;
using ModApi.Craft;
using ModApi.Expressions;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class CraftExpressionRequirement : ExpressionRequirement
	{
		private CraftExpressionContext _craftExpressionContext;

		public CraftExpressionRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			base.RequiresPlayerCraft = false;
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			_craftExpressionContext.CraftNode = craftNode;
			return base.Evaluate(craftNode);
		}

		protected override Context GenerateContext(IFlightContext flight)
		{
			PayloadRequirement parentRequirement = GetParentRequirement<PayloadRequirement>();
			_craftExpressionContext = new CraftExpressionContext(parentRequirement);
			return new Context(true, (typeof(CraftExpressionContext), _craftExpressionContext, null, true));
		}
	}
}
