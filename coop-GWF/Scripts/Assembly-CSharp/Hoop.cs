using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class Hoop : NetworkBehaviour
{
	[SerializeField]
	private Transform hoopCenterPosition;

	[SerializeField]
	private MMF_Player registerHoopFb;

	public UnityEvent onHoopRegistered;

	private readonly Dictionary<Item, Vector3> _entryPositions = new Dictionary<Item, Vector3>();

	private void OnTriggerEnter(Collider other)
	{
		if (base.isServer && (bool)other.attachedRigidbody && other.attachedRigidbody.TryGetComponent<Item>(out var component) && (component is Basketball || component is PlayerCarry))
		{
			if (component.transform.position.y < hoopCenterPosition.position.y)
			{
				other.attachedRigidbody.linearVelocity *= 0.3f;
				other.attachedRigidbody.AddForce(Vector3.down * 100f, ForceMode.Acceleration);
			}
			else if (!_entryPositions.ContainsKey(component))
			{
				_entryPositions[component] = component.transform.position;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (base.isServer && (bool)other.attachedRigidbody && other.attachedRigidbody.TryGetComponent<Item>(out var component) && (component is Basketball || component is PlayerCarry) && _entryPositions.TryGetValue(component, out var value))
		{
			if (value.y > hoopCenterPosition.position.y && component.transform.position.y < hoopCenterPosition.position.y)
			{
				RegisterHoop(component);
			}
			_entryPositions.Remove(component);
		}
	}

	private void RegisterHoop(Item item)
	{
		RpcRegisterHoop();
		onHoopRegistered?.Invoke();
	}

	[ClientRpc]
	private void RpcRegisterHoop()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Hoop::RpcRegisterHoop()", -1963564451, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcRegisterHoop()
	{
		registerHoopFb.PlayFeedbacks();
	}

	protected static void InvokeUserCode_RpcRegisterHoop(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRegisterHoop called on server.");
		}
		else
		{
			((Hoop)obj).UserCode_RpcRegisterHoop();
		}
	}

	static Hoop()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(Hoop), "System.Void Hoop::RpcRegisterHoop()", InvokeUserCode_RpcRegisterHoop);
	}
}
