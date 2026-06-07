using UnityEngine;

namespace HumanAPI
{
	public class FloatAwayTrigger : LevelObject
	{
		public void OnTriggerExit(Collider other)
		{
			if (base.active)
			{
				HumanBase componentInParent = other.GetComponentInParent<HumanBase>();
				if (componentInParent != null)
				{
					Dependencies.Get<IGame>().Fall(componentInParent, false, false);
				}
			}
		}
	}
}
