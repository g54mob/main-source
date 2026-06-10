using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	public class HistoryView : UIView
	{
		[SerializeField]
		private TMP_Text detailsText;

		[SerializeField]
		private LayoutGroupView entriesGroup;

		private List<ButtonLayoutItemView> entries = new List<ButtonLayoutItemView>();

		private int currentlySelected;

		private HistoricalRecordsManager historyManager;

		private void Awake()
		{
			historyManager = MonoSingleton<HistoricalRecordsManager>.Instance;
		}

		public override void Show()
		{
			base.Show();
			UpdateEntries();
			ShowEntryDetails(currentlySelected);
		}

		private void UpdateEntries()
		{
			entries.SetAllActive(active: false);
			foreach (HistoryEntry allHistoryEntry in historyManager.GetAllHistoryEntries())
			{
				ButtonLayoutItemView next = entries.GetNext(entriesGroup);
				next.TextObject.SetText(allHistoryEntry.Date + " <style=AltColor>" + allHistoryEntry.TypeText + "</style>");
				int id = allHistoryEntry.ID;
				next.Button.AddCleanListener(delegate
				{
					OnEntryButtonClick(id);
				});
				float a = (((id + 2) % 2 == 0) ? 0.04f : 0.02f);
				next.ImageObject.color = new Color(1f, 1f, 1f, a);
			}
		}

		private void OnEntryButtonClick(int entryId)
		{
			currentlySelected = entryId;
			int num = 0;
			foreach (ButtonLayoutItemView entry in entries)
			{
				entry.Select(num == currentlySelected);
				num++;
			}
			ShowEntryDetails(entryId);
		}

		private void ShowEntryDetails(int entryId)
		{
			HistoryEntry historyEntry = historyManager.GetHistoryEntry(entryId);
			detailsText.SetText("<style=AltColorParagraphTitle>" + historyEntry.TitleText + "</style>\n<style=Desc>" + historyEntry.Date + "</style>\n\n" + historyEntry.DetailsText);
		}
	}
}
