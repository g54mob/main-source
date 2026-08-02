using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.UI;

public class ChatUI : NetworkBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private Text chatHistory;

	[SerializeField]
	private Scrollbar scrollbar;

	[SerializeField]
	private InputField chatMessage;

	[SerializeField]
	private Button sendButton;

	public static string localPlayerName;

	internal static readonly Dictionary<NetworkConnectionToClient, string> connNames;

	public bool isChatActive;

	private bool sendMassage;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && !chatMessage.isFocused)
		{
			Debug.Log("XXXXXXXXXXXXX");
			isChatActive = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			chatMessage.ActivateInputField();
		}
	}

	public override void OnStartServer()
	{
		connNames.Clear();
	}

	public override void OnStartClient()
	{
		chatHistory.text = "";
	}

	[Command(requiresAuthority = false)]
	private void CmdSend(string message, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(message);
		SendCommandInternal("System.Void ChatUI::CmdSend(System.String,Mirror.NetworkConnectionToClient)", -277886924, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcReceive(string playerName, string message)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		writer.WriteString(message);
		SendRPCInternal("System.Void ChatUI::RpcReceive(System.String,System.String)", -1854483185, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void AppendMessage(string message)
	{
		StartCoroutine(AppendAndScroll(message));
	}

	private IEnumerator AppendAndScroll(string message)
	{
		Text text = chatHistory;
		text.text = text.text + message + "\n";
		yield return null;
		yield return null;
		scrollbar.value = 0f;
	}

	public void ExitButtonOnClick()
	{
		NetworkManager.singleton.StopHost();
	}

	public void ToggleButton(string input)
	{
		sendButton.interactable = !string.IsNullOrWhiteSpace(input);
	}

	public void OnEndEdit(string input)
	{
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
		{
			SendMessage();
		}
	}

	public void SendMessage()
	{
		Debug.Log("sdadsadsad");
		if (!string.IsNullOrWhiteSpace(chatMessage.text))
		{
			CmdSend(chatMessage.text.Trim());
			chatMessage.text = string.Empty;
			chatMessage.DeactivateInputField();
		}
	}

	static ChatUI()
	{
		connNames = new Dictionary<NetworkConnectionToClient, string>();
		RemoteProcedureCalls.RegisterCommand(typeof(ChatUI), "System.Void ChatUI::CmdSend(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSend__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ChatUI), "System.Void ChatUI::RpcReceive(System.String,System.String)", InvokeUserCode_RpcReceive__String__String);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSend__String__NetworkConnectionToClient(string message, NetworkConnectionToClient sender)
	{
		if (!connNames.ContainsKey(sender))
		{
			connNames.Add(sender, sender.identity.GetComponent<Player>().playerName);
		}
		if (!string.IsNullOrWhiteSpace(message))
		{
			RpcReceive(connNames[sender], message.Trim());
		}
	}

	protected static void InvokeUserCode_CmdSend__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSend called on client.");
		}
		else
		{
			((ChatUI)obj).UserCode_CmdSend__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	protected void UserCode_RpcReceive__String__String(string playerName, string message)
	{
		string message2 = ((playerName == localPlayerName) ? ("<color=blue>" + playerName + ":</color> " + message) : ("<color=red>" + playerName + ":</color> " + message));
		AppendMessage(message2);
	}

	protected static void InvokeUserCode_RpcReceive__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReceive called on server.");
		}
		else
		{
			((ChatUI)obj).UserCode_RpcReceive__String__String(reader.ReadString(), reader.ReadString());
		}
	}
}
