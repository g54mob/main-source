using UnityEngine;

[RequireComponent(typeof(SimpleMotor))]
public class SimpleMotorAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip idleMotorClip;

	private SimpleMotor simpleMotor;

	private float maxVolume;

	private float minVolume;

	private float maxPitch;

	private float minPitch;

	private float currentVolumeVelocity;

	private float currentPitchVelocity;

	protected override void Initialize()
	{
		simpleMotor = GetComponent<SimpleMotor>();
		simpleMotor.OnTurnOnMotorEvent += OnTurnOnMotorHandler;
		base.gameObject.GetBlockView().BlockDestroyedEvent += OnBlockDestroyedHandler;
		currentVolumeVelocity = 0f;
		currentPitchVelocity = 0f;
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource != null)
		{
			base.AudioSource.transform.position = base.transform.position;
			if (simpleMotor.IsMotorInUse)
			{
				float currentInputSignal = simpleMotor.CurrentInputSignal;
				base.AudioSource.volume = Mathf.SmoothDamp(base.AudioSource.volume, maxVolume * currentInputSignal, ref currentVolumeVelocity, 0.5f);
				base.AudioSource.pitch = Mathf.SmoothDamp(base.AudioSource.pitch, maxPitch * currentInputSignal, ref currentPitchVelocity, 0.5f);
			}
			else
			{
				base.AudioSource.volume = Mathf.SmoothDamp(base.AudioSource.volume, minVolume, ref currentVolumeVelocity, 0.5f);
				base.AudioSource.pitch = Mathf.SmoothDamp(base.AudioSource.pitch, minPitch, ref currentPitchVelocity, 0.5f);
			}
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		switch (simpleMotor.Type)
		{
		case "combustion_1":
		case "combustion_2":
			idleMotorClip = gameStylesData.componentStylesData.simpleMotorCombustionIdleClip;
			maxVolume = 1f;
			minVolume = 0.2f;
			if (gameStylesData.volumeStylesData != null)
			{
				maxVolume = gameStylesData.volumeStylesData.simpleMotorCombustionMax;
				minVolume = gameStylesData.volumeStylesData.simpleMotorCombustionMin;
			}
			maxPitch = 1.5f;
			minPitch = 0.5f;
			break;
		case "electric_1":
			idleMotorClip = gameStylesData.componentStylesData.simpleMotorElectricIdleClip;
			maxVolume = 0.2f;
			minVolume = 0.02f;
			if (gameStylesData.volumeStylesData != null)
			{
				maxVolume = gameStylesData.volumeStylesData.simpleMotorEletricMax;
				minVolume = gameStylesData.volumeStylesData.simpleMotorEletricMin;
			}
			maxPitch = 2f;
			minPitch = 1f;
			break;
		default:
			idleMotorClip = gameStylesData.componentStylesData.simpleMotorCombustionIdleClip;
			maxVolume = 1f;
			minVolume = 0.2f;
			if (gameStylesData.volumeStylesData != null)
			{
				maxVolume = gameStylesData.volumeStylesData.simpleMotorCombustionMax;
				minVolume = gameStylesData.volumeStylesData.simpleMotorCombustionMin;
			}
			maxPitch = 2f;
			minPitch = 1f;
			break;
		}
	}

	private void OnTurnOnMotorHandler()
	{
		if (base.AudioSource != null)
		{
			base.AudioSource.clip = idleMotorClip;
			base.AudioSource.volume = 0.2f;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
			base.AudioSource.Play();
		}
	}

	private void OnBlockDestroyedHandler()
	{
		RecycleAudioSource();
	}
}
