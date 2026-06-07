using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins.UnityUI
{
	public abstract class UnityUIAlertDialog : MonoBehaviour, IUnityUIAlertDialog
	{
		protected class AlertAction
		{
			public string Title { get; private set; }

			public AlertAction(string title)
			{
			}
		}

		private List<AlertAction> m_actionButtons;

		private List<string> m_inputPlaceholderValues;

		private Action<int, string[]> m_callback;

		public bool IsShowing { get; private set; }

		public string Title { get; set; }

		public string Message { get; set; }

		protected virtual void Start()
		{
		}

		public void AddTextField(string placeholderText)
		{
		}

		public void AddActionButton(string title)
		{
		}

		public virtual void Show()
		{
		}

		public virtual void Dismiss()
		{
		}

		public void SetCompletionCallback(Action<int, string[]> callback)
		{
		}

		protected int GetActionButtonCount()
		{
			return 0;
		}

		protected AlertAction GetActionButtonAtIndex(int index)
		{
			return null;
		}

		protected int GetInputFieldCount()
		{
			return 0;
		}

		protected string GetInputFieldPlaceholderTextAtIndex(int index)
		{
			return null;
		}

		protected void SendCompletionResult(int selectedButtonIndex, string[] inputValues)
		{
		}
	}
}
