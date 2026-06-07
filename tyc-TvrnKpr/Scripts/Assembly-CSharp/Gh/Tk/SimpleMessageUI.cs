using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class SimpleMessageUI : SingletonMonoBehaviour<SimpleMessageUI>
	{
		[SerializeField]
		private TMP_Text _messageText;

		private float _timeToClearMessage;

		private float _timeRemaining;

		public override void Awake()
		{
		}

		public void Show(string message, bool canClearMessage = false)
		{
		}

		public void Hide(Action callback = null)
		{
		}

		private void ClearMessageOnClick(object sender, InputController.MouseClickEventArgs e)
		{
		}

		private void Update()
		{
		}
	}
}
