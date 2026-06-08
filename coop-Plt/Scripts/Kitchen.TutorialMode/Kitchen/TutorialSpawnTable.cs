using UnityEngine;

namespace Kitchen
{
	public class TutorialSpawnTable : TutorialAction
	{
		public Vector3 Position;

		public Vector3 Facing;

		public TutorialSpawnTable(Vector3 pos, Vector3 facing)
		{
			Position = pos;
			Facing = facing;
		}
	}
}
