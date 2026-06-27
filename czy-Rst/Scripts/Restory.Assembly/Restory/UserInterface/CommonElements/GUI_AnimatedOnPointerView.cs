using System.Collections.Generic;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_AnimatedOnPointerView : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private List<TweenSequenceConstructor> sequences;

		public void OnPointerEnter(PointerEventData eventData)
		{
			foreach (TweenSequenceConstructor sequence in sequences)
			{
				sequence.StartSequence();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			foreach (TweenSequenceConstructor sequence in sequences)
			{
				sequence.RewindSequenceToInitialState();
			}
		}
	}
}
