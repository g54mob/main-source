using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace ModApi.Craft.Program
{
	public class Variable
	{
		public bool IsList => Value.ExpressionType == ExpressionType.List;

		public string Name { get; private set; }

		public ExpressionResult Value { get; private set; }

		public Variable(string name, ExpressionResult value = null)
		{
			Name = name;
			if (value == null)
			{
				Value = new ExpressionResult();
			}
			else
			{
				Value = value;
			}
		}

		public Variable(XElement xml)
		{
			Name = xml.GetStringAttribute("name");
			Value = new ExpressionResult(xml);
		}

		public void SaveXml(XElement xml)
		{
			xml.SetAttributeValue("name", Name);
			Value.SaveXml(xml);
		}
	}
}
