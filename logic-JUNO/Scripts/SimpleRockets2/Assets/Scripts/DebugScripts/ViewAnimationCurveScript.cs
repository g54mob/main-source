using ModApi.Data;
using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class ViewAnimationCurveScript : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _curve;

		public AnimationCurve Curve
		{
			get
			{
				return _curve;
			}
			set
			{
				_curve = value;
			}
		}

		[ContextMenu("Output Keyframes")]
		public void OutputKeyframes()
		{
			UserCurve userCurve = new UserCurve("Temp", UserCurve.CurveStyle.Custom, UserCurve.CurveWrapMode.Clamp);
			userCurve.Curve = Curve;
			Debug.Log("Keyframes: " + userCurve.GetKeyframesAsString());
		}
	}
}
