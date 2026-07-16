using System;
using AudioSystem;
using UnityEngine;

public class ModuleCannon : Module
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData reloadSound2;

	[SerializeField]
	private SoundData reloadSound1;

	[SerializeField]
	private SoundData deflectSound;

	[NonSerialized]
	public Cannon cannon;

	private new void Awake()
	{
		base.Awake();
		cannon = base.transform.Find("Mount").GetChild(0).GetComponent<Cannon>();
	}

	private new void Start()
	{
		base.Start();
	}

	protected override void SetEmpSoundChannels()
	{
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		base.OnInteractStart(interactor);
		base.Interactable.OnSetPoint += cannon.SetAim;
		base.Interactable.OnTranslatePoint += cannon.TranslateAim;
		UIManager.Instance.CannonCrosshair.gameObject.SetActive(value: true);
		cannon.SetActive(isActive: true);
		ModuleStartAiming();
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
		base.Interactable.OnSetPoint -= cannon.SetAim;
		base.Interactable.OnTranslatePoint -= cannon.TranslateAim;
		cannon.SetActive(isActive: false);
		ModuleEndAiming();
	}

	protected override void HandleNextLevelSelected()
	{
		if (cannon.AmmoCount < (float)(int)GetUpgradedStatValueByStatType(StatTypes.capacity))
		{
			cannon.TryStopReload();
			cannon.InstantFullReload();
		}
		UIManager.Instance.CannonCrosshair.gameObject.SetActive(value: false);
	}

	protected override void HandleLevelCompleted()
	{
		base.HandleLevelCompleted();
		UIManager.Instance.CannonCrosshair.gameObject.SetActive(value: false);
	}

	public override void HandleJourneyContinued()
	{
		base.HandleJourneyContinued();
		if (cannon.AmmoCount < (float)(int)GetUpgradedStatValueByStatType(StatTypes.capacity))
		{
			cannon.TryStopReload();
			cannon.InstantFullReload(forced: true);
		}
		UIManager.Instance.CannonCrosshair.gameObject.SetActive(value: false);
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
	}

	public override void OnReload(Interactor interactor)
	{
		if (!cannon._reloading && !base.IsFullyBroken && cannon.AmmoCount != (float)(int)GetUpgradedStatValueByStatType(StatTypes.capacity))
		{
			cannon.OnStartReload();
		}
	}

	public void PlayBulletReloadSound()
	{
		soundBuilder.Play(reloadSound2);
	}

	public void PlayReloadSound()
	{
		soundBuilder.Play(reloadSound1);
	}

	public void PlayDeflectSound()
	{
		soundBuilder.Play(deflectSound);
	}
}
