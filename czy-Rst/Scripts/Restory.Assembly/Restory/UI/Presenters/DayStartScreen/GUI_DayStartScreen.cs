using System;
using Restory.Data.TimeSystems;
using Restory.UI.Views.DayStartScreen;
using UnityEngine;

namespace Restory.UI.Presenters.DayStartScreen
{
	public class GUI_DayStartScreen : MonoBehaviour
	{
		[SerializeField]
		private GUI_DayStartScreenView view;

		public float ViewCanvasGroupAlphaValue => view.CanvasGroupAlpha;

		public void Show(int day, DayOfWeekInfo dayOfWeekInfo, bool instantly = false)
		{
			view.SetText(day, dayOfWeekInfo);
			view.Show(instantly);
		}

		public void Hide(bool instantly = false, Action onFullyHiddenCallback = null)
		{
			view.Hide(instantly, onFullyHiddenCallback);
		}
	}
}
