using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.FinanceLog
{
	public class DayLog3DUIView : BaseCollapsibleLogEntry3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _dayText;

		[SerializeField]
		private TextMeshPro _incomeText;

		[SerializeField]
		private TextMeshPro _expenditureText;

		[SerializeField]
		private TextMeshPro _totalText;

		[SerializeField]
		private GameObject _categoryRowPrefab;

		private static PrefabObjectPool _categoryRowPool;

		private List<GameObject> _categoryRows;

		[SerializeField]
		private TavernEventEntryLog3DUIView _eventLogPrefab;

		private static PrefabObjectPool _eventLogPool;

		private List<GameObject> _eventRows;

		protected override void Start()
		{
		}

		private void Clear()
		{
		}

		public void SetValues(int day, List<TavernLog.TransactionLogEntry> logs)
		{
		}

		public void SetValues(int day, List<TavernLog.TavernEventLogEntry> logs)
		{
		}

		private void OnValuesSet(int day)
		{
		}
	}
}
