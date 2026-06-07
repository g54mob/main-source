using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public static class AnimatorDataExtensions
	{
		public static AnimatorData ToData(this Animator animator)
		{
			return default(AnimatorData);
		}

		public static void ApplyToObject(this AnimatorData data, Animator animator)
		{
		}

		public static void FromJson(this Animator animator, JsonData data)
		{
		}
	}
}
