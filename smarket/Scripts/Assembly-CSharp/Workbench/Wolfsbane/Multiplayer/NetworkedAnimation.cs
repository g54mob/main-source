using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace Workbench.Wolfsbane.Multiplayer
{
	public class NetworkedAnimation : MonoBehaviourPunCallbacks
	{
		[SerializeField]
		private Animator anim;

		public const byte PlayAnimationEventCode = 1;

		public override void OnEnable()
		{
		}

		public void SetAnimator(Animator _anim)
		{
		}

		public override void OnDisable()
		{
		}

		private void OnEvent(EventData photonEvent)
		{
		}

		public void SendPlayAnimationEvent(int photonViewID, string animatorParameter, string parameterType, object parameterValue = null)
		{
		}
	}
}
