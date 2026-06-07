using System;
using System.Diagnostics;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetComponentInSceneAttribute : GetByXPathAttribute
	{
		public readonly Type CompType;

		public readonly bool IncludeInactive;

		public override string GroupBy { get; }

		public GetComponentInSceneAttribute(bool includeInactive = false, Type compType = null, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetComponentInSceneExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseArguments(includeInactive, compType);
			GroupBy = groupBy;
			CompType = compType;
			IncludeInactive = includeInactive;
			base.OptimizationPayload = new GetComponentInScenePayload(includeInactive, compType);
		}

		private void ParseArguments(bool includeInactive, Type compType)
		{
			string componentFilter = GetByXPathAttribute.GetComponentFilter(compType);
			string text = (includeInactive ? "" : "[@{gameObject.activeInHierarchy}]") + componentFilter;
			_ = "scene:://*" + text;
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
