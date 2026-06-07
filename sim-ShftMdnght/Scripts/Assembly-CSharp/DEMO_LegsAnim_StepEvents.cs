using FIMSpace.FProceduralAnimation;
using UnityEngine;

public class DEMO_LegsAnim_StepEvents : MonoBehaviour, LegsAnimator.ILegStepReceiver
{
	public AudioSource StepSource;

	public AudioClip[] StepClips;

	public AudioClip[] LandClips;

	[Space(4f)]
	public GameObject Particle;

	public void PlayStepAudio(float volumeMul = 1f)
	{
		if (!(StepSource == null) && StepClips.Length != 0)
		{
			StepSource.PlayOneShot(StepClips[Random.Range(0, StepClips.Length)], volumeMul);
		}
	}

	public void PlayLandAudio(float volumeMul = 1f)
	{
		if (!(StepSource == null) && LandClips.Length != 0)
		{
			StepSource.PlayOneShot(LandClips[Random.Range(0, LandClips.Length)], volumeMul);
		}
	}

	public void LegAnimatorStepEvent(LegsAnimator.Leg leg, float power, bool isRight, Vector3 position, Quaternion rotation, LegsAnimator.EStepType type)
	{
		if (Particle != null)
		{
			GameObject gameObject = Object.Instantiate(Particle);
			if (type == LegsAnimator.EStepType.OnLanding)
			{
				gameObject.transform.position = leg.Owner.BaseTransform.position;
				gameObject.transform.localScale = Particle.transform.localScale * 1.65f;
			}
			else
			{
				gameObject.transform.position = position;
			}
			gameObject.transform.rotation = rotation * Quaternion.Euler(-90f, -90f, 0f);
		}
		if (type == LegsAnimator.EStepType.OnLanding)
		{
			PlayLandAudio(Mathf.Lerp(0.75f, 1f, power));
		}
		else
		{
			PlayStepAudio(Mathf.Lerp(0.5f, 1f, power));
		}
	}
}
