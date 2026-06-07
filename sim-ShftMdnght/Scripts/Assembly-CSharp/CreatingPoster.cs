using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

public class CreatingPoster : NetworkBehaviour
{
	public MeshRenderer posterMesh;

	public Material[] posterStyles;

	public int posterStyleIndex;

	public TextMeshProUGUI[] finalTexts;

	public TextMeshProUGUI tempText;

	public bool creating;

	public GameObject cam;

	public Interactable pickupObj;

	public PlayerManager curPlayerMan;

	public SaveSnapshotObject saveSnapshotObj;

	public DecorObject decorObject;

	public AudioSource completePosterSfx;

	public void StartCreating(PlayerManager pMan)
	{
		SpeakingManager.Instance.ignoreClicks = true;
		Material[] materials = posterMesh.materials;
		materials[0] = posterStyles[0];
		posterMesh.materials = materials;
		ClientPlayer.Instance.playerMan.canPause = false;
		curPlayerMan = pMan;
		creating = true;
		Creating();
		cam.SetActive(value: true);
	}

	private void Creating()
	{
		if (creating)
		{
			ClientPlayer.Instance.fpsScript.UnlockCursor();
			ClientPlayer.Instance.fpsScript.lockCam = true;
			ClientPlayer.Instance.fpsScript.lockMove = true;
			Invoke("Creating", 1f);
		}
	}

	public void ChangePosterStyle(bool forward)
	{
		if (forward)
		{
			posterStyleIndex++;
		}
		else
		{
			posterStyleIndex--;
		}
		if (posterStyleIndex < 0)
		{
			posterStyleIndex = posterStyles.Length - 1;
		}
		else if (posterStyleIndex >= posterStyles.Length)
		{
			posterStyleIndex = 0;
		}
		Material[] materials = posterMesh.materials;
		materials[0] = posterStyles[posterStyleIndex];
		posterMesh.materials = materials;
		for (int i = 0; i < posterStyles.Length; i++)
		{
			if (i == posterStyleIndex)
			{
				finalTexts[i].gameObject.SetActive(value: true);
			}
			else
			{
				finalTexts[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void UpdatePosterText()
	{
		Invoke("ActuallyUpdatePosterText", 0.1f);
	}

	private void ActuallyUpdatePosterText()
	{
		TextMeshProUGUI[] array = finalTexts;
		foreach (TextMeshProUGUI obj in array)
		{
			obj.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			obj.text = tempText.text;
		}
	}

	public void ConfirmPoster()
	{
		SpeakingManager.Instance.ignoreClicks = false;
		if (base.isServer)
		{
			ConfirmPosterRpc(posterStyleIndex, tempText.text);
			pickupObj.ChangeInteractableStatusRpc(change: true);
		}
		else
		{
			ConfirmPosterCmd(posterStyleIndex, tempText.text);
			pickupObj.ChangeInteractableStatusCmd(change: true);
		}
	}

	[Command(requiresAuthority = false)]
	private void ConfirmPosterCmd(int posterStyle, string text)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(posterStyle);
		writer.WriteString(text);
		SendCommandInternal("System.Void CreatingPoster::ConfirmPosterCmd(System.Int32,System.String)", 1706878483, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ConfirmPosterRpc(int posterStyle, string text)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(posterStyle);
		writer.WriteString(text);
		SendRPCInternal("System.Void CreatingPoster::ConfirmPosterRpc(System.Int32,System.String)", -945479084, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void LoadPosterRpc(string savedString)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(savedString);
		SendRPCInternal("System.Void CreatingPoster::LoadPosterRpc(System.String)", -1232664651, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ConfirmPosterCmd__Int32__String(int posterStyle, string text)
	{
		ConfirmPosterRpc(posterStyle, text);
	}

	protected static void InvokeUserCode_ConfirmPosterCmd__Int32__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ConfirmPosterCmd called on client.");
		}
		else
		{
			((CreatingPoster)obj).UserCode_ConfirmPosterCmd__Int32__String(reader.ReadVarInt(), reader.ReadString());
		}
	}

	protected void UserCode_ConfirmPosterRpc__Int32__String(int posterStyle, string text)
	{
		decorObject.IncreaseParticles();
		completePosterSfx.Play();
		finalTexts[posterStyle].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		finalTexts[posterStyle].text = text;
		finalTexts[posterStyle].gameObject.SetActive(value: true);
		Material[] materials = posterMesh.materials;
		materials[0] = posterStyles[posterStyle];
		posterMesh.materials = materials;
		creating = false;
		cam.SetActive(value: false);
		saveSnapshotObj.associatedString = posterStyle + text;
		if (curPlayerMan == ClientPlayer.Instance.playerMan)
		{
			curPlayerMan.canPause = true;
			curPlayerMan.fpsScript.LockCursor();
			curPlayerMan.fpsScript.lockCam = false;
			curPlayerMan.fpsScript.lockMove = false;
		}
	}

	protected static void InvokeUserCode_ConfirmPosterRpc__Int32__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ConfirmPosterRpc called on server.");
		}
		else
		{
			((CreatingPoster)obj).UserCode_ConfirmPosterRpc__Int32__String(reader.ReadVarInt(), reader.ReadString());
		}
	}

	protected void UserCode_LoadPosterRpc__String(string savedString)
	{
		pickupObj.ChangeInteractableStatusRpc(change: true);
		int num = int.Parse(savedString[0].ToString());
		string text = savedString.Substring(1);
		finalTexts[num].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		finalTexts[num].text = text;
		finalTexts[num].gameObject.SetActive(value: true);
		Material[] materials = posterMesh.materials;
		materials[0] = posterStyles[num];
		posterMesh.materials = materials;
		saveSnapshotObj.associatedString = num + text;
	}

	protected static void InvokeUserCode_LoadPosterRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC LoadPosterRpc called on server.");
		}
		else
		{
			((CreatingPoster)obj).UserCode_LoadPosterRpc__String(reader.ReadString());
		}
	}

	static CreatingPoster()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(CreatingPoster), "System.Void CreatingPoster::ConfirmPosterCmd(System.Int32,System.String)", InvokeUserCode_ConfirmPosterCmd__Int32__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(CreatingPoster), "System.Void CreatingPoster::ConfirmPosterRpc(System.Int32,System.String)", InvokeUserCode_ConfirmPosterRpc__Int32__String);
		RemoteProcedureCalls.RegisterRpc(typeof(CreatingPoster), "System.Void CreatingPoster::LoadPosterRpc(System.String)", InvokeUserCode_LoadPosterRpc__String);
	}
}
