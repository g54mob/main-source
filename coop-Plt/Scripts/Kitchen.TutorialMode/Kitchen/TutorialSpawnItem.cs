using UnityEngine;

namespace Kitchen
{
	public class TutorialSpawnItem : TutorialAction
	{
		public int ItemGroup;

		public Vector3 Position;

		public TutorialSpawnItem(int group, Vector3 position)
		{
			ItemGroup = group;
			Position = position;
		}
	}
}
