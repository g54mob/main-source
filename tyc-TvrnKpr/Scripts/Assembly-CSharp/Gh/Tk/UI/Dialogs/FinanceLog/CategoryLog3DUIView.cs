using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.FinanceLog
{
	public class CategoryLog3DUIView : BaseCollapsibleLogEntry3DUIView
	{
		[SerializeField]
		private TextBlock3DUIView _categoryText;

		[SerializeField]
		private TextMeshPro _incomeText;

		[SerializeField]
		private TextMeshPro _expenditureText;

		[SerializeField]
		private TextMeshPro _totalText;

		private float offsetPerLog;

		[SerializeField]
		private GameObject _entryRowPrefab;

		private static PrefabObjectPool _eventLogPool;

		private List<GameObject> _eventRows;

		public int Income { get; private set; }

		public int Expenditure { get; private set; }

		protected override void Start()
		{
		}

		public void SetValues(string reason, List<TavernLog.TransactionLogEntry> logs)
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
