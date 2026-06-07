using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class CompletionsParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public CompletionsParam(XElement xml, ContractParamContext context)
			: base(xml)
		{
			string stringAttribute = xml.GetStringAttribute("contractID");
			_value = context.GetNumberOfCompletions(stringAttribute).ToString();
		}
	}
}
