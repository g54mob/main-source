using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class SimpleDecisionWindow3DUIView : ShowHideAnimation3DUIView
	{
		[Header("Decision Window")]
		[SerializeField]
		private TextMeshProUGUII18n _titleText;

		[SerializeField]
		private TextBlock3DUIView _messageText;

		[SerializeField]
		private Container3DUIView _decisionButtonContainer;

		[SerializeField]
		private Button3DUIView _decisionButtonPrefab;

		[SerializeField]
		private List<Button3DUIView> _decisionButtons;

		public bool generateActionButtons;

		protected override void Awake()
		{
		}

		public void ShowSaveDiscardCancelDecision(string title, string message, Action saveAction, Action discardAction, Action cancelAction)
		{
		}

		public void ShowOkCancelDecision(string title, string message, Action okAction, Action cancelAction, string okText = null, string cancelText = null)
		{
		}

		public void ShowOkDecision(string title, string message, Action okAction, string okText = null)
		{
		}

		private void ShowDecision(string title, string message, params (Action decisionAction, string decisionText)[] decisions)
		{
		}

		public void CancelDecision()
		{
		}

		public void SetMessageText(string msgKey)
		{
		}

		private void AddDecisionButton(string text, Action action)
		{
		}

		protected virtual void OnDecisionInvoked(Action action)
		{
		}

		public void ShowDecisionWithIds(string message, Dictionary<string, Action> decisionActionLookup)
		{
		}
	}
}
