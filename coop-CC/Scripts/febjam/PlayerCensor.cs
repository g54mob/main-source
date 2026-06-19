using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using Dissonance;
using FMODUnity;
using UnityEngine;

public class PlayerCensor : NetworkEntityBehaviourBase
{
	private PlayerStress _playerStress;

	public Transform playerCensorVisual;

	private VoicePlayerState _voice;

	public float bleepDelay = 0.05f;

	public float bleepTime = 1f;

	public float bleepCooldown = 0.5f;

	public float voipAmplitudeBleepThreshold = 0.2f;

	public AnimationCurve bleepVisualCurve;

	public bool bleeping;

	public bool busy;

	public StudioEventEmitter bleepEventEmitter;

	protected override void OnEntityCreated()
	{
		_playerStress = base.entity.GetObject<PlayerStress>();
		playerCensorVisual.transform.localScale = Vector3.zero;
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (base.isLocalPlayer)
		{
			_voice = AggroManagerBase<VoiceManager>.instance.GetLocalPlayerVoicePlayerState();
		}
		else
		{
			_voice = AggroManagerBase<VoiceManager>.instance.GetVoicePlayerStateFromEntity(base.entity);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (_voice != null)
		{
			if (_voice.Amplitude > voipAmplitudeBleepThreshold && !busy && _playerStress.crashingOut)
			{
				busy = true;
				StopAllCoroutines();
				StartCoroutine(BleepCo());
			}
		}
		else
		{
			busy = false;
		}
	}

	private IEnumerator BleepCo()
	{
		yield return new WaitForSeconds(bleepDelay);
		bleeping = true;
		bleepEventEmitter.Play();
		playerCensorVisual.transform.localScale = Vector3.zero;
		float time = 0f;
		while (time < bleepTime)
		{
			float time2 = time / bleepTime;
			playerCensorVisual.transform.localScale = bleepVisualCurve.Evaluate(time2) * Vector3.one;
			time += Time.deltaTime;
			yield return null;
		}
		playerCensorVisual.transform.localScale = Vector3.zero;
		bleeping = false;
		bleepEventEmitter.Stop();
		yield return new WaitForSeconds(bleepCooldown);
		busy = false;
	}

	public override bool Weaved()
	{
		return true;
	}
}
