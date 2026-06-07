using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_StockUnderPanelEvent : MonoBehaviour
	{
		[SerializeField]
		private StringKey _stringKey;

		public static event Action<StringKey> OnOpenPanel;

		public static event Action<StringKey> OnOpenMaevePanel;

		public void Open()
		{
			UI_StockUnderPanelEvent.OnOpenPanel?.Invoke(_stringKey);
		}

		public void OpenMaeve()
		{
			UI_StockUnderPanelEvent.OnOpenMaevePanel?.Invoke(_stringKey);
		}
	}
}
