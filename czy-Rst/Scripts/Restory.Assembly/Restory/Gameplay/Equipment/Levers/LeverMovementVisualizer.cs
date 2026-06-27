using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Levers
{
	public class LeverMovementVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Transform leverObjectToMove;

		[SerializeField]
		private float leverTopXAngle = 60f;

		[SerializeField]
		private float leverBottomXAngle = -60f;

		[SerializeField]
		private float animationDuration = 0.5f;

		[SerializeField]
		private Ease animationEase = Ease.Linear;

		private TweenSequencesService tweenSequencesService;

		private Sequence sequence;

		public event Action OnMovementStarted;

		public event Action OnMovementEnded;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		public void SetLeverToPosition(LeverPositions targetPosition, bool animate = true)
		{
			float x = targetPosition switch
			{
				LeverPositions.None => leverTopXAngle, 
				LeverPositions.Top => leverTopXAngle, 
				LeverPositions.Bottom => leverBottomXAngle, 
				_ => throw new NotImplementedException(), 
			};
			Vector3 localEulerAngles = leverObjectToMove.localEulerAngles;
			Vector3 vector = new Vector3(x, localEulerAngles.y, localEulerAngles.z);
			if (animate)
			{
				if (sequence.IsActive())
				{
					sequence.Kill();
				}
				sequence = tweenSequencesService.Create();
				sequence.Append(leverObjectToMove.DOLocalRotate(vector, animationDuration).SetEase(animationEase)).OnStart(delegate
				{
					this.OnMovementStarted?.Invoke();
				}).OnComplete(delegate
				{
					this.OnMovementEnded?.Invoke();
				});
			}
			else
			{
				leverObjectToMove.rotation = Quaternion.Euler(vector);
			}
		}
	}
}
