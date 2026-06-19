using System.Collections.Generic;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[GenerateParameterUtility]
	public static class TMPParameterUtility
	{
		public delegate W ParseDelegate<T, U, V, W>(T input, out U output, V keywords);

		private static ParseDelegate<string, string, ITMPKeywordDatabase, bool> stringParseDelegate;

		public static bool TryGetDefinedParameter(out string value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool ParameterDefined(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonArrayParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasArrayParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetArrayParameter(out string[] value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool HasNonArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetArrayParameter<T>(out T[] value, IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool TryGetArrayParameter<T>(out T[] value, IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool HasFloatParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasFloatParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonFloatParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonFloatParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetFloatParameter(out float value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(float);
			return false;
		}

		public static bool TryGetFloatParameter(out float value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(float);
			return false;
		}

		public static bool HasIntParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasIntParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonIntParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonIntParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetIntParameter(out int value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(int);
			return false;
		}

		public static bool TryGetIntParameter(out int value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(int);
			return false;
		}

		public static bool HasBoolParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasBoolParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonBoolParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonBoolParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetBoolParameter(out bool value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(bool);
			return false;
		}

		public static bool TryGetBoolParameter(out bool value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(bool);
			return false;
		}

		public static bool HasUnityObjectParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasUnityObjectParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonUnityObjectParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonUnityObjectParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetUnityObjectParameter(out Object value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool TryGetUnityObjectParameter(out Object value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool HasTypedVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasTypedVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonTypedVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonTypedVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetTypedVector3Parameter(out TMPParameterTypes.TypedVector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector3);
			return false;
		}

		public static bool TryGetTypedVector3Parameter(out TMPParameterTypes.TypedVector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector3);
			return false;
		}

		public static bool HasTypedVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasTypedVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonTypedVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonTypedVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetTypedVector2Parameter(out TMPParameterTypes.TypedVector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector2);
			return false;
		}

		public static bool TryGetTypedVector2Parameter(out TMPParameterTypes.TypedVector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector2);
			return false;
		}

		public static bool HasVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetVector2Parameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool TryGetVector2Parameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool HasVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetVector3Parameter(out Vector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector3);
			return false;
		}

		public static bool TryGetVector3Parameter(out Vector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector3);
			return false;
		}

		public static bool HasVector2OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasVector2OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector2OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector2OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetVector2OffsetParameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool TryGetVector2OffsetParameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool HasVector3OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasVector3OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector3OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonVector3OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetVector3OffsetParameter(out Vector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector3);
			return false;
		}

		public static bool TryGetVector3OffsetParameter(out Vector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector3);
			return false;
		}

		public static bool HasAnchorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasAnchorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonAnchorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonAnchorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetAnchorParameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool TryGetAnchorParameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			return false;
		}

		public static bool HasColorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasColorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonColorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonColorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetColorParameter(out Color value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Color);
			return false;
		}

		public static bool TryGetColorParameter(out Color value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Color);
			return false;
		}

		public static bool HasAnimCurveParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasAnimCurveParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonAnimCurveParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		public static bool HasNonAnimCurveParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		public static bool TryGetAnimCurveParameter(out AnimationCurve value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		public static bool TryGetAnimCurveParameter(out AnimationCurve value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			return false;
		}
	}
}
