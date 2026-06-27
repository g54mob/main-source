using System.Collections.Generic;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_AnimatedOnPointerDownUpView : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private List<TweenSequenceConstructor> pointerDownSequences;

		[SerializeField]
		private List<TweenSequenceConstructor> pointerUpSequences;

		public void OnPointerDown(PointerEventData eventData)
		{
			foreach (TweenSequenceConstructor pointerDownSequence in pointerDownSequences)
			{
				pointerDownSequence.StartSequence();
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			foreach (TweenSequenceConstructor pointerUpSequence in pointerUpSequences)
			{
				pointerUpSequence.StartSequence();
			}
		}
	}
}
