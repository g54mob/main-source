using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class MasterMemoSheetCtrl : MonoBehaviour
	{
		public List<MasterMemoSheetBase> sheets;

		public float span;

		private int _index;

		private UnityAction _callback;

		public void SetMessages(eMasterMemo memo)
		{
		}

		public void SetMessages(List<string> messages)
		{
		}

		public void PlayContents(UnityAction callback = null)
		{
		}

		private void NextSheet()
		{
		}

		private void FinishedContents()
		{
		}
	}
}
