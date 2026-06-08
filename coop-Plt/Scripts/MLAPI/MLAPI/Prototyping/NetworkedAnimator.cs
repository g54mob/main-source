using System.Collections.Generic;
using System.IO;
using MLAPI.Connection;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.Serialization.Pooled;
using UnityEngine;

namespace MLAPI.Prototyping
{
	[AddComponentMenu("MLAPI/NetworkedAnimator")]
	public class NetworkedAnimator : NetworkedBehaviour
	{
		public bool EnableProximity;

		public float ProximityRange = 50f;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private uint parameterSendBits;

		[SerializeField]
		private readonly float sendRate = 0.1f;

		private AnimatorControllerParameter[] animatorParameters;

		private int animationHash;

		private int transitionHash;

		private float sendTimer;

		public string param0;

		public string param1;

		public string param2;

		public string param3;

		public string param4;

		public string param5;

		public Animator animator
		{
			get
			{
				return _animator;
			}
			set
			{
				_animator = value;
				ResetParameterOptions();
			}
		}

		public void SetParameterAutoSend(int index, bool value)
		{
			if (value)
			{
				parameterSendBits |= (uint)(1 << index);
			}
			else
			{
				parameterSendBits &= (uint)(~(1 << index));
			}
		}

		public bool GetParameterAutoSend(int index)
		{
			return (parameterSendBits & (uint)(1 << index)) != 0;
		}

