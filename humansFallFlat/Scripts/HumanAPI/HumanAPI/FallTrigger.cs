using UnityEngine;
using UnityEngine.Events;

namespace HumanAPI
{
	[AddComponentMenu("Human/Level/Fall Trigger", 10)]
	public class FallTrigger : LevelObject
	{
		public bool fallAchievement = true;

		public UnityEvent OnFall;

		public void OnTriggerEnter(Collider other)
		{
			if (base.active)
			{
				HumanBase componentInParent = other.GetComponentInParent<HumanBase>();
				if (componentInParent != null)
				{
					Dependencies.Get<IGame>().Fall(componentInParent, false, fallAchievement);
					OnFall.Invoke();
				}
			}
		}
	}
}
