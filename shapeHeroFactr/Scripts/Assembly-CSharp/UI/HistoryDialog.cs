using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class HistoryDialog : BaseDialog
	{
		public RectTransform artifactContent;

		public RectTransform upgradeContent;

		public RectTransform unlockContent;

		public RectTransform relicContent;

		public RectTransform enemyContent;

		public ChoiceMenuButtonBase historyImagePrefab;

		private Dictionary<int, List<ChoiceMenuButtonBase>> _waveUnitHistory;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public void CreateChild(RectTransform parent, eArchiveCategory category, string archiveId, int waveCount)
		{
		}

		public ChoiceMenuButtonBase CreateChild(RectTransform parent)
		{
			return null;
		}

		public void UpdateAllHistory()
		{
		}

		public override void Back()
		{
		}
	}
}
