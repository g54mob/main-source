using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkTransformFollow : NetworkEntityBehaviourBase
{
	public bool disableWhenOwner = true;

	public bool disableWhenKinematic;

	public bool controlRigidbodyInterpolation = true;

	[Space]
	[Min(0f)]
	public float positionInterpolateSpeed = 12f;

	[Min(0f)]
	public float rotationSlerpSpeed = 8f;

	[Space]
	[Min(0f)]
	public float positionSnapDistance = 10f;

	private Transform _transform;

	private Transform _parent;

	private bool _hasProcessed;

	private string _notFollowingName;

	private string _followingName;

	public float speedMultiplier { get; set; } = 1f;

	protected override void OnInitializeBehaviour()
	{
		_transform = base.transform;
		_parent = _transform.parent;
		if (_parent != null)
		{
			_notFollowingName = base.name;
			_followingName = base.name + " (Following " + _parent.name + ")";
		}
		else
		{
			base.enabled = false;
		}
	}

	protected override void OnEntityStart()
	{
		_hasProcessed = false;
		_transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}

	protected override void OnEntityDestroyed()
	{
		if (_parent != null && base.entity.behaviour != null && !base.entity.behaviour.isBeingUnityDestroyed)
		{
			_transform.parent = _parent;
			_transform.localScale = Vector3.one;
		}
		else if (this != null && base.gameObject != null)
		{
			Object.Destroy(base.gameObject);
		}
	}

	[UpdateInGroup(UpdatePriority.Late)]
	protected override void OnUpdatePresentation()
	{
		speedMultiplier = 1f;
		if (ShouldProcess())
		{
			if (!_hasProcessed && controlRigidbodyInterpolation)
			{
				Rigidbody obj2;
				if (base.entity.TryGetObject<PredictedRigidbody>(out var obj))
				{
					obj.predictedRigidbody.interpolation = RigidbodyInterpolation.None;
				}
				else if (base.entity.TryGetObject<Rigidbody>(out obj2) && obj2.isKinematic)
				{
					obj2.interpolation = RigidbodyInterpolation.None;
				}
				_transform.parent = null;
				_transform.localScale = Vector3.one;
				_hasProcessed = true;
				base.name = _followingName;
			}
			_transform.GetPositionAndRotation(out var position, out var rotation);
			_parent.transform.GetPositionAndRotation(out var position2, out var rotation2);
			Vector3 vector = position2 - position;
			if (vector.sqrMagnitude < positionSnapDistance * positionSnapDistance)
			{
				float magnitude = vector.magnitude;
				position2 = Vector3.MoveTowards(position, position2, magnitude * positionInterpolateSpeed * Time.deltaTime * speedMultiplier);
			}
			rotation2 = Quaternion.Slerp(rotation, rotation2, rotationSlerpSpeed * Time.deltaTime * speedMultiplier).normalized;
			_transform.SetPositionAndRotation(position2, rotation2);
		}
		else if (_hasProcessed)
		{
			Rigidbody obj4;
			if (base.entity.TryGetObject<PredictedRigidbody>(out var obj3))
			{
				obj3.predictedRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
			}
			else if (base.entity.TryGetObject<Rigidbody>(out obj4) && obj4.isKinematic)
			{
				obj4.interpolation = RigidbodyInterpolation.Interpolate;
			}
			_transform.parent = _parent;
			_transform.localScale = Vector3.one;
			_transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			_hasProcessed = false;
			base.name = _notFollowingName;
		}
	}

	private bool ShouldProcess()
	{
		if (disableWhenKinematic)
		{
			Rigidbody obj2;
			if (base.entity.TryGetObject<PredictedRigidbody>(out var obj))
			{
				if (obj.predictedRigidbody.isKinematic)
				{
					return false;
				}
			}
			else if (base.entity.TryGetObject<Rigidbody>(out obj2) && obj2.isKinematic)
			{
				return false;
			}
		}
		if (disableWhenOwner)
		{
			if (!base.entity.TryGetObject<NetworkIdentity>(out var obj3))
			{
				return false;
			}
			if (obj3.isOwned)
			{
				return false;
			}
			if (obj3.connectionToClient == null && NetworkServer.active)
			{
				return false;
			}
		}
		return true;
	}

	[Server]
	public void ServerTeleported()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkTransformFollow::ServerTeleported()' called when server was not active");
		}
		else
		{
			RpcTeleported();
		}
	}

	[ClientRpc]
	private void RpcTeleported()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkTransformFollow::RpcTeleported()", 1398845099, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcTeleported()
	{
		if (!base.isServer)
		{
			if (_hasProcessed)
			{
				_parent.transform.GetPositionAndRotation(out var position, out var rotation);
				_transform.SetPositionAndRotation(position, rotation);
			}
			else
			{
				_transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
		}
	}

	protected static void InvokeUserCode_RpcTeleported(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTeleported called on server.");
		}
		else
		{
			((NetworkTransformFollow)obj).UserCode_RpcTeleported();
		}
	}

	static NetworkTransformFollow()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkTransformFollow), "System.Void NetworkTransformFollow::RpcTeleported()", InvokeUserCode_RpcTeleported);
	}
}
