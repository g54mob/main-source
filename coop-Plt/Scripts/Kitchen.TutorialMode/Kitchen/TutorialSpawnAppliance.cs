using UnityEngine;

namespace Kitchen
{
	public class TutorialSpawnAppliance : TutorialAction
	{
		public int ApplianceOrItem;

		public Vector3 Position;

		public Vector3 Facing;

		public bool IsProvider;

		public TutorialSpawnAppliance(int appliance_or_item, Vector3 pos, Vector3 facing, bool is_provider = false)
		{
			ApplianceOrItem = appliance_or_item;
			Position = pos;
			Facing = facing;
			IsProvider = is_provider;
		}
	}
}
