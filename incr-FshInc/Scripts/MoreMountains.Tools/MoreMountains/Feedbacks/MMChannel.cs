using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[CreateAssetMenu(menuName = "MoreMountains/MMChannel", fileName = "MMChannel")]
	public class MMChannel : ScriptableObject
	{
		public static bool Match(MMChannelData dataA, MMChannelData dataB)
		{
			if (dataA.MMChannelMode != dataB.MMChannelMode)
			{
				return false;
			}
			if (dataA.MMChannelMode == MMChannelModes.Int)
			{
				return dataA.Channel == dataB.Channel;
			}
			return dataA.MMChannelDefinition == dataB.MMChannelDefinition;
		}

		public static bool Match(MMChannelData dataA, MMChannelModes modeB, int channelB, MMChannel channelDefinitionB)
		{
			if (dataA == null)
			{
				return true;
			}
			if (dataA.MMChannelMode != modeB)
			{
				return false;
			}
			if (dataA.MMChannelMode == MMChannelModes.Int)
			{
				return dataA.Channel == channelB;
			}
			return dataA.MMChannelDefinition == channelDefinitionB;
		}
	}
}
