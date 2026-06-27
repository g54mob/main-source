using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.CashRegisters
{
	public class CashRegisterVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Transform cashDrawer;

		[SerializeField]
		private float closePosition;

		[SerializeField]
		private float openPosition = 0.1f;

		[SerializeField]
		private float animationDuration = 0.5f;

		[SerializeField]
		private Ease animationEase = Ease.Linear;

		private TweenSequencesService tweenSequencesService;

		private Sequence sequence;

		public bool IsAnimationActive => sequence.IsActive();

		public event Action OnBeforeAnimationStarted;

		public event Action OnAnimationStarted;

		public event Action OnAnimationCompleted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnDisable()
		{
			tweenSequencesService?.Kill(sequence);
			sequence = null;
		}

		public void SetCashDrawerState(CashDrawerState state, bool animate = true)
		{
			this.OnBeforeAnimationStarted?.Invoke();
			float num = state switch
			{
				CashDrawerState.None => closePosition, 
				CashDrawerState.Open => openPosition, 
				CashDrawerState.Closed => closePosition, 
				CashDrawerState.PartiallyOpen => (openPosition + closePosition) * 0.5f, 
				_ => throw new NotImplementedException(), 
			};
			tweenSequencesService.Kill(sequence);
			if (animate)
			{
				sequence = tweenSequencesService.Create();
				sequence.Append(cashDrawer.DOLocalMoveZ(num, animationDuration).SetEase(animationEase)).OnStart(delegate
				{
					this.OnAnimationStarted?.Invoke();
				}).OnComplete(delegate
				{
					this.OnAnimationCompleted?.Invoke();
				});
			}
			else
			{
				cashDrawer.localPosition = new Vector3(0f, 0f, num);
			}
		}
	}
}
