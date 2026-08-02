using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TrainArrivedLabChecker : NetworkBehaviour
{
	[SerializeField]
	private string fallbackMessage = "Labovatuara vardınız";

	private Collider triggerCollider;

	private bool triggered;

	public float messageDisplayDuration = 10f;

	private void Awake()
	{
		triggerCollider = GetComponent<Collider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (base.isServer && !triggered)
		{
			TrainController component;
			bool flag = other.TryGetComponent<TrainController>(out component);
			bool flag2 = other.GetComponentInParent<TrainController>() != null;
			Debug.Log($"[LabChecker] TriggerEnter: {other.gameObject.name} | root: {other.transform.root.name} | TrainController(direct)={flag} | TrainController(parent)={flag2}");
			if (flag || flag2)
			{
				triggered = true;
				triggerCollider.enabled = false;
				RpcShowMessage();
			}
		}
	}

	[ClientRpc]
	private void RpcShowMessage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainArrivedLabChecker::RpcShowMessage()", 153479127, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcShowMessage()
	{
		if (Singleton<UserMessagePanelCenter>.Instance != null)
		{
			Singleton<UserMessagePanelCenter>.Instance.SendMessageToPanel(fallbackMessage, messageDisplayDuration);
		}
	}

	protected static void InvokeUserCode_RpcShowMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowMessage called on server.");
		}
		else
		{
			((TrainArrivedLabChecker)obj).UserCode_RpcShowMessage();
		}
	}

	static TrainArrivedLabChecker()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(TrainArrivedLabChecker), "System.Void TrainArrivedLabChecker::RpcShowMessage()", InvokeUserCode_RpcShowMessage);
	}
}
