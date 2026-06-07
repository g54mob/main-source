using System;
using System.Xml.Linq;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class UniqueStringParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public UniqueStringParam(XElement xml)
			: base(xml)
		{
			GenerateValue();
		}

		private void GenerateValue()
		{
			_value = Guid.NewGuid().ToString();
		}
	}
}
