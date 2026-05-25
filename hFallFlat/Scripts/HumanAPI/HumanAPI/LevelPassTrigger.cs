using UnityEngine;

namespace HumanAPI
{
	[AddComponentMenu("Human/Level/Level Pass Trigger", 10)]
	public class LevelPassTrigger : LevelObject
	{
		public void OnTriggerEnter(Collider other)
		{
			if (base.active && !(other.tag != "Player"))
			{
				Dependencies.Get<IGame>().EnterPassZone();
			}
		}
	}
}
