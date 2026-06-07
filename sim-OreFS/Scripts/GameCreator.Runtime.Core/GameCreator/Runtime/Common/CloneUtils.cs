using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class CloneUtils
	{
		public static T Deep<T>(T source)
		{
			if (source == null)
			{
				return default(T);
			}
			return JsonUtility.FromJson<T>(JsonUtility.ToJson(source));
		}
	}
}
