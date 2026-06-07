using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TransactionEntryLog3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextBlock3DUIView _reasonText;

		[SerializeField]
		private TextMeshPro _incomeText;

		[SerializeField]
		private TextMeshPro _expenditureText;

		[SerializeField]
		private TextMeshPro _totalText;

		private Action _lazySetValues;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void SetValues(string reason, int income, int expenditure)
		{
		}

		private void SetValuesInternal(string reason, int income, int expenditure)
		{
		}
	}
}
