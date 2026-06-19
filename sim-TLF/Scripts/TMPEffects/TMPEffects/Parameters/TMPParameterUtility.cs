using System.Collections.Generic;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[GenerateParameterUtility]
	public static class TMPParameterUtility
	{
		public delegate W ParseDelegate<T, U, V, W>(T input, out U output, V keywords);

		private static ParseDelegate<string, string, ITMPKeywordDatabase, bool> stringParseDelegate = delegate(string a, out string b, ITMPKeywordDatabase keywordDatabase)
		{
			b = a;
			return true;
		};

		public static bool TryGetDefinedParameter(out string value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			if (parameters.ContainsKey(name))
			{
				value = name;
			}
			if (aliases == null)
			{
				return value != null;
			}
			for (int i = 0; i < aliases.Length; i++)
			{
				if (parameters.ContainsKey(aliases[i]))
				{
					if (value != null)
					{
						return false;
					}
					value = aliases[i];
				}
			}
			return value != null;
		}

		public static bool ParameterDefined(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			string value;
			return TryGetDefinedParameter(out value, parameters, name, aliases);
		}

		public static bool HasNonArrayParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			string[] value;
			return !TryGetArrayParameter(out value, parameters, name, aliases);
		}

		public static bool HasArrayParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			string[] value;
			return TryGetArrayParameter(out value, parameters, name, aliases);
		}

		public static bool TryGetArrayParameter(out string[] value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return TryGetArrayParameter(out value, parameters, stringParseDelegate, null, name, aliases);
		}

		public static bool HasNonArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			return HasNonArrayParameter(parameters, func, null, name, aliases);
		}

		public static bool HasNonArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			T[] value;
			return !TryGetArrayParameter(out value, parameters, func, keywords, name, aliases);
		}

		public static bool HasArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			return HasArrayParameter(parameters, func, null, name, aliases);
		}

		public static bool HasArrayParameter<T>(IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			T[] value;
			return TryGetArrayParameter(out value, parameters, func, name, aliases);
		}

		public static bool TryGetArrayParameter<T>(out T[] value, IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, string name, params string[] aliases)
		{
			return TryGetArrayParameter(out value, parameters, func, null, name, aliases);
		}

		public static bool TryGetArrayParameter<T>(out T[] value, IDictionary<string, string> parameters, ParseDelegate<string, T, ITMPKeywordDatabase, bool> func, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			string[] array = parameters[value2].Split(";");
			List<T> list = new List<T>();
			foreach (string input in array)
			{
				if (!func(input, out var output, keywords))
				{
					return false;
				}
				list.Add(output);
			}
			value = list.ToArray();
			return true;
		}

		public static bool HasFloatParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			float value;
			return TryGetFloatParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasFloatParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			float value;
			return TryGetFloatParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonFloatParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			float value;
			return !TryGetFloatParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonFloatParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			float value;
			return !TryGetFloatParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetFloatParameter(out float value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = 0f;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToFloat(parameters[value2], out value);
		}

		public static bool TryGetFloatParameter(out float value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = 0f;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToFloat(parameters[value2], out value, keywords);
		}

		public static bool HasIntParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			int value;
			return TryGetIntParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasIntParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			int value;
			return TryGetIntParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonIntParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			int value;
			return !TryGetIntParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonIntParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			int value;
			return !TryGetIntParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetIntParameter(out int value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = 0;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToInt(parameters[value2], out value);
		}

		public static bool TryGetIntParameter(out int value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = 0;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToInt(parameters[value2], out value, keywords);
		}

		public static bool HasBoolParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			bool value;
			return TryGetBoolParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasBoolParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			bool value;
			return TryGetBoolParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonBoolParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			bool value;
			return !TryGetBoolParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonBoolParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			bool value;
			return !TryGetBoolParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetBoolParameter(out bool value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = false;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToBool(parameters[value2], out value);
		}

		public static bool TryGetBoolParameter(out bool value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = false;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToBool(parameters[value2], out value, keywords);
		}

		public static bool HasUnityObjectParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Object value;
			return TryGetUnityObjectParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasUnityObjectParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Object value;
			return TryGetUnityObjectParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonUnityObjectParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Object value;
			return !TryGetUnityObjectParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonUnityObjectParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Object value;
			return !TryGetUnityObjectParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetUnityObjectParameter(out Object value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToUnityObject(parameters[value2], out value);
		}

		public static bool TryGetUnityObjectParameter(out Object value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToUnityObject(parameters[value2], out value, keywords);
		}

		public static bool HasTypedVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			TMPParameterTypes.TypedVector3 value;
			return TryGetTypedVector3Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasTypedVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			TMPParameterTypes.TypedVector3 value;
			return TryGetTypedVector3Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonTypedVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			TMPParameterTypes.TypedVector3 value;
			return !TryGetTypedVector3Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonTypedVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			TMPParameterTypes.TypedVector3 value;
			return !TryGetTypedVector3Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetTypedVector3Parameter(out TMPParameterTypes.TypedVector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToTypedVector3(parameters[value2], out value);
		}

		public static bool TryGetTypedVector3Parameter(out TMPParameterTypes.TypedVector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToTypedVector3(parameters[value2], out value, keywords);
		}

		public static bool HasTypedVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			TMPParameterTypes.TypedVector2 value;
			return TryGetTypedVector2Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasTypedVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			TMPParameterTypes.TypedVector2 value;
			return TryGetTypedVector2Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonTypedVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			TMPParameterTypes.TypedVector2 value;
			return !TryGetTypedVector2Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonTypedVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			TMPParameterTypes.TypedVector2 value;
			return !TryGetTypedVector2Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetTypedVector2Parameter(out TMPParameterTypes.TypedVector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToTypedVector2(parameters[value2], out value);
		}

		public static bool TryGetTypedVector2Parameter(out TMPParameterTypes.TypedVector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(TMPParameterTypes.TypedVector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToTypedVector2(parameters[value2], out value, keywords);
		}

		public static bool HasVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetVector2Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetVector2Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonVector2Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetVector2Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonVector2Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetVector2Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetVector2Parameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector2(parameters[value2], out value);
		}

		public static bool TryGetVector2Parameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector2(parameters[value2], out value, keywords);
		}

		public static bool HasVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Vector3 value;
			return TryGetVector3Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Vector3 value;
			return TryGetVector3Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonVector3Parameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector3 value;
			return !TryGetVector3Parameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonVector3Parameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector3 value;
			return !TryGetVector3Parameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetVector3Parameter(out Vector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector3(parameters[value2], out value);
		}

		public static bool TryGetVector3Parameter(out Vector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector3(parameters[value2], out value, keywords);
		}

		public static bool HasVector2OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetVector2OffsetParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasVector2OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetVector2OffsetParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonVector2OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetVector2OffsetParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonVector2OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetVector2OffsetParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetVector2OffsetParameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector2Offset(parameters[value2], out value);
		}

		public static bool TryGetVector2OffsetParameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector2Offset(parameters[value2], out value, keywords);
		}

		public static bool HasVector3OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Vector3 value;
			return TryGetVector3OffsetParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasVector3OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Vector3 value;
			return TryGetVector3OffsetParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonVector3OffsetParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector3 value;
			return !TryGetVector3OffsetParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonVector3OffsetParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector3 value;
			return !TryGetVector3OffsetParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetVector3OffsetParameter(out Vector3 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector3Offset(parameters[value2], out value);
		}

		public static bool TryGetVector3OffsetParameter(out Vector3 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector3);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToVector3Offset(parameters[value2], out value, keywords);
		}

		public static bool HasAnchorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetAnchorParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasAnchorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Vector2 value;
			return TryGetAnchorParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonAnchorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetAnchorParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonAnchorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Vector2 value;
			return !TryGetAnchorParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetAnchorParameter(out Vector2 value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToAnchor(parameters[value2], out value);
		}

		public static bool TryGetAnchorParameter(out Vector2 value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Vector2);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToAnchor(parameters[value2], out value, keywords);
		}

		public static bool HasColorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			Color value;
			return TryGetColorParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasColorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			Color value;
			return TryGetColorParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonColorParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Color value;
			return !TryGetColorParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonColorParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			Color value;
			return !TryGetColorParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetColorParameter(out Color value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = default(Color);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToColor(parameters[value2], out value);
		}

		public static bool TryGetColorParameter(out Color value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = default(Color);
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToColor(parameters[value2], out value, keywords);
		}

		public static bool HasAnimCurveParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			AnimationCurve value;
			return TryGetAnimCurveParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasAnimCurveParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			AnimationCurve value;
			return TryGetAnimCurveParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool HasNonAnimCurveParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			AnimationCurve value;
			return !TryGetAnimCurveParameter(out value, parameters, null, name, aliases);
		}

		public static bool HasNonAnimCurveParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			AnimationCurve value;
			return !TryGetAnimCurveParameter(out value, parameters, keywords, name, aliases);
		}

		public static bool TryGetAnimCurveParameter(out AnimationCurve value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToAnimCurve(parameters[value2], out value);
		}

		public static bool TryGetAnimCurveParameter(out AnimationCurve value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			if (!TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return ParameterParsing.StringToAnimCurve(parameters[value2], out value, keywords);
		}
	}
}
