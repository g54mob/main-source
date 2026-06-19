using UnityEngine;

namespace Aggro.Core
{
	public class EnititySpawnOrientation : EntityBehaviourBase
	{
		public bool stickTypeWeapon;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.up);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.right);
		}
	}
}
