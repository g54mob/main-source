using UnityEngine;

public class RigidbodyAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip impactClip;

	[SerializeField]
	private AudioClip jointBreakClip;

	private AudioEffectData impactAudioData;

	private AudioEffectData jointBreakAudioData;

	protected override void Initialize()
	{
		impactAudioData = new AudioEffectData
		{
			AudioClip = impactClip,
			LoudnessIntensity = AudioEffectData.Loudness.VeryLow
		};
		jointBreakAudioData = new AudioEffectData
		{
			AudioClip = jointBreakClip,
			LoudnessIntensity = AudioEffectData.Loudness.Low
		};
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		impactClip = gameStylesData.rigidbodyStylesData.impactClip;
		jointBreakClip = gameStylesData.rigidbodyStylesData.jointBreakClip;
		if (impactAudioData != null)
		{
			impactAudioData.AudioClip = impactClip;
		}
		if (jointBreakAudioData != null)
		{
			jointBreakAudioData.AudioClip = jointBreakClip;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		float magnitude = collision.impulse.magnitude;
		if (!(magnitude < 1f))
		{
			float num = Mathf.InverseLerp(1f, 20f, magnitude);
			impactAudioData.Volume = num;
			impactAudioData.Priority = (int)(256f - num * 32f);
			PlayOnceEffect(impactAudioData, base.transform.position);
			Debug.Log("Collision Impulse: " + magnitude + " [" + num + "]");
		}
	}

	private void OnJointBreak(float breakForce)
	{
		float num = Mathf.InverseLerp(1000f, 16000f, breakForce);
		jointBreakAudioData.Volume = num;
		jointBreakAudioData.Priority = (int)(224f - num * 32f);
		PlayOnceEffect(jointBreakAudioData, base.transform.position);
		Debug.Log("Joint Break: " + breakForce + " [" + num + "]");
	}
}
