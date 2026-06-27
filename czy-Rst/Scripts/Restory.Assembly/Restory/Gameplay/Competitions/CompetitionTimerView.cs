using System;
using System.Collections;
using Restory.UserInterface;
using TMPro;
using UnityEngine;

namespace Restory.Gameplay.Competitions
{
	public class CompetitionTimerView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text timerText;

		[SerializeField]
		private TMP_Text bestTimeText;

		[SerializeField]
		private GUI_LocalisedText resultText;

		[SerializeField]
		private string mistakeLocalisationId = "UI_COMPETITION_PROGRESS_MISTAKE";

		[SerializeField]
		private string completedLocalisationId = "UI_COMPETITION_PROGRESS_COMPLETED";

		[SerializeField]
		private string newBestTimeLocalisationId = "UI_COMPETITION_PROGRESS_NEW_BEST_TIME";

		[SerializeField]
		private float failTextKeepTime = 2f;

		private Coroutine failTextHoldingCoroutine;

		private void OnDisable()
		{
			if (failTextHoldingCoroutine != null)
			{
				StopCoroutine(failTextHoldingCoroutine);
				failTextHoldingCoroutine = null;
			}
		}

		public void SetPreviousBestTime(float timeInSeconds)
		{
			bestTimeText.text = GetFormattedTimeFromSeconds(timeInSeconds);
		}

		public void UpdateView(float timeInSeconds, CompetitionState competitionState = CompetitionState.None)
		{
			timerText.text = GetFormattedTimeFromSeconds(timeInSeconds);
			switch (competitionState)
			{
			case CompetitionState.None:
			case CompetitionState.InProgress:
				if (failTextHoldingCoroutine == null)
				{
					resultText.LocalizationID = string.Empty;
				}
				break;
			case CompetitionState.Failure:
				if (failTextHoldingCoroutine != null)
				{
					StopCoroutine(failTextHoldingCoroutine);
				}
				resultText.LocalizationID = mistakeLocalisationId;
				failTextHoldingCoroutine = StartCoroutine(FailTextHoldingCoroutine());
				break;
			case CompetitionState.Success_WorseThanPreviousTime:
				if (failTextHoldingCoroutine != null)
				{
					StopCoroutine(failTextHoldingCoroutine);
					failTextHoldingCoroutine = null;
				}
				resultText.LocalizationID = completedLocalisationId;
				break;
			case CompetitionState.Success_NewBestTime:
				if (failTextHoldingCoroutine != null)
				{
					StopCoroutine(failTextHoldingCoroutine);
					failTextHoldingCoroutine = null;
				}
				resultText.LocalizationID = newBestTimeLocalisationId;
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private static string GetFormattedTimeFromSeconds(float timeInSeconds)
		{
			return TimeSpan.FromSeconds(timeInSeconds).ToString("hh\\:mm\\:ss");
		}

		private IEnumerator FailTextHoldingCoroutine()
		{
			yield return new WaitForSeconds(failTextKeepTime);
			resultText.LocalizationID = string.Empty;
			failTextHoldingCoroutine = null;
		}
	}
}
