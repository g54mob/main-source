using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.NPCs
{
	public class NpcView : MonoBehaviour
	{
		[Space]
		[Header("Movement settings")]
		[SerializeField]
		private Vector3 appearPosition;

		[SerializeField]
		private Vector3 dialogPosition;

		[SerializeField]
		private Vector3 gonePosition;

		[SerializeField]
		private float movementSpeed;

		[SerializeField]
		private float rotateDuration;

		[SerializeField]
		private Quaternion dialogDirection;

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		public bool IsActionComplete { get; private set; } = true;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
			base.gameObject.transform.position = appearPosition;
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			if (tweenSequences != null && transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
		}

		public void Arrive()
		{
			IsActionComplete = false;
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			base.transform.position = appearPosition;
			base.transform.rotation = Quaternion.LookRotation(dialogPosition - base.transform.position);
			float duration = Vector3.Distance(base.transform.position, dialogPosition) / movementSpeed;
			base.gameObject.SetActive(value: true);
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(base.transform.DOMove(dialogPosition, duration)).Append(base.transform.DORotateQuaternion(dialogDirection, rotateDuration)).OnComplete(delegate
			{
				IsActionComplete = true;
			});
		}

		public void Leave()
		{
			IsActionComplete = false;
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			Quaternion endValue = Quaternion.LookRotation(gonePosition - base.transform.position);
			float duration = Vector3.Distance(base.transform.position, gonePosition) / movementSpeed;
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(base.transform.DORotateQuaternion(endValue, rotateDuration)).Append(base.transform.DOMove(gonePosition, duration).SetEase(Ease.InOutQuad)).OnComplete(delegate
			{
				IsActionComplete = true;
				base.gameObject.SetActive(value: false);
			});
		}
	}
}
