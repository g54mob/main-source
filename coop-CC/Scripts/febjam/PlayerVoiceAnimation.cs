using Aggro.Core;
using Aggro.Core.Networking;
using Dissonance;
using UnityEngine;

public class PlayerVoiceAnimation : NetworkEntityBehaviourBase
{
	public float headLookSpeed = 5f;

	public float playerVoiceAnimationThreshold = 0.2f;

	public float playerVoiceLerpSpeed = 25f;

	private VoicePlayerState _voice;

	public Animator animator;

	private float _speechTimer;

	public float speechMinActiveTimeSeconds = 1f;

	public VehicleController vc;

	public bool isPuppet;

	private int expressionSpeakLayer = -1;

	private int faceSpeakLayer = -1;

	protected override void OnUpdatePresentationEarly()
	{
		if (_voice == null)
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
		expressionSpeakLayer = animator.GetLayerIndex("ExpressionSpeak");
		faceSpeakLayer = animator.GetLayerIndex("FaceSpeak");
	}

	protected override void OnUpdatePresentation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		float num = 0f;
		if (_voice != null)
		{
			if (_speechTimer <= 0f)
			{
				if (_voice.Amplitude > playerVoiceAnimationThreshold && !AggroManagerBase<VoiceManager>.instance.isMuted)
				{
					_speechTimer = speechMinActiveTimeSeconds;
					num = 1f;
				}
			}
			else
			{
				num = 1f;
				_speechTimer -= Time.deltaTime;
			}
		}
		else
		{
			num = 0f;
		}
		float weight = Mathf.Lerp(animator.GetLayerWeight(expressionSpeakLayer), num, ((num > 0f) ? playerVoiceLerpSpeed : headLookSpeed) * Time.deltaTime);
		animator.SetLayerWeight(expressionSpeakLayer, weight);
		animator.SetLayerWeight(faceSpeakLayer, num);
	}

	protected override void OnUpdatePresentationLate()
	{
		if (base.isLocalPlayer)
		{
			float num = (isPuppet ? 0f : vc.GetTurnDirForVisual());
			float num2 = ((_voice == null || AggroManagerBase<VoiceManager>.instance.isMuted) ? 0f : ((_voice.Amplitude > playerVoiceAnimationThreshold) ? 1f : 0f));
			bool flag = ((!isPuppet) ? (Vector3.Dot(vc.transform.forward, Vector3.forward) > -0.85f && num2 > 0f) : (num2 > 0f));
			float b = ((!flag) ? num : (isPuppet ? (-0.5f) : ((!(Vector3.SignedAngle(vc.transform.forward, Vector3.forward, Vector3.up) > 0f)) ? 1f : (-1f))));
			animator.SetFloat("headLook", Mathf.Lerp(animator.GetFloat("headLook"), b, (flag ? playerVoiceLerpSpeed : headLookSpeed) * Time.deltaTime));
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
