using System;
using System.Collections.Generic;
using System.Linq;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class KeyInput5DigitsUi : SelfInstancingMonoSingleton<KeyInput5DigitsUi>
	{
		public KeyInput5Digits keyInput5Digits;

		public List<TMP_Text> texts = new List<TMP_Text>();

		public List<GameObject> indicators = new List<GameObject>();

		public TMP_Text instructionText;

		private Action onCancel;

		private Action<string> onContinue;

		internal Translation AuthenticationPanelInfoTextTranslation;

		private int MaxDigits => texts.Count;

		protected override void Awake()
		{
			base.Awake();
			keyInput5Digits.Setup();
		}

		public void Open(Action<string> onContinue, string email, Action onCancel)
		{
			this.onCancel = onCancel;
			this.onContinue = onContinue;
			base.gameObject.SetActive(value: true);
			EventSystem.current.SetSelectedGameObject(null);
			keyInput5Digits.NewSession(MaxDigits, Render, Continue);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Input5Digits);
			Translation.Get(AuthenticationPanelInfoTextTranslation, "Please check your email {email} for your 5 digit code to verify it below.", instructionText, email);
		}

		public void SetIndex(int i)
		{
			keyInput5Digits.SetIndex(i);
			OnIndexChange(i);
		}

		public void ContinueButton()
		{
			Continue(keyInput5Digits.GetValues());
		}

		public void CancelButton()
		{
			Close();
			onCancel?.Invoke();
		}

		private void Close()
		{
			base.gameObject.SetActive(value: false);
			keyInput5Digits.EndSession();
		}

		private void Continue(string s)
		{
			Close();
			onContinue?.Invoke(s);
		}

		private void Render(string renderString)
		{
			texts.ForEach(delegate(TMP_Text t)
			{
				t.text = "";
			});
			foreach (int item in Enumerable.Range(0, Mathf.Min(MaxDigits, renderString.Length)))
			{
				texts[item].text = renderString[item].ToString();
			}
			OnIndexChange(keyInput5Digits.index);
		}

		private void OnIndexChange(int i)
		{
			indicators.ForEach(delegate(GameObject x)
			{
				x.gameObject.SetActive(value: false);
			});
			indicators[i].gameObject.SetActive(value: true);
		}
	}
}
