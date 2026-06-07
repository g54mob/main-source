using System;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

public class JournalButtonUI : MonoBehaviour
{
	[SerializeField]
	private Image notifyer;

	[SerializeField]
	private JournalUI journalUI;

	[SerializeField]
	private List<ParticleSystem> particles;

	private Button journalButton;

	private Tween loopingAnimation;

	public event EventHandler OnFirstJournalButtonClick;

	private void Awake()
	{
		journalButton = GetComponentInChildren<Button>();
	}

	private void Start()
	{
		journalButton.onClick.AddListener(delegate
		{
			OnClick();
		});
		if (AllServices.Container.Single<IPersistentProgressService>().Progress.IsShowJournal)
		{
			AnimationStart();
		}
		notifyer.gameObject.SetActive(value: false);
	}

	private void AnimationStart()
	{
		loopingAnimation = base.transform.DOScale(1.2f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
			.Play();
		if (particles.Count > 0)
		{
			foreach (ParticleSystem particle in particles)
			{
				particle.Play();
			}
		}
		AllServices.Container.Single<IPersistentProgressService>().Progress.IsShowJournal = false;
	}

	private void CollectionManager_OnNewPlantInCollection(object sender, EventArgs e)
	{
	}

	private void OnClick()
	{
		if (MovementSystem.Instance.IsMoving())
		{
			return;
		}
		this.OnFirstJournalButtonClick?.Invoke(this, EventArgs.Empty);
		journalUI.Show();
		loopingAnimation.Kill();
		if (particles.Count <= 0)
		{
			return;
		}
		foreach (ParticleSystem particle in particles)
		{
			particle.Stop();
		}
	}

	private void OnDestroy()
	{
		journalButton.onClick.RemoveAllListeners();
	}
}
