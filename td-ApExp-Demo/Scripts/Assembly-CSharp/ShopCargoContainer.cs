using UnityEngine;
using UnityEngine.UI;

public class ShopCargoContainer : CargoContainer
{
	[SerializeField]
	private Image cargoImage;

	[SerializeField]
	private Image maskImage;

	[SerializeField]
	private Image iconFrameImage;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private GameObject cardGo;

	[SerializeField]
	private ParticleSystem pillarCommonPs;

	[SerializeField]
	private ParticleSystem pillarRarePs;

	[SerializeField]
	private ParticleSystem pillarEpicPs;

	[SerializeField]
	private ParticleSystem pillarLegendaryPs;

	[SerializeField]
	private GameObject discountTag;

	public void ResetContainer()
	{
		cargoImage.sprite = base.StartingFrameSprite;
		base.Anim.enabled = false;
		maskImage.enabled = false;
		iconFrameImage.enabled = false;
		iconImage.enabled = false;
		cardGo.SetActive(value: false);
	}

	public override void ContainerChosen()
	{
		switch (base.Card.en.Rarity)
		{
		case Rarity.Common:
			EffectsUtils.PlayMultipleParticles(commonRevealPs, play: true);
			pillarCommonPs.Play();
			base.unitAudioController.PlayOnChannel(0);
			base.unitAudioController.PlayOnChannel(1);
			break;
		case Rarity.Rare:
			EffectsUtils.PlayMultipleParticles(rareRevealPs, play: true);
			pillarRarePs.Play();
			base.unitAudioController.PlayOnChannel(0);
			base.unitAudioController.PlayOnChannel(2);
			break;
		case Rarity.Epic:
			EffectsUtils.PlayMultipleParticles(epicRevealPs, play: true);
			pillarEpicPs.Play();
			base.unitAudioController.PlayOnChannel(0);
			base.unitAudioController.PlayOnChannel(3);
			break;
		case Rarity.Legendary:
			EffectsUtils.PlayMultipleParticles(legendaryRevealPs, play: true);
			pillarLegendaryPs.Play();
			base.unitAudioController.PlayOnChannel(0);
			base.unitAudioController.PlayOnChannel(4);
			break;
		}
		discountTag.SetActive(value: false);
	}
}
