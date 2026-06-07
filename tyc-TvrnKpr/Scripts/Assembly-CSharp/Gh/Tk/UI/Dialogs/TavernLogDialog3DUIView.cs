using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs.FinanceLog;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TavernLogDialog3DUIView : BaseTavernLogDialog3DUIView
	{
		private PrefabObjectPool _dayLogPool;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject _dayLogPrefab;

		private List<DayLog3DUIView> _dayLogs;

		protected override void Awake()
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void Clear()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void PopulateLogs(IEnumerable<TavernLog.TavernEventLogEntry> logEntries)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
