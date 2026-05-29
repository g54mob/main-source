using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.Chat
{
	public class Chat : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<Data> _data;

		private float _totalCellSize;

		private float _oldScrollPosition;

		public EnhancedScroller scroller;

		public InputField myInputField;

		public InputField otherInputField;

		public EnhancedScrollerCellView myTextCellViewPrefab;

		public EnhancedScrollerCellView otherTextCellViewPrefab;

		public EnhancedScrollerCellView spacerCellViewPrefab;

		public int characterWidth;

		public int characterHeight;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void AddNewRow(Data.CellType cellType, string text)
		{
		}

		private void ResizeScroller()
		{
		}

		private void ResetSpacer()
		{
		}

		public void SendButton_Click()
		{
		}

		public void OtherSendButton_Click()
		{
		}

		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			return 0;
		}

		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 0f;
		}

		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			return null;
		}
	}
}
