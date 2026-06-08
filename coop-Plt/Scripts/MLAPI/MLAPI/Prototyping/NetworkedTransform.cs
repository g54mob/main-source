using System.Collections.Generic;
using MLAPI.Messaging;
using UnityEngine;

namespace MLAPI.Prototyping
{
	[AddComponentMenu("MLAPI/NetworkedTransform")]
	public class NetworkedTransform : NetworkedBehaviour
	{
		internal class ClientSendInfo
		{
			public ulong clientId;

			public float lastSent;

			public Vector3? lastMissedPosition;

			public Quaternion? lastMissedRotation;
		}

		public delegate bool MoveValidationDelegate(Vector3 oldPos, Vector3 newPos);

		[Range(0f, 120f)]
		public float FixedSendsPerSecond = 20f;

		[Tooltip("This assumes that the SendsPerSecond is synced across clients")]
		public bool AssumeSyncedSends = true;

		[Tooltip("This requires AssumeSyncedSends to be true")]
		public bool InterpolatePosition = true;

		[Tooltip("The transform will snap if the distance is greater than this distance")]
		public float SnapDistance = 10f;

		public bool InterpolateServer = true;

		public float MinMeters = 0.15f;

		public float MinDegrees = 1.5f;

		public bool ExtrapolatePosition;

		public float MaxSendsToExtrapolate = 5f;

		[Tooltip("The channel to send the data on. Uses the default channel if left unspecified")]
		public string Channel;

		private float lerpT;

		private Vector3 lerpStartPos;

		private Quaternion lerpStartRot;

		private Vector3 lerpEndPos;

		private Quaternion lerpEndRot;

		private float lastSendTime;

		private Vector3 lastSentPos;

		private Quaternion lastSentRot;

		private float lastReceiveTime;

		public bool EnableRange;

		public bool EnableNonProvokedResendChecks;

		public AnimationCurve DistanceSendrate = AnimationCurve.Constant(0f, 500f, 20f);

		private readonly Dictionary<ulong, ClientSendInfo> clientSendInfo = new Dictionary<ulong, ClientSendInfo>();

		public MoveValidationDelegate IsMoveValidDelegate;

		private void OnValidate()
		{
			if (!AssumeSyncedSends && InterpolatePosition)
			{
				InterpolatePosition = false;
			}
			if (InterpolateServer && !InterpolatePosition)
			{
				InterpolateServer = false;
			}
			if (MinDegrees < 0f)
			{
				MinDegrees = 0f;
			}
			if (MinMeters < 0f)
			{
				MinMeters = 0f;
			}
			if (EnableNonProvokedResendChecks && !EnableRange)
			{
				EnableNonProvokedResendChecks = false;
			}
		}

		private float GetTimeForLerp(Vector3 pos1, Vector3 pos2)
		{
			return 1f / DistanceSendrate.Evaluate(Vector3.Distance(pos1, pos2));
		}

		public override void NetworkStart()
		{
			lastSentRot = base.transform.rotation;
			lastSentPos = base.transform.position;
			lerpStartPos = base.transform.position;
			lerpStartRot = base.transform.rotation;
			lerpEndPos = base.transform.position;
			lerpEndRot = base.transform.rotation;
		}

		private void Update()
		{
			if (base.IsOwner)
			{
				if (NetworkingManager.Singleton.NetworkTime - lastSendTime >= 1f / FixedSendsPerSecond && (Vector3.Distance(base.transform.position, lastSentPos) > MinMeters || Quaternion.Angle(base.transform.rotation, lastSentRot) > MinDegrees))
				{
					lastSendTime = NetworkingManager.Singleton.NetworkTime;
					lastSentPos = base.transform.position;
					lastSentRot = base.transform.rotation;
					if (base.IsServer)
					{
						InvokeClientRpcOnEveryoneExcept(ApplyTransform, base.OwnerClientId, base.transform.position, base.transform.rotation, string.IsNullOrEmpty(Channel) ? "MLAPI_DEFAULT_MESSAGE" : Channel);
					}
					else
					{
						InvokeServerRpc(SubmitTransform, base.transform.position, base.transform.rotation, string.IsNullOrEmpty(Channel) ? "MLAPI_DEFAULT_MESSAGE" : Channel);
					}
				}
			}
			else if ((base.IsServer && InterpolateServer && InterpolatePosition) || (!base.IsServer && InterpolatePosition))
			{
				if (Vector3.Distance(base.transform.position, lerpEndPos) > SnapDistance)
				{
					lerpT = 1f;
				}
				float num = ((base.IsServer || !EnableRange || !AssumeSyncedSends || NetworkingManager.Singleton.ConnectedClients[NetworkingManager.Singleton.LocalClientId].PlayerObject == null) ? (1f / FixedSendsPerSecond) : GetTimeForLerp(base.transform.position, NetworkingManager.Singleton.ConnectedClients[NetworkingManager.Singleton.LocalClientId].PlayerObject.transform.position));
				lerpT += Time.unscaledDeltaTime / num;
				if (ExtrapolatePosition && Time.unscaledTime - lastReceiveTime < num * MaxSendsToExtrapolate)
				{
					base.transform.position = Vector3.LerpUnclamped(lerpStartPos, lerpEndPos, lerpT);
				}
				else
				{
					base.transform.position = Vector3.Lerp(lerpStartPos, lerpEndPos, lerpT);
				}
				if (ExtrapolatePosition && Time.unscaledTime - lastReceiveTime < num * MaxSendsToExtrapolate)
				{
					base.transform.rotation = Quaternion.SlerpUnclamped(lerpStartRot, lerpEndRot, lerpT);
				}
				else
				{
					base.transform.rotation = Quaternion.Slerp(lerpStartRot, lerpEndRot, lerpT);
				}
			}
			if (base.IsServer && EnableRange && EnableNonProvokedResendChecks)
			{
				CheckForMissedSends();
			}
		}

