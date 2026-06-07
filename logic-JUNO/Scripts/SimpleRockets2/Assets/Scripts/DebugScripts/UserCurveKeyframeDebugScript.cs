using ModApi.Common.Animation;
using ModApi.Data;
using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class UserCurveKeyframeDebugScript : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _curve = new AnimationCurve();

		private string _curvePrevious;

		[SerializeField]
		private string _text;

		private string _textPrevious;

		protected virtual void Awake()
		{
			_curve.SetTangents(AnimationCurveTangentMode.Free);
			_curve.postWrapMode = WrapMode.Once;
			_curve.preWrapMode = WrapMode.Once;
		}

		protected virtual void OnValidate()
		{
			string serializedCurve = GetSerializedCurve(_curve);
			if (serializedCurve != _curvePrevious)
			{
				_text = serializedCurve;
				_textPrevious = serializedCurve;
				_curvePrevious = serializedCurve;
			}
			string text = _text;
			if (text != _textPrevious)
			{
				_curve.keys = new Keyframe[0];
				UserCurve.TryAddKeyframes(_curve, text);
				_curvePrevious = GetSerializedCurve(_curve);
				_textPrevious = text;
			}
		}

		private static string GetSerializedCurve(AnimationCurve curve)
		{
			try
			{
				return UserCurve.GetKeyframesAsString(curve, UserCurve.CurveStyle.Custom);
			}
			catch
			{
				return null;
			}
		}
	}
}
