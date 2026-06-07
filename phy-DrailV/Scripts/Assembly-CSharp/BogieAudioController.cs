using UnityEngine;

public class BogieAudioController
{
	public LayeredAudio currentRollingAudio;

	public LayeredAudio currentSquealingAudio;

	private LayeredAudio rollingAudioDetailed;

	private LayeredAudio rollingAudioSimple;

	private LayeredAudio squealAudioDetailed;

	private LayeredAudio squealAudioSimple;

	private Transform[] audioTransforms;

	private AudioLOD currentLOD;

	public BogieAudioController(LayeredAudio rollingAudioDetailed, LayeredAudio rollingAudioSimple, LayeredAudio squealAudioDetailed, LayeredAudio squealAudioSimple)
	{
		this.rollingAudioDetailed = rollingAudioDetailed;
		this.rollingAudioSimple = rollingAudioSimple;
		this.squealAudioDetailed = squealAudioDetailed;
		this.squealAudioSimple = squealAudioSimple;
		audioTransforms = new Transform[4];
		audioTransforms[0] = rollingAudioDetailed.transform;
		audioTransforms[1] = rollingAudioSimple.transform;
		audioTransforms[2] = squealAudioDetailed.transform;
		audioTransforms[3] = squealAudioSimple.transform;
		currentLOD = AudioLOD.SIMPLE;
		SetLOD(AudioLOD.NONE);
	}

	public void SetLOD(AudioLOD lod)
	{
		if (currentLOD != lod)
		{
			switch (lod)
			{
			case AudioLOD.DETAILED:
				currentRollingAudio = rollingAudioDetailed;
				currentSquealingAudio = squealAudioDetailed;
				DeactivateAudio(rollingAudioSimple);
				rollingAudioDetailed.gameObject.SetActive(value: true);
				DeactivateAudio(squealAudioSimple);
				squealAudioDetailed.gameObject.SetActive(value: true);
				break;
			case AudioLOD.SIMPLE:
				currentRollingAudio = rollingAudioSimple;
				currentSquealingAudio = squealAudioSimple;
				DeactivateAudio(rollingAudioDetailed);
				rollingAudioSimple.gameObject.SetActive(value: true);
				DeactivateAudio(squealAudioDetailed);
				squealAudioSimple.gameObject.SetActive(value: true);
				break;
			case AudioLOD.NONE:
				DeactivateAudio(rollingAudioDetailed);
				DeactivateAudio(rollingAudioSimple);
				DeactivateAudio(squealAudioDetailed);
				DeactivateAudio(squealAudioSimple);
				currentRollingAudio = null;
				currentSquealingAudio = null;
				break;
			}
			currentLOD = lod;
		}
	}

	private void DeactivateAudio(LayeredAudio audio)
	{
		audio.Stop();
		audio.gameObject.SetActive(value: false);
	}

	public void SetAudioLocalPosition(Vector3 desiredLocalPosition)
	{
		for (int i = 0; i < audioTransforms.Length; i++)
		{
			audioTransforms[i].localPosition = desiredLocalPosition;
		}
	}

	public void ResetAudio()
	{
		rollingAudioDetailed.Reset();
		rollingAudioSimple.Reset();
		squealAudioDetailed.Reset();
		squealAudioSimple.Reset();
	}

	public void DestroyAllSources()
	{
		for (int i = 0; i < audioTransforms.Length; i++)
		{
			Object.Destroy(audioTransforms[i].gameObject);
		}
	}
}
