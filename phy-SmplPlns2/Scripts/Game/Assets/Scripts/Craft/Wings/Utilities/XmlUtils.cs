using System.Xml.Linq;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public static class XmlUtils
	{
		public static float2? Float2Attribute(this XElement element, string attr)
		{
			attr = (string)element.Attribute(attr);
			if (string.IsNullOrWhiteSpace(attr))
			{
				return null;
			}
			string[] array = attr.Split(',');
			if (array.Length != 2)
			{
				return null;
			}
			float2 value = default(float2);
			if (float.TryParse(array[0], out value.x) && float.TryParse(array[1], out value.y))
			{
				return value;
			}
			return null;
		}

		public static float3? Float3Attribute(this XElement element, string attr)
		{
			attr = (string)element.Attribute(attr);
			if (string.IsNullOrWhiteSpace(attr))
			{
				return null;
			}
			string[] array = attr.Split(',');
			if (array.Length != 3)
			{
				return null;
			}
			float3 value = default(float3);
			if (float.TryParse(array[0], out value.x) && float.TryParse(array[1], out value.y) && float.TryParse(array[2], out value.z))
			{
				return value;
			}
			return null;
		}

		public static bool TryUnwrap<T>(this T? inst, out T value) where T : struct
		{
			if (!inst.HasValue)
			{
				value = default(T);
				return false;
			}
			value = inst.Value;
			return true;
		}
	}
}
