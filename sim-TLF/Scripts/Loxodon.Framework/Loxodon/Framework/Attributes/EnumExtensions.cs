using System;
using System.Reflection;

namespace Loxodon.Framework.Attributes
{
	public static class EnumExtensions
	{
		public static string GetRemark(this Enum e)
		{
			FieldInfo field = e.GetType().GetField(e.ToString());
			if (field == null)
			{
				return string.Empty;
			}
			object[] customAttributes = field.GetCustomAttributes(typeof(RemarkAttribute), inherit: false);
			int num = 0;
			if (num < customAttributes.Length)
			{
				return ((RemarkAttribute)customAttributes[num]).Remark;
			}
			return string.Empty;
		}
	}
}
