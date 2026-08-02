using Dissonance;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(VoiceBroadcastTrigger))]
public class VoicePushToTalkController : MonoBehaviour
{
	[Tooltip("The shared SettingsData asset (same one SettingsManager/AudioSettingsBridge use). Assign this so the controller reads the voice settings even if SettingsManager isn't loaded yet.")]
	[SerializeField]
	private SettingsData settingsData;

	[Tooltip("Fallback used only when neither a SettingsData asset nor a SettingsManager is available.")]
	[SerializeField]
	private bool pushToTalkFallback;

	[Tooltip("Log the resolved voice state to the Console (local player only) for debugging.")]
	[SerializeField]
	private bool debugLog;

	private VoiceBroadcastTrigger _broadcast;

	private VoiceReceiptTrigger _receipt;

	private NetworkBehaviour _net;

	private DissonanceComms _comms;

	private bool IsLocal
	{
		get
		{
			if (_net == null)
			{
				return true;
			}
			if (!NetworkServer.active && !NetworkClient.active)
			{
				return true;
			}
			return _net.isLocalPlayer;
		}
	}

	private SettingsData Data
	{
		get
		{
			if (settingsData != null)
			{
				return settingsData;
			}
			SettingsManager instance = SettingsManager.Instance;
			if (instance != null)
			{
				settingsData = instance.GetSettingsData();
				return settingsData;
			}
			return null;
		}
	}

	private bool VoiceChatEnabled
	{
		get
		{
			SettingsData data = Data;
			if (!(data == null))
			{
				return data.voiceChatEnabled;
			}
			return true;
		}
	}

	private bool PushToTalkEnabled
	{
		get
		{
			SettingsData data = Data;
			if (!(data != null))
			{
				return pushToTalkFallback;
			}
			return data.voicePushToTalk;
		}
	}

	private void Awake()
	{
		_broadcast = GetComponent<VoiceBroadcastTrigger>();
		_receipt = GetComponent<VoiceReceiptTrigger>();
		_net = GetComponent<NetworkBehaviour>();
	}

	private void Update()
	{
		bool isLocal = IsLocal;
		if (_broadcast != null && _broadcast.enabled != isLocal)
		{
			_broadcast.enabled = isLocal;
		}
		if (_receipt != null && _receipt.enabled != isLocal)
		{
			_receipt.enabled = isLocal;
		}
		if (!isLocal)
		{
			return;
		}
		if (_broadcast != null && _broadcast.Mode == CommActivationMode.None)
		{
			_broadcast.Mode = CommActivationMode.VoiceActivation;
		}
		if (_comms == null)
		{
			_comms = Object.FindObjectOfType<DissonanceComms>();
		}
		if (_comms == null)
		{
			return;
		}
		bool voiceChatEnabled = VoiceChatEnabled;
		bool pushToTalkEnabled = PushToTalkEnabled;
		bool flag = !pushToTalkEnabled || IsPushToTalkKeyHeld();
		bool flag2 = voiceChatEnabled && flag;
		if (_comms.IsMuted != !flag2)
		{
			_comms.IsMuted = !flag2;
			if (debugLog)
			{
				Debug.Log(string.Format("[VoiceChat] transmit={0} (voiceOn={1}, ptt={2}, keyHeld={3}, dataSrc={4})", flag2, voiceChatEnabled, pushToTalkEnabled, flag, (settingsData != null) ? "asset" : "none"), this);
			}
		}
		if (_comms.IsDeafened != !voiceChatEnabled)
		{
			_comms.IsDeafened = !voiceChatEnabled;
		}
	}

	private static bool IsPushToTalkKeyHeld()
	{
		UserPrefencesManager instance = Singleton<UserPrefencesManager>.Instance;
		KeyCode keyCode = ((instance != null && instance.keyData != null) ? instance.keyData.PushToTalkKey : KeyCode.V);
		if (keyCode != KeyCode.None)
		{
			return Input.GetKey(keyCode);
		}
		return false;
	}
}
