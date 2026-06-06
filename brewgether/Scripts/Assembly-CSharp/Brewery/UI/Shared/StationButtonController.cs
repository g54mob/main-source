using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.UI.Shared
{
	public class StationButtonController
	{
		private Button button;

		private readonly StationPulseManager pulseManager;

		public string CurrentText { get; private set; }

		public bool IsEnabled { get; private set; }

		public bool IsPulsing => false;

		public event Action OnClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public StationButtonController(StationPulseManager pulseManager = null)
		{
		}

		public void Bind(Button buttonElement)
		{
		}

		public void SetState(string text, bool enabled)
		{
		}

		public void SetMultiStepState(int stepIndex, string[] stepTexts, string[] processingTexts, bool isProcessing, bool isComplete, bool canStart)
		{
		}

		public void StartPulse()
		{
		}

		public void StopPulse()
		{
		}

		public void SetPulseWhenReady(bool shouldPulse)
		{
		}

		public Button GetButton()
		{
			return null;
		}
	}
}
