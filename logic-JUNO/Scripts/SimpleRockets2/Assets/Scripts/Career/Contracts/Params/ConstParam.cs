using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class ConstParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public ConstParam(XElement xml)
			: base(xml)
		{
			_value = xml.GetStringAttribute("value");
		}

		public ConstParam(string name, string value)
			: base(name)
		{
			_value = value;
		}
	}
}
