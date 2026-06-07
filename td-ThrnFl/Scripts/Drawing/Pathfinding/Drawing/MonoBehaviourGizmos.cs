using UnityEngine;

namespace Pathfinding.Drawing
{
	public abstract class MonoBehaviourGizmos : MonoBehaviour, IDrawGizmos
	{
		public MonoBehaviourGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public virtual void DrawGizmos()
		{
		}
	}
}
