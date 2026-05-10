using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest04 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _openEntryID;

		[SerializeField]
		private LocalizedString _bark01;

		protected override IEnumerator QuestIntroduction()
		{
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_OpenBar);
			yield break;
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.LevelParameters.SetOpened(p_value: true);
		}

		protected override void StartObservingObjectives()
		{
			StopObservingObjectives();
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpening;
			OnBarOpening(CTSSingleton<LevelParameters>.Instance.IsOpen);
		}

		private void OnBarOpening(bool value)
		{
			if (value)
			{
				LevelParameters.OnBarOpenedStatusChanged -= OnBarOpening;
				QuestEntrySuccess(_openEntryID);
				BarkFirstWorker(_bark01.GetLocalizedString());
				base.QuestChain.OpenBarButtonLocker.Lock();
			}
		}

		protected override void StopObservingObjectives()
		{
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpening;
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.LevelParameters.SetOpened(p_value: true);
		}
	}
}
