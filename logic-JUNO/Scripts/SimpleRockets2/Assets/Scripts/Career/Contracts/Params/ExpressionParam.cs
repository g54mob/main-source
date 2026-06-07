using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Expressions;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class ExpressionParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public ExpressionParam(XElement xml, ContractParamContext context)
			: base(xml)
		{
			string stringAttribute = xml.GetStringAttribute("value");
			string stringAttribute2 = xml.GetStringAttribute("valueTrue");
			string stringAttribute3 = xml.GetStringAttribute("valueFalse");
			string stringAttribute4 = xml.GetStringAttribute("valueDebug");
			try
			{
				string inputString = context.ContractTemplate.StringProcessor.ProcessString(stringAttribute);
				Context context2 = new Context(true, (typeof(ContractParamContext), context, null, true));
				double num = Parser.Process<double>(inputString, context2)?.Invoke() ?? 0.0;
				if (stringAttribute4 != null && context.ContractTemplate.IsDebug)
				{
					_value = stringAttribute4;
				}
				else if (stringAttribute2 != null && stringAttribute3 != null)
				{
					_value = ((num != -1.0) ? stringAttribute2 : stringAttribute3);
				}
				else
				{
					_value = num.ToString();
				}
			}
			catch (Exception innerException)
			{
				throw new ContractException("Error in ExpressionParam '" + base.Name + "': " + stringAttribute, innerException);
			}
		}
	}
}
