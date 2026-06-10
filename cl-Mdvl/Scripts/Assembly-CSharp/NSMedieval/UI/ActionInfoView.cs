using System.Collections.Generic;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ActionInfoView : UIView
	{
		[SerializeField]
		private TMP_Text text;

		private string previousSb;

		private Task showTask;

		private void Awake()
		{
			text.text = string.Empty;
			previousSb = string.Empty;
			Hide();
		}

		public void UpdateTextAndShow(List<string> textKeys, bool overrideExisting)
		{
			if (!overrideExisting && base.gameObject.activeInHierarchy)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string textKey in textKeys)
			{
				stringBuilder.AppendLine(textKey);
			}
			if (!(stringBuilder.ToString() == text.text) || !base.gameObject.activeInHierarchy)
			{
				previousSb = text.text;
				UpdateAndShow(stringBuilder.ToString());
			}
		}

		public void HideIfActive(List<string> textKeys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string textKey in textKeys)
			{
				stringBuilder.AppendLine(textKey);
			}
			if (!(stringBuilder.ToString() != text.text))
			{
				Hide();
			}
		}

		public void ShowPrevious()
		{
			Hide();
			if (previousSb == string.Empty || previousSb == text.text)
			{
				previousSb = string.Empty;
			}
			else
			{
				UpdateAndShow(previousSb);
			}
		}

		public override void Show()
		{
			showTask = null;
			base.Show();
		}

		public override void Hide()
		{
			if (showTask != null)
			{
				showTask.Stop();
				showTask = null;
			}
			base.Hide();
		}

		private void UpdateAndShow(string textToShow)
		{
			text.text = textToShow;
			Hide();
			showTask = MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(Show);
		}
	}
}
