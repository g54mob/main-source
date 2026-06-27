using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Screens
{
	public class GUI_HackingEffect : MonoBehaviour
	{
		[SerializeField]
		private TweenSequenceConstructor sequenceConstructor;

		private void OnDisable()
		{
			if (sequenceConstructor.IsSequenceActive)
			{
				sequenceConstructor.KillSequence();
			}
		}

		public void Play()
		{
			sequenceConstructor.StartSequence();
		}
	}
}
