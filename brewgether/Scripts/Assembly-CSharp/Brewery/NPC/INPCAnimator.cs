using UnityEngine;

namespace Brewery.NPC
{
	public interface INPCAnimator
	{
		void SetDead(bool isDead);

		void SetStagger(bool isStaggered);

		void TriggerHitReaction(int direction);

		static int CalculateHitDirection(Transform npcTransform, Vector3 attackerPosition)
		{
			return 0;
		}
	}
}
