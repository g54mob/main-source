using System;
using DG.Tweening;
using Restory.Gameplay.Effects;
using Restory.Infrastructure.StateMachine;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PersonalBoxAppearanceController : MonoBehaviour
	{
		[SerializeField]
		private Transform modelTransform;

		[SerializeField]
		private Transform appearancePoint;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private float transitionDuration = 0.6f;

		[SerializeField]
		private Ease transitionEase = Ease.InQuint;

		private GlobalStateObserver globalStateObserver;

		private TweenSequencesService tweenSequences;

		private VfxService vfxService;

		private Sequence transitionSequence;

		public event Action OnAppearanceCompleted;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver, TweenSequencesService tweenSequences, VfxService vfxService)
		{
			this.globalStateObserver = globalStateObserver;
			this.tweenSequences = tweenSequences;
			this.vfxService = vfxService;
		}

		public void ActivateAppearance()
		{
			animator.enabled = false;
			modelTransform.SetLocalPositionAndRotation(appearancePoint.localPosition, appearancePoint.localRotation);
			if (globalStateObserver.IsLoading)
			{
				globalStateObserver.AddSubscriber(this, OnGlobalStateChanged);
			}
			else
			{
				PlayAppearance();
			}
		}

		private void PlayAppearance()
		{
			TransferModelToOrigin();
		}

		private void OnGlobalStateChanged()
		{
			if (globalStateObserver.IsInGameLoop)
			{
				globalStateObserver.RemoveSubscriber(this);
				PlayAppearance();
			}
		}

		private void TransferModelToOrigin()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(modelTransform.DOLocalMove(Vector3.zero, transitionDuration)).Join(modelTransform.DOLocalRotate(Vector3.zero, transitionDuration)).SetEase(transitionEase)
				.OnComplete(OnTransferComplete);
		}

		private void OnTransferComplete()
		{
			animator.enabled = true;
			vfxService.PlayPlacementEffect(base.transform);
			transitionSequence = null;
			this.OnAppearanceCompleted?.Invoke();
		}
	}
}
