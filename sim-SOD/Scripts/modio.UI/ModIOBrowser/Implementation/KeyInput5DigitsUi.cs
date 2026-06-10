using System;
using System.Collections.Generic;
using ModIO.Util;
using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class KeyInput5DigitsUi : SelfInstancingMonoSingleton<KeyInput5DigitsUi>
	{
		public KeyInput5Digits keyInput5Digits;

		public List<TMP_Text> texts;

		public List<GameObject> indicators;

		public TMP_Text instructionText;

		private Action onCancel;

		private Action<string> onContinue;

		internal Translation AuthenticationPanelInfoTextTranslation;

		private int MaxDigits => 0;

		protected override void Awake()
		{
		}

		public void Open(Action<string> onContinue, string email, Action onCancel)
		{
		}

		public void SetIndex(int i)
		{
		}

		public void ContinueButton()
		{
		}

		public void CancelButton()
		{
		}

		private void Close()
		{
		}

		private void Continue(string s)
		{
		}

		private void Render(string renderString)
		{
		}

		private void OnIndexChange(int i)
		{
		}
	}
}
