using UnityEngine;

namespace UI.Xml
{
	public static class ObjectExtensions
	{
		public static string ConvertToAttributeString(this object o)
		{
			if (o is Object)
			{
				Object obj = (Object)o;
				if (XmlLayoutResourceDatabase.instance.IsResource(obj))
				{
					return XmlLayoutResourceDatabase.instance.GetResourcePath(obj);
				}
				if (o is Sprite || o is Font || o is AudioClip)
				{
					try
					{
						return obj.name;
					}
					catch
					{
					}
				}
			}
			return o.ToString();
		}
	}
}
