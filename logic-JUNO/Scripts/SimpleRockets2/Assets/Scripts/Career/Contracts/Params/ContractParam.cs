using System.Xml.Linq;

namespace Assets.Scripts.Career.Contracts.Params
{
	public abstract class ContractParam : IStringProcessorParam
	{
		public string Name { get; private set; }

		public abstract string Value { get; }

		public ContractParam(XElement xml)
		{
			Name = xml.Attribute("name")?.Value;
			if (string.IsNullOrWhiteSpace(Name))
			{
				throw new ContractException("Param does not have a name attribute");
			}
		}

		public ContractParam(string name)
		{
			Name = name;
		}
	}
}
