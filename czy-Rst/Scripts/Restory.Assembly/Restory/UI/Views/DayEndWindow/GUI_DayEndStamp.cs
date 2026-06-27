using System;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_DayEndStamp : MonoBehaviour
	{
		[SerializeField]
		private TweenSequenceConstructor tweenSequence;

		[SerializeField]
		[Range(0f, 180f)]
		private float permissibleSlopeValue = 30f;

		public event Action OnStampingDone;

		private void OnEnable()
		{
			tweenSequence.OnSequenceCompleted.AddListener(ResolveTweenSequenceComplete);
		}

		private void OnDisable()
		{
			tweenSequence.OnSequenceCompleted.RemoveListener(ResolveTweenSequenceComplete);
		}

		public void Activate()
		{
			base.transform.Rotate(new Vector3(0f, 0f, UnityEngine.Random.Range(0f - permissibleSlopeValue, permissibleSlopeValue)));
			base.gameObject.SetActive(value: true);
			tweenSequence.StartSequence();
		}

		private void ResolveTweenSequenceComplete()
		{
			this.OnStampingDone?.Invoke();
		}
	}
}
