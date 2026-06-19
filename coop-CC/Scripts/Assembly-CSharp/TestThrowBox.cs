using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestThrowBox : NetworkEntityBehaviourBase
{
	protected override void OnUpdatePresentation()
	{
		if ((!base.isServer || Application.isEditor) && Keyboard.current.yKey.wasPressedThisFrame)
		{
			base.entity.rigidbody.AddForce(new Vector3(1f, 1f, 0f).normalized * 10f, ForceMode.Impulse);
			if (!base.isServer)
			{
				CmdAddForce();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddForce()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TestThrowBox::CmdAddForce()", -1628126862, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddForce()
	{
		base.entity.rigidbody.AddForce(new Vector3(1f, 1f, 0f).normalized * 10f, ForceMode.Impulse);
	}

	protected static void InvokeUserCode_CmdAddForce(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddForce called on client.");
		}
		else
		{
			((TestThrowBox)obj).UserCode_CmdAddForce();
		}
	}

	static TestThrowBox()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TestThrowBox), "System.Void TestThrowBox::CmdAddForce()", InvokeUserCode_CmdAddForce, requiresAuthority: false);
	}
}
