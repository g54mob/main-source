using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class ThanksForPlayingDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private BaseInteractable3DUIView _finishButton;

		[SerializeField]
		private BaseInteractable3DUIView _keepPlayingButton;

		[SerializeField]
		private TMP_Text _timeRemainingText;

		private bool _continuePlaying;

		private Action<bool> _keepPlayingCallback;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void Open(Action<bool> callback)
		{
		}

		private void OnFinishButtonClick()
		{
		}

		private void OnKeepPlayingButtonClick()
		{
		}

		protected override void Closed()
		{
		}
	}
}
