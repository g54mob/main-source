using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_AnimatedOnEnableView : MonoBehaviour
	{
		[SerializeField]
		private TweenSequenceConstructor onEnableSequence;

		private void OnEnable()
		{
			StartSequence();
		}

		private void StartSequence()
		{
			if (onEnableSequence.IsSequenceActive)
			{
				onEnableSequence.KillSequence();
			}
			onEnableSequence.StartSequence();
		}
	}
}
