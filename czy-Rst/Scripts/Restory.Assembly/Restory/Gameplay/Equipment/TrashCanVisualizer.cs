using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class TrashCanVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Transform lid;

		[SerializeField]
		private Vector3 lidOpenRotation = new Vector3(45f, 0f, 0f);

		[SerializeField]
		private Vector3 lidOpenPosition = new Vector3(0f, 0f, 0f);

		[SerializeField]
		private Ease lidOpenEase = Ease.InCubic;

		[SerializeField]
		private Vector3 lidCloseRotation = new Vector3(0f, 0f, 0f);

		[SerializeField]
		private Vector3 lidClosePosition = new Vector3(0f, 0f, 0f);

		[SerializeField]
		private Ease lidCloseEase = Ease.OutCubic;

		[SerializeField]
		[Min(0f)]
		private float lidOpenCloseDuration = 1.5f;

		private Sequence openCloseLidSequence;

		private TweenSequencesService tweenSequencesService;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		public void OpenLid()
		{
			if (tweenSequencesService != null)
			{
				if (openCloseLidSequence != null)
				{
					tweenSequencesService.Kill(openCloseLidSequence);
				}
				openCloseLidSequence = tweenSequencesService.Create();
				openCloseLidSequence.Append(lid.DOLocalRotate(lidOpenRotation, lidOpenCloseDuration)).Join(lid.DOLocalMove(lidOpenPosition, lidOpenCloseDuration)).SetEase(lidOpenEase);
			}
		}

		public void CloseLid()
		{
			if (tweenSequencesService != null)
			{
				if (openCloseLidSequence != null)
				{
					tweenSequencesService.Kill(openCloseLidSequence);
				}
				openCloseLidSequence = tweenSequencesService.Create();
				openCloseLidSequence.Append(lid.DOLocalRotate(lidCloseRotation, lidOpenCloseDuration)).Join(lid.DOLocalMove(lidClosePosition, lidOpenCloseDuration)).SetEase(lidCloseEase);
			}
		}
	}
}
