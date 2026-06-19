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
			return false;
		}

		static bool HasOffsetProviderParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		static bool HasOffsetProviderParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		static bool HasNonOffsetProviderParameter(IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			return false;
		}

		static bool HasNonOffsetProviderParameter(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			return false;
		}

		static bool TryGetOffsetProviderParameter(out ITMPOffsetProvider value, IDictionary<string, string> parameters, string name, params string[] aliases)
		{
			value = null;
			return false;
		}

		static bool TryGetOffsetProviderParameter(out ITMPOffsetProvider value, IDictionary<string, string> parameters, ITMPKeywordDatabase keywords, string name, params string[] aliases)
		{
			value = null;
			return false;
		}
	}
}
