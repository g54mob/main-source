using System.Collections.Generic;

namespace Assets.Scripts.Craft.Parts
{
	public interface IPartIDChangedListener
	{
		void OnPartIDsRemapped(Dictionary<int, int> idMap);

		void OnPartRemoved(PartData part);
	}
}
