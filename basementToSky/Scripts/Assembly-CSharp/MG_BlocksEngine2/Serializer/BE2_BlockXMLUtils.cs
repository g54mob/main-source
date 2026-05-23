using System.Globalization;
using UnityEngine;

namespace MG_BlocksEngine2.Serializer
{
	public static class BE2_BlockXMLUtils
	{
		public static Vector3 StringToVector3(string stringValue)
		{
			Vector3 zero = Vector3.zero;
			string[] array = stringValue.TrimStart('(').TrimEnd(')').Split(',');
			zero.x = StringToFloat(array[0]);
			zero.y = StringToFloat(array[1]);
			zero.z = StringToFloat(array[2]);
			return zero;
		}

		public static float StringToFloat(string stringValue)
		{
			try
			{
				return float.Parse(stringValue, CultureInfo.InvariantCulture);
			}
			catch
			{
				return 0f;
			}
		}
	}
}
