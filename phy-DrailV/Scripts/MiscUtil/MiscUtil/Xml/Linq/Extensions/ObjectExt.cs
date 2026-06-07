using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace MiscUtil.Xml.Linq.Extensions
{
	public static class ObjectExt
	{
		public static IEnumerable<XElement> AsXElements(this object source)
		{
			try
			{
				PropertyInfo[] properties = source.GetType().GetProperties();
				foreach (PropertyInfo prop in properties)
				{
					yield return new XElement(content: prop.GetValue(source, null), name: prop.Name.Replace("_", "-"));
				}
			}
			finally
			{
			}
		}

		public static IEnumerable<XAttribute> AsXAttributes(this object source)
		{
			try
			{
				PropertyInfo[] properties = source.GetType().GetProperties();
				foreach (PropertyInfo prop in properties)
				{
					yield return new XAttribute(value: prop.GetValue(source, null) ?? "", name: prop.Name.Replace("_", "-"));
				}
			}
			finally
			{
			}
		}
	}
}
