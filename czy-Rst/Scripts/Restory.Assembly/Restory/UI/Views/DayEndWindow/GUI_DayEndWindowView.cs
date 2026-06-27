using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_DayEndWindowView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_DayEndWindowStatsView dayEndStats;

		[SerializeField]
		private GUI_DayEndWindowStamp dayEndWindowStamp;

		public event Action OnFinalizeDayActionPerformed;

		protected override void OnEnable()
		{
			base.OnEnable();
			dayEndWindowStamp.OnStampingDone += ResolveStampingDone;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			dayEndWindowStamp.OnStampingDone -= ResolveStampingDone;
		}

		public void Show()
		{
			SetVisibility(shouldBeVisible: true);
		}

		public void Hide()
		{
			SetVisibility(shouldBeVisible: false);
		}

		public void SetUpStatsInfo(DayEndWindowStatsArguments arguments)
		{
			dayEndStats.ShowStats(arguments);
		}

		private void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.interactable = shouldBeVisible;
			canvasGroup.blocksRaycasts = shouldBeVisible;
		}

		private void ResolveStampingDone()
		{
			this.OnFinalizeDayActionPerformed?.Invoke();
		}
	}
}
