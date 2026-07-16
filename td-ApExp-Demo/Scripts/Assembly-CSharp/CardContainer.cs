using UnityEngine;

public class CardContainer : CargoContainer
{
	[SerializeField]
	public UnitAudioController dropAudio;

	[SerializeField]
	protected float dropShakeIntensity;

	[SerializeField]
	protected float dropShakeDuration;

	public virtual void CointainerGrounded()
	{
		dropAudio.PlayOnChannel(0);
		CameraController.Instance.Shake(dropShakeIntensity, dropShakeDuration, force: true);
	}

	public override void ContainerStartedDropping()
	{
		base.ContainerStartedDropping();
		base.unitAudioController.StopChannel(5);
		base.unitAudioController.StopChannel(6);
		base.unitAudioController.StopChannel(7);
		base.unitAudioController.StopChannel(8);
	}

	public override void ContainerChosen()
	{
		base.ContainerChosen();
		base.unitAudioController.StopChannel(5);
		base.unitAudioController.StopChannel(6);
		base.unitAudioController.StopChannel(7);
		base.unitAudioController.StopChannel(8);
	}

	public void PlayBackgroundSFX(Rarity rarity)
	{
		switch (rarity)
		{
		case Rarity.Common:
			base.unitAudioController.PlayOnChannel(5);
			break;
		case Rarity.Rare:
			base.unitAudioController.PlayOnChannel(6);
			break;
		case Rarity.Epic:
			base.unitAudioController.PlayOnChannel(7);
			break;
		case Rarity.Legendary:
			base.unitAudioController.PlayOnChannel(8);
			break;
		}
	}

	public void PlayChainBreakSound()
	{
		dropAudio.PlayOnChannel(1);
	}
}
