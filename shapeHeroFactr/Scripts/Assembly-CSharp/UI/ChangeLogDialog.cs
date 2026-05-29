using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class ChangeLogDialog : BaseDialog
	{
		[SerializeField]
		private RectTransform contentsParent;

		[SerializeField]
		private ChangeLogItem logItemPrefab;

		private List<ChangeLogItem> changeLogs;

		private const int logLimit = 10;

		public override void Init()
		{
		}

		private List<(string, string, string)> GetChangeLogs()
		{
			return null;
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}
	}
}
