using System.Linq;
using System.Reflection;
using System.Text;

namespace UniJSON
{
	public class JsonSchemaAttribute : BaseJsonSchemaAttribute
	{
		public override string GetInfo(FieldInfo fi)
		{
			if (BaseJsonSchemaAttribute.IsNumber(fi.FieldType))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!double.IsNaN(Minimum) && !double.IsNaN(Maximum))
				{
					stringBuilder.Append($"{Minimum} <= N <= {Maximum}");
				}
				else if (!double.IsNaN(Minimum))
				{
					stringBuilder.Append($"{Minimum} <= N");
				}
				else if (!double.IsNaN(Maximum))
				{
					stringBuilder.Append($"N <= {Maximum}");
				}
				return stringBuilder.ToString();
			}
			if (EnumValues != null)
			{
				return string.Join(", ", EnumValues.Select((object x) => x.ToString()).ToArray());
			}
			return BaseJsonSchemaAttribute.GetTypeName(fi.FieldType);
		}
	}
}