		public void ResetParameterOptions()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogInfo("ResetParameterOptions");
			}
			parameterSendBits = 0u;
			animatorParameters = null;
		}

		private void FixedUpdate()
		{
			if (!base.IsOwner)
			{
				return;
			}
			CheckSendRate();
			if (!CheckAnimStateChanged(out var stateHash, out var normalizedTime))
			{
				return;
			}
			using PooledBitStream stream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteInt32Packed(stateHash);
			pooledBitWriter.WriteSinglePacked(normalizedTime);
			WriteParameters(stream, autoSend: false);
			if (base.IsServer)
			{
				if (EnableProximity)
				{
					List<ulong> list = new List<ulong>();
					foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
					{
						if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
						{
							list.Add(connectedClient.Key);
						}
					}
					InvokeClientRpcPerformance(ApplyAnimParamMsg, list, stream);
				}
				else
				{
					InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimMsg, base.OwnerClientId, stream);
				}
			}
			else
			{
				InvokeServerRpcPerformance(SubmitAnimMsg, stream);
			}
		}

		private bool CheckAnimStateChanged(out int stateHash, out float normalizedTime)
		{
			stateHash = 0;
			normalizedTime = 0f;
			if (animator.IsInTransition(0))
			{
				AnimatorTransitionInfo animatorTransitionInfo = animator.GetAnimatorTransitionInfo(0);
				if (animatorTransitionInfo.fullPathHash != transitionHash)
				{
					transitionHash = animatorTransitionInfo.fullPathHash;
					animationHash = 0;
					return true;
				}
				return false;
			}
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.fullPathHash != animationHash)
			{
				if (animationHash != 0)
				{
					stateHash = currentAnimatorStateInfo.fullPathHash;
					normalizedTime = currentAnimatorStateInfo.normalizedTime;
				}
				transitionHash = 0;
				animationHash = currentAnimatorStateInfo.fullPathHash;
				return true;
			}
			return false;
		}

		private void CheckSendRate()
		{
			if (!base.IsOwner || sendRate == 0f || !(sendTimer < NetworkingManager.Singleton.NetworkTime))
			{
				return;
			}
			sendTimer = NetworkingManager.Singleton.NetworkTime + sendRate;
			using PooledBitStream stream = PooledBitStream.Get();
			using (PooledBitWriter.Get(stream))
			{
				WriteParameters(stream, autoSend: true);
				if (base.IsServer)
				{
					if (EnableProximity)
					{
						List<ulong> list = new List<ulong>();
						foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
						{
							if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
							{
								list.Add(connectedClient.Key);
							}
						}
						InvokeClientRpcPerformance(ApplyAnimParamMsg, list, stream);
					}
					else
					{
						InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimParamMsg, base.OwnerClientId, stream);
					}
				}
				else
				{
					InvokeServerRpcPerformance(SubmitAnimParamMsg, stream);
				}
			}
		}

		private void SetSendTrackingParam(string p, int i)
		{
			p = "Sent Param: " + p;
			if (i == 0)
			{
				param0 = p;
			}
			if (i == 1)
			{
				param1 = p;
			}
			if (i == 2)
			{
				param2 = p;
			}
			if (i == 3)
			{
				param3 = p;
			}
			if (i == 4)
			{
				param4 = p;
			}
			if (i == 5)
			{
				param5 = p;
			}
		}

		private void SetRecvTrackingParam(string p, int i)
		{
			p = "Recv Param: " + p;
			if (i == 0)
			{
				param0 = p;
			}
			if (i == 1)
			{
				param1 = p;
			}
			if (i == 2)
			{
				param2 = p;
			}
			if (i == 3)
			{
				param3 = p;
			}
			if (i == 4)
			{
				param4 = p;
			}
			if (i == 5)
			{
				param5 = p;
			}
		}

		[ServerRPC]
		private void SubmitAnimMsg(ulong clientId, Stream stream)
		{
			if (EnableProximity)
			{
				List<ulong> list = new List<ulong>();
				foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
				{
					if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
					{
						list.Add(connectedClient.Key);
					}
				}
				InvokeClientRpcPerformance(ApplyAnimMsg, list, stream);
			}
			else
			{
				InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimMsg, base.OwnerClientId, stream);
			}
		}

		[ClientRPC]
		private void ApplyAnimMsg(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			int num = pooledBitReader.ReadInt32Packed();
			float normalizedTime = pooledBitReader.ReadSinglePacked();
			if (num != 0)
			{
				animator.Play(num, 0, normalizedTime);
			}
			ReadParameters(stream, autoSend: false);
		}

		[ServerRPC]
		private void SubmitAnimParamMsg(ulong clientId, Stream stream)
		{
			if (EnableProximity)
			{
				List<ulong> list = new List<ulong>();
				foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
				{
					if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
					{
						list.Add(connectedClient.Key);
					}
				}
				InvokeClientRpcPerformance(ApplyAnimParamMsg, list, stream);
			}
			else
			{
				InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimParamMsg, base.OwnerClientId, stream);
			}
		}

		[ClientRPC]
		private void ApplyAnimParamMsg(ulong clientId, Stream stream)
		{
			ReadParameters(stream, autoSend: true);
		}

		[ServerRPC]
		private void SubmitAnimTriggerMsg(ulong clientId, Stream stream)
		{
			if (EnableProximity)
			{
				List<ulong> list = new List<ulong>();
				foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
				{
					if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
					{
						list.Add(connectedClient.Key);
					}
				}
				InvokeClientRpcPerformance(ApplyAnimTriggerMsg, list, stream);
			}
			else
			{
				InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimTriggerMsg, base.OwnerClientId, stream);
			}
		}

		[ClientRPC]
		private void ApplyAnimTriggerMsg(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			animator.SetTrigger(pooledBitReader.ReadInt32Packed());
		}

		private void WriteParameters(Stream stream, bool autoSend)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			if (animatorParameters == null)
			{
				animatorParameters = animator.parameters;
			}
			for (int i = 0; i < animatorParameters.Length; i++)
			{
				if (!autoSend || GetParameterAutoSend(i))
				{
					AnimatorControllerParameter animatorControllerParameter = animatorParameters[i];
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
					{
						pooledBitWriter.WriteUInt32Packed((uint)animator.GetInteger(animatorControllerParameter.nameHash));
						SetSendTrackingParam(animatorControllerParameter.name + ":" + animator.GetInteger(animatorControllerParameter.nameHash), i);
					}
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Float)
					{
						pooledBitWriter.WriteSinglePacked(animator.GetFloat(animatorControllerParameter.nameHash));
						SetSendTrackingParam(animatorControllerParameter.name + ":" + animator.GetFloat(animatorControllerParameter.nameHash), i);
					}
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Bool)
					{
						pooledBitWriter.WriteBool(animator.GetBool(animatorControllerParameter.nameHash));
						SetSendTrackingParam(animatorControllerParameter.name + ":" + animator.GetBool(animatorControllerParameter.nameHash), i);
					}
				}
			}
		}

		private void ReadParameters(Stream stream, bool autoSend)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			if (animatorParameters == null)
			{
				animatorParameters = animator.parameters;
			}
			for (int i = 0; i < animatorParameters.Length; i++)
			{
				if (!autoSend || GetParameterAutoSend(i))
				{
					AnimatorControllerParameter animatorControllerParameter = animatorParameters[i];
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
					{
						int num = (int)pooledBitReader.ReadUInt32Packed();
						animator.SetInteger(animatorControllerParameter.nameHash, num);
						SetRecvTrackingParam(animatorControllerParameter.name + ":" + num, i);
					}
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Float)
					{
						float num2 = pooledBitReader.ReadSinglePacked();
						animator.SetFloat(animatorControllerParameter.nameHash, num2);
						SetRecvTrackingParam(animatorControllerParameter.name + ":" + num2, i);
					}
					if (animatorControllerParameter.type == AnimatorControllerParameterType.Bool)
					{
						bool value = pooledBitReader.ReadBool();
						animator.SetBool(animatorControllerParameter.nameHash, value);
						SetRecvTrackingParam(animatorControllerParameter.name + ":" + value, i);
					}
				}
			}
		}

		public void SetTrigger(string triggerName)
		{
			SetTrigger(Animator.StringToHash(triggerName));
		}

		public void SetTrigger(int hash)
		{
			if (!base.IsOwner)
			{
				return;
			}
			using PooledBitStream stream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteInt32Packed(hash);
			if (base.IsServer)
			{
				if (EnableProximity)
				{
					List<ulong> list = new List<ulong>();
					foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
					{
						if (connectedClient.Value.PlayerObject == null || Vector3.Distance(base.transform.position, connectedClient.Value.PlayerObject.transform.position) <= ProximityRange)
						{
							list.Add(connectedClient.Key);
						}
					}
					InvokeClientRpcPerformance(ApplyAnimTriggerMsg, list, stream);
				}
				else
				{
					InvokeClientRpcOnEveryoneExceptPerformance(ApplyAnimTriggerMsg, base.OwnerClientId, stream);
				}
			}
			else
			{
				InvokeServerRpcPerformance(SubmitAnimTriggerMsg, stream);
			}
		}
	}
}
