using System;

namespace Dorfromantik.CreativeMode
{
	[Serializable]
	public class GroupTypeProbability
	{
		public GroupTypeId groupType;

		public float probability;

		public GroupTypeProbability(GroupTypeId groupType, float probability)
		{
			this.groupType = groupType;
			this.probability = probability;
		}
	}
}
