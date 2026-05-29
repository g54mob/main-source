using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using Workbench.Wolfsbane.Multiplayer;

namespace Civil
{
	public class NPCAnimator : MonoBehaviour
	{
		private static readonly int SpeedHash;

		[SerializeField]
		private Animator m_Animator;

		[SerializeField]
		private NavMeshAgent m_Agent;

		private NetworkedAnimation m_NetworkedAnimation;

		private PhotonView m_PhotonView;

		private bool m_Bending;

		public PhotonView PhotonView => null;

		public NetworkedAnimation NetworkedAnimation => null;

		public void ManualUpdate()
		{
		}

		public void StopAnimation()
		{
		}

		public void SetSpeedManually(float value)
		{
		}

		public float GetAnimationSpeed()
		{
			return 0f;
		}

		public void PickUpProductFromVending()
		{
		}

		public void PushVendingButton()
		{
		}

		public void FinishAnimation(bool standUp)
		{
		}

		public void SetAnimator(Animator animator)
		{
		}
	}
}
