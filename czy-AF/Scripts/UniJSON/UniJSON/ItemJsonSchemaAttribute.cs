using System.Reflection;
using System.Text;

namespace UniJSON
{
	public class ItemJsonSchemaAttribute : BaseJsonSchemaAttribute
	{
		public override string GetInfo(FieldInfo fi)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(BaseJsonSchemaAttribute.GetTypeName(fi.FieldType));
			if (!double.IsNaN(MinItems) && !double.IsNaN(MaxItems))
			{
				stringBuilder.Append($"{MinItems} < N < {MaxItems}");
			}
			else if (!double.IsNaN(MinItems))
			{
				stringBuilder.Append($"{MinItems}< N");
			}
			else
			{
				double.IsNaN(MaxItems);
			}
			return stringBuilder.ToString();
		}
	}
}
