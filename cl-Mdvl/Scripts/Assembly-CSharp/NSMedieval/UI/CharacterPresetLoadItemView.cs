using NSEipix.View.UI;
using NSMedieval.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class CharacterPresetLoadItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text entryName;

		[SerializeField]
		private TMP_Text characterName;

		[SerializeField]
		private SoundButton deleteEntryButton;

		[SerializeField]
		private SoundButton entryButton;

		public void SetData(WorkerInstancePreset preset, UnityAction deleteCallback, UnityAction selectedFeedback)
		{
			entryName.SetText(preset.Name);
			characterName.SetText(preset.Instance.Info.FirstName + " " + preset.Instance.Info.LastName);
			deleteEntryButton.AddCleanListener(deleteCallback.Invoke);
			entryButton.AddCleanListener(selectedFeedback.Invoke);
			(base.TooltipNew as CreatureStatsTooltipView)?.SetTooltipData(preset.GetID(), preset.Instance);
		}
	}
}
