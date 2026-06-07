using System;
using System.Diagnostics;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetPrefabWithComponentAttribute : GetByXPathAttribute
	{
		public readonly Type CompType;

		public override string GroupBy { get; }

		public GetPrefabWithComponentAttribute(Type compType = null, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetPrefabWithComponentExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseXPath(compType);
			GroupBy = groupBy;
			CompType = compType;
			base.OptimizationPayload = new GetPrefabWithComponentPayload(compType);
		}

		public GetPrefabWithComponentAttribute(EXP config, Type compType = null, string groupBy = "")
		{
			ParseOptions(config);
			ParseXPath(compType);
			GroupBy = groupBy;
			base.OptimizationPayload = new GetPrefabWithComponentPayload(compType);
		}

		private void ParseXPath(Type compType)
		{
			string componentFilter = GetByXPathAttribute.GetComponentFilter(compType);
			_ = "assets:://*.prefab" + componentFilter;
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
