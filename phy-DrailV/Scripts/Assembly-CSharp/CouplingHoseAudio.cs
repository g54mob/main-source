using DV.Simulation.Brake;
using UnityEngine;

public class CouplingHoseAudio : HoseAudioBase
{
	[Header("Hose sounds")]
	public AudioClip connectSoundWithAirflow;

	public AudioClip connectSoundNoAirflow;

	public AudioClip disconnectSoundPressurized;

	public AudioClip disconnectSoundUnpressurized;

	public LayeredAudio airflowPrefab;

	[Header("Cock sounds")]
	public AudioClip cockOpenShortAirflowSound;

	public AudioClip cockOpenLongAirflowSound;

	public AudioClip cockOpenNoAirflowSound;

	public AudioClip cockCloseSound;

	public Transform cockSoundAnchor;

	private LayeredAudio airflowLayered;

	private CouplingHoseCouplerAdapter adapter;

	private void Awake()
	{
		adapter = GetComponent<CouplingHoseCouplerAdapter>();
	}

	public override void PlayConnectSound()
	{
		AudioClip clip;
		if ((bool)adapter && (bool)adapter.coupler)
		{
			HoseAndCock hoseAndCock = adapter.coupler.hoseAndCock;
			clip = ((hoseAndCock.exhaustFlow > 0.01f || (hoseAndCock.connectedTo != null && hoseAndCock.connectedTo.exhaustFlow > 0.01f)) ? connectSoundWithAirflow : connectSoundNoAirflow);
		}
		else
		{
			clip = connectSoundNoAirflow;
		}
		clip.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}

	public override void PlayDisconnectSound()
	{
		(((bool)adapter && (bool)adapter.coupler && adapter.coupler.hoseAndCock.wasPressurized) ? disconnectSoundPressurized : disconnectSoundUnpressurized).Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}

	public void PlayCockSound(bool open)
	{
		if (!base.enabled)
		{
			return;
		}
		AudioClip clip;
		if (open)
		{
			HoseAndCock hoseAndCock = adapter.coupler.hoseAndCock;
			if (hoseAndCock.IsFullyConnected)
			{
				float num = Mathf.Abs(hoseAndCock.parentSystem.brakePipePressure - hoseAndCock.connectedTo.parentSystem.brakePipePressure);
				clip = ((num > 1f) ? cockOpenLongAirflowSound : ((!(num > 0.1f)) ? cockOpenNoAirflowSound : cockOpenShortAirflowSound));
			}
			else if (hoseAndCock.IsHoseConnected)
			{
				bool flag = (double)hoseAndCock.parentSystem.brakePipePressure > 1.5;
				clip = ((hoseAndCock.wasPressurized ^ flag) ? cockOpenShortAirflowSound : cockOpenNoAirflowSound);
			}
			else
			{
				clip = cockOpenNoAirflowSound;
			}
		}
		else
		{
			clip = cockCloseSound;
		}
		clip.Play(cockSoundAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}

	private void Update()
	{
		if (!adapter || !adapter.coupler)
		{
			return;
		}
		HoseAndCock hoseAndCock = adapter.coupler.hoseAndCock;
		bool flag = hoseAndCock.exhaustFlow > 0.005f && hoseAndCock.IsOpenToAtmosphere;
		if ((bool)airflowLayered)
		{
			if (flag)
			{
				MatchPositionToConnectorAndUpdateVolume(hoseAndCock.exhaustFlow);
				return;
			}
			Object.Destroy(airflowLayered.gameObject);
			airflowLayered = null;
		}
		else if (flag)
		{
			airflowLayered = Object.Instantiate(airflowPrefab.gameObject, base.transform, worldPositionStays: false).GetComponent<LayeredAudio>();
			MatchPositionToConnectorAndUpdateVolume(hoseAndCock.exhaustFlow);
		}
	}

	private void MatchPositionToConnectorAndUpdateVolume(float flow)
	{
		airflowLayered.transform.position = (connector ? connector.position : base.transform.position);
		airflowLayered.Set(flow);
	}
}
