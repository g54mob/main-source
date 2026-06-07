using System.Diagnostics;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetScriptableObjectAttribute : GetByXPathAttribute
	{
		public readonly string PathSuffix;

		public override string GroupBy { get; }

		public GetScriptableObjectAttribute(string pathSuffix = null, string groupBy = "")
		{
			PathSuffix = (string.IsNullOrEmpty(pathSuffix) ? null : (pathSuffix + ".asset"));
			ParseOptions(SaintsFieldConfigUtil.GetScriptableObjectExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseXPath(pathSuffix);
			GroupBy = groupBy;
			base.OptimizationPayload = new GetScriptableObjectPayload(PathSuffix);
		}

		public GetScriptableObjectAttribute(EXP config, string pathSuffix = null, string groupBy = "")
		{
			ParseOptions(config);
			ParseXPath(pathSuffix);
			GroupBy = groupBy;
			base.OptimizationPayload = new GetScriptableObjectPayload(null);
		}

		private void ParseXPath(string pathSuffix)
		{
			string text = (string.IsNullOrEmpty(pathSuffix) ? "*.asset" : ("*" + pathSuffix + ".asset"));
			_ = "assets:://" + text;
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
