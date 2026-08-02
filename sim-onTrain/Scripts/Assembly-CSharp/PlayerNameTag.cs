using Dissonance;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TsNetworkPlayer))]
public class PlayerNameTag : MonoBehaviour
{
	[Header("References (authored in prefab)")]
	[Tooltip("World-space canvas child that holds the name label.")]
	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private TMP_Text label;

	[Header("Behaviour")]
	[Tooltip("Hide the tag past this distance from the camera (0 = never hide by distance).")]
	[SerializeField]
	private float maxVisibleDistance = 40f;

	[Header("Voice (Dissonance)")]
	[Tooltip("Icon shown while this player is talking above the amplitude threshold.")]
	[SerializeField]
	private GameObject voiceIcon;

	[Tooltip("Voice amplitude (0..1) the player must exceed for the icon to appear.")]
	[SerializeField]
	private float speakAmplitudeThreshold = 0.02f;

	[Tooltip("Once shown, keep the icon on at least this long after the voice drops below the threshold, so brief dips while talking don't make it flicker.")]
	[SerializeField]
	private float voiceIconHoldTime = 0.3f;

	private TsNetworkPlayer _netPlayer;

	private Camera _cam;

	private string _lastName;

	private IDissonancePlayer _dissonancePlayer;

	private DissonanceComms _comms;

	private VoicePlayerState _voiceState;

	private float _voiceHoldTimer;

	private void Awake()
	{
		_netPlayer = GetComponent<TsNetworkPlayer>();
		_dissonancePlayer = GetComponent<IDissonancePlayer>();
		if (canvas != null)
		{
			canvas.gameObject.SetActive(value: false);
		}
		if (voiceIcon != null)
		{
			voiceIcon.SetActive(value: false);
		}
	}

	private void LateUpdate()
	{
		UpdateVoiceIcon();
		if (canvas == null)
		{
			return;
		}
		bool flag = ShouldShow();
		if (canvas.gameObject.activeSelf != flag)
		{
			canvas.gameObject.SetActive(flag);
		}
		if (!flag)
		{
			return;
		}
		if (label != null && _lastName != _netPlayer.playerName)
		{
			_lastName = _netPlayer.playerName;
			label.text = _lastName;
		}
		if (_cam == null)
		{
			_cam = Camera.main;
		}
		if (_cam != null)
		{
			Vector3 forward = canvas.transform.position - _cam.transform.position;
			if (forward.sqrMagnitude > 0.0001f)
			{
				canvas.transform.rotation = Quaternion.LookRotation(forward);
			}
		}
	}

	private void UpdateVoiceIcon()
	{
		if (voiceIcon == null)
		{
			return;
		}
		ResolveVoiceState();
		int num;
		if (_voiceState != null && _dissonancePlayer != null && _dissonancePlayer.Type == NetworkPlayerType.Remote)
		{
			num = ((_voiceState.Amplitude >= speakAmplitudeThreshold) ? 1 : 0);
			if (num != 0)
			{
				_voiceHoldTimer = voiceIconHoldTime;
				goto IL_007c;
			}
		}
		else
		{
			num = 0;
		}
		if (_voiceHoldTimer > 0f)
		{
			_voiceHoldTimer -= Time.deltaTime;
		}
		goto IL_007c;
		IL_007c:
		bool flag = num != 0 || _voiceHoldTimer > 0f;
		if (voiceIcon.activeSelf != flag)
		{
			voiceIcon.SetActive(flag);
		}
	}

	private void ResolveVoiceState()
	{
		if (_voiceState == null && _dissonancePlayer != null && _dissonancePlayer.IsTracking)
		{
			if (_comms == null)
			{
				_comms = Object.FindObjectOfType<DissonanceComms>();
			}
			if (!(_comms == null) && !string.IsNullOrEmpty(_dissonancePlayer.PlayerId))
			{
				_voiceState = _comms.FindPlayer(_dissonancePlayer.PlayerId);
			}
		}
	}

	private bool ShouldShow()
	{
		if (_netPlayer.isLocalPlayer)
		{
			return false;
		}
		if (string.IsNullOrEmpty(_netPlayer.playerName))
		{
			return false;
		}
		SettingsManager instance = SettingsManager.Instance;
		if (instance != null && !instance.GetSettingsData().showPlayerNames)
		{
			return false;
		}
		if (maxVisibleDistance > 0f)
		{
			if (_cam == null)
			{
				_cam = Camera.main;
			}
			if (_cam != null && (_cam.transform.position - base.transform.position).sqrMagnitude > maxVisibleDistance * maxVisibleDistance)
			{
				return false;
			}
		}
		return true;
	}
}
