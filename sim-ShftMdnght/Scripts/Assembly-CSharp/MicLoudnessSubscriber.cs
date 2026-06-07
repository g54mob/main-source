using System;
using Dissonance;
using NAudio.Wave;
using UnityEngine;
using UnityEngine.UI;

public class MicLoudnessSubscriber : BaseMicrophoneSubscriber
{
	public Image bar;

	public float loudness;

	public PlayerManager playerMan;

	private void Start()
	{
		bar = StoreManager.Instance.scentBar;
	}

	private void OnEnable()
	{
		DissonanceComms dissonanceComms = UnityEngine.Object.FindObjectOfType<DissonanceComms>();
		if (dissonanceComms != null)
		{
			dissonanceComms.SubscribeToRecordedAudio(this);
		}
	}

	private void OnDisable()
	{
		DissonanceComms dissonanceComms = UnityEngine.Object.FindObjectOfType<DissonanceComms>();
		if (dissonanceComms != null)
		{
			dissonanceComms.UnsubscribeFromRecordedAudio(this);
		}
	}

	protected override void ProcessAudio(ArraySegment<float> data)
	{
		float num = 0f;
		for (int i = 0; i < data.Count; i++)
		{
			float num2 = data.Array[data.Offset + i];
			num += num2 * num2;
		}
		float num3 = 0f;
		if (data.Count > 0)
		{
			num3 = Mathf.Sqrt(num / (float)data.Count);
		}
		if (loudness < num3 * 5f)
		{
			loudness = num3 * 5f;
		}
		if (loudness > 1f)
		{
			loudness = 1f;
		}
	}

	private void FixedUpdate()
	{
		loudness -= Time.deltaTime * 0.2f;
		bar.fillAmount = loudness;
		playerMan.scent = loudness;
	}

	protected override void ResetAudioStream(WaveFormat waveFormat)
	{
		throw new NotImplementedException();
	}
}
