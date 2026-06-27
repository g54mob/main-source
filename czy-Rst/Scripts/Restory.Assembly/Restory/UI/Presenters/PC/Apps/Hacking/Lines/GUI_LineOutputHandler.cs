using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_LineOutputHandler : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private List<TMP_Text> statuses;

		private int titleOutputProgress;

		private int statusOutputProgress;

		private bool isTitleOutputComplete;

		private bool isStatusOutputComplete;

		private void OnEnable()
		{
			title.maxVisibleCharacters = 0;
			foreach (TMP_Text status in statuses)
			{
				status.maxVisibleCharacters = 0;
			}
			titleOutputProgress = 0;
			statusOutputProgress = 0;
			isTitleOutputComplete = false;
			isStatusOutputComplete = false;
		}

		public void PerformOutput(float outputProgress, out bool outputComplete)
		{
			if (isTitleOutputComplete && isStatusOutputComplete)
			{
				outputComplete = true;
				return;
			}
			if (isTitleOutputComplete)
			{
				OutputStatus(outputProgress);
			}
			else
			{
				OutputTitle(outputProgress);
			}
			outputComplete = isTitleOutputComplete && isStatusOutputComplete;
		}

		private void OutputTitle(float outputProgress)
		{
			titleOutputProgress = (int)outputProgress;
			title.maxVisibleCharacters = titleOutputProgress;
			isTitleOutputComplete = titleOutputProgress >= title.text.Length;
		}

		private void OutputStatus(float outputProgress)
		{
			statusOutputProgress = (int)outputProgress - titleOutputProgress;
			foreach (TMP_Text status in statuses)
			{
				if (status.gameObject.activeSelf)
				{
					status.maxVisibleCharacters = statusOutputProgress;
					isStatusOutputComplete = statusOutputProgress >= status.text.Length;
					return;
				}
			}
			isStatusOutputComplete = true;
		}
	}
}
