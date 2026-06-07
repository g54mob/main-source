using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ClydeDeathCutscene : NetworkBehaviour
{
	public Transform clydeHolder;

	public Animator clydeAnim;

	public Transform player;

	public PlayerManager playerMan;

	public AudioSource[] audioSequence;

	public int audioIndex;

	public StoreBrowseBehaviour browseScript;

	public Hittable hittable;

	public CharacterDeathMemory charDeathMemory;

	public GameObject cctvCam;

	public Volume globalVolume;

	public VolumeProfile normalProfile;

	public VolumeProfile cctvProfile;

	public TextMeshProUGUI clydeText;

	public void Start()
	{
		List<Volume> list = (from v in Object.FindObjectsOfType<Volume>(includeInactive: true)
			where v.isGlobal
			orderby v.priority descending
			select v).ToList();
		globalVolume = list[0];
		globalVolume.profile = Object.Instantiate(cctvProfile);
		cctvCam = GameObject.FindWithTag("CCTV").transform.GetChild(0).gameObject;
		cctvCam.SetActive(value: true);
		playerMan = ClientPlayer.Instance.playerMan;
		ClientPlayer.Instance.inventoryMan.PauseInventory();
		playerMan.canPause = false;
		ClientPlayer.Instance.inventoryMan.canControlItem = false;
		player = playerMan.transform;
		playerMan.fpsScript.lockMove = true;
		playerMan.fpsScript.lockCam = true;
		playerMan.canvas.SetActive(value: false);
		StoreManager.Instance.canvas.SetActive(value: false);
		SpeakingManager.Instance.enabled = false;
		Invoke("RelockMovement", 1f);
		Invoke("PlayDialogue", 5.4f);
		Invoke("PlayerBoredAnim", 5f);
		Invoke("StopBrowseScript", 5.2f);
		Invoke("PlayDialogue2", 7.5f);
		Invoke("PlayNextAudio", 8.7f);
		Invoke("PlayNextAudio", 8.95f);
		Invoke("PlayNextAudio", 9.2f);
		Invoke("PlayNextAudio", 9.45f);
		Invoke("PlayNextAudio", 9.95f);
		Invoke("PlayNextAudio", 10.45f);
		Invoke("Die", 11f);
		if (browseScript.dialogueInteractable.isServer)
		{
			browseScript.dialogueInteractable.ChangeInteractableStatusRpc(change: false);
		}
		else
		{
			browseScript.dialogueInteractable.ChangeInteractableStatusCmd(change: false);
		}
		StoreManager.Instance.EnterCutscene();
	}

	private void PlayerBoredAnim()
	{
		TriggerAnim("ClydeLeanIn");
	}

	private void PlayerShootAnim()
	{
		TriggerAnim("Pistol Walk Backward");
	}

	public void TriggerAnim(string trigger)
	{
		if (base.isServer)
		{
			TriggerAnimRpc(trigger);
		}
		else
		{
			TriggerAnimCmd(trigger);
		}
	}

	[Command(requiresAuthority = false)]
	public void TriggerAnimCmd(string trigger)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(trigger);
		SendCommandInternal("System.Void ClydeDeathCutscene::TriggerAnimCmd(System.String)", -1879030007, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void TriggerAnimRpc(string trigger)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(trigger);
		SendRPCInternal("System.Void ClydeDeathCutscene::TriggerAnimRpc(System.String)", 364498896, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void RelockMovement()
	{
		playerMan.fpsScript.lockMove = true;
		playerMan.fpsScript.lockCam = true;
	}

	private void StopBrowseScript()
	{
		playerMan.fpsScript.lockMove = true;
		playerMan.fpsScript.lockCam = true;
		browseScript.enabled = false;
		browseScript.curAnim = null;
		browseScript.StopAllCoroutines();
		browseScript.CancelInvoke();
		Object.Destroy(browseScript.seeker);
		Object.Destroy(browseScript.pathfinder);
		browseScript.pathfinder.maxSpeed = 0f;
	}

	private void PlayDialogue()
	{
		clydeText.transform.parent.gameObject.SetActive(value: true);
		StartCoroutine(RevealText());
	}

	private void PlayDialogue2()
	{
		clydeText.transform.parent.gameObject.SetActive(value: true);
		StartCoroutine(RevealText_());
	}

	private IEnumerator RevealText()
	{
		clydeText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		clydeText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "Clyde Speech Text 1");
		clydeText.ForceMeshUpdate();
		int totalVisibleCharacters = clydeText.textInfo.characterCount;
		int counter = 0;
		while (true)
		{
			int num = counter % (totalVisibleCharacters + 1);
			clydeText.maxVisibleCharacters = num;
			if (num >= totalVisibleCharacters)
			{
				break;
			}
			counter++;
			yield return new WaitForSeconds(0.03f);
		}
	}

	private IEnumerator RevealText_()
	{
		clydeText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		clydeText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "Clyde Speech Text 2");
		clydeText.ForceMeshUpdate();
		int totalVisibleCharacters = clydeText.textInfo.characterCount;
		int counter = 0;
		while (true)
		{
			int num = counter % (totalVisibleCharacters + 1);
			clydeText.maxVisibleCharacters = num;
			if (num >= totalVisibleCharacters)
			{
				break;
			}
			counter++;
			yield return new WaitForSeconds(0.03f);
		}
		Invoke("CloseText", 1f);
	}

	private void CloseText()
	{
		clydeText.transform.parent.gameObject.SetActive(value: false);
	}

	private void Die()
	{
		if (base.isServer)
		{
			hittable.Die();
		}
		StoreManager.Instance.Invoke("ExitCutscene", 2f);
		StoreManager.Instance.Invoke("BackToPlayer", 2f);
	}

	private void PlayNextAudio()
	{
		audioSequence[audioIndex].gameObject.SetActive(value: true);
		audioIndex++;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TriggerAnimCmd__String(string trigger)
	{
		TriggerAnimRpc(trigger);
	}

	protected static void InvokeUserCode_TriggerAnimCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TriggerAnimCmd called on client.");
		}
		else
		{
			((ClydeDeathCutscene)obj).UserCode_TriggerAnimCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_TriggerAnimRpc__String(string trigger)
	{
		clydeAnim.SetTrigger(trigger);
	}

	protected static void InvokeUserCode_TriggerAnimRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TriggerAnimRpc called on server.");
		}
		else
		{
			((ClydeDeathCutscene)obj).UserCode_TriggerAnimRpc__String(reader.ReadString());
		}
	}

	static ClydeDeathCutscene()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ClydeDeathCutscene), "System.Void ClydeDeathCutscene::TriggerAnimCmd(System.String)", InvokeUserCode_TriggerAnimCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ClydeDeathCutscene), "System.Void ClydeDeathCutscene::TriggerAnimRpc(System.String)", InvokeUserCode_TriggerAnimRpc__String);
	}
}
