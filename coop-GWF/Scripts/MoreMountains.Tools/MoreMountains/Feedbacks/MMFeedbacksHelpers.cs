using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	public class MMFeedbacksHelpers : MonoBehaviour
	{
		public static float Remap(float x, float A, float B, float C, float D)
		{
			return C + (x - A) / (B - A) * (D - C);
		}

		public static void MigrateCurve(AnimationCurve oldCurve, MMTweenType newTweenType, MMF_Player owner)
		{
			if (oldCurve.keys.Length != 0 && !newTweenType.Initialized)
			{
				newTweenType.Curve = oldCurve;
				newTweenType.MMTweenDefinitionType = MMTweenDefinitionTypes.AnimationCurve;
				oldCurve = null;
				newTweenType.Initialized = true;
			}
		}
	}
}
