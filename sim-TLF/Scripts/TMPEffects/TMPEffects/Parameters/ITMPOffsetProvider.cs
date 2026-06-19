using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Parameters.Attributes;

namespace TMPEffects.Parameters
{
	[TMPParameterType("OffsetProvider", typeof(OffsetTypePowerEnum), typeof(SceneOffsetTypePowerEnum), true)]
	public interface ITMPOffsetProvider
	{
		float GetOffset(CharData cData, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false);

		void GetMinMaxOffset(out float min, out float max, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false);

		static bool StringToOffsetProvider(string str, out ITMPOffsetProvider result, ITMPKeywordDatabase db)
		{
			result = null;
			switch (str)
			{
			case "sidx":
			case "sindex":
			case "segmentindex":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.SegmentIndex);
				return true;
			case "idx":
			case "index":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.Index);
				return true;
			case "word":
			case "wordidx":
			case "wordindex":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.Word);
				return true;
			case "line":
			case "lineno":
			case "linenumber":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.Line);
				return true;
			case "base":
			case "baseline":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.Baseline);
				return true;
			case "x":
			case "xpos":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.XPos);
				return true;
			case "y":
			case "ypos":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.YPos);
				return true;
			case "wordly":
			case "worldypos":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.WorldYPos);
				return true;
			case "wordlx":
			case "worldxpos":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.WorldXPos);
				return true;
			case "wordlz":
			case "worldzpos":
				result = new OffsetTypePowerEnum(TMPParameterTypes.OffsetType.WorldZPos);
				return true;
			default:
				return false;
			}
		}

		static bool HasOffsetProviderParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			ITMPOffsetProvider value;
			return TryGetOffsetProviderParameter(out value, parameters, null, name, aliases);
		}

		static bool HasOffsetProviderParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			ITMPOffsetProvider value;
			return TryGetOffsetProviderParameter(out value, parameters, keywords, name, aliases);
		}

		static bool HasNonOffsetProviderParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			if (!TMPParameterUtility.ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			ITMPOffsetProvider value;
			return !TryGetOffsetProviderParameter(out value, parameters, null, name, aliases);
		}

		static bool HasNonOffsetProviderParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			if (!TMPParameterUtility.ParameterDefined(parameters, name, aliases))
			{
				return false;
			}
			ITMPOffsetProvider value;
			return !TryGetOffsetProviderParameter(out value, parameters, keywords, name, aliases);
		}

		static bool TryGetOffsetProviderParameter(out ITMPOffsetProvider value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			if (!TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return StringToOffsetProvider(parameters[value2], out value, null);
		}

		static bool TryGetOffsetProviderParameter(out ITMPOffsetProvider value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			if (!TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, name, aliases))
			{
				return false;
			}
			return StringToOffsetProvider(parameters[value2], out value, keywords);
		}
	}
}
