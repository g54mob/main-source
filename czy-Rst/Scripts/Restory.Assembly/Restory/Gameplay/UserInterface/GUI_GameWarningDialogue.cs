using System;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using TMPro;
using UnityEngine;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_GameWarningDialogue : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI messageText;

		[SerializeField]
		private TweenSequenceConstructor sequenceConstructor;

		public event Action OnWarningShown;

		private void OnEnable()
		{
			sequenceConstructor.OnSequenceCompleted.AddListener(ResolveSequenceComplete);
		}

		private void OnDisable()
		{
			sequenceConstructor.OnSequenceCompleted.RemoveListener(ResolveSequenceComplete);
			messageText.text = "";
		}

		public void Show(string warningMessage)
		{
			messageText.text = warningMessage;
			sequenceConstructor.StartSequence();
		}

		private void ResolveSequenceComplete()
		{
			this.OnWarningShown?.Invoke();
		}
	}
}
