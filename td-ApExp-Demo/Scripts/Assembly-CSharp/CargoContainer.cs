using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoContainer : MonoBehaviour
{
	[SerializeField]
	protected List<ParticleSystem>? commonPs;

	[SerializeField]
	protected List<ParticleSystem>? rarePs;

	[SerializeField]
	protected List<ParticleSystem>? epicPs;

	[SerializeField]
	protected List<ParticleSystem>? legendaryPs;

	[SerializeField]
	protected List<ParticleSystem>? commonRevealPs;

	[SerializeField]
	protected List<ParticleSystem>? rareRevealPs;

	[SerializeField]
	protected List<ParticleSystem>? epicRevealPs;

	[SerializeField]
	protected List<ParticleSystem>? legendaryRevealPs;

	public Animator Anim { get; protected set; }

	[field: SerializeField]
	public EnhancementCard Card { get; protected set; }

	[field: SerializeField]
	public Sprite StartingFrameSprite { get; protected set; }

	[field: SerializeField]
	public UnitAudioController unitAudioController { get; protected set; }

	public event Action<CargoContainer> OnContainerOpened;

	public event Action<CargoContainer> OnContainerDropped;

	protected void Awake()
	{
		Anim = GetComponent<Animator>();
	}

	public virtual void ContainerOpened()
	{
		this.OnContainerOpened?.Invoke(this);
	}

	public virtual void ContainerStartedOpening()
	{
		switch (Card.en.Rarity)
		{
		case Rarity.Common:
			EffectsUtils.PlayMultipleParticles(commonRevealPs, play: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(1);
			break;
		case Rarity.Rare:
			EffectsUtils.PlayMultipleParticles(rareRevealPs, play: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(2);
			break;
		case Rarity.Epic:
			EffectsUtils.PlayMultipleParticles(epicRevealPs, play: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(3);
			break;
		case Rarity.Legendary:
			EffectsUtils.PlayMultipleParticles(legendaryRevealPs, play: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(4);
			break;
		}
	}

	public virtual void PreOpen()
	{
		switch (Card.en.Rarity)
		{
		case Rarity.Common:
			EffectsUtils.PlayMultipleParticles(commonPs, play: true);
			break;
		case Rarity.Rare:
			EffectsUtils.PlayMultipleParticles(rarePs, play: true);
			break;
		case Rarity.Epic:
			EffectsUtils.PlayMultipleParticles(epicPs, play: true);
			break;
		case Rarity.Legendary:
			EffectsUtils.PlayMultipleParticles(legendaryPs, play: true);
			break;
		}
	}

	public virtual void ContainerChosen()
	{
		switch (Card.en.Rarity)
		{
		case Rarity.Common:
			EffectsUtils.PlayMultipleParticles(commonRevealPs, play: true);
			EffectsUtils.PlayMultipleParticles(commonPs, play: false, clearOnStop: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(1);
			break;
		case Rarity.Rare:
			EffectsUtils.PlayMultipleParticles(rareRevealPs, play: true);
			EffectsUtils.PlayMultipleParticles(rarePs, play: false, clearOnStop: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(2);
			break;
		case Rarity.Epic:
			EffectsUtils.PlayMultipleParticles(epicRevealPs, play: true);
			EffectsUtils.PlayMultipleParticles(epicPs, play: false, clearOnStop: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(3);
			break;
		case Rarity.Legendary:
			EffectsUtils.PlayMultipleParticles(legendaryRevealPs, play: true);
			EffectsUtils.PlayMultipleParticles(legendaryPs, play: false, clearOnStop: true);
			unitAudioController.PlayOnChannel(0);
			unitAudioController.PlayOnChannel(4);
			break;
		}
		Card.containerOutlineImage.gameObject.SetActive(value: false);
	}

	public virtual void ContainerStartedDropping()
	{
		switch (Card.en.Rarity)
		{
		case Rarity.Common:
			EffectsUtils.PlayMultipleParticles(commonPs, play: false, clearOnStop: true);
			Card.gameObject.GetComponent<Button>().interactable = false;
			break;
		case Rarity.Rare:
			EffectsUtils.PlayMultipleParticles(rarePs, play: false, clearOnStop: true);
			Card.gameObject.GetComponent<Button>().interactable = false;
			break;
		case Rarity.Epic:
			EffectsUtils.PlayMultipleParticles(epicPs, play: false, clearOnStop: true);
			Card.gameObject.GetComponent<Button>().interactable = false;
			break;
		case Rarity.Legendary:
			EffectsUtils.PlayMultipleParticles(legendaryPs, play: false, clearOnStop: true);
			Card.gameObject.GetComponent<Button>().interactable = false;
			break;
		}
		Card.containerOutlineImage.gameObject.SetActive(value: false);
	}

	public void ContainerDropped()
	{
		this.OnContainerDropped?.Invoke(this);
	}
}
