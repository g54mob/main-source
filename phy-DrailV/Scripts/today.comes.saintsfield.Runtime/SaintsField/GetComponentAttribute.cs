using System;
using System.Diagnostics;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetComponentAttribute : GetByXPathAttribute
	{
		public readonly Type CompType;

		public override string GroupBy { get; }

		public GetComponentAttribute(Type compType = null, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetComponentExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseXPath(compType);
			GroupBy = groupBy;
			base.OptimizationPayload = new GetComponentPayload(compType);
		}

		public GetComponentAttribute(EXP exp, Type compType = null, string groupBy = "")
		{
			ParseOptions(exp);
			ParseXPath(compType);
			CompType = compType;
			GroupBy = groupBy;
			base.OptimizationPayload = new GetComponentPayload(compType);
		}

		private void ParseXPath(Type compType)
		{
			GetByXPathAttribute.GetComponentFilter(compType);
			XPathInfoAndList = new XPathInfo[1][] { new XPathInfo[1]
			{
				new XPathInfo
				{
					IsCallback = false,
					Callback = ""
				}
			} };
		}
	}
}
