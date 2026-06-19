using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.Parameters
{
	public static class ParameterParsing
	{
		private static string TrimIfNeeded(string text)
		{
			return null;
		}

		public static bool StringToInt(string str, out int result, ITMPKeywordDatabase keywords = null)
		{
			result = default(int);
			return false;
		}

		public static bool StringToFloat(string str, out float result, ITMPKeywordDatabase keywords = null)
		{
			result = default(float);
			return false;
		}

		public static bool StringToBool(string str, out bool result, ITMPKeywordDatabase keywords = null)
		{
			result = default(bool);
			return false;
		}

		public static bool StringToVector2(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector2);
			return false;
		}

		public static bool StringToTypedVector3(string str, out TMPParameterTypes.TypedVector3 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(TMPParameterTypes.TypedVector3);
			return false;
		}

		public static bool StringToTypedVector2(string str, out TMPParameterTypes.TypedVector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(TMPParameterTypes.TypedVector2);
			return false;
		}

		public static bool StringToVector3(string str, out Vector3 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector3);
			return false;
		}

		public static bool StringToVector2Offset(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector2);
			return false;
		}

		public static bool StringToVector3Offset(string str, out Vector3 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector3);
			return false;
		}

		public static bool StringToAnchor(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector2);
			return false;
		}

		public static bool StringToAnimCurve(string str, out AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			result = null;
			return false;
		}

		public static bool StringToUnityObject(string str, out Object result, ITMPKeywordDatabase keywords = null)
		{
			result = null;
			return false;
		}

		public static bool StringToColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			return false;
		}

		internal static bool StringToHexInt(string str, out int result, ITMPKeywordDatabase keywords = null)
		{
			result = default(int);
			return false;
		}

		internal static bool StringToHexColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			return false;
		}

		internal static bool StringToHSVColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			return false;
		}

		internal static bool StringToRGBColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			return false;
		}

		internal static bool StringToRGBAColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			return false;
		}

		internal static bool VectorSequenceToAnimationCurve(string str, ref AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			return false;
		}

		internal static bool MethodToAnimationCurve(string str, ref AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			return false;
		}
	}
}
