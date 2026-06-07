using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public interface IRagdollAnimator2Receiver
	{
		void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision);
	}
}
