using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror
{
	public class NetworkAnimator : NetworkBehaviour
	{
		public bool clientAuthority;

		public Animator animator;

		[SyncVar]
		private float animatorSpeed;

		private float previousSpeed;

		private int[] lastIntParameters;

		private float[] lastFloatParameters;

		private bool[] lastBoolParameters;

		private AnimatorControllerParameter[] parameters;

		private int[] animationHash;

		private int[] transitionHash;

		private float[] layerWeight;

		private float nextSendTime;

		private bool SendMessagesAllowed => false;

		public float NetworkanimatorSpeed
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		private void CheckSpeed()
		{
		}

		private void CmdSetAnimatorSpeed(float newSpeed)
		{
		}

		private void OnAnimatorSpeedChanged(float _, float value)
		{
		}

		private bool CheckAnimStateChanged(out int stateHash, out float normalizedTime, int layerId)
		{
			stateHash = default(int);
			normalizedTime = default(float);
			return false;
		}

		private void CheckSendRate()
		{
		}

		private void SendAnimationMessage(int stateHash, float normalizedTime, int layerId, float weight, byte[] parameters)
		{
		}

		private void SendAnimationParametersMessage(byte[] parameters)
		{
		}

		private void HandleAnimMsg(int stateHash, float normalizedTime, int layerId, float weight, NetworkReader reader)
		{
		}

		private void HandleAnimParamsMsg(NetworkReader reader)
		{
		}

		private void HandleAnimTriggerMsg(int hash)
		{
		}

		private void HandleAnimResetTriggerMsg(int hash)
		{
		}

		private ulong NextDirtyBits()
		{
			return 0uL;
		}

		private bool WriteParameters(NetworkWriter writer, bool forceAll = false)
		{
			return false;
		}

		private void ReadParameters(NetworkReader reader)
		{
		}

		public override bool OnSerialize(NetworkWriter writer, bool initialState)
		{
			return false;
		}

		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
		}

		public void SetTrigger(string triggerName)
		{
		}

		public void SetTrigger(int hash)
		{
		}

		public void ResetTrigger(string triggerName)
		{
		}

		public void ResetTrigger(int hash)
		{
		}

		[Command]
		private void CmdOnAnimationServerMessage(int stateHash, float normalizedTime, int layerId, float weight, byte[] parameters)
		{
		}

		[Command]
		private void CmdOnAnimationParametersServerMessage(byte[] parameters)
		{
		}

		[Command]
		private void CmdOnAnimationTriggerServerMessage(int hash)
		{
		}

		[Command]
		private void CmdOnAnimationResetTriggerServerMessage(int hash)
		{
		}

		[ClientRpc]
		private void RpcOnAnimationClientMessage(int stateHash, float normalizedTime, int layerId, float weight, byte[] parameters)
		{
		}

		[ClientRpc]
		private void RpcOnAnimationParametersClientMessage(byte[] parameters)
		{
		}

		[ClientRpc]
		private void RpcOnAnimationTriggerClientMessage(int hash)
		{
		}

		[ClientRpc]
		private void RpcOnAnimationResetTriggerClientMessage(int hash)
		{
		}

		private void MirrorProcessed()
		{
		}

		private void UserCode_CmdOnAnimationServerMessage(int stateHash, float normalizedTime, int layerId, float weight, byte[] parameters)
		{
		}

		protected static void InvokeUserCode_CmdOnAnimationServerMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdOnAnimationParametersServerMessage(byte[] parameters)
		{
		}

		protected static void InvokeUserCode_CmdOnAnimationParametersServerMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdOnAnimationTriggerServerMessage(int hash)
		{
		}

		protected static void InvokeUserCode_CmdOnAnimationTriggerServerMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_CmdOnAnimationResetTriggerServerMessage(int hash)
		{
		}

		protected static void InvokeUserCode_CmdOnAnimationResetTriggerServerMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcOnAnimationClientMessage(int stateHash, float normalizedTime, int layerId, float weight, byte[] parameters)
		{
		}

		protected static void InvokeUserCode_RpcOnAnimationClientMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcOnAnimationParametersClientMessage(byte[] parameters)
		{
		}

		protected static void InvokeUserCode_RpcOnAnimationParametersClientMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcOnAnimationTriggerClientMessage(int hash)
		{
		}

		protected static void InvokeUserCode_RpcOnAnimationTriggerClientMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		private void UserCode_RpcOnAnimationResetTriggerClientMessage(int hash)
		{
		}

		protected static void InvokeUserCode_RpcOnAnimationResetTriggerClientMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NetworkAnimator()
		{
		}

		public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			return false;
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
