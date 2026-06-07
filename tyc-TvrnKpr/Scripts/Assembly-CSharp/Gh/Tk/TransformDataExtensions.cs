using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public static class TransformDataExtensions
	{
		public static TransformData ToData(this Transform transform)
		{
			return default(TransformData);
		}

		public static void FromJson(this Transform transform, JsonData data)
		{
		}

		public static void FromData(this Transform transform, TransformData data)
		{
		}
	}
}