		[ClientRPC]
		private void ApplyTransform(Vector3 position, Quaternion rotation)
		{
			if (base.enabled)
			{
				if (InterpolatePosition && (!base.IsServer || InterpolateServer))
				{
					lastReceiveTime = Time.unscaledTime;
					lerpStartPos = base.transform.position;
					lerpStartRot = base.transform.rotation;
					lerpEndPos = position;
					lerpEndRot = rotation;
					lerpT = 0f;
				}
				else
				{
					base.transform.position = position;
					base.transform.rotation = rotation;
				}
			}
		}

		[ServerRPC]
		private void SubmitTransform(Vector3 position, Quaternion rotation)
		{
			if (!base.enabled || (IsMoveValidDelegate != null && !IsMoveValidDelegate(lerpEndPos, position)))
			{
				return;
			}
			if (!base.IsClient)
			{
				ApplyTransform(position, rotation);
			}
			if (EnableRange)
			{
				for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
				{
					if (!this.clientSendInfo.ContainsKey(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
					{
						this.clientSendInfo.Add(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, new ClientSendInfo
						{
							clientId = NetworkingManager.Singleton.ConnectedClientsList[i].ClientId,
							lastMissedPosition = null,
							lastMissedRotation = null,
							lastSent = 0f
						});
					}
					ClientSendInfo clientSendInfo = this.clientSendInfo[NetworkingManager.Singleton.ConnectedClientsList[i].ClientId];
					Vector3? vector = ((NetworkingManager.Singleton.ConnectedClientsList[i].PlayerObject == null) ? ((Vector3?)null) : new Vector3?(NetworkingManager.Singleton.ConnectedClientsList[i].PlayerObject.transform.position));
					Vector3? vector2 = ((NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject == null) ? ((Vector3?)null) : new Vector3?(NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject.transform.position));
					if (!vector.HasValue || (!vector2.HasValue && NetworkingManager.Singleton.NetworkTime - clientSendInfo.lastSent >= 1f / FixedSendsPerSecond) || NetworkingManager.Singleton.NetworkTime - clientSendInfo.lastSent >= GetTimeForLerp(vector.Value, vector2.Value))
					{
						clientSendInfo.lastSent = NetworkingManager.Singleton.NetworkTime;
						clientSendInfo.lastMissedPosition = null;
						clientSendInfo.lastMissedRotation = null;
						InvokeClientRpcOnClient(ApplyTransform, NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, position, rotation, string.IsNullOrEmpty(Channel) ? "MLAPI_DEFAULT_MESSAGE" : Channel);
					}
					else
					{
						clientSendInfo.lastMissedPosition = position;
						clientSendInfo.lastMissedRotation = rotation;
					}
				}
			}
			else
			{
				InvokeClientRpcOnEveryoneExcept(ApplyTransform, base.OwnerClientId, position, rotation, string.IsNullOrEmpty(Channel) ? "MLAPI_DEFAULT_MESSAGE" : Channel);
			}
		}

		private void CheckForMissedSends()
		{
			for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
			{
				if (!this.clientSendInfo.ContainsKey(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					this.clientSendInfo.Add(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, new ClientSendInfo
					{
						clientId = NetworkingManager.Singleton.ConnectedClientsList[i].ClientId,
						lastMissedPosition = null,
						lastMissedRotation = null,
						lastSent = 0f
					});
				}
				ClientSendInfo clientSendInfo = this.clientSendInfo[NetworkingManager.Singleton.ConnectedClientsList[i].ClientId];
				Vector3? vector = ((NetworkingManager.Singleton.ConnectedClientsList[i].PlayerObject == null) ? ((Vector3?)null) : new Vector3?(NetworkingManager.Singleton.ConnectedClientsList[i].PlayerObject.transform.position));
				Vector3? vector2 = ((NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject == null) ? ((Vector3?)null) : new Vector3?(NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject.transform.position));
				if (!vector.HasValue || (!vector2.HasValue && NetworkingManager.Singleton.NetworkTime - clientSendInfo.lastSent >= 1f / FixedSendsPerSecond) || NetworkingManager.Singleton.NetworkTime - clientSendInfo.lastSent >= GetTimeForLerp(vector.Value, vector2.Value))
				{
					Vector3? vector3 = ((NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject == null) ? ((Vector3?)null) : new Vector3?(NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject.transform.position));
					Quaternion? quaternion = ((NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject == null) ? ((Quaternion?)null) : new Quaternion?(NetworkingManager.Singleton.ConnectedClients[base.OwnerClientId].PlayerObject.transform.rotation));
					if (vector3.HasValue && quaternion.HasValue)
					{
						clientSendInfo.lastSent = NetworkingManager.Singleton.NetworkTime;
						clientSendInfo.lastMissedPosition = null;
						clientSendInfo.lastMissedRotation = null;
						InvokeClientRpcOnClient(ApplyTransform, NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, vector3.Value, quaternion.Value, string.IsNullOrEmpty(Channel) ? "MLAPI_DEFAULT_MESSAGE" : Channel);
					}
				}
			}
		}

		public void Teleport(Vector3 position, Quaternion rotation)
		{
			if ((InterpolateServer && base.IsServer) || base.IsClient)
			{
				lerpStartPos = position;
				lerpStartRot = rotation;
				lerpEndPos = position;
				lerpEndRot = rotation;
				lerpT = 0f;
			}
		}
	}
}
