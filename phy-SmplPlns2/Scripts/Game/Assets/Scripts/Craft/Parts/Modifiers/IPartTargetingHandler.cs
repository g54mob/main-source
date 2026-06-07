using System.Collections.Generic;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IPartTargetingHandler
	{
		List<int> GetPartIDs();

		void SetPartIDs(List<int> partIDs);
	}
}
